using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using SMRPGED.ScriptsEditor.Commands;

namespace SMRPGED.ScriptsEditor
{
    public partial class Scripts : Form
    {
        #region Variables
        A_TreeViewWrapper a_treeViewWrapper;
        AnimationScript[] animationScripts;
        AnimationScriptCommand asc;

        int a_currentScript = 0;
        private SMRPGED.Previewer.MenuTextPreview menuTextPreview;
        private FontCharacter[] menuCharacters;

        #region Spell Effect Names
        private string[] BattleSoundNames = new string[]
        {
            "[000]  ____",
            "[001]  select action/menu",
            "[002]  cancel action/menu",
            "[003]  move cursor",
            "[004]  Mario's jump",
            "[005]  birdie tweet",
            "[006]  flower bonus/status up",
            "[007]  error/incorrect answer",
            "[008]  get dizzy",
            "[009]  arrow sling",
            "[010]  punch",
            "[011]  swoosh/run away",
            "[012]  bomb explosion",
            "[013]  coin",
            "[014]  grab flower",
            "[015]  spike strike",
            "[016]  bite",
            "[017]  falling stars (electroshock?)",
            "[018]  shell kick",
            "[019]  Drain Beam",
            "[020]  Aurora Flash",
            "[021]  wing flaps",
            "[022]  Electroshock shock",
            "[023]  small laser?",
            "[024]  ____",
            "[025]  wing hit",
            "[026]  Flame Wall",
            "[027]  grab item/1-UP",
            "[028]  Flame",
            "[029]  Drain",
            "[030]  Fire Orb multiple orb hit",
            "[031]  Fire Orb background burn",
            "[032]  Fire Orb finish",
            "[033]  kick?",
            "[034]  spike shot",
            "[035]  Bombs Away power up",
            "[036]  Snowy gathering snow",
            "[037]  monster/item toss",
            "[038]  hit by tossed item",
            "[039]  claw strike",
            "[040]  K-9 fang hit",
            "[041]  Hammer Bro hammer hit",
            "[042]  Johnnys Skewer strike",
            "[043]  casting a spell",
            "[044]  Thunderbolt second strike",
            "[045]  HP Rain cloud",
            "[046]  bounce",
            "[047]  dry clunk",
            "[048]  Marios punch",
            "[049]  cymbal crash",
            "[050]  tiny shell hit",
            "[051]  Super Flame multiple orb hit",
            "[052]  Finger Shot/Bullets",
            "[053]  Thwomp hit ground",
            "[054]  hammer hit from Hammer Time",
            "[055]  Marios hammer hit",
            "[056]  super/ultra jump 1-UP sound",
            "[057]  Water Blast spout?",
            "[058]  Marios shell kick up",
            "[059]  Marios shell kick forward",
            "[060]  cymbal resonance",
            "[061]  use item",
            "[062]  monster run away",
            "[063]  ignition from Geno Blast",
            "[064]  egg hatch",
            "[065]  Yoshi cant make cookie",
            "[066]  Recover HP/MP",
            "[067]  stars?",
            "[068]  rain cloud",
            "[069]  Geno power up",
            "[070]  Geno Beam",
            "[071]  drum roll (Psycopath/Roulette)",
            "[072]  rain cloud appears",
            "[073]  correct password",
            "[074]  quack?",
            "[075]  Yoshi talk",
            "[076]  Yoshi make item",
            "[077]  stat boost (Geno Boost)",
            "[078]  timed stat boost",
            "[079]  rumble",
            "[080]  hit",
            "[081]  hit",
            "[082]  big hit",
            "[083]  Dry Bones hit",
            "[084]  big hit",
            "[085]  Jinxs Triple Kick kick",
            "[086]  long fall",
            "[087]  Lazy Shell kick",
            "[088]  ticking bomb",
            "[089]  enemy defeated (common explosion)",
            "[090]  valor up?",
            "[091]  ____",
            "[092]  fall",
            "[093]  Shocker 1",
            "[094]  Shocker 2",
            "[095]  Bowsers Crusher?",
            "[096]  Boulder",
            "[097]  toss",
            "[098]  click",
            "[099]  Willy Wisp",
            "[100]  Electroshock sparks",
            "[101]  electricity?",
            "[102]  Static E!",
            "[103]  Crystal hits",
            "[104]  Blizzard",
            "[105]  Rock Candy",
            "[106]  Light Beam",
            "[107]  squeak then hit?",
            "[108]  howl",
            "[109]  bullet shot",
            "[110]  huge explosion",
            "[111]  Heavy Troopa land?",
            "[112]  swing",
            "[113]  shot",
            "[114]  Spikey attack",
            "[115]  hit",
            "[116]  Terrapin hit",
            "[117]  sting?",
            "[118]  jolt?",
            "[119]  Meteor Swarm/Snowy",
            "[120]  deep swallow",
            "[121]  big swing",
            "[122]  arrow shot?",
            "[123]  Chomp bite",
            "[124]  Goomba run forward",
            "[125]  spike shot",
            "[126]  big object bounces",
            "[127]  ???",
            "[128]  Lil Boo approaches",
            "[129]  throw?",
            "[130]  Valor Up/Vigor Up",
            "[131]  Come Back summon star?",
            "[132]  little beep",
            "[133]  lullaby",
            "[134]  hit",
            "[135]  hit",
            "[136]  Lil Boo approaches",
            "[137]  heavy machine stomp",
            "[138]  Endobubble",
            "[139]  guitar string?",
            "[140]  Come Back star",
            "[141]  lullaby",
            "[142]  tongue noise?",
            "[143]  toss something",
            "[144]  Lightning Orb",
            "[145]  ???",
            "[146]  slap",
            "[147]  ____",
            "[148]  finger shot/arm cannon",
            "[149]  enemy jumps high",
            "[150]  enemy taunts then hits",
            "[151]  spores",
            "[152]  hit",
            "[153]  deep weird voice",
            "[154]  buzzing bee",
            "[155]  Sparky hit",
            "[156]  Chomp bite",
            "[157]  weird enemy hit",
            "[158]  tongue swing?",
            "[159]  big deep hit",
            "[160]  wing slap",
            "[161]  ____",
            "[162]  ____",
            "[163]  ____",
            "[164]  ____",
            "[165]  ____",
            "[166]  ____",
            "[167]  ____",
            "[168]  ____",
            "[169]  ____",
            "[170]  ____",
            "[171]  ____",
            "[172]  ____",
            "[173]  ____",
            "[174]  ____",
            "[175]  ____",
            "[176]  fade-out",
            "[177]  ____",
            "[178]  ____",
            "[179]  ____",
            "[180]  ____",
            "[181]  ____",
            "[182]  ____",
            "[183]  ____",
            "[184]  ____",
            "[185]  ____",
            "[186]  ____",
            "[187]  ____",
            "[188]  Petal Blast",
            "[189]  ???",
            "[190]  Come Back",
            "[191]  monster call",
            "[192]  big shell kick",
            "[193]  big shell hit 1",
            "[194]  big shell hit 2",
            "[195]  explosive attack",
            "[196]  hovering attack",
            "[197]  smash",
            "[198]  Ice Rock",
            "[199]  Arrow Rain",
            "[200]  Spear Rain",
            "[201]  Sword Rain",
            "[202]  Corona 1",
            "[203]  Corona 2",
            "[204]  chomping",
            "[205]  Jinxed",
            "[206]  monster swing",
            "[207]  monster taunt",
            "[208]  Smithy Form 1 - light up",
            "[209]  Smithy Form 1 - transform",
            "[210]  Booster Express train horn"
        };
        private string[] spellEffectNames = new string[]{
            "[00]  ___DUMMY",
            "[01]  ___DUMMY",
            "[02]  Thundershock",
            "[03]  Thundershock (BG mask)",
            "[04]  Crusher",
            "[05]  Meteor Blast",
            "[06]  Bolt",
            "[07]  Star Rain",
            "[08]  Flame (fire engulf)",
            "[09]  Mute (balloon)",
            "[0A]  Flame Stone",
            "[0B]  Bowser Crush",
            "[0C]  spell cast spade",
            "[0D]  spell cast heart",
            "[0E]  spell cast club",
            "[0F]  spell cast diamond",
            "[10]  spell cast star",
            "[11]  Terrorize",
            "[12]  Snowy (snow BG, 4bpp)",
            "[13]  Snowy (snow FG, 2bpp)",
            "[14]  Endobubble (black ball/orb)",
            "[15]  ___DUMMY",
            "[16]  Solidify",
            "[17]  ___DUMMY",
            "[18]  ___DUMMY",
            "[19]  Psych Bomb (BG)",
            "[1A]  ___DUMMY",
            "[1B]  Dark Star",
            "[1C]  Willy Wisp (blue orb/ball BG)",
            "[1D]  ___DUMMY",
            "[1E]  ___DUMMY",
            "[1F]  ___DUMMY",
            "[20]  Geno Whirl",
            "[21]  ___DUMMY",
            "[22]  ___DUMMY",
            "[23]  ___DUMMY",
            "[24]  blank white flash (2bpp)",
            "[25]  blank white flash (4bpp)",
            "[26]  Boulder",
            "[27]  black ball/orb",
            "[28]  blank blue flash (2bpp)",
            "[29]  blank red flash (2bpp)",
            "[2A]  blank blue flash (4bpp)",
            "[2B]  blank red flash (4bpp)",
            "[2C]  ___DUMMY",
            "[2D]  black flash (2bpp)",
            "[2E]  black flash (4bpp)",
            "[2F]  Meteor Shower (snow/confetti)",
            "[30]  purple/violet flash (4bpp)",
            "[31]  brown flash (4bpp)",
            "[32]  dark red blast",
            "[33]  dark blue blast",
            "[34]  snow/confetti, green",
            "[35]  light blue blast",
            "[36]  black ball/orb",
            "[37]  red ball/orb",
            "[38]  green ball/orb",
            "[39]  snow/confetti, slate green",
            "[3A]  snow/confetti, red",
            "[3B]  orange/red blast (Fire Bomb)",
            "[3C]  Ice bomb/Solidify BG (blue freeze)",
            "[3D]  Static E! (electric blast)",
            "[3E]  green star bunches",
            "[3F]  blue star bunches",
            "[40]  pink star bunches",
            "[41]  yellow star bunches",
            "[42]  Aurora Flash",
            "[43]  Storm",
            "[44]  Electroshock",
            "[45]  Smithy Treasure Head spell, red",
            "[46]  Smithy Treasure Head spell, green",
            "[47]  Smithy Treasure Head spell, blue",
            "[48]  Smithy Treasure Head spell, yellow",
            "[49]  ___DUMMY",
            "[4A]  ___DUMMY",
            "[4B]  ___DUMMY",
            "[4C]  Flame Wall (orange/red fire)",
            "[4D]  Petal Blast 1",
            "[4E]  Petal Blast 2",
            "[4F]  Drain Beam BG (4bpp)",
            "[50]  Drain Beam FG (2bpp)",
            "[51]  ___DUMMY",
            "[52]  electric bolt",
            "[53]  black flash (2bpp)",
            "[54]  ___DUMMY",
            "[55]  Pollen Nap (yellow pollen)",
            "[56]  Geno Beam, blue",
            "[57]  Geno Beam, red",
            "[58]  Geno Beam, gold",
            "[59]  Geno Beam, yellow",
            "[5A]  Geno Beam, green",
            "[5B]  Thunderbolt",
            "[5C]  Light Beam",
            "[5D]  Meteor Shower",
            "[5E]  S\'Crow Dust (purple pollen)",
            "[5F]  HP Rain BG",
            "[60]  HP Rain FG",
            "[61]  wavy dark blue lines",
            "[62]  wavy blue lines",
            "[63]  wavy red lines",
            "[64]  wavy brown lines",
            "[65]  Sand Storm",
            "[66]  Sledge",
            "[67]  Arrow Rain",
            "[68]  Spear Rain",
            "[69]  Sword Rain",
            "[6A]  Lightning Orb (BG waves)",
            "[6B]  Echofinder",
            "[6C]  Poison Gas FG 1",
            "[6D]  Poison Gas FG 2",
            "[6E]  Poison Gas BG",
            "[6F]  Smithy Transforms (beam effect)",
            "[70]  Smelter\'s molten metal",
            "[71]  ___DUMMY",
            "[72]  ___DUMMY",
            "[73]  ___DUMMY",
            "[74]  ___DUMMY",
            "[75]  ___DUMMY",
            "[76]  ___DUMMY",
            "[77]  ___DUMMY",
            "[78]  ___DUMMY",
            "[79]  ___DUMMY",
            "[7A]  ___DUMMY",
            "[7B]  ___DUMMY",
            "[7C]  ___DUMMY",
            "[7D]  ___DUMMY",
            "[7E]  ___DUMMY",
            "[7F]  ___DUMMY"};
        #endregion

        private byte[] animationBank, battleBank;
        private bool updatingAnimations = false;
        #endregion

        #region Methods
        private void InitializeAnimationScriptsEditor()
        {
            updatingAnimations = true;

            animationBank = BitManager.GetByteArray(data, 0x350000, 0x10000);
            battleBank = BitManager.GetByteArray(data, 0x3A6000, 0xA000);

            this.menuCharacters = scriptsModel.MenuCharacters;
            this.menuTextPreview = new SMRPGED.Previewer.MenuTextPreview();

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
                    animationNum.Maximum = animationScripts.Length - 1;
                    break;
                case 1:
                    a_treeViewWrapper.ChangeScript(animationScripts[(int)animationNum.Value]);
                    animationName.Items.Clear();
                    for (int i = 0; i < animationScripts.Length; i++)
                        this.animationName.Items.Add(universal.SpellNames.GetNameByNum(i + 0x40));
                    animationNum.Maximum = animationScripts.Length - 1;
                    break;
                case 2:
                    a_treeViewWrapper.ChangeScript(animationScripts[(int)animationNum.Value]);
                    animationName.Items.Clear();
                    this.animationName.Items.AddRange(universal.AttackNames.Names);
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
                    animationNum.Maximum = animationScripts.Length - 1;
                    break;
                case 4:
                    a_treeViewWrapper.ChangeScript(animationScripts[(int)animationNum.Value]);
                    animationName.Items.Clear();
                    for (int i = 0; i < animationScripts.Length; i++)
                        this.animationName.Items.Add(universal.ItemNames.GetNameByNum(i + 0x60));
                    animationNum.Maximum = animationScripts.Length - 1;
                    break;
                case 5:
                    a_treeViewWrapper.ChangeScript(animationScripts[(int)animationNum.Value]);
                    animationName.Items.Clear();
                    for (int i = 0; i < animationScripts.Length; i++)
                        this.animationName.Items.Add(universal.SpellNames.GetNameByNum(i));
                    animationNum.Maximum = animationScripts.Length - 1;
                    break;
                case 6:
                    a_treeViewWrapper.ChangeScript(animationScripts[(int)animationNum.Value]);
                    animationName.Items.Clear();
                    for (int i = 0; i < animationScripts.Length; i++)
                        this.animationName.Items.Add(universal.ItemNames.GetNameByNum(i));
                    animationNum.Maximum = animationScripts.Length - 1;
                    break;
                case 7:
                    a_treeViewWrapper.ChangeScript(animationScripts[(int)animationNum.Value]);
                    animationName.Items.Clear();
                    for (int i = 0; i < animationScripts.Length; i++)
                        this.animationName.Items.Add(settings.BattleEventNames[i]);
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
                    foreach (string name in settings.SpriteNames)
                        aniNameA.Items.Add(name);
                    aniNameA.Enabled = true;
                    aniNumA.Hexadecimal = true; aniNumA.Maximum = 0x3FF; aniNumA.Enabled = true;
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

                    aniNumA.Value = aniNameA.SelectedIndex = BitManager.GetShort(asc.AnimationData, 3) & 0x3FF;
                    aniNumC.Value = asc.AnimationData[5];
                    aniNumD.Value = BitManager.GetShort(asc.AnimationData, 7);
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
                    aniNumB.Value = (short)BitManager.GetShort(asc.AnimationData, 6);
                    aniNumC.Value = (short)BitManager.GetShort(asc.AnimationData, 2);
                    aniNumD.Value = (short)BitManager.GetShort(asc.AnimationData, 4);
                    aniBits.SetItemChecked(0, (asc.Option & 0x01) == 0x01);
                    aniBits.SetItemChecked(1, (asc.Option & 0x02) == 0x02);
                    aniBits.SetItemChecked(2, (asc.Option & 0x04) == 0x04);
                    break;
                case 0x03:
                    aniTitleA.Text = "Set sprite of current action object...";
                    aniLabelA.Text = "Sprite";
                    aniLabelC.Text = "Sequence";
                    aniTitleB.Text = "Properties...";
                    foreach (string name in settings.SpriteNames)
                        aniNameA.Items.Add(name);
                    aniNameA.Enabled = true;
                    aniNumA.Hexadecimal = true; aniNumA.Maximum = 0x3FF; aniNumA.Enabled = true;
                    aniNumC.Maximum = 15; aniNumC.Enabled = true;
                    aniBits.Items.AddRange(new object[]{
                        "store to VRAM",
                        "infinite seq playback",
                        "store palette"});
                    aniBits.Enabled = true;

                    aniNumA.Value = aniNameA.SelectedIndex = BitManager.GetShort(asc.AnimationData, 3) & 0x3FF;
                    aniNumC.Value = asc.AnimationData[5];
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
                    aniNumC.Value = BitManager.GetShort(asc.AnimationData, 2);
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

                    aniNumB.Value = (short)BitManager.GetShort(asc.AnimationData, 6);
                    aniNumC.Value = (short)BitManager.GetShort(asc.AnimationData, 2);
                    aniNumD.Value = (short)BitManager.GetShort(asc.AnimationData, 4);
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

                    aniNumC.Value = BitManager.GetShort(asc.AnimationData, 1);
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
                    aniNumC.Value = (short)BitManager.GetShort(asc.AnimationData, 2);
                    aniNumD.Value = (short)BitManager.GetShort(asc.AnimationData, 4);
                    break;
                case 0x10:
                    aniTitleA.Text = "Jump to subroutine...";
                    aniLabelC.Text = "Address";
                    aniNumC.Maximum = 0xFFFF; aniNumC.Hexadecimal = true; aniNumC.Enabled = true;

                    aniNumC.Value = BitManager.GetShort(asc.AnimationData, 1);
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
                    aniNumC.Value = BitManager.GetShort(asc.AnimationData, 2);
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
                    aniNumC.Value = BitManager.GetShort(asc.AnimationData, 2);
                    aniNumD.Value = BitManager.GetShort(asc.AnimationData, 4);
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
                case 0x36: aniTitleA.Text = "Set object mem bits..."; goto case 0x37;
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
                    aniNumE.Value = BitManager.GetShort(asc.AnimationData, 3);
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
                    aniNumD.Value = BitManager.GetShort(asc.AnimationData, 3);
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

                    aniNumC.Value = BitManager.GetShort(asc.AnimationData, 1);
                    break;
                case 0x68:
                    aniTitleA.Text = "Run synchronous code packet from OMEM $60 at...";
                    aniLabelC.Text = "Address";
                    aniLabelD.Text = "Sub-packet";

                    aniNumC.Hexadecimal = true; aniNumC.Maximum = 0xFFFF; aniNumC.Enabled = true;
                    aniNumD.Maximum = 255; aniNumD.Enabled = true;

                    aniNumC.Value = BitManager.GetShort(asc.AnimationData, 1);
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
                    aniNumD.Value = asc.Opcode == 0x6A ? asc.AnimationData[2] : BitManager.GetShort(asc.AnimationData, 2);
                    break;
                case 0x72:
                    aniTitleA.Text = "Start spell effect...";
                    aniLabelA.Text = "Effect";
                    aniTitleB.Text = "Properties...";

                    aniNameA.Items.AddRange(spellEffectNames);
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

                    aniNumC.Value = BitManager.GetShort(asc.AnimationData, 1);
                    break;
                case 0x77:
                    aniTitleA.Text = "Set object graphic properties...";
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
                    aniTitleA.Text = "Set object layer priority...";
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

                    aniNameA.SelectedIndex = asc.Option;
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
                    aniTitleA.Text = "Screen flash color...";
                    aniLabelA.Text = "Color";
                    aniLabelC.Text = "Duration";

                    aniNameA.Items.AddRange(new object[] { 
                        "{none}", "red", "green", "yellow", "blue", "pink", "aqua", "white" });
                    aniNameA.Enabled = true;
                    aniNumC.Enabled = true;

                    aniNameA.SelectedIndex = asc.Option & 0x07;
                    aniNumC.Value = asc.AnimationData[2];
                    break;
                case 0xAB:
                case 0xAE:
                    aniTitleA.Text = "Playback sound effect";
                    aniTitleA.Text += asc.Opcode == 0xAB ? "..." : " (sync)...";
                    aniLabelA.Text = "Sound";

                    aniNameA.Items.AddRange(BattleSoundNames);
                    aniNameA.Enabled = true;

                    aniNameA.SelectedIndex = asc.Option;
                    break;
                case 0xB0:
                    aniTitleA.Text = "Playback music";
                    aniLabelA.Text = "Music";

                    aniNameA.Items.AddRange(MusicNames);
                    aniNameA.Enabled = true;

                    aniNameA.SelectedIndex = asc.Option;
                    break;
                case 0xB1:
                    aniTitleA.Text = "Playback music";
                    aniLabelA.Text = "Music";

                    aniNameA.Items.AddRange(MusicNames);
                    aniNameA.Enabled = true;
                    aniNumC.Enabled = true; aniNumC.Maximum = 0xFFFF;

                    aniNameA.SelectedIndex = asc.Option;
                    aniNumC.Value = BitManager.GetShort(asc.AnimationData, 2);
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

                    foreach (string name in settings.TargetNames)
                        aniNameA.Items.Add(name);
                    aniNameA.Enabled = true;

                    aniNameA.SelectedIndex = asc.Option;
                    break;
                case 0xBC:
                case 0xBD:
                    aniTitleA.Text = asc.Opcode == 0xBC ?
                        "Store / remove item to item inventory..." : "Store / remove item to special item inventory...";
                    aniLabelA.Text = "Item";

                    aniNameA.Items.AddRange(universal.ItemNames.GetNames());
                    aniNameA.Enabled = true;
                    aniNumA.Maximum = 0xB0; aniNumA.Enabled = true;
                    aniBits.Items.Add("remove"); aniBits.Enabled = true;

                    aniNameA.SelectedIndex = universal.ItemNames.GetIndexFromNum(
                        Math.Abs((short)BitManager.GetShort(asc.AnimationData, 1)));
                    aniNumA.Value = Math.Abs((short)BitManager.GetShort(asc.AnimationData, 1));
                    aniBits.SetItemChecked(0, asc.AnimationData[2] == 0xFF);
                    break;
                case 0xBE:
                    aniTitleA.Text = "Add value to current coins...";
                    aniLabelC.Text = "Value";

                    aniNumC.Maximum = 0xFFFF; aniNumC.Enabled = true;

                    aniNumC.Value = BitManager.GetShort(asc.AnimationData, 1);
                    break;
                case 0xBF:
                    aniTitleA.Text = "Store target's Yoshi Cookie to item inventory...";
                    aniLabelA.Text = "Target";

                    foreach (string name in settings.TargetNames)
                        aniNameA.Items.Add(name);
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

                    aniNumC.Value = BitManager.GetShort(asc.AnimationData, 1);
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
                    BitManager.SetShort(asc.AnimationData, 3, (ushort)aniNumA.Value);
                    asc.AnimationData[5] = (byte)aniNumC.Value;
                    BitManager.SetShort(asc.AnimationData, 7, (ushort)aniNumD.Value);
                    BitManager.SetBit(asc.AnimationData, 1, 0, aniBits.GetItemChecked(0));
                    BitManager.SetBit(asc.AnimationData, 2, 3, aniBits.GetItemChecked(1));
                    BitManager.SetBit(asc.AnimationData, 2, 5, aniBits.GetItemChecked(2));
                    BitManager.SetBit(asc.AnimationData, 6, 4, aniBits.GetItemChecked(3));
                    BitManager.SetBit(asc.AnimationData, 6, 6, aniBits.GetItemChecked(4));
                    BitManager.SetBit(asc.AnimationData, 6, 7, aniBits.GetItemChecked(5));
                    break;
                case 0x01:
                case 0x0B:
                    asc.Option = (byte)(aniNameA.SelectedIndex << 4);
                    BitManager.SetBit(asc.AnimationData, 1, 0, aniBits.GetItemChecked(0));
                    BitManager.SetBit(asc.AnimationData, 1, 1, aniBits.GetItemChecked(1));
                    BitManager.SetBit(asc.AnimationData, 1, 2, aniBits.GetItemChecked(2));
                    BitManager.SetShort(asc.AnimationData, 2, (ushort)((short)aniNumC.Value));
                    BitManager.SetShort(asc.AnimationData, 4, (ushort)((short)aniNumD.Value));
                    BitManager.SetShort(asc.AnimationData, 6, (ushort)((short)aniNumB.Value));
                    break;
                case 0x03:
                    BitManager.SetShort(asc.AnimationData, 3, (ushort)aniNumA.Value);
                    asc.AnimationData[5] = (byte)aniNumC.Value;
                    BitManager.SetBit(asc.AnimationData, 1, 0, aniBits.GetItemChecked(0));
                    BitManager.SetBit(asc.AnimationData, 2, 3, aniBits.GetItemChecked(1));
                    BitManager.SetBit(asc.AnimationData, 2, 5, aniBits.GetItemChecked(2));
                    break;
                case 0x04:
                    asc.Option = (byte)aniNameA.SelectedIndex;
                    BitManager.SetShort(asc.AnimationData, 2, (ushort)aniNumC.Value);
                    break;
                case 0x08:
                    BitManager.SetBit(asc.AnimationData, 1, 0, aniBits.GetItemChecked(0));
                    BitManager.SetBit(asc.AnimationData, 1, 1, aniBits.GetItemChecked(1));
                    BitManager.SetBit(asc.AnimationData, 1, 2, aniBits.GetItemChecked(2));
                    BitManager.SetBit(asc.AnimationData, 1, 5, aniBits.GetItemChecked(3));
                    BitManager.SetBit(asc.AnimationData, 1, 6, aniBits.GetItemChecked(4));
                    BitManager.SetBit(asc.AnimationData, 1, 7, aniBits.GetItemChecked(5));
                    BitManager.SetShort(asc.AnimationData, 2, (ushort)((short)aniNumC.Value));
                    BitManager.SetShort(asc.AnimationData, 4, (ushort)((short)aniNumD.Value));
                    BitManager.SetShort(asc.AnimationData, 6, (ushort)((short)aniNumB.Value));
                    break;
                case 0x09:
                case 0x10:
                case 0x64:
                    BitManager.SetShort(asc.AnimationData, 1, (ushort)aniNumC.Value);
                    break;
                case 0x0C:
                    asc.Option = (byte)(aniNameA.SelectedIndex * 2);
                    BitManager.SetShort(asc.AnimationData, 2, (ushort)((short)aniNumC.Value));
                    BitManager.SetShort(asc.AnimationData, 4, (ushort)((short)aniNumD.Value));
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
                    BitManager.SetShort(asc.AnimationData, 2, (ushort)aniNumC.Value);
                    break;
                case 0x24:
                case 0x25:
                case 0x26:
                case 0x27:
                case 0x28:
                case 0x29:
                case 0x2A:
                case 0x2B:
                    BitManager.SetShort(asc.AnimationData, 4, (ushort)aniNumD.Value); goto case 0x23;
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
                        BitManager.SetBit(asc.AnimationData, 2, j, aniBits.GetItemChecked(j));
                    break;
                case 0x38:
                case 0x39:
                    asc.Option = (byte)aniNumC.Value;
                    for (int i = 1, j = 0; j < 8; i *= 2, j++)
                        BitManager.SetBit(asc.AnimationData, 2, j, aniBits.GetItemChecked(j));
                    BitManager.SetShort(asc.AnimationData, 3, (ushort)aniNumE.Value);
                    break;
                case 0x40:
                case 0x41:
                    asc.Option = (byte)aniNumC.Value;
                    for (int i = 1, j = 0; j < 8; i *= 2, j++)
                        BitManager.SetBit(asc.AnimationData, 2, j, aniBits.GetItemChecked(j));
                    break;
                case 0x43:
                    asc.Option = (byte)aniNumC.Value;
                    for (int i = 0, j = 0; j < 4; i++, j++)
                        BitManager.SetBit(asc.AnimationData, 1, j + 4, aniBits.GetItemChecked(j));
                    break;
                case 0x5D:
                    for (int i = 1, j = 0; j < 8; i *= 2, j++)
                        BitManager.SetBit(asc.AnimationData, 1, j, aniBits.GetItemChecked(j));
                    asc.AnimationData[2] = (byte)aniNumC.Value;
                    BitManager.SetShort(asc.AnimationData, 3, (ushort)aniNumD.Value);
                    break;
                case 0x63:
                    asc.Option = (byte)aniNameA.SelectedIndex;
                    break;
                case 0x68:
                    BitManager.SetShort(asc.AnimationData, 1, (ushort)aniNumC.Value);
                    asc.AnimationData[3] = (byte)aniNumD.Value;
                    break;
                case 0x6A:
                case 0x6B:
                    asc.Option = (byte)aniNumC.Value;
                    if (asc.Opcode == 0x6B)
                        BitManager.SetShort(asc.AnimationData, 2, (ushort)aniNumD.Value);
                    else
                        asc.AnimationData[2] = (byte)aniNumD.Value;
                    break;
                case 0x72:
                    asc.AnimationData[2] = (byte)aniNameA.SelectedIndex;
                    for (int i = 1, j = 0; j < 4; i *= 2, j++)
                        BitManager.SetBit(asc.AnimationData, 1, j, aniBits.GetItemChecked(j));
                    break;
                case 0x74:
                case 0x75:
                    BitManager.SetShort(asc.AnimationData, 1, (ushort)aniNumC.Value);
                    break;
                case 0x77:
                    asc.Option = (byte)(aniNameA.SelectedIndex << 4);
                    for (int i = 1, j = 0; j < 4; i *= 2, j++)
                        BitManager.SetBit(asc.AnimationData, 1, j, aniBits.GetItemChecked(j));
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
                    break;
                case 0x8E:
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
                    BitManager.SetShort(asc.AnimationData, 2, (ushort)aniNumC.Value);
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
                        BitManager.SetShort(asc.AnimationData, 1, (ushort)temp);
                    else
                        BitManager.SetShort(asc.AnimationData, 1, (ushort)aniNumA.Value);
                    break;
                case 0xBE:
                    BitManager.SetShort(asc.AnimationData, 1, (ushort)aniNumC.Value);
                    break;
                case 0xC3:
                case 0xCB:
                    asc.Option = (byte)aniNumC.Value;
                    break;
                case 0xE1:
                    BitManager.SetShort(asc.AnimationData, 1, (ushort)aniNumC.Value);
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

        private void MoveAnimationNode(AnimationScriptCommand tempA, AnimationScriptCommand tempB, int select)
        {
            Point p = GetTreeViewScrollPos(animationScriptTree);

            byte[] byteA = new byte[tempB.AnimationData.Length];
            byte[] byteB = new byte[tempA.AnimationData.Length];
            for (int i = 0; i < byteA.Length; i++)
                byteA[i] = tempB.AnimationData[i];
            for (int i = 0; i < byteB.Length; i++)
                byteB[i] = tempA.AnimationData[i];
            tempA.AnimationData = byteA;
            tempB.AnimationData = byteB;

            int offset = tempA.InternalOffset;
            for (int i = 0; i < byteA.Length; i++, offset++)
                data[offset] = tempA.AnimationData[i];
            int temp = tempB.InternalOffset;
            tempB.InternalOffset = tempA.InternalOffset;
            tempA.InternalOffset = offset;
            for (int i = 0; i < byteB.Length; i++, offset++)
                data[offset] = tempB.AnimationData[i];
            tempA.Offset = tempA.OriginalOffset = tempA.InternalOffset;
            tempB.Offset = tempB.OriginalOffset = tempB.InternalOffset;

            // check multiple instances of command in current script, and change each accordingly
            animationScripts[(int)animationNum.Value].RefreshAnimationScript();

            // redraw the treeview
            a_treeViewWrapper.ChangeScript(animationScripts[(int)animationNum.Value]);

            // set the selected node
            int internalOffset = select == 0 ? tempA.InternalOffset : tempB.InternalOffset;
            foreach (TreeNode tn in this.animationScriptTree.Nodes)
            {
                if (internalOffset == ((AnimationScriptCommand)tn.Tag).InternalOffset)
                {
                    this.animationScriptTree.SelectedNode = tn;
                    break;
                }
                else
                    SearchForNodeWithTag(tn, internalOffset);
            }
            p.X = 0;
            SetTreeViewScrollPos(animationScriptTree, p);
        }
        private void SearchForNodeWithTag(TreeNode node, int offset)
        {
            foreach (TreeNode tn in node.Nodes)
            {
                if (offset == ((AnimationScriptCommand)tn.Tag).InternalOffset)
                {
                    this.animationScriptTree.SelectedNode = tn;
                    break;
                }
                else
                    SearchForNodeWithTag(tn, offset);
            }
        }
        #endregion

        #region Event Handlers
        private void animationCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingAnimations) return;

            animationNum.Value = 0;
            switch (animationCategory.SelectedIndex)
            {
                case 0: animationScripts = scriptsModel.BehaviorAnimations; break;
                case 1: animationScripts = scriptsModel.SpellAnimMonsters; break;
                case 2: animationScripts = scriptsModel.AttackAnimations; break;
                case 3: animationScripts = scriptsModel.EntranceAnimations; break;
                case 4: animationScripts = scriptsModel.ItemAnimations; break;
                case 5: animationScripts = scriptsModel.SpellAnimAllies; break;
                case 6: animationScripts = scriptsModel.WeaponAnimations; break;
                case 7: animationScripts = scriptsModel.BattleEvents; break;
            }
            RefreshAnimationScriptsEditor();
        }
        private void animationNum_ValueChanged(object sender, EventArgs e)
        {
            animationScripts[(int)animationNum.Value].RefreshAnimationScript();

            int current = a_currentScript;
            a_currentScript = (int)animationNum.Value;
            if (animationCategory.SelectedIndex == 2)
            {
                animationName.SelectedIndex = universal.AttackNames.GetIndexFromNum(a_currentScript);
                a_treeViewWrapper.ChangeScript(animationScripts[(int)animationNum.Value]);
            }
            else
            {
                animationName.SelectedIndex = a_currentScript;
                a_treeViewWrapper.ChangeScript(animationScripts[(int)animationNum.Value]);
            }
            if (this.animationScriptTree.Nodes.Count > 0)
                this.animationScriptTree.SelectedNode = this.animationScriptTree.Nodes[0];
        }
        private void animationName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (animationCategory.SelectedIndex == 2)
                animationNum.Value = universal.AttackNames.GetNumFromIndex(animationName.SelectedIndex);
            else
                animationNum.Value = animationName.SelectedIndex;
        }
        private void animationName_DrawItem(object sender, DrawItemEventArgs e)
        {
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

            e.DrawBackground();
            if (animationCategory.SelectedIndex == 1 ||
                animationCategory.SelectedIndex == 2 ||
                animationCategory.SelectedIndex == 4 ||
                animationCategory.SelectedIndex == 5 ||
                animationCategory.SelectedIndex == 6)
            {
                char[] arr;

                switch (animationCategory.SelectedIndex)
                {
                    case 1: arr = universal.SpellNames.GetNameByNum(e.Index + 0x40).ToCharArray(); break;
                    case 2: arr = universal.AttackNames.GetName(e.Index).ToCharArray(); break;
                    case 4: arr = universal.ItemNames.GetNameByNum(e.Index + 0x60).ToCharArray(); break;
                    case 5: arr = universal.SpellNames.GetNameByNum(e.Index).ToCharArray(); break;
                    case 6: arr = universal.ItemNames.GetNameByNum(e.Index).ToCharArray(); break;
                    default: arr = new char[1]; break;
                }

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == '.') arr[i] = (char)0x2A;
                    if (arr[i] == '!') arr[i] = (char)0x7B;
                    if (arr[i] == '-') arr[i] = (char)0x7D;
                    if (arr[i] == '\'') arr[i] = (char)0x7E;
                    if (animationCategory.SelectedIndex == 2)
                    {
                        if (arr[i] == ' ' && i == 0) arr[i] = (char)0x7F;
                        if (arr[i] == '_') arr[i] = i == 0 ? (char)0x7F : (char)0x20;
                        if (arr[i] == '&') arr[i] = (char)0x9C;
                    }
                }

                // set the palette
                int[] palette = new int[16];
                ushort color = 0; int r, g, b;
                for (int i = 0; i < 16; i++) // 16 colors in palette
                {
                    color = BitManager.GetShort(data, i * 2 + 0x3E2D55);
                    r = (byte)((color % 0x20) * 8);
                    g = (byte)(((color >> 5) % 0x20) * 8);
                    b = (byte)(((color >> 10) % 0x20) * 8);
                    palette[i] = Color.FromArgb(r, g, b).ToArgb();
                }

                // set the pixels
                int[] temp = menuTextPreview.GetPreview(menuCharacters, palette, arr, false);
                int[] pixels = new int[256 * 14];

                for (int y = 2, c = 0; y < 14; y++, c++)
                {
                    for (int x = 2, a = 0; x < 256; x++, a++)
                        pixels[y * 256 + x] = temp[c * 256 + a];
                }

                Bitmap icon = new Bitmap(DrawImageFromIntArr(pixels, 256, 14));

                e.Graphics.DrawImage(icon, new Point(e.Bounds.X, e.Bounds.Y));
            }
            else
            {
                e.Graphics.DrawString(animationName.Items[e.Index].ToString(), e.Font, new SolidBrush(animationName.ForeColor), e.Bounds);
            }
            e.DrawFocusRectangle();
        }

        private void animationScriptTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //if (asc == (AnimationScriptCommand)e.Node.Tag)
            //    return;

            a_treeViewWrapper.SelectedNode = e.Node;
            asc = (AnimationScriptCommand)e.Node.Tag;

            NumericUpDown numUpDown;
            panelHexEditor.Controls.Clear();
            for (int i = 0; i < asc.AnimationData.Length; i++)
            {
                numUpDown = new NumericUpDown();
                numUpDown.BorderStyle = BorderStyle.None;
                numUpDown.Hexadecimal = true;
                numUpDown.Location = new Point((i * 41) + 64 + 38, 2);
                numUpDown.Maximum = 255;
                numUpDown.Tag = asc;
                numUpDown.TextAlign = HorizontalAlignment.Right;
                numUpDown.Value = asc.AnimationData[i];
                numUpDown.Width = 40;
                //numUpDown.ValueChanged += new EventHandler(numUpDown_ValueChanged);

                panelHexEditor.Controls.Add(numUpDown);
            }
            panelHexEditor.Size = new Size((asc.AnimationData.Length * 41) + 64 + 50 + applyAnimationMods.Width + 38, 21);
            emptyAnimationMods.Left = 69 + (asc.AnimationData.Length * 41) + 38;
            emptyAnimationMods.Enabled = true;
            applyAnimationMods.Left = emptyAnimationMods.Left + 50;
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
                    aniMoveUp_Click(null, null);
                    break;
                case Keys.Control | Keys.Down:
                    aniMoveDown_Click(null, null);
                    break;
            }
        }

        private void aniMoveDown_Click(object sender, EventArgs e)
        {
            if (a_treeViewWrapper.SelectedNode.NextNode == null)
                return;
            if (asc.Opcode == 0x07 ||
                asc.Opcode == 0x11 ||
                asc.Opcode == 0x5E)
                return;
            AnimationScriptCommand next = (AnimationScriptCommand)a_treeViewWrapper.SelectedNode.NextNode.Tag;
            if (next.Opcode == 0x07 ||
                next.Opcode == 0x11 ||
                next.Opcode == 0x5E)
                return;
            if (a_treeViewWrapper.SelectedNode.Parent != null)
            {
                if (a_treeViewWrapper.SelectedNode.Index >= a_treeViewWrapper.SelectedNode.Parent.Nodes.Count - 1)
                    return;
            }
            else
            {
                if (a_treeViewWrapper.SelectedNode.Index >= animationScriptTree.Nodes.Count - 1)
                    return;
            }
            //try
            //{
            MoveAnimationNode(asc, (AnimationScriptCommand)a_treeViewWrapper.SelectedNode.NextNode.Tag, 0);
            //}
            //catch
            //{
            //    MessageBox.Show("Setting this byte to this value causes errors.",
            //        "WARNING: Byte error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    animationScriptTree.EndUpdate();
            //}
        }
        private void aniMoveUp_Click(object sender, EventArgs e)
        {
            if (a_treeViewWrapper.SelectedNode.PrevNode == null)
                return;
            if (asc.Opcode == 0x07 ||
                asc.Opcode == 0x11 ||
                asc.Opcode == 0x5E)
                return;
            AnimationScriptCommand prev = (AnimationScriptCommand)a_treeViewWrapper.SelectedNode.PrevNode.Tag;
            if (prev.Opcode == 0x07 ||
                prev.Opcode == 0x11 ||
                prev.Opcode == 0x5E)
                return;
            if (a_treeViewWrapper.SelectedNode.Index == 0)
                return;

            //try
            //{
            MoveAnimationNode((AnimationScriptCommand)a_treeViewWrapper.SelectedNode.PrevNode.Tag, asc, 1);
            //}
            //catch
            //{
            //    MessageBox.Show("Setting this byte to this value causes errors.",
            //        "WARNING: Byte error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    animationScriptTree.EndUpdate();
            //}
        }
        private void applyAnimationMods_Click(object sender, EventArgs e)
        {
            Point p = GetTreeViewScrollPos(animationScriptTree);

            int tmp = asc.InternalOffset;
            byte[] temp = new byte[asc.AnimationData.Length];
            asc.AnimationData.CopyTo(temp, 0);
            try
            {
                foreach (NumericUpDown numUpDown in panelHexEditor.Controls)
                {
                    int index = (numUpDown.Location.X - 64 - 38) / 41;

                    // set the new value for the command
                    asc.AnimationData[index] = (byte)numUpDown.Value;
                    data[asc.InternalOffset + index] = (byte)numUpDown.Value;
                }
                // check multiple instances of command in current script, and change each accordingly
                animationScripts[(int)animationNum.Value].RefreshAnimationScript();

            }
            catch
            {
                for (int i = 0; i < temp.Length; i++)
                    data[tmp + i] = temp[i];

                // check multiple instances of command in current script, and change each accordingly
                animationScripts[(int)animationNum.Value].RefreshAnimationScript();

                //// redraw the treeview
                //a_treeViewWrapper.ChangeScript(animationScripts[(int)animationNum.Value]);

                MessageBox.Show("Setting this byte to this value causes errors.",
                    "WARNING: Byte error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                animationScriptTree.EndUpdate();
            }
            finally
            {
                // redraw the treeview
                a_treeViewWrapper.ChangeScript(animationScripts[(int)animationNum.Value]);
            }

            // set the selected node
            foreach (TreeNode tn in this.animationScriptTree.Nodes)
            {
                if (asc.InternalOffset == ((AnimationScriptCommand)tn.Tag).InternalOffset)
                {
                    this.animationScriptTree.SelectedNode = tn;
                    break;
                }
                else
                    SearchForNodeWithTag(tn, asc.InternalOffset);
            }
            p.X = 0;
            SetTreeViewScrollPos(animationScriptTree, p);
        }
        private void emptyAnimationMods_Click(object sender, EventArgs e)
        {
            foreach (NumericUpDown numUpDown in panelHexEditor.Controls)
            {
                numUpDown.Value = 0x0A;
            }
        }

        private void applyAnimation_Click(object sender, EventArgs e)
        {
            Point p = GetTreeViewScrollPos(animationScriptTree);

            ControlAniAsmMethod();

            for (int i = 0; i < asc.AnimationData.Length; i++)
                data[asc.InternalOffset + i] = asc.AnimationData[i];

            // redraw the treeview
            animationScripts[(int)animationNum.Value].RefreshAnimationScript();
            a_treeViewWrapper.ChangeScript(animationScripts[(int)animationNum.Value]);

            // set the selected node
            foreach (TreeNode tn in this.animationScriptTree.Nodes)
            {
                if (asc.InternalOffset == ((AnimationScriptCommand)tn.Tag).InternalOffset)
                {
                    this.animationScriptTree.SelectedNode = tn;
                    break;
                }
                else
                    SearchForNodeWithTag(tn, asc.InternalOffset);
            }
            p.X = 0;
            SetTreeViewScrollPos(animationScriptTree, p);
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
                    aniNumA.Value = universal.ItemNames.GetNumFromIndex(aniNameA.SelectedIndex);
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
                    aniNameA.SelectedIndex = universal.ItemNames.GetIndexFromNum((int)aniNumA.Value);
                    break;
            }
        }
        #endregion
    }
}
