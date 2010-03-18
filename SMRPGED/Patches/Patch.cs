using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Net;
using SMRPGED.Properties;

namespace SMRPGED.Patches
{
    class Patch
    {
        private string patchName, author, creationDate, description, size, extra;
        private Uri patchURI;
        private Settings settings;
        
        private WebClient client = new WebClient();

        
        private int patchNum; public int PatchNum { get { return this.patchNum; } }
        private Image patchImage; public Image PatchImage { get { return patchImage; } }
        
        public string PatchName { get { return patchName; } }
        public string Author { get { return author; } }
        public string CreationDate { get { return creationDate; } }
        public string Description { get { return description; } }
        public string Size { get { return this.size; } }
        public string Extra { get { return this.extra; } }

        public Uri PatchURI { get { return patchURI; } }
        private byte flags;
        
        public bool AssemblyHack { get { return BitManager.GetBit(flags, 0); } }
        public bool GameHack { get { return BitManager.GetBit(flags, 1); } }
        public bool FreshRom { get { return BitManager.GetBit(flags, 2); } }

        
        private string imageName;

        public Patch(int patchNum, byte[] data)
        {
            this.patchNum = patchNum;
            this.settings = Settings.Default;
            Dissassemble(data);
        }
        private void Dissassemble(byte[] data)
        {
            MemoryStream ms = new MemoryStream(data);
            flags = Convert.ToByte(ms.ReadByte());

            StreamReader st = new StreamReader(ms);

            patchName = st.ReadLine();
            author = st.ReadLine();
            size = st.ReadLine(); 
            creationDate = st.ReadLine();
            description = st.ReadLine();
            extra = st.ReadLine(); 
            imageName = st.ReadLine();
            patchURI = new Uri(settings.patchServerURL + "Patch" + this.patchNum.ToString() + "\\" + st.ReadLine());

            DownloadImage();
        }
        private void DownloadImage()
        {
            try
            {
                Stream st = client.OpenRead(settings.patchServerURL + "Patch" + patchNum.ToString() + "\\" + imageName);
                patchImage = new Bitmap(st);
            }
            catch
            {
                patchImage = null;
            }
        }


    }
}
