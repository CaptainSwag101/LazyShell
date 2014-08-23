using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using LAZYSHELL.Properties;
using LAZYSHELL.EventScripts;

namespace LAZYSHELL
{
    public static partial class Do
    {
        #region Variables

        private static BackgroundWorker Export_Worker;
        private static BackgroundWorker Import_Worker;

        #endregion

        #region Export

        /// <summary>
        /// Exports an element to a file.
        /// </summary>
        /// <param name="element">The element to export.</param>
        /// <param name="fileName">Ignored. Set this to null when passing parameter.</param>
        /// <param name="fullPath">The full local path, including the filename with the extension.</param>
        public static void Export(object element, string fileName, string fullPath)
        {
            if (element is byte[])
            {
                var fs = new FileStream(fullPath, FileMode.Create, FileAccess.ReadWrite);
                var bw = new BinaryWriter(fs);
                bw.Write((byte[])element);
                bw.Close();
                fs.Close();
            }
            else if (element is Bitmap)
                ((Bitmap)element).Save(fullPath, ImageFormat.Png);
            else
            {
                var bf = new BinaryFormatter();
                var s = File.Create(fullPath);
                bf.Serialize(s, element);
                s.Close();
            }
        }
        /// <summary>
        /// Exports an element to a file.
        /// </summary>
        /// <param name="element">The element to export.</param>
        /// <param name="fileName">The filename to save as, with the extension.</param>
        public static void Export(object element, string fileName)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = fileName;
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            if (element is byte[])
            {
                saveFileDialog.Filter = "Binary files (*.bin)|*.bin|All files (*.*)|*.*";
                saveFileDialog.Title = "Export";
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                    return;
                var fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.ReadWrite);
                var bw = new BinaryWriter(fs);
                bw.Write((byte[])element);
                bw.Close();
                fs.Close();
            }
            else if (element is Bitmap)
            {
                saveFileDialog.Filter = "Image file (*.png)|*.png|All files (*.*)|*.*";
                saveFileDialog.Title = "Save Image";
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                    return;
                ((Bitmap)element).Save(saveFileDialog.FileName, ImageFormat.Png);
            }
            else
            {
                saveFileDialog.Filter = "Data file (*.dat)|*.dat|All files (*.*)|*.*";
                saveFileDialog.Title = "Export";
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                    return;
                var bf = new BinaryFormatter();
                var s = File.Create(saveFileDialog.FileName);
                bf.Serialize(s, element);
                s.Close();
            }
        }
        /// <summary>
        /// Exports a set of elements to files to a specified folder.
        /// </summary>
        /// <param name="elements">The elements to export.</param>
        /// <param name="fileName">The base filename to export as, without an extension.</param>
        /// <param name="folder">The folder to create.</param>
        /// <param name="type">The type of element. Preferably in all caps and singular form.</param>
        /// <param name="showProgressBar">Sets whether or not to show the progress bar when exporting.</param>
        public static void Export(object[] elements, string fileName, string folder, string type, bool showProgressBar)
        {
            // first, open and create directory
            var folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.SelectedPath = Settings.Default.LastDirectory;
            folderBrowserDialog1.Description = "Select directory to export to";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                Settings.Default.LastDirectory = folderBrowserDialog1.SelectedPath;
            else
                return;
            string fullPath = folderBrowserDialog1.SelectedPath + "\\" + folder + "\\" + fileName;
            Export(elements, fullPath, type, showProgressBar);
        }
        /// <summary>
        /// Exports a set of elements to files to a specified full path of a local folder.
        /// </summary>
        /// <param name="elements">The elements to export.</param>
        /// <param name="fullPath">The local path of the folder to export to, plus the filename without the index or extension.</param>
        /// <param name="type">The type of element. Preferably in all caps and singular form.</param>
        /// <param name="showProgressBar">Sets whether or not to show the progress bar when exporting.</param>
        public static void Export(object[] elements, string fullPath, string type, bool showProgressBar)
        {
            var fi = new FileInfo(fullPath);
            var di = new DirectoryInfo(fi.DirectoryName);
            if (!di.Exists)
                di.Create();
            // set the backgroundworker properties
            Do.Export_Worker = new BackgroundWorker();
            Do.Export_Worker.WorkerReportsProgress = true;
            Do.Export_Worker.WorkerSupportsCancellation = true;
            Do.Export_Worker.DoWork += (s, e) => Export_Worker_DoWork(s, e, elements, fullPath);
            Do.Export_Worker.ProgressChanged += (s, e) => Export_Worker_ProgressChanged(s, e, type);
            Do.Export_Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Export_Worker_RunWorkerCompleted);
            if (showProgressBar)
            {
                ProgressBar = new ProgressBar("EXPORTING " + type + "S...", elements.Length, Export_Worker);
                ProgressBar.Show();
            }
            Export_Worker.RunWorkerAsync();
            while (Export_Worker.IsBusy)
                Application.DoEvents();
        }
        private static void Export_Worker_DoWork(object sender, DoWorkEventArgs e, object[] elements, string fullPath)
        {
            // Create the files
            for (int i = 0; i < elements.Length; i++)
            {
                if (Export_Worker.CancellationPending)
                    return;
                Export_Worker.ReportProgress(i);
                object element = elements[i];
                // if saving images
                if (element is Bitmap)
                {
                    ((Bitmap)element).Save(
                        fullPath + "-" + i.ToString("d" + elements.Length.ToString().Length) + ".png", ImageFormat.Png);
                }
                // if a byte[] array, then export to .bin
                else if (element is byte[])
                {
                    var fs = new FileStream(
                        fullPath + "-" + i.ToString("d" + elements.Length.ToString().Length) + ".bin",
                        FileMode.Create, FileAccess.ReadWrite);
                    var bw = new BinaryWriter(fs);
                    bw.Write((byte[])elements[i]);
                    bw.Close();
                    fs.Close();
                }
                // otherwise, export to .dat
                else
                {
                    var bf = new BinaryFormatter();
                    var s = File.Create(
                        fullPath + "-" + i.ToString("d" + elements.Length.ToString().Length) + ".dat");
                    bf.Serialize(s, element);
                    s.Close();
                }
            }
        }
        private static void Export_Worker_ProgressChanged(object sender, ProgressChangedEventArgs e, string type)
        {
            if (ProgressBar != null && ProgressBar.Visible)
                ProgressBar.PerformStep("EXPORTING " + type + " #" + e.ProgressPercentage);
        }
        private static void Export_Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (ProgressBar != null && ProgressBar.Visible)
                ProgressBar.Close();
        }

        #endregion

        #region Import

        /// <summary>
        /// Imports a file into an element.
        /// </summary>
        /// <param name="element">The element to import to.</param>
        /// <param name="fileName">Ignored. Set this to null when passing parameter.</param>
        /// <param name="fullPath">The full local path, including the filename.</param>
        public static object Import(object element, string fullPath)
        {
            if (element is byte[])
            {
                var fs = File.OpenRead(fullPath);
                var br = new BinaryReader(fs);
                element = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();
            }
            else if (element is Bitmap)
            {
                element = new Bitmap(Image.FromFile(fullPath));
            }
            else
            {
                var s = File.OpenRead(fullPath);
                var bf = new BinaryFormatter();
                element = bf.Deserialize(s);
                s.Close();
            }
            return element;
        }
        public static object[] Import(object[] elements, string[] fullPaths)
        {
            if (elements is byte[][])
            {
                elements = new byte[fullPaths.Length][];
                for (int i = 0; i < fullPaths.Length; i++)
                {
                    var fs = File.OpenRead(fullPaths[i]);
                    var br = new BinaryReader(fs);
                    elements[i] = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();
                }
            }
            else if (elements is Bitmap[])
            {
                elements = new Bitmap[fullPaths.Length];
                for (int i = 0; i < fullPaths.Length; i++)
                {
                    elements[i] = new Bitmap(Image.FromFile(fullPaths[i]));
                }
            }
            else
            {
                elements = new object[fullPaths.Length];
                for (int i = 0; i < fullPaths.Length; i++)
                {
                    var s = File.OpenRead(fullPaths[i]);
                    var bf = new BinaryFormatter();
                    elements[i] = bf.Deserialize(s);
                    s.Close();
                }
            }
            return elements;
        }
        /// <summary>
        /// Imports a file into an element.
        /// </summary>
        /// <param name="element">The element to import to.</param>
        /// <param name="fileName">The file to import from.</param>
        public static object Import(object element)
        {
            var openFileDialog = new OpenFileDialog();
            if (element is byte[])
                openFileDialog.Filter = "Binary files (*.bin)|*.bin|All files (*.*)|*.*";
            else if (element is Bitmap)
                openFileDialog.Filter = "Image files (*.gif,*.jpg,*.png)|*.gif;*.jpg;*.png|All files (*.*)|*.*";
            else
                openFileDialog.Filter = "Data files (*.dat)|*.dat|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Title = "Import";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return null;
            return Import(element, openFileDialog.FileName);
        }
        public static object[] Import(object[] elements)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            if (elements is byte[][])
                openFileDialog.Filter = "Binary files (*.bin)|*.bin|All files (*.*)|*.*";
            else if (elements is Bitmap[])
                openFileDialog.Filter = "Image files (*.gif,*.jpg,*.png)|*.gif;*.jpg;*.png|All files (*.*)|*.*";
            else
                openFileDialog.Filter = "Data files (*.dat)|*.dat|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Title = "Import";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return null;
            return Import(elements, openFileDialog.FileNames);
        }
        /// <summary>
        /// Imports a file into an element from a set of files in a specified folder.
        /// </summary>
        /// <param name="element">The elements to import to.</param>
        /// <param name="fileName">The base filename to import as, without an extension.</param>
        /// <param name="folder">The folder to import from.</param>
        /// <param name="type">The type of element. Preferably in all caps and singular form.</param>
        /// <param name="showProgressBar">Sets whether or not to show the progress bar when importing.</param>
        public static void Import(object[] elements, string fileName, string folder, string type, bool showProgressBar)
        {
            // first, open and create directory
            var folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.SelectedPath = Settings.Default.LastDirectory;
            folderBrowserDialog1.Description = "Select directory to import from";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                Settings.Default.LastDirectory = folderBrowserDialog1.SelectedPath;
            else
                return;
            string fullPath = folderBrowserDialog1.SelectedPath + "\\" + folder + "\\" + fileName;
            Import(elements, fullPath, type, showProgressBar);
        }
        /// <summary>
        /// Imports files into a set of elements from a set of files in a specified full path of a local folder.
        /// </summary>
        /// <param name="element">The elements to import to.</param>
        /// <param name="fullPath">The local path of the folder to import from, plus the filename without the index or extension.</param>
        /// <param name="type">The type of element. Preferably in all caps and singular form.</param>
        /// <param name="showProgressBar">Sets whether or not to show the progress bar when importing.</param>
        public static void Import(object[] elements, string fullPath, string type, bool showProgressBar)
        {
            // set the backgroundworker properties
            Do.Import_Worker = new BackgroundWorker();
            Do.Import_Worker.WorkerReportsProgress = true;
            Do.Import_Worker.WorkerSupportsCancellation = true;
            Do.Import_Worker.DoWork += (s, e) => Import_Worker_DoWork(s, e, elements, fullPath);
            Do.Import_Worker.ProgressChanged += (s, e) => Import_Worker_ProgressChanged(s, e, type);
            Do.Import_Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Import_Worker_RunWorkerCompleted);
            if (showProgressBar)
            {
                ProgressBar = new ProgressBar("EXPORTING " + type + "S...", elements.Length, Export_Worker);
                ProgressBar.Show();
            }
            Import_Worker.RunWorkerAsync();
            while (Import_Worker.IsBusy)
                Application.DoEvents();
        }
        private static void Import_Worker_DoWork(object sender, DoWorkEventArgs e, object[] elements, string fullPath)
        {
            // Create the files
            for (int i = 0; i < elements.Length; i++)
            {
                if (Import_Worker.CancellationPending)
                    return;
                Import_Worker.ReportProgress(i);
                // if a byte[] array, then import as .bin
                if (elements[i] is byte[])
                {
                    if (!File.Exists(fullPath + "-" + i.ToString("d" + elements.Length.ToString().Length) + ".bin"))
                        continue;
                    var fs = File.OpenRead(fullPath + "-" + i.ToString("d" + elements.Length.ToString().Length) + ".bin");
                    var br = new BinaryReader(fs);
                    elements[i] = new byte[fs.Length];
                    br.ReadBytes((int)fs.Length).CopyTo((byte[])elements[i], 0);
                    br.Close();
                    fs.Close();
                }
                // otherwise, import as .dat
                else
                {
                    if (!File.Exists(fullPath + "-" + i.ToString("d" + elements.Length.ToString().Length) + ".dat"))
                        continue;
                    var s = File.OpenRead(fullPath + "-" + i.ToString("d" + elements.Length.ToString().Length) + ".dat");
                    var bf = new BinaryFormatter();
                    elements[i] = bf.Deserialize(s);
                    s.Close();
                }
            }
        }
        private static void Import_Worker_ProgressChanged(object sender, ProgressChangedEventArgs e, string type)
        {
            if (ProgressBar != null && ProgressBar.Visible)
                ProgressBar.PerformStep("IMPORTING " + type + " #" + e.ProgressPercentage);
        }
        private static void Import_Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (ProgressBar != null && ProgressBar.Visible)
                ProgressBar.Close();
        }

        #endregion

        #region Miscellaneous

        public static void WriteToTXT(string text, string filename)
        {
            var writer = File.CreateText(filename);
            writer.Write(text);
            writer.Close();
        }
        public static bool CreateDirectory(string directory)
        {
            var directoryInfo = new DirectoryInfo(directory);
            try
            {
                if (!directoryInfo.Exists)
                {
                    directoryInfo.Create();
                }
                return true;
            }
            catch
            {
                MessageBox.Show("Error creating directory in " + directory, "LAZY SHELL");
                return false;
            }
        }
        public static string GetDirectoryPath(string caption)
        {
            var folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.SelectedPath = Settings.Default.LastDirectory;
            folderBrowserDialog1.Description = caption;
            // Display the openFile dialog.
            var result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                Settings.Default.LastDirectory = folderBrowserDialog1.SelectedPath;
                return folderBrowserDialog1.SelectedPath;
            }
            else
                return null;
        }

        #endregion
    }
}
