using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Media;
using System.Text;
using System.Windows.Forms;
using LazyShell.Properties;

namespace LazyShell.Audio
{
    public partial class SamplesForm : Controls.DockForm
    {
        #region Variables

        private Settings settings = Settings.Default;
        public SoundPlayer SoundPlayer = new SoundPlayer();
        private byte[] wav;
        private byte[] loop;
        public int Index
        {
            get { return (int)sampleNum.Value; }
            set { sampleNum.Value = value; }
        }
        private BRRSample[] samples
        {
            get { return Model.BRRSamples; }
            set { Model.BRRSamples = value; }
        }
        private BRRSample sample
        {
            get { return samples[Index]; }
            set { samples[Index] = value; }
        }
        //
        private Search searchWindow;
        private EditLabel labelWindow;
        private FindReferences findReferencesForm;
        private delegate void FindReferencesFunction(TreeView treeView);

        #endregion

        // Constructor
        public SamplesForm()
        {
            InitializeComponent();
            InitializeListControls();
            InitializeNavigationControls();
            CreateHelperForms();
            LoadProperties();
            //
            this.History = new History(this, sampleName, sampleNum);
        }

        #region Methods

        private void InitializeListControls()
        {
            this.Updating = true;
            //
            sampleName.Items.AddRange(Lists.Numerize(Lists.Samples));
            sampleRateName.SelectedIndex = 5;
            sampleName.SelectedIndex = 0;
            //
            this.Updating = false;
        }
        private void InitializeNavigationControls()
        {
            this.Updating = true;
            //
            if (settings.RememberLastIndex)
                Index = settings.LastAudioSample;
            //
            this.Updating = false;
        }
        private void CreateHelperForms()
        {
            searchWindow = new Search(sampleNum, searchNames, sampleName.Items);
            labelWindow = new EditLabel(sampleName, sampleNum, "Samples", true);
        }
        private void RefreshWAVBuffer()
        {
            wav = BRR.BRRToWAV(sample.Sample, sample.Rate);
            loop = BRR.BRRToWAV(sample.Sample, sample.Rate, sample.LoopStart);
            picture.Invalidate();
        }
        private void LoadProperties()
        {
            this.Updating = true;
            //
            relFreq.Value = sample.RelFreq;
            relGain.Value = sample.RelGain;
            loopStart.Value = sample.LoopStart / 9;
            RefreshWAVBuffer();
            //
            this.Updating = false;
        }

        /// <summary>
        /// Draws the wavelength graphics for the specified WAV data to a graphics source.
        /// </summary>
        /// <param name="g">The graphics to draw to.</param>
        /// <param name="width">The width of the graphics, in pixels.</param>
        /// <param name="height">The height of the graphics, in pixels</param>
        /// <param name="wav">The WAV data.</param>
        private void DrawWavelength(Graphics g, int width, int height, byte[] wav)
        {
            int size = Bits.GetInt32(wav, 0x0028) / 2;
            int offset = 0x2C;
            List<Point> points = new List<Point>();
            double w_ratio = (double)width / (double)size;
            double h_ratio = (double)height / 65536.0;
            for (int i = 0; i < size; i++)
            {
                int x = (int)((double)i * w_ratio);
                int y = (int)((double)(Bits.GetShort(wav, offset) ^ 0x8000) * h_ratio);
                points.Add(new Point(x, y));
                offset += 2;
            }
            int loopStart = (int)((double)sample.LoopStart / (double)sample.Length * (double)width);
            if (loopStart < 0)
                loopStart = 0;
            g.DrawLine(Pens.Gray, 0, height / 2, width, height / 2);
            g.DrawLine(Pens.Gray, loopStart, 0, loopStart, height);
            g.DrawLines(Pens.Lime, points.ToArray());
        }

        /// <summary>
        /// Searches for references to the current sample in other elements of the Mario RPG ROM
        /// and writes the results to a specified TreeView control.
        /// </summary>
        /// <param name="treeView"></param>
        private void FindReferences(TreeView treeView)
        {
            // look through SPC tracks
            var spcTrackResults = new TreeNode();
            foreach (var spc in Model.SPCs)
            {
                if (spc.Channels == null)
                    continue;
                for (int c = 0; c < spc.Channels.Length; c++)
                {
                    if (spc.Channels[c] == null)
                        continue;
                    var channel = spc.Channels[c];
                    for (int i = 0; i < channel.Count; i++)
                    {
                        if (channel[i] == null)
                            continue;
                        var command = channel[i];
                        byte opcode = command.Opcode;
                        if (opcode == 0xDE)
                        {
                            int referenceSample = command.Param1;
                            // if points to this sample, create a node from result and add to the parent node
                            if (referenceSample == this.Index)
                            {
                                var node = new TreeNode("SPC #" + spc.Index + ", channel " + c + ", index " + i + " {" + Lists.SPCTracks[spc.Index] + "}");
                                node.Tag = command;
                                spcTrackResults.Nodes.Add(node);
                            }
                        }
                    }
                }
            }
            if (spcTrackResults.Nodes.Count > 0)
            {
                spcTrackResults.Text = "SPC TRACKS — found " + spcTrackResults.Nodes.Count + " results";
                treeView.Nodes.Add(spcTrackResults);
            }
            // look through SPC event sounds
            var spcEventSoundResults = new TreeNode();
            foreach (var spc in Model.SPCEvent)
            {
                if (spc.Channels == null)
                    continue;
                for (int c = 0; c < spc.Channels.Length; c++)
                {
                    if (spc.Channels[c] == null)
                        continue;
                    var channel = spc.Channels[c];
                    for (int i = 0; i < channel.Count; i++)
                    {
                        if (channel[i] == null)
                            continue;
                        var command = channel[i];
                        byte opcode = command.Opcode;
                        if (opcode == 0xDE)
                        {
                            int referenceSample = command.Param1;
                            // if points to this sample, create a node from result and add to the parent node
                            if (referenceSample == this.Index)
                            {
                                var node = new TreeNode("SPC #" + spc.Index + ", channel " + c + ", index " + i + " {" + Lists.SPCEventSounds[spc.Index] + "}");
                                node.Tag = command;
                                spcEventSoundResults.Nodes.Add(node);
                            }
                        }
                    }
                }
            }
            if (spcEventSoundResults.Nodes.Count > 0)
            {
                spcEventSoundResults.Text = "SPC EVENT SOUNDS — found " + spcEventSoundResults.Nodes.Count + " results";
                treeView.Nodes.Add(spcEventSoundResults);
            }
            // look through SPC battle sounds
            var spcBattleSoundResults = new TreeNode();
            foreach (var spc in Model.SPCBattle)
            {
                if (spc.Channels == null)
                    continue;
                for (int c = 0; c < spc.Channels.Length; c++)
                {
                    if (spc.Channels[c] == null)
                        continue;
                    var channel = spc.Channels[c];
                    for (int i = 0; i < channel.Count; i++)
                    {
                        if (channel[i] == null)
                            continue;
                        var command = channel[i];
                        byte opcode = command.Opcode;
                        if (opcode == 0xDE)
                        {
                            int referenceSample = command.Param1;
                            // if points to this sample, create a node from result and add to the parent node
                            if (referenceSample == this.Index)
                            {
                                var node = new TreeNode("SPC #" + spc.Index + ", channel " + c + ", index " + i + " {" + Lists.SPCBattleSounds[spc.Index] + "}");
                                node.Tag = command;
                                spcBattleSoundResults.Nodes.Add(node);
                            }
                        }
                    }
                }
            }
            if (spcBattleSoundResults.Nodes.Count > 0)
            {
                spcBattleSoundResults.Text = "SPC BATTLE SOUNDS — found " + spcBattleSoundResults.Nodes.Count + " results";
                treeView.Nodes.Add(spcBattleSoundResults);
            }
        }

        // Read/write ROM
        public void WriteToROM()
        {
            int i = 0;
            int offset06 = 0x060939;
            int offset14 = 0x146000;
            int offset1C = 0x1C8000;
            int offset1D = 0x1DC600;
            // check if room for next in bank 14
            for (; i < samples.Length && offset14 + samples[i].Length < 0x148000; i++)
                samples[i].WriteToROM(ref offset14);
            // check if room for next in bank 06
            for (; i < samples.Length && offset06 + samples[i].Length < 0x094000; i++)
                samples[i].WriteToROM(ref offset06);
            // check if room for next in bank 1C
            for (; i < samples.Length && offset1C + samples[i].Length < 0x1CEA00; i++)
                samples[i].WriteToROM(ref offset1C);
            // check if room for next in bank 1D
            for (; i < samples.Length && offset1D + samples[i].Length < 0x1DDE00; i++)
                samples[i].WriteToROM(ref offset1D);
            if (i < samples.Length)
                MessageBox.Show("Not enough space to save all samples. Stopped saving at index " + i.ToString("d3") + ".");
        }

        #endregion

        #region Event Handlers

        // Navigators
        private void sampleNum_ValueChanged(object sender, EventArgs e)
        {
            sampleName.SelectedIndex = (int)sampleNum.Value;
            //
            if (!this.Updating)
            {
                LoadProperties();
                if (settings.RememberLastIndex)
                    settings.LastAudioSample = (int)sampleNum.Value;
            }
        }
        private void sampleName_SelectedIndexChanged(object sender, EventArgs e)
        {
            sampleNum.Value = sampleName.SelectedIndex;
        }
        private void findReferences_Click(object sender, EventArgs e)
        {
            if (findReferencesForm == null)
            {
                findReferencesForm = new FindReferences(new FindReferencesFunction(FindReferences), null);
                findReferencesForm.Owner = this;
            }
            else
                findReferencesForm.Reload();
            findReferencesForm.Show();
        }

        // Properties
        private void sampleRate_CheckedChanged(object sender, EventArgs e)
        {
            RefreshWAVBuffer();
            sampleRateName.Enabled = rateFixed.Checked;
            rateManualValue.Enabled = rateManual.Checked;
        }
        private void sampleRateName_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshWAVBuffer();
        }
        private void rateManualValue_ValueChanged(object sender, EventArgs e)
        {
            RefreshWAVBuffer();
        }
        private void loopStart_ValueChanged(object sender, EventArgs e)
        {
            sample.LoopStart = (int)loopStart.Value * 9;
            if (!this.Updating)
                RefreshWAVBuffer();
        }
        private void relGain_ValueChanged(object sender, EventArgs e)
        {
            sample.RelGain = (short)relGain.Value;
            if (!this.Updating)
                RefreshWAVBuffer();
        }
        private void relFreq_ValueChanged(object sender, EventArgs e)
        {
            sample.RelFreq = (short)relFreq.Value;
            if (!this.Updating)
                RefreshWAVBuffer();
        }
        private void buttonPitch_Click(object sender, EventArgs e)
        {
            if (pitchChange.SelectedIndex < 0)
                return;
            if (pitchChange.SelectedIndex == 0 && relFreq.Value - 512 >= -32768)
                relFreq.Value -= 512;
            if (pitchChange.SelectedIndex == 1 && relFreq.Value - 256 >= -32768)
                relFreq.Value -= 256;
            if (pitchChange.SelectedIndex == 2 && relFreq.Value + 256 <= 32767)
                relFreq.Value += 256;
            if (pitchChange.SelectedIndex == 3 && relFreq.Value + 512 <= 32767)
                relFreq.Value += 512;
        }

        // Playback
        private void play_Click(object sender, EventArgs e)
        {
            SoundPlayer.Stop();
            if (infiniteLoop.Checked)
                Do.Play(SoundPlayer, loop, true);
            else
                Do.Play(SoundPlayer, wav, false);
        }
        private void back_Click(object sender, EventArgs e)
        {
            if (sampleNum.Value > 0)
                sampleNum.Value--;
            SoundPlayer.Stop();
            Do.Play(SoundPlayer, wav, false);
        }
        private void foward_Click(object sender, EventArgs e)
        {
            if (sampleNum.Value < sampleNum.Maximum)
                sampleNum.Value++;
            SoundPlayer.Stop();
            Do.Play(SoundPlayer, wav, false);
        }
        private void pause_Click(object sender, EventArgs e)
        {
            SoundPlayer.Stop();
        }

        // Picture
        private void picture_Paint(object sender, PaintEventArgs e)
        {
            DrawWavelength(e.Graphics, picture.Width, picture.Height, wav);
        }
        private void picture_SizeChanged(object sender, EventArgs e)
        {
            picture.Invalidate();
        }

        // Import / Export
        private void import_Click(object sender, EventArgs e)
        {
            new IOElements(Model.BRRSamples, IOMode.Import, Index, "IMPORT SAMPLE WAVs...").ShowDialog();
            RefreshWAVBuffer();
        }
        private void importBRR_Click(object sender, EventArgs e)
        {
            new IOElements(Model.BRRSamples, IOMode.Import, Index, "IMPORT SAMPLE BRRs...").ShowDialog();
            RefreshWAVBuffer();
        }
        private void export_Click(object sender, EventArgs e)
        {
            new IOElements(Model.BRRSamples, IOMode.Export, Index, "EXPORT SAMPLE WAVs...", sample.Rate).ShowDialog();
        }
        private void exportBRR_Click(object sender, EventArgs e)
        {
            new IOElements(Model.BRRSamples, IOMode.Export, Index, "EXPORT SAMPLE BRRs...", sample.Rate).ShowDialog();
        }
        private void clear_Click(object sender, EventArgs e)
        {
            new ClearElements(Model.BRRSamples, Index, "CLEAR SAMPLES...").ShowDialog();
            RefreshWAVBuffer();
        }
        private void reset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reset the current sample? You will lose all unsaved changes.",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            sample = new BRRSample(Index);
            LoadProperties();
        }

        #endregion
    }
}
