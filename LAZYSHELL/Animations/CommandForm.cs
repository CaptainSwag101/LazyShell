using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LazyShell.Animations
{
    /// <summary>
    /// Form for creating and modifying an animation command in a user interface.
    /// </summary>
    public partial class CommandForm : Controls.NewForm
    {
        #region Variables

        /// <summary>
        /// The Command loaded from the OwnerForm.
        /// </summary>
        private Command command;
        /// <summary>
        /// New Command for overwriting the Command loaded from the OwnerForm.
        /// </summary>
        private Command newCommand;

        #endregion

        // Constructor
        public CommandForm(Command command)
        {
            this.command = command;
            //
            this.SnapToEdges = false;
            InitializeComponent();
            InitializePosition();
            InitializeListControls();
            ReadFromCommand(this.command);
        }

        #region Methods

        // Initialization
        private void InitializePosition()
        {
            this.Left = Cursor.Position.X + 10;
            this.Top = Cursor.Position.Y - 10;
        }
        private void InitializeListControls()
        {
            commands.Items.AddRange(Lists.AnimationCommands);
        }

        /// <summary>
        /// Loads the command's data into the controls.
        /// </summary>
        /// <param name="command">The Command loaded from Animations.OwnerForm.</param>
        private void ReadFromCommand(Command command)
        {
            panelCommand.SuspendDrawing();
            ResetControls();
            //
            this.Updating = true;
            //
            switch (command.Opcode)
            {
                case 0x00:
                    aniLabelA1.Text = "Sprite";
                    aniLabelA2.Text = "Sequence";
                    aniLabelB1.Text = "Priority";
                    aniLabelB2.Text = "VRAM address";
                    aniNameA1.Items.AddRange(Lists.Numerize(Lists.Sprites));
                    aniNameA1.Enabled = true; aniNameA1.DropDownWidth = 300;
                    aniNumA1.Maximum = 0x3FF; aniNumA1.Enabled = true;
                    aniNumA2.Maximum = 15; aniNumA2.Enabled = true;
                    aniNumB1.Maximum = 3; aniNumB1.Enabled = true;
                    aniNumB2.Hexadecimal = true; aniNumB2.Maximum = 0xFFFF; aniNumB2.Enabled = true;
                    aniBits.Items.AddRange(new object[]{
                        "overwrite VRAM",
                        "looping on",
                        "overwrite palette",
                        "use palette row 4",
                        "mirror",
                        "invert"});
                    aniBits.Enabled = true;
                    aniNumA1.Value = aniNameA1.SelectedIndex = Bits.GetShort(command.Data, 3) & 0x3FF;
                    aniNumA2.Value = command.Param5;
                    aniNumB1.Value = (command.Param6 & 0x30) >> 4;
                    aniNumB2.Value = Bits.GetShort(command.Data, 7);
                    aniBits.SetItemChecked(0, (command.Param1 & 0x01) == 0x01);
                    aniBits.SetItemChecked(1, (command.Param2 & 0x08) == 0x08);
                    aniBits.SetItemChecked(2, (command.Param2 & 0x20) == 0x20);
                    aniBits.SetItemChecked(3, (command.Param6 & 0x08) == 0x08);
                    aniBits.SetItemChecked(4, (command.Param6 & 0x40) == 0x40);
                    aniBits.SetItemChecked(5, (command.Param6 & 0x80) == 0x80);
                    break;
                case 0x01:
                case 0x0B:
                    aniLabelA1.Text = "Origin";
                    aniLabelB1.Text = "X coord";
                    aniLabelB2.Text = "Y coord";
                    aniLabelC1.Text = "Z coord";
                    aniNameA1.Items.AddRange(new object[]{
                        "absolute position",
                        "caster's initial position",
                        "target's current position",
                        "caster's current position"});
                    aniNameA1.Enabled = true;
                    aniNumB1.Enabled = true; aniNumB1.Minimum = -0x8000; aniNumB1.Maximum = 0x7FFF;
                    aniNumB2.Enabled = true; aniNumB2.Minimum = -0x8000; aniNumB2.Maximum = 0x7FFF;
                    aniNumC1.Enabled = true; aniNumC1.Minimum = -0x8000; aniNumC1.Maximum = 0x7FFF;
                    aniBits.Enabled = true;
                    aniBits.Items.AddRange(new object[] { "set X coord", "set Y coord", "set Z coord" });
                    aniNameA1.SelectedIndex = (int)(command.Param1 >> 4);
                    aniNumB1.Value = (short)Bits.GetShort(command.Data, 2);
                    aniNumB2.Value = (short)Bits.GetShort(command.Data, 4);
                    aniNumC1.Value = (short)Bits.GetShort(command.Data, 6);
                    aniBits.SetItemChecked(0, (command.Param1 & 0x01) == 0x01);
                    aniBits.SetItemChecked(1, (command.Param1 & 0x02) == 0x02);
                    aniBits.SetItemChecked(2, (command.Param1 & 0x04) == 0x04);
                    break;
                case 0x03:
                    aniLabelA1.Text = "Sprite";
                    aniLabelB1.Text = "Sequence";
                    aniNameA1.Items.AddRange(Lists.Numerize(Lists.Sprites));
                    aniNameA1.Enabled = true; aniNameA1.DropDownWidth = 300;
                    aniNumA1.Maximum = 0x3FF; aniNumA1.Enabled = true;
                    aniNumB1.Maximum = 15; aniNumB1.Enabled = true;
                    aniBits.Items.AddRange(new object[]{
                        "store to VRAM",
                        "looping on",
                        "store palette"});
                    aniBits.Enabled = true;
                    aniNumA1.Value = aniNameA1.SelectedIndex = Bits.GetShort(command.Data, 3) & 0x3FF;
                    aniNumB1.Value = command.Param5 & 15;
                    aniBits.SetItemChecked(0, (command.Param1 & 0x01) == 0x01);
                    aniBits.SetItemChecked(1, (command.Param2 & 0x08) == 0x08);
                    aniBits.SetItemChecked(2, (command.Param2 & 0x20) == 0x20);
                    break;
                case 0x04:
                    aniLabelA1.Text = "Resume after";
                    aniLabelA2.Text = "# frames";
                    aniNameA1.Items.AddRange(new object[]{
                        "{00}","{01}","{02}","{03}","{04}","{05}",
                        "sprite shift complete",
                        "{07}","{08}","{09}","{0A}","{0B}","{0C}","{0D}","{0E}","{0F}",
                        "# frames elapsed"});
                    aniNameA1.Enabled = true;
                    aniNameA1.SelectedIndex = command.Param1;
                    aniNumA2.Enabled = true; aniNumA2.Maximum = 0xFFFF;
                    aniNumA2.Value = Bits.GetShort(command.Data, 2);
                    break;
                case 0x08:
                    aniLabelA2.Text = "Speed";
                    aniLabelB1.Text = "Start position";
                    aniLabelB2.Text = "End position";
                    aniNumA2.Enabled = true; aniNumA2.Maximum = 0x7FFF; aniNumA2.Minimum = -0x8000;
                    aniNumB1.Enabled = true; aniNumB1.Maximum = 0x7FFF; aniNumB1.Minimum = -0x8000;
                    aniNumB2.Enabled = true; aniNumB2.Maximum = 0x7FFF; aniNumB2.Minimum = -0x8000;
                    aniBits.Items.AddRange(new object[]{
                        "apply to Z axis","apply to Y axis","apply to X axis",
                        "set start position","set end position","set speed"});
                    aniBits.Enabled = true;
                    aniNumA2.Value = (short)Bits.GetShort(command.Data, 6);
                    aniNumB1.Value = (short)Bits.GetShort(command.Data, 2);
                    aniNumB2.Value = (short)Bits.GetShort(command.Data, 4);
                    aniBits.SetItemChecked(0, (command.Param1 & 0x01) == 0x01);
                    aniBits.SetItemChecked(1, (command.Param1 & 0x02) == 0x02);
                    aniBits.SetItemChecked(2, (command.Param1 & 0x04) == 0x04);
                    aniBits.SetItemChecked(3, (command.Param1 & 0x20) == 0x20);
                    aniBits.SetItemChecked(4, (command.Param1 & 0x40) == 0x40);
                    aniBits.SetItemChecked(5, (command.Param1 & 0x80) == 0x80);
                    break;
                case 0x09:
                case 0x10:
                case 0x50:
                case 0x51:
                case 0x64:
                    aniLabelB1.Text = "Address";
                    aniNumB1.Maximum = 0xFFFF; aniNumB1.Hexadecimal = true; aniNumB1.Enabled = true;
                    aniNumB1.Value = Bits.GetShort(command.Data, 1);
                    break;
                case 0x0C:
                    aniLabelA1.Text = "Type";
                    aniLabelB1.Text = "Speed";
                    aniLabelB2.Text = "Arch height";
                    aniNameA1.Enabled = true;
                    aniNameA1.Items.AddRange(new object[] { "{00}", "shift", "transfer", "{04}", "{08}" });
                    aniNumB1.Enabled = true; aniNumB1.Maximum = 0x7FFF; aniNumB1.Minimum = -0x8000;
                    aniNumB2.Enabled = true; aniNumB2.Maximum = 0x7FFF; aniNumB2.Minimum = -0x8000;
                    aniNameA1.SelectedIndex = command.Param1 / 2;
                    aniNumB1.Value = (short)Bits.GetShort(command.Data, 2);
                    aniNumB2.Value = (short)Bits.GetShort(command.Data, 4);
                    break;
                case 0x20:
                case 0x21:
                case 0x22:
                case 0x23:
                case 0x2C:
                case 0x2D:
                case 0x2E:
                case 0x2F:
                    aniLabelA1.Text = "Variable type";
                    aniLabelB1.Text = "AMEM";
                    aniLabelB2.Text = "Variable";
                    aniNameA1.Items.AddRange(Parser.VariableNames);
                    aniNameA1.Enabled = true;
                    aniNumB1.Minimum = 0x60; aniNumB1.Maximum = 0x6F;
                    aniNumB1.Enabled = true; aniNumB1.Hexadecimal = true;
                    aniNumB2.Enabled = true;
                    aniNumB2.Hexadecimal = command.Param1 >> 4 != 0;
                    switch (command.Param1 >> 4)
                    {
                        case 0:
                            aniNumB2.Maximum = 0xFFFF;
                            aniNumB2.Value = Bits.GetShort(command.Data, 2);
                            break;
                        case 1:
                        case 5:
                            aniNumB2.Maximum = 0x7EFFFF;
                            aniNumB2.Minimum = 0x7E0000;
                            aniNumB2.Value = Bits.GetShort(command.Data, 2) + 0x7E0000;
                            break;
                        case 2:
                            aniNumB2.Maximum = 0x7FFFFF;
                            aniNumB2.Minimum = 0x7F0000;
                            aniNumB2.Value = Bits.GetShort(command.Data, 2) + 0x7F0000;
                            break;
                        case 3:
                            aniNumB2.Minimum = 0x60;
                            aniNumB2.Maximum = 0x6F;
                            aniNumB2.Value = (command.Param2 & 0x0F) + 0x60;
                            break;
                        case 4:
                        case 6:
                            aniNumB2.Maximum = 0xFF;
                            aniNumB2.Value = command.Param2;
                            break;
                    }
                    aniNameA1.SelectedIndex = command.Param1 >> 4;
                    aniNumB1.Value = (command.Param1 & 0x0F) + 0x60;
                    break;
                case 0x24:
                case 0x25:
                case 0x26:
                case 0x27:
                case 0x28:
                case 0x29:
                case 0x2A:
                case 0x2B:
                    aniLabelA1.Text = "Variable type";
                    aniLabelA2.Text = "AMEM";
                    aniLabelB1.Text = "Variable";
                    aniLabelB2.Text = "Jump to";
                    aniNameA1.Items.AddRange(Parser.VariableNames);
                    aniNameA1.Enabled = true;
                    aniNumA2.Minimum = 0x60; aniNumA2.Maximum = 0x6F;
                    aniNumA2.Enabled = true; aniNumA2.Hexadecimal = true;
                    aniNumB1.Enabled = true; aniNumB1.Hexadecimal = command.Param1 >> 4 != 0;
                    switch (command.Param1 >> 4)
                    {
                        case 0:
                            aniNumB1.Maximum = 0xFFFF;
                            aniNumB1.Value = Bits.GetShort(command.Data, 2);
                            break;
                        case 1:
                        case 5:
                            aniNumB1.Maximum = 0x7EFFFF;
                            aniNumB1.Minimum = 0x7E0000;
                            aniNumB1.Value = Bits.GetShort(command.Data, 2) + 0x7E0000;
                            break;
                        case 2:
                            aniNumB1.Maximum = 0x7FFFFF;
                            aniNumB1.Minimum = 0x7F0000;
                            aniNumB1.Value = Bits.GetShort(command.Data, 2) + 0x7F0000;
                            break;
                        case 3:
                            aniNumB1.Minimum = 0x60;
                            aniNumB1.Maximum = 0x6F;
                            aniNumB1.Value = (command.Param2 & 0x0F) + 0x60;
                            break;
                        case 4:
                        case 6:
                            aniNumB1.Maximum = 0xFF;
                            aniNumB1.Value = command.Param2;
                            break;
                    }
                    aniNumB2.Maximum = 0xFFFF; aniNumB2.Enabled = true; aniNumB2.Hexadecimal = true;
                    aniNameA1.SelectedIndex = command.Param1 >> 4;
                    aniNumA2.Value = (command.Param1 & 0x0F) + 0x60;
                    aniNumB2.Value = Bits.GetShort(command.Data, 4);
                    break;
                case 0x30:
                case 0x31:
                case 0x32:
                case 0x33:
                case 0x34:
                case 0x35:
                    aniLabelB1.Text = "AMEM";
                    aniNumB1.Minimum = 0x60; aniNumB1.Maximum = 0x6F;
                    aniNumB1.Hexadecimal = true; aniNumB1.Enabled = true;
                    aniNumB1.Value = (command.Param1 & 0x0F) + 0x60;
                    break;
                case 0x36:
                case 0x37:
                    aniLabelB1.Text = "AMEM";
                    aniTitleD.Text = "Bits";
                    aniNumB1.Minimum = 0x60; aniNumB1.Maximum = 0x6F;
                    aniNumB1.Hexadecimal = true; aniNumB1.Enabled = true;
                    aniBits.Items.AddRange(new object[] { "b0", "b1", "b2", "b3", "b4", "b5", "b6", "b7" });
                    aniBits.Enabled = true;
                    aniNumB1.Value = (command.Param1 & 0x0F) + 0x60;
                    for (int i = 1, j = 0; j < 8; i *= 2, j++)
                        aniBits.SetItemChecked(j, (command.Param2 & i) == i);
                    break;
                case 0x38:
                case 0x39:
                    aniLabelB1.Text = "AMEM";
                    aniTitleD.Text = "Bits";
                    aniLabelC1.Text = "Jump to";
                    aniNumB1.Minimum = 0x60; aniNumB1.Maximum = 0x6F;
                    aniNumB1.Hexadecimal = true; aniNumB1.Enabled = true;
                    aniBits.Items.AddRange(new object[] { "b0", "b1", "b2", "b3", "b4", "b5", "b6", "b7" });
                    aniBits.Enabled = true;
                    aniNumC1.Maximum = 0xFFFF; aniNumC1.Enabled = true; aniNumC1.Hexadecimal = true;
                    aniNumB1.Value = (command.Param1 & 0x0F) + 0x60;
                    for (int i = 1, j = 0; j < 8; i *= 2, j++)
                        aniBits.SetItemChecked(j, (command.Param2 & i) == i);
                    aniNumC1.Value = Bits.GetShort(command.Data, 3);
                    break;
                case 0x40:
                case 0x41:
                    aniLabelB1.Text = "AMEM";
                    aniTitleD.Text = "Bits";
                    aniNumB1.Minimum = 0x60; aniNumB1.Maximum = 0x6F;
                    aniNumB1.Enabled = true; aniNumB1.Hexadecimal = true;
                    aniBits.Items.AddRange(new object[] { "b0", "b1", "b2", "b3", "b4", "b5", "b6", "b7" });
                    aniBits.Enabled = true;
                    aniNumB1.Value = (command.Param1 & 0x0F) + 0x60;
                    for (int i = 1, j = 0; j < 8; i *= 2, j++)
                        aniBits.SetItemChecked(j, (command.Param2 & i) == i);
                    break;
                case 0x43:
                    aniLabelB1.Text = "Sequence";
                    aniNumB1.Maximum = 0x0F; aniNumB1.Enabled = true;
                    aniBits.Items.AddRange(new object[] { "looping on", "looping off", "b6", "mirror" });
                    aniBits.Enabled = true;
                    aniNumB1.Value = command.Param1 & 0x0F;
                    for (int i = 0x10, j = 0; j < 4; i *= 2, j++)
                        aniBits.SetItemChecked(j, (command.Param1 & i) == i);
                    break;
                case 0x5D:
                    aniLabelB1.Text = "Object #";
                    aniLabelB2.Text = "Address";
                    aniNumB1.Maximum = 0x0F; aniNumB1.Hexadecimal = true; aniNumB1.Enabled = true;
                    aniNumB2.Maximum = 0xFFFF; aniNumB2.Hexadecimal = true; aniNumB2.Enabled = true;
                    aniBits.Items.AddRange(new object[] { 
                        "b0", "b1", "b2", "character slot", 
                        "b4", "b5", "current target", "b7" });
                    aniBits.Enabled = true;
                    for (int i = 1, j = 0; j < 8; i *= 2, j++)
                        aniBits.SetItemChecked(j, (command.Param1 & i) == i);
                    aniNumB1.Value = command.Param2;
                    aniNumB2.Value = Bits.GetShort(command.Data, 3);
                    break;
                case 0x63:
                    aniLabelA1.Text = "Type";
                    aniNameA1.Items.AddRange(new object[] { "attack name", "spell name", "item name" });
                    aniNameA1.Enabled = true;
                    aniNameA1.SelectedIndex = command.Param1;
                    break;
                case 0x68:
                    aniLabelB1.Text = "Address";
                    aniLabelB2.Text = "Index";
                    aniNumB1.Hexadecimal = true; aniNumB1.Maximum = 0xFFFF; aniNumB1.Enabled = true;
                    aniNumB2.Maximum = 255; aniNumB2.Enabled = true;
                    aniNumB1.Value = Bits.GetShort(command.Data, 1);
                    aniNumB2.Value = command.Data[3];
                    break;
                case 0x6A:
                case 0x6B:
                    aniLabelB1.Text = "Memory";
                    aniLabelB2.Text = "Value";
                    aniNumB1.Minimum = 0x60; aniNumB1.Maximum = 0x6F;
                    aniNumB1.Hexadecimal = true; aniNumB1.Enabled = true;
                    aniNumB2.Maximum = command.Opcode == 0x6A ? 0xFF : 0xFFFF; aniNumB2.Enabled = true;
                    aniNumB1.Value = (command.Param1 & 0x0F) + 0x60;
                    aniNumB2.Value = command.Opcode == 0x6A ? command.Param2 : Bits.GetShort(command.Data, 2);
                    break;
                case 0x72:
                    aniLabelA1.Text = "Effect";
                    aniNameA1.Items.AddRange(Lists.Numerize(Lists.Effects));
                    aniNameA1.Enabled = true; aniNameA1.DropDownWidth = 250;
                    aniBits.Items.AddRange(new object[]{
                        "looping on","playback off","looping off","b3"});
                    aniBits.Enabled = true;
                    aniNameA1.SelectedIndex = command.Param2;
                    for (int i = 1, j = 0; j < 4; i *= 2, j++)
                        aniBits.SetItemChecked(j, (command.Param1 & i) == i);
                    break;
                case 0x74:
                    aniLabelA1.Text = "Pause until";
                    aniNameA1.Items.AddRange(new object[]{
                        "sequence complete (4bpp)",
                        "sequence complete (2bpp)",
                        "fade in complete",
                        "fade complete (4bpp)",
                        "fade complete (2bpp)"});
                    aniNameA1.Enabled = true;
                    switch (Bits.GetShort(command.Data, 1))
                    {
                        case 0x0004:
                            aniNameA1.SelectedIndex = 0; break;
                        case 0x0008:
                            aniNameA1.SelectedIndex = 1; break;
                        case 0x0200:
                            aniNameA1.SelectedIndex = 2; break;
                        case 0x0400:
                            aniNameA1.SelectedIndex = 3; break;
                        case 0x0800:
                            aniNameA1.SelectedIndex = 4; break;
                        default:
                            break;
                    }
                    break;
                case 0x75:
                    aniLabelB1.Text = "Bits";
                    aniNumB1.Maximum = 0xFFFF; aniNumB1.Hexadecimal = true; aniNumB1.Enabled = true;
                    aniNumB1.Value = Bits.GetShort(command.Data, 1);
                    break;
                case 0x77:
                case 0x78:
                    aniLabelA1.Text = "Overlap";
                    aniNameA1.Items.AddRange(new object[] { 
                        "transparency off", "overlap all", "overlap none", "overlap all except allies" });
                    aniNameA1.Enabled = true;
                    aniBits.Items.AddRange(new object[]{
                        "b0","4bpp","2bpp","invisible"});
                    aniBits.Enabled = true;
                    aniNameA1.SelectedIndex = command.Param1 >> 4;
                    for (int i = 1, j = 0; j < 4; i *= 2, j++)
                        aniBits.SetItemChecked(j, (command.Param1 & i) == i);
                    break;
                case 0x7A:
                    aniLabelA1.Text = "Type";
                    aniLabelA2.Text = "Dialogue #";
                    aniNameA1.Items.AddRange(new object[] { "battle dialogue", "psychopath message", "battle message" });
                    aniNameA1.Enabled = true;
                    aniNumA2.Enabled = true;
                    aniNameA1.SelectedIndex = command.Param1 & 3;
                    aniNumA2.Value = command.Param2;
                    break;
                case 0x96:
                    aniLabelA1.Text = "Message";
                    aniLabelB1.Text = "X";
                    aniLabelB2.Text = "Y";
                    foreach (var message in Dialogues.Model.BonusMessages)
                        aniNameA1.Items.Add(message.Text);
                    aniNameA1.Enabled = true;
                    aniNumB1.Enabled = true;
                    aniNumB2.Enabled = true;
                    aniNumB1.Maximum = 127; aniNumB1.Minimum = -128;
                    aniNumB2.Maximum = 127; aniNumB2.Minimum = -128;
                    aniNameA1.SelectedIndex = command.Param2;
                    aniNumB1.Value = (sbyte)command.Data[3];
                    aniNumB2.Value = (sbyte)command.Param4;
                    break;
                case 0x7E:
                    aniLabelB1.Text = "Duration";
                    aniNumB1.Enabled = true;
                    aniNumB1.Value = command.Param1;
                    break;
                case 0x80:
                    aniLabelA1.Text = "Type";
                    aniLabelB1.Text = "Color count";
                    aniLabelB2.Text = "Starting color index";
                    aniLabelC1.Text = "Glow duration";
                    //
                    aniNameA1.Enabled = true;
                    aniNameA1.Items.AddRange(new string[] { "eastward reflection", "westward reflection" });
                    aniNumB1.Maximum = 15; aniNumB1.Enabled = true;
                    aniNumB2.Maximum = 15; aniNumB2.Enabled = true;
                    aniNumC1.Enabled = true;
                    //
                    aniNameA1.SelectedIndex = command.Param1 & 0x01;
                    aniNumB1.Value = command.Param2 & 0x0F;
                    aniNumB2.Value = command.Param2 >> 4;
                    aniNumC1.Value = command.Param3;
                    break;
                case 0x85:
                    aniLabelA1.Text = "Type";
                    aniLabelA2.Text = "Object";
                    aniLabelB1.Text = "Duration";
                    aniNameA1.Items.AddRange(new object[] { "fade out", "fade in" }); aniNameA1.Enabled = true;
                    aniNameA2.Items.AddRange(new object[] { "effect", "sprite", "screen" }); aniNameA2.Enabled = true;
                    aniNumB1.Enabled = true;
                    aniNameA1.SelectedIndex = (command.Param1 & 0x0F) >> 1;
                    aniNameA2.SelectedIndex = command.Param1 >> 4;
                    aniNumB1.Value = command.Param2;
                    break;
                case 0x86:
                    aniLabelA1.Text = "Object";
                    aniLabelB1.Text = "Amount";
                    aniLabelB2.Text = "Speed";
                    aniNameA1.Enabled = true;
                    aniNameA1.Items.AddRange(new string[] { "none", "screen", "sprites", "...", "all" });
                    aniNumB1.Enabled = true;
                    aniNumB2.Enabled = true; aniNumB2.Maximum = 256;
                    //
                    aniNameA1.SelectedIndex = command.Param1;
                    aniNumB1.Value = command.Param4;
                    aniNumB2.Value = Bits.GetShort(command.Data, 5);
                    break;
                case 0x8E:
                case 0x8F:
                    aniLabelA1.Text = "Color";
                    aniLabelB1.Text = "Duration";
                    aniNameA1.Items.AddRange(new object[] { 
                        "{none}", "red", "green", "yellow", "blue", "pink", "aqua", "white" });
                    aniNameA1.Enabled = true;
                    aniNameA1.SelectedIndex = command.Param1 & 0x07;
                    if (command.Opcode == 0x8E)
                    {
                        aniNumB1.Enabled = true;
                        aniNumB1.Value = command.Param2;
                    }
                    break;
                case 0xA3:
                    aniLabelA1.Text = "Effect";
                    aniNameA1.Items.AddRange(Parser.ScreenEffects);
                    aniNameA1.Enabled = true;
                    //
                    aniNameA1.SelectedIndex = command.Param1;
                    break;
                case 0xAB:
                case 0xAE:
                    aniLabelA1.Text = "Sound";
                    aniNameA1.Items.AddRange(Lists.Numerize(Lists.SPCBattleSounds));
                    aniNameA1.Enabled = true; aniNameA1.DropDownWidth = 250;
                    aniNameA1.SelectedIndex = command.Param1;
                    break;
                case 0xB0:
                    aniLabelA1.Text = "Music";
                    aniNameA1.Items.AddRange(Lists.Numerize(Lists.SPCTracks));
                    aniNameA1.Enabled = true;
                    aniNameA1.SelectedIndex = command.Param1;
                    break;
                case 0xB1:
                    aniLabelA1.Text = "Music";
                    aniNameA1.Items.AddRange(Lists.Numerize(Lists.SPCTracks));
                    aniNameA1.Enabled = true; aniNameA1.DropDownWidth = 250;
                    aniNumB1.Enabled = true; aniNumB1.Maximum = 0xFFFF;
                    aniNameA1.SelectedIndex = command.Param1;
                    aniNumB1.Value = Bits.GetShort(command.Data, 2);
                    break;
                case 0xB6:
                    aniLabelB1.Text = "Speed";
                    aniLabelB2.Text = "Volume";
                    aniNumB1.Enabled = true;
                    aniNumB2.Enabled = true;
                    aniNumB1.Value = command.Param1;
                    aniNumB2.Value = command.Param2;
                    break;
                case 0xBB:
                    aniLabelA1.Text = "Target";
                    aniNameA1.Items.AddRange(Lists.Targets);
                    aniNameA1.Enabled = true; aniNameA1.DropDownWidth = 200;
                    aniNameA1.SelectedIndex = command.Param1;
                    break;
                case 0xBC:
                case 0xBD:
                    aniLabelA1.Text = "Item";
                    aniNameA1.Items.AddRange(Items.Model.Names.Names);
                    aniNameA1.Enabled = true;
                    aniNameA1.BackColor = SystemColors.ControlDarkDark;
                    aniNameA1.DrawMode = DrawMode.OwnerDrawFixed;
                    aniNameA1.ItemHeight = 15;
                    aniNumA1.Maximum = 0xB0; aniNumA1.Enabled = true;
                    aniBits.Items.Add("remove"); aniBits.Enabled = true;
                    aniNameA1.SelectedIndex = Items.Model.Names.GetSortedIndex(
                        Math.Abs((short)Bits.GetShort(command.Data, 1)));
                    aniNumA1.Value = Math.Abs((short)Bits.GetShort(command.Data, 1));
                    aniBits.SetItemChecked(0, command.Param2 == 0xFF);
                    break;
                case 0xBE:
                    aniLabelB1.Text = "Value";
                    aniNumB1.Maximum = 0xFFFF; aniNumB1.Enabled = true;
                    aniNumB1.Value = Bits.GetShort(command.Data, 1);
                    break;
                case 0xBF:
                    aniLabelA1.Text = "Target";
                    aniNameA1.Items.AddRange(Lists.Targets);
                    aniNameA1.Enabled = true; aniNameA1.DropDownWidth = 200;
                    aniNameA1.SelectedIndex = command.Param1;
                    break;
                case 0xC3:
                    aniLabelA1.Text = "Mask";
                    aniNameA1.Items.AddRange(new string[] { 
                        "...", "incline", "incline", "circle", "dome", 
                        "polygon", "wavy circle", "cylinder" });
                    aniNameA1.Enabled = true;
                    aniNameA1.SelectedIndex = command.Param1;
                    break;
                case 0xCB:
                    aniLabelB1.Text = "Speed";
                    aniNumB1.Maximum = 15; aniNumB1.Enabled = true;
                    aniNumB1.Value = command.Param1;
                    break;
                case 0xE1:
                    aniLabelB1.Text = "Event #";
                    aniLabelB2.Text = "Offset";
                    aniNumB1.Maximum = 0xFFFF;
                    aniNumB1.Enabled = true;
                    aniNumB2.Enabled = true;
                    aniNumB1.Value = Bits.GetShort(command.Data, 1);
                    aniNumB2.Value = command.Param2;
                    break;
            }
            ArrangeControls();
            commands.SelectedIndex = -1;
            //
            panelCommand.ResumeDrawing();
            //
            this.Updating = false;
        }
        /// <summary>
        /// Writes the values of the controls to the command's data.
        /// </summary>
        /// <param name="command"></param>
        private void WriteToCommand(Command command)
        {
            switch (command.Opcode)
            {
                case 0x00:
                    Bits.SetShort(command.Data, 3, (ushort)aniNumA1.Value);
                    command.Param5 = (byte)aniNumA2.Value;
                    command.Param6 = (byte)((byte)aniNumB1.Value << 4);
                    Bits.SetShort(command.Data, 7, (ushort)aniNumB2.Value);
                    Bits.SetBit(command.Data, 1, 0, aniBits.GetItemChecked(0));
                    Bits.SetBit(command.Data, 2, 3, aniBits.GetItemChecked(1));
                    Bits.SetBit(command.Data, 2, 5, aniBits.GetItemChecked(2));
                    Bits.SetBit(command.Data, 6, 3, aniBits.GetItemChecked(3));
                    Bits.SetBit(command.Data, 6, 6, aniBits.GetItemChecked(4));
                    Bits.SetBit(command.Data, 6, 7, aniBits.GetItemChecked(5));
                    break;
                case 0x01:
                case 0x0B:
                    command.Param1 = (byte)(aniNameA1.SelectedIndex << 4);
                    Bits.SetBit(command.Data, 1, 0, aniBits.GetItemChecked(0));
                    Bits.SetBit(command.Data, 1, 1, aniBits.GetItemChecked(1));
                    Bits.SetBit(command.Data, 1, 2, aniBits.GetItemChecked(2));
                    Bits.SetShort(command.Data, 2, (ushort)((short)aniNumB1.Value));
                    Bits.SetShort(command.Data, 4, (ushort)((short)aniNumB2.Value));
                    Bits.SetShort(command.Data, 6, (ushort)((short)aniNumC1.Value));
                    break;
                case 0x03:
                    Bits.SetShort(command.Data, 3, (ushort)aniNumA1.Value);
                    command.Param5 = (byte)aniNumB1.Value;
                    Bits.SetBit(command.Data, 1, 0, aniBits.GetItemChecked(0));
                    Bits.SetBit(command.Data, 2, 3, aniBits.GetItemChecked(1));
                    Bits.SetBit(command.Data, 2, 5, aniBits.GetItemChecked(2));
                    break;
                case 0x04:
                    command.Param1 = (byte)aniNameA1.SelectedIndex;
                    Bits.SetShort(command.Data, 2, (ushort)aniNumA2.Value);
                    break;
                case 0x08:
                    Bits.SetBit(command.Data, 1, 0, aniBits.GetItemChecked(0));
                    Bits.SetBit(command.Data, 1, 1, aniBits.GetItemChecked(1));
                    Bits.SetBit(command.Data, 1, 2, aniBits.GetItemChecked(2));
                    Bits.SetBit(command.Data, 1, 5, aniBits.GetItemChecked(3));
                    Bits.SetBit(command.Data, 1, 6, aniBits.GetItemChecked(4));
                    Bits.SetBit(command.Data, 1, 7, aniBits.GetItemChecked(5));
                    Bits.SetShort(command.Data, 2, (ushort)((short)aniNumB1.Value));
                    Bits.SetShort(command.Data, 4, (ushort)((short)aniNumB2.Value));
                    Bits.SetShort(command.Data, 6, (ushort)((short)aniNumA2.Value));
                    break;
                case 0x09:
                case 0x10:
                case 0x50:
                case 0x51:
                case 0x64:
                    Bits.SetShort(command.Data, 1, (ushort)aniNumB1.Value);
                    break;
                case 0x0C:
                    command.Param1 = (byte)(aniNameA1.SelectedIndex * 2);
                    Bits.SetShort(command.Data, 2, (ushort)((short)aniNumB1.Value));
                    Bits.SetShort(command.Data, 4, (ushort)((short)aniNumB2.Value));
                    break;
                case 0x20:
                case 0x21:
                case 0x22:
                case 0x23:
                case 0x2C:
                case 0x2D:
                case 0x2E:
                case 0x2F:
                    command.Param1 = (byte)(aniNumB1.Value - 0x60);
                    command.Param1 |= (byte)(aniNameA1.SelectedIndex << 4);
                    switch (command.Param1 >> 4)
                    {
                        case 0:
                        case 4:
                        case 6:
                            Bits.SetShort(command.Data, 2, (ushort)aniNumB2.Value);
                            break;
                        case 1:
                        case 5:
                            Bits.SetShort(command.Data, 2, (ushort)(aniNumB2.Value - 0x7E0000));
                            break;
                        case 2:
                            Bits.SetShort(command.Data, 2, (ushort)(aniNumB2.Value - 0x7F0000));
                            break;
                        case 3:
                            Bits.SetShort(command.Data, 2, (ushort)(aniNumB2.Value - 0x60));
                            break;
                    }
                    break;
                case 0x24:
                case 0x25:
                case 0x26:
                case 0x27:
                case 0x28:
                case 0x29:
                case 0x2A:
                case 0x2B:
                    command.Param1 = (byte)(aniNumA2.Value - 0x60);
                    command.Param1 |= (byte)(aniNameA1.SelectedIndex << 4);
                    switch (command.Param1 >> 4)
                    {
                        case 0:
                        case 4:
                        case 6:
                            Bits.SetShort(command.Data, 2, (ushort)aniNumB1.Value);
                            break;
                        case 1:
                        case 5:
                            Bits.SetShort(command.Data, 2, (ushort)(aniNumB1.Value - 0x7E0000));
                            break;
                        case 2:
                            Bits.SetShort(command.Data, 2, (ushort)(aniNumB1.Value - 0x7F0000));
                            break;
                        case 3:
                            Bits.SetShort(command.Data, 2, (ushort)(aniNumB1.Value - 0x60));
                            break;
                    }
                    Bits.SetShort(command.Data, 4, (ushort)aniNumB2.Value);
                    break;
                case 0x30:
                case 0x31:
                case 0x32:
                case 0x33:
                case 0x34:
                case 0x35:
                    command.Param1 = (byte)(aniNumB1.Value - 0x60);
                    break;
                case 0x7E:
                    command.Param1 = (byte)aniNumB1.Value; break;
                case 0x36:
                case 0x37:
                    command.Param1 = (byte)(aniNumB1.Value - 0x60);
                    for (int i = 1, j = 0; j < 8; i *= 2, j++)
                        Bits.SetBit(command.Data, 2, j, aniBits.GetItemChecked(j));
                    break;
                case 0x38:
                case 0x39:
                    command.Param1 = (byte)(aniNumB1.Value - 0x60);
                    for (int i = 1, j = 0; j < 8; i *= 2, j++)
                        Bits.SetBit(command.Data, 2, j, aniBits.GetItemChecked(j));
                    Bits.SetShort(command.Data, 3, (ushort)aniNumC1.Value);
                    break;
                case 0x40:
                case 0x41:
                    command.Param1 = (byte)(aniNumB1.Value - 0x60);
                    for (int i = 1, j = 0; j < 8; i *= 2, j++)
                        Bits.SetBit(command.Data, 2, j, aniBits.GetItemChecked(j));
                    break;
                case 0x43:
                    command.Param1 = (byte)aniNumB1.Value;
                    for (int i = 0, j = 0; j < 4; i++, j++)
                        Bits.SetBit(command.Data, 1, j + 4, aniBits.GetItemChecked(j));
                    break;
                case 0x5D:
                    for (int i = 1, j = 0; j < 8; i *= 2, j++)
                        Bits.SetBit(command.Data, 1, j, aniBits.GetItemChecked(j));
                    command.Param2 = (byte)aniNumB1.Value;
                    Bits.SetShort(command.Data, 3, (ushort)aniNumB2.Value);
                    break;
                case 0x63:
                    command.Param1 = (byte)aniNameA1.SelectedIndex;
                    break;
                case 0x68:
                    Bits.SetShort(command.Data, 1, (ushort)aniNumB1.Value);
                    command.Data[3] = (byte)aniNumB2.Value;
                    break;
                case 0x6A:
                case 0x6B:
                    command.Param1 = (byte)(aniNumB1.Value - 0x60);
                    if (command.Opcode == 0x6B)
                        Bits.SetShort(command.Data, 2, (ushort)aniNumB2.Value);
                    else
                        command.Param2 = (byte)aniNumB2.Value;
                    break;
                case 0x72:
                    command.Param2 = (byte)aniNameA1.SelectedIndex;
                    for (int i = 1, j = 0; j < 4; i *= 2, j++)
                        Bits.SetBit(command.Data, 1, j, aniBits.GetItemChecked(j));
                    break;
                case 0x74:
                    switch (aniNameA1.SelectedIndex)
                    {
                        case 0:
                            Bits.SetShort(command.Data, 1, 0x0004); break;
                        case 1:
                            Bits.SetShort(command.Data, 1, 0x0008); break;
                        case 2:
                            Bits.SetShort(command.Data, 1, 0x0200); break;
                        case 3:
                            Bits.SetShort(command.Data, 1, 0x0400); break;
                        case 4:
                            Bits.SetShort(command.Data, 1, 0x0800); break;
                        default:
                            break;
                    }
                    break;
                case 0x75:
                    Bits.SetShort(command.Data, 1, (ushort)aniNumB1.Value);
                    break;
                case 0x77:
                case 0x78:
                    command.Param1 = (byte)(aniNameA1.SelectedIndex << 4);
                    for (int i = 1, j = 0; j < 4; i *= 2, j++)
                        Bits.SetBit(command.Data, 1, j, aniBits.GetItemChecked(j));
                    break;
                case 0x7A:
                    command.Param1 = (byte)aniNameA1.SelectedIndex;
                    command.Param2 = (byte)aniNumA2.Value;
                    break;
                case 0x80:
                    command.Param1 = (byte)aniNameA1.SelectedIndex;
                    command.Param2 = (byte)aniNumB1.Value;
                    command.Param2 |= (byte)((byte)aniNumB2.Value << 4);
                    command.Param3 = (byte)aniNumC1.Value;
                    break;
                case 0x96:
                    command.Param2 = (byte)aniNameA1.SelectedIndex;
                    command.Data[3] = (byte)((sbyte)aniNumB1.Value);
                    command.Param4 = (byte)((sbyte)aniNumB2.Value);
                    break;
                case 0x85:
                    command.Param1 = (byte)(aniNameA1.SelectedIndex << 1);
                    command.Param1 |= (byte)(aniNameA2.SelectedIndex << 4);
                    command.Param2 = (byte)aniNumB1.Value;
                    break;
                case 0x86:
                    command.Param1 = (byte)aniNameA1.SelectedIndex;
                    command.Param4 = (byte)aniNumB1.Value;
                    Bits.SetShort(command.Data, 5, (ushort)aniNumB2.Value);
                    break;
                case 0x8E:
                    command.Param1 = (byte)aniNameA1.SelectedIndex;
                    command.Param2 = (byte)aniNumB1.Value;
                    break;
                case 0xA3:
                    command.Param1 = (byte)aniNameA1.SelectedIndex;
                    break;
                case 0xAB:
                case 0xAE:
                    command.Param1 = (byte)aniNameA1.SelectedIndex;
                    break;
                case 0xB0:
                    command.Param1 = (byte)aniNameA1.SelectedIndex;
                    break;
                case 0xB1:
                    command.Param1 = (byte)aniNameA1.SelectedIndex;
                    Bits.SetShort(command.Data, 2, (ushort)aniNumB1.Value);
                    break;
                case 0xB6:
                    command.Param1 = (byte)aniNumB1.Value;
                    command.Param2 = (byte)aniNumB2.Value;
                    break;
                case 0xBB:
                case 0xBF:
                    command.Param1 = (byte)aniNameA1.SelectedIndex;
                    break;
                case 0xBC:
                case 0xBD:
                    short temp = (short)(-(ushort)aniNumA1.Value);
                    if (aniBits.GetItemChecked(0))
                        Bits.SetShort(command.Data, 1, (ushort)temp);
                    else
                        Bits.SetShort(command.Data, 1, (ushort)aniNumA1.Value);
                    break;
                case 0xBE:
                    Bits.SetShort(command.Data, 1, (ushort)aniNumB1.Value);
                    break;
                case 0xC3:
                    command.Param1 = (byte)aniNameA1.SelectedIndex;
                    break;
                case 0xCB:
                    command.Param1 = (byte)aniNumB1.Value;
                    break;
                case 0xE1:
                    Bits.SetShort(command.Data, 1, (ushort)aniNumB1.Value);
                    command.Data[3] = (byte)aniNumB2.Value;
                    break;
            }
        }

        /// <summary>
        /// Resets the values of all controls linked to the command's properties.
        /// </summary>
        private void ResetControls()
        {
            this.Updating = true;
            //
            aniNameA1.DrawMode = DrawMode.Normal; aniNameA1.ItemHeight = 13; aniNameA1.BackColor = SystemColors.Window;
            aniNameA1.Items.Clear(); aniNameA1.ResetText(); aniNameA1.Enabled = false; aniNameA1.DropDownWidth = aniNameA1.Width;
            aniNameA2.Items.Clear(); aniNameA2.ResetText(); aniNameA2.Enabled = false; aniNameA2.DropDownWidth = aniNameA2.Width;
            aniNumA1.Maximum = 255; aniNumA1.Hexadecimal = false; aniNumA1.Minimum = 0; aniNumA1.Value = 0; aniNumA1.Enabled = false;
            aniNumA2.Maximum = 255; aniNumA2.Hexadecimal = false; aniNumA2.Minimum = 0; aniNumA2.Value = 0; aniNumA2.Enabled = false;
            aniNumB1.Maximum = 255; aniNumB1.Hexadecimal = false; aniNumB1.Minimum = 0; aniNumB1.Increment = 1; aniNumB1.Value = 0; aniNumB1.Enabled = false;
            aniNumB2.Maximum = 255; aniNumB2.Hexadecimal = false; aniNumB2.Minimum = 0; aniNumB2.Increment = 1; aniNumB2.Value = 0; aniNumB2.Enabled = false;
            aniNumC1.Maximum = 255; aniNumC1.Hexadecimal = false; aniNumC1.Value = 0; aniNumC1.Enabled = false;
            aniNumC2.Maximum = 255; aniNumC2.Value = 0; aniNumC2.Enabled = false;
            aniBits.ColumnWidth = 134; aniBits.Items.Clear(); aniBits.Enabled = false;
            aniTitleA.Text = "";
            aniTitleB.Text = "";
            aniTitleC.Text = "";
            aniTitleD.Text = "";
            aniLabelA1.Text = "";
            aniLabelA2.Text = "";
            aniLabelB1.Text = "";
            aniLabelB2.Text = "";
            aniLabelC1.Text = "";
            aniLabelC2.Text = "";
            // Finished
            this.Updating = false;
        }
        /// <summary>
        /// Arranges and organizes the controls in the proper order according to the
        /// available options in the current command's properties.
        /// </summary>
        private void ArrangeControls()
        {
            this.Updating = true;
            //
            aniTitleA.Visible = aniTitleA.Enabled =
                aniTitleA.Text != "" ||
                aniLabelA1.Text != "" ||
                aniLabelA2.Text != "";
            aniTitleB.Visible = aniTitleB.Enabled =
                aniTitleB.Text != "" ||
                aniLabelB1.Text != "" ||
                aniLabelB2.Text != "";
            aniTitleC.Visible = aniTitleC.Enabled =
                aniTitleC.Text != "" ||
                aniLabelC1.Text != "" ||
                aniLabelC2.Text != "";
            aniTitleD.Visible = aniTitleD.Enabled =
                aniTitleD.Text != "" ||
                aniBits.Items.Count > 0;
            aniPanelA1.Visible = aniNumA1.Enabled || aniNameA1.Enabled;
            aniPanelA2.Visible = aniNumA2.Enabled || aniNameA2.Enabled;
            aniPanelB1.Visible = aniNumB1.Enabled;
            aniPanelB2.Visible = aniNumB2.Enabled;
            aniPanelC1.Visible = aniNumC1.Enabled;
            aniPanelC2.Visible = aniNumC2.Enabled;
            aniNameA1.Visible = aniNameA1.Enabled;
            aniNameA2.Visible = aniNameA2.Enabled;
            aniNumA1.Visible = aniNumA1.Enabled;
            aniNumA2.Visible = aniNumA2.Enabled;
            if (aniBits.Items.Count < 8)
                aniBits.Height = aniBits.Items.Count * 16 + 4;
            else
                aniBits.Height = 8 * 16 + 4;
            //
            aniTitleA.BringToFront();
            aniTitleB.BringToFront();
            aniTitleC.BringToFront();
            aniTitleD.BringToFront();
            panel1.BringToFront();
            aniPanelA1.BringToFront();
            aniPanelA2.BringToFront();
            aniPanelB1.BringToFront();
            aniPanelB2.BringToFront();
            aniPanelC1.BringToFront();
            aniPanelC2.BringToFront();
            aniLabelA1.BringToFront();
            aniNameA1.BringToFront();
            aniNumA1.BringToFront();
            aniLabelA2.BringToFront();
            aniNameA2.BringToFront();
            aniNumA2.BringToFront();
            //
            if (aniTitleA.Enabled)
                aniTitleA.Text = Lists.AnimationCommands[command.Opcode];
            else if (aniTitleB.Enabled)
                aniTitleB.Text = Lists.AnimationCommands[command.Opcode];
            else if (aniTitleC.Enabled)
                aniTitleC.Text = Lists.AnimationCommands[command.Opcode];
            else if (aniTitleD.Enabled)
                aniTitleD.Text = Lists.AnimationCommands[command.Opcode];
            //
            this.Height = panelCommand.Bottom + panelCommand.Margin.Bottom + this.TitleHeight;
            // Finished
            this.Updating = false;
        }
        /// <summary>
        /// Creates a new command from the selected index in the commands list 
        /// and sets the value of this.newCommand to the result.
        /// </summary>
        private void CreateNewCommand()
        {
            this.newCommand = this.command.Copy();
            byte opcode = (byte)commands.SelectedIndex;
            int length = ScriptEnums.GetCommandLength(opcode, 0);
            newCommand.Data = new byte[length];
            Bits.Fill(newCommand.Data, 0x0A);
            newCommand.Opcode = opcode;
            for (int i = 1; i < newCommand.Length; i++)
                newCommand.Data[i] = 0;
        }

        #endregion

        #region Event Handlers

        // Select command
        private void commands_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            if (commands.SelectedIndex == -1)
                return;

            // Starting
            this.Updating = true;

            // If no command loaded, cancel operation
            if (command == null)
            {
                MessageBox.Show("Must select a command in the tree to change.");
                commands.SelectedIndex = -1;
                return;
            }

            // Get total available space to replace w/new command
            int needed = ScriptEnums.GetCommandLength(commands.SelectedIndex, 0);
            if (needed > command.AvailableSpace(needed, false))
            {
                MessageBox.Show("Not enough space to replace the selected command(s) with the new command.\n\n" +
                    "Try selecting a smaller command from the list or selecting an earlier command within the routine in the tree.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                commands.SelectedIndex = -1;
                return;
            }

            // Create and load new command
            CreateNewCommand();
            ReadFromCommand(this.newCommand);

            // Finished
            this.Updating = false;
        }

        // Properties
        private void aniNameA1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            switch (command.Opcode)
            {
                case 0x00:
                case 0x03:
                    aniNumA1.Value = aniNameA1.SelectedIndex;
                    break;
                case 0x20:
                case 0x21:
                case 0x22:
                case 0x23:
                case 0x2C:
                case 0x2D:
                case 0x2E:
                case 0x2F:
                    aniNumB2.Hexadecimal = aniNameA1.SelectedIndex != 0;
                    switch (aniNameA1.SelectedIndex)
                    {
                        case 0:
                            aniNumB2.Minimum = 0;
                            aniNumB2.Maximum = 0xFFFF;
                            break;
                        case 1:
                        case 5:
                            aniNumB2.Maximum = 0x7EFFFF;
                            aniNumB2.Minimum = 0x7E0000;
                            break;
                        case 2:
                            aniNumB2.Maximum = 0x7FFFFF;
                            aniNumB2.Minimum = 0x7F0000;
                            break;
                        case 3:
                            aniNumB2.Minimum = 0x60;
                            aniNumB2.Maximum = 0x6F;
                            break;
                        case 4:
                        case 6:
                            aniNumB2.Minimum = 0;
                            aniNumB2.Maximum = 0xFF;
                            break;
                    }
                    break;
                case 0x24:
                case 0x25:
                case 0x26:
                case 0x27:
                case 0x28:
                case 0x29:
                case 0x2A:
                case 0x2B:
                    aniNumB1.Hexadecimal = aniNameA1.SelectedIndex != 0;
                    switch (aniNameA1.SelectedIndex)
                    {
                        case 0:
                            aniNumB1.Minimum = 0;
                            aniNumB1.Maximum = 0xFFFF;
                            break;
                        case 1:
                        case 5:
                            aniNumB1.Maximum = 0x7EFFFF;
                            aniNumB1.Minimum = 0x7E0000;
                            break;
                        case 2:
                            aniNumB1.Maximum = 0x7FFFFF;
                            aniNumB1.Minimum = 0x7F0000;
                            break;
                        case 3:
                            aniNumB1.Minimum = 0x60;
                            aniNumB1.Maximum = 0x6F;
                            break;
                        case 4:
                        case 6:
                            aniNumB1.Minimum = 0;
                            aniNumB1.Maximum = 0xFF;
                            break;
                    }
                    break;
                case 0xBC:
                case 0xBD:
                    aniNumA1.Value = Items.Model.Names.GetUnsortedIndex(aniNameA1.SelectedIndex);
                    break;
            }
        }
        private void aniNameA1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;
            Do.DrawName(sender, e, new BattleDialoguePreview(), Items.Model.Names, Fonts.Model.Menu,
                Fonts.Model.Palette_Menu.Palettes[0], 8, 10, 0, 128, true, false, Menus.Model.MenuBG_256x255);
        }
        private void aniNumA1_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            Command asc = newCommand != null ? newCommand : this.command;
            switch (asc.Opcode)
            {
                case 0x00:
                case 0x03:
                    aniNameA1.SelectedIndex = (int)aniNumA1.Value;
                    break;
                case 0xBC:
                case 0xBD:
                    aniNameA1.SelectedIndex = Items.Model.Names.GetSortedIndex((int)aniNumA1.Value);
                    break;
            }
        }

        // Results
        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            // if inserting a new command into the collection
            if (this.newCommand != null)
            {
                // number of bytes to replace and/or wipe clean w/0x0A's
                int available = this.command.AvailableSpace(this.newCommand.Length, false);
                if (this.newCommand.Length > available)
                {
                    MessageBox.Show("Not enough space to replace the selected command(s) with the new command.\n\n" +
                        "Try selecting a smaller command from the list or selecting an earlier command within the routine in the tree.",
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                int lastNeeded = this.command.AvailableSpace(this.newCommand.Length, true); // the last command index needed for space
                if (MessageBox.Show("CAUTION: you are about to replace the selected command in the tree and the following " +
                    (lastNeeded - this.command.Index) + " commands.\n\n" + "Continue?",
                    "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                // set the value of the loaded command to the new one
                WriteToCommand(this.newCommand);
                this.Tag = this.newCommand;
            }
            else
            {
                WriteToCommand(this.command);
                this.Tag = this.command;
            }
            this.Close();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion
    }
}
