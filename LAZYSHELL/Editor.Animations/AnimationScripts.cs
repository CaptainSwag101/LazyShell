using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.ScriptsEditor;
using LAZYSHELL.ScriptsEditor.Commands;
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
    public partial class AnimationScripts : Form
    {
        #region Variables
        private long checksum;
        private A_TreeViewWrapper a_treeViewWrapper;
        private AnimationScript[] animationScripts
        {
            get
            {
                switch (animationCategory.SelectedIndex)
                {
                    case 0: return Model.BehaviorAnimations;
                    case 1: return Model.SpellAnimMonsters;
                    case 2: return Model.AttackAnimations;
                    case 3: return Model.EntranceAnimations;
                    case 4: return Model.ItemAnimations;
                    case 5: return Model.SpellAnimAllies;
                    case 6: return Model.WeaponAnimations;
                    case 7: return Model.BattleEvents;
                }
                return null;
            }
            set
            {
                switch (animationCategory.SelectedIndex)
                {
                    case 0: Model.BehaviorAnimations = value; break;
                    case 1: Model.SpellAnimMonsters = value; break;
                    case 2: Model.AttackAnimations = value; break;
                    case 3: Model.EntranceAnimations = value; break;
                    case 4: Model.ItemAnimations = value; break;
                    case 5: Model.SpellAnimAllies = value; break;
                    case 6: Model.WeaponAnimations = value; break;
                    case 7: Model.BattleEvents = value; break;
                }
            }
        }
        private AnimationScriptCommand asc;
        private int index { get { return (int)animationNum.Value; } set { animationNum.Value = value; } }
        private Settings settings = Settings.Default;
        private BattleDialoguePreview battleDialoguePreview;
        private MenuTextPreview menuTextPreview;
        private ToolTipLabel toolTipLabel;
        private byte[] animationBank, battleBank;
        private bool updatingAnimations = false;
        #endregion
        // constructor
        public AnimationScripts()
        {
            this.settings.Keystrokes[0x20] = "\x20";
            this.settings.KeystrokesMenu[0x20] = "\x20";
            InitializeComponent();
            toolTipLabel = new ToolTipLabel(this, toolTip1, showDecHex, null);
            for (int i = 0; i < 9; i++)
            {
                ToolStripNumericUpDown numUpDown = new ToolStripNumericUpDown();
                numUpDown.Hexadecimal = true;
                numUpDown.Maximum = 255;
                numUpDown.MouseMove += new MouseEventHandler(toolTipLabel.ControlMouseMove);
                numUpDown.Width = 40;
                toolStrip2.Items.Insert(i + 4, numUpDown);
            }
            this.animationCategory.Items.AddRange(new object[] {
            "Monster Behaviors",
            "Monster Spells",
            "Monster Attacks",
            "Monster Entrances",
            "Items",
            "Ally Spells",
            "Weapons",
            "Battle Events"});
            Do.AddShortcut(toolStrip4, Keys.Control | Keys.S, new EventHandler(save_Click));
            Do.AddShortcut(toolStrip4, Keys.F2, showDecHex);
            InitializeAnimationScriptsEditor();
        }
        #region Methods
        private void InitializeAnimationScriptsEditor()
        {
            updatingAnimations = true;

            animationBank = Bits.GetByteArray(Model.Data, 0x350000, 0x10000);
            battleBank = Bits.GetByteArray(Model.Data, 0x3A6000, 0xA000);

            checksum = Do.GenerateChecksum(animationBank, battleBank);
            //
            this.menuTextPreview = new MenuTextPreview();
            this.battleDialoguePreview = new BattleDialoguePreview();

            this.a_treeViewWrapper = new A_TreeViewWrapper(this.animationScriptTree);
            this.animationCategory.SelectedIndex = 1;

            RefreshAnimationScriptsEditor();

            updatingAnimations = false;
        }
        private void RefreshAnimationScriptsEditor()
        {
            animationScripts[(int)animationNum.Value].RefreshAnimationScript();
            switch (animationCategory.SelectedIndex)
            {
                case 0:
                    a_treeViewWrapper.ChangeScript(animationScripts[(int)animationNum.Value]);
                    animationName.Items.Clear();
                    for (int i = 0; i < animationScripts.Length; i++)
                        this.animationName.Items.Add("Script #" + i.ToString());
                    animationName.DropDownWidth = animationName.Width;
                    animationNum.Maximum = animationScripts.Length - 1;
                    break;
                case 1:
                    a_treeViewWrapper.ChangeScript(animationScripts[(int)animationNum.Value]);
                    animationName.Items.Clear();
                    for (int i = 0; i < animationScripts.Length; i++)
                        this.animationName.Items.Add(Model.SpellNames.GetNameByNum(i + 0x40));
                    animationName.DropDownWidth = animationName.Width;
                    animationNum.Maximum = animationScripts.Length - 1;
                    break;
                case 2:
                    a_treeViewWrapper.ChangeScript(animationScripts[(int)animationNum.Value]);
                    animationName.Items.Clear();
                    this.animationName.Items.AddRange(Model.AttackNames.Names);
                    animationName.DropDownWidth = animationName.Width;
                    animationNum.Maximum = animationScripts.Length - 1;
                    break;
                case 3:
                    a_treeViewWrapper.ChangeScript(animationScripts[(int)animationNum.Value]);
                    animationName.Items.Clear();
                    this.animationName.Items.AddRange(new object[] {
                        "none",
                        "slide in",
                        "long jump",
                        "hop 3 times",
                        "drop from above",
                        "zoom in from right",
                        "zoom in from left",
                        "spread out from back",
                        "hover in",
                        "ready to attack",
                        "fade in",
                        "slow drop from above",
                        "wait, then appear",
                        "spread from front",
                        "spread from middle",
                        "ready to attack"});
                    animationName.DropDownWidth = animationName.Width;
                    animationNum.Maximum = animationScripts.Length - 1;
                    break;
                case 4:
                    a_treeViewWrapper.ChangeScript(animationScripts[(int)animationNum.Value]);
                    animationName.Items.Clear();
                    for (int i = 0; i < animationScripts.Length; i++)
                        this.animationName.Items.Add(Model.ItemNames.GetNameByNum(i + 0x60));
                    animationName.DropDownWidth = animationName.Width;
                    animationNum.Maximum = animationScripts.Length - 1;
                    break;
                case 5:
                    a_treeViewWrapper.ChangeScript(animationScripts[(int)animationNum.Value]);
                    animationName.Items.Clear();
                    for (int i = 0; i < animationScripts.Length; i++)
                        this.animationName.Items.Add(Model.SpellNames.GetNameByNum(i));
                    animationName.DropDownWidth = animationName.Width;
                    animationNum.Maximum = animationScripts.Length - 1;
                    break;
                case 6:
                    a_treeViewWrapper.ChangeScript(animationScripts[(int)animationNum.Value]);
                    animationName.Items.Clear();
                    for (int i = 0; i < animationScripts.Length; i++)
                        this.animationName.Items.Add(Model.ItemNames.GetNameByNum(i));
                    animationName.DropDownWidth = animationName.Width;
                    animationNum.Maximum = animationScripts.Length - 1;
                    break;
                case 7:
                    a_treeViewWrapper.ChangeScript(animationScripts[(int)animationNum.Value]);
                    animationName.Items.Clear();
                    this.animationName.Items.AddRange(Lists.Numerize(Lists.BattleEventNames));
                    animationName.DropDownWidth = 500;
                    animationNum.Maximum = animationScripts.Length - 1;
                    break;
            }
            this.animationName.SelectedIndex = 0;
            if (this.animationScriptTree.Nodes.Count > 0)
                this.animationScriptTree.SelectedNode = this.animationScriptTree.Nodes[0];
        }

        private void ControlAniDisasmMethod()
        {
            updatingAnimations = true;

            switch (asc.Opcode)
            {
                case 0x00:
                    aniTitleA.Text = "Set current action object...";
                    aniLabelA.Text = "Sprite";
                    aniLabelC.Text = "Sequence";
                    aniLabelD.Text = "VRAM";
                    aniTitleB.Text = "Properties...";
                    aniNameA.Items.AddRange(Lists.Numerize(Lists.SpriteNames));
                    aniNameA.Enabled = true;
                    aniNumA.Maximum = 0x3FF; aniNumA.Enabled = true;
                    aniNumC.Maximum = 15; aniNumC.Enabled = true;
                    aniNumD.Hexadecimal = true; aniNumD.Maximum = 0xFFFF; aniNumD.Enabled = true;
                    aniBits.Items.AddRange(new object[]{
                        "store to VRAM",
                        "infinite seq playback",
                        "store palette",
                        "playback only once",
                        "mirror",
                        "invert"});
                    aniBits.Enabled = true;

                    aniNumA.Value = aniNameA.SelectedIndex = Bits.GetShort(asc.AnimationData, 3) & 0x3FF;
                    aniNumC.Value = asc.AnimationData[5];
                    aniNumD.Value = Bits.GetShort(asc.AnimationData, 7);
                    aniBits.SetItemChecked(0, (asc.AnimationData[1] & 0x01) == 0x01);
                    aniBits.SetItemChecked(1, (asc.AnimationData[2] & 0x08) == 0x08);
                    aniBits.SetItemChecked(2, (asc.AnimationData[2] & 0x20) == 0x20);
                    aniBits.SetItemChecked(3, (asc.AnimationData[6] & 0x10) == 0x10);
                    aniBits.SetItemChecked(4, (asc.AnimationData[6] & 0x40) == 0x40);
                    aniBits.SetItemChecked(5, (asc.AnimationData[6] & 0x80) == 0x80);
                    break;
                case 0x01:
                case 0x0B:
                    aniTitleA.Text = asc.Opcode == 0x0B ?
                        "Store coords to action mem $40..." : "Store coords to mem $32...";
                    aniLabelA.Text = "Add to coords:";
                    aniLabelB.Text = "Z coord";
                    aniLabelC.Text = "X coord";
                    aniLabelD.Text = "Y coord";
                    aniTitleB.Text = "Set coords...";
                    aniNameA.Items.AddRange(new object[]{
                        "absolute coords",
                        "caster's original coords",
                        "target's current coords",
                        "caster's current coords"});
                    aniNameA.Enabled = true;
                    aniNumB.Enabled = true; aniNumB.Minimum = -0x8000; aniNumB.Maximum = 0x7FFF;
                    aniNumC.Enabled = true; aniNumC.Minimum = -0x8000; aniNumC.Maximum = 0x7FFF;
                    aniNumD.Enabled = true; aniNumD.Minimum = -0x8000; aniNumD.Maximum = 0x7FFF;
                    aniBits.Enabled = true;
                    aniBits.Items.AddRange(new object[] { "set X coord", "set Y coord", "set Z coord" });

                    aniNameA.SelectedIndex = (int)(asc.Option >> 4);
                    aniNumB.Value = (short)Bits.GetShort(asc.AnimationData, 6);
                    aniNumC.Value = (short)Bits.GetShort(asc.AnimationData, 2);
                    aniNumD.Value = (short)Bits.GetShort(asc.AnimationData, 4);
                    aniBits.SetItemChecked(0, (asc.Option & 0x01) == 0x01);
                    aniBits.SetItemChecked(1, (asc.Option & 0x02) == 0x02);
                    aniBits.SetItemChecked(2, (asc.Option & 0x04) == 0x04);
                    break;
                case 0x03:
                    aniTitleA.Text = "Set sprite of current action object...";
                    aniLabelA.Text = "Sprite";
                    aniLabelC.Text = "Sequence";
                    aniTitleB.Text = "Properties...";
                    aniNameA.Items.AddRange(Lists.Numerize(Lists.SpriteNames));
                    aniNameA.Enabled = true;
                    aniNumA.Maximum = 0x3FF; aniNumA.Enabled = true;
                    aniNumC.Maximum = 15; aniNumC.Enabled = true;
                    aniBits.Items.AddRange(new object[]{
                        "store to VRAM",
                        "infinite seq playback",
                        "store palette"});
                    aniBits.Enabled = true;

                    aniNumA.Value = aniNameA.SelectedIndex = Bits.GetShort(asc.AnimationData, 3) & 0x3FF;
                    aniNumC.Value = asc.AnimationData[5] & 15;
                    aniBits.SetItemChecked(0, (asc.AnimationData[1] & 0x01) == 0x01);
                    aniBits.SetItemChecked(1, (asc.AnimationData[2] & 0x08) == 0x08);
                    aniBits.SetItemChecked(2, (asc.AnimationData[2] & 0x20) == 0x20);
                    break;
                case 0x04:
                    aniTitleA.Text = "Pause script...";
                    aniLabelA.Text = "until...";
                    aniLabelC.Text = "# of frames";
                    aniNameA.Items.AddRange(new object[]{"{00}","{01}","{02}","{03}","{04}","{05}",
                        "sprite shift complete",
                        "{07}","{08}","{09}","{0A}","{0B}","{0C}","{0D}","{0E}","{0F}",
                        "# of frames have passed"});
                    aniNameA.Enabled = true;
                    aniNameA.SelectedIndex = asc.Option;
                    aniNumC.Enabled = true; aniNumC.Maximum = 0xFFFF;
                    aniNumC.Value = Bits.GetShort(asc.AnimationData, 2);
                    break;
                case 0x08:
                    aniTitleA.Text = "Shift current action object...";
                    aniLabelB.Text = "Acceleration";
                    aniLabelC.Text = "Start value";
                    aniLabelD.Text = "End value";
                    aniTitleB.Text = "Set properties...";

                    aniNumB.Enabled = true; aniNumB.Maximum = 0x7FFF; aniNumB.Minimum = -0x8000;
                    aniNumC.Enabled = true; aniNumC.Maximum = 0x7FFF; aniNumC.Minimum = -0x8000;
                    aniNumD.Enabled = true; aniNumD.Maximum = 0x7FFF; aniNumD.Minimum = -0x8000;
                    aniBits.Items.AddRange(new object[]{
                        "do Z shift","do Y shift","do X shift",
                        "set start value","set end value","set acceleration"});
                    aniBits.Enabled = true;

                    aniNumB.Value = (short)Bits.GetShort(asc.AnimationData, 6);
                    aniNumC.Value = (short)Bits.GetShort(asc.AnimationData, 2);
                    aniNumD.Value = (short)Bits.GetShort(asc.AnimationData, 4);
                    aniBits.SetItemChecked(0, (asc.Option & 0x01) == 0x01);
                    aniBits.SetItemChecked(1, (asc.Option & 0x02) == 0x02);
                    aniBits.SetItemChecked(2, (asc.Option & 0x04) == 0x04);
                    aniBits.SetItemChecked(3, (asc.Option & 0x20) == 0x20);
                    aniBits.SetItemChecked(4, (asc.Option & 0x40) == 0x40);
                    aniBits.SetItemChecked(5, (asc.Option & 0x80) == 0x80);
                    break;
                case 0x09:
                    aniTitleA.Text = "Jump to address...";
                    aniLabelC.Text = "Address";
                    aniNumC.Maximum = 0xFFFF; aniNumC.Hexadecimal = true; aniNumC.Enabled = true;

                    aniNumC.Value = Bits.GetShort(asc.AnimationData, 1);
                    break;
                case 0x0C:
                    aniTitleA.Text = "Shift current sprite to coords @ action mem $40...";
                    aniLabelA.Text = "Shift type";
                    aniLabelC.Text = "Speed";
                    aniLabelD.Text = "Jump height";

                    aniNameA.Enabled = true;
                    aniNameA.Items.AddRange(new object[] { "{00}", "shift", "transfer", "{04}", "{08}" });
                    aniNumC.Enabled = true; aniNumC.Maximum = 0x7FFF; aniNumC.Minimum = -0x8000;
                    aniNumD.Enabled = true; aniNumD.Maximum = 0x7FFF; aniNumD.Minimum = -0x8000;

                    aniNameA.SelectedIndex = asc.Option / 2;
                    aniNumC.Value = (short)Bits.GetShort(asc.AnimationData, 2);
                    aniNumD.Value = (short)Bits.GetShort(asc.AnimationData, 4);
                    break;
                case 0x10:
                    aniTitleA.Text = "Jump to subroutine...";
                    aniLabelC.Text = "Address";
                    aniNumC.Maximum = 0xFFFF; aniNumC.Hexadecimal = true; aniNumC.Enabled = true;

                    aniNumC.Value = Bits.GetShort(asc.AnimationData, 1);
                    break;
                case 0x20:
                case 0x21:
                    aniTitleA.Text = "Store from source to action mem...";
                    aniLabelB.Text = "Mem addr"; aniLabelC.Text = "Source"; goto case 0x2F;
                case 0x22:
                case 0x23:
                    aniTitleA.Text = "Store from source to action mem...";
                    aniLabelB.Text = "Source"; aniLabelC.Text = "Destination"; goto case 0x2F;
                case 0x2C:
                case 0x2D:
                    aniTitleA.Text = "Add source to object mem..."; goto case 0x2F;
                case 0x2E:
                case 0x2F:
                    if (asc.Opcode == 0x2E || asc.Opcode == 0x2F)
                        aniTitleA.Text = "Subtract source from object mem...";
                    aniLabelB.Text = (asc.Opcode < 0x22) ? "Mem addr" : "Source";
                    aniLabelC.Text = (asc.Opcode < 0x22) ? "Source" : "Destination";
                    aniLabelA.Text = "Source type";

                    aniNameA.Items.AddRange(new object[]{
                        "absolute value",
                        "mem 7E:xxxx (xxxx == source)",
                        "mem 7F:xxxx (xxxx == source)",
                        "AMEM",
                        "OMEM (current)",
                        "mem 7E:0000,x",
                        "OMEM (main)",
                        "{07}",
                        "{08}",
                        "{09}",
                        "{0A}",
                        "{0B}"});
                    aniNameA.Enabled = true;
                    aniNumB.Maximum = 0x0F; aniNumB.Enabled = true; aniNumB.Hexadecimal = true;
                    aniNumC.Maximum = 0xFFFF; aniNumC.Enabled = true; aniNumC.Hexadecimal = true;

                    aniNameA.SelectedIndex = asc.Option >> 4;
                    aniNumB.Value = asc.Option & 0x0F;
                    aniNumC.Value = Bits.GetShort(asc.AnimationData, 2);
                    break;
                case 0x24: aniTitleA.Text = "If value at OMEM == source... (8-bit)"; goto case 0x2B;
                case 0x25: aniTitleA.Text = "If value at OMEM == source... (16-bit)"; goto case 0x2B;
                case 0x26: aniTitleA.Text = "If value at OMEM != source... (8-bit)"; goto case 0x2B;
                case 0x27: aniTitleA.Text = "If value at OMEM != source... (16-bit)"; goto case 0x2B;
                case 0x28: aniTitleA.Text = "If value at OMEM < source... (8-bit)"; goto case 0x2B;
                case 0x29: aniTitleA.Text = "If value at OMEM < source... (16-bit)"; goto case 0x2B;
                case 0x2A: aniTitleA.Text = "If value at OMEM >= source... (8-bit)"; goto case 0x2B;
                case 0x2B:
                    if (asc.Opcode == 0x2B)
                        aniTitleA.Text = "If value at OMEM >= source... (16-bit)";
                    aniLabelA.Text = "Source type";
                    aniLabelB.Text = "Mem addr";
                    aniLabelC.Text = "Source";
                    aniLabelD.Text = "Jump to";

                    aniNameA.Items.AddRange(new object[]{
                        "absolute value",
                        "mem 7E:xxxx (xxxx == source)",
                        "mem 7F:xxxx (xxxx == source)",
                        "AMEM",
                        "OMEM (current)",
                        "mem 7E:0000,x",
                        "OMEM (main)",
                        "{07}",
                        "{08}",
                        "{09}",
                        "{0A}",
                        "{0B}"});
                    aniNameA.Enabled = true;
                    aniNumB.Maximum = 0x0F; aniNumB.Enabled = true; aniNumB.Hexadecimal = true;
                    aniNumC.Maximum = 0xFFFF; aniNumC.Enabled = true; aniNumC.Hexadecimal = true;
                    aniNumD.Maximum = 0xFFFF; aniNumD.Enabled = true; aniNumD.Hexadecimal = true;

                    aniNameA.SelectedIndex = asc.Option >> 4;
                    aniNumB.Value = asc.Option & 0x0F;
                    aniNumC.Value = Bits.GetShort(asc.AnimationData, 2);
                    aniNumD.Value = Bits.GetShort(asc.AnimationData, 4);
                    break;
                case 0x30:
                case 0x31: aniTitleA.Text = "Increment object mem..."; goto case 0x35;
                case 0x32:
                case 0x33: aniTitleA.Text = "Decrement object mem..."; goto case 0x35;
                case 0x34:
                case 0x35:
                    if (asc.Opcode == 0x34 || asc.Opcode == 0x35)
                        aniTitleA.Text = "Clear object mem...";
                    aniLabelC.Text = "Mem addr";

                    aniNumC.Maximum = 0x0F; aniNumC.Hexadecimal = true; aniNumC.Enabled = true;

                    aniNumC.Value = asc.Option & 0x0F;
                    break;
                case 0x36: aniTitleA.Text = "Set obj mem bits..."; goto case 0x37;
                case 0x37:
                    if (asc.Opcode == 0x37)
                        aniTitleA.Text = "Clear object mem bits...";

                    aniLabelC.Text = "Mem addr";
                    aniTitleB.Text = "Bits";

                    aniNumC.Maximum = 0x0F; aniNumC.Hexadecimal = true; aniNumC.Enabled = true;
                    aniBits.Items.AddRange(new object[] { "b0", "b1", "b2", "b3", "b4", "b5", "b6", "b7" });
                    aniBits.Enabled = true;

                    aniNumC.Value = asc.Option & 0x0F;
                    for (int i = 1, j = 0; j < 8; i *= 2, j++)
                        aniBits.SetItemChecked(j, (asc.AnimationData[2] & i) == i);
                    break;
                case 0x38: aniTitleA.Text = "If object mem bits set..."; break;
                case 0x39:
                    if (asc.Opcode == 0x39)
                        aniTitleA.Text = "If object mem bits clear...";

                    aniLabelC.Text = "Mem addr";
                    aniTitleB.Text = "Bits";
                    aniLabelE.Text = "Jump to";

                    aniNumC.Maximum = 0x0F; aniNumC.Hexadecimal = true; aniNumC.Enabled = true;
                    aniBits.Items.AddRange(new object[] { "b0", "b1", "b2", "b3", "b4", "b5", "b6", "b7" });
                    aniBits.Enabled = true;
                    aniNumE.Maximum = 0xFFFF; aniNumE.Enabled = true; aniNumE.Hexadecimal = true;

                    aniNumC.Value = asc.Option & 0x0F;
                    for (int i = 1, j = 0; j < 8; i *= 2, j++)
                        aniBits.SetItemChecked(j, (asc.AnimationData[2] & i) == i);
                    aniNumE.Value = Bits.GetShort(asc.AnimationData, 3);
                    break;
                case 0x40: aniTitleA.Text = "Pause script until object mem bits set..."; goto case 0x41;
                case 0x41:
                    if (asc.Opcode == 0x41)
                        aniTitleA.Text = "Pause script until object mem bits clear...";
                    aniLabelC.Text = "Mem addr";
                    aniTitleB.Text = "Bits";

                    aniNumC.Maximum = 0x0F; aniNumC.Enabled = true; aniNumC.Hexadecimal = true;
                    aniBits.Items.AddRange(new object[] { "b0", "b1", "b2", "b3", "b4", "b5", "b6", "b7" });
                    aniBits.Enabled = true;

                    aniNumC.Value = asc.Option;
                    for (int i = 1, j = 0; j < 8; i *= 2, j++)
                        aniBits.SetItemChecked(j, (asc.AnimationData[2] & i) == i);
                    break;
                case 0x43:
                    aniTitleA.Text = "Playback sprite sequence for current object...";
                    aniLabelC.Text = "Sequence";
                    aniTitleB.Text = "Properties...";

                    aniNumC.Maximum = 0x0F; aniNumC.Enabled = true;
                    aniBits.Items.AddRange(new object[] { "infinite playback", "playback once", "b6", "mirror" });
                    aniBits.Enabled = true;

                    aniNumC.Value = asc.Option & 0x0F;
                    for (int i = 0x10, j = 0; j < 4; i *= 2, j++)
                        aniBits.SetItemChecked(j, (asc.Option & i) == i);
                    break;
                case 0x5D:
                    aniTitleA.Text = "Run object queue at address...";
                    aniTitleB.Text = "Object type...";
                    aniLabelC.Text = "Object #";
                    aniLabelD.Text = "Address";

                    aniNumC.Maximum = 0x0F; aniNumC.Hexadecimal = true; aniNumC.Enabled = true;
                    aniNumD.Maximum = 0xFFFF; aniNumD.Hexadecimal = true; aniNumD.Enabled = true;
                    aniBits.Items.AddRange(new object[] { 
                        "b0", "b1", "b2", "character slot", 
                        "b4", "b5", "current target", "b7" });
                    aniBits.Enabled = true;

                    for (int i = 1, j = 0; j < 8; i *= 2, j++)
                        aniBits.SetItemChecked(j, (asc.Option & i) == i);
                    aniNumC.Value = asc.AnimationData[2];
                    aniNumD.Value = Bits.GetShort(asc.AnimationData, 3);
                    break;
                case 0x63:
                    aniTitleA.Text = "Run dialogue message...";
                    aniLabelA.Text = "Type";

                    aniNameA.Items.AddRange(new object[] { "attack name", "spell name", "item name" });
                    aniNameA.Enabled = true;

                    aniNameA.SelectedIndex = asc.Option;
                    break;
                case 0x64:
                    aniTitleA.Text = "Run synchronous code packet from OMEM $60 at...";
                    aniLabelC.Text = "Address";

                    aniNumC.Hexadecimal = true; aniNumC.Maximum = 0xFFFF; aniNumC.Enabled = true;

                    aniNumC.Value = Bits.GetShort(asc.AnimationData, 1);
                    break;
                case 0x68:
                    aniTitleA.Text = "Run synchronous code packet from OMEM $60 at...";
                    aniLabelC.Text = "Address";
                    aniLabelD.Text = "Sub-packet";

                    aniNumC.Hexadecimal = true; aniNumC.Maximum = 0xFFFF; aniNumC.Enabled = true;
                    aniNumD.Maximum = 255; aniNumD.Enabled = true;

                    aniNumC.Value = Bits.GetShort(asc.AnimationData, 1);
                    aniNumD.Value = asc.AnimationData[3];
                    break;
                case 0x6A:
                case 0x6B:
                    aniTitleA.Text = "Store random # between 0 and value to object mem...";
                    aniLabelC.Text = "Mem addr";
                    aniLabelD.Text = "Value";

                    aniNumC.Maximum = 0x0F; aniNumC.Hexadecimal = true; aniNumC.Enabled = true;
                    aniNumD.Maximum = asc.Opcode == 0x6A ? 0xFF : 0xFFFF; aniNumD.Enabled = true;

                    aniNumC.Value = asc.Option;
                    aniNumD.Value = asc.Opcode == 0x6A ? asc.AnimationData[2] : Bits.GetShort(asc.AnimationData, 2);
                    break;
                case 0x72:
                    aniTitleA.Text = "Start spell effect...";
                    aniLabelA.Text = "Effect";
                    aniTitleB.Text = "Properties...";

                    aniNameA.Items.AddRange(Lists.Numerize(Lists.EffectNames));
                    aniNameA.Enabled = true;
                    aniBits.Items.AddRange(new object[]{
                        "infinite seq playback","show only 1st frame","playback once","b3"});
                    aniBits.Enabled = true;

                    aniNameA.SelectedIndex = asc.AnimationData[2];
                    for (int i = 1, j = 0; j < 4; i *= 2, j++)
                        aniBits.SetItemChecked(j, (asc.Option & i) == i);
                    break;
                case 0x74:
                case 0x75:
                    aniTitleA.Text = "Pause script until bits ";
                    aniTitleA.Text += asc.Opcode == 0x74 ? "set..." : "clear...";
                    aniLabelC.Text = "Bits";

                    aniNumC.Maximum = 0xFFFF; aniNumC.Hexadecimal = true; aniNumC.Enabled = true;

                    aniNumC.Value = Bits.GetShort(asc.AnimationData, 1);
                    break;
                case 0x77:
                    aniTitleA.Text = "Set obj graphic properties...";
                    aniLabelA.Text = "Overlap";
                    aniTitleB.Text = "Properties...";

                    aniNameA.Items.AddRange(new object[] { 
                        "no transparency", "overlap all", "overlap none", "overlap all, not ally sprites" });
                    aniNameA.Enabled = true;
                    aniBits.Items.AddRange(new object[]{
                        "b0","4bpp","2bpp","b3"});
                    aniBits.Enabled = true;

                    aniNameA.SelectedIndex = asc.Option >> 4;
                    for (int i = 1, j = 0; j < 4; i *= 2, j++)
                        aniBits.SetItemChecked(j, (asc.Option & i) == i);
                    break;
                case 0x78:
                    aniTitleA.Text = "Set obj layer priority...";
                    aniLabelC.Text = "Low bits";
                    aniLabelD.Text = "High bits";

                    aniNumC.Maximum = 15; aniNumC.Enabled = true;
                    aniNumD.Maximum = 15; aniNumD.Enabled = true;

                    aniNumC.Value = asc.Option & 0x0F;
                    aniNumD.Value = asc.Option >> 4;
                    break;
                case 0x7A:
                    aniTitleA.Text = "Run dialogue...";
                    aniLabelA.Text = "Type";
                    aniLabelC.Text = "Dialogue";

                    aniNameA.Items.AddRange(new object[] { "battle dialogue", "psychopath message", "special dialogue" });
                    aniNameA.Enabled = true;
                    aniNumC.Enabled = true;

                    aniNameA.SelectedIndex = asc.Option & 3;
                    aniNumC.Value = asc.AnimationData[2];
                    break;
                case 0x7E:
                    aniTitleA.Text = "Fade out object...";
                    aniLabelC.Text = "Duration";

                    aniNumC.Enabled = true;
                    aniNumC.Value = asc.Option;
                    break;
                case 0x85:
                    aniTitleA.Text = "Fade effect on object...";
                    aniLabelA.Text = "Type";
                    aniLabelB.Text = "Object";
                    aniLabelC.Text = "Duration";

                    aniNameA.Items.AddRange(new object[] { "fade out", "fade in" }); aniNameA.Enabled = true;
                    aniNameB.Items.AddRange(new object[] { "{00}", "{01}", "screen" }); aniNameB.Enabled = true;
                    aniNumC.Enabled = true;

                    aniNameA.SelectedIndex = (asc.Option & 0x0F) >> 1;
                    aniNameB.SelectedIndex = asc.Option >> 4;
                    aniNumC.Value = asc.AnimationData[2];
                    break;
                case 0x8E:
                case 0x8F:
                    aniTitleA.Text = "Screen flash color...";
                    aniLabelA.Text = "Color";
                    aniLabelC.Text = "Duration";

                    aniNameA.Items.AddRange(new object[] { 
                        "{none}", "red", "green", "yellow", "blue", "pink", "aqua", "white" });
                    aniNameA.Enabled = true;
                    aniNameA.SelectedIndex = asc.Option & 0x07;

                    if (asc.Opcode == 0x8E)
                    {
                        aniNumC.Enabled = true;
                        aniNumC.Value = asc.AnimationData[2];
                    }
                    break;
                case 0xAB:
                case 0xAE:
                    aniTitleA.Text = "Playback sound effect";
                    aniTitleA.Text += asc.Opcode == 0xAB ? "..." : " (sync)...";
                    aniLabelA.Text = "Sound";

                    aniNameA.Items.AddRange(Lists.Numerize(Lists.BattleSoundNames));
                    aniNameA.Enabled = true;

                    aniNameA.SelectedIndex = asc.Option;
                    break;
                case 0xB0:
                    aniTitleA.Text = "Playback music";
                    aniLabelA.Text = "Music";

                    aniNameA.Items.AddRange(Lists.Numerize(Lists.MusicNames));
                    aniNameA.Enabled = true;

                    aniNameA.SelectedIndex = asc.Option;
                    break;
                case 0xB1:
                    aniTitleA.Text = "Playback music";
                    aniLabelA.Text = "Music";

                    aniNameA.Items.AddRange(Lists.Numerize(Lists.MusicNames));
                    aniNameA.Enabled = true;
                    aniNumC.Enabled = true; aniNumC.Maximum = 0xFFFF;

                    aniNameA.SelectedIndex = asc.Option;
                    aniNumC.Value = Bits.GetShort(asc.AnimationData, 2);
                    break;
                case 0xB6:
                    aniTitleA.Text = "Fade out current music...";
                    aniLabelC.Text = "Speed";
                    aniLabelD.Text = "Volume";

                    aniNumC.Enabled = true;
                    aniNumD.Enabled = true;

                    aniNumC.Value = asc.Option;
                    aniNumD.Value = asc.AnimationData[2];
                    break;
                case 0xBB:
                    aniTitleA.Text = "Set target...";
                    aniLabelA.Text = "Target";
                    aniNameA.Items.AddRange(Lists.TargetNames);
                    aniNameA.Enabled = true;

                    aniNameA.SelectedIndex = asc.Option;
                    break;
                case 0xBC:
                case 0xBD:
                    aniTitleA.Text = asc.Opcode == 0xBC ?
                        "Store / remove item to item inventory..." : "Store / remove item to special item inventory...";
                    aniLabelA.Text = "Item";

                    aniNameA.Items.AddRange(Model.ItemNames.GetNames());
                    aniNameA.Enabled = true;
                    aniNumA.Maximum = 0xB0; aniNumA.Enabled = true;
                    aniBits.Items.Add("remove"); aniBits.Enabled = true;

                    aniNameA.SelectedIndex = Model.ItemNames.GetIndexFromNum(
                        Math.Abs((short)Bits.GetShort(asc.AnimationData, 1)));
                    aniNumA.Value = Math.Abs((short)Bits.GetShort(asc.AnimationData, 1));
                    aniBits.SetItemChecked(0, asc.AnimationData[2] == 0xFF);
                    break;
                case 0xBE:
                    aniTitleA.Text = "Add value to current coins...";
                    aniLabelC.Text = "Value";

                    aniNumC.Maximum = 0xFFFF; aniNumC.Enabled = true;

                    aniNumC.Value = Bits.GetShort(asc.AnimationData, 1);
                    break;
                case 0xBF:
                    aniTitleA.Text = "Store target's Yoshi Cookie to item inventory...";
                    aniLabelA.Text = "Target";

                    aniNameA.Items.AddRange(Lists.TargetNames);
                    aniNameA.Enabled = true;

                    aniNameA.SelectedIndex = asc.Option;
                    break;
                case 0xC3:
                    aniTitleA.Text = "Mask effect...";
                    aniLabelC.Text = "Mask";

                    aniNumC.Enabled = true;

                    aniNumC.Value = asc.Option;
                    break;
                case 0xCB:
                    aniTitleA.Text = "Sprite playback speed...";
                    aniLabelC.Text = "Speed";

                    aniNumC.Maximum = 15; aniNumC.Enabled = true;

                    aniNumC.Value = asc.Option;
                    break;
                case 0xE1:
                    aniTitleA.Text = "Run battle event...";
                    aniLabelC.Text = "Event #";
                    aniLabelD.Text = "Offset";

                    aniNumC.Maximum = 0xFFFF;
                    aniNumC.Enabled = true;
                    aniNumD.Enabled = true;

                    aniNumC.Value = Bits.GetShort(asc.AnimationData, 1);
                    aniNumD.Value = asc.AnimationData[2];
                    break;
            }

            updatingAnimations = false;
        }
        private void ControlAniAsmMethod()
        {
            switch (asc.Opcode)
            {
                case 0x00:
                    Bits.SetShort(asc.AnimationData, 3, (ushort)aniNumA.Value);
                    asc.AnimationData[5] = (byte)aniNumC.Value;
                    Bits.SetShort(asc.AnimationData, 7, (ushort)aniNumD.Value);
                    Bits.SetBit(asc.AnimationData, 1, 0, aniBits.GetItemChecked(0));
                    Bits.SetBit(asc.AnimationData, 2, 3, aniBits.GetItemChecked(1));
                    Bits.SetBit(asc.AnimationData, 2, 5, aniBits.GetItemChecked(2));
                    Bits.SetBit(asc.AnimationData, 6, 4, aniBits.GetItemChecked(3));
                    Bits.SetBit(asc.AnimationData, 6, 6, aniBits.GetItemChecked(4));
                    Bits.SetBit(asc.AnimationData, 6, 7, aniBits.GetItemChecked(5));
                    break;
                case 0x01:
                case 0x0B:
                    asc.Option = (byte)(aniNameA.SelectedIndex << 4);
                    Bits.SetBit(asc.AnimationData, 1, 0, aniBits.GetItemChecked(0));
                    Bits.SetBit(asc.AnimationData, 1, 1, aniBits.GetItemChecked(1));
                    Bits.SetBit(asc.AnimationData, 1, 2, aniBits.GetItemChecked(2));
                    Bits.SetShort(asc.AnimationData, 2, (ushort)((short)aniNumC.Value));
                    Bits.SetShort(asc.AnimationData, 4, (ushort)((short)aniNumD.Value));
                    Bits.SetShort(asc.AnimationData, 6, (ushort)((short)aniNumB.Value));
                    break;
                case 0x03:
                    Bits.SetShort(asc.AnimationData, 3, (ushort)aniNumA.Value);
                    asc.AnimationData[5] = (byte)aniNumC.Value;
                    Bits.SetBit(asc.AnimationData, 1, 0, aniBits.GetItemChecked(0));
                    Bits.SetBit(asc.AnimationData, 2, 3, aniBits.GetItemChecked(1));
                    Bits.SetBit(asc.AnimationData, 2, 5, aniBits.GetItemChecked(2));
                    break;
                case 0x04:
                    asc.Option = (byte)aniNameA.SelectedIndex;
                    Bits.SetShort(asc.AnimationData, 2, (ushort)aniNumC.Value);
                    break;
                case 0x08:
                    Bits.SetBit(asc.AnimationData, 1, 0, aniBits.GetItemChecked(0));
                    Bits.SetBit(asc.AnimationData, 1, 1, aniBits.GetItemChecked(1));
                    Bits.SetBit(asc.AnimationData, 1, 2, aniBits.GetItemChecked(2));
                    Bits.SetBit(asc.AnimationData, 1, 5, aniBits.GetItemChecked(3));
                    Bits.SetBit(asc.AnimationData, 1, 6, aniBits.GetItemChecked(4));
                    Bits.SetBit(asc.AnimationData, 1, 7, aniBits.GetItemChecked(5));
                    Bits.SetShort(asc.AnimationData, 2, (ushort)((short)aniNumC.Value));
                    Bits.SetShort(asc.AnimationData, 4, (ushort)((short)aniNumD.Value));
                    Bits.SetShort(asc.AnimationData, 6, (ushort)((short)aniNumB.Value));
                    break;
                case 0x09:
                case 0x10:
                case 0x64:
                    Bits.SetShort(asc.AnimationData, 1, (ushort)aniNumC.Value);
                    break;
                case 0x0C:
                    asc.Option = (byte)(aniNameA.SelectedIndex * 2);
                    Bits.SetShort(asc.AnimationData, 2, (ushort)((short)aniNumC.Value));
                    Bits.SetShort(asc.AnimationData, 4, (ushort)((short)aniNumD.Value));
                    break;
                case 0x20:
                case 0x21:
                case 0x22:
                case 0x23:
                case 0x2C:
                case 0x2D:
                case 0x2E:
                case 0x2F:
                    asc.Option = (byte)aniNumB.Value;
                    asc.Option |= (byte)(aniNameA.SelectedIndex << 4);
                    Bits.SetShort(asc.AnimationData, 2, (ushort)aniNumC.Value);
                    break;
                case 0x24:
                case 0x25:
                case 0x26:
                case 0x27:
                case 0x28:
                case 0x29:
                case 0x2A:
                case 0x2B:
                    Bits.SetShort(asc.AnimationData, 4, (ushort)aniNumD.Value); goto case 0x23;
                case 0x30:
                case 0x31:
                case 0x32:
                case 0x33:
                case 0x34:
                case 0x35:
                case 0x7E:
                    asc.Option = (byte)aniNumC.Value; break;
                case 0x36:
                case 0x37:
                    asc.Option = (byte)aniNumC.Value;
                    for (int i = 1, j = 0; j < 8; i *= 2, j++)
                        Bits.SetBit(asc.AnimationData, 2, j, aniBits.GetItemChecked(j));
                    break;
                case 0x38:
                case 0x39:
                    asc.Option = (byte)aniNumC.Value;
                    for (int i = 1, j = 0; j < 8; i *= 2, j++)
                        Bits.SetBit(asc.AnimationData, 2, j, aniBits.GetItemChecked(j));
                    Bits.SetShort(asc.AnimationData, 3, (ushort)aniNumE.Value);
                    break;
                case 0x40:
                case 0x41:
                    asc.Option = (byte)aniNumC.Value;
                    for (int i = 1, j = 0; j < 8; i *= 2, j++)
                        Bits.SetBit(asc.AnimationData, 2, j, aniBits.GetItemChecked(j));
                    break;
                case 0x43:
                    asc.Option = (byte)aniNumC.Value;
                    for (int i = 0, j = 0; j < 4; i++, j++)
                        Bits.SetBit(asc.AnimationData, 1, j + 4, aniBits.GetItemChecked(j));
                    break;
                case 0x5D:
                    for (int i = 1, j = 0; j < 8; i *= 2, j++)
                        Bits.SetBit(asc.AnimationData, 1, j, aniBits.GetItemChecked(j));
                    asc.AnimationData[2] = (byte)aniNumC.Value;
                    Bits.SetShort(asc.AnimationData, 3, (ushort)aniNumD.Value);
                    break;
                case 0x63:
                    asc.Option = (byte)aniNameA.SelectedIndex;
                    break;
                case 0x68:
                    Bits.SetShort(asc.AnimationData, 1, (ushort)aniNumC.Value);
                    asc.AnimationData[3] = (byte)aniNumD.Value;
                    break;
                case 0x6A:
                case 0x6B:
                    asc.Option = (byte)aniNumC.Value;
                    if (asc.Opcode == 0x6B)
                        Bits.SetShort(asc.AnimationData, 2, (ushort)aniNumD.Value);
                    else
                        asc.AnimationData[2] = (byte)aniNumD.Value;
                    break;
                case 0x72:
                    asc.AnimationData[2] = (byte)aniNameA.SelectedIndex;
                    for (int i = 1, j = 0; j < 4; i *= 2, j++)
                        Bits.SetBit(asc.AnimationData, 1, j, aniBits.GetItemChecked(j));
                    break;
                case 0x74:
                case 0x75:
                    Bits.SetShort(asc.AnimationData, 1, (ushort)aniNumC.Value);
                    break;
                case 0x77:
                    asc.Option = (byte)(aniNameA.SelectedIndex << 4);
                    for (int i = 1, j = 0; j < 4; i *= 2, j++)
                        Bits.SetBit(asc.AnimationData, 1, j, aniBits.GetItemChecked(j));
                    break;
                case 0x78:
                    asc.Option = (byte)aniNumC.Value;
                    asc.Option |= (byte)((byte)aniNumD.Value << 4);
                    break;
                case 0x7A:
                    asc.Option = (byte)aniNameA.SelectedIndex;
                    asc.AnimationData[2] = (byte)aniNumC.Value;
                    break;
                case 0x85:
                    asc.Option = (byte)(aniNameA.SelectedIndex << 1);
                    asc.Option |= (byte)(aniNameB.SelectedIndex << 4);
                    asc.AnimationData[2] = (byte)aniNumC.Value;
                    break;
                case 0x8E:
                    asc.Option = (byte)aniNameA.SelectedIndex;
                    asc.AnimationData[2] = (byte)aniNumC.Value;
                    break;
                case 0xAB:
                case 0xAE:
                    asc.Option = (byte)aniNameA.SelectedIndex;
                    break;
                case 0xB0:
                    asc.Option = (byte)aniNameA.SelectedIndex;
                    break;
                case 0xB1:
                    asc.Option = (byte)aniNameA.SelectedIndex;
                    Bits.SetShort(asc.AnimationData, 2, (ushort)aniNumC.Value);
                    break;
                case 0xB6:
                    asc.Option = (byte)aniNumC.Value;
                    asc.AnimationData[2] = (byte)aniNumD.Value;
                    break;
                case 0xBB:
                case 0xBF:
                    asc.Option = (byte)aniNameA.SelectedIndex;
                    break;
                case 0xBC:
                case 0xBD:
                    short temp = (short)(-(ushort)aniNumA.Value);
                    if (aniBits.GetItemChecked(0))
                        Bits.SetShort(asc.AnimationData, 1, (ushort)temp);
                    else
                        Bits.SetShort(asc.AnimationData, 1, (ushort)aniNumA.Value);
                    break;
                case 0xBE:
                    Bits.SetShort(asc.AnimationData, 1, (ushort)aniNumC.Value);
                    break;
                case 0xC3:
                case 0xCB:
                    asc.Option = (byte)aniNumC.Value;
                    break;
                case 0xE1:
                    Bits.SetShort(asc.AnimationData, 1, (ushort)aniNumC.Value);
                    asc.AnimationData[3] = (byte)aniNumD.Value;
                    break;
            }
        }
        private void ResetAllAniControls()
        {
            updatingAnimations = true;

            aniNameA.Items.Clear(); aniNameA.ResetText(); aniNameA.Enabled = false;
            aniNameB.Items.Clear(); aniNameB.ResetText(); aniNameB.Enabled = false;
            aniNumA.Maximum = 255; aniNumA.Hexadecimal = false; aniNumA.Value = 0; aniNumA.Enabled = false;
            aniNumB.Maximum = 255; aniNumB.Hexadecimal = false; aniNumB.Value = 0; aniNumB.Enabled = false;
            aniNumC.Maximum = 255; aniNumC.Hexadecimal = false; aniNumC.Minimum = 0; aniNumC.Increment = 1; aniNumC.Value = 0; aniNumC.Enabled = false;
            aniNumD.Maximum = 255; aniNumD.Hexadecimal = false; aniNumD.Minimum = 0; aniNumD.Increment = 1; aniNumD.Value = 0; aniNumD.Enabled = false;
            aniNumE.Maximum = 255; aniNumE.Hexadecimal = false; aniNumE.Value = 0; aniNumE.Enabled = false;
            aniNumF.Maximum = 255; aniNumF.Value = 0; aniNumF.Enabled = false;
            aniBits.ColumnWidth = 138; aniBits.Items.Clear(); aniBits.Enabled = false;

            aniTitleA.Text = "";
            aniTitleC.Text = "";
            aniTitleB.Text = "";
            aniLabelA.Text = "";
            aniLabelB.Text = "";
            aniLabelC.Text = "";
            aniLabelD.Text = "";
            aniLabelE.Text = "";
            aniLabelF.Text = "";

            updatingAnimations = false;
        }

        public void Assemble()
        {
        }
        #endregion
        #region Event Handlers
        private void animationCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingAnimations) return;

            animationNum.Value = 0;
            RefreshAnimationScriptsEditor();
        }
        private void animationNum_ValueChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            animationScripts[(int)animationNum.Value].RefreshAnimationScript();

            if (animationCategory.SelectedIndex == 2)
            {
                animationName.SelectedIndex = Model.AttackNames.GetIndexFromNum(index);
                a_treeViewWrapper.ChangeScript(animationScripts[(int)animationNum.Value]);
            }
            else
            {
                animationName.SelectedIndex = index;
                a_treeViewWrapper.ChangeScript(animationScripts[(int)animationNum.Value]);
            }
            if (this.animationScriptTree.Nodes.Count > 0)
                this.animationScriptTree.SelectedNode = this.animationScriptTree.Nodes[0];
            Cursor.Current = Cursors.Arrow;
        }
        private void animationName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (animationCategory.SelectedIndex == 2)
                animationNum.Value = Model.AttackNames.GetNumFromIndex(animationName.SelectedIndex);
            else
                animationNum.Value = animationName.SelectedIndex;
        }
        private void animationName_DrawItem(object sender, DrawItemEventArgs e)
        {
            Bitmap bgimage = Model.MenuBackground_;
            switch (animationCategory.SelectedIndex)
            {
                case 0: if (e.Index < 0 || e.Index > 53) return; break;
                case 1: if (e.Index < 0 || e.Index > 44) return; break;
                case 2: if (e.Index < 0 || e.Index > 128) return; break;
                case 3: if (e.Index < 0 || e.Index > 15) return; break;
                case 4: if (e.Index < 0 || e.Index > 80) return; break;
                case 5: if (e.Index < 0 || e.Index > 26) return; break;
                case 6: if (e.Index < 0 || e.Index > 35) return; break;
                case 7: if (e.Index < 0 || e.Index > 102) return; break;
            }
            int[] temp;
            if (animationCategory.SelectedIndex == 1 ||
                animationCategory.SelectedIndex == 2 ||
                animationCategory.SelectedIndex == 4 ||
                animationCategory.SelectedIndex == 5 ||
                animationCategory.SelectedIndex == 6)
            {
                char[] arr;

                switch (animationCategory.SelectedIndex)
                {
                    case 1: // monster spells
                        arr = Model.SpellNames.GetNameByNum(e.Index + 0x40).ToCharArray();
                        temp = battleDialoguePreview.GetPreview(Model.FontDialogue, Model.FontPaletteBattle.Palette, arr, false);
                        break;
                    case 2: // monster attacks
                        arr = Model.AttackNames.GetName(e.Index).ToCharArray();
                        temp = battleDialoguePreview.GetPreview(Model.FontDialogue, Model.FontPaletteBattle.Palette, arr, false);
                        break;
                    case 4: // items
                        arr = Model.ItemNames.GetNameByNum(e.Index + 0x60).ToCharArray();
                        temp = menuTextPreview.GetPreview(Model.FontMenu, Model.FontPaletteBattle.Palette, arr, true);
                        break;
                    case 5: // ally spells
                        arr = Model.SpellNames.GetNameByNum(e.Index).ToCharArray();
                        temp = menuTextPreview.GetPreview(Model.FontMenu, Model.FontPaletteBattle.Palette, arr, true);
                        break;
                    case 6: // weapons
                        arr = Model.ItemNames.GetNameByNum(e.Index).ToCharArray();
                        temp = menuTextPreview.GetPreview(Model.FontMenu, Model.FontPaletteBattle.Palette, arr, true);
                        break;
                    default:
                        arr = new char[1];
                        temp = menuTextPreview.GetPreview(Model.FontMenu, Model.FontPaletteBattle.Palette, arr, true); break;
                }

                Rectangle background = new Rectangle(0, e.Index * 15 % bgimage.Height, bgimage.Width, 15);
                e.Graphics.DrawImage(bgimage, e.Bounds.X, e.Bounds.Y, background, GraphicsUnit.Pixel);
                // set the pixels
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    e.DrawBackground();

                int[] pixels;
                Bitmap icon;
                if (animationCategory.SelectedIndex == 1 || animationCategory.SelectedIndex == 2)
                {
                    pixels = new int[256 * 32];
                    for (int y = 2, c = 10; c < 32; y++, c++)
                    {
                        for (int x = 2, a = 8; a < 256; x++, a++)
                            pixels[y * 256 + x] = temp[c * 256 + a];
                    }
                    icon = new Bitmap(Do.PixelsToImage(pixels, 256, 32));
                }
                else
                {
                    pixels = new int[256 * 14];
                    for (int y = 2, c = 0; y < 14; y++, c++)
                    {
                        for (int x = 2, a = 0; x < 256; x++, a++)
                            pixels[y * 256 + x] = temp[c * 256 + a];
                    }
                    icon = new Bitmap(Do.PixelsToImage(pixels, 256, 14));
                }
                e.Graphics.DrawImage(new Bitmap(icon), new Point(e.Bounds.X, e.Bounds.Y));
            }
            else
            {
                e.DrawBackground();
                e.Graphics.DrawString(animationName.Items[e.Index].ToString(), e.Font, new SolidBrush(animationName.ForeColor), e.Bounds);
            }
        }

        private void animationScriptTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //if (asc == (AnimationScriptCommand)e.Node.Tag)
            //    return;
            a_treeViewWrapper.SelectedNode = e.Node;
            asc = (AnimationScriptCommand)e.Node.Tag;

            ToolStripNumericUpDown numUpDown;
            int i = 4;
            for (int a = 0; a < asc.AnimationData.Length && a < 9; a++, i++)
            {
                numUpDown = (ToolStripNumericUpDown)toolStrip2.Items[i];
                numUpDown.Tag = asc;
                numUpDown.Value = asc.AnimationData[a];
                numUpDown.Visible = true;
            }
            for (; i < 4 + 9; i++)
            {
                numUpDown = (ToolStripNumericUpDown)toolStrip2.Items[i];
                numUpDown.Visible = false;
            }
            emptyAnimationMods.Enabled = true;
            applyAnimationMods.Enabled = true;
            aniMoveDown.Enabled = true;
            aniMoveUp.Enabled = true;

            panelAniControls.Enabled = true;
            applyAnimation.Enabled = true;
            ResetAllAniControls();
            ControlAniDisasmMethod();
        }
        private void animationScriptTree_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Control | Keys.Up:
                case Keys.Shift | Keys.Up:
                    aniMoveUp_Click(null, null);
                    break;
                case Keys.Control | Keys.Down:
                case Keys.Shift | Keys.Down:
                    aniMoveDown_Click(null, null);
                    break;
            }
        }

        private void aniMoveDown_Click(object sender, EventArgs e)
        {
            a_treeViewWrapper.MoveDown(asc);
        }
        private void aniMoveUp_Click(object sender, EventArgs e)
        {
            a_treeViewWrapper.MoveUp(asc);
        }
        private void applyAnimationMods_Click(object sender, EventArgs e)
        {
            Point p = Do.GetTreeViewScrollPos(animationScriptTree);
            animationScriptTree.BeginUpdate();
            animationScriptTree.EnablePaint = false;

            int tmp = asc.InternalOffset;
            byte[] temp = new byte[asc.AnimationData.Length];
            asc.AnimationData.CopyTo(temp, 0);
            try
            {
                foreach (ToolStripItem item in toolStrip2.Items)
                {
                    if (!item.Visible || item.GetType() != typeof(ToolStripNumericUpDown))
                        continue;
                    ToolStripNumericUpDown numUpDown = (ToolStripNumericUpDown)item;
                    int index = toolStrip2.Items.IndexOf(numUpDown) - 4;
                    // set the new value for the command
                    asc.AnimationData[index] = (byte)numUpDown.Value;
                    Model.Data[asc.InternalOffset + index] = (byte)numUpDown.Value;
                }
                // check multiple instances of command in current script, and change each accordingly
                animationScripts[(int)animationNum.Value].RefreshAnimationScript();

            }
            catch
            {
                for (int i = 0; i < temp.Length; i++)
                    Model.Data[tmp + i] = temp[i];

                // check multiple instances of command in current script, and change each accordingly
                animationScripts[(int)animationNum.Value].RefreshAnimationScript();

                //// redraw the treeview
                //a_treeViewWrapper.ChangeScript(animationScripts[(int)animationNum.Value]);

                MessageBox.Show("Setting this byte to this value causes errors.",
                    "LAZY SHELL");
            }
            finally
            {
                // redraw the treeview
                a_treeViewWrapper.ChangeScript(animationScripts[(int)animationNum.Value], false);
            }

            // set the selected node
            a_treeViewWrapper.SetSelectedNode(asc.InternalOffset);
            p.X = 0;
            Do.SetTreeViewScrollPos(animationScriptTree, p);
            animationScriptTree.EnablePaint = true;
            animationScriptTree.EndUpdate();
        }
        private void emptyAnimationMods_Click(object sender, EventArgs e)
        {
            foreach (ToolStripItem item in toolStrip2.Items)
            {
                if (item.GetType() == typeof(ToolStripNumericUpDown))
                    ((ToolStripNumericUpDown)item).Value = 0x0A;
            }
        }

        private void applyAnimation_Click(object sender, EventArgs e)
        {
            Point p = Do.GetTreeViewScrollPos(animationScriptTree);
            animationScriptTree.BeginUpdate();
            animationScriptTree.EnablePaint = false;

            ControlAniAsmMethod();

            for (int i = 0; i < asc.AnimationData.Length; i++)
                Model.Data[asc.InternalOffset + i] = asc.AnimationData[i];

            // redraw the treeview
            animationScripts[(int)animationNum.Value].RefreshAnimationScript();
            a_treeViewWrapper.ChangeScript(animationScripts[(int)animationNum.Value], false);

            // set the selected node
            a_treeViewWrapper.SetSelectedNode(asc.InternalOffset);
            p.X = 0;
            Do.SetTreeViewScrollPos(animationScriptTree, p);
            animationScriptTree.EnablePaint = true;
            animationScriptTree.EndUpdate();
        }
        private void aniNameA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingAnimations) return;

            switch (asc.Opcode)
            {
                case 0x00:
                case 0x03:
                    aniNumA.Value = aniNameA.SelectedIndex;
                    break;
                case 0xBC:
                case 0xBD:
                    aniNumA.Value = Model.ItemNames.GetNumFromIndex(aniNameA.SelectedIndex);
                    break;
            }
        }
        private void aniNumA_ValueChanged(object sender, EventArgs e)
        {
            if (updatingAnimations) return;

            switch (asc.Opcode)
            {
                case 0x00:
                case 0x03:
                    aniNameA.SelectedIndex = (int)aniNumA.Value;
                    break;
                case 0xBC:
                case 0xBD:
                    aniNameA.SelectedIndex = Model.ItemNames.GetIndexFromNum((int)aniNumA.Value);
                    break;
            }
        }

        private void AnimationScripts_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Do.GenerateChecksum(Bits.GetByteArray(Model.Data, 0x350000, 0x10000), Bits.GetByteArray(Model.Data, 0x3A6000, 0xA000)) == this.checksum)
                return;
            DialogResult result = MessageBox.Show("Animations have not been saved.\n\nWould you like to save changes?", "LAZY SHELL", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Assemble();
            }
            else if (result == DialogResult.No)
            {
                Buffer.BlockCopy(animationBank, 0, Model.Data, 0x350000, 0x10000);
                Buffer.BlockCopy(battleBank, 0, Model.Data, 0x3A6000, 0xA000);
                Model.SpellAnimMonsters = null;
                Model.SpellAnimAllies = null;
                Model.AttackAnimations = null;
                Model.ItemAnimations = null;
                Model.BattleEvents = null;
                Model.BehaviorAnimations = null;
                Model.EntranceAnimations = null;
                Model.WeaponAnimations = null;
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }
        }
        private void save_Click(object sender, System.EventArgs e)
        {
            Assemble();
        }
        private void export_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.FileName = "animationScripts.txt";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

            int i = 0;
            StreamWriter evtscr = File.CreateText(saveFileDialog.FileName);
            evtscr.WriteLine("**************");
            evtscr.WriteLine("MONSTER SPELLS");
            evtscr.WriteLine("**************\n");
            foreach (AnimationScript ans in Model.SpellAnimMonsters)
            {
                evtscr.WriteLine("\nMONSTER SPELL [" + i.ToString("d3") + "] " + Model.SpellNames.GetNameByNum(i + 64).Substring(1).Trim() +
                    "------------------------------------------------------------>\n");
                foreach (AnimationScriptCommand asc in ans.Commands)
                {
                    evtscr.Write((asc.Offset).ToString("X6") + ": ");
                    evtscr.Write("{" + BitConverter.ToString(asc.AnimationData) + "}\n");

                    dumpAnimationLoop(asc, evtscr, 1);
                }
                i++;
            }
            i = 0;
            evtscr.WriteLine("\n***********");
            evtscr.WriteLine("ALLY SPELLS");
            evtscr.WriteLine("***********\n");
            foreach (AnimationScript ans in Model.SpellAnimAllies)
            {
                evtscr.WriteLine("\nALLY SPELL [" + i.ToString("d3") + "] " + Model.SpellNames.GetNameByNum(i).Substring(1).Trim() +
                    "------------------------------------------------------------>\n");
                foreach (AnimationScriptCommand asc in ans.Commands)
                {
                    evtscr.Write((asc.Offset).ToString("X6") + ": ");
                    evtscr.Write("{" + BitConverter.ToString(asc.AnimationData) + "}\n");

                    dumpAnimationLoop(asc, evtscr, 1);
                }
                i++;
            }
            i = 0;
            evtscr.WriteLine("\n*******");
            evtscr.WriteLine("ATTACKS");
            evtscr.WriteLine("*******\n");
            foreach (AnimationScript ans in Model.AttackAnimations)
            {
                evtscr.WriteLine("\nATTACK [" + i.ToString("d3") + "] " + Model.AttackNames.GetNameByNum(i).Trim() +
                    "------------------------------------------------------------>\n");
                foreach (AnimationScriptCommand asc in ans.Commands)
                {
                    evtscr.Write((asc.Offset).ToString("X6") + ": ");
                    evtscr.Write("{" + BitConverter.ToString(asc.AnimationData) + "}\n");

                    dumpAnimationLoop(asc, evtscr, 1);
                }
                i++;
            }
            i = 0;
            evtscr.WriteLine("\n*****");
            evtscr.WriteLine("ITEMS");
            evtscr.WriteLine("*****\n");
            foreach (AnimationScript ans in Model.ItemAnimations)
            {
                evtscr.WriteLine("\nITEM [" + i.ToString("d3") + "] " + Model.ItemNames.GetNameByNum(i + 96).Substring(1).Trim() +
                    "------------------------------------------------------------>\n");
                foreach (AnimationScriptCommand asc in ans.Commands)
                {
                    evtscr.Write((asc.Offset).ToString("X6") + ": ");
                    evtscr.Write("{" + BitConverter.ToString(asc.AnimationData) + "}\n");

                    dumpAnimationLoop(asc, evtscr, 1);
                }
                i++;
            }
            i = 0;
            evtscr.WriteLine("\n*************");
            evtscr.WriteLine("BATTLE EVENTS");
            evtscr.WriteLine("*************\n");
            foreach (AnimationScript ans in Model.BattleEvents)
            {
                evtscr.WriteLine("\nBATTLE EVENT [" + i.ToString("d3") + "] " +
                    "------------------------------------------------------------>\n");
                foreach (AnimationScriptCommand asc in ans.Commands)
                {
                    evtscr.Write((asc.Offset).ToString("X6") + ": ");
                    evtscr.Write("{" + BitConverter.ToString(asc.AnimationData) + "}\n");

                    dumpAnimationLoop(asc, evtscr, 1);
                }
                i++;
            }
            i = 0;
            evtscr.WriteLine("\n*********");
            evtscr.WriteLine("BEHAVIORS");
            evtscr.WriteLine("*********\n");
            foreach (AnimationScript ans in Model.BehaviorAnimations)
            {
                evtscr.WriteLine("\nBEHAVIOR [" + i.ToString("d3") + "] " +
                    "------------------------------------------------------------>\n");
                foreach (AnimationScriptCommand asc in ans.Commands)
                {
                    evtscr.Write((asc.Offset).ToString("X6") + ": ");
                    evtscr.Write("{" + BitConverter.ToString(asc.AnimationData) + "}\n");

                    dumpAnimationLoop(asc, evtscr, 1);
                }
                i++;
            }
            i = 0;
            evtscr.WriteLine("\n*********");
            evtscr.WriteLine("ENTRANCES");
            evtscr.WriteLine("*********\n");
            foreach (AnimationScript ans in Model.EntranceAnimations)
            {
                evtscr.WriteLine("\nENTRANCE [" + i.ToString("d3") + "] " +
                    "------------------------------------------------------------>\n");
                foreach (AnimationScriptCommand asc in ans.Commands)
                {
                    evtscr.Write((asc.Offset).ToString("X6") + ": ");
                    evtscr.Write("{" + BitConverter.ToString(asc.AnimationData) + "}\n");

                    dumpAnimationLoop(asc, evtscr, 1);
                }
                i++;
            }
            i = 0;
            evtscr.WriteLine("\n*******");
            evtscr.WriteLine("WEAPONS");
            evtscr.WriteLine("*******\n");
            foreach (AnimationScript ans in Model.WeaponAnimations)
            {
                evtscr.WriteLine("\nWEAPON [" + i.ToString("d3") + "] " + Model.ItemNames.GetNameByNum(i).Substring(1).Trim() +
                    "------------------------------------------------------------>\n");
                foreach (AnimationScriptCommand asc in ans.Commands)
                {
                    evtscr.Write((asc.Offset).ToString("X6") + ": ");
                    evtscr.Write("{" + BitConverter.ToString(asc.AnimationData) + "}\n");

                    dumpAnimationLoop(asc, evtscr, 1);
                }
                i++;
            }
        }
        private void dumpAnimationLoop(AnimationScriptCommand com, StreamWriter evtscr, int level)
        {
            foreach (AnimationScriptCommand asc in com.Commands)
            {
                for (int i = 0; i < level; i++)
                    evtscr.Write("\t");

                evtscr.Write((asc.Offset).ToString("X6") + ": ");
                evtscr.Write("{" + BitConverter.ToString(asc.AnimationData) + "}\n");

                dumpAnimationLoop(asc, evtscr, level + 1);
            }
        }
        #endregion
    }
}
