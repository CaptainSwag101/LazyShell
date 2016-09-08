using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LazyShell.Audio
{
    public static class Model
    {
        #region Variables

        // ROM buffer
        public static byte[] ROM
        {
            get { return LazyShell.Model.ROM; }
            set { LazyShell.Model.ROM = value; }
        }

        // SPCs
        private static SPCTrack[] spcs;
        private static SPCSound[] spcEvent;
        private static SPCSound[] spcBattle;
        public static SPCTrack[] SPCs
        {
            get
            {
                if (spcs == null)
                {
                    spcs = new SPCTrack[74];
                    for (int i = 0; i < spcs.Length; i++)
                        spcs[i] = new SPCTrack(i);
                }
                return spcs;
            }
            set { spcs = value; }
        }
        public static SPCSound[] SPCEvent
        {
            get
            {
                if (spcEvent == null)
                {
                    spcEvent = new SPCSound[163];
                    for (int i = 0; i < spcEvent.Length; i++)
                        spcEvent[i] = new SPCSound(i, ElementType.SPCEvent);
                }
                return spcEvent;
            }
            set { spcEvent = value; }
        }
        public static SPCSound[] SPCBattle
        {
            get
            {
                if (spcBattle == null)
                {
                    spcBattle = new SPCSound[211];
                    for (int i = 0; i < spcBattle.Length; i++)
                        spcBattle[i] = new SPCSound(i, ElementType.SPCBattle);
                }
                return spcBattle;
            }
            set { spcBattle = value; }
        }

        // Samples
        private static BRRSample[] brrSamples;
        public static BRRSample[] BRRSamples
        {
            get
            {
                if (brrSamples == null)
                {
                    brrSamples = new BRRSample[116];
                    for (int i = 0; i < brrSamples.Length; i++)
                        brrSamples[i] = new BRRSample(i);
                }
                return brrSamples;
            }
            set { brrSamples = value; }
        }

        #endregion

        #region Methods

        // Free space
        public static int FreeSPCTrackSpace(bool showWarning)
        {
            int offset = 0x045526;
            int endOffset = 0x060939;
            foreach (var spc in Model.SPCs)
            {
                if (spc == null || spc.Samples == null || spc.Data == null)
                    continue;
                offset += 3; // Reverb
                foreach (var sample in spc.Samples)
                    if (sample != null && sample.Active)
                        offset += 2;
                offset++; // 0xFF
                offset += 2; // SPC size
                offset += spc.Data.Length;
                for (int i = 0; i < spc.Channels.Length; i++)
                {
                    if (!spc.ActiveChannels[i] || spc.Channels[i] == null || spc.Channels[i].Count == 0)
                        continue;
                    var lastSSC = spc.Channels[i][spc.Channels[i].Count - 1];
                    if (lastSSC.Opcode != 0xD0 && lastSSC.Opcode != 0xCD && lastSSC.Opcode != 0xCE)
                        offset++;
                }
            }
            int left = endOffset - offset;
            if (showWarning && left < 0)
                MessageBox.Show("Not enough space to save all SPCs.", "LAZY SHELL");
            return endOffset - offset;
        }
        public static int FreeSPCEventSpace(bool showWarning)
        {
            int offset = 0x042C26;
            int endOffset = 0x043E26;
            foreach (SPCSound sound in Model.SPCEvent)
            {
                if (sound == null || sound.Channels == null)
                    continue;
                offset += sound.GetLength();
            }
            int left = endOffset - offset;
            if (showWarning && left < 0)
                MessageBox.Show("Not enough space to save all event sound effects.", "LAZY SHELL");
            return left;
        }
        public static int FreeSPCBattleSpace(bool showWarning)
        {
            int offset = 0x044226;
            int endOffset = 0x045426;
            foreach (var sound in Model.SPCBattle)
            {
                if (sound == null || sound.Channels == null)
                    continue;
                offset += sound.GetLength();
            }
            int left = endOffset - offset;
            if (showWarning && left < 0)
                MessageBox.Show("Not enough space to save all battle sound effects.", "LAZY SHELL");
            return left;
        }

        // Export elements
        public static void ExportBRRSample(string fullPath, int index)
        {
            Do.Export(BRRSamples[index].Sample,
                "brr-sample-" + index.ToString("d3") + ".brr", fullPath);
        }
        public static void ExportBRRSamples(string fullPath)
        {
            byte[][] samples = new byte[BRRSamples.Length][];
            for (int i = 0; i < brrSamples.Length; i++)
                samples[i] = brrSamples[i].Sample;
            Do.Export(samples,
                fullPath + "\\" + LazyShell.Model.GetFileNameWithoutPath() + " - BRR Samples\\" + "brr-sample",
                "BRR SAMPLE", true);
        }
        public static void ExportWAVSample(string fullPath, int index, int rate)
        {
            Do.Export(BRR.BRRToWAV(BRRSamples[index].Sample, rate),
                "wav-sample-" + index.ToString("d3") + ".wav", fullPath);
        }
        public static void ExportWAVSamples(string fullPath, int rate)
        {
            byte[][] samples = new byte[BRRSamples.Length][];
            int i = 0;
            foreach (var brr in BRRSamples)
                samples[i++] = BRR.BRRToWAV(brr.Sample, rate);
            Do.Export(samples,
                fullPath + "\\" + LazyShell.Model.GetFileNameWithoutPath() + " - WAV Samples\\" + "wav-sample",
                "SAMPLE", true);
        }
        public static void ExportSPC(string fullPath, int index)
        {
            Do.Export(SPCs[index], null, fullPath);
        }
        public static void ExportSPCs(string fullPath)
        {
            Do.Export(SPCs, fullPath + "\\" + LazyShell.Model.GetFileNameWithoutPath() + " - SPCs\\" + "spc", "SPC", true);
        }

        // Import elements
        public static bool ImportBRRSample(int index, string fullPath)
        {
            try
            {
                byte[] sample = (byte[])Do.Import(new byte[1], fullPath);
                BRRSamples[index].Sample = sample;
            }
            catch
            {
                MessageBox.Show("Error importing .brr file.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;
        }
        public static bool ImportBRRSamples(string fullPath)
        {
            byte[][] samples = new byte[BRRSamples.Length][];
            try
            {
                Do.Import(samples, fullPath + "\\" + "sampleBRR", "BRR SAMPLE", true);
            }
            catch
            {
                MessageBox.Show("Error importing .brr file(s).",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            int i = 0;
            foreach (var sample in BRRSamples)
                sample.Sample = samples[i++];
            //
            return true;
        }
        public static bool ImportWAVSample(int index, string fullPath)
        {
            try
            {
                byte[] sample = (byte[])Do.Import(new byte[1], fullPath);
                BRRSamples[index].Sample = BRR.Encode(sample);
            }
            catch
            {
                MessageBox.Show("Error encoding .wav file.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;
        }
        public static bool ImportWAVSamples(string fullPath)
        {
            byte[][] samples = new byte[BRRSamples.Length][];
            try
            {
                Do.Import(samples, fullPath + "\\" + "sampleWAV", "WAV SAMPLE", true);
            }
            catch
            {
                MessageBox.Show("Error encoding .wav file(s).",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            int i = 0;
            foreach (var sample in BRRSamples)
                sample.Sample = BRR.Encode(samples[i++]);
            //
            return true;
        }
        public static bool ImportSPC(int index, string fullPath)
        {
            var spc = new Audio.SPCTrack();
            try
            {
                spc = (Audio.SPCTrack)Do.Import(spc, fullPath);
            }
            catch
            {
                MessageBox.Show("File not an SPC data file.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            spc.ParseScript();
            SPCs[index] = spc;
            //
            return true;
        }
        public static bool ImportSPCs(string fullPath)
        {
            var spcs = new Audio.SPCTrack[SPCs.Length];
            for (int i = 0; i < spcs.Length; i++)
                spcs[i] = new Audio.SPCTrack();
            try
            {
                Do.Import(spcs, fullPath + "\\" + "spc", "SPC", true);
            }
            catch
            {
                MessageBox.Show("One or more files not an SPC data file.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            for (int i = 0; i < spcs.Length; i++)
            {
                if (spcs[i].Data == null)
                    continue;
                SPCs[i] = spcs[i];
                SPCs[i].ParseScript();
            }
            return true;
        }

        // Model management
        public static void ClearAll()
        {
            brrSamples = null;
            spcEvent = null;
            spcBattle = null;
            spcs = null;
        }
        public static void LoadAll()
        {
            object dummy;
            dummy = BRRSamples;
            dummy = SPCEvent;
            dummy = SPCBattle;
            dummy = SPCs;
        }

        #endregion
    }
    public enum ExportMode
    {
        ExportSPC, ExportStaffs
    }
}
