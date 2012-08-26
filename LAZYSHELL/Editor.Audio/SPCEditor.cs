using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using LAZYSHELL.Properties;
using LAZYSHELL.ScriptsEditor.Commands;

namespace LAZYSHELL
{
    public partial class SPCEditor : Form
    {
        #region Variables
        public int Index { get { return (int)trackNum.Value; } set { trackNum.Value = value; } }
        public int Type { get { return soundType.SelectedIndex; } set { soundType.SelectedIndex = value; } }
        private SPC[] spcs;
        private SPC spc { get { return spcs[Index]; } set { spcs[Index] = value; } }
        private Settings settings = Settings.Default;
        private bool updating = false;
        private SPCScriptCommand mouseDownSSC;
        private SPCScriptCommand mouseOverSSC;
        private int mouseOverChannel;
        private bool mouseEnter = false;
        private Interpreter interpreter = Interpreter.Instance;
        private Previewer previewer;
        // control arrays
        private ComboBox[] sampleIndexes;
        private NumericUpDown[] volumes;
        private CheckBox[] activeChannels;
        private CheckBox[] activeInstruments;
        // channel track icons
        private Bitmap noteWhole = Resources.noteWhole;
        private Bitmap noteHalfDotted = Resources.noteHalfDotted;
        private Bitmap noteHalf = Resources.noteHalf;
        private Bitmap noteDotted = Resources.noteDotted;
        private Bitmap note = Resources.note;
        private Bitmap note8thDotted = Resources.note8thDotted;
        private Bitmap note8th_32nd = Resources.note8th_32nd;
        private Bitmap note8th = Resources.note8th;
        private Bitmap note16thDotted = Resources.note16thDotted;
        private Bitmap note16th = Resources.note16th;
        private Bitmap note32ndDotted = Resources.note32ndDotted;
        private Bitmap note32nd = Resources.note32nd;
        private Bitmap note64th = Resources.note64th;
        private Bitmap restWhole = Resources.restWhole;
        private Bitmap restHalfDotted = Resources.restHalfDotted;
        private Bitmap restHalf = Resources.restHalf;
        private Bitmap restDotted = Resources.restDotted;
        private Bitmap rest = Resources.rest;
        private Bitmap rest8thDotted = Resources.rest8thDotted;
        private Bitmap rest8th_32nd = Resources.rest8th_32nd;
        private Bitmap rest8th = Resources.rest8th;
        private Bitmap rest16thDotted = Resources.rest16thDotted;
        private Bitmap rest16th = Resources.rest16th;
        private Bitmap rest32ndDotted = Resources.rest32ndDotted;
        private Bitmap rest32nd = Resources.rest32nd;
        private Bitmap rest64th = Resources.rest64th;
        //
        private Bitmap sharp = Resources.sharp;
        private Bitmap octaveUp = Resources.octaveUp;
        private Bitmap octaveDown = Resources.octaveDown;
        private Bitmap octaveSet = Resources.octaveSet;
        private Bitmap terminate = Resources.terminate;
        private Bitmap metronome = Resources.metronome;
        private Bitmap loop = Resources.loop;
        private Bitmap loopEnd = Resources.loopEnd;
        private Bitmap firstSection = Resources.firstSection;
        private Bitmap loopInf = Resources.loopInf;
        private Bitmap instrument = Resources.instrument;
        private Bitmap volume = Resources.volume;
        private Bitmap portamento = Resources.portamento;
        private Bitmap speakerBalance = Resources.speakerBalance;
        private Bitmap tremolo = Resources.tremolo;
        private Bitmap reverbOn = Resources.reverbOn;
        private Bitmap reverbOff = Resources.reverbOff;
        private Bitmap drumsOn = Resources.drumsOn;
        private Bitmap drumsOff = Resources.drumsOff;
        #endregion
        public SPCEditor()
        {
            InitializeComponent();
            //
            updating = true;
            //
            percussivePitch.Items.AddRange(Lists.Pitches);
            sampleIndexes = new ComboBox[19];
            volumes = new NumericUpDown[19];
            activeInstruments = new CheckBox[19];
            for (int i = 0; i < sampleIndexes.Length; i++)
            {
                sampleIndexes[i] = new ComboBox();
                sampleIndexes[i].DropDownStyle = ComboBoxStyle.DropDownList;
                sampleIndexes[i].Enabled = false;
                sampleIndexes[i].FormattingEnabled = true;
                sampleIndexes[i].Items.AddRange(Lists.Numerize(Lists.SampleNames));
                sampleIndexes[i].Location = new Point(22, i * 21 + 42);
                sampleIndexes[i].Name = "sampleIndex" + i;
                sampleIndexes[i].Size = new Size(182, 21);
                sampleIndexes[i].TabIndex = i;
                sampleIndexes[i].Tag = i;
                sampleIndexes[i].SelectedIndexChanged += new EventHandler(sampleIndex_SelectedIndexChanged);
                this.groupBox3.Controls.Add(sampleIndexes[i]);
                //
                volumes[i] = new NumericUpDown();
                volumes[i].Enabled = false;
                volumes[i].Location = new Point(208, i * 21 + 42);
                volumes[i].Maximum = 127;
                volumes[i].Name = "volume" + i;
                volumes[i].Size = new Size(50, 21);
                volumes[i].TabIndex = i;
                volumes[i].Tag = i;
                volumes[i].TextAlign = HorizontalAlignment.Right;
                volumes[i].ValueChanged += new EventHandler(volume_ValueChanged);
                this.groupBox3.Controls.Add(volumes[i]);
                //
                activeInstruments[i] = new CheckBox();
                activeInstruments[i].AutoSize = true;
                activeInstruments[i].Location = new Point(6, i * 21 + 46);
                activeInstruments[i].Tag = i;
                activeInstruments[i].CheckedChanged += new EventHandler(activeInstrument_CheckedChanged);
                this.groupBox3.Controls.Add(activeInstruments[i]);
            }
            //
            if (settings.RememberLastIndex)
                Type = settings.LastSoundType;
            percussiveName.Items.AddRange(Lists.Numerize(Lists.SampleNames));
            //
            if (Type == 0)
            {
                spcs = Model.SPCs;
                trackName.Items.AddRange(Lists.Numerize(Lists.MusicNames));
            }
            else if (Type == 1)
            {
                spcs = Model.SPCEvent;
                trackName.Items.AddRange(Lists.Numerize(Lists.SoundNames));
            }
            else
            {
                spcs = Model.SPCBattle;
                trackName.Items.AddRange(Lists.Numerize(Lists.BattleSoundNames));
            }
            trackNum.Maximum = spcs.Length - 1;
            if (settings.RememberLastIndex)
                Index = settings.LastSPC;
            trackName.SelectedIndex = Index;
            //
            activeChannels = new CheckBox[8];
            for (int i = 0; i < 8; i++)
            {
                activeChannels[i] = new CheckBox();
                activeChannels[i].Location = new Point(6, i * 40 + 32);
                activeChannels[i].Tag = i;
                activeChannels[i].CheckedChanged += new EventHandler(activeChannel_CheckedChanged);
                groupBox2.Controls.Add(activeChannels[i]);
            }
            //
            RefreshSPC();
            updating = false;
        }
        #region Functions
        private void RefreshSPC()
        {
            updating = true;
            // Reverberation
            groupBox5.Enabled = Index != 0 && Type == 0;
            delayTime.Value = spc.DelayTime;
            decayFactor.Value = spc.DecayFactor;
            echo.Value = (sbyte)spc.Echo;
            // Instruments
            groupBox3.Enabled = Index != 0 && Type == 0;
            for (int i = 0; i < sampleIndexes.Length; i++)
            {
                if (Index == 0 || Type != 0 || spc.Samples[i] == null)
                {
                    activeInstruments[i].Checked = false;
                    sampleIndexes[i].SelectedIndex = 0;
                    volumes[i].Value = 0;
                }
                else
                {
                    activeInstruments[i].Checked = spc.Samples[i].Active;
                    sampleIndexes[i].SelectedIndex = spc.Samples[i].Sample;
                    volumes[i].Value = spc.Samples[i].Volume;
                }
                sampleIndexes[i].Enabled = activeInstruments[i].Checked;
                volumes[i].Enabled = activeInstruments[i].Checked;
            }
            // Percussives
            groupBox1.Enabled = Index != 0 && Type == 0 && spc.Percussives.Count > 0;
            percussives.Items.Clear();
            if (Index != 0 && Type == 0)
            {
                for (int i = 0; i < spc.Percussives.Count; i++)
                {
                    int index = spc.Percussives[i].Sample;
                    percussives.Items.Add(Lists.Numerize(Lists.SampleNames[index], index, 3));
                }
                if (spc.Percussives.Count > 0)
                {
                    percussives.SelectedIndex = 0;
                    RefreshPercussive();
                }
            }
            else
            {
                percussivePitchIndex.SelectedIndex = 0;
                percussiveName.SelectedIndex = 0;
                percussivePitch.SelectedIndex = 0;
                percussiveVolume.Value = 0;
                percussiveBalance.Value = 0;
            }
            // Track editor
            if (Index != 0 || Type != 0)
                spc.CreateNotes();
            groupBox2.Enabled = Index != 0 || Type != 0;
            groupBox4.Enabled = Index != 0 || Type != 0;
            hScrollBar1.Maximum = 0;
            hScrollBar2.Maximum = 0;
            mouseDownSSC = null;
            ControlDisassemble();
            if (Index != 0 || Type != 0)
            {
                for (int i = 0; i < spc.Channels.Length; i++)
                {
                    activeChannels[i].Enabled = spc.Channels[i] != null;
                    activeChannels[i].Checked = spc.ActiveChannels[i];
                    if (spc.Channels[i] == null)
                        continue;
                    hScrollBar1.SmallChange = 24;
                    hScrollBar1.LargeChange = 24 * 4;
                    if (spc.Channels[i].Count * 24 - channelTracks.Width > hScrollBar1.Maximum)
                        hScrollBar1.Maximum = spc.Channels[i].Count * 24 - channelTracks.Width;
                    int maximum = 0;
                    if (spc.Notes != null)
                        foreach (Note note in spc.Notes[i])
                        {
                            maximum += note.Duration;
                            if (maximum > hScrollBar2.Maximum)
                                hScrollBar2.Maximum = maximum;
                        }
                }
            }
            channelTracks.Invalidate();
            scorePictureBox.Invalidate();
            CalculateFreeSpace(Type, true, false);
            //
            updating = false;
        }
        private void RefreshPercussive()
        {
            percussivePitchIndex.SelectedIndex = spc.Percussives[percussives.SelectedIndex].PitchIndex;
            percussiveName.SelectedIndex = spc.Percussives[percussives.SelectedIndex].Sample;
            percussivePitch.SelectedIndex = spc.Percussives[percussives.SelectedIndex].Pitch;
            percussiveVolume.Value = spc.Percussives[percussives.SelectedIndex].Volume;
            percussiveBalance.Value = (sbyte)spc.Percussives[percussives.SelectedIndex].Balance;
        }
        public bool CalculateFreeSpace(int type, bool label, bool warning)
        {
            int offset = 0;
            int endOffset = 0;
            if (type == 0)
            {
                offset = 0x045526;
                endOffset = 0x060939;
                foreach (SPCTrack spc in Model.SPCs)
                {
                    if (spc == null || spc.Samples == null || spc.SPCData == null)
                        continue;
                    offset += 3; // Reverb
                    foreach (SampleIndex sample in spc.Samples)
                        if (sample != null && sample.Active)
                            offset += 2;
                    offset++; // 0xFF
                    offset += 2; // SPC size
                    offset += spc.SPCData.Length;
                    for (int i = 0; i < spc.Channels.Length; i++)
                    {
                        if (!spc.ActiveChannels[i] || spc.Channels[i] == null || spc.Channels[i].Count == 0)
                            continue;
                        SPCScriptCommand lastSSC = spc.Channels[i][spc.Channels[i].Count - 1];
                        if (lastSSC.Opcode != 0xD0 && lastSSC.Opcode != 0xCD && lastSSC.Opcode != 0xCE)
                            offset++;
                    }
                }
            }
            else if (type == 1)
            {
                offset = 0x042C26;
                endOffset = 0x043E26;
                foreach (SPCSound sound in Model.SPCEvent)
                {
                    if (sound == null || sound.Channels == null)
                        continue;
                    offset += sound.GetLength();
                }
            }
            else
            {
                offset = 0x044226;
                endOffset = 0x045426;
                foreach (SPCSound sound in Model.SPCBattle)
                {
                    if (sound == null || sound.Channels == null)
                        continue;
                    offset += sound.GetLength();
                }
            }
            int left = endOffset - offset;
            if (label)
            {
                freeSpace.Text = left.ToString() + " available bytes";
                freeSpace.ForeColor = left < 0 ? Color.Red : SystemColors.ControlText;
            }
            if (warning && left < 0)
            {
                if (type == 0)
                    MessageBox.Show("Not enough space to save all SPCs.", "LAZY SHELL");
                if (type == 1)
                    MessageBox.Show("Not enough space to save all event sound effects.", "LAZY SHELL");
                if (type == 2)
                    MessageBox.Show("Not enough space to save all battle sound effects.", "LAZY SHELL");
            }
            return left >= 0;
        }
        private void ControlDisassemble()
        {
            updating = true;
            labelOpcode1.Text = "Opcode 1";
            labelParameter1.Text = "Parameter 1";
            labelParameter2.Text = "Parameter 2";
            labelParameter3.Text = "Parameter 3";
            opcodeByte1.Value = 0;
            opcodeByte1.Maximum = 255;
            opcodeByte1.Enabled = false;
            opcodeByte1.Hexadecimal = true;
            parameterByte1.Value = 0;
            parameterByte1.Maximum = 255;
            parameterByte1.Enabled = false;
            parameterByte1.BringToFront();
            parameterByte2.Value = 0;
            parameterByte2.Maximum = 255;
            parameterByte2.Enabled = false;
            parameterByte2.BringToFront();
            parameterByte3.Value = 0;
            parameterByte3.Maximum = 255;
            parameterByte3.Enabled = false;
            parameterByte3.BringToFront();
            parameterName1.Enabled = false;
            parameterName1.Items.Clear();
            parameterName2.Enabled = false;
            parameterName2.Items.Clear();
            parameterName3.Enabled = false;
            parameterName3.Items.Clear();
            panelParameters.BringToFront();
            // notes
            noteNames.Enabled = false;
            //noteNames.Items.Clear();
            noteLengthName.Enabled = false;
            //noteLengthName.Items.Clear();
            noteLengthName.BringToFront();
            noteLengthByte.Enabled = false;
            noteLengthByte.Value = 0;
            //
            if (mouseDownSSC == null)
                return;
            switch (mouseDownSSC.Opcode)
            {
                case 0xC4:
                case 0xC5:
                    opcodeByte1.Enabled = true;
                    opcodeByte1.Value = mouseDownSSC.Opcode;
                    break;
                case 0xC6:
                    labelParameter1.Text = "Octave = ";
                    opcodeByte1.Enabled = true;
                    opcodeByte1.Value = mouseDownSSC.Opcode;
                    parameterByte1.Maximum = 8;
                    parameterByte1.Enabled = true;
                    parameterByte1.Value = mouseDownSSC.Option;
                    break;
                case 0xC8:
                    labelParameter1.Text = "Channels";
                    opcodeByte1.Enabled = true;
                    opcodeByte1.Value = mouseDownSSC.Opcode;
                    parameterByte1.Enabled = true;
                    parameterByte1.Value = mouseDownSSC.Option;
                    break;
                case 0xCD:
                case 0xCE:
                    labelParameter1.Text = "Sound";
                    opcodeByte1.Value = mouseDownSSC.Opcode;
                    parameterName1.Enabled = true;
                    parameterName1.Items.AddRange(Lists.Numerize(Lists.SoundNames));
                    parameterName1.SelectedIndex = mouseDownSSC.Option;
                    parameterName1.BringToFront();
                    break;
                case 0xCF:
                    labelParameter1.Text = "1/16 pitch = ";
                    opcodeByte1.Value = mouseDownSSC.Opcode;
                    parameterByte1.Enabled = true;
                    parameterByte1.Value = mouseDownSSC.Option;
                    break;
                case 0xD1:
                    labelParameter1.Text = "Beat duration = ";
                    opcodeByte1.Enabled = true;
                    opcodeByte1.Value = mouseDownSSC.Opcode;
                    parameterByte1.Enabled = true;
                    parameterByte1.Value = mouseDownSSC.Option;
                    break;
                case 0xD4:
                    labelParameter1.Text = "Loop count = ";
                    opcodeByte1.Value = mouseDownSSC.Opcode;
                    parameterByte1.Enabled = true;
                    parameterByte1.Value = mouseDownSSC.Option;
                    break;
                case 0xDC:
                    labelParameter1.Text = "Decay ratio : 24";
                    opcodeByte1.Value = mouseDownSSC.Opcode;
                    parameterByte1.Enabled = true;
                    parameterByte1.Maximum = 23;
                    parameterByte1.Value = mouseDownSSC.Option;
                    break;
                case 0xDE:
                    labelParameter1.Text = "Instrument";
                    opcodeByte1.Enabled = true;
                    opcodeByte1.Value = mouseDownSSC.Opcode;
                    parameterName1.Enabled = true;
                    parameterName1.BringToFront();
                    parameterName1.Items.AddRange(Lists.Numerize(Lists.SampleNames));
                    parameterName1.SelectedIndex = mouseDownSSC.Option;
                    break;
                case 0xE0:
                    labelParameter1.Text = "Staccato = ";
                    opcodeByte1.Value = mouseDownSSC.Opcode;
                    parameterByte1.Enabled = true;
                    parameterByte1.Maximum = 31;
                    parameterByte1.Value = mouseDownSSC.Option;
                    break;
                case 0xE2:
                    labelParameter1.Text = "Volume = ";
                    opcodeByte1.Enabled = true;
                    opcodeByte1.Value = mouseDownSSC.Opcode;
                    parameterByte1.Enabled = true;
                    parameterByte1.Value = mouseDownSSC.Option;
                    break;
                case 0xE4:
                case 0xE5:
                    labelParameter1.Text = "Duration = ";
                    labelParameter2.Text = "Change = ";
                    opcodeByte1.Value = mouseDownSSC.Opcode;
                    parameterByte1.Enabled = true;
                    parameterByte1.Value = mouseDownSSC.Option;
                    parameterByte2.Enabled = true;
                    parameterByte2.Maximum = 127;
                    parameterByte2.Minimum = -128;
                    parameterByte2.Value = (sbyte)mouseDownSSC.CommandData[2];
                    break;
                case 0xE7:
                    labelParameter1.Text = "Balance = ";
                    opcodeByte1.Value = mouseDownSSC.Opcode;
                    parameterByte1.Enabled = true;
                    parameterByte1.Maximum = 127;
                    parameterByte1.Minimum = -128;
                    parameterByte1.Value = (sbyte)mouseDownSSC.Option;
                    break;
                case 0xE8:
                case 0xE9:
                    labelParameter1.Text = "Duration = ";
                    if (mouseDownSSC.Opcode == 0xE8)
                        labelParameter2.Text = "Balance = ";
                    else
                        labelParameter2.Text = "Speed = ";
                    opcodeByte1.Value = mouseDownSSC.Opcode;
                    parameterByte1.Enabled = true;
                    parameterByte1.Value = mouseDownSSC.Option;
                    parameterByte2.Enabled = true;
                    if (mouseDownSSC.Opcode == 0xE8)
                    {
                        parameterByte2.Maximum = 127;
                        parameterByte2.Minimum = -128;
                        parameterByte2.Value = (sbyte)mouseDownSSC.CommandData[2];
                    }
                    else
                        parameterByte2.Value = mouseDownSSC.CommandData[2];
                    break;
                case 0xEC:
                case 0xED:
                    labelParameter1.Text = "1/4 pitch = ";
                    opcodeByte1.Enabled = true;
                    opcodeByte1.Value = mouseDownSSC.Opcode;
                    parameterByte1.Enabled = true;
                    parameterByte1.Value = mouseDownSSC.Option;
                    break;
                case 0xF0:
                case 0xF1:
                    labelParameter1.Text = "Rate = ";
                    labelParameter2.Text = "Extent = ";
                    opcodeByte1.Value = mouseDownSSC.Opcode;
                    parameterByte1.Enabled = true;
                    parameterByte1.Value = mouseDownSSC.Option;
                    parameterByte2.Enabled = true;
                    parameterByte2.Value = mouseDownSSC.CommandData[2];
                    if (mouseDownSSC.Opcode == 0xF1)
                        parameterByte3.Value = mouseDownSSC.CommandData[3];
                    break;
                case 0xF6:
                    labelParameter1.Text = "Length = ";
                    opcodeByte1.Value = mouseDownSSC.Opcode;
                    parameterByte1.Enabled = true;
                    parameterByte1.Value = mouseDownSSC.Option;
                    break;
                case 0xFC:
                    labelParameter1.Text = "Delay Time";
                    labelParameter2.Text = "Decay Ratio";
                    labelParameter3.Text = "Echo Volume";
                    opcodeByte1.Value = mouseDownSSC.Opcode;
                    parameterByte1.Enabled = true;
                    parameterByte2.Enabled = true;
                    parameterByte3.Enabled = true;
                    parameterByte2.Maximum = 127;
                    parameterByte1.Value = mouseDownSSC.Option;
                    parameterByte2.Value = mouseDownSSC.CommandData[2];
                    parameterByte3.Value = mouseDownSSC.CommandData[3];
                    break;
                default:
                    if (mouseDownSSC.Opcode < 0xC4)
                    {
                        panelNotes.BringToFront();
                        noteNames.Enabled = true;
                        noteLengthName.Enabled = mouseDownSSC.Opcode < 0xB6;
                        noteLengthByte.Enabled = mouseDownSSC.Opcode >= 0xB6;
                        if (mouseDownSSC.Opcode >= 0xB6)
                            noteLengthByte.BringToFront();
                        //
                        noteNames.SelectedIndex = mouseDownSSC.Opcode % 14;
                        if (mouseDownSSC.Opcode < 0xB6)
                            noteLengthName.SelectedIndex = mouseDownSSC.Opcode / 14;
                        else
                            noteLengthByte.Value = mouseDownSSC.Option;
                    }
                    else
                    {
                        if (mouseDownSSC.Length > 0)
                        {
                            opcodeByte1.Enabled = true;
                            opcodeByte1.Value = mouseDownSSC.Opcode;
                        }
                        if (mouseDownSSC.Length > 1)
                        {
                            parameterByte1.Enabled = true;
                            parameterByte1.Value = mouseDownSSC.Option;
                        }
                        if (mouseDownSSC.Length > 2)
                        {
                            parameterByte2.Enabled = true;
                            parameterByte2.Value = mouseDownSSC.CommandData[2];
                        }
                        if (mouseDownSSC.Length > 3)
                        {
                            parameterByte3.Enabled = true;
                            parameterByte3.Value = mouseDownSSC.CommandData[3];
                        }
                    }
                    break;
            }
            CalculateFreeSpace(Type, true, false);
            updating = false;
        }
        private void ControlAssemble()
        {
            if (mouseDownSSC == null)
                return;
            switch (mouseDownSSC.Opcode)
            {
                case 0xCD:
                case 0xCE:
                case 0xDE:
                    mouseDownSSC.Opcode = (byte)opcodeByte1.Value;
                    mouseDownSSC.Option = (byte)parameterName1.SelectedIndex;
                    break;
                case 0xE7:
                    mouseDownSSC.Opcode = (byte)opcodeByte1.Value;
                    mouseDownSSC.Option = (byte)((sbyte)parameterByte1.Value);
                    break;
                case 0xE4:
                case 0xE5:
                case 0xE8:
                    mouseDownSSC.Opcode = (byte)opcodeByte1.Value;
                    mouseDownSSC.Option = (byte)parameterByte1.Value;
                    mouseDownSSC.CommandData[2] = (byte)((sbyte)parameterByte2.Value);
                    break;
                case 0xE9:
                case 0xF0:
                case 0xF1:
                case 0xFC:
                    mouseDownSSC.Opcode = (byte)opcodeByte1.Value;
                    mouseDownSSC.Option = (byte)parameterByte1.Value;
                    mouseDownSSC.CommandData[2] = (byte)parameterByte2.Value;
                    if (mouseDownSSC.Option == 0xF1 ||
                        mouseDownSSC.Option == 0xFC)
                        mouseDownSSC.CommandData[3] = (byte)parameterByte3.Value;
                    break;
                default:
                    if (mouseDownSSC.Opcode < 0xC4)
                    {
                        if (mouseDownSSC.Opcode < 0xB6)
                            mouseDownSSC.Opcode = (byte)(noteLengthName.SelectedIndex * 14);
                        else
                            mouseDownSSC.Option = (byte)noteLengthByte.Value;
                        mouseDownSSC.Opcode += (byte)noteNames.SelectedIndex;
                    }
                    else
                    {
                        if (mouseDownSSC.Length > 0)
                            mouseDownSSC.Opcode = (byte)opcodeByte1.Value;
                        if (mouseDownSSC.Length > 1)
                            mouseDownSSC.Option = (byte)parameterByte1.Value;
                        if (mouseDownSSC.Length > 2)
                            mouseDownSSC.CommandData[2] = (byte)parameterByte2.Value;
                        if (mouseDownSSC.Length > 3)
                            mouseDownSSC.CommandData[3] = (byte)parameterByte3.Value;
                    }
                    break;
            }
            if (Type == 0)
                ((SPCTrack)spc).AssembleSPCData();
            CalculateFreeSpace(Type, true, false);
        }
        public void Assemble(bool warning)
        {
            int offset = 0x045526;
            if (CalculateFreeSpace(0, false, warning))
                for (int i = 0; i < Model.SPCs.Length; i++)
                    Model.SPCs[i].Assemble(ref offset);
            offset = 0x042C26;
            if (CalculateFreeSpace(1, false, warning))
                for (int i = 0; i < Model.SPCEvent.Length; i++)
                    Model.SPCEvent[i].Assemble(ref offset);
            offset = 0x044226;
            if (CalculateFreeSpace(2, false, warning))
                for (int i = 0; i < Model.SPCBattle.Length; i++)
                    Model.SPCBattle[i].Assemble(ref offset);
        }
        #endregion
        #region Event Handlers
        private void soundType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            trackName.Items.Clear();
            if (Type == 0)
            {
                spcs = Model.SPCs;
                trackName.Items.AddRange(Lists.Numerize(Lists.MusicNames));
            }
            else if (Type == 1)
            {
                spcs = Model.SPCEvent;
                trackName.Items.AddRange(Lists.Numerize(Lists.SoundNames));
            }
            else
            {
                spcs = Model.SPCBattle;
                trackName.Items.AddRange(Lists.Numerize(Lists.BattleSoundNames));
            }
            if (settings.RememberLastIndex)
                settings.LastSoundType = soundType.SelectedIndex;
            trackNum.Maximum = spcs.Length - 1;
            Index = 0;
            trackName.SelectedIndex = 0;
            RefreshSPC();
        }
        private void trackNum_ValueChanged(object sender, EventArgs e)
        {
            if (updating)
                return;
            trackName.SelectedIndex = (int)trackNum.Value;
            if (settings.RememberLastIndex)
                settings.LastSPC = (int)trackNum.Value;
            RefreshSPC();
        }
        private void trackName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating)
                return;
            trackNum.Value = trackName.SelectedIndex;
        }
        // Instruments
        private void sampleIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating)
                return;
            int index = (int)((ComboBox)sender).Tag;
            for (int i = 0; i < spc.Channels.Length; i++)
            {
                if (spc.Channels[i] == null)
                    continue;
                foreach (SPCScriptCommand ssc in spc.Channels[i])
                {
                    if (ssc.Opcode == 0xDE && ssc.Option == spc.Samples[index].Sample)
                        ssc.Option = (byte)sampleIndexes[index].SelectedIndex;
                }
            }
            spc.Samples[index].Sample = (byte)sampleIndexes[index].SelectedIndex;
            channelTracks.Invalidate();
        }
        private void volume_ValueChanged(object sender, EventArgs e)
        {
            if (updating)
                return;
            int index = (int)((NumericUpDown)sender).Tag;
            spc.Samples[index].Volume = (int)volumes[index].Value;
        }
        private void activeInstrument_CheckedChanged(object sender, EventArgs e)
        {
            if (updating)
                return;
            int index = (int)((CheckBox)sender).Tag;
            if (activeInstruments[index].Checked)
            {
                if (spc.Samples[index] == null)
                    spc.Samples[index] = new SampleIndex(sampleIndexes[index].SelectedIndex, (int)volumes[index].Value);
                else
                    spc.Samples[index].Active = true;
                sampleIndexes[index].Enabled = true;
                volumes[index].Enabled = true;
            }
            else
            {
                if (spc.Samples[index] != null)
                    spc.Samples[index].Active = false;
                sampleIndexes[index].Enabled = false;
                volumes[index].Enabled = false;
            }
            CalculateFreeSpace(Type, true, false);
            channelTracks.Invalidate();
        }
        // Reverb
        private void delayTime_ValueChanged(object sender, EventArgs e)
        {
            if (updating)
                return;
            spc.DelayTime = (byte)delayTime.Value;
        }
        private void decayFactor_ValueChanged(object sender, EventArgs e)
        {
            if (updating)
                return;
            spc.DecayFactor = (byte)decayFactor.Value;
        }
        private void echo_ValueChanged(object sender, EventArgs e)
        {
            if (updating)
                return;
            spc.Echo = (byte)((sbyte)echo.Value);
        }
        // Percussives
        private void newPercussive_Click(object sender, EventArgs e)
        {
            if (spc.Percussives.Count >= 12)
            {
                MessageBox.Show("No more than 12 percussives allowed.", "LAZY SHELL");
                return;
            }
            int index = percussives.SelectedIndex + 1;
            spc.Percussives.Insert(index, new Percussives(0, 0, 0, 0, 0));
            updating = true;
            percussives.Items.Insert(index, Lists.Numerize(Lists.SampleNames, 0, 3));
            updating = false;
            percussives.SelectedIndex = Math.Min(percussives.Items.Count - 1, index);
            RefreshPercussive();
        }
        private void deletePercussive_Click(object sender, EventArgs e)
        {
            if (spc.Percussives.Count == 0)
                return;
            if (percussives.SelectedIndex < 0)
            {
                MessageBox.Show("No percussives selected.", "LAZY SHELL");
                return;
            }
            int index = percussives.SelectedIndex;
            spc.Percussives.RemoveAt(index);
            updating = true;
            percussives.Items.RemoveAt(index);
            updating = false;
            percussives.SelectedIndex = Math.Min(percussives.Items.Count - 1, index);
        }
        private void percussives_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            RefreshPercussive();
        }
        private void percussivePitchIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            spc.Percussives[percussives.SelectedIndex].PitchIndex = (byte)percussivePitchIndex.SelectedIndex;
        }
        private void percussiveName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int index = percussiveName.SelectedIndex;
            percussives.Items[percussives.SelectedIndex] = Lists.Numerize(Lists.SampleNames[index], index, 3);
            spc.Percussives[percussives.SelectedIndex].Sample = (byte)index;
            updating = false;
        }
        private void percussivePitch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            spc.Percussives[percussives.SelectedIndex].Pitch = (byte)percussivePitch.SelectedIndex;
        }
        private void percussiveVolume_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            spc.Percussives[percussives.SelectedIndex].Volume = (byte)percussiveVolume.Value;
        }
        private void percussiveBalance_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            spc.Percussives[percussives.SelectedIndex].Balance = (byte)((sbyte)percussiveBalance.Value);
        }
        // Toolstrip
        private void reset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reset the current SPC? You will lose all unsaved changes.",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            if (Type == 0)
                Model.SPCs[Index] = new SPCTrack(Model.Data, Index);
            else if (Type == 1)
                Model.SPCEvent[Index] = new SPCSound(Index, 0);
            else
                Model.SPCBattle[Index] = new SPCSound(Index, 1);
            RefreshSPC();
        }
        private void hexViewer_Click(object sender, EventArgs e)
        {
            int offset = Bits.Get24Bit(Model.Data, Index * 3 + 0x042748);
            Model.HexViewer.Offset = offset & 0x3FFFF0;
            Model.HexViewer.SelectionStart = (offset & 15) * 3;
            Model.HexViewer.Compare();
            Model.HexViewer.Show();
        }
        private void openPreviewer_Click(object sender, EventArgs e)
        {
            if (previewer != null && previewer.Visible)
                previewer.Close();
            if (Type == 0)
                previewer = new Previewer(Index, previewAuto.Checked, PreviewType.SPCTrack);
            else if (Type == 1)
                previewer = new Previewer(Index, previewAuto.Checked, PreviewType.SPCEvent);
            else if (Type == 2)
                previewer = new Previewer(Index, previewAuto.Checked, PreviewType.SPCBattle);
            if (!previewAuto.Checked)
                previewer.Show();
        }
        // Track editor, picture
        private void channelTracks_Paint(object sender, PaintEventArgs e)
        {
            if (Index == 0 && Type == 0)
                return;
            //
            SolidBrush brush = new SolidBrush(Color.FromArgb(24, 0, 0, 0));
            if (mouseEnter && spc.ActiveChannels[mouseOverChannel])
                e.Graphics.FillRectangle(brush, 0, mouseOverChannel * 40 + 3, channelTracks.Width, 35);
            //
            brush = new SolidBrush(SystemColors.ControlText);
            Font font = new Font("Lucida Console", 8.25F);
            Pen pen = new Pen(Color.Black); pen.DashStyle = DashStyle.Dot;
            int x = 0;
            int y = 0;
            for (int t = 0; t < spc.Channels.Length; t++)
            {
                if (!spc.ActiveChannels[t] || spc.Channels[t] == null)
                    continue;
                pen.Color = Color.Black;
                e.Graphics.DrawLine(pen, 0, t * 40 + 2, channelTracks.Width, t * 40 + 2);
                e.Graphics.DrawLine(pen, 0, t * 40 + 38, channelTracks.Width, t * 40 + 38);
                for (int c = 0; c < spc.Channels[t].Count; c++)
                {
                    x = c * 24 + 8 - hScrollBar1.Value;
                    y = t * 40 + 14;
                    if (x < -24 || x > channelTracks.Width)
                        continue;
                    SPCScriptCommand ssc = spc.Channels[t][c];
                    switch (ssc.Opcode)
                    {
                        case 0xC4: e.Graphics.DrawImage(this.octaveUp, x, y); break;
                        case 0xC5: e.Graphics.DrawImage(this.octaveDown, x, y); break;
                        case 0xC6: e.Graphics.DrawImage(this.octaveSet, x, y); break;
                        case 0xD0: e.Graphics.DrawImage(this.terminate, x, y); break;
                        case 0xD1: e.Graphics.DrawImage(this.metronome, x, y); break;
                        case 0xD4: e.Graphics.DrawImage(this.loop, x, y); break;
                        case 0xD5: e.Graphics.DrawImage(this.loopEnd, x, y); break;
                        case 0xD6: e.Graphics.DrawImage(this.firstSection, x, y); break;
                        case 0xD7: e.Graphics.DrawImage(this.loopInf, x, y); break;
                        case 0xDE: e.Graphics.DrawImage(this.instrument, x, y); break;
                        case 0xE2: e.Graphics.DrawImage(this.volume, x, y); break;
                        case 0xE5: e.Graphics.DrawImage(this.portamento, x, y); break;
                        case 0xE7: e.Graphics.DrawImage(this.speakerBalance, x, y); break;
                        case 0xEE: e.Graphics.DrawImage(this.drumsOn, x, y); break;
                        case 0xEF: e.Graphics.DrawImage(this.drumsOff, x, y); break;
                        case 0xF0: e.Graphics.DrawImage(this.tremolo, x, y); break;
                        case 0xFA: e.Graphics.DrawImage(this.reverbOn, x, y); break;
                        case 0xFB: e.Graphics.DrawImage(this.reverbOff, x, y); break;
                        default:
                            if (ssc.Opcode < 0xC4)
                            {
                                if (ssc.Opcode % 14 < 0x0C)
                                    e.Graphics.DrawImage(this.note, x, y);
                                else if (ssc.Opcode % 14 == 0x0C)
                                    e.Graphics.DrawImage(this.rest, x, y);
                                else if (ssc.Opcode % 14 == 0x0D)
                                    e.Graphics.DrawString("...", font, brush, x, y);
                            }
                            else
                                e.Graphics.DrawString(ssc.Opcode.ToString("X2"), font, brush, x, y);
                            break;
                    }
                    pen.Color = Color.Red;
                    if (ssc == mouseDownSSC)
                        e.Graphics.DrawRectangle(pen, x - 2, y - 2, 20, 20);
                    pen.Color = Color.Black;
                }
            }
        }
        private void channelTracks_MouseMove(object sender, MouseEventArgs e)
        {
            mouseOverSSC = null;
            if (Index == 0)
                return;
            int x = e.X + hScrollBar1.Value - 8;
            int y = e.Y % 40;
            int mouseOverChannel = this.mouseOverChannel;
            if (Type == 0)
                mouseOverChannel = Math.Min(7, e.Y / 40);
            else
                mouseOverChannel = Math.Min(2, e.Y / 40);
            if (mouseOverChannel < spc.Channels.Length &&
                spc.ActiveChannels[mouseOverChannel] &&
                spc.Channels[mouseOverChannel] != null &&
                x >= 0 && x % 24 < 16 && y >= 14 && y < 30)
            {
                int index = x / 24;
                if (index < spc.Channels[mouseOverChannel].Count)
                {
                    mouseOverSSC = spc.Channels[mouseOverChannel][index];
                    labelCommand.Text = interpreter.InterpretSPCCommand(mouseOverSSC);
                    labelBits.Text = "{" + BitConverter.ToString(mouseOverSSC.CommandData) + "}";
                    channelTracks.Cursor = Cursors.Hand;
                }
            }
            else
            {
                labelCommand.Text = "...";
                labelBits.Text = "...";
                channelTracks.Cursor = Cursors.Arrow;
            }
            if (mouseOverChannel != this.mouseOverChannel)
            {
                this.mouseOverChannel = mouseOverChannel;
                channelTracks.Invalidate();
            }
            else
                this.mouseOverChannel = mouseOverChannel;
        }
        private void channelTracks_MouseEnter(object sender, EventArgs e)
        {
            mouseEnter = true;
            channelTracks.Invalidate();
        }
        private void channelTracks_MouseLeave(object sender, EventArgs e)
        {
            mouseEnter = false;
            channelTracks.Invalidate();
        }
        private void channelTracks_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownSSC = null;
            if (Index == 0)
                return;
            if (mouseOverSSC != null)
            {
                mouseDownSSC = mouseOverSSC;
                ControlDisassemble();
            }
            channelTracks.Invalidate();
        }
        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            channelTracks.Invalidate();
        }
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            channelTracks.Invalidate();
        }
        private void activeChannel_CheckedChanged(object sender, EventArgs e)
        {
            if (updating)
                return;
            CheckBox activeChannel = (CheckBox)sender;
            int channel = (int)activeChannel.Tag;
            spc.ActiveChannels[channel] = activeChannel.Checked;
            if (Type == 0)
                ((SPCTrack)spc).AssembleSPCData();
            CalculateFreeSpace(Type, true, false);
            channelTracks.Invalidate();
        }
        // Track editor, toolstrip
        private void moveLeft_Click(object sender, EventArgs e)
        {
            if (mouseDownSSC == null) return;
            List<SPCScriptCommand> channel = spc.Channels[mouseDownSSC.Channel];
            int index = channel.IndexOf(mouseDownSSC);
            if (index > 0)
                channel.Reverse(index - 1, 2);
            ControlAssemble();
            channelTracks.Invalidate();
        }
        private void moveRight_Click(object sender, EventArgs e)
        {
            if (mouseDownSSC == null) return;
            List<SPCScriptCommand> channel = spc.Channels[mouseDownSSC.Channel];
            int index = channel.IndexOf(mouseDownSSC);
            if (index < channel.Count - 1)
                channel.Reverse(index, 2);
            ControlAssemble();
            channelTracks.Invalidate();
        }
        private void delete_Click(object sender, EventArgs e)
        {
            if (mouseDownSSC == null) return;
            spc.Channels[mouseDownSSC.Channel].Remove(mouseDownSSC);
            ControlAssemble();
            channelTracks.Invalidate();
        }
        private void newNote_Click(object sender, EventArgs e)
        {
            if (mouseDownSSC == null) return;
            SPCCommand spcCommand = new SPCCommand();
            spcCommand.ShowDialog();
            if (spcCommand.DialogResult != DialogResult.OK)
                return;
            int opcode = spcCommand.Opcode;
            int length = SPCScriptEnums.SPCScriptLengths[opcode];
            SPCScriptCommand ssc;
            if (Type == 0)
                ssc = new SPCScriptCommand(new byte[length], (SPCTrack)spc, mouseDownSSC.Channel);
            else
                ssc = new SPCScriptCommand(new byte[length], (SPCSound)spc, mouseDownSSC.Channel);
            ssc.Opcode = (byte)opcode;
            List<SPCScriptCommand> channel = spc.Channels[mouseDownSSC.Channel];
            channel.Insert(channel.IndexOf(mouseDownSSC) + 1, ssc);
            mouseDownSSC = ssc;
            ControlDisassemble();
            ControlAssemble();
            channelTracks.Invalidate();
        }
        // Track editor, commands
        private void opcodeByte1_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            try
            {
                ControlAssemble();
                ControlDisassemble();
            }
            catch
            {
                MessageBox.Show("Couldn't change value.");
            }
            channelTracks.Invalidate();
        }
        private void parameterByte1_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            try
            {
                ControlAssemble();
            }
            catch
            {
                MessageBox.Show("Couldn't change value.");
            }
            channelTracks.Invalidate();
        }
        private void parameterByte2_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            try
            {
                ControlAssemble();
            }
            catch
            {
                MessageBox.Show("Couldn't change value.");
            }
            channelTracks.Invalidate();
        }
        private void parameterByte3_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            try
            {
                ControlAssemble();
            }
            catch
            {
                MessageBox.Show("Couldn't change value.");
            }
            channelTracks.Invalidate();
        }
        private void parameterName1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            try
            {
                ControlAssemble();
            }
            catch
            {
                MessageBox.Show("Couldn't change value.");
            }
            channelTracks.Invalidate();
        }
        private void noteNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            try
            {
                ControlAssemble();
            }
            catch
            {
                MessageBox.Show("Couldn't change value.");
            }
            channelTracks.Invalidate();
        }
        private void noteLengthName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            try
            {
                ControlAssemble();
            }
            catch
            {
                MessageBox.Show("Couldn't change value.");
            }
            channelTracks.Invalidate();
        }
        private void noteLengthByte_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            try
            {
                ControlAssemble();
            }
            catch
            {
                MessageBox.Show("Couldn't change value.");
            }
            channelTracks.Invalidate();
        }
        // Score viewer
        private void scorePictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (Index == 0 && Type == 0)
                return;
            Font font = new Font("Lucida Console", 8.25F);
            SolidBrush brush = new SolidBrush(SystemColors.ControlText);
            Pen pen = new Pen(Color.Black);
            int x = 0;
            int t = 0;
            int max = spc.Channels.Length;
            if (allChannels.Checked)
            {
                t = 0;
                max = spc.Channels.Length;
            }
            else
            {
                t = (int)singleChannelNum.Value;
                max = (int)(singleChannelNum.Value + 1);
            }
            if (spc.Notes != null)
                for (; t < max; t++)
                {
                    if (spc.Channels[t] == null)
                        continue;
                    //
                    int y = t * 88;
                    x = -hScrollBar2.Value + 16;
                    //
                    pen.Color = Color.Red;
                    pen.DashStyle = DashStyle.Dot;
                    // dratted dotted boundaries of staff
                    e.Graphics.DrawLine(pen, 0, y + 4, scorePictureBox.Width, y + 4);
                    e.Graphics.DrawLine(pen, 0, y + 84, scorePictureBox.Width, y + 84);
                    // draw staff ledger lines
                    pen.Color = Color.Black;
                    pen.DashStyle = DashStyle.Solid;
                    e.Graphics.DrawLine(pen, 0, y + 28, scorePictureBox.Width, y + 28);
                    e.Graphics.DrawLine(pen, 0, y + 36, scorePictureBox.Width, y + 36);
                    e.Graphics.DrawLine(pen, 0, y + 44, scorePictureBox.Width, y + 44);
                    e.Graphics.DrawLine(pen, 0, y + 52, scorePictureBox.Width, y + 52);
                    e.Graphics.DrawLine(pen, 0, y + 60, scorePictureBox.Width, y + 60);
                    // draw notes
                    if (spc.Notes[t] != null)
                        foreach (Note note in spc.Notes[t])
                        {
                            Bitmap image;
                            if (x < -32 || x - 32 > scorePictureBox.Width)
                            {
                                x += note.Duration;
                                continue;
                            }
                            if (!note.Stop && !note.Hold)
                            {
                                switch (note.Beat)
                                {
                                    case 0: image = noteWhole; break;
                                    case 1: image = noteHalfDotted; break;
                                    case 2: image = noteHalf; break;
                                    case 3: image = noteDotted; break;
                                    case 4: image = this.note; break;
                                    case 5: image = note8thDotted; break;
                                    case 6: image = note8th_32nd; break;
                                    case 7: image = note8th; break;
                                    case 8: image = note16thDotted; break;
                                    case 9: image = note16th; break;
                                    case 10: image = note32ndDotted; break;
                                    case 11: image = note32nd; break;
                                    case 12: image = note64th; break;
                                    default: image = this.note; break;
                                }
                                // 42 is middle line, 4 is top dotted line, -12 is the offset of resource image
                                if (!note.Percussive)
                                {
                                    e.Graphics.DrawImage(image, x, y + 42 + note.Y + 4 - 12);
                                    if (note.Sharp)
                                        e.Graphics.DrawImage(this.sharp, x, y + 42 + note.Y + 4 - 12);
                                }
                                else
                                    e.Graphics.DrawImage(image, x, y + 42 + 4 - 12);
                            }
                            else if (note.Stop)
                            {
                                switch (note.Beat)
                                {
                                    case 0: image = restWhole; break;
                                    case 1: image = restHalfDotted; break;
                                    case 2: image = restHalf; break;
                                    case 3: image = restDotted; break;
                                    case 4: image = rest; break;
                                    case 5: image = rest8thDotted; break;
                                    case 6: image = rest8th_32nd; break;
                                    case 7: image = rest8th; break;
                                    case 8: image = rest16thDotted; break;
                                    case 9: image = rest16th; break;
                                    case 10: image = rest32ndDotted; break;
                                    case 11: image = rest32nd; break;
                                    case 12: image = rest64th; break;
                                    default: image = rest; break;
                                }
                                e.Graphics.DrawImage(image, x, y + 42 + 4 - 12);
                            }
                            x += note.Duration;
                        }
                }
        }
        private void allChannels_CheckedChanged(object sender, EventArgs e)
        {
            singleChannelNum.Enabled = singleChannel.Checked;
            scorePictureBox.Invalidate();
        }
        private void singleChannel_CheckedChanged(object sender, EventArgs e)
        {
            singleChannelNum.Enabled = singleChannel.Checked;
            scorePictureBox.Invalidate();
        }
        private void singleChannelNum_ValueChanged(object sender, EventArgs e)
        {
            scorePictureBox.Invalidate();
        }
        private void scoreView_Click(object sender, EventArgs e)
        {
            if (scoreView.Checked)
                groupBox4.BringToFront();
            else
                groupBox2.BringToFront();
        }
        private void hScrollBar2_ValueChanged(object sender, EventArgs e)
        {
            scorePictureBox.Invalidate();
        }
        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            scorePictureBox.Invalidate();
        }
        //
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (!spc.ActiveChannels[mouseOverChannel])
                e.Cancel = true;
        }
        private void importTrack_Click(object sender, EventArgs e)
        {
            if (Type == 0)
                new IOElements((Element[])Model.SPCs, Index, "IMPORT SPCS...").ShowDialog();
            else if (Type == 1)
                new IOElements((Element[])Model.SPCEvent, Index, "IMPORT EVENT SOUNDS...").ShowDialog();
            else
                new IOElements((Element[])Model.SPCBattle, Index, "IMPORT BATTLE SOUNDS...").ShowDialog();
            RefreshSPC();
        }
        private void importScript_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Import SPC script";
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            string path = openFileDialog.FileName;
            TextReader tr;
            BinaryFormatter b = new BinaryFormatter();
            tr = new StreamReader(path);
            string[] strings = Interpreter.SPCScriptCommands;
            List<SPCScriptCommand> commands = new List<SPCScriptCommand>();
            int octave = 0;
            bool octaveIsSet = false;
            string temp = "";
            string error = "";
            int lineNumber = 1;
            while (tr.Peek() != -1)
            {
                try
                {
                    int opcode = -1;
                    int parameter1 = 0;
                    int parameter2 = 0;
                    int parameter3 = 0;
                    int length = 0;
                    byte[] command;
                    string line = tr.ReadLine();
                    temp = line;
                    #region Notes
                    if (line.StartsWith("Note "))
                    {
                        line = line.Remove(0, 5); // remove "Note "
                        int beat = -1;
                        int pitch = 0;
                        int duration = 0;
                        // see if it's a note to play
                        if (line.StartsWith("play: "))
                        {
                            line = line.Remove(0, 6); // remove "play: "
                            bool Ab = line.StartsWith("Ab");
                            // Find pitch based on letter key
                            if (line.StartsWith("Ab")) { pitch = 11; line = line.Remove(0, 2); }
                            else if (line.StartsWith("A#") || line.StartsWith("Bb")) { pitch = 1; line = line.Remove(0, 2); }
                            else if (line.StartsWith("A")) { pitch = 0; line = line.Remove(0, 1); }
                            else if (line.StartsWith("B") || line.StartsWith("Cb")) { pitch = 2; line = line.Remove(0, 1); }
                            else if (line.StartsWith("C#") || line.StartsWith("Db")) { pitch = 4; line = line.Remove(0, 2); }
                            else if (line.StartsWith("C")) { pitch = 3; line = line.Remove(0, 1); }
                            else if (line.StartsWith("D#") || line.StartsWith("Eb")) { pitch = 6; line = line.Remove(0, 2); }
                            else if (line.StartsWith("D")) { pitch = 5; line = line.Remove(0, 1); }
                            else if (line.StartsWith("E#")) { pitch = 8; line = line.Remove(0, 2); }
                            else if (line.StartsWith("E") || line.StartsWith("Fb")) { pitch = 7; line = line.Remove(0, 1); }
                            else if (line.StartsWith("F#") || line.StartsWith("Gb")) { pitch = 9; line = line.Remove(0, 2); }
                            else if (line.StartsWith("F")) { pitch = 8; line = line.Remove(0, 1); }
                            else if (line.StartsWith("G#")) { pitch = 11; line = line.Remove(0, 2); }
                            else if (line.StartsWith("G")) { pitch = 10; line = line.Remove(0, 1); }
                            // Check if octave set in note (only 9 octaves)
                            if (Regex.IsMatch(line[0].ToString(), "[0-8]"))
                            {
                                // if different from current octave, change octave
                                byte value = Convert.ToByte(line[0].ToString(), 10);
                                // Only if not Ab0, b/c Ab0 doesn't exist
                                if (Ab && octave != 0)
                                    octave--;
                                else if (Ab && octave == 0)
                                    continue; // Skip because Ab0 not valid note, thus not valid command
                                if (value != octave || !octaveIsSet)
                                {
                                    if (!octaveIsSet) // if first note, must set current octave
                                    {
                                        command = new byte[] { 0xC6, value };
                                        octave = value;
                                        octaveIsSet = true;
                                    }
                                    else if (value == octave + 1)
                                    {
                                        command = new byte[] { 0xC4 };
                                        octave++;
                                    }
                                    else if (value == octave - 1)
                                    {
                                        command = new byte[] { 0xC5 };
                                        octave--;
                                    }
                                    else
                                    {
                                        command = new byte[] { 0xC6, value };
                                        octave = value;
                                    }
                                    if (Type == 0)
                                        commands.Add(new SPCScriptCommand(command, (SPCTrack)this.spc, mouseOverChannel));
                                    else
                                        commands.Add(new SPCScriptCommand(command, (SPCSound)this.spc, mouseOverChannel));
                                }
                                line = line.Remove(0, 1);
                            }
                            line = line.Remove(0, 2); // remove ", "
                        }
                        else if (line.StartsWith("stop, "))
                        {
                            pitch = 12;
                            line = line.Remove(0, 6); // remove "hold, "
                        }
                        else if (line.StartsWith("hold, "))
                        {
                            pitch = 13;
                            line = line.Remove(0, 6); // remove "stop, "
                        }
                        // now check if beat or fixed duration
                        if (line.StartsWith("beat: "))
                        {
                            line = line.Remove(0, 6);
                            switch (line)
                            {
                                case "whole": beat = 0; break;
                                case "half.": beat = 1; break;
                                case "half": beat = 2; break;
                                case "quarter.": beat = 3; break;
                                case "quarter": beat = 4; break;
                                case "8th.": beat = 5; break;
                                case "8th+32nd": beat = 6; break;
                                case "8th": beat = 7; break;
                                case "16th.": beat = 8; break;
                                case "16th": beat = 9; break;
                                case "32nd.": beat = 10; break;
                                case "32nd": beat = 11; break;
                                case "64th": beat = 12; break;
                                default: break;
                            }
                        }
                        else if (line.StartsWith("duration: "))
                        {
                            line = line.Remove(0, 10);
                            duration = Convert.ToByte(line, 10);
                            // check if duration a standard beat length
                            for (int i = 0; i < 13; i++)
                                if (duration == Model.Data[0x042304 + i])
                                    beat = i;
                        }
                        if (beat == -1)
                        {
                            opcode = 0xB6 + pitch;
                            parameter1 = duration;
                        }
                        else
                            opcode = beat * 14 + pitch;
                    }
                    #endregion
                    #region Commands
                    else
                    {
                        // look through interpreter strings for legitimate opcodes
                        for (int i = 0xC4; i < strings.Length; i++)
                        {
                            if (strings[i] != "" && line.StartsWith(strings[i]))
                            {
                                opcode = i;
                                line = line.Remove(0, strings[i].Length);
                                break;
                            }
                        }
                        // if line has no matches, check if raw opcode in {}
                        if (opcode == -1 && line.Length >= 4 && line.StartsWith("{") && line.EndsWith("}"))
                        {
                            // remove {} and -
                            line = line.Replace("{", "");
                            line = line.Replace("-", "");
                            length = line.Length / 2;
                            string[] bytes = line.Split(new char[] { '-' });
                            opcode = Convert.ToByte(bytes[0], 16);
                            if (bytes.Length > 1)
                                parameter1 = Convert.ToByte(bytes[1], 16);
                            if (bytes.Length > 2)
                                parameter2 = Convert.ToByte(bytes[2], 16);
                            if (bytes.Length > 3)
                                parameter3 = Convert.ToByte(bytes[3], 16);
                        }
                        // if no matches and not raw opcode, not a legitimate command
                        else if (opcode == -1)
                            continue;
                        // otherwise, it is a legitimate command, so continue reading line
                        #region Opcode Interpreter
                        // get array of strings for each individual parameter
                        string[] parameters = line.Split(new char[] { ',' });
                        switch (opcode)
                        {
                            case 0xCD: // Play sound
                            case 0xCE: // Play sound
                            case 0xDE: // Set instrument
                                line = line.Replace("{", "");
                                line = line.Replace("}", "");
                                line = line.Remove(3); // rest not needed, just need sound effect index
                                parameter1 = Convert.ToByte(line, 10);
                                break;
                            case 0xC4: // Octave up
                                octave++; break;
                            case 0xC5: // Octave down
                                octave--; break;
                            case 0xC6: // Octave = 
                                parameter1 = Convert.ToByte(line, 10);
                                octave = parameter1;
                                octaveIsSet = true;
                                break;
                            case 0xC8: // Noise on, channels = 
                            case 0xCF: // Transpose 1/16 pitch = 
                            case 0xD1: // Beat duration = 
                            case 0xD4: // Start loop, count = 
                            case 0xDC: // Echo, decay ratio : 24 = 
                            case 0xE0: // Staccato = 
                            case 0xE2: // Volume = 
                            case 0xEC: // Transpose 1/4 pitch 1 = 
                            case 0xED: // Transpose 1/4 pitch 2 = 
                            case 0xF6: // Portamento on, length = 
                                parameter1 = Convert.ToByte(line, 10);
                                break;
                            case 0xE4: // Volume slide, duration = 
                            case 0xE5: // Portamento, duration = 
                                parameter1 = Convert.ToByte(parameters[0], 10);
                                parameters[1] = parameters[1].Remove(0, 9);
                                parameter2 = (byte)((sbyte)Convert.ToInt32(parameters[1], 10));
                                break;
                            case 0xE8: // Speaker balance shift, duration = 
                                parameter1 = Convert.ToByte(parameters[0], 10);
                                parameters[1] = parameters[1].Remove(0, 11);
                                parameter2 = (byte)((sbyte)Convert.ToInt32(parameters[1], 10));
                                break;
                            case 0xE9: // Speaker balance pansweep, duration = 
                                parameter1 = Convert.ToByte(parameters[0], 10);
                                parameters[1] = parameters[1].Remove(0, 9);
                                parameter2 = Convert.ToByte(parameters[1], 10);
                                break;
                            case 0xF0: // Tremolo, rate = 
                            case 0xF1: // Vibrato, rate = 
                                parameter1 = Convert.ToByte(parameters[0], 10);
                                parameters[1] = parameters[1].Remove(0, 10);
                                parameter2 = Convert.ToByte(parameters[1], 10);
                                parameters[2] = parameters[2].Remove(0, 14);
                                parameter3 = Convert.ToByte(parameters[2], 10);
                                break;
                            case 0xE7: // speaker balance = 
                            case 0xF2: // beat duration, change = 
                                parameter1 = (byte)((sbyte)Convert.ToInt32(line, 10)); // signed byte
                                break;
                            case 0xFC: // Reverb, delay time = 
                                parameter1 = Convert.ToByte(parameters[0], 10);
                                parameters[1] = parameters[1].Remove(0, 10);
                                parameter2 = Convert.ToByte(parameters[1], 10);
                                parameters[2] = parameters[2].Remove(0, 14);
                                parameter3 = Convert.ToByte(parameters[2], 10);
                                break;
                            default: break;
                        }
                        #endregion
                    }
                    #endregion
                    // create the command data
                    length = SPCScriptEnums.SPCScriptLengths[opcode];
                    command = new byte[length];
                    if (length > 0)
                        command[0] = (byte)opcode;
                    if (length > 1)
                        command[1] = (byte)parameter1;
                    if (length > 2)
                        command[2] = (byte)parameter2;
                    if (length > 3)
                        command[3] = (byte)parameter3;
                    if (Type == 0)
                        commands.Add(new SPCScriptCommand(command, (SPCTrack)this.spc, mouseOverChannel));
                    else
                        commands.Add(new SPCScriptCommand(command, (SPCSound)this.spc, mouseOverChannel));
                }
                catch (Exception ex)
                {
                    error += "Error reading line #" + lineNumber + " (\"" + temp + "\"). " + ex.Message + "\n";
                }
                lineNumber++;
            }
            if (error == "")
                MessageBox.Show("Import successful.", "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                new NewMessageBox("LAZY SHELL", "There were some errors importing the channel script.", error, "", MessageIcon.Warning).ShowDialog();
            tr.Close();
            spc.Channels[mouseOverChannel] = commands;
            if (Type == 0)
                ((SPCTrack)spc).AssembleSPCData();
            RefreshSPC();
        }
        private void exportTrack_Click(object sender, EventArgs e)
        {
            if (Type == 0)
                new IOElements((Element[])Model.SPCs, Index, "EXPORT SPCS...").ShowDialog();
            else if (Type == 1)
                new IOElements((Element[])Model.SPCEvent, Index, "EXPORT EVENT SOUNDS...").ShowDialog();
            else
                new IOElements((Element[])Model.SPCBattle, Index, "EXPORT BATTLE SOUNDS...").ShowDialog();
        }
        private void exportScript_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.FileName = Model.GetFileNameWithoutPath() + " - ";
            if (Type == 0)
                saveFileDialog.FileName += "SPCScript." + Index.ToString("d2");
            else if (Type == 1)
                saveFileDialog.FileName += "EVTSoundFX." + Index.ToString("d3");
            else
                saveFileDialog.FileName += "BATSoundFX." + Index.ToString("d3");
            saveFileDialog.FileName += "." + mouseOverChannel;
            saveFileDialog.FileName += ".txt";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;
            //
            StreamWriter script = File.CreateText(saveFileDialog.FileName);
            List<SPCScriptCommand> channel = spc.Channels[mouseOverChannel];
            foreach (SPCScriptCommand ssc in channel)
                script.WriteLine(ssc.ToString());
            script.Close();
        }
        private void clearChannel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear all data in this channel -- are you sure?", "LAZY SHELL",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            spc.Channels[mouseOverChannel] = new List<SPCScriptCommand>();
            if (Type == 0)
                ((SPCTrack)spc).AssembleSPCData();
            RefreshSPC();
        }
        private void clear_Click(object sender, EventArgs e)
        {
            ClearElements clearElements;
            if (Type == 0)
                clearElements = new ClearElements(Model.SPCs, Index, "CLEAR SPCS...");
            else if (Type == 1)
                clearElements = new ClearElements(Model.SPCEvent, Index, "CLEAR EVENT SOUNDS...");
            else
                clearElements = new ClearElements(Model.SPCBattle, Index, "CLEAR BATTLE SOUNDS...");
            clearElements.ShowDialog();
            if (clearElements.DialogResult == DialogResult.Cancel)
                return;
            RefreshSPC();
        }
        #endregion
    }
}
