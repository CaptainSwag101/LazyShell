using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL.Areas
{
    public partial class MapForm : Controls.DockForm
    {
        #region Variables

        private OwnerForm ownerForm;
        private Area area
        {
            get { return ownerForm.Area; }
            set { ownerForm.Area = value; }
        }
        private Map map
        {
            get { return areaMaps[area.Map]; }
            set { areaMaps[area.Map] = value; }
        }
        private Map[] areaMaps
        {
            get { return Model.Maps; }
            set { Model.Maps = value; }
        }
        private PaletteSet[] paletteSets
        {
            get { return Model.PaletteSets; }
            set { Model.PaletteSets = value; }
        }
        private PaletteSet paletteSet
        {
            get { return paletteSets[map.PaletteSet]; }
            set { paletteSets[map.PaletteSet] = value; }
        }
        private Tileset tileset
        {
            get { return ownerForm.Tileset; }
            set { ownerForm.Tileset = value; }
        }
        private Tilemap tilemap
        {
            get { return ownerForm.Tilemap; }
            set { ownerForm.Tilemap = value; }
        }
        private CollisionMap collisionMap
        {
            get { return ownerForm.CollisionMap; }
            set { ownerForm.CollisionMap = value; }
        }
        private TilemapForm tilemapForm
        {
            get { return ownerForm.TilemapForm; }
            set { ownerForm.TilemapForm = value; }
        }
        private TilesetForm[] tilesetForms
        {
            get { return ownerForm.TilesetForms; }
            set { ownerForm.TilesetForms = value; }
        }

        #endregion

        // Constructor
        public MapForm(OwnerForm ownerForm)
        {
            this.ownerForm = ownerForm;
            InitializeComponent();
            InitializeListControls();
        }

        #region Methods

        private void InitializeListControls()
        {
            this.Updating = true;
            //
            this.gfxSet1Name.Items.AddRange(Lists.Numerize(Lists.GraphicSets));
            this.gfxSet2Name.Items.AddRange(Lists.Numerize(Lists.GraphicSets));
            this.gfxSet3Name.Items.AddRange(Lists.Numerize(Lists.GraphicSets));
            this.gfxSet4Name.Items.AddRange(Lists.Numerize(Lists.GraphicSets));
            this.gfxSet5Name.Items.AddRange(Lists.Numerize(Lists.GraphicSets));
            this.tilesetL1Name.Items.AddRange(Lists.Numerize(Lists.TileSetNames));
            this.tilesetL2Name.Items.AddRange(Lists.Numerize(Lists.TileSetNames));
            this.tilesetL3Name.Items.AddRange(Lists.Numerize(Lists.TilesetsL3));
            this.tilemapL1Name.Items.AddRange(Lists.Numerize(Lists.Tilemaps));
            this.tilemapL2Name.Items.AddRange(Lists.Numerize(Lists.Tilemaps));
            this.tilemapL3Name.Items.AddRange(Lists.Numerize(Lists.TilemapsL3));
            this.collisionMapName.Items.AddRange(Lists.Numerize(Lists.CollisionMaps));
            this.paletteSetName.Items.AddRange(Lists.Numerize(Lists.PaletteSets));
            //
            this.Updating = false;
        }
        //
        public void LoadProperties()
        {
            this.Updating = true;
            // 
            this.gfxSet1Num.Value = map.GraphicSet1;
            this.gfxSet1Name.SelectedIndex = map.GraphicSet1;
            this.gfxSet2Num.Value = map.GraphicSet2;
            this.gfxSet2Name.SelectedIndex = map.GraphicSet2;
            this.gfxSet3Num.Value = map.GraphicSet3;
            this.gfxSet3Name.SelectedIndex = map.GraphicSet3;
            this.gfxSet4Num.Value = map.GraphicSet4;
            this.gfxSet4Name.SelectedIndex = map.GraphicSet4;
            this.gfxSet5Num.Value = map.GraphicSet5;
            this.gfxSet5Name.SelectedIndex = map.GraphicSet5;
            if (map.GraphicSetL3 > 0x1b)
            {
                this.gfxSetL3Num.Value = 0x1c;
                this.gfxSetL3Name.SelectedIndex = 0x1c;
            }
            else
            {
                this.gfxSetL3Num.Value = map.GraphicSetL3;
                this.gfxSetL3Name.SelectedIndex = map.GraphicSetL3;
            }
            this.tilesetL1Num.Value = map.TilesetL1;
            this.tilesetL1Name.SelectedIndex = map.TilesetL1;
            this.tilesetL2Num.Value = map.TilesetL2;
            this.tilesetL2Name.SelectedIndex = map.TilesetL2;
            this.tilesetL3Num.Value = map.TilesetL3;
            this.tilesetL3Name.SelectedIndex = map.TilesetL3;
            this.tilemapL1Num.Value = map.TilemapL1;
            this.tilemapL1Name.SelectedIndex = map.TilemapL1;
            this.tilemapL2Num.Value = map.TilemapL2;
            this.tilemapL2Name.SelectedIndex = map.TilemapL2;
            this.tilemapL3Num.Value = map.TilemapL3;
            this.tilemapL3Name.SelectedIndex = map.TilemapL3;
            this.collisionMapNum.Value = map.CollisionMap;
            this.collisionMapName.SelectedIndex = map.CollisionMap;
            this.battlefieldNum.Value = map.Battlefield;
            this.battlefieldName.SelectedIndex = map.Battlefield;
            if (map.GraphicSetL3 > 0x1b)
            {
                this.tilesetL3Num.Enabled = false;
                this.tilesetL3Name.Enabled = false;
                this.tilemapL3Num.Enabled = false;
                this.tilemapL3Name.Enabled = false;
            }
            else
            {
                this.tilesetL3Num.Enabled = true;
                this.tilesetL3Name.Enabled = true;
                this.tilemapL3Num.Enabled = true;
                this.tilemapL3Name.Enabled = true;
            }
            this.topPriorityL3.Checked = map.TopPriorityL3;
            this.paletteSetNum.Value = map.PaletteSet;
            this.paletteSetName.SelectedIndex = map.PaletteSet;
            // Finished
            this.Updating = false;
        }
        /// <summary>
        /// Called when the map index has been changed.
        /// </summary>
        public void MapChanged()
        {
            tileset = new Tileset(map, paletteSet);
            foreach (var tilesetForm in tilesetForms)
                tilesetForm.SetTilesetImage();
            tilemap = new AreaTilemap(area, tileset);
            tilemapForm.SetTilemapImage();
            ownerForm.ReloadPaletteEditor();
            ownerForm.ReloadGraphicEditor();
        }
        /// <summary>
        /// Called when a graphic set has been changed by the user.
        /// </summary>
        private void GraphicSetChanged()
        {
            tileset.InitializeGraphics();
            tileset.BuildTilesetTiles();
            foreach (var tilesetForm in tilesetForms)
                tilesetForm.SetTilesetImage();
            tilemap.RedrawTilemaps();
            tilemapForm.SetTilemapImage();
            ownerForm.ReloadGraphicEditor();
        }
        /// <summary>
        /// Called when a tileset has been changed by the user.
        /// </summary>
        /// <param name="layer">The layer that has changed.</param>
        private void TilesetChanged(int layer)
        {
            tileset.RedrawTilesets(layer);
            foreach (var tilesetForm in tilesetForms)
                tilesetForm.SetTilesetImage();
            tilemap.RedrawTilemaps();
            tilemapForm.SetTilemapImage();
        }
        /// <summary>
        /// Called when a tilemap has been changed by the user.
        /// </summary>
        private void TilemapChanged()
        {
            tilemap.RedrawTilemaps();
            tilemapForm.SetTilemapImage();
        }
        /// <summary>
        /// Called when the collision map has been changed by the user.
        /// </summary>
        private void CollisionMapChanged()
        {
            collisionMap = new CollisionMap(map);
            collisionMap.Image = null;
            tilemapForm.Picture.Invalidate();
        }
        /// <summary>
        /// Called when the palette set has been changed by the user.
        /// </summary>
        private void PaletteSetChanged()
        {
            tileset.PaletteSet = paletteSet;
            tileset.BuildTilesetTiles();
            foreach (var tilesetForm in tilesetForms)
                tilesetForm.SetTilesetImage();
            tilemap.RedrawTilemaps();
            tilemapForm.SetTilemapImage();
            ownerForm.ReloadPaletteEditor();
        }

        #endregion

        #region Event Handlers

        // Properties
        private void gfxSet1Num_ValueChanged(object sender, EventArgs e)
        {
            gfxSet1Name.SelectedIndex = (int)gfxSet1Num.Value;
            map.GraphicSet1 = (byte)this.gfxSet1Num.Value;
            if (!this.Updating)
                GraphicSetChanged();
        }
        private void gfxSet2Num_ValueChanged(object sender, EventArgs e)
        {
            gfxSet2Name.SelectedIndex = (int)gfxSet2Num.Value;
            map.GraphicSet2 = (byte)this.gfxSet2Num.Value;
            if (!this.Updating)
                GraphicSetChanged();
        }
        private void gfxSet3Num_ValueChanged(object sender, EventArgs e)
        {
            gfxSet3Name.SelectedIndex = (int)gfxSet3Num.Value;
            map.GraphicSet3 = (byte)this.gfxSet3Num.Value;
            if (!this.Updating)
                GraphicSetChanged();
        }
        private void gfxSet4Num_ValueChanged(object sender, EventArgs e)
        {
            gfxSet4Name.SelectedIndex = (int)gfxSet4Num.Value;
            map.GraphicSet4 = (byte)this.gfxSet4Num.Value;
            if (!this.Updating)
                GraphicSetChanged();
        }
        private void gfxSet5Num_ValueChanged(object sender, EventArgs e)
        {
            gfxSet5Name.SelectedIndex = (int)gfxSet5Num.Value;
            map.GraphicSet5 = (byte)this.gfxSet5Num.Value;
            if (!this.Updating)
                GraphicSetChanged();
        }
        private void gfxSetL3Num_ValueChanged(object sender, EventArgs e)
        {
            gfxSetL3Name.SelectedIndex = (int)gfxSetL3Num.Value;
            if (this.gfxSetL3Num.Value > 0x1B)
            {
                map.GraphicSetL3 = 0xFF;
                this.tilesetL3Num.Enabled = false;
                this.tilesetL3Name.Enabled = false;
                this.tilemapL3Num.Enabled = false;
                this.tilemapL3Name.Enabled = false;
                if (!this.Updating && ownerForm.Layer == 2)
                    ownerForm.Layer = 0;
            }
            else
            {
                map.GraphicSetL3 = (byte)this.gfxSetL3Num.Value;
                this.tilesetL3Num.Enabled = true;
                this.tilesetL3Name.Enabled = true;
                this.tilemapL3Num.Enabled = true;
                this.tilemapL3Name.Enabled = true;
            }
            if (!this.Updating)
                GraphicSetChanged();
        }
        private void gfxSet1Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            gfxSet1Num.Value = gfxSet1Name.SelectedIndex;
        }
        private void gfxSet2Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            gfxSet2Num.Value = gfxSet2Name.SelectedIndex;
        }
        private void gfxSet3Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            gfxSet3Num.Value = gfxSet3Name.SelectedIndex;
        }
        private void gfxSet4Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            gfxSet4Num.Value = gfxSet4Name.SelectedIndex;
        }
        private void gfxSet5Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            gfxSet5Num.Value = gfxSet5Name.SelectedIndex;
        }
        private void gfxSetL3Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            gfxSetL3Num.Value = gfxSetL3Name.SelectedIndex;
        }

        // Tileset
        private void tilesetL1Num_ValueChanged(object sender, EventArgs e)
        {
            tilesetL1Name.SelectedIndex = (int)tilesetL1Num.Value;
            map.TilesetL1 = (byte)this.tilesetL1Num.Value;
            if (!this.Updating)
                TilesetChanged(0);
        }
        private void tilesetL2Num_ValueChanged(object sender, EventArgs e)
        {
            tilesetL2Name.SelectedIndex = (int)tilesetL2Num.Value;
            map.TilesetL2 = (byte)this.tilesetL2Num.Value;
            if (!this.Updating)
                TilesetChanged(1);
        }
        private void tilesetL3Num_ValueChanged(object sender, EventArgs e)
        {
            tilesetL3Name.SelectedIndex = (int)tilesetL3Num.Value;
            map.TilesetL3 = (byte)this.tilesetL3Num.Value;
            if (!this.Updating)
                TilesetChanged(2);
        }
        private void tilesetL1Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            tilesetL1Num.Value = tilesetL1Name.SelectedIndex;
        }
        private void tilesetL2Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            tilesetL2Num.Value = tilesetL2Name.SelectedIndex;
        }
        private void tilesetL3Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            tilesetL3Num.Value = tilesetL3Name.SelectedIndex;
        }

        // Tilemap
        private void tilemapL1Num_ValueChanged(object sender, EventArgs e)
        {
            tilemapL1Name.SelectedIndex = (int)tilemapL1Num.Value;
            map.TilemapL1 = (byte)this.tilemapL1Num.Value;
            if (!this.Updating)
                TilemapChanged();
        }
        private void tilemapL2Num_ValueChanged(object sender, EventArgs e)
        {
            tilemapL2Name.SelectedIndex = (int)tilemapL2Num.Value;
            map.TilemapL2 = (byte)this.tilemapL2Num.Value;
            if (!this.Updating)
                TilemapChanged();
        }
        private void tilemapL3Num_ValueChanged(object sender, EventArgs e)
        {
            tilemapL3Name.SelectedIndex = (int)tilemapL3Num.Value;
            map.TilemapL3 = (byte)this.tilemapL3Num.Value;
            if (!this.Updating)
                TilemapChanged();
        }
        private void tilemapL1Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            tilemapL1Num.Value = tilemapL1Name.SelectedIndex;
        }
        private void tilemapL2Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            tilemapL2Num.Value = tilemapL2Name.SelectedIndex;
        }
        private void tilemapL3Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            tilemapL3Num.Value = tilemapL3Name.SelectedIndex;
        }
        private void topPriorityL3_CheckedChanged(object sender, EventArgs e)
        {
            topPriorityL3.ForeColor = topPriorityL3.Checked ? Color.Black : Color.Gray;
            map.TopPriorityL3 = topPriorityL3.Checked;
            if (!this.Updating)
                TilemapChanged();
        }

        // Collision map
        private void collisionMapNum_ValueChanged(object sender, EventArgs e)
        {
            collisionMapName.SelectedIndex = (int)collisionMapNum.Value;
            map.CollisionMap = (byte)this.collisionMapNum.Value;
            if (!this.Updating)
                CollisionMapChanged();
        }
        private void collisionMapName_SelectedIndexChanged(object sender, EventArgs e)
        {
            collisionMapNum.Value = collisionMapName.SelectedIndex;
        }

        // Battlefield
        private void battlefieldNum_ValueChanged(object sender, EventArgs e)
        {
            battlefieldName.SelectedIndex = (int)battlefieldNum.Value;
            map.Battlefield = (byte)this.battlefieldNum.Value;
        }
        private void battlefieldName_SelectedIndexChanged(object sender, EventArgs e)
        {
            battlefieldNum.Value = battlefieldName.SelectedIndex;
        }

        // Palette set
        private void paletteSetNum_ValueChanged(object sender, EventArgs e)
        {
            paletteSetName.SelectedIndex = (int)paletteSetNum.Value;
            map.PaletteSet = (byte)this.paletteSetNum.Value;
            if (!this.Updating)
                PaletteSetChanged();
        }
        private void paletteSetName_SelectedIndexChanged(object sender, EventArgs e)
        {
            paletteSetNum.Value = paletteSetName.SelectedIndex;
        }

        // toolstrip
        private void clearAllCollisionMaps_Click(object sender, EventArgs e)
        {
            if (new ClearElements(null, (int)collisionMapNum.Value, "CLEAR COLLISION MAPS...").ShowDialog() == DialogResult.Cancel)
                return;
            CollisionMapChanged();
        }
        private void resetAreaMap_Click(object sender, EventArgs e)
        {
        }

        #endregion
    }
}
