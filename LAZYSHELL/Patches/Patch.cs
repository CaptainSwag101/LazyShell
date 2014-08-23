using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Net;
using LAZYSHELL.Properties;

namespace LAZYSHELL.Patches
{
    class Patch
    {
        #region Variables

        // Miscellaneous
        private byte flags;
        private string imageName;
        private Settings settings = Settings.Default;
        private WebClient client = new WebClient();

        // Properties
        public int PatchNum { get; set; }
        public string PatchName { get; set; }
        public Image PatchImage { get; set; }
        public string Author { get; set; }
        public string CreationDate { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string Extra { get; set; }
        public Uri PatchURI { get; set; }
        public bool AssemblyHack
        {
            get { return Bits.GetBit(flags, 0); }
        }
        public bool GameHack
        {
            get { return Bits.GetBit(flags, 1); }
        }
        public bool FreshRom
        {
            get { return Bits.GetBit(flags, 2); }
        }

        #endregion

        // Constructor
        public Patch(int patchNum, byte[] patch)
        {
            this.PatchNum = patchNum;
            ReadFromBuffer(patch);
        }

        #region Methods

        // Read/write buffer
        private void ReadFromBuffer(byte[] patch)
        {
            MemoryStream ms = new MemoryStream(patch);
            ms.Seek(0x1B, SeekOrigin.Current);
            //
            flags = Convert.ToByte(ms.ReadByte());
            //
            StreamReader st = new StreamReader(ms);
            PatchName = st.ReadLine();
            Author = st.ReadLine();
            Size = st.ReadLine();
            CreationDate = st.ReadLine();
            Description = st.ReadLine();
            Extra = st.ReadLine();
            imageName = st.ReadLine();
            PatchURI = new Uri(settings.PatchServerURL + "patch" + this.PatchNum.ToString() + "\\" + st.ReadLine());
            //
            DownloadImage();
        }
        private void DownloadImage()
        {
            try
            {
                Stream st = client.OpenRead(settings.PatchServerURL + "patch" + PatchNum.ToString() + "\\" + imageName);
                PatchImage = new Bitmap(st);
            }
            catch
            {
                PatchImage = null;
            }
        }

        #endregion
    }
}
