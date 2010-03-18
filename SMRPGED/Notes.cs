using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SMRPGED.Properties;

namespace SMRPGED
{
    public sealed class Notes
    {
        static Notes instance = null; // Our instance
        static readonly object padlock = new object(); // Ensures only one instance of this object
        private string path; // The path to the notes package directory
        private Settings settings;


        Notes()
        {
            settings = Settings.Default;
        }

        public static Notes Instance
        {
            get
            {
                lock (padlock)
                {
                    if(instance == null)
                    {
                        instance = new Notes();
                    }
                    return instance;
                }

            }
        }

        public void SetPath(string path, string name)
        {
            try
            {
                if (name != null && path != null)
                    this.path = path + name.Substring(0, name.LastIndexOf('.')) + "Notes\\";
            }
            catch
            {
                if (name != null && path != null)
                    this.path = path + name + "Notes\\";   
            }
        }
        public string GetPath()
        {
            return this.path;
        }
        public bool GetLoadNotes()
        {
            return settings.LoadNotes;
        }
        public void SetLoadNotes(bool value)
        {
            settings.LoadNotes = value;
            settings.Save();   
        }
        public bool CreateNoteSet()
        {
            if (!CreateNoteDir())
                return false;

            // Note List
            if (!CreateNote("main-changes.rtf"))
                return false;
            if (!CreateNote("main-modification.rtf"))
                return false;
            if (!CreateNote("main-stats-monsters.rtf"))
                return false;
            if (!CreateNote("main-stats-formations.rtf"))
                return false;
            if (!CreateNote("main-stats-spells.rtf"))
                return false;
            if (!CreateNote("main-stats-attacks.rtf"))
                return false;
            if (!CreateNote("main-stats-dialogue.rtf"))
                return false;
            if (!CreateNote("main-levels.rtf"))
                return false;
            if (!CreateNote("main-scripts-battle.rtf"))
                return false;
            if (!CreateNote("main-scripts-event.rtf"))
                return false;

            return true;
        }
        public bool CreateNoteDir()
        {
            DirectoryInfo di = new DirectoryInfo(path);

            try
            {
                if (!di.Exists && settings.LoadNotes)
                {
                    di.Create();
                }
                return true;
            }
            catch
            {
                MessageBox.Show("Sorry, there was an error trying to create the directory for the notes set", "Error");
                return false;
            }
        }
        private bool CreateNote(string name)
        {
            FileStream fs;
            try
            {
                fs = new FileStream(path + name, FileMode.CreateNew);
            }
            catch
            {
                // Do nothing, we dont want to overwrite an existing note set
                return true;
            }
            BinaryWriter bw = new BinaryWriter(fs);
            // A blank rtf file
            char[] toWrite = "\x7B\x5C\x72\x74\x66\x31\x5C\x61\x6E\x73\x69\x5C\x61\x6E\x73\x69\x63\x70\x67\x31\x32\x35\x32\x5C\x64\x65\x66\x66\x30\x5C\x64\x65\x66\x6C\x61\x6E\x67\x31\x30\x33\x33\x7B\x5C\x66\x6F\x6E\x74\x74\x62\x6C\x7B\x5C\x66\x30\x5C\x66\x73\x77\x69\x73\x73\x5C\x66\x63\x68\x61\x72\x73\x65\x74\x30\x20\x41\x72\x69\x61\x6C\x3B\x7D\x7D\x0D\x0A\x7B\x5C\x2A\x5C\x67\x65\x6E\x65\x72\x61\x74\x6F\x72\x20\x4D\x73\x66\x74\x65\x64\x69\x74\x20\x35\x2E\x34\x31\x2E\x31\x35\x2E\x31\x35\x30\x37\x3B\x7D\x5C\x76\x69\x65\x77\x6B\x69\x6E\x64\x34\x5C\x75\x63\x31\x5C\x70\x61\x72\x64\x5C\x66\x30\x5C\x66\x73\x32\x30\x5C\x70\x61\x72\x0D\x0A\x7D\x0D\x0A\x00".ToCharArray();

            try
            {
                bw.Write(toWrite);
                bw.Close();
            }
            catch
            {
                MessageBox.Show("Sorry, there was an error creating file " + path + name + "in the note set", "Error");
                return false;
            }

            return true;
        }
    }
}
