using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LazyShell.Properties;

namespace LazyShell.Audio
{
    public partial class InstrumentsForm : Controls.DockForm
    {
        #region Variables

        private OwnerForm owner;
        public SPC SPC
        {
            get { return owner.SPC; }
            set { owner.SPC = value; }
        }
        public int Index
        {
            get { return owner.Index; }
            set { owner.Index = value; }
        }
        public ComboBox[] sampleIndexes;
        public NumericUpDown[] volumes;
        public CheckBox[] activeInstruments;
        private Settings settings;
        private ElementType Type
        {
            get { return owner.Type; }
            set { owner.Type = value; }
        }

        #endregion

        // Constructor
        public InstrumentsForm(OwnerForm owner)
        {
            this.owner = owner;
            InitializeComponent();
            InitializeVariables();
            InitializeListControls();
            InitializeControls();
        }

        #region Methods

        private void InitializeVariables()
        {
            this.settings = Settings.Default;
        }
        private void InitializeControls()
        {
            this.Updating = true;
            //
            sampleIndexes = new ComboBox[20];
            volumes = new NumericUpDown[20];
            activeInstruments = new CheckBox[20];
            for (int i = 0; i < sampleIndexes.Length; i++)
            {
                sampleIndexes[i] = new ComboBox();
                sampleIndexes[i].Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
                sampleIndexes[i].DropDownStyle = ComboBoxStyle.DropDownList;
                sampleIndexes[i].Enabled = false;
                sampleIndexes[i].FormattingEnabled = true;
                sampleIndexes[i].Items.AddRange(Lists.Numerize(Lists.Samples));
                sampleIndexes[i].Location = new Point(21, i * 21 + 35);
                sampleIndexes[i].Name = "sampleIndex" + i;
                sampleIndexes[i].Size = new Size(139, 21);
                sampleIndexes[i].TabIndex = i;
                sampleIndexes[i].Tag = i;
                sampleIndexes[i].SelectedIndexChanged += new EventHandler(sampleIndex_SelectedIndexChanged);
                panelInstruments.Controls.Add(sampleIndexes[i]);
                //
                volumes[i] = new NumericUpDown();
                volumes[i].Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Right);
                volumes[i].Enabled = false;
                volumes[i].Location = new Point(160, i * 21 + 35);
                volumes[i].Maximum = 127;
                volumes[i].Name = "volume" + i;
                volumes[i].Size = new Size(44, 21);
                volumes[i].TabIndex = i;
                volumes[i].Tag = i;
                volumes[i].TextAlign = HorizontalAlignment.Right;
                volumes[i].ValueChanged += new EventHandler(volume_ValueChanged);
                panelInstruments.Controls.Add(volumes[i]);
                //
                activeInstruments[i] = new CheckBox();
                activeInstruments[i].AutoSize = true;
                activeInstruments[i].Location = new Point(3, i * 21 + 38);
                activeInstruments[i].Tag = i;
                activeInstruments[i].CheckedChanged += new EventHandler(activeInstrument_CheckedChanged);
                panelInstruments.Controls.Add(activeInstruments[i]);
            }
            //
            this.Updating = false;
        }
        private void InitializeListControls()
        {
            this.Updating = true;
            //
            percussivePitch.Items.AddRange(Lists.Pitches);
            percussiveName.Items.AddRange(Lists.Numerize(Lists.Samples));
            //
            this.Updating = false;
        }

        public void LoadProperties()
        {
            LoadInstrumentProperties();
            LoadReverberationProperties();
            BuildPercussiveListBox();
            LoadPercussiveProperties();
        }
        private void LoadInstrumentProperties()
        {
            this.Updating = true;
            //
            panelInstruments.Enabled = Index != 0 && Type == ElementType.SPCTrack;
            for (int i = 0; i < sampleIndexes.Length; i++)
            {
                if (Index == 0 || Type != ElementType.SPCTrack || SPC.Samples[i] == null)
                {
                    activeInstruments[i].Checked = false;
                    sampleIndexes[i].SelectedIndex = 0;
                    volumes[i].Value = 0;
                }
                else
                {
                    activeInstruments[i].Checked = SPC.Samples[i].Active;
                    sampleIndexes[i].SelectedIndex = SPC.Samples[i].Sample;
                    volumes[i].Value = SPC.Samples[i].Volume;
                }
                sampleIndexes[i].Enabled = activeInstruments[i].Checked;
                volumes[i].Enabled = activeInstruments[i].Checked;
            }
            //
            this.Updating = false;
        }
        private void LoadReverberationProperties()
        {
            this.Updating = true;
            //
            panelReverberation.Enabled = Index != 0 && Type == ElementType.SPCTrack;
            delayTime.Value = SPC.DelayTime;
            decayFactor.Value = SPC.DecayFactor;
            echo.Value = (sbyte)SPC.Echo;
            //
            this.Updating = false;
        }
        private void LoadPercussiveProperties()
        {
            this.Updating = true;
            //
            panelPercussions.Enabled = Index != 0 && Type == ElementType.SPCTrack;
            //
            percussivePitchIndex.Enabled = SPC.Percussives != null && SPC.Percussives.Count > 0;
            percussiveName.Enabled = SPC.Percussives != null && SPC.Percussives.Count > 0;
            percussivePitch.Enabled = SPC.Percussives != null && SPC.Percussives.Count > 0;
            percussiveVolume.Enabled = SPC.Percussives != null && SPC.Percussives.Count > 0;
            percussiveBalance.Enabled = SPC.Percussives != null && SPC.Percussives.Count > 0;
            if (SPC.Percussives == null || SPC.Percussives.Count == 0 || percussives.SelectedIndex >= SPC.Percussives.Count)
            {
                percussivePitchIndex.SelectedIndex = 0;
                percussiveName.SelectedIndex = 0;
                percussivePitch.SelectedIndex = 0;
                percussiveVolume.Value = 0;
                percussiveBalance.Value = 0;
            }
            else
            {
                percussivePitchIndex.SelectedIndex = (int)SPC.Percussives[percussives.SelectedIndex].PitchIndex;
                percussiveName.SelectedIndex = SPC.Percussives[percussives.SelectedIndex].Sample;
                percussivePitch.SelectedIndex = SPC.Percussives[percussives.SelectedIndex].Pitch;
                percussiveVolume.Value = SPC.Percussives[percussives.SelectedIndex].Volume;
                percussiveBalance.Value = SPC.Percussives[percussives.SelectedIndex].Balance;
            }
            //
            this.Updating = false;
        }
        private void BuildPercussiveListBox()
        {
            this.Updating = true;
            //
            percussives.Items.Clear();
            if (Index != 0 && Type == ElementType.SPCTrack)
            {
                for (int i = 0; i < SPC.Percussives.Count; i++)
                {
                    int index = SPC.Percussives[i].Sample;
                    percussives.Items.Add(Lists.Numerize(Lists.Samples[index], index, 3));
                }
            }
            if (percussives.Items.Count > 0)
                percussives.SelectedIndex = 0;
            //
            this.Updating = false;
        }

        /// <summary>
        /// Loads a new instrument table to the current instrument collection.
        /// </summary>
        /// <param name="newInstruments">The new instruments.</param>
        /// <param name="globalVol">The new volume of all instruments.</param>
        public void LoadNewInstruments(List<int> newInstruments, int globalVol)
        {
            if (globalVol == -1)
                globalVol = 100;
            for (int i = 0; i < 20; i++)
            {
                if (i < newInstruments.Count)
                {
                    if (SPC.Samples[i] == null)
                        SPC.Samples[i] = new SampleIndex((byte)newInstruments[i], 100);
                    else
                        SPC.Samples[i].Sample = newInstruments[i];
                    SPC.Samples[i].Volume = globalVol;
                    SPC.Samples[i].Active = true;
                    activeInstruments[i].Checked = true;
                    sampleIndexes[i].SelectedIndex = (byte)newInstruments[i];
                    sampleIndexes[i].Enabled = true;
                    volumes[i].Enabled = true;
                    volumes[i].Value = globalVol;
                }
                else
                {
                    if (SPC.Samples[i] != null)
                        SPC.Samples[i].Active = false;
                    activeInstruments[i].Checked = false;
                    sampleIndexes[i].Enabled = false;
                    volumes[i].Enabled = false;
                }
            }
        }

        #endregion

        #region Event Handlers

        // Instruments
        private void sampleIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = (int)(sender as ComboBox).Tag;
            if (!this.Updating)
            {
                for (int i = 0; i < SPC.Channels.Length; i++)
                {
                    if (SPC.Channels[i] == null)
                        continue;
                    foreach (var ssc in SPC.Channels[i])
                    {
                        if (ssc.Opcode == 0xDE && ssc.Param1 == SPC.Samples[index].Sample)
                            ssc.Param1 = (byte)sampleIndexes[index].SelectedIndex;
                    }
                }
                SPC.Samples[index].Sample = (byte)sampleIndexes[index].SelectedIndex;
                //
                owner.RefreshPictures();
            }
        }
        private void volume_ValueChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                int index = (int)(sender as NumericUpDown).Tag;
                SPC.Samples[index].Volume = (int)volumes[index].Value;
            }
        }
        private void activeInstrument_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                int index = (int)(sender as CheckBox).Tag;
                if (activeInstruments[index].Checked)
                {
                    if (SPC.Samples[index] == null)
                        SPC.Samples[index] = new SampleIndex(sampleIndexes[index].SelectedIndex, (int)volumes[index].Value);
                    SPC.Samples[index].Active = true;
                    sampleIndexes[index].Enabled = true;
                    volumes[index].Enabled = true;
                }
                else
                {
                    if (SPC.Samples[index] != null)
                        SPC.Samples[index].Active = false;
                    sampleIndexes[index].Enabled = false;
                    volumes[index].Enabled = false;
                }
                owner.SetFreeBytesLabel();
                owner.RefreshPictures();
            }
        }

        // Reverb
        private void delayTime_ValueChanged(object sender, EventArgs e)
        {
            SPC.DelayTime = (byte)delayTime.Value;
        }
        private void decayFactor_ValueChanged(object sender, EventArgs e)
        {
            SPC.DecayFactor = (byte)decayFactor.Value;
        }
        private void echo_ValueChanged(object sender, EventArgs e)
        {
            SPC.Echo = (byte)((sbyte)echo.Value);
        }

        // Percussives
        private void newPercussive_Click(object sender, EventArgs e)
        {
            if (SPC.Percussives.Count >= 12)
            {
                MessageBox.Show("No more than 12 percussives allowed.", "LAZY SHELL",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int index = percussives.SelectedIndex + 1;
            SPC.Percussives.Insert(index, new Percussive(0, 0, 0, 0, 0));
            //
            this.Updating = true;
            //
            percussives.Items.Insert(index, Lists.Numerize(Lists.Samples, 0, 3));
            percussives.SelectedIndex = Math.Min(percussives.Items.Count - 1, index);
            LoadPercussiveProperties();
            //
            this.Updating = false;
        }
        private void deletePercussive_Click(object sender, EventArgs e)
        {
            if (SPC.Percussives.Count == 0)
                return;
            if (percussives.SelectedIndex < 0)
            {
                MessageBox.Show("No percussives selected.", "LAZY SHELL",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int index = percussives.SelectedIndex;
            SPC.Percussives.RemoveAt(index);
            //
            this.Updating = true;
            //
            percussives.Items.RemoveAt(index);
            percussives.SelectedIndex = Math.Min(percussives.Items.Count - 1, index);
            LoadPercussiveProperties();
            //
            this.Updating = false;
        }
        private void percussives_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
                LoadPercussiveProperties();
        }
        private void percussivePitchIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            SPC.Percussives[percussives.SelectedIndex].PitchIndex = (Pitch)percussivePitchIndex.SelectedIndex;
        }
        private void percussiveName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Updating = true;
            //
            int index = percussiveName.SelectedIndex;
            percussives.Items[percussives.SelectedIndex] = Lists.Numerize(Lists.Samples[index], index, 3);
            SPC.Percussives[percussives.SelectedIndex].Sample = (byte)index;
            //
            this.Updating = false;
        }
        private void percussivePitch_SelectedIndexChanged(object sender, EventArgs e)
        {
            SPC.Percussives[percussives.SelectedIndex].Pitch = (byte)percussivePitch.SelectedIndex;
        }
        private void percussiveVolume_ValueChanged(object sender, EventArgs e)
        {
            SPC.Percussives[percussives.SelectedIndex].Volume = (byte)percussiveVolume.Value;
        }
        private void percussiveBalance_ValueChanged(object sender, EventArgs e)
        {
            SPC.Percussives[percussives.SelectedIndex].Balance = (byte)percussiveBalance.Value;
        }

        #endregion
    }
}
