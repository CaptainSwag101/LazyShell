using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.ScriptsEditor;
using LAZYSHELL.ScriptsEditor.Commands;

namespace LAZYSHELL
{
    public partial class EventScripts : Form
    {
        private ActionQueue[] actionScripts { get { return Model.ActionScripts; } set { Model.ActionScripts = value; } }
        public ActionQueue[] ActionScripts { get { return actionScripts; } set { actionScripts = value; } }
        private ActionQueue actionScript { get { return actionScripts[index]; } set { actionScripts[index] = value; } }

        private void ControlActionDisasmMethod()
        {
            updatingControls = false;

            switch (aqc.Opcode)
            {
                // Properties
                case 0x0A:
                    labelTitleA.Text = "Solidity properties = ...";
                    labelEvtC.Text = "value";
                    evtNumC.Enabled = true;

                    evtNumC.Value = aqc.Option;
                    break;
                case 0x0B: labelTitleA.Text = "Solidity properties, set bits..."; goto case 0x0C;
                case 0x15: labelTitleA.Text = "Movement properties |=..."; goto case 0x0C;
                case 0x0C:
                    if (aqc.Opcode == 0x0C) labelTitleA.Text = "Solidity properties, clear bits...";
                    labelTitleB.Text = "bits...";
                    evtEffects.Items.AddRange(new string[] 
                        { 
                            "bit 0", "can't walk under", "can't pass walls", "can't jump through", 
                            "bit 4", "can't pass NPCs", "can't walk through", "bit 7", 
                        });
                    evtEffects.Enabled = true;

                    for (int i = 1, j = 0; j < 8; i *= 2, j++)
                        evtEffects.SetItemChecked(j, (aqc.Option & i) == i);
                    break;
                case 0x13:
                    labelTitleA.Text = "Sprite priority, set...";
                    labelEvtC.Text = "priority";
                    evtNumC.Maximum = 3; evtNumC.Enabled = true;

                    evtNumC.Value = aqc.Option;
                    break;
                case 0x3D:
                    labelTitleA.Text = "If in air, jump to...";
                    labelEvtC.Text = "address";
                    evtNumC.Hexadecimal = true; evtNumC.Maximum = 0xFFFF; evtNumC.Enabled = true;

                    evtNumC.Value = Bits.GetShort(aqc.EventData, 1);
                    break;

                // Palette
                case 0x0D: labelTitleA.Text = "Palette index, set =..."; evtNumC.Maximum = 15; goto case 0x0E;
                case 0x0E:
                    if (aqc.Opcode == 0x0E) labelTitleA.Text = "Palette index, shift =...";
                    labelEvtC.Text = "value";
                    evtNumC.Enabled = true;

                    evtNumC.Value = aqc.Option;
                    break;

                // Sprite Sequence
                case 0x08:
                    labelTitleA.Text = "Sequence playback, sprite +=...";
                    labelEvtC.Text = "object +=";
                    labelTitleB.Text = "properties";
                    evtNumC.Maximum = 7; evtNumC.Enabled = true;
                    evtNumD.Maximum = 127; evtNumD.Enabled = true;
                    evtEffects.Items.AddRange(new string[]
                    {
                        "read from mold",
                        "playback only once",
                        "bit 6",
                        "mirror sprite"
                    });
                    evtEffects.Enabled = true;

                    evtNumC.Value = aqc.Option & 0x07;
                    evtNumD.Value = aqc.EventData[2] & 0x7F;
                    evtEffects.SetItemChecked(0, (aqc.Option & 0x08) == 0x08);
                    evtEffects.SetItemChecked(1, (aqc.Option & 0x10) == 0x10);
                    evtEffects.SetItemChecked(2, (aqc.Option & 0x40) == 0x40);
                    evtEffects.SetItemChecked(3, (aqc.EventData[2] & 0x80) == 0x80);

                    if (evtEffects.GetItemChecked(0)) labelEvtD.Text = "mold";
                    else labelEvtD.Text = "sequence";

                    /*
                     * TODO
                     * set labelEvtD.text based on bit 3 of byte 2
                     * if set, make "frame", else "sequence"
                     */
                    break;
                case 0x10:
                    labelTitleA.Text = "Playback, set speed = ...";
                    labelEvtA.Text = "speed change";
                    labelTitleB.Text = "flags";
                    evtNameA.Items.AddRange(new string[]
                    {
                        "normal",
                        "speed up x2","speed up x2.5",
                        "speed up x4", "speed up x8",
                        "speed down x2", "speed down x4"
                    });
                    evtNameA.Enabled = true;
                    evtEffects.Items.AddRange(new string[] { "shift", "sequence" });
                    evtEffects.Enabled = true;

                    evtNameA.SelectedIndex = aqc.Option & 0x0F;
                    evtEffects.SetItemChecked(0, (aqc.Option & 0x40) == 0x40);
                    evtEffects.SetItemChecked(1, (aqc.Option & 0x80) == 0x80);
                    break;
                case 0xD0:
                    labelTitleA.Text = "Set action script =...";
                    labelEvtC.Text = "action #";
                    evtNumC.Maximum = 0x3FF; evtNumC.Enabled = true;

                    evtNumC.Value = Bits.GetShort(aqc.EventData, 1) & 0x3FF;
                    break;

                // Sprite Animation


                // Shift isometric units
                case 0x50: labelTitleA.Text = "Shift east, isometric units =..."; goto case 0x5B;
                case 0x51: labelTitleA.Text = "Shift southeast, isometric units =..."; goto case 0x5B;
                case 0x52: labelTitleA.Text = "Shift south, isometric units =..."; goto case 0x5B;
                case 0x53: labelTitleA.Text = "Shift southwest, isometric units =..."; goto case 0x5B;
                case 0x54: labelTitleA.Text = "Shift west, isometric units =..."; goto case 0x5B;
                case 0x55: labelTitleA.Text = "Shift northwest, isometric units =..."; goto case 0x5B;
                case 0x56: labelTitleA.Text = "Shift north, isometric units =..."; goto case 0x5B;
                case 0x57: labelTitleA.Text = "Shift northeast, isometric units =..."; goto case 0x5B;
                case 0x58: labelTitleA.Text = "Shift in facing direction, isometric units =..."; goto case 0x5B;
                case 0x5A: labelTitleA.Text = "Elevate up, isometric units =..."; goto case 0x5B;
                case 0x5B:
                    if (aqc.Opcode == 0x5B) labelTitleA.Text = "Elevate down, isometric units =...";
                    labelEvtC.Text = "amount";
                    evtNumC.Enabled = true;

                    evtNumC.Value = aqc.Option;
                    break;
                case 0x7E: labelTitleA.Text = "Jump, isometric units =..."; goto case 0x7F;
                case 0x7F:
                    if (aqc.Opcode == 0x7F) labelTitleA.Text = "Jump, 1px units =...";
                    labelEvtC.Text = "amount";
                    evtNumC.Maximum = 65535; evtNumC.Enabled = true;

                    evtNumC.Value = Bits.GetShort(aqc.EventData, 1);
                    break;

                // Shift 1px units
                case 0x60: labelTitleA.Text = "Shift east, pixels =..."; goto case 0x6B;
                case 0x61: labelTitleA.Text = "Shift southeast, pixels =..."; goto case 0x6B;
                case 0x62: labelTitleA.Text = "Shift south, pixels =..."; goto case 0x6B;
                case 0x63: labelTitleA.Text = "Shift southwest, pixels =..."; goto case 0x6B;
                case 0x64: labelTitleA.Text = "Shift west, pixels =..."; goto case 0x6B;
                case 0x65: labelTitleA.Text = "Shift northwest, pixels =..."; goto case 0x6B;
                case 0x66: labelTitleA.Text = "Shift north, pixels =..."; goto case 0x6B;
                case 0x67: labelTitleA.Text = "Shift northeast, pixels =..."; goto case 0x6B;
                case 0x68: labelTitleA.Text = "Shift in facing direction, pixels =..."; goto case 0x6B;
                case 0x6A: labelTitleA.Text = "Elevate up, pixels =..."; goto case 0x6B;
                case 0x6B:
                    if (aqc.Opcode == 0x6B) labelTitleA.Text = "Elevate down, pixels =...";
                    labelEvtC.Text = "amount";
                    evtNumC.Enabled = true;

                    evtNumC.Value = aqc.Option;
                    break;

                // Face direction
                case 0x7B:
                    labelTitleA.Text = "Turn clockwise 45° times...";
                    labelEvtC.Text = "amount";
                    evtNumC.Enabled = true;

                    evtNumC.Value = aqc.Option;
                    break;

                // Shift to coords
                case 0x80: labelTitleA.Text = "Shift to isometric coords..."; goto case 0x84;
                case 0x81: labelTitleA.Text = "Shift isometric units..."; goto case 0x84;
                case 0x82: labelTitleA.Text = "Transfer to isometric coords..."; goto case 0x84;
                case 0x83: labelTitleA.Text = "Transfer isometric units..."; goto case 0x84;
                case 0x84:
                    if (aqc.Opcode == 0x84) labelTitleA.Text = "Transfer isometric pixels...";
                    labelEvtC.Text = "X";
                    labelEvtD.Text = "Y";
                    evtNumC.Enabled = true;
                    evtNumD.Enabled = true;
                    if (aqc.Opcode != 0x80 && aqc.Opcode != 0x82)
                    {
                        evtNumC.Minimum = evtNumD.Minimum = -128;
                        evtNumC.Maximum = evtNumD.Maximum = 127;
                    }
                    evtNumC.Value = aqc.Option;
                    evtNumD.Value = aqc.EventData[2];
                    break;
                case 0x87:
                case 0x95:
                    labelTitleA.Text = "Transfer to other object's isometric coords...";
                    labelEvtA.Text = "object";
                    evtNameA.Items.AddRange(Lists.ObjectNames); evtNameA.Enabled = true;

                    evtNameA.SelectedIndex = aqc.Option;
                    break;
                case 0x90: labelTitleA.Text = "Bounce to isometric coords..."; goto case 0x91;
                case 0x91:
                    if (aqc.Opcode == 0x91) labelTitleA.Text = "Bounce isometric units...";
                    labelEvtA.Text = "bounce arch height";
                    labelEvtC.Text = "X";
                    labelEvtD.Text = "Y";
                    evtNumA.Enabled = true;
                    evtNumC.Enabled = true;
                    evtNumD.Enabled = true;
                    if (aqc.Opcode != 0x90)
                    {
                        evtNumC.Minimum = evtNumD.Minimum = -128;
                        evtNumC.Maximum = evtNumD.Maximum = 127;
                    }

                    evtNumA.Value = aqc.EventData[3];
                    evtNumC.Value = aqc.Option;
                    evtNumD.Value = aqc.EventData[2];
                    break;
                case 0x92: labelTitleA.Text = "Transfer to isometric coords..."; goto case 0x94;
                case 0x93: labelTitleA.Text = "Transfer isometric units..."; goto case 0x94;
                case 0x94:
                    labelTitleA.Text = "Transfer isometric pixels...";
                    labelEvtB.Text = "facing / Z";
                    labelEvtC.Text = "X";
                    labelEvtD.Text = "Y";
                    evtNameB.Items.AddRange(Lists.Directions); evtNameB.Enabled = true;
                    evtNumB.Maximum = 0x31; evtNumB.Enabled = true;
                    if (aqc.Opcode != 0x92)
                    {
                        evtNumC.Minimum = evtNumD.Minimum = -128;
                        evtNumC.Maximum = evtNumD.Maximum = 127;
                    }
                    evtNumC.Enabled = true;
                    evtNumD.Enabled = true;

                    evtNameB.SelectedIndex = (aqc.EventData[3] & 0xE0) >> 5;
                    evtNumB.Value = aqc.EventData[3] & 0x1F;
                    evtNumC.Value = aqc.Option;
                    evtNumD.Value = aqc.EventData[2];
                    break;

                // Audio playback
                case 0x9C:
                    labelTitleA.Text = "Playback start, sound...";
                    labelEvtA.Text = "sound";
                    evtNameA.Items.AddRange(Lists.Numerize(Lists.SoundNames)); evtNameA.Enabled = true;

                    evtNameA.SelectedIndex = aqc.Option;
                    break;
                case 0x9D:
                    labelTitleA.Text = "Playback start (speaker balance), sound...";
                    labelEvtC.Text = "balance";
                    evtNameA.Items.AddRange(Lists.Numerize(Lists.SoundNames)); evtNameA.Enabled = true;
                    evtNumC.Enabled = true;

                    evtNameA.SelectedIndex = aqc.Option;
                    evtNumC.Value = aqc.EventData[2];
                    break;
                case 0x9E:
                    labelTitleA.Text = "Playback fade-out sound, duration...";
                    labelEvtC.Text = "duration";
                    labelEvtD.Text = "min volume";
                    evtNumC.Enabled = true;
                    evtNumD.Enabled = true;

                    evtNumC.Value = aqc.Option;
                    evtNumD.Value = aqc.EventData[2];
                    break;

                // Memory
                case 0xA0:
                case 0xA1:
                case 0xA2:
                case 0xA4:
                case 0xA5:
                case 0xA6:
                    if (aqc.Opcode < 0xA4) labelTitleA.Text = "Set mem...";
                    else labelTitleA.Text = "Clear mem...";

                    labelEvtC.Text = "address";
                    labelEvtD.Text = "bit";
                    evtNumC.Hexadecimal = true;
                    evtNumC.Maximum = 0x709F; evtNumC.Minimum = 0x7040;
                    evtNumC.Enabled = true;
                    evtNumD.Maximum = 7; evtNumD.Enabled = true;

                    if (aqc.Opcode < 0xA4) evtNumC.Value = ((((aqc.Opcode - 0xA0) * 0x100) + aqc.Option) >> 3) + 0x7040;
                    else evtNumC.Value = ((((aqc.Opcode - 0xA4) * 0x100) + aqc.Option) >> 3) + 0x7040;
                    evtNumD.Value = aqc.Option & 7;
                    break;
                case 0xA8:
                case 0xA9:
                    if (aqc.Opcode == 0xA8) labelTitleA.Text = "Store to mem a value (8-bit)...";
                    else labelTitleA.Text = "Add to mem a value (8-bit)...";
                    labelEvtC.Text = "address";
                    labelEvtD.Text = "value";
                    evtNumC.Hexadecimal = true;
                    evtNumC.Maximum = 0x719F; evtNumC.Minimum = 0x70A0;
                    evtNumC.Enabled = true;
                    evtNumD.Enabled = true;

                    evtNumC.Value = aqc.Option + 0x70A0;
                    evtNumD.Value = aqc.EventData[2];
                    break;
                case 0xAA:
                case 0xAB:
                    if (aqc.Opcode == 0xAA) labelTitleA.Text = "Increment mem (8-bit)...";
                    else labelTitleA.Text = "Decrement mem (8-bit)...";
                    labelEvtC.Text = "address";
                    evtNumC.Hexadecimal = true;
                    evtNumC.Maximum = 0x719F; evtNumC.Minimum = 0x70A0;
                    evtNumC.Enabled = true;

                    evtNumC.Value = aqc.Option + 0x70A0;
                    break;
                case 0xB0:
                case 0xB1:
                case 0xC2:
                    if (aqc.Opcode == 0xB0) labelTitleA.Text = "Store to mem a value (16-bit)...";
                    else if (aqc.Opcode == 0xB1) labelTitleA.Text = "Add to mem a value (16-bit)...";
                    else labelTitleA.Text = "Compare to mem a value (16-bit)...";
                    labelEvtC.Text = "address";
                    labelEvtD.Text = "value";
                    evtNumC.Hexadecimal = true; evtNumC.Increment = 2;
                    evtNumC.Maximum = 0x71FE; evtNumC.Minimum = 0x7000;
                    evtNumC.Enabled = true;
                    evtNumD.Maximum = 65535; evtNumD.Enabled = true;

                    evtNumC.Value = (aqc.Option * 2) + 0x7000;
                    evtNumD.Value = Bits.GetShort(aqc.EventData, 2);
                    break;
                case 0xB2:
                case 0xB3:
                case 0xD6:
                case 0xBB:
                    if (aqc.Opcode == 0xB2) labelTitleA.Text = "Increment mem (16-bit)...";
                    else if (aqc.Opcode == 0xB3) labelTitleA.Text = "Decrement mem (16-bit)...";
                    else if (aqc.Opcode == 0xB6) labelTitleA.Text = "Store to object mem from mem...";
                    else labelTitleA.Text = "Store to mem from mem $700C (16-bit)...";
                    labelEvtC.Text = "address";
                    evtNumC.Hexadecimal = true; evtNumC.Increment = 2;
                    evtNumC.Maximum = 0x71FE; evtNumC.Minimum = 0x7000;
                    evtNumC.Enabled = true;

                    evtNumC.Value = (aqc.Option * 2) + 0x7000;
                    break;
                case 0xB5:
                    labelTitleA.Text = "Store to mem from mem $700C (8-bit)...";
                    labelEvtC.Text = "address";
                    evtNumC.Hexadecimal = true;
                    evtNumC.Maximum = 0x719F; evtNumC.Minimum = 0x70A0;
                    evtNumC.Enabled = true;

                    evtNumC.Value = aqc.Option + 0x70A0;
                    break;
                case 0xB7:
                    labelTitleA.Text = "Store random # less than... to mem...";
                    labelEvtC.Text = "address";
                    labelEvtD.Text = "number <";
                    evtNumC.Hexadecimal = true; evtNumC.Increment = 2;
                    evtNumC.Maximum = 0x71FE; evtNumC.Minimum = 0x7000;
                    evtNumC.Enabled = true;
                    evtNumD.Maximum = 65535; evtNumD.Enabled = true;

                    evtNumC.Value = (aqc.Option * 2) + 0x7000;
                    evtNumD.Value = Bits.GetShort(aqc.EventData, 2);
                    break;
                case 0xBC:
                case 0xBD:
                    if (aqc.Opcode == 0xBC) labelTitleA.Text = "Store to mem A from mem B (choose both, 16-bit)...";
                    else labelTitleA.Text = "Exchange mem A and mem B (16-bit)...";
                    labelEvtC.Text = "address A";
                    labelEvtD.Text = "address B";
                    evtNumC.Hexadecimal = true; evtNumC.Increment = 2;
                    evtNumC.Maximum = 0x71FE; evtNumC.Minimum = 0x7000;
                    evtNumC.Enabled = true;
                    evtNumD.Hexadecimal = true; evtNumD.Increment = 2;
                    evtNumD.Maximum = 0x71FE; evtNumD.Minimum = 0x7000;
                    evtNumD.Enabled = true;

                    evtNumC.Value = (aqc.Option * 2) + 0x7000;
                    evtNumD.Value = (aqc.EventData[2] * 2) + 0x7000;
                    break;
                case 0xD8:
                case 0xD9:
                case 0xDA:
                case 0xDC:
                case 0xDD:
                case 0xDE:
                    if (aqc.Opcode < 0xDC) labelTitleA.Text = "If set, mem...";
                    else labelTitleA.Text = "If clear, mem...";

                    labelEvtC.Text = "address";
                    labelEvtD.Text = "bit";
                    labelEvtE.Text = "then jump to...";
                    evtNumC.Hexadecimal = true;
                    evtNumC.Maximum = 0x709F; evtNumC.Minimum = 0x7040;
                    evtNumC.Enabled = true;
                    evtNumD.Maximum = 7; evtNumD.Enabled = true;
                    evtNumE.Hexadecimal = true; evtNumE.Maximum = 0xFFFF; evtNumE.Enabled = true;

                    if (aqc.Opcode < 0xDC) evtNumC.Value = ((((aqc.Opcode - 0xD8) * 0x100) + aqc.Option) >> 3) + 0x7040;
                    else evtNumC.Value = ((((aqc.Opcode - 0xDC) * 0x100) + aqc.Option) >> 3) + 0x7040;
                    evtNumD.Value = aqc.Option & 7;
                    evtNumE.Value = Bits.GetShort(aqc.EventData, 2);
                    break;
                case 0xE0:
                case 0xE1:
                    if (aqc.Opcode == 0xE0) labelTitleA.Text = "If mem = (8-bit)...";
                    else labelTitleA.Text = "If mem != (8-bit)...";
                    labelEvtC.Text = "address";
                    labelEvtD.Text = "value";
                    labelEvtE.Text = "then jump to...";
                    evtNumC.Hexadecimal = true;
                    evtNumC.Maximum = 0x719F; evtNumC.Minimum = 0x70A0;
                    evtNumC.Enabled = true;
                    evtNumD.Enabled = true;
                    evtNumE.Hexadecimal = true; evtNumE.Maximum = 0xFFFF; evtNumE.Enabled = true;

                    evtNumC.Value = aqc.Option + 0x70A0;
                    evtNumD.Value = aqc.EventData[2];
                    evtNumE.Value = Bits.GetShort(aqc.EventData, 3);
                    break;
                case 0xE4:
                case 0xE5:
                    if (aqc.Opcode == 0xE4) labelTitleA.Text = "If mem = (16-bit)...";
                    else labelTitleA.Text = "If mem != (16-bit)...";
                    labelEvtC.Text = "address";
                    labelEvtD.Text = "value";
                    labelEvtE.Text = "then jump to...";
                    evtNumC.Hexadecimal = true; evtNumC.Increment = 2;
                    evtNumC.Maximum = 0x71FE; evtNumC.Minimum = 0x7000;
                    evtNumC.Enabled = true;
                    evtNumD.Maximum = 65535; evtNumD.Enabled = true;
                    evtNumE.Hexadecimal = true; evtNumE.Maximum = 0xFFFF; evtNumE.Enabled = true;

                    evtNumC.Value = (aqc.Option * 2) + 0x7000;
                    evtNumD.Value = Bits.GetShort(aqc.EventData, 2);
                    evtNumE.Value = Bits.GetShort(aqc.EventData, 4);
                    break;
                case 0xE8:
                    labelTitleA.Text = "If random # > 128, jump to...";
                    labelEvtC.Text = "address";
                    evtNumC.Hexadecimal = true; evtNumC.Maximum = 0xFFFF; evtNumC.Enabled = true;

                    evtNumC.Value = Bits.GetShort(aqc.EventData, 1);
                    break;
                case 0xE9:
                    labelTitleA.Text = "If random # > 66, jump to address A, else address B...";
                    labelEvtC.Text = "address A";
                    labelEvtD.Text = "address B";
                    evtNumC.Hexadecimal = true; evtNumC.Maximum = 0xFFFF; evtNumC.Enabled = true;
                    evtNumD.Hexadecimal = true; evtNumD.Maximum = 0xFFFF; evtNumD.Enabled = true;

                    evtNumC.Value = Bits.GetShort(aqc.EventData, 1);
                    evtNumD.Value = Bits.GetShort(aqc.EventData, 3);
                    break;

                // Memory $700C
                case 0xAC: labelTitleA.Text = "Mem $700C =..."; goto case 0xC0;
                case 0xAD: labelTitleA.Text = "Mem $700C +=..."; goto case 0xC0;
                case 0xB6: labelTitleA.Text = "Mem $700C = random # less than..."; goto case 0xC0;
                case 0xC0:
                    if (aqc.Opcode == 0xC0) labelTitleA.Text = "Mem $700C compare to...";
                    labelEvtC.Text = "value";
                    evtNumC.Maximum = 65535; evtNumC.Enabled = true;

                    evtNumC.Value = Bits.GetShort(aqc.EventData, 1);
                    break;
                case 0xB4:
                    labelTitleA.Text = "Mem $700C = mem...";
                    labelEvtC.Text = "address";
                    evtNumC.Hexadecimal = true;
                    evtNumC.Maximum = 0x719F; evtNumC.Minimum = 0x70A0;
                    evtNumC.Enabled = true;

                    evtNumC.Value = aqc.Option + 0x70A0;
                    break;
                case 0xB8: labelTitleA.Text = "Mem $700C += mem..."; goto case 0xC1;
                case 0xB9: labelTitleA.Text = "Mem $700C -= mem..."; goto case 0xC1;
                case 0xBA: labelTitleA.Text = "Mem $700C = mem..."; goto case 0xC1;
                case 0xC1:
                    if (aqc.Opcode == 0xC1) labelTitleA.Text = "Mem $700C compare to mem...";
                    labelEvtC.Text = "address";
                    evtNumC.Hexadecimal = true; evtNumC.Increment = 2;
                    evtNumC.Maximum = 0x71FE; evtNumC.Minimum = 0x7000;
                    evtNumC.Enabled = true;

                    evtNumC.Value = (aqc.Option * 2) + 0x7000;
                    break;
                case 0xC4: labelTitleA.Text = "Mem $700C = object X coord..."; goto case 0xC6;
                case 0xC5: labelTitleA.Text = "Mem $700C = object Y coord..."; goto case 0xC6;
                case 0xC6:
                    if (aqc.Opcode == 0xC6) labelTitleA.Text = "Mem $700C = object Z coord...";
                    labelEvtA.Text = "object";
                    evtNameA.Items.AddRange(Lists.ObjectNames); evtNameA.Enabled = true;
                    evtEffects.Items.Add("isometric"); evtEffects.Enabled = true;

                    evtNameA.SelectedIndex = aqc.Option;
                    evtEffects.SetItemChecked(0, (aqc.Option & 0x80) == 0x80);
                    break;
                case 0xDB: labelTitleA.Text = "If mem $700C bit(s) set, jump to..."; goto case 0xDF;
                case 0xDF:
                    if (aqc.Opcode == 0xDF) labelTitleA.Text = "If mem $700C bit(s) clear, jump to...";
                    labelEvtC.Text = "address";
                    evtNumC.Hexadecimal = true; evtNumC.Maximum = 0xFFFF; evtNumC.Enabled = true;

                    evtNumC.Value = Bits.GetShort(aqc.EventData, 1);
                    break;
                case 0xE2: labelTitleA.Text = "If mem $700C = value..."; labelEvtC.Text = "value"; goto case 0xE7;
                case 0xE3: labelTitleA.Text = "If mem $700C != value..."; labelEvtC.Text = "value"; goto case 0xE7;
                case 0xE6: labelTitleA.Text = "If mem $700C set, no bits..."; goto case 0xE7;
                case 0xE7:
                    if (aqc.Opcode == 0xE7) labelTitleA.Text = "If mem $700C set, any bits...";
                    if (aqc.Opcode > 0xE3) labelEvtC.Text = "bits";
                    labelEvtD.Text = "jump to";
                    evtNumC.Maximum = 65535; evtNumC.Enabled = true;
                    evtNumD.Hexadecimal = true; evtNumD.Maximum = 0xFFFF; evtNumD.Enabled = true;

                    evtNumC.Value = Bits.GetShort(aqc.EventData, 1);
                    evtNumD.Value = Bits.GetShort(aqc.EventData, 3);
                    break;
                case 0xEA: labelTitleA.Text = "If equal to zero, jump to..."; goto case 0xEF;
                case 0xEB: labelTitleA.Text = "If not equal to zero, jump to..."; goto case 0xEF;
                case 0xEC: labelTitleA.Text = "If greater than / equal to, jump to..."; goto case 0xEF;
                case 0xED: labelTitleA.Text = "If less than, jump to..."; goto case 0xEF;
                case 0xEE: labelTitleA.Text = "If negative, jump to..."; goto case 0xEF;
                case 0xEF:
                    if (aqc.Opcode == 0xEF) labelTitleA.Text = "If positive, jump to...";
                    labelEvtC.Text = "jump to";
                    evtNumC.Hexadecimal = true; evtNumC.Maximum = 0xFFFF; evtNumC.Enabled = true;

                    evtNumC.Value = Bits.GetShort(aqc.EventData, 1);
                    break;

                // Jump to
                case 0xD2:
                case 0xD3:
                    if (aqc.Opcode == 0xD2) labelTitleA.Text = "Jump to address...";
                    else labelTitleA.Text = "Jump to subroutine...";

                    labelEvtC.Text = "address";
                    evtNumC.Hexadecimal = true; evtNumC.Maximum = 0xFFFF; evtNumC.Enabled = true;

                    evtNumC.Value = Bits.GetShort(aqc.EventData, 1);
                    break;
                case 0xD4:
                    labelTitleA.Text = "Loop start, loop count...";
                    labelEvtC.Text = "count";
                    evtNumC.Enabled = true;

                    evtNumC.Value = aqc.Option;
                    break;

                // Object memory
                case 0xF2:         // Set obj presence...  
                case 0xF3:         // Set obj engage type...
                case 0xF8:         // If object in level ..., presence =...
                    if (aqc.Opcode == 0xF2)
                    {
                        labelTitleA.Text = "Set presence in...";
                        labelTitleB.Text = "presence is...";
                    }
                    else if (aqc.Opcode == 0xF3)
                    {
                        labelTitleA.Text = "Set event trigger in...";
                        labelTitleB.Text = "event trigger enabled is...";
                    }
                    else
                    {
                        labelTitleA.Text = "If presence in...";
                        labelTitleB.Text = "presence is...";
                        labelEvtE.Text = "jump to";
                    }
                    labelEvtA.Text = "level";
                    labelEvtB.Text = "for object";
                    evtNameA.Items.AddRange(Lists.Convert(settings.LevelNames)); evtNameA.Enabled = true;
                    evtNameB.Items.AddRange(Lists.ObjectNames); evtNameB.Enabled = true;
                    evtNumA.Enabled = true; evtNumA.Maximum = 511;
                    evtEffects.Items.AddRange(new object[] { "true" }); evtEffects.Enabled = true;
                    if (aqc.Opcode == 0xF8)
                        evtNumE.Enabled = true; evtNumE.Hexadecimal = true; evtNumE.Maximum = 0xFFFF;

                    evtNumA.Value = Bits.GetShort(aqc.EventData, 1) & 0x1FF;
                    evtNameA.SelectedIndex = (int)evtNumA.Value;
                    evtNameB.SelectedIndex = (aqc.EventData[2] >> 1) & 0x3F;
                    evtEffects.SetItemChecked(0, (aqc.EventData[2] & 0x80) == 0x80);
                    if (aqc.Opcode == 0xF8)
                        evtNumE.Value = Bits.GetShort(aqc.EventData, 3);
                    /* 
                     * TODO
                     * synchronize evtNameA with evtNumA
                     */
                    break;

                // Pause script
                case 0xF0:
                    labelTitleA.Text = "Pause script, frame duration (8-bit)...";
                    labelEvtC.Text = "frames";
                    evtNumC.Enabled = true;

                    evtNumC.Value = aqc.Option;
                    break;
                case 0xF1:
                    labelTitleA.Text = "Pause script, frame duration (16-bit)...";
                    labelEvtC.Text = "frames";
                    evtNumC.Maximum = 65535; evtNumC.Enabled = true;

                    evtNumC.Value = Bits.GetShort(aqc.EventData, 1);
                    break;

                case 0xFD:
                    switch (aqc.Option)
                    {
                        case 0x0F:
                            labelTitleA.Text = "Layer priority =...";
                            labelEvtC.Text = "priority";
                            evtNumC.Maximum = 3; evtNumC.Enabled = true;

                            evtNumC.Value = aqc.EventData[2];
                            break;

                        // Memory
                        case 0xB6:
                            labelTitleA.Text = "Halve mem...";
                            labelEvtC.Text = "address";
                            labelEvtD.Text = "halves";
                            evtNumC.Hexadecimal = true; evtNumC.Increment = 2;
                            evtNumC.Maximum = 0x71FE; evtNumC.Minimum = 0x7000;
                            evtNumC.Enabled = true;
                            evtNumD.Maximum = 256; evtNumD.Minimum = 1; evtNumD.Enabled = true;

                            evtNumC.Value = (aqc.EventData[2] * 2) + 0x7000;
                            evtNumD.Value = (aqc.EventData[3] ^ 0xFF) + 1;
                            break;

                        // Memory $700C
                        case 0xB0: labelTitleA.Text = "Mem $700C isolate bits =..."; goto case 0xB2;
                        case 0xB1: labelTitleA.Text = "Mem $700C set bits =..."; goto case 0xB2;
                        case 0xB2:
                            if (aqc.Option == 0xB2) labelTitleA.Text = "Mem $700C xor bits =...";
                            labelEvtC.Text = "bits";
                            evtNumC.Maximum = 65535; evtNumC.Enabled = true;

                            evtNumC.Value = Bits.GetShort(aqc.EventData, 2);
                            break;
                        case 0xB3: labelTitleA.Text = "Mem $700C isolate bits = mem..."; goto case 0xB5;
                        case 0xB4: labelTitleA.Text = "Mem $700C set bits = mem..."; goto case 0xB5;
                        case 0xB5:
                            if (aqc.Option == 0xB5) labelTitleA.Text = "Mem $700C xor bits = mem...";
                            labelEvtC.Text = "address";
                            evtNumC.Hexadecimal = true; evtNumC.Increment = 2;
                            evtNumC.Maximum = 0x71FE; evtNumC.Minimum = 0x7000;
                            evtNumC.Enabled = true;

                            evtNumC.Value = (aqc.EventData[2] * 2) + 0x7000;
                            break;
                    }
                    break;
            }

            updatingControls = true;
        }
        private void ControlActionAsmMethod()
        {
            switch (aqc.Opcode)
            {
                // Properties
                case 0x0A:
                    aqc.Option = (byte)evtNumC.Value;
                    break;
                case 0x0B:
                case 0x15:
                case 0x0C:
                    for (int i = 0; i < 8; i++)
                        Bits.SetBit(aqc.EventData, 1, i, evtEffects.GetItemChecked(i));
                    break;
                case 0x13:
                    aqc.Option = (byte)evtNumC.Value;
                    break;
                case 0x3D:
                    Bits.SetShort(aqc.EventData, 1, (ushort)evtNumC.Value);
                    break;

                // Palette
                case 0x0D:
                case 0x0E:
                    aqc.Option = (byte)evtNumC.Value;
                    break;

                // Sprite Sequence
                case 0x08:
                    aqc.Option = (byte)evtNumC.Value;
                    aqc.EventData[2] = (byte)evtNumD.Value;
                    Bits.SetBit(aqc.EventData, 1, 3, evtEffects.GetItemChecked(0));
                    Bits.SetBit(aqc.EventData, 1, 4, evtEffects.GetItemChecked(1));
                    Bits.SetBit(aqc.EventData, 1, 6, evtEffects.GetItemChecked(2));
                    Bits.SetBit(aqc.EventData, 2, 7, evtEffects.GetItemChecked(3));

                    /*
                     * TODO
                     * set labelEvtD.text based on bit 3 of byte 2
                     * if set, make "frame", else "sequence"
                     */
                    break;
                case 0x10:
                    aqc.Option = (byte)evtNameA.SelectedIndex;
                    Bits.SetBit(aqc.EventData, 1, 6, evtEffects.GetItemChecked(0));
                    Bits.SetBit(aqc.EventData, 1, 7, evtEffects.GetItemChecked(1));
                    break;
                case 0xD0:
                    Bits.SetShort(aqc.EventData, 1, (ushort)evtNumC.Value);
                    break;

                // Sprite Animation


                // Shift isometric units
                case 0x50:
                case 0x51:
                case 0x52:
                case 0x53:
                case 0x54:
                case 0x55:
                case 0x56:
                case 0x57:
                case 0x58:
                case 0x5A:
                case 0x5B:
                    aqc.Option = (byte)evtNumC.Value;
                    break;
                case 0x7E:
                case 0x7F:
                    Bits.SetShort(aqc.EventData, 1, (ushort)evtNumC.Value);
                    break;

                // Shift 1px units
                case 0x60:
                case 0x61:
                case 0x62:
                case 0x63:
                case 0x64:
                case 0x65:
                case 0x66:
                case 0x67:
                case 0x68:
                case 0x6A:
                case 0x6B:
                    aqc.Option = (byte)evtNumC.Value;
                    break;

                // Face direction
                case 0x7B:
                    aqc.Option = (byte)evtNumC.Value;
                    break;

                // Shift to coords
                case 0x80:
                case 0x81:
                case 0x82:
                case 0x83:
                case 0x84:
                    if (aqc.Opcode != 0x80 && aqc.Opcode != 0x82)
                    {
                        aqc.Option = (byte)((sbyte)evtNumC.Value);
                        aqc.EventData[2] = (byte)((sbyte)evtNumD.Value);
                    }
                    else
                    {
                        aqc.Option = (byte)evtNumC.Value;
                        aqc.EventData[2] = (byte)evtNumD.Value;
                    }
                    break;
                case 0x87:
                case 0x95:
                    aqc.Option = (byte)evtNameA.SelectedIndex;
                    break;
                case 0x90:
                case 0x91:
                    aqc.EventData[3] = (byte)evtNumA.Value;
                    if (aqc.Opcode != 0x90)
                    {
                        aqc.Option = (byte)((sbyte)evtNumC.Value);
                        aqc.EventData[2] = (byte)((sbyte)evtNumD.Value);
                    }
                    else
                    {
                        aqc.Option = (byte)evtNumC.Value;
                        aqc.EventData[2] = (byte)evtNumD.Value;
                    }
                    break;
                case 0x92:
                case 0x93:
                case 0x94:
                    aqc.EventData[3] = (byte)(evtNameB.SelectedIndex << 5);
                    aqc.EventData[3] &= 0xE0; aqc.EventData[3] |= (byte)evtNumB.Value;
                    if (aqc.Opcode != 0x92)
                    {
                        aqc.Option = (byte)((sbyte)evtNumC.Value);
                        aqc.EventData[2] = (byte)((sbyte)evtNumD.Value);
                    }
                    else
                    {
                        aqc.Option = (byte)evtNumC.Value;
                        aqc.EventData[2] = (byte)evtNumD.Value;
                    }
                    break;

                // Audio playback
                case 0x9C:
                    aqc.Option = (byte)evtNameA.SelectedIndex;
                    break;
                case 0x9D:
                    aqc.Option = (byte)evtNameA.SelectedIndex;
                    aqc.EventData[2] = (byte)evtNumC.Value;
                    break;
                case 0x9E:
                    aqc.Option = (byte)evtNumC.Value;
                    aqc.EventData[2] = (byte)evtNumD.Value;
                    break;

                // Memory
                case 0xA0:
                case 0xA1:
                case 0xA2:
                    aqc.Opcode = (byte)(((((byte)(evtNumC.Value - 0x7040) << 3) & 0x0F00) >> 8) + 0xA0);
                    aqc.Option = (byte)(((byte)(evtNumC.Value - 0x7040) << 3) & 0xF8);
                    aqc.Option &= 0xF8; aqc.Option |= (byte)evtNumD.Value;
                    break;
                case 0xA4:
                case 0xA5:
                case 0xA6:
                    aqc.Opcode = (byte)(((((byte)(evtNumC.Value - 0x7040) << 3) & 0x0F00) >> 8) + 0xA4);
                    aqc.Option = (byte)(((byte)(evtNumC.Value - 0x7040) << 3) & 0xF8);
                    aqc.Option &= 0xF8; aqc.Option |= (byte)evtNumD.Value;
                    break;
                case 0xA8:
                case 0xA9:
                    aqc.Option = (byte)(evtNumC.Value - 0x70A0);
                    aqc.EventData[2] = (byte)evtNumD.Value;
                    break;
                case 0xAA:
                case 0xAB:
                    aqc.Option = (byte)(evtNumC.Value - 0x70A0);
                    break;
                case 0xB0:
                case 0xB1:
                case 0xC2:
                    aqc.Option = (byte)((evtNumC.Value - 0x7000) / 2);
                    Bits.SetShort(aqc.EventData, 2, (ushort)evtNumD.Value);
                    break;
                case 0xB2:
                case 0xB3:
                case 0xD6:
                case 0xBB:
                    aqc.Option = (byte)((evtNumC.Value - 0x7000) / 2);
                    break;
                case 0xB5:
                    aqc.Option = (byte)(evtNumC.Value - 0x70A0);
                    break;
                case 0xB7:
                    aqc.Option = (byte)((evtNumC.Value - 0x7000) / 2);
                    Bits.SetShort(aqc.EventData, 2, (ushort)evtNumD.Value);
                    break;
                case 0xBC:
                case 0xBD:
                    aqc.Option = (byte)((evtNumC.Value - 0x7000) / 2);
                    aqc.EventData[2] = (byte)((evtNumD.Value - 0x7000) / 2);
                    break;
                case 0xD8:
                case 0xD9:
                case 0xDA:
                    aqc.Opcode = (byte)(((((byte)(evtNumC.Value - 0x7040) << 3) & 0x0F00) >> 8) + 0xD8);
                    aqc.Option = (byte)(((byte)(evtNumC.Value - 0x7040) << 3) & 0xF8);
                    aqc.Option &= 0xF8; aqc.Option |= (byte)evtNumD.Value;
                    Bits.SetShort(aqc.EventData, 2, (ushort)evtNumE.Value);
                    break;
                case 0xDC:
                case 0xDD:
                case 0xDE:
                    aqc.Opcode = (byte)(((((byte)(evtNumC.Value - 0x7040) << 3) & 0x0F00) >> 8) + 0xDC);
                    aqc.Option = (byte)(((byte)(evtNumC.Value - 0x7040) << 3) & 0xF8);
                    aqc.Option &= 0xF8; aqc.Option |= (byte)evtNumD.Value;
                    Bits.SetShort(aqc.EventData, 2, (ushort)evtNumE.Value);
                    break;
                case 0xE0:
                case 0xE1:
                    aqc.Option = (byte)(evtNumC.Value - 0x70A0);
                    aqc.EventData[2] = (byte)evtNumD.Value;
                    Bits.SetShort(aqc.EventData, 3, (ushort)evtNumE.Value);
                    break;
                case 0xE4:
                case 0xE5:
                    aqc.Option = (byte)((evtNumC.Value - 0x7000) / 2);
                    Bits.SetShort(aqc.EventData, 2, (ushort)evtNumD.Value);
                    Bits.SetShort(aqc.EventData, 4, (ushort)evtNumE.Value);
                    break;
                case 0xE8:
                    Bits.SetShort(aqc.EventData, 1, (ushort)evtNumC.Value);
                    break;
                case 0xE9:
                    Bits.SetShort(aqc.EventData, 1, (ushort)evtNumC.Value);
                    Bits.SetShort(aqc.EventData, 3, (ushort)evtNumD.Value);
                    break;

                // Memory $700C
                case 0xAC:
                case 0xAD:
                case 0xB6:
                case 0xC0:
                    Bits.SetShort(aqc.EventData, 1, (ushort)evtNumC.Value);
                    break;
                case 0xB4:
                    aqc.Option = (byte)(evtNumC.Value - 0x70A0);
                    break;
                case 0xB8:
                case 0xB9:
                case 0xBA:
                case 0xC1:
                    aqc.Option = (byte)((evtNumC.Value - 0x7000) / 2);
                    break;
                case 0xC4:
                case 0xC5:
                case 0xC6:
                    aqc.Option = (byte)evtNameA.SelectedIndex;
                    Bits.SetBit(aqc.EventData, 1, 7, evtEffects.GetItemChecked(0));
                    break;
                case 0xDB:
                case 0xDF:
                    Bits.SetShort(aqc.EventData, 1, (ushort)evtNumC.Value);
                    break;
                case 0xE2:
                case 0xE3:
                case 0xE6:
                case 0xE7:
                    Bits.SetShort(aqc.EventData, 1, (ushort)evtNumC.Value);
                    Bits.SetShort(aqc.EventData, 3, (ushort)evtNumD.Value);
                    break;
                case 0xEA:
                case 0xEB:
                case 0xEC:
                case 0xED:
                case 0xEE:
                case 0xEF:
                    Bits.SetShort(aqc.EventData, 1, (ushort)evtNumC.Value);
                    break;

                // Jump to
                case 0xD2:
                case 0xD3:
                    Bits.SetShort(aqc.EventData, 1, (ushort)evtNumC.Value);
                    break;
                case 0xD4:
                    aqc.Option = (byte)evtNumC.Value;
                    break;

                // Object memory
                case 0xF2:         // Set obj presence...  
                case 0xF3:         // Set obj engage type...
                case 0xF8:         // If object in level ..., presence =...
                    Bits.SetShort(aqc.EventData, 1, (ushort)evtNumA.Value);
                    aqc.EventData[2] &= 1; aqc.EventData[2] |= (byte)(evtNameB.SelectedIndex << 1);
                    Bits.SetBit(aqc.EventData, 2, 7, evtEffects.GetItemChecked(0));    // set bit 7 if true
                    if (aqc.Opcode == 0xF8)
                        Bits.SetShort(aqc.EventData, 3, (ushort)evtNumE.Value);
                    /* 
                     * TODO
                     * synchronize evtNameA with evtNumA
                     */
                    break;

                // Pause script
                case 0xF0:
                    aqc.Option = (byte)evtNumC.Value;
                    break;
                case 0xF1:
                    Bits.SetShort(aqc.EventData, 1, (ushort)evtNumC.Value);
                    break;

                case 0xFD:
                    switch (aqc.Option)
                    {
                        case 0x0F:
                            aqc.EventData[2] = (byte)evtNumC.Value;
                            break;

                        // Memory
                        case 0xB6:
                            aqc.EventData[2] = (byte)((evtNumC.Value - 0x7000) / 2);
                            aqc.EventData[3] = (byte)((byte)(evtNumD.Value - 1) ^ 0xFF);
                            break;

                        // Memory $700C
                        case 0xB0:
                        case 0xB1:
                        case 0xB2:
                            Bits.SetShort(aqc.EventData, 2, (ushort)evtNumC.Value);
                            break;
                        case 0xB3:
                        case 0xB4:
                        case 0xB5:
                            aqc.EventData[2] = (byte)((evtNumC.Value - 0x7000) / 2);
                            break;
                    }
                    break;
            }
        }

        public void UpdateActionOffsets()
        {
            int delta = treeViewWrapper.ScriptDelta;
            int actionNum = treeViewWrapper.Action.Index;
            int end, start;
            int conditionOffset = 0;

            if (actionNum >= 0 && actionNum <= 1023)
            {
                start = 0;
                end = 1023; // Bank 1E

                if (actionNum < end)
                    conditionOffset = actionScripts[actionNum + 1].Offset;
                else
                    conditionOffset = actionScripts[actionNum].Offset + actionScripts[actionNum].ActionQueueLength; // Dont need to update anything after this event if its the last one                    
            }
            else
                throw new Exception("Invalid action num");

            if (!autoPointerUpdate.Checked)
                conditionOffset = 0x7FFFFFFF;

            if (autoPointerUpdate.Checked)
            {
                // Update all pointers before eventOffset
                for (int i = start; i < actionNum; i++)
                    actionScripts[i].UpdateAllOffsets(delta, conditionOffset);
            }

            // Update all events and pointers after edited event
            for (int i = actionNum + 1; i <= end; i++)
                actionScripts[i].UpdateAllOffsets(delta, conditionOffset);

            if (autoPointerUpdate.Checked)
            {
                // Update all pointers to edited event
                UpdateCurrentActionReferencePointers();
            }
            treeViewWrapper.ScriptDelta = 0;
        }
        private void UpdateCurrentActionReferencePointers()
        {

            ActionQueue aq = treeViewWrapper.Action;

            foreach (ActionQueueCommand aqc in aq.Commands)
            {
                if (aqc.CommandDelta != 0)
                    UpdatePointersToAction(aqc);
            }
        }
        private void UpdatePointersToAction(ActionQueueCommand aqcRef)
        {
            ushort pointer;
            foreach (ActionQueue aq in actionScripts)
            {
                if (aq.Index != treeViewWrapper.Action.Index)
                {
                    foreach (ActionQueueCommand aqcIterator in aq.Commands)
                    {
                        if (aqcIterator.Opcode == 0xE9)
                        {
                            pointer = aqcIterator.ReadPointerSpecial(0);
                            if (pointer == (aqcRef.OriginalOffset & 0xFFFF))
                                aqcIterator.WritePointerSpecial(0, (ushort)(pointer + aqcRef.CommandDelta));
                            pointer = aqcIterator.ReadPointerSpecial(1);
                            if (pointer == (aqcRef.OriginalOffset & 0xFFFF))
                                aqcIterator.WritePointerSpecial(1, (ushort)(pointer + aqcRef.CommandDelta));
                        }
                        else
                        {
                            pointer = aqcIterator.ReadPointer();
                            if (pointer == (aqcRef.OriginalOffset & 0xFFFF))
                                aqcIterator.WritePointer((ushort)(pointer + aqcRef.CommandDelta));
                        }
                    }
                }
            }
        }

        private void UpdateActionScriptsFreeSpace()
        {
            int left = CalculateActionScriptsLength();
            this.label1.Text = " " + left.ToString() + " bytes left ";
            this.label1.BackColor = left < 0 ? Color.Red : SystemColors.Control;
        }
        private int CalculateActionScriptsLength()
        {
            int totalSize = 0xC000 - 0x800;
            int length = 0;

            for (int i = 0; i < actionScripts.Length; i++)
                length += actionScripts[i].ActionQueueData.Length;

            return totalSize - length - 1;
        }
    }
}
