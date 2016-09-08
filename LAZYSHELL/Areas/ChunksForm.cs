using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using LazyShell.Properties;

namespace LazyShell.Areas
{
    public partial class ChunksForm : Controls.NewForm
    {
        #region Variables

        private OwnerForm ownerForm;
        private Overlay overlay;
        public Chunk Chunk { get; set; }
        private Chunk chunkCopy;
        private List<Chunk> chunks;
        private Bitmap chunkImage;

        #endregion

        #region Methods

        public ChunksForm(OwnerForm ownerForm, Overlay overlay)
        {
            this.ownerForm = ownerForm;
            this.overlay = overlay;
            InitializeComponent();
            InitializeVariables();
            SetChunkImage();
        }
        //
        private void InitializeVariables()
        {
            chunks = new List<Chunk>();
        }
        //
        public void SetChunkImage()
        {
            if (Chunk == null)
                return;
            picture.Size = Chunk.Size;
            chunkImage = Do.PixelsToImage(
                Chunk.GetPixels(ownerForm.Area, ownerForm.Tileset), 
                Chunk.Size.Width, Chunk.Size.Height);
            picture.Invalidate();
        }

        #endregion

        #region Event Handlers

        private void transfer_Click(object sender, EventArgs e)
        {
            if (overlay.Select.Empty || overlay.Select.Size == new Size(0, 0))
            {
                MessageBox.Show("Need to make a selection before creating a new chunk.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // now create the chunk from the selection
            Chunk = new Chunk();
            // can't have chunks with the same name
            int ctr = 0;
            string name = "New chunk";
            foreach (var var in chunks)
            {
                if (var.Name == name)
                {
                    name = name + ctr.ToString();
                    ctr++;
                }
            }
            Chunk.Name = name;
            chunks.Add(Chunk);
            ownerForm.Tilemap.ParseTilemap();
            Chunk.Transfer(ownerForm.Tilemap.Tilemaps_bytes, ownerForm.Map, ownerForm.CollisionMap, overlay.Select.Location, overlay.Select.Terminal);
            // add to listbox
            listBox.BeginUpdate();
            listBox.Items.Add(Chunk.Name);
            listBox.SelectedIndex = listBox.Items.Count - 1;
            listBox.EndUpdate();
        }
        private void import_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Settings.Default.LastRomPath;
            openFileDialog1.Title = "Select files to import";
            openFileDialog1.Filter = "Data files (*.dat)|*.dat|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = true;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            chunks.Clear();
            listBox.Items.Clear();
            foreach (string path in openFileDialog1.FileNames)
            {
                var s = File.OpenRead(path);
                var b = new BinaryFormatter();
                Chunk chunk = b.Deserialize(s) as Chunk;
                chunks.Add(chunk);
                listBox.Items.Add(chunk.Name);
                s.Close();
            }
            if (listBox.Items.Count > 0)
                listBox.SelectedIndex = 0;
        }
        private void export_Click(object sender, EventArgs e)
        {
            if (this.chunks.Count == 0)
                return;
            // first, open and create directory
            var folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.SelectedPath = Settings.Default.LastDirectory;
            folderBrowserDialog1.Description = "Select directory to export to";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                Settings.Default.LastDirectory = folderBrowserDialog1.SelectedPath;
            else
                return;
            string fullPath = folderBrowserDialog1.SelectedPath + "\\";
            var fi = new FileInfo(fullPath);
            var di = new DirectoryInfo(fi.DirectoryName);
            if (!di.Exists)
                di.Create();
            foreach (var chunk in chunks)
                Do.Export(chunk, null, fullPath + chunk.Name + ".dat");
        }
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
                return;
            Chunk = chunks[listBox.SelectedIndex];
            renameText.Text = Chunk.Name;
            SetChunkImage();
            export.Enabled = true;
            listBox.Enabled = true;
            toolStrip1.Enabled = true;
        }
        private void rename_Click(object sender, EventArgs e)
        {
            renameText.Visible = rename.Checked;
        }
        private void renameText_TextChanged(object sender, EventArgs e)
        {
            if (this.chunks.Count == 0)
                return;
            if (renameText.Text == "")
            {
                MessageBox.Show("A chunk name cannot be empty.", "LAZY SHELL");
                return;
            }
            foreach (var c in this.chunks)
            {
                if (this.Chunk != c && renameText.Text == c.Name)
                {
                    MessageBox.Show("Cannot rename " + c.Name + ". A chunk with the name you specified already exists.",
                       "LAZY SHELL");
                    return;
                }
                else if (this.Chunk == c && this.Chunk.Name == renameText.Text)
                    return;
            }
            this.Chunk.Name = renameText.Text;
            listBox.Items[listBox.SelectedIndex] = this.Chunk.Name;
        }
        private void delete_Click(object sender, EventArgs e)
        {
            if (Chunk == null || chunks.Count == 0)
                return;
            chunks.Remove(Chunk);
            int temp = listBox.SelectedIndex;
            listBox.BeginUpdate();
            listBox.Items.Clear();
            foreach (var c in chunks)
                listBox.Items.Add(c.Name);
            listBox.EndUpdate();
            if (chunks.Count == 0)
            {
                export.Enabled = false;
                listBox.Enabled = false;
                renameText.Text = "";
                toolStrip1.Enabled = false;
                chunkImage = null;
                picture.Invalidate();
                Chunk = null;
            }
            else if (chunks.Count == temp)
                listBox.SelectedIndex = temp - 1;
            else
                listBox.SelectedIndex = temp;
        }
        private void copy_Click(object sender, EventArgs e)
        {
            if (Chunk == null || chunks.Count == 0)
                return;
            chunkCopy = Chunk;
        }
        private void paste_Click(object sender, EventArgs e)
        {
            if (chunkCopy == null || chunks.Count == 0)
                return;
            Chunk = chunkCopy;
            chunks.Add(Chunk);
            listBox.Items.Add(Chunk.Name);
            listBox.SelectedIndex = listBox.Items.Count - 1;
            listBox.Enabled = true;
            renameText.Enabled = true;
            rename.Enabled = true;
            renameText.Text = Chunk.Name;
        }
        private void picture_Paint(object sender, PaintEventArgs e)
        {
            if (chunkImage != null)
                e.Graphics.DrawImage(chunkImage, 0, 0);
        }

        #endregion
    }
}
