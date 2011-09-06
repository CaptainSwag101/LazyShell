﻿namespace LAZYSHELL
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Monsters");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Formations");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Spells");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Attacks");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Items");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Shops");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Level-ups");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Starting stats");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Timings");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Stats", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Layers");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Maps");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("NPCs");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Exits");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Events");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Overlaps");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Tile mods");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Solid mods");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Tilemaps");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Tilesets");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Graphics");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Solidity maps");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Battlefields");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Battlefield tilesets");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Battlefield Graphics");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Levels", new System.Windows.Forms.TreeNode[] {
            treeNode11,
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
            treeNode25});
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Event scripts");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Action scripts");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Battle scripts");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("Animation scripts");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Scripts", new System.Windows.Forms.TreeNode[] {
            treeNode27,
            treeNode28,
            treeNode29,
            treeNode30});
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("Sprites");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("Spell effects");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("Dialogues");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("Fonts, backgrounds");
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("World map tilesets");
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("World maps");
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("Sprites", new System.Windows.Forms.TreeNode[] {
            treeNode32,
            treeNode33,
            treeNode34,
            treeNode35,
            treeNode36,
            treeNode37});
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
            this.elements.Location = new System.Drawing.Point(12, 69);
            this.elements.Name = "elements";
            treeNode1.Name = "Monsters";
            treeNode1.Text = "Monsters";
            treeNode2.Name = "Formations";
            treeNode2.Text = "Formations";
            treeNode3.Name = "Spells";
            treeNode3.Text = "Spells";
            treeNode4.Name = "Attacks";
            treeNode4.Text = "Attacks";
            treeNode5.Name = "Items";
            treeNode5.Text = "Items";
            treeNode6.Name = "Shops";
            treeNode6.Text = "Shops";
            treeNode7.Name = "LevelUps";
            treeNode7.Text = "Level-ups";
            treeNode8.Name = "StartingStats";
            treeNode8.Text = "Starting stats";
            treeNode9.Name = "Timings";
            treeNode9.Text = "Timings";
            treeNode10.Name = "Stats";
            treeNode10.Text = "Stats";
            treeNode11.Name = "Layers";
            treeNode11.Text = "Layers";
            treeNode12.Name = "Maps";
            treeNode12.Text = "Maps";
            treeNode13.Name = "NPCs";
            treeNode13.Text = "NPCs";
            treeNode14.Name = "Exits";
            treeNode14.Text = "Exits";
            treeNode15.Name = "Events";
            treeNode15.Text = "Events";
            treeNode16.Name = "Overlaps";
            treeNode16.Text = "Overlaps";
            treeNode17.Name = "TileMods";
            treeNode17.Text = "Tile mods";
            treeNode18.Name = "SolidMods";
            treeNode18.Text = "Solid mods";
            treeNode19.Name = "Tilemaps";
            treeNode19.Text = "Tilemaps";
            treeNode20.Name = "Tilesets";
            treeNode20.Text = "Tilesets";
            treeNode21.Name = "Graphics";
            treeNode21.Text = "Graphics";
            treeNode22.Name = "SolidityMaps";
            treeNode22.Text = "Solidity maps";
            treeNode23.Name = "Battlefields";
            treeNode23.Text = "Battlefields";
            treeNode24.Name = "BattlefieldTilesets";
            treeNode24.Text = "Battlefield tilesets";
            treeNode25.Name = "BattlefieldGraphics";
            treeNode25.Text = "Battlefield Graphics";
            treeNode26.Name = "Levels";
            treeNode26.Text = "Levels";
            treeNode27.Name = "EventScripts";
            treeNode27.Text = "Event scripts";
            treeNode28.Name = "ActionScripts";
            treeNode28.Text = "Action scripts";
            treeNode29.Name = "BattleScripts";
            treeNode29.Text = "Battle scripts";
            treeNode30.Name = "AnimationScripts";
            treeNode30.Text = "Animation scripts";
            treeNode31.Name = "Scripts";
            treeNode31.Text = "Scripts";
            treeNode32.Name = "Sprites";
            treeNode32.Text = "Sprites";
            treeNode33.Name = "SpellEffects";
            treeNode33.Text = "Spell effects";
            treeNode34.Name = "Dialogues";
            treeNode34.Text = "Dialogues";
            treeNode35.Name = "FontsBackgrounds";
            treeNode35.Text = "Fonts, backgrounds";
            treeNode36.Name = "WorldMapTilesets";
            treeNode36.Text = "World map tilesets";
            treeNode37.Name = "WorldMaps";
            treeNode37.Text = "World maps";
            treeNode38.Name = "Sprites";
            treeNode38.Text = "Sprites";
            this.elements.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode26,
            treeNode31,
            treeNode38});
            this.elements.Size = new System.Drawing.Size(333, 491);
            this.elements.TabIndex = 0;
            this.elements.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.elements_AfterCheck);
            // 
            // browseFreshRom
            // 
            this.browseFreshRom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseFreshRom.Location = new System.Drawing.Point(270, 40);
            this.browseFreshRom.Name = "browseFreshRom";
            this.browseFreshRom.Size = new System.Drawing.Size(75, 23);
            this.browseFreshRom.TabIndex = 1;
            this.browseFreshRom.Text = "Browse...";
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
            this.freshRomTextBox.Size = new System.Drawing.Size(333, 21);
            this.freshRomTextBox.TabIndex = 2;
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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