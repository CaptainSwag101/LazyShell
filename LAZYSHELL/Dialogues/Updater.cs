using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL.Dialogues
{
    class GraphicUpdater : LAZYSHELL.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LAZYSHELL.Model.Program.Dialogues.BattleDialoguesForm.UpdateGraphics();
        }
    }
    class PaletteUpdater : LAZYSHELL.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LAZYSHELL.Model.Program.Dialogues.BattleDialoguesForm.UpdatePalette();
        }
    }
    class PaletteMenuUpdater : LAZYSHELL.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LAZYSHELL.Model.Program.Dialogues.BattleDialoguesForm.UpdatePaletteMenu();
        }
    }
    class TileUpdater : LAZYSHELL.TileUpdater
    {
        public override void UpdateTile()
        {
            LAZYSHELL.Model.Program.Dialogues.BattleDialoguesForm.UpdateTile();
        }
    }
}
