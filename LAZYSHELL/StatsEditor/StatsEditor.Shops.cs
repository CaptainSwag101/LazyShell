using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL.StatsEditor
{
    public partial class StatsEditor
    {
        private bool updatingShops = false;

        private void InitializeShops()
        {
            this.shopName.SelectedIndex = 0;
            RefreshShopsTab();
        }
        private void InitializeShopStrings()
        {
            for (int i = 0; i < settings.ShopNames.Count; i++)
                shopName.Items.Add(settings.ShopNames[i]);
        }
        private void RefreshShopsTab()
        {
            if (!updatingShops)
            {
                updatingShops = true;
                this.shopName.SelectedIndex = (int)shopNum.Value;
                this.shopLabel.Text = settings.ShopNames[(int)shopNum.Value];
                this.shopItem1.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Shops[(int)shopNum.Value].Items[0]);
                this.shopItem2.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Shops[(int)shopNum.Value].Items[1]);
                this.shopItem3.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Shops[(int)shopNum.Value].Items[2]);
                this.shopItem4.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Shops[(int)shopNum.Value].Items[3]);
                this.shopItem5.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Shops[(int)shopNum.Value].Items[4]);
                this.shopItem6.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Shops[(int)shopNum.Value].Items[5]);
                this.shopItem7.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Shops[(int)shopNum.Value].Items[6]);
                this.shopItem8.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Shops[(int)shopNum.Value].Items[7]);
                this.shopItem9.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Shops[(int)shopNum.Value].Items[8]);
                this.shopItem10.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Shops[(int)shopNum.Value].Items[9]);
                this.shopItem11.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Shops[(int)shopNum.Value].Items[10]);
                this.shopItem12.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Shops[(int)shopNum.Value].Items[11]);
                this.shopItem13.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Shops[(int)shopNum.Value].Items[12]);
                this.shopItem14.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Shops[(int)shopNum.Value].Items[13]);
                this.shopItem15.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Shops[(int)shopNum.Value].Items[14]);
                this.shopBuyOptions.SetItemChecked(0, statsModel.Shops[(int)shopNum.Value].BuyFrogCoinOne);
                this.shopBuyOptions.SetItemChecked(1, statsModel.Shops[(int)shopNum.Value].BuyFrogCoin);
                this.shopBuyOptions.SetItemChecked(2, statsModel.Shops[(int)shopNum.Value].BuyOnlyA);
                this.shopBuyOptions.SetItemChecked(3, statsModel.Shops[(int)shopNum.Value].BuyOnlyB);
                this.shopDiscounts.SetItemChecked(0, statsModel.Shops[(int)shopNum.Value].Discount6);
                this.shopDiscounts.SetItemChecked(1, statsModel.Shops[(int)shopNum.Value].Discount12);
                this.shopDiscounts.SetItemChecked(2, statsModel.Shops[(int)shopNum.Value].Discount25);
                this.shopDiscounts.SetItemChecked(3, statsModel.Shops[(int)shopNum.Value].Discount50);
                updatingShops = false;
            }
        }

        #region Event Handlers
        private void shopNum_ValueChanged(object sender, EventArgs e)
        {
            RefreshShopsTab();
        }
        private void shopName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.shopNum.Value = shopName.SelectedIndex;
        }
        private void shopName_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index > 255)
                return;

            char[] test = shopName.Items[e.Index].ToString().ToCharArray();

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
            int[] temp = battleDialoguePreview.GetPreview(fontCharacters, palette, test, false);
            int[] pixels = new int[256 * 32];

            for (int y = 2, c = 11; c < 32; y++, c++)
            {
                for (int x = 2, a = 8; a < 256; x++, a++)
                    pixels[y * 256 + x] = temp[c * 256 + a];
            }

            Bitmap icon = new Bitmap(DrawImageFromIntArr(pixels, 256, 32));

            e.DrawBackground();
            e.Graphics.DrawImage(icon, new Point(e.Bounds.X, e.Bounds.Y));
            e.DrawFocusRectangle();
        }
        private void shopLabel_Leave(object sender, EventArgs e)
        {

        }
        private void shopLabel_TextChanged(object sender, EventArgs e)
        {
            if (settings.ShopNames[(int)shopNum.Value].CompareTo(shopLabel.Text) != 0)
            {
                settings.ShopNames[(int)shopNum.Value] = this.shopLabel.Text;

                shopName.BeginUpdate();
                shopName.Items.Clear();
                for (int i = 0; i < settings.ShopNames.Count; i++)
                    shopName.Items.Add(settings.ShopNames[i]);
                shopName.SelectedIndex = (int)shopNum.Value;
                shopName.EndUpdate();
            }
        }
        private void shopItem1_SelectedIndexChanged(object sender, EventArgs e)
        { 
            statsModel.Shops[(int)shopNum.Value].Items[0] = (byte)universal.ItemNames.GetNumFromIndex(this.shopItem1.SelectedIndex);
        }
        private void shopItem2_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Shops[(int)shopNum.Value].Items[1] = (byte)universal.ItemNames.GetNumFromIndex(this.shopItem2.SelectedIndex);
        }
        private void shopItem3_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Shops[(int)shopNum.Value].Items[2] = (byte)universal.ItemNames.GetNumFromIndex(this.shopItem3.SelectedIndex);
        }
        private void shopItem4_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Shops[(int)shopNum.Value].Items[3] = (byte)universal.ItemNames.GetNumFromIndex(this.shopItem4.SelectedIndex);
        }
        private void shopItem5_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Shops[(int)shopNum.Value].Items[4] = (byte)universal.ItemNames.GetNumFromIndex(this.shopItem5.SelectedIndex);
        }
        private void shopItem6_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Shops[(int)shopNum.Value].Items[5] = (byte)universal.ItemNames.GetNumFromIndex(this.shopItem6.SelectedIndex);
        }
        private void shopItem7_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Shops[(int)shopNum.Value].Items[6] = (byte)universal.ItemNames.GetNumFromIndex(this.shopItem7.SelectedIndex);
        }
        private void shopItem8_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Shops[(int)shopNum.Value].Items[7] = (byte)universal.ItemNames.GetNumFromIndex(this.shopItem8.SelectedIndex);
        }
        private void shopItem9_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Shops[(int)shopNum.Value].Items[8] = (byte)universal.ItemNames.GetNumFromIndex(this.shopItem9.SelectedIndex);
        }
        private void shopItem10_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Shops[(int)shopNum.Value].Items[9] = (byte)universal.ItemNames.GetNumFromIndex(this.shopItem10.SelectedIndex);
        }
        private void shopItem11_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Shops[(int)shopNum.Value].Items[10] = (byte)universal.ItemNames.GetNumFromIndex(this.shopItem11.SelectedIndex);
        }
        private void shopItem12_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Shops[(int)shopNum.Value].Items[11] = (byte)universal.ItemNames.GetNumFromIndex(this.shopItem12.SelectedIndex);
        }
        private void shopItem13_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Shops[(int)shopNum.Value].Items[12] = (byte)universal.ItemNames.GetNumFromIndex(this.shopItem13.SelectedIndex);
        }
        private void shopItem14_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Shops[(int)shopNum.Value].Items[13] = (byte)universal.ItemNames.GetNumFromIndex(this.shopItem14.SelectedIndex);
        }
        private void shopItem15_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Shops[(int)shopNum.Value].Items[14] = (byte)universal.ItemNames.GetNumFromIndex(this.shopItem15.SelectedIndex);
        }
        private void shopBuyOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Shops[(int)shopNum.Value].BuyFrogCoinOne = this.shopBuyOptions.GetItemChecked(0);
            statsModel.Shops[(int)shopNum.Value].BuyFrogCoin = this.shopBuyOptions.GetItemChecked(1);
            statsModel.Shops[(int)shopNum.Value].BuyOnlyA = this.shopBuyOptions.GetItemChecked(2);
            statsModel.Shops[(int)shopNum.Value].BuyOnlyB = this.shopBuyOptions.GetItemChecked(3);    
        }
        private void shopDiscounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Shops[(int)shopNum.Value].Discount6 = this.shopDiscounts.GetItemChecked(0);
            statsModel.Shops[(int)shopNum.Value].Discount12 = this.shopDiscounts.GetItemChecked(1);
            statsModel.Shops[(int)shopNum.Value].Discount25 = this.shopDiscounts.GetItemChecked(2);
            statsModel.Shops[(int)shopNum.Value].Discount50 = this.shopDiscounts.GetItemChecked(3);
        }
        #endregion
    }
}
