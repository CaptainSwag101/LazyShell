using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LazyShell.EventScripts;

namespace LazyShell.Undo
{
    class AnimationEdit : Edit
    {
        private int offset;
        private byte[] data;
        private Animations.OwnerForm form;
        private Animations.Command asc;
        public bool AutoRedo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="asc">The command being modified.</param>
        /// <param name="offset">The offset of the data.</param>
        /// <param name="internalOffset">The internal offset of the command.</param>
        /// <param name="data">The binary data.</param>
        public AnimationEdit(Animations.OwnerForm form, Animations.Command asc, int offset, byte[] data)
        {
            this.form = form;
            this.asc = asc;
            this.offset = offset;
            this.data = data;
            Execute(true);
        }

        // Execute
        public void Execute()
        {
            Execute(false);
        }
        public void Execute(bool push)
        {
            for (int i = 0; i < data.Length; i++)
            {
                byte temp = Model.ROM[offset + i];
                Model.ROM[offset + i] = data[i];
                data[i] = temp;
            }
            if (!push)
            {
                var temp = this.asc;
                this.asc = this.form.Command;
                this.form.Command = temp;
            }
        }
    }
    class GraphicEdit : Edit
    {
        private byte[] changes;
        private byte[] graphics;
        public bool AutoRedo { get; set; }

        // Constructor
        public GraphicEdit(byte[] graphics, byte[] changes)
        {
            this.graphics = graphics;
            this.changes = changes;
        }

        // Execute
        public void Execute()
        {
            byte[] temp = Bits.Copy(graphics);
            changes.CopyTo(graphics, 0);
            temp.CopyTo(changes, 0);
        }
    }

    #region Score

    class ScoreEdit : Edit
    {
        // class variables and accessors
        private object collection;
        private ScoreAction scoreAction;
        private int index;
        private object itemA;
        private object itemB;
        private object itemC;
        private object items;
        public bool AutoRedo { get; set; }

        // Constructor
        public ScoreEdit(ScoreAction scoreAction, object collection, int index, object item)
        {
            this.collection = collection;
            this.scoreAction = scoreAction;
            this.index = index;
            this.itemB = item;
            Execute();
        }
        public ScoreEdit(ScoreAction scoreAction, object collection, object items, int index)
        {
            this.collection = collection;
            this.scoreAction = scoreAction;
            this.index = index;
            this.items = items;
            Execute();
        }
        /// <summary>
        /// If inserting a note at a different octave
        /// </summary>
        /// <param name="scoreAction"></param>
        /// <param name="collection"></param>
        /// <param name="index"></param>
        /// <param name="itemA"></param>
        /// <param name="itemB"></param>
        public ScoreEdit(ScoreAction scoreAction, object collection, int index, object itemA, object itemB, object itemC)
        {
            this.collection = collection;
            this.scoreAction = scoreAction;
            this.index = index;
            this.itemA = itemA;
            this.itemB = itemB;
            this.itemC = itemC;
            Execute();
        }

        // Execute
        public void Execute()
        {
            if (scoreAction == ScoreAction.EraseNote)
            {
                scoreAction = ScoreAction.InsertNote;
                try
                {
                    ((List<object>)collection).Remove((Audio.Note)itemB);
                }
                catch
                {
                    if (itemA != null)
                        ((List<Audio.Command>)collection).Remove((Audio.Command)itemA);
                    ((List<Audio.Command>)collection).Remove((Audio.Command)itemB);
                    if (itemC != null)
                        ((List<Audio.Command>)collection).Remove((Audio.Command)itemC);
                }
            }
            else if (scoreAction == ScoreAction.InsertNote)
            {
                scoreAction = ScoreAction.EraseNote;
                try
                {
                    ((List<object>)collection).Insert(index, (Audio.Note)itemB);
                }
                catch
                {
                    if (itemC != null)
                        ((List<Audio.Command>)collection).Insert(index, (Audio.Command)itemC);
                    ((List<Audio.Command>)collection).Insert(index, (Audio.Command)itemB);
                    if (itemA != null)
                        ((List<Audio.Command>)collection).Insert(index, (Audio.Command)itemA);
                }
            }
            else if (scoreAction == ScoreAction.PasteNotes)
            {
                scoreAction = ScoreAction.DeleteNotes;
                try
                {
                    ((List<object>)collection).InsertRange(index, (List<object>)items);
                }
                catch
                {
                    ((List<Audio.Command>)collection).InsertRange(index, (List<Audio.Command>)items);
                }
            }
            else if (scoreAction == ScoreAction.DeleteNotes)
            {
                scoreAction = ScoreAction.PasteNotes;
                try
                {
                    ((List<object>)collection).RemoveRange(index, ((List<object>)items).Count);
                }
                catch
                {
                    ((List<Audio.Command>)collection).RemoveRange(index, ((List<Audio.Command>)items).Count);
                }
            }
            else if (scoreAction == ScoreAction.AddStaff)
            {
                scoreAction = ScoreAction.DeleteStaff;
                ((List<Audio.Staff>)collection).Insert(index, (Audio.Staff)itemB);
            }
            else if (scoreAction == ScoreAction.DeleteStaff)
            {
                scoreAction = ScoreAction.AddStaff;
                ((List<Audio.Staff>)collection).Remove((Audio.Staff)itemB);
            }
        }
    }
    public enum ScoreAction
    {
        InsertNote,
        EraseNote,
        PasteNotes,
        DeleteNotes,
        AddStaff,
        DeleteStaff
    }

    #endregion

    #region Sprite

    class SpriteEdit : Edit
    {
        private List<Sprites.Mold> molds;
        private ListBox listbox;
        private Sprites.Mold moldA;
        private Sprites.Mold moldB;
        private int index;
        private int indexB;
        private SpriteAction action;
        public bool AutoRedo { get; set; }

        // Constructor
        public SpriteEdit(SpriteAction action, List<Sprites.Mold> molds, ListBox listbox, 
            Sprites.Mold moldA, Sprites.Mold moldB, int index, int indexB)
        {
            this.action = action;
            this.molds = molds;
            this.listbox = listbox;
            this.moldA = moldA.Copy();
            this.moldB = moldB.Copy();
            this.index = index;
            this.indexB = indexB;
        }

        // Execute
        public void Execute()
        {
            if (action == SpriteAction.Edit)
            {
                this.molds[index] = this.moldB.Copy();
                var temp = this.moldA.Copy();
                this.moldA = this.moldB.Copy();
                this.moldB = temp;
                this.listbox.SelectedIndex = this.index;
            }
            else if (action == SpriteAction.Create)
            {
                this.molds.RemoveAt(index);
                this.listbox.Items.RemoveAt(index);
                this.listbox.SelectedIndex = Math.Min(this.index, this.listbox.Items.Count - 1);
                this.action = SpriteAction.Delete;
            }
            else if (action == SpriteAction.Delete)
            {
                this.molds.Insert(index, moldB.Copy());
                this.listbox.Items.Insert(index, "Mold " + index);
                this.listbox.SelectedIndex = Math.Min(this.index, this.listbox.Items.Count - 1);
                this.action = SpriteAction.Create;
            }
            else if (action == SpriteAction.MoveDown)
            {
                this.molds.Reverse(index, 2);
                this.listbox.SelectedIndex = index;
                this.action = SpriteAction.MoveUp;
            }
            else if (action == SpriteAction.MoveUp)
            {
                this.molds.Reverse(index, 2);
                this.listbox.SelectedIndex = index + 1;
                this.action = SpriteAction.MoveDown;
            }
            else if (action == SpriteAction.IndexChange)
            {
                this.listbox.SelectedIndex = this.indexB;
                int index = this.index;
                this.index = this.indexB;
                this.indexB = index;
            }
            //
        }
    }
    enum SpriteAction
    {
        Edit, MoveUp, MoveDown, Delete, Create, IndexChange
    }

    class MoldEdit : Edit
    {
        private byte[] src;
        private Size srcSize;
        private byte[] changes;
        private Point location;
        private Size size;
        public bool AutoRedo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="src">The source array to modify.</param>
        /// <param name="srcWidth">The width, in tiles, of the source array.</param>
        /// <param name="srcHeight">The height, in tiles, of the source array.</param>
        /// <param name="changes">The changes to apply to the source array.</param>
        /// <param name="x">The X location, in tiles, where the changes will be applied.</param>
        /// <param name="y">The Y location, in tiles, where the changes will be applied.</param>
        /// <param name="width">The width, in tiles, of the changes.</param>
        /// <param name="height">The height, in tiles, of the changes.</param>
        public MoldEdit(byte[] src, int srcWidth, int srcHeight, byte[] changes, int x, int y, int width, int height)
        {
            this.src = src;
            this.changes = new byte[changes.Length];
            changes.CopyTo(this.changes, 0);
            this.srcSize = new Size(srcWidth, srcHeight);
            this.size = new Size(width, height);
            this.location = new Point(x, y);
            Execute();
        }

        // Execute
        public void Execute()
        {
            for (int y = location.Y, y_ = 0; y < location.Y + size.Height && y < 16; y++, y_++)
            {
                for (int x = location.X, x_ = 0; x < location.X + size.Width && x < 16; x++, x_++)
                {
                    if (x < 0 || y < 0 || x_ < 0 || y_ < 0) continue;
                    byte temp = src[y * srcSize.Width + x];
                    src[y * srcSize.Width + x] = changes[y_ * size.Width + x_];
                    changes[y_ * size.Width + x_] = temp;
                }
            }
        }
    }

    #endregion

    class TilesetEdit : Edit
    {
        private byte[] oldTileset;
        private Tileset tileset;
        private byte[] graphics;
        private int index;
        private byte format;
        private Battlefields.OwnerForm form;
        private Battlefields.Tileset battlefieldTileset;
        private System.Windows.Forms.ToolStripComboBox name;
        public bool AutoRedo { get; set; }

        // Constructors
        public TilesetEdit(Tileset tileset, byte[] oldTileset, byte[] graphics,
            byte format, System.Windows.Forms.ToolStripComboBox name)
        {
            this.tileset = tileset;
            this.oldTileset = oldTileset;
            this.graphics = graphics;
            this.format = format;
            this.name = name;
            if (name != null)
                this.index = (int)name.SelectedIndex;
        }
        public TilesetEdit(Battlefields.Tileset tileset, byte[] oldTileset, Battlefields.OwnerForm form)
        {
            this.battlefieldTileset = tileset;
            this.oldTileset = oldTileset;
            this.form = form;
            this.index = form.Index;
        }

        // Execute
        public void Execute()
        {
            if (tileset != null)
            {
                byte[] temp = Bits.Copy(tileset.Tileset_bytes);
                oldTileset.CopyTo(tileset.Tileset_bytes, 0);
                tileset.BuildTilesetTiles(tileset.Tileset_bytes, tileset.Tileset_tiles, graphics, format);
                oldTileset = temp;
                if (name != null)
                    name.SelectedIndex = index;
            }
            else if (battlefieldTileset != null)
            {
                byte[] temp = Bits.Copy(battlefieldTileset.Tileset_bytes);
                oldTileset.CopyTo(battlefieldTileset.Tileset_bytes, 0);
                battlefieldTileset.ParseTileset(battlefieldTileset.Tileset_bytes, battlefieldTileset.Tileset_tiles);
                oldTileset = temp;
                form.Index = index;
            }
        }
    }
}
