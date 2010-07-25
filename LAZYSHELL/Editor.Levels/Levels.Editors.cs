using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public partial class Levels
    {
        private delegate void Function();

        private PaletteEditor paletteEditor;
        private GraphicEditor graphicEditor;
        private LevelsTileset levelsTileset;
        private LevelsTilemap levelsTilemap;
        private LevelsPhysicalTiles levelsPhysicalTiles;
        private LevelsTemplate levelsTemplate;

        private void PaletteUpdate()
        {
            updating = true; // Start
            tileSet.RedrawTilesets(); // Redraw all tilesets
            tileMap.RedrawTileMap();
            LoadTilesetEditor();
            LoadTilemapEditor();
            LoadTemplateEditor();
            updating = false; // Done
        }
        private void GraphicUpdate()
        {
            updating = true; // Start
            tileSet.RedrawTilesets(); // Redraw all tilesets
            tileMap.RedrawTileMap();
            LoadTilesetEditor();
            LoadTilemapEditor();
            LoadTemplateEditor();
            updating = false; // Done
        }
        private void TilemapUpdate()
        {
        }
        private void TilesetUpdate()
        {
            fullUpdate = false;
            RefreshLevel();
        }

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
                    this.model, this, this.level,
                    this.tileMap, this.physicalMap, this.tileSet, this.overlay, this.state,
                    this.paletteEditor, this.levelsTileset, this.levelsPhysicalTiles, this.levelsTemplate);
                levelsTilemap.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                levelsTilemap.Reload(
                  this.model, this, this.level,
                  this.tileMap, this.physicalMap, this.tileSet, this.overlay, this.state,
                  this.paletteEditor, this.levelsTileset, this.levelsPhysicalTiles, this.levelsTemplate);
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
        private void LoadPhysicalTileset()
        {
            levelsPhysicalTiles = new LevelsPhysicalTiles(physicalTiles, solids);
            levelsPhysicalTiles.FormClosing += new FormClosingEventHandler(editor_FormClosing);
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
        private void editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            ((Form)sender).Hide();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            tabControl.Visible = toolStripButton2.Checked;
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
            levelsPhysicalTiles.Visible = openSolidTileset.Checked;
            levelsPhysicalTiles.Location = new Point(
                Screen.PrimaryScreen.WorkingArea.Width - levelsPhysicalTiles.Size.Width, this.Location.Y);
        }
        private void openTemplates_Click(object sender, EventArgs e)
        {
            levelsTemplate.Visible = openTemplates.Checked;
            levelsTemplate.Location = new Point(
                Screen.PrimaryScreen.WorkingArea.Width - levelsTemplate.Size.Width, this.Location.Y);
        }
    }
}
