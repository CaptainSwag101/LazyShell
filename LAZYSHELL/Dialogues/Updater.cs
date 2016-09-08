using System;
using System.Collections.Generic;
using System.Text;

namespace LazyShell.Dialogues
{
    class GraphicUpdater : LazyShell.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LazyShell.Model.Program.Dialogues.BattleDialoguesForm.UpdateGraphics();
        }
    }
    class PaletteUpdater : LazyShell.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LazyShell.Model.Program.Dialogues.BattleDialoguesForm.UpdatePalette();
        }
    }
    class PaletteMenuUpdater : LazyShell.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LazyShell.Model.Program.Dialogues.BattleDialoguesForm.UpdatePaletteMenu();
        }
    }
    class TileUpdater : LazyShell.TileUpdater
    {
        public override void UpdateTile()
        {
            LazyShell.Model.Program.Dialogues.BattleDialoguesForm.UpdateTile();
        }
    }
}
