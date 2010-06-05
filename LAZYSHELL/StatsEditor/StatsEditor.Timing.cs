using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL.StatsEditor
{
    public partial class StatsEditor
    {
        private bool updatingTiming = false;
        private void InitializeTiming()
        {
            this.weaponOrDefense.SelectedIndex = 0;
            this.weaponName.SelectedIndex = 0;
            this.level1TimingSpellName.SelectedIndex = 0;
            this.level2TimingSpellName.SelectedIndex = 0;
            this.multipleTimingSpellName.SelectedIndex = 0;
            this.padRotationSpellName.SelectedIndex = 0;
            this.fireballName.SelectedIndex = 0;

            this.instanceNumberName.SelectedIndex = 0;

            RefreshTimingTab();
        }
        private void InitializeTimingStrings()
        {
            this.weaponName.Items.Clear();
            for (int i = 0; i < 37; i++)
                this.weaponName.Items.Add(new string(statsModel.Items[i].Name));
            this.weaponName.SelectedIndex = (int)this.numericUpDown6.Value;

            this.level1TimingSpellName.Items.Clear();
            byte[] spellsToFind = new byte[] { 0x9, 0x11, 0x12, 0x15, 0x17 }; // Spell Numbers
            for (int i = 0; i < spellsToFind.Length; i++)
                this.level1TimingSpellName.Items.Add(new string(statsModel.Spells[spellsToFind[i]].Name));
            this.level1TimingSpellName.SelectedIndex = 0;

            this.level2TimingSpellName.Items.Clear();
            spellsToFind = new byte[] { 0x00, 0x06, 0x0e, 0x16, 0x18 }; // Spell Numbers
            for (int i = 0; i < spellsToFind.Length; i++)
                this.level2TimingSpellName.Items.Add(new string(statsModel.Spells[spellsToFind[i]].Name));
            this.level2TimingSpellName.SelectedIndex = 0;

            this.multipleTimingSpellName.Items.Clear();
            spellsToFind = new byte[] { 0x02, 0x04, 0x1A }; // Spell Numbers
            for (int i = 0; i < spellsToFind.Length; i++)
                this.multipleTimingSpellName.Items.Add(new string(statsModel.Spells[spellsToFind[i]].Name));
            this.multipleTimingSpellName.SelectedIndex = 0;

            this.padRotationSpellName.Items.Clear();
            spellsToFind = new byte[] { 0x08, 0x0A, 0x0C, 0x0D, 0x19 }; // Spell Numbers
            for (int i = 0; i < spellsToFind.Length; i++)
                this.padRotationSpellName.Items.Add(new string(statsModel.Spells[spellsToFind[i]].Name));
            this.padRotationSpellName.SelectedIndex = 0;

            this.fireballName.Items.Clear();
            spellsToFind = new byte[] { 0x01, 0x03, 0x05 }; // Spell Numbers
            for (int i = 0; i < spellsToFind.Length; i++)
                this.fireballName.Items.Add(new string(statsModel.Spells[spellsToFind[i]].Name));
            this.fireballName.SelectedIndex = 0;
        }

        private void RefreshTimingTab()
        {
            if (!updatingTiming)
            {
                updatingTiming = true;

                RefreshTimingWD();
                RefreshTimingSpellsOne();
                RefreshTimingSpellsTwo();
                RefreshTimingSpellsGeno();
                RefreshTimingFireballSpells();
                RefreshTimingRotaionSpells();
                RefreshTimingRapidSpellMax();
                RefreshTimingMultipleTiming();

                updatingTiming = false;
            }
        }
        private void RefreshTimingWD()
        {
            if (weaponOrDefense.SelectedIndex == 1)
            {
                this.lvl1TimingStart.Value = statsModel.Timing.DefenseStartLevel1;
                this.lvl2TimingStart.Value = statsModel.Timing.DefenseStartLevel2;
                this.lvl2TimingEnd.Value = statsModel.Timing.DefenseEndLevel2;
                this.lvl1TimingEnd.Value = statsModel.Timing.DefenseEndLevel1;
            }
            else if (weaponOrDefense.SelectedIndex == 0)
            {
                statsModel.Timing.CurrentWeapon = (byte)numericUpDown6.Value;
                this.weaponName.SelectedIndex = (int)numericUpDown6.Value;

                this.lvl1TimingStart.Value = statsModel.Timing.WeaponStartLevel1;
                this.lvl2TimingStart.Value = statsModel.Timing.WeaponStartLevel2;
                this.lvl2TimingEnd.Value = statsModel.Timing.WeaponEndLevel2;
                this.lvl1TimingEnd.Value = statsModel.Timing.WeaponEndLevel1;
            }
            this.numericUpDown117.Value = this.lvl2TimingEnd.Value;
            this.numericUpDown118.Value = this.lvl1TimingStart.Value;
            this.numericUpDown119.Value = this.lvl1TimingEnd.Value;
            this.numericUpDown120.Value = this.lvl2TimingStart.Value;

        }
        private void RefreshTimingSpellsOne()
        {
            statsModel.Timing.CurrentLevelOneSpellTiming = (byte)this.level1TimingSpellName.SelectedIndex;

            this.spell1TimingFrameSpan.Value = statsModel.Timing.OneLevelSpellSpan;
            this.numericUpDown100.Value = this.spell1TimingFrameSpan.Value;
        }
        private void RefreshTimingSpellsTwo()
        {
            statsModel.Timing.CurrentLevelTwoSpellTiming = (byte)this.level2TimingSpellName.SelectedIndex;

            this.spell2Level2FrameStart.Value = statsModel.Timing.TwoLevelSpellStartLevel2;
            this.spell2Level2FrameEnd.Value = statsModel.Timing.TwoLevelSpellEndLevel2;
            this.spell2Level1FrameEnd.Value = statsModel.Timing.TwoLevelSpellEndLevel1;
            this.numericUpDown107.Value = this.spell2Level2FrameStart.Value;
            this.numericUpDown110.Value = this.spell2Level2FrameEnd.Value;
            this.numericUpDown108.Value = this.spell2Level1FrameEnd.Value;
        }
        private void RefreshTimingSpellsGeno()
        {
            this.GenoLevel2Frame.Value = statsModel.Timing.ChargeSpellStartLevel2;
            this.GenoLevel3Frame.Value = statsModel.Timing.ChargeSpellStartLevel3;
            this.GenoLevel4Frame.Value = statsModel.Timing.ChargeSpellStartLevel4;
            this.GenoChargeOverflow.Value = statsModel.Timing.ChargeSpellOverflow;
            this.numericUpDown113.Value = this.GenoLevel2Frame.Value;
            this.numericUpDown111.Value = this.GenoLevel3Frame.Value;
            this.numericUpDown114.Value = this.GenoLevel4Frame.Value;
            this.numericUpDown112.Value = this.GenoChargeOverflow.Value;

        }
        private void RefreshTimingFireballSpells()
        {
            statsModel.Timing.CurrentFireball = (byte)this.fireballName.SelectedIndex;

            this.numericUpDown106.Value = statsModel.Timing.FireballSpellRange;
            this.numericUpDown105.Value = statsModel.Timing.FireballSpellOrbs;
        }
        private void RefreshTimingRotaionSpells()
        {
            statsModel.Timing.CurrentRotationSpell = (byte)this.padRotationSpellName.SelectedIndex;

            this.numericUpDown104.Value = statsModel.Timing.RotationSpellStart;
            this.numericUpDown103.Value = statsModel.Timing.RotationSpellMax;
        }
        private void RefreshTimingRapidSpellMax()
        {
            this.numericUpDown102.Value = statsModel.Timing.RapidSpellMax;
        }
        private void RefreshTimingMultipleTiming()
        {
            this.statsModel.Timing.MultipleSpellNum = (byte)this.multipleTimingSpellName.SelectedIndex;
            this.instanceNumberName.Items.Clear();

            if (this.statsModel.Timing.MultipleSpellNum != 2)
            {
                //string pre = (this.statsModel.Timing.MultipleSpellNum == 0) ? "Super Jump " : "Ultra Jump ";
                string pre = this.multipleTimingSpellName.SelectedItem.ToString();
                int count = (this.statsModel.Timing.MultipleSpellNum == 0) ? 14 : 17;
                for (int i = 0; i < count; i++)
                    this.instanceNumberName.Items.Add(pre + " " + i.ToString());

                this.instanceNumberName.SelectedIndex = 0;
                this.instanceNumberName.Enabled = true;
            }
            else
            {
                this.instanceNumberName.Items.AddRange(new object[] { this.multipleTimingSpellName.SelectedItem.ToString() });
                this.instanceNumberName.SelectedIndex = 0;
                this.instanceNumberName.Enabled = false;
            }

            statsModel.Timing.MultipleSpellNum = (byte)this.multipleTimingSpellName.SelectedIndex;
            statsModel.Timing.SaveIndex = (byte)this.instanceNumberName.SelectedIndex;
            this.numericUpDown7.Value = statsModel.Timing.NumberOfMultipleInstances;
            this.numericUpDown8.Value = statsModel.Timing.TimeFrameStart;
        }

        #region Event Handlers
        private void weaponOrDefense_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (weaponOrDefense.SelectedIndex == 0) // Weapons
            {
                this.weaponName.Enabled = true;
                this.numericUpDown6.Enabled = true;
            }
            else if (weaponOrDefense.SelectedIndex == 1) // Defense
            {
                this.weaponName.Enabled = false;
                this.numericUpDown6.Enabled = false;
            }
            RefreshTimingWD();
        }
        private void weaponName_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericUpDown6.Value = weaponName.SelectedIndex;
        }
        private void weaponName_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index > 36)
                return;

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
            int[] temp = menuTextPreview.GetPreview(menuCharacters, palette, statsModel.Items[e.Index].Name, false);
            int[] pixels = new int[256 * 16];

            for (int y = 2, c = 0; y < 16; y++, c++)
            {
                for (int x = 2, a = 0; x < 256; x++, a++)
                    pixels[y * 256 + x] = temp[c * 256 + a];
            }

            Bitmap icon = new Bitmap(Drawing.PixelArrayToImage(pixels, 256, 16));

            e.DrawBackground();
            e.Graphics.DrawImage(new Bitmap(icon), new Point(e.Bounds.X, e.Bounds.Y));
            e.DrawFocusRectangle();
        }
        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            this.weaponName.SelectedIndex = (int)this.numericUpDown6.Value;

            RefreshTimingWD();
        }
        private void numericUpDown118_ValueChanged(object sender, EventArgs e)
        {
            if (weaponOrDefense.SelectedIndex == 1)
            {
                statsModel.Timing.DefenseStartLevel1 = (byte)this.numericUpDown118.Value;
            }
            else if (weaponOrDefense.SelectedIndex == 0)
            {
                statsModel.Timing.WeaponStartLevel1 = (byte)this.numericUpDown118.Value;
            }
            this.lvl1TimingStart.Value = (int)this.numericUpDown118.Value;
        }
        private void lvl1TimingStart_Scroll(object sender, EventArgs e)
        {
            this.numericUpDown118.Value = this.lvl1TimingStart.Value;
        }
        private void numericUpDown120_ValueChanged(object sender, EventArgs e)
        {
            if (weaponOrDefense.SelectedIndex == 1)
            {
                statsModel.Timing.DefenseStartLevel2 = (byte)this.numericUpDown120.Value;
            }
            else if (weaponOrDefense.SelectedIndex == 0)
            {
                statsModel.Timing.WeaponStartLevel2 = (byte)this.numericUpDown120.Value;
            }
            this.lvl2TimingStart.Value = (int)this.numericUpDown120.Value;
        }
        private void lvl2TimingStart_Scroll(object sender, EventArgs e)
        {
            this.numericUpDown120.Value = this.lvl2TimingStart.Value;
        }
        private void numericUpDown117_ValueChanged(object sender, EventArgs e)
        {
            if (weaponOrDefense.SelectedIndex == 1)
            {
                statsModel.Timing.DefenseEndLevel2 = (byte)this.numericUpDown117.Value;
            }
            else if (weaponOrDefense.SelectedIndex == 0)
            {
                statsModel.Timing.WeaponEndLevel2 = (byte)this.numericUpDown117.Value;
            }
            this.lvl2TimingEnd.Value = (int)this.numericUpDown117.Value;
        }
        private void lvl2TimingEnd_Scroll(object sender, EventArgs e)
        {
            this.numericUpDown117.Value = this.lvl2TimingEnd.Value;
        }
        private void numericUpDown119_ValueChanged(object sender, EventArgs e)
        {
            if (weaponOrDefense.SelectedIndex == 1)
            {
                statsModel.Timing.DefenseEndLevel1 = (byte)this.numericUpDown119.Value;
            }
            else if (weaponOrDefense.SelectedIndex == 0)
            {
                statsModel.Timing.WeaponEndLevel1 = (byte)this.numericUpDown119.Value;
            }
            this.lvl1TimingEnd.Value = (int)this.numericUpDown119.Value;
        }
        private void lvl1TimingEnd_Scroll(object sender, EventArgs e)
        {
            this.numericUpDown119.Value = this.lvl1TimingEnd.Value;
        }

        private void level1TimingSpellName_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshTimingSpellsOne();
        }
        private void level1TimingSpellName_DrawItem(object sender, DrawItemEventArgs e)
        {
            byte[] spellsToFind = new byte[] { 0x9, 0x11, 0x12, 0x15, 0x17 }; // Spell Numbers

            if (e.Index < 0 || e.Index > spellsToFind.Length)
                return;

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
            int[] temp = menuTextPreview.GetPreview(menuCharacters, palette, statsModel.Spells[spellsToFind[e.Index]].Name, false);
            int[] pixels = new int[256 * 14];

            for (int y = 2, c = 0; y < 14; y++, c++)
            {
                for (int x = 2, a = 0; x < 256; x++, a++)
                    pixels[y * 256 + x] = temp[c * 256 + a];
            }

            Bitmap icon = new Bitmap(Drawing.PixelArrayToImage(pixels, 256, 14));

            e.DrawBackground();
            e.Graphics.DrawImage(icon, new Point(e.Bounds.X, e.Bounds.Y));
            e.DrawFocusRectangle();
        }
        private void numericUpDown100_ValueChanged(object sender, EventArgs e)
        {
            this.spell1TimingFrameSpan.Value = (int)this.numericUpDown100.Value;
            this.statsModel.Timing.OneLevelSpellSpan = (byte)numericUpDown100.Value;
        }
        private void spell1TimingFrameSpan_Scroll(object sender, EventArgs e)
        {
            this.numericUpDown100.Value = this.spell1TimingFrameSpan.Value;
        }

        private void level2TimingSpellName_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshTimingSpellsTwo();
        }
        private void level2TimingSpellName_DrawItem(object sender, DrawItemEventArgs e)
        {
            byte[] spellsToFind = new byte[] { 0x00, 0x06, 0x0e, 0x16, 0x18 }; // Spell Numbers

            if (e.Index < 0 || e.Index > spellsToFind.Length)
                return;

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
            int[] temp = menuTextPreview.GetPreview(menuCharacters, palette, statsModel.Spells[spellsToFind[e.Index]].Name, false);
            int[] pixels = new int[256 * 14];

            for (int y = 2, c = 0; y < 14; y++, c++)
            {
                for (int x = 2, a = 0; x < 256; x++, a++)
                    pixels[y * 256 + x] = temp[c * 256 + a];
            }

            Bitmap icon = new Bitmap(Drawing.PixelArrayToImage(pixels, 256, 14));

            e.DrawBackground();
            e.Graphics.DrawImage(icon, new Point(e.Bounds.X, e.Bounds.Y));
            e.DrawFocusRectangle();
        }
        private void numericUpDown107_ValueChanged(object sender, EventArgs e)
        {
            this.spell2Level2FrameStart.Value = (int)this.numericUpDown107.Value;
            this.statsModel.Timing.TwoLevelSpellStartLevel2 = (byte)numericUpDown107.Value;
        }
        private void spell2Level2FrameStart_Scroll(object sender, EventArgs e)
        {
            this.numericUpDown107.Value = (int)this.spell2Level2FrameStart.Value;
        }
        private void numericUpDown110_ValueChanged(object sender, EventArgs e)
        {
            this.spell2Level2FrameEnd.Value = (int)this.numericUpDown110.Value;
            this.statsModel.Timing.TwoLevelSpellEndLevel2 = (byte)numericUpDown110.Value;
        }
        private void spell2Level2FrameEnd_Scroll(object sender, EventArgs e)
        {
            this.numericUpDown110.Value = this.spell2Level2FrameEnd.Value;
        }
        private void numericUpDown108_ValueChanged(object sender, EventArgs e)
        {
            this.spell2Level1FrameEnd.Value = (int)this.numericUpDown108.Value;
            this.statsModel.Timing.TwoLevelSpellEndLevel1 = (byte)numericUpDown108.Value;
        }
        private void spell2Level1FrameEnd_Scroll(object sender, EventArgs e)
        {
            this.numericUpDown108.Value = this.spell2Level1FrameEnd.Value;
        }

        private void numericUpDown113_ValueChanged(object sender, EventArgs e)
        {
            this.GenoLevel2Frame.Value = (int)this.numericUpDown113.Value;
            this.statsModel.Timing.ChargeSpellStartLevel2 = (byte)numericUpDown113.Value;
        }
        private void GenoLevel2Frame_Scroll(object sender, EventArgs e)
        {
            this.numericUpDown113.Value = this.GenoLevel2Frame.Value;
        }
        private void numericUpDown111_ValueChanged(object sender, EventArgs e)
        {
            this.GenoLevel3Frame.Value = (int)this.numericUpDown111.Value;
            this.statsModel.Timing.ChargeSpellStartLevel3 = (byte)numericUpDown111.Value;
        }
        private void GenoLevel3Frame_Scroll(object sender, EventArgs e)
        {
            this.numericUpDown111.Value = this.GenoLevel3Frame.Value;
        }
        private void numericUpDown114_ValueChanged(object sender, EventArgs e)
        {
            this.GenoLevel4Frame.Value = (int)this.numericUpDown114.Value;
            this.statsModel.Timing.ChargeSpellStartLevel4 = (byte)numericUpDown114.Value;
        }
        private void GenoLevel4Frame_Scroll(object sender, EventArgs e)
        {
            this.numericUpDown114.Value = this.GenoLevel4Frame.Value;
        }
        private void numericUpDown112_ValueChanged(object sender, EventArgs e)
        {
            this.GenoChargeOverflow.Value = (int)this.numericUpDown112.Value;
            this.statsModel.Timing.ChargeSpellOverflow = (byte)numericUpDown112.Value;
        }
        private void GenoChargeOverflow_Scroll(object sender, EventArgs e)
        {
            this.numericUpDown112.Value = this.GenoChargeOverflow.Value;
        }

        private void fireballName_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshTimingFireballSpells();
        }
        private void fireballName_DrawItem(object sender, DrawItemEventArgs e)
        {
            byte[] spellsToFind = new byte[] { 0x01, 0x03, 0x05 }; // Spell Numbers

            if (e.Index < 0 || e.Index > spellsToFind.Length)
                return;

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
            int[] temp = menuTextPreview.GetPreview(menuCharacters, palette, statsModel.Spells[spellsToFind[e.Index]].Name, false);
            int[] pixels = new int[256 * 14];

            for (int y = 2, c = 0; y < 14; y++, c++)
            {
                for (int x = 2, a = 0; x < 256; x++, a++)
                    pixels[y * 256 + x] = temp[c * 256 + a];
            }

            Bitmap icon = new Bitmap(Drawing.PixelArrayToImage(pixels, 256, 14));

            e.DrawBackground();
            e.Graphics.DrawImage(icon, new Point(e.Bounds.X, e.Bounds.Y));
            e.DrawFocusRectangle();
        }
        private void numericUpDown106_ValueChanged(object sender, EventArgs e)
        {
            this.statsModel.Timing.FireballSpellRange = (byte)numericUpDown106.Value;
        }
        private void numericUpDown105_ValueChanged(object sender, EventArgs e)
        {
            this.statsModel.Timing.FireballSpellOrbs = (byte)numericUpDown105.Value;
        }

        private void padRotationSpellName_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshTimingRotaionSpells();
        }
        private void padRotationSpellName_DrawItem(object sender, DrawItemEventArgs e)
        {
            byte[] spellsToFind = new byte[] { 0x08, 0x0A, 0x0C, 0x0D, 0x19 }; // Spell Numbers

            if (e.Index < 0 || e.Index > spellsToFind.Length)
                return;

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
            int[] temp = menuTextPreview.GetPreview(menuCharacters, palette, statsModel.Spells[spellsToFind[e.Index]].Name, false);
            int[] pixels = new int[256 * 14];

            for (int y = 2, c = 0; y < 14; y++, c++)
            {
                for (int x = 2, a = 0; x < 256; x++, a++)
                    pixels[y * 256 + x] = temp[c * 256 + a];
            }

            Bitmap icon = new Bitmap(Drawing.PixelArrayToImage(pixels, 256, 14));

            e.DrawBackground();
            e.Graphics.DrawImage(icon, new Point(e.Bounds.X, e.Bounds.Y));
            e.DrawFocusRectangle();
        }
        private void numericUpDown104_ValueChanged(object sender, EventArgs e)
        {
            this.statsModel.Timing.RotationSpellStart = (byte)numericUpDown104.Value;
        }
        private void numericUpDown103_ValueChanged(object sender, EventArgs e)
        {
            this.statsModel.Timing.RotationSpellMax = (byte)numericUpDown103.Value;
        }

        private void multipleTimingSpellName_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshTimingMultipleTiming();
        }
        private void multipleTimingSpellName_DrawItem(object sender, DrawItemEventArgs e)
        {
            byte[] spellsToFind = new byte[] { 0x02, 0x04, 0x1A }; // Spell Numbers

            if (e.Index < 0 || e.Index > spellsToFind.Length)
                return;

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
            int[] temp = menuTextPreview.GetPreview(menuCharacters, palette, statsModel.Spells[spellsToFind[e.Index]].Name, false);
            int[] pixels = new int[256 * 14];

            for (int y = 2, c = 0; y < 14; y++, c++)
            {
                for (int x = 2, a = 0; x < 256; x++, a++)
                    pixels[y * 256 + x] = temp[c * 256 + a];
            }

            Bitmap icon = new Bitmap(Drawing.PixelArrayToImage(pixels, 256, 14));

            e.DrawBackground();
            e.Graphics.DrawImage(icon, new Point(e.Bounds.X, e.Bounds.Y));
            e.DrawFocusRectangle();
        }
        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            this.statsModel.Timing.NumberOfMultipleInstances = (byte)numericUpDown7.Value;
        }
        private void instanceNumberName_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Timing.SaveIndex = (byte)this.instanceNumberName.SelectedIndex;
            this.numericUpDown7.Value = statsModel.Timing.NumberOfMultipleInstances;
            this.numericUpDown8.Value = statsModel.Timing.TimeFrameStart;
        }
        private void instanceNumberName_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index > instanceNumberName.Items.Count - 1)
                return;

            char[] arr = instanceNumberName.Items[e.Index].ToString().ToCharArray();

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

            Bitmap icon = new Bitmap(Drawing.PixelArrayToImage(pixels, 256, 14));

            e.DrawBackground();
            e.Graphics.DrawImage(icon, new Point(e.Bounds.X, e.Bounds.Y));
            e.DrawFocusRectangle();
        }
        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            this.statsModel.Timing.TimeFrameStart = (byte)numericUpDown8.Value;
        }

        private void numericUpDown102_ValueChanged(object sender, EventArgs e)
        {
            this.statsModel.Timing.RapidSpellMax = (byte)numericUpDown102.Value;
        }
        #endregion
    }
}
