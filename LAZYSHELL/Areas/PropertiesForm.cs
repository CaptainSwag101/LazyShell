using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL.Areas
{
    public partial class PropertiesForm : Controls.DockForm
    {
        #region Variables

        private OwnerForm ownerForm;
        private MapForm mapForm
        {
            get { return ownerForm.MapForm; }
            set { ownerForm.MapForm = value; }
        }
        private PriorityForm priorityForm
        {
            get { return ownerForm.PriorityForm; }
            set { ownerForm.PriorityForm = value; }
        }
        private Area area
        {
            get { return ownerForm.Area; }
            set { ownerForm.Area = value; }
        }
        private Map map
        {
            get { return ownerForm.Map; }
            set { ownerForm.Map = value; }
        }
        private PaletteSet paletteSet
        {
            get { return ownerForm.PaletteSet; }
            set { ownerForm.PaletteSet = value; }
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
        private Layering layering
        {
            get { return area.Layering; }
            set { area.Layering = value; }
        }
        private EventTriggerCollection events
        {
            get { return area.EventTriggers; }
            set { area.EventTriggers = value; }
        }
        public NPCObjectCollection NPCObjects
        {
            get { return area.NPCObjects; }
            set { area.NPCObjects = value; }
        }
        private SpritePartitionsForm spritePartitionsForm;

        #endregion

        // Constructor
        public PropertiesForm(OwnerForm ownerForm)
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
            this.mapName.Items.AddRange(Lists.Numerize(Lists.Maps));
            this.startMusic.Items.AddRange(Lists.Numerize(Lists.SPCTracks));
            this.banner.Items.Add("{NONE}");
            var dialogues = Dialogues.Model.GetDialogues(0, 128);
            string[] tables = Dialogues.Model.DTEStr(true);
            for (int i = 0; i < 128; i++)
                this.banner.Items.Add(dialogues[i].GetStub(true, tables));
            //
            this.Updating = false;
        }
        //
        public void LoadProperties()
        {
            this.Updating = true;

            // Map
            this.mapNum.Value = area.Map;
            this.prioritySetNum.Value = layering.PrioritySet;
            this.spritePartition.Value = NPCObjects.Partition;

            // Entrance
            this.startEvent.Value = events.StartEvent;
            this.startMusic.SelectedIndex = events.StartMusic;
            this.banner.SelectedIndex = layering.Banner;

            // Finished
            this.Updating = false;
        }

        #endregion

        #region Event Handlers

        // Map
        private void mapNum_ValueChanged(object sender, EventArgs e)
        {
            mapName.SelectedIndex = (int)mapNum.Value;
            if (!this.Updating)
            {
                area.Map = (int)mapNum.Value;
                mapForm.LoadProperties();
                tileset = new Tileset(map, paletteSet);
                tilemap = new AreaTilemap(area, tileset);
                ownerForm.TilemapForm.SetTilemapImage();
            }
        }
        private void mapName_SelectedIndexChanged(object sender, EventArgs e)
        {
            mapNum.Value = mapName.SelectedIndex;
        }
        private void prioritySetNum_ValueChanged(object sender, EventArgs e)
        {
            layering.PrioritySet = (byte)prioritySetNum.Value;
            if (!this.Updating)
            {
                priorityForm.LoadProperties();
                tilemap.RedrawTilemaps();
            }
        }
        private void spritePartition_ValueChanged(object sender, System.EventArgs e)
        {
            NPCObjects.Partition = (byte)this.spritePartition.Value;
        }

        // Entrance
        private void startEvent_ValueChanged(object sender, EventArgs e)
        {
            events.StartEvent = (ushort)this.startEvent.Value;
        }
        private void startMusic_SelectedIndexChanged(object sender, EventArgs e)
        {
            events.StartMusic = (byte)this.startMusic.SelectedIndex;
        }
        private void banner_SelectedIndexChanged(object sender, EventArgs e)
        {
            layering.Banner = (byte)banner.SelectedIndex;
        }

        // Buttons
        private void openPartitions_Click(object sender, System.EventArgs e)
        {
            if (spritePartitionsForm == null)
            {
                spritePartitionsForm = new SpritePartitionsForm(ownerForm, Model.SpritePartitions, NPCObjects.Partition);
                spritePartitionsForm.BringToFront();
                spritePartitionsForm.Owner = this;
            }
            else
                spritePartitionsForm.Index = NPCObjects.Partition;
            spritePartitionsForm.Show(this);
        }
        private void buttonGotoC_Click(object sender, EventArgs e)
        {
            if (LAZYSHELL.Model.Program.EventScripts == null || !LAZYSHELL.Model.Program.EventScripts.Visible)
                LAZYSHELL.Model.Program.CreateEventScriptsWindow();
            LAZYSHELL.Model.Program.EventScripts.Type = 0;
            LAZYSHELL.Model.Program.EventScripts.Index = (int)startEvent.Value;
            LAZYSHELL.Model.Program.EventScripts.BringToFront();
        }

        #endregion
    }
}
