namespace LAZYSHELL
{
    partial class Restore
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Audio");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Monsters");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Formations");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Spells");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Attacks");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Items");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Shops");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Level-ups");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Starting stats");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Timings");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Stats", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Layers");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Maps");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("NPCs");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Exits");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Events");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Overlaps");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Tile mods");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Solid mods");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Tilemaps");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Tilesets");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Graphics");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Solidity maps");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Battlefields");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Battlefield tilesets");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Battlefield Graphics");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Levels", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22,
            treeNode23,
            treeNode24,
            treeNode25,
            treeNode26});
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Event scripts");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Action scripts");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("Battle scripts");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Animation scripts");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("Scripts", new System.Windows.Forms.TreeNode[] {
            treeNode28,
            treeNode29,
            treeNode30,
            treeNode31});
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("Sprites");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("Spell effects");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("Dialogues");
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("Battle Dialogues");
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("Fonts, backgrounds");
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("World map tilesets");
            System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("World maps");
            System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode("Sprites", new System.Windows.Forms.TreeNode[] {
            treeNode33,
            treeNode34,
            treeNode35,
            treeNode36,
            treeNode37,
            treeNode38,
            treeNode39});
            System.Windows.Forms.TreeNode treeNode41 = new System.Windows.Forms.TreeNode("Main Title");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Restore));
            this.elements = new System.Windows.Forms.TreeView();
            this.browseFreshRom = new System.Windows.Forms.Button();
            this.freshRomTextBox = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // elements
            // 
            this.elements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.elements.CheckBoxes = true;
            this.elements.Location = new System.Drawing.Point(12, 41);
            this.elements.Name = "elements";
            treeNode1.Name = "Audio";
            treeNode1.Text = "Audio";
            treeNode2.Name = "Monsters";
            treeNode2.Text = "Monsters";
            treeNode3.Name = "Formations";
            treeNode3.Text = "Formations";
            treeNode4.Name = "Spells";
            treeNode4.Text = "Spells";
            treeNode5.Name = "Attacks";
            treeNode5.Text = "Attacks";
            treeNode6.Name = "Items";
            treeNode6.Text = "Items";
            treeNode7.Name = "Shops";
            treeNode7.Text = "Shops";
            treeNode8.Name = "LevelUps";
            treeNode8.Text = "Level-ups";
            treeNode9.Name = "StartingStats";
            treeNode9.Text = "Starting stats";
            treeNode10.Name = "Timings";
            treeNode10.Text = "Timings";
            treeNode11.Name = "Stats";
            treeNode11.Text = "Stats";
            treeNode12.Name = "Layers";
            treeNode12.Text = "Layers";
            treeNode13.Name = "Maps";
            treeNode13.Text = "Maps";
            treeNode14.Name = "NPCs";
            treeNode14.Text = "NPCs";
            treeNode15.Name = "Exits";
            treeNode15.Text = "Exits";
            treeNode16.Name = "Events";
            treeNode16.Text = "Events";
            treeNode17.Name = "Overlaps";
            treeNode17.Text = "Overlaps";
            treeNode18.Name = "TileMods";
            treeNode18.Text = "Tile mods";
            treeNode19.Name = "SolidMods";
            treeNode19.Text = "Solid mods";
            treeNode20.Name = "Tilemaps";
            treeNode20.Text = "Tilemaps";
            treeNode21.Name = "Tilesets";
            treeNode21.Text = "Tilesets";
            treeNode22.Name = "Graphics";
            treeNode22.Text = "Graphics";
            treeNode23.Name = "SolidityMaps";
            treeNode23.Text = "Solidity maps";
            treeNode24.Name = "Battlefields";
            treeNode24.Text = "Battlefields";
            treeNode25.Name = "BattlefieldTilesets";
            treeNode25.Text = "Battlefield tilesets";
            treeNode26.Name = "BattlefieldGraphics";
            treeNode26.Text = "Battlefield Graphics";
            treeNode27.Name = "Levels";
            treeNode27.Text = "Levels";
            treeNode28.Name = "EventScripts";
            treeNode28.Text = "Event scripts";
            treeNode29.Name = "ActionScripts";
            treeNode29.Text = "Action scripts";
            treeNode30.Name = "BattleScripts";
            treeNode30.Text = "Battle scripts";
            treeNode31.Name = "AnimationScripts";
            treeNode31.Text = "Animation scripts";
            treeNode32.Name = "Scripts";
            treeNode32.Text = "Scripts";
            treeNode33.Name = "Sprites";
            treeNode33.Text = "Sprites";
            treeNode34.Name = "SpellEffects";
            treeNode34.Text = "Spell effects";
            treeNode35.Name = "Dialogues";
            treeNode35.Text = "Dialogues";
            treeNode36.Name = "BattleDialogues";
            treeNode36.Text = "Battle Dialogues";
            treeNode37.Name = "FontsBackgrounds";
            treeNode37.Text = "Fonts, backgrounds";
            treeNode38.Name = "WorldMapTilesets";
            treeNode38.Text = "World map tilesets";
            treeNode39.Name = "WorldMaps";
            treeNode39.Text = "World maps";
            treeNode40.Name = "Sprites";
            treeNode40.Text = "Sprites";
            treeNode41.Name = "Title";
            treeNode41.Text = "Main Title";
            this.elements.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode11,
            treeNode27,
            treeNode32,
            treeNode40,
            treeNode41});
            this.elements.Size = new System.Drawing.Size(333, 519);
            this.elements.TabIndex = 2;
            this.elements.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.elements_AfterCheck);
            // 
            // browseFreshRom
            // 
            this.browseFreshRom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseFreshRom.Location = new System.Drawing.Point(318, 14);
            this.browseFreshRom.Name = "browseFreshRom";
            this.browseFreshRom.Size = new System.Drawing.Size(27, 23);
            this.browseFreshRom.TabIndex = 1;
            this.browseFreshRom.Text = "...";
            this.browseFreshRom.UseVisualStyleBackColor = true;
            this.browseFreshRom.Click += new System.EventHandler(this.browseFreshRom_Click);
            // 
            // freshRomTextBox
            // 
            this.freshRomTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.freshRomTextBox.Location = new System.Drawing.Point(12, 14);
            this.freshRomTextBox.Name = "freshRomTextBox";
            this.freshRomTextBox.ReadOnly = true;
            this.freshRomTextBox.Size = new System.Drawing.Size(300, 21);
            this.freshRomTextBox.TabIndex = 0;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Enabled = false;
            this.buttonOK.Location = new System.Drawing.Point(189, 566);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(270, 566);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // Restore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 601);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.freshRomTextBox);
            this.Controls.Add(this.browseFreshRom);
            this.Controls.Add(this.elements);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = global::LAZYSHELL.Properties.Resources.LAZYSHELL_icon;
            this.Location = new System.Drawing.Point(5, 5);
            this.Name = "Restore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "IMPORT ELEMENTS FROM ANOTHER ROM...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView elements;
        private System.Windows.Forms.Button browseFreshRom;
        private System.Windows.Forms.TextBox freshRomTextBox;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}