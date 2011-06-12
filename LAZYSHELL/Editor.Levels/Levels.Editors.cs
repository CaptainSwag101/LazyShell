using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public partial class Levels
    {
        #region Variables
        private delegate void Function();
        private PaletteEditor paletteEditor;
        private GraphicEditor graphicEditor;
        private LevelsTileset levelsTileset;
        private LevelsTilemap levelsTilemap;
        private LevelsSolidTiles levelsSolidTiles;
        private LevelsTemplate levelsTemplate;
        #endregion
        #region Functions
        private void PaletteUpdate()
        {
            fullUpdate = false;
            RefreshLevel();
            checksum--;   // b/c switching colors won't modify checksum
        }
        private void GraphicUpdate()
        {
            tileSet.AssembleIntoModel(16, levelsTileset.Layer);
            fullUpdate = false;
            RefreshLevel();
        }
        private void TilemapUpdate()
        {
        }
        private void TilesetUpdate()
        {
            tileMap.AssembleIntoModel();
            tileMap = new TileMap(level, tileSet);
            fullUpdate = false;
            RefreshLevel();
        }
        private void SolidityUpdate()
        {
            fullUpdate = true;
            solidityMap = new LevelSolidMap(levelMap);
            solidityMap.Image = null;
            LoadTilemapEditor();
        }
        //
        private void LoadPaletteEditor()
        {
            if (paletteEditor == null)
            {
                paletteEditor = new PaletteEditor(new Function(PaletteUpdate), paletteSet, 8, 1);
                paletteEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                paletteEditor.Reload(new Function(PaletteUpdate), paletteSet, 8, 1);
        }
        private void LoadGraphicEditor()
        {
            if (graphicEditor == null)
            {
                graphicEditor = new GraphicEditor(new Function(GraphicUpdate),
                    tileSet.Graphics, tileSet.Graphics.Length, 0, paletteSet, 1, 0x20);
                graphicEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                graphicEditor.Reload(new Function(GraphicUpdate),
                    tileSet.Graphics, tileSet.Graphics.Length, 0, paletteSet, 1, 0x20);
        }
        private void LoadTilemapEditor()
        {
            if (levelsTilemap == null)
            {
                levelsTilemap = new LevelsTilemap(
                    this, this.level, this.tileMap, this.solidityMap, this.tileSet, this.overlay,
                    this.paletteEditor, this.levelsTileset, this.levelsSolidTiles, this.levelsTemplate);
                levelsTilemap.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                levelsTilemap.Reload(
                  this, this.level, this.tileMap, this.solidityMap, this.tileSet, this.overlay,
                  this.paletteEditor, this.levelsTileset, this.levelsSolidTiles, this.levelsTemplate);
        }
        private void LoadTilesetEditor()
        {
            if (levelsTileset == null)
            {
                levelsTileset = new LevelsTileset(this.tileSet, new Function(TilesetUpdate), this.paletteSet, this.overlay);
                levelsTileset.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                levelsTileset.Reload(this.tileSet, new Function(TilesetUpdate), this.paletteSet, this.overlay);
        }
        private void LoadSolidityTileset()
        {
            levelsSolidTiles = new LevelsSolidTiles(solidity, new Function(SolidityUpdate));
            levelsSolidTiles.FormClosing += new FormClosingEventHandler(editor_FormClosing);
        }
        private void LoadTemplateEditor()
        {
            if (levelsTemplate == null)
            {
                levelsTemplate = new LevelsTemplate(this, this.overlay);
                levelsTemplate.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                levelsTemplate.Reload(this, this.overlay);
        }
        #endregion
        #region Event handlers
        private void editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            ((Form)sender).Hide();
        }
        //
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            tabControl.Visible = propertiesButton.Checked;
        }
        private void openPaletteEditor_Click(object sender, EventArgs e)
        {
            paletteEditor.Visible = true;
        }
        private void openGraphicEditor_Click(object sender, EventArgs e)
        {
            graphicEditor.Visible = true;
        }
        private void openTileset_Click(object sender, EventArgs e)
        {
            levelsTileset.Visible = openTileset.Checked;
            levelsTileset.Location = new Point(
                Screen.PrimaryScreen.WorkingArea.Width - levelsTileset.Size.Width - 5, this.Location.Y);
        }
        private void openTilemap_Click(object sender, EventArgs e)
        {
            levelsTilemap.Visible = openTilemap.Checked;
            levelsTilemap.Size = new Size(
                Screen.PrimaryScreen.WorkingArea.Width - levelsTileset.Width - this.Width - 10, this.Height);
            levelsTilemap.Location = new Point(this.Location.X + this.Size.Width, this.Location.Y);
        }
        private void openSolidTileset_Click(object sender, EventArgs e)
        {
            levelsSolidTiles.Visible = openSolidTileset.Checked;
            levelsSolidTiles.Location = new Point(
                Screen.PrimaryScreen.WorkingArea.Width - levelsSolidTiles.Size.Width, this.Location.Y);
        }
        private void openTemplates_Click(object sender, EventArgs e)
        {
            levelsTemplate.Visible = openTemplates.Checked;
            levelsTemplate.Location = new Point(
                Screen.PrimaryScreen.WorkingArea.Width - levelsTemplate.Size.Width, this.Location.Y);
        }
        #endregion
    }
}
