using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL.Audio
{
    public partial class TrackViewerForm : Controls.DockForm
    {
        #region Variables

        // Forms
        private OwnerForm ownerForm;
        private ScoreViewerForm scoreViewerForm
        {
            get { return ownerForm.ScoreViewerForm; }
            set { ownerForm.ScoreViewerForm = value; }
        }

        // Index
        private int Index
        {
            get { return ownerForm.Index; }
            set { ownerForm.Index = value; }
        }
        private ElementType Type
        {
            get { return ownerForm.Type; }
            set { ownerForm.Type = value; }
        }

        // Elements
        private SPC SPC
        {
            get { return ownerForm.SPC; }
            set { ownerForm.SPC = value; }
        }
        private Command copiedSSC;

        // Collections
        public CheckBox[] ActiveChannels { get; set; }

        // Mouse behavior
        public int MouseDownChannel { get; set; }
        public int MouseOverChannel { get; set; }
        public Command MouseDownSSC { get; set; }
        public Command MouseOverSSC { get; set; }
        public bool MouseEnterPage { get; set; }

        // Picture
        public PictureBox Picture
        {
            get { return picture; }
            set { picture = value; }
        }
        private Controls.NewPictureBox scoreViewerPicture
        {
            get { return scoreViewerForm.Picture; }
            set { scoreViewerForm.Picture = value; }
        }

        #endregion

        // Constructor
        public TrackViewerForm(OwnerForm owner)
        {
            this.ownerForm = owner;
            InitializeComponent();
            InitializeControls();
        }

        #region Methods

        // Initialization
        public void LoadProperties()
        {
            if (Index != 0 || Type != ElementType.SPCTrack)
                SPC.CreateNotes();
            MouseDownSSC = null;
            ReadFromCommand();
            SetHScrollBar();
        }
        private void InitializeControls()
        {
            newCommands.Items.AddRange(Lists.SPCCommands);
            ActiveChannels = new CheckBox[8];
            for (int i = 0; i < 8; i++)
            {
                ActiveChannels[i] = new CheckBox();
                ActiveChannels[i].Location = new Point(6, i * 36 + 36);
                ActiveChannels[i].Tag = i;
                ActiveChannels[i].CheckedChanged += new EventHandler(activeChannel_CheckedChanged);
                if (i >= 2)
                    ActiveChannels[i].Visible = Type == ElementType.SPCTrack;
                this.Controls.Add(ActiveChannels[i]);
            }
        }

        /// <summary>
        /// Selects a specified command in the picture and loads its properties into the command controls.
        /// </summary>
        public void SelectCommand(Command command)
        {
            if (command == null)
                return;
            MouseDownSSC = command;
            int index = command.Index;
            hScrollBar.Value = Math.Min(hScrollBar.Maximum, index * 24);
            picture.Invalidate();
            ReadFromCommand();
        }
        /// <summary>
        /// Refreshes the maximum size of the hScrollBar based on the
        /// channel containing the most commands in the SPC.
        /// </summary>
        public void SetHScrollBar()
        {
            this.Updating = true;
            //
            hScrollBar.Maximum = 0;
            if (Index != 0 || Type != ElementType.SPCTrack)
            {
                for (int i = 0; i < SPC.Channels.Length; i++)
                {
                    ActiveChannels[i].Checked = SPC.ActiveChannels[i];
                    if (!SPC.ActiveChannels[i])
                        continue;
                    hScrollBar.SmallChange = 24;
                    hScrollBar.LargeChange = 24 * 4;
                    if (SPC.Channels[i].Count * 24 - picture.Width > hScrollBar.Maximum)
                        hScrollBar.Maximum = SPC.Channels[i].Count * 24;
                }
            }
            //
            this.Updating = false;
        }

        #region Command editing

        /// <summary>
        /// Loads the command data from MouseDownSSC into the command editing controls.
        /// </summary>
        public void ReadFromCommand()
        {
            ResetControls();
            //
            this.Updating = true;
            //
            if (MouseDownSSC != null && ActiveChannels[MouseDownSSC.Channel].Checked)
            {
                switch (MouseDownSSC.Opcode)
                {
                    case 0xC4:
                    case 0xC5:
                        opcodeByte1.Value = MouseDownSSC.Opcode;
                        break;
                    case 0xC6:
                        labelParameter1.Text = "Octave = ";
                        opcodeByte1.Value = MouseDownSSC.Opcode;
                        parameterByte1.Maximum = 8;
                        parameterByte1.Enabled = true;
                        parameterByte1.Value = MouseDownSSC.Param1;
                        break;
                    case 0xC8: labelParameter1.Text = "Channels"; goto case 0xF6;
                    case 0xCD:
                    case 0xCE:
                        labelParameter1.Text = "Sound";
                        opcodeByte1.Value = MouseDownSSC.Opcode;
                        parameterName1.Enabled = true;
                        if (Type != ElementType.SPCBattle)
                            parameterName1.Items.AddRange(Lists.Numerize(Lists.SPCEventSounds));
                        else
                            parameterName1.Items.AddRange(Lists.Numerize(Lists.SPCBattleSounds));
                        parameterName1.SelectedIndex = MouseDownSSC.Param1;
                        parameterName1.BringToFront();
                        break;
                    case 0xCF: labelParameter1.Text = "1/16 pitch = "; goto case 0xF2;
                    case 0xD1: labelParameter1.Text = "Beat duration = "; goto case 0xF6;
                    case 0xD2: labelParameter1.Text = "ARAM $69 = "; goto case 0xF6;
                    case 0xD4: labelParameter1.Text = "Loop count = "; goto case 0xF6;
                    case 0xD9:
                        labelParameter1.Text = "ADSR attack = ";
                        opcodeByte1.Value = MouseDownSSC.Opcode;
                        parameterByte1.Enabled = true;
                        parameterByte1.Maximum = 15;
                        parameterByte1.Value = MouseDownSSC.Param1;
                        break;
                    case 0xDA:
                        labelParameter1.Text = "ADSR decay = ";
                        opcodeByte1.Value = MouseDownSSC.Opcode;
                        parameterByte1.Enabled = true;
                        parameterByte1.Maximum = 7;
                        parameterByte1.Value = MouseDownSSC.Param1;
                        break;
                    case 0xDB:
                        labelParameter1.Text = "ADSR sustain = ";
                        opcodeByte1.Value = MouseDownSSC.Opcode;
                        parameterByte1.Enabled = true;
                        parameterByte1.Maximum = 7;
                        parameterByte1.Value = MouseDownSSC.Param1;
                        break;
                    case 0xDC:
                        labelParameter1.Text = "ADSR release = ";
                        opcodeByte1.Value = MouseDownSSC.Opcode;
                        parameterByte1.Enabled = true;
                        parameterByte1.Maximum = 31;
                        parameterByte1.Value = MouseDownSSC.Param1;
                        break;
                    case 0xDD:
                        labelParameter1.Text = "Sample length = ";
                        opcodeByte1.Value = MouseDownSSC.Opcode;
                        parameterByte1.Enabled = true;
                        parameterByte1.Maximum = 15;
                        parameterByte1.Value = MouseDownSSC.Param1;
                        break;
                    case 0xDE:
                        labelParameter1.Text = "Sample = ";
                        opcodeByte1.Value = MouseDownSSC.Opcode;
                        parameterName1.Enabled = true;
                        parameterName1.BringToFront();
                        parameterName1.Items.AddRange(Lists.Numerize(Lists.Samples));
                        parameterName1.SelectedIndex = MouseDownSSC.Param1;
                        break;
                    case 0xDF:
                        labelParameter1.Text = "Pitch = ";
                        labelParameter2.Text = "VOXCON = ";
                        opcodeByte1.Value = MouseDownSSC.Opcode;
                        parameterByte1.Enabled = true;
                        parameterByte1.Minimum = -16;
                        parameterByte1.Maximum = 15;
                        if (!Bits.GetBit(MouseDownSSC.Param1, 4))
                            parameterByte1.Value = MouseDownSSC.Param1 & 0x0F;
                        else
                            parameterByte1.Value = -(((MouseDownSSC.Param1 & 0x1F) ^ 0x1F) + 1);
                        parameterByte2.Enabled = true;
                        parameterByte2.Value = MouseDownSSC.Param1 >> 5;
                        break;
                    case 0xE0:
                        labelParameter1.Text = "Fadeout = ";
                        opcodeByte1.Value = MouseDownSSC.Opcode;
                        parameterByte1.Enabled = true;
                        parameterByte1.Maximum = 31;
                        parameterByte1.Value = MouseDownSSC.Param1;
                        break;
                    case 0xE2:
                        labelParameter1.Text = "Volume = ";
                        parameterByte1.Maximum = 127;
                        goto case 0xF6;
                    case 0xE3:
                        labelParameter1.Text = "Amount = ";
                        opcodeByte1.Value = MouseDownSSC.Opcode;
                        parameterByte1.Enabled = true;
                        parameterByte1.Maximum = 127;
                        parameterByte1.Minimum = -128;
                        parameterByte1.Value = (sbyte)MouseDownSSC.Param1;
                        break;
                    case 0xE4:
                    case 0xE5:
                        labelParameter1.Text = "Duration = ";
                        if (MouseDownSSC.Opcode == 0xE4)
                            labelParameter2.Text = "Volume = ";
                        else
                            labelParameter2.Text = "Pitch = ";
                        opcodeByte1.Value = MouseDownSSC.Opcode;
                        parameterByte1.Enabled = true;
                        parameterByte1.Value = MouseDownSSC.Param1;
                        parameterByte2.Enabled = true;
                        parameterByte2.Maximum = 127;
                        parameterByte2.Minimum = -128;
                        parameterByte2.Value = (sbyte)MouseDownSSC.Param2;
                        break;
                    case 0xE7: labelParameter1.Text = "Balance = "; goto case 0xF6;
                    case 0xE8:
                    case 0xE9:
                        labelParameter1.Text = "Duration = ";
                        if (MouseDownSSC.Opcode == 0xE8)
                            labelParameter2.Text = "End balance = ";
                        else
                            labelParameter2.Text = "Reach = ";
                        opcodeByte1.Value = MouseDownSSC.Opcode;
                        parameterByte1.Enabled = true;
                        parameterByte1.Value = MouseDownSSC.Param1;
                        parameterByte2.Enabled = true;
                        parameterByte2.Value = MouseDownSSC.Param2;
                        break;
                    case 0xEC:
                    case 0xED: labelParameter1.Text = "1/4 pitch = "; goto case 0xF2;
                    case 0xF0:
                    case 0xF1:
                        labelParameter1.Text = "Amplitude = ";
                        labelParameter2.Text = "Wavelength = ";
                        opcodeByte1.Value = MouseDownSSC.Opcode;
                        parameterByte1.Enabled = true;
                        parameterByte1.Value = MouseDownSSC.Param1;
                        parameterByte2.Enabled = true;
                        parameterByte2.Value = MouseDownSSC.Param2;
                        if (MouseDownSSC.Opcode == 0xF1)
                        {
                            labelParameter3.Text = "Delay = ";
                            parameterByte3.Enabled = true;
                            parameterByte3.Value = MouseDownSSC.Param3;
                        }
                        break;
                    case 0xF2:
                        if (MouseDownSSC.Opcode == 0xF2)
                            labelParameter1.Text = "Change = ";
                        opcodeByte1.Value = MouseDownSSC.Opcode;
                        parameterByte1.Enabled = true;
                        parameterByte1.Maximum = 127;
                        parameterByte1.Minimum = -128;
                        parameterByte1.Value = (sbyte)MouseDownSSC.Param1;
                        break;
                    case 0xF4:
                        labelParameter1.Text = "Roughness = ";
                        labelParameter2.Text = "Wavelength = ";
                        opcodeByte1.Value = MouseDownSSC.Opcode;
                        parameterByte1.Enabled = true;
                        parameterByte1.Value = MouseDownSSC.Param1;
                        parameterByte2.Enabled = true;
                        parameterByte2.Value = MouseDownSSC.Param2;
                        break;
                    case 0xF6:
                        if (MouseDownSSC.Opcode == 0xF6)
                            labelParameter1.Text = "Length = ";
                        opcodeByte1.Value = MouseDownSSC.Opcode;
                        parameterByte1.Enabled = true;
                        parameterByte1.Value = MouseDownSSC.Param1;
                        break;
                    case 0xFC:
                        labelParameter1.Text = "Delay Time";
                        labelParameter2.Text = "Decay Ratio";
                        labelParameter3.Text = "Echo Volume";
                        opcodeByte1.Value = MouseDownSSC.Opcode;
                        parameterByte1.Enabled = true;
                        parameterByte2.Enabled = true;
                        parameterByte3.Enabled = true;
                        parameterByte2.Maximum = 127;
                        parameterByte1.Value = MouseDownSSC.Param1;
                        parameterByte2.Value = MouseDownSSC.Param2;
                        parameterByte3.Value = MouseDownSSC.Param3;
                        break;
                    default:
                        if (MouseDownSSC.Opcode < 0xC4)
                        {
                            panelNotes.BringToFront();
                            noteNames.Enabled = true;
                            noteLengthName.Enabled = MouseDownSSC.Opcode < 0xB6;
                            noteLengthByte.Enabled = MouseDownSSC.Opcode >= 0xB6;
                            //
                            noteNames.SelectedIndex = MouseDownSSC.Opcode % 14;
                            if (MouseDownSSC.Opcode < 0xB6)
                                noteLengthName.SelectedIndex = MouseDownSSC.Opcode / 14;
                            else
                            {
                                labelBeat.Text = "Duration";
                                noteLengthByte.BringToFront();
                                noteLengthByte.Value = MouseDownSSC.Param1;
                            }
                        }
                        else
                        {
                            if (MouseDownSSC.Length > 0)
                            {
                                opcodeByte1.Value = MouseDownSSC.Opcode;
                            }
                            if (MouseDownSSC.Length > 1)
                            {
                                parameterByte1.Enabled = true;
                                parameterByte1.Value = MouseDownSSC.Param1;
                            }
                            if (MouseDownSSC.Length > 2)
                            {
                                parameterByte2.Enabled = true;
                                parameterByte2.Value = MouseDownSSC.Param2;
                            }
                            if (MouseDownSSC.Length > 3)
                            {
                                parameterByte3.Enabled = true;
                                parameterByte3.Value = MouseDownSSC.Param3;
                            }
                        }
                        break;
                }
            }
            ownerForm.SetFreeBytesLabel();
            //
            this.Updating = false;
        }
        /// <summary>
        /// Writes the values in the command editing controls to the command data of MouseDownSSC.
        /// </summary>
        private void WriteToCommand()
        {
            if (MouseDownSSC == null)
                return;
            switch (MouseDownSSC.Opcode)
            {
                case 0xCD:
                case 0xCE:
                case 0xDE:
                    MouseDownSSC.Opcode = (byte)opcodeByte1.Value;
                    MouseDownSSC.Param1 = (byte)parameterName1.SelectedIndex;
                    break;
                case 0xDF:
                    MouseDownSSC.Opcode = (byte)opcodeByte1.Value;
                    if (parameterByte1.Value < 0)
                        MouseDownSSC.Param1 = (byte)(0x20 + parameterByte1.Value);
                    else
                        MouseDownSSC.Param1 = (byte)parameterByte1.Value;
                    MouseDownSSC.Param1 |= (byte)((byte)parameterByte2.Value << 5);
                    break;
                case 0xCF:
                case 0xE3:
                case 0xEC:
                case 0xED:
                case 0xF2:
                    MouseDownSSC.Opcode = (byte)opcodeByte1.Value;
                    MouseDownSSC.Param1 = (byte)((sbyte)parameterByte1.Value);
                    break;
                case 0xE4:
                case 0xE5:
                    MouseDownSSC.Opcode = (byte)opcodeByte1.Value;
                    MouseDownSSC.Param1 = (byte)parameterByte1.Value;
                    MouseDownSSC.Param2 = (byte)((sbyte)parameterByte2.Value);
                    break;
                default:
                    if (MouseDownSSC.Opcode < 0xC4)
                    {
                        if (MouseDownSSC.Opcode < 0xB6)
                            MouseDownSSC.Opcode = (byte)(noteLengthName.SelectedIndex * 14);
                        else
                        {
                            MouseDownSSC.Opcode = 0xB6;
                            MouseDownSSC.Param1 = (byte)noteLengthByte.Value;
                        }
                        MouseDownSSC.Opcode += (byte)noteNames.SelectedIndex;
                    }
                    else
                    {
                        if (MouseDownSSC.Length > 0)
                            MouseDownSSC.Opcode = (byte)opcodeByte1.Value;
                        if (MouseDownSSC.Length > 1)
                            MouseDownSSC.Param1 = (byte)parameterByte1.Value;
                        if (MouseDownSSC.Length > 2)
                            MouseDownSSC.Param2 = (byte)parameterByte2.Value;
                        if (MouseDownSSC.Length > 3)
                            MouseDownSSC.Param3 = (byte)parameterByte3.Value;
                    }
                    break;
            }
            if (Type == ElementType.SPCTrack)
                (SPC as SPCTrack).WriteToBuffer();
            // if changed octave, recreate notes
            if (MouseDownSSC.Opcode == 0xC4 ||
                MouseDownSSC.Opcode == 0xC5 ||
                MouseDownSSC.Opcode == 0xC6)
                SPC.CreateNotes();
            ownerForm.SetFreeBytesLabel();
        }
        /// <summary>
        /// Resets the values of all controls linked to the command's properties.
        /// </summary>
        private void ResetControls()
        {
            this.Updating = true;
            //
            labelOpcode1.Text = "Opcode 1";
            labelParameter1.Text = "Parameter 1";
            labelParameter2.Text = "Parameter 2";
            labelParameter3.Text = "Parameter 3";
            labelBeat.Text = "Beat";
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
            this.Updating = false;
        }

        #endregion

        #endregion

        #region Event Handlers

        // Picture
        private void picture_Paint(object sender, PaintEventArgs e)
        {
            if (Index == 0 && Type == ElementType.SPCTrack)
                return;
            //
            var brush = new SolidBrush(Color.FromArgb(24, 0, 0, 0));
            if (MouseEnterPage && MouseOverChannel >= 0 && SPC.ActiveChannels[MouseOverChannel])
                e.Graphics.FillRectangle(brush, 0, MouseOverChannel * 36 + 3, picture.Width, 31);
            //
            brush = new SolidBrush(SystemColors.ControlText);
            Font font = new Font("Lucida Console", 8.25F);
            Pen pen = new Pen(Color.Black); pen.DashStyle = DashStyle.Dot;
            int x = 0;
            int y = 0;
            for (int t = 0; t < SPC.Channels.Length; t++)
            {
                if (!SPC.ActiveChannels[t] || SPC.Channels[t] == null)
                    continue;
                pen.Color = Color.Black;
                e.Graphics.DrawLine(pen, 0, t * 36 + 2, picture.Width, t * 36 + 2);
                e.Graphics.DrawLine(pen, 0, t * 36 + 34, picture.Width, t * 36 + 34);
                for (int c = 0; c < SPC.Channels[t].Count; c++)
                {
                    x = c * 24 + 8 - hScrollBar.Value;
                    y = t * 36 + 10;
                    if (x < -24 || x > picture.Width + 24)
                        continue;
                    var ssc = SPC.Channels[t][c];
                    switch (ssc.Opcode)
                    {
                        case 0xC4: e.Graphics.DrawImage(Icons.OctaveUp, x, y); break;
                        case 0xC5: e.Graphics.DrawImage(Icons.OctaveDown, x, y); break;
                        case 0xC6: e.Graphics.DrawImage(Icons.OctaveSet, x, y); break;
                        case 0xD0: e.Graphics.DrawImage(Icons.Terminate, x, y); break;
                        case 0xD1: e.Graphics.DrawImage(Icons.Metronome, x, y); break;
                        case 0xD4: e.Graphics.DrawImage(Icons.Loop, x, y); break;
                        case 0xD5: e.Graphics.DrawImage(Icons.LoopEnd, x, y); break;
                        case 0xD6: e.Graphics.DrawImage(Icons.FirstSection, x, y); break;
                        case 0xD7: e.Graphics.DrawImage(Icons.LoopInf, x, y); break;
                        case 0xDE: e.Graphics.DrawImage(Icons.Instrument, x, y); break;
                        case 0xE2: e.Graphics.DrawImage(Icons.Volume, x, y); break;
                        case 0xE5: e.Graphics.DrawImage(Icons.Portamento, x, y); break;
                        case 0xE7: e.Graphics.DrawImage(Icons.SpeakerBalance, x, y); break;
                        case 0xEE: e.Graphics.DrawImage(Icons.DrumsOn, x, y); break;
                        case 0xEF: e.Graphics.DrawImage(Icons.DrumsOff, x, y); break;
                        case 0xF0: e.Graphics.DrawImage(Icons.Tremolo, x, y); break;
                        case 0xF1: e.Graphics.DrawImage(Icons.Vibrato, x, y); break;
                        case 0xFA: e.Graphics.DrawImage(Icons.ReverbOn, x, y); break;
                        case 0xFB: e.Graphics.DrawImage(Icons.ReverbOff, x, y); break;
                        default:
                            // Draw a note image
                            if (ssc.Opcode < 0xC4)
                            {
                                Note note = new Note(ssc);
                                if (!note.Rest && !note.Tie)
                                {
                                    var stem = Music.GetStem(note.Ticks, 0, false, Color.Red);
                                    var head = Music.GetHead(note.Ticks, 0, false, Color.Red);
                                    if (stem != null)
                                        e.Graphics.DrawImage(stem, x, y);
                                    e.Graphics.DrawImage(head, x, y);
                                }
                                else if (note.Rest)
                                {
                                    var image = Music.GetRest(note.Ticks, false, Color.Red);
                                    e.Graphics.DrawImage(image, x, y);
                                }
                                else if (note.Tie)
                                    e.Graphics.DrawImage(Icons.TieOver, x, y, 16, 16);
                            }
                            // Draw opcode's hex value
                            else
                                e.Graphics.DrawString(ssc.Opcode.ToString("X2"), font, brush, x, y + 2);
                            break;
                    }
                    pen.Color = Color.Red;
                    if (ssc == MouseDownSSC)
                        e.Graphics.DrawRectangle(pen, x - 4, y - 4, 24, 24);
                    pen.Color = Color.Black;
                }
            }
        }
        private void picture_MouseMove(object sender, MouseEventArgs e)
        {
            this.MouseOverChannel = -1;
            this.MouseOverSSC = null;
            if (Index == 0)
                return;
            int x = e.X + hScrollBar.Value - 8;
            int y = e.Y % 36;
            int mouseOverChannel = e.Y / 36;
            if (mouseOverChannel < SPC.Channels.Length)
                this.MouseOverChannel = mouseOverChannel;
            //
            if (mouseOverChannel < SPC.Channels.Length &&
                SPC.ActiveChannels[mouseOverChannel] &&
                SPC.Channels[mouseOverChannel] != null &&
                x >= 0 && x % 24 < 16 && y >= 10 && y < 26)
            {
                int index = x / 24;
                if (index < SPC.Channels[mouseOverChannel].Count)
                {
                    MouseOverSSC = SPC.Channels[mouseOverChannel][index];
                    labelCommand.Text = Parser.ParseCommand(MouseOverSSC);
                    labelBits.Text = "{" + BitConverter.ToString(MouseOverSSC.Data) + "}";
                    labelIndex.Text = "Index " + index;
                    picture.Cursor = Cursors.Hand;
                }
            }
            else
            {
                labelCommand.Text = "...";
                labelBits.Text = "...";
                labelIndex.Text = "...";
                picture.Cursor = Cursors.Arrow;
            }
            picture.Invalidate();
        }
        private void picture_MouseEnter(object sender, EventArgs e)
        {
            MouseEnterPage = true;
            picture.Invalidate();
        }
        private void picture_MouseLeave(object sender, EventArgs e)
        {
            MouseEnterPage = false;
            picture.Invalidate();
        }
        private void picture_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownSSC = null;
            MouseDownChannel = -1;
            if (Index == 0)
                return;
            if (MouseOverSSC != null)
            {
                MouseDownSSC = MouseOverSSC;
                MouseDownChannel = MouseOverChannel;
                ReadFromCommand();
            }
            picture.Invalidate();
        }

        // ScrollBar
        private void hScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            picture.Invalidate();
        }
        private void activeChannel_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            CheckBox activeChannel = sender as CheckBox;
            int channel = (int)activeChannel.Tag;
            SPC.ActiveChannels[channel] = activeChannel.Checked;
            if (SPC.Channels[channel].Count == 0)
                SPC.Channels[channel].Add(new Command(new byte[] { 0xD0 }, SPC, channel));
            if (Type == ElementType.SPCTrack)
                (SPC as SPCTrack).WriteToBuffer();
            ReadFromCommand();
            picture.Invalidate();
            scoreViewerPicture.Invalidate();
        }

        // Collection editing
        private void moveLeft_Click(object sender, EventArgs e)
        {
            if (MouseDownSSC == null)
                return;
            List<Command> channel = SPC.Channels[MouseDownSSC.Channel];
            int index = MouseDownSSC.Index;
            if (index > 0)
                channel.Reverse(index - 1, 2);
            SPC.CreateNotes();
            WriteToCommand();
            picture.Invalidate();
            scoreViewerPicture.Invalidate();
        }
        private void moveRight_Click(object sender, EventArgs e)
        {
            if (MouseDownSSC == null)
                return;
            List<Command> channel = SPC.Channels[MouseDownSSC.Channel];
            int index = MouseDownSSC.Index;
            if (index < channel.Count - 1)
                channel.Reverse(index, 2);
            SPC.CreateNotes();
            WriteToCommand();
            picture.Invalidate();
            scoreViewerPicture.Invalidate();
        }
        private void delete_Click(object sender, EventArgs e)
        {
            if (MouseDownSSC == null)
                return;
            int index = MouseDownSSC.Index;
            SPC.Channels[MouseDownSSC.Channel].Remove(MouseDownSSC);
            if (index >= 0 && SPC.Channels[MouseDownSSC.Channel].Count > 0)
            {
                index = Math.Min(SPC.Channels[MouseDownSSC.Channel].Count - 1, index);
                MouseDownSSC = SPC.Channels[MouseDownSSC.Channel][index];
            }
            else
                MouseDownSSC = null;
            SPC.CreateNotes();
            ReadFromCommand();
            WriteToCommand();
            picture.Invalidate();
            scoreViewerPicture.Invalidate();
        }
        private void newNote_Click(object sender, EventArgs e)
        {
            int index = -1;
            int channelIndex = -1;
            if (MouseDownSSC != null)
            {
                index = MouseDownSSC.Index;
                channelIndex = MouseDownSSC.Channel;
            }
            else
            {
                // look for 1st active channel and insert the command at the beginning
                for (int i = 0; i < SPC.ActiveChannels.Length; i++)
                    if (SPC.ActiveChannels[i]) { channelIndex = i; break; }
            }
            if (channelIndex == -1)
                return;
            if (newCommands.SelectedIndex == -1)
                return;
            int opcode;
            if (newCommands.SelectedIndex == 0)
                opcode = 0;
            else if (newCommands.SelectedIndex == 1)
                opcode = 0xB6;
            else
                opcode = newCommands.SelectedIndex + 0xC2;
            int length = ScriptEnums.CommandLengths[opcode];
            Command ssc;
            if (Type == ElementType.SPCTrack)
                ssc = new Command(new byte[length], (SPCTrack)SPC, channelIndex);
            else
                ssc = new Command(new byte[length], (SPCSound)SPC, channelIndex);
            ssc.Opcode = (byte)opcode;
            List<Command> channel = SPC.Channels[channelIndex];
            channel.Insert(index + 1, ssc);
            MouseDownSSC = ssc;
            SPC.CreateNotes();
            ReadFromCommand();
            WriteToCommand();
            picture.Invalidate();
            scoreViewerPicture.Invalidate();
        }
        private void copy_Click(object sender, EventArgs e)
        {
            if (MouseDownSSC == null)
                return;
            copiedSSC = MouseDownSSC.Copy();
        }
        private void paste_Click(object sender, EventArgs e)
        {
            if (this.copiedSSC == null || MouseDownSSC == null)
                return;
            Command copiedSSC = this.copiedSSC.Copy();
            copiedSSC.Channel = MouseDownSSC.Channel;
            List<Command> channel = SPC.Channels[MouseDownSSC.Channel];
            channel.Insert(MouseDownSSC.Index + 1, copiedSSC);
            MouseDownSSC = copiedSSC;
            SPC.CreateNotes();
            ReadFromCommand();
            picture.Invalidate();
            scoreViewerPicture.Invalidate();
        }
        private void duplicate_Click(object sender, EventArgs e)
        {
            if (MouseDownSSC == null)
                return;
            Command copiedSSC = MouseDownSSC.Copy();
            List<Command> channel = SPC.Channels[MouseDownSSC.Channel];
            channel.Insert(MouseDownSSC.Index + 1, copiedSSC);
            MouseDownSSC = copiedSSC;
            SPC.CreateNotes();
            ReadFromCommand();
            picture.Invalidate();
            scoreViewerPicture.Invalidate();
        }
        private void findCommand_Click(object sender, EventArgs e)
        {
            try
            {
                byte value = Convert.ToByte(findCommandText.Text, 16);
                for (int a = 0; a < 3; a++)
                {
                    SPC[] spcs;
                    string type;
                    if (a == 0)
                    {
                        spcs = Model.SPCs;
                        type = "SPC Track";
                    }
                    else if (a == 1)
                    {
                        spcs = Model.SPCEvent;
                        type = "Event SFX";
                    }
                    else
                    {
                        spcs = Model.SPCBattle;
                        type = "Battle SFX";
                    }
                    for (int s = 0; s < spcs.Length; s++)
                    {
                        if (a == 0 && s == 0)
                            continue;
                        for (int c = 0; c < spcs[s].Channels.Length; c++)
                        {
                            for (int i = 0; i < spcs[s].Channels[c].Count; i++)
                            {
                                if (spcs[s].Channels[c][i].Opcode == value)
                                {
                                    DialogResult dialogResult = MessageBox.Show(
                                        "Found command in " + type + " index " + s + ", channel " + c + "." +
                                        "\n\nGo to command, continue searching, or stop searching?", "LAZY SHELL",
                                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                                    if (dialogResult == DialogResult.Yes)
                                    {
                                        Type = (ElementType)a;
                                        Index = s;
                                        MouseDownSSC = spcs[s].Channels[c][i];
                                        hScrollBar.Value = Math.Min(hScrollBar.Maximum, i * 24);
                                        ReadFromCommand();
                                        picture.Invalidate();
                                        return;
                                    }
                                    else if (dialogResult == DialogResult.No)
                                        continue;
                                    else if (dialogResult == DialogResult.Cancel)
                                        return;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void findCommandText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                findCommand.PerformClick();
        }

        // Command editing
        private void opcodeByte1_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            try
            {
                WriteToCommand();
                ReadFromCommand();
            }
            catch
            {
                MessageBox.Show("Couldn't change value.");
            }
            picture.Invalidate();
            scoreViewerPicture.Invalidate();
        }
        private void parameterByte1_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            try
            {
                WriteToCommand();
            }
            catch
            {
                MessageBox.Show("Couldn't change value.");
            }
            picture.Invalidate();
            scoreViewerPicture.Invalidate();
        }
        private void parameterByte2_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            try
            {
                WriteToCommand();
            }
            catch
            {
                MessageBox.Show("Couldn't change value.");
            }
            picture.Invalidate();
            scoreViewerPicture.Invalidate();
        }
        private void parameterByte3_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            try
            {
                WriteToCommand();
            }
            catch
            {
                MessageBox.Show("Couldn't change value.");
            }
            picture.Invalidate();
            scoreViewerPicture.Invalidate();
        }
        private void parameterName1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            try
            {
                WriteToCommand();
            }
            catch
            {
                MessageBox.Show("Couldn't change value.");
            }
            picture.Invalidate();
            scoreViewerPicture.Invalidate();
        }
        private void noteNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            try
            {
                WriteToCommand();
            }
            catch
            {
                MessageBox.Show("Couldn't change value.");
            }
            picture.Invalidate();
            scoreViewerPicture.Invalidate();
        }
        private void noteLengthName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            try
            {
                WriteToCommand();
            }
            catch
            {
                MessageBox.Show("Couldn't change value.");
            }
            picture.Invalidate();
            scoreViewerPicture.Invalidate();
        }
        private void noteLengthByte_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            try
            {
                WriteToCommand();
            }
            catch
            {
                MessageBox.Show("Couldn't change value.");
            }
            picture.Invalidate();
            scoreViewerPicture.Invalidate();
        }

        // ContextMenuStrip
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (MouseOverChannel < 0 || !SPC.ActiveChannels[MouseOverChannel])
                e.Cancel = true;
        }
        private void importScript_Click(object sender, EventArgs e)
        {
            if (!ownerForm.ImportSPCScript(ref SPC.Channels[MouseOverChannel]))
                return;
            if (Type == ElementType.SPCTrack)
                (SPC as SPCTrack).WriteToBuffer();
            LoadProperties();
        }
        private void exportScript_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.FileName = LAZYSHELL.Model.GetFileNameWithoutPath() + " - ";
            if (Type == ElementType.SPCTrack)
                saveFileDialog.FileName += "SPCScript-" + Index.ToString("d2");
            else if (Type == ElementType.SPCEvent)
                saveFileDialog.FileName += "EVTSoundFX-" + Index.ToString("d3");
            else
                saveFileDialog.FileName += "BATSoundFX-" + Index.ToString("d3");
            saveFileDialog.FileName += ".channel-" + MouseOverChannel;
            saveFileDialog.FileName += ".txt";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;
            //
            var script = File.CreateText(saveFileDialog.FileName);
            var channel = SPC.Channels[MouseOverChannel];
            foreach (var ssc in channel)
                script.WriteLine(ssc.ToString());
            script.Close();
        }
        private void clearChannel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear all data in this channel -- are you sure?", "LAZY SHELL",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            SPC.Channels[MouseOverChannel] = new List<Command>();
            SPC.Channels[MouseOverChannel].Add(new Command(new byte[] { 0xD0 }, SPC, MouseOverChannel));
            if (Type == ElementType.SPCTrack)
                (SPC as SPCTrack).WriteToBuffer();
            LoadProperties();
        }

        #endregion
    }
}
