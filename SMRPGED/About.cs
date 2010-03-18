using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMRPGED
{
    public partial class About : Form
    {
        private Form1 form1;
        private StatsEditor.StatsEditor stats;
        private Levels levels;
        private ScriptsEditor.Scripts scripts;
        private Sprites sprites;

        public About(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
        }
        public About(StatsEditor.StatsEditor stats)
        {
            this.stats = stats;
            InitializeComponent();
        }
        public About(Levels levels)
        {
            this.levels = levels;
            InitializeComponent();
        }
        public About(ScriptsEditor.Scripts scripts)
        {
            this.scripts = scripts;
            InitializeComponent();
        }

        public About(Sprites sprites)
        {
            this.sprites = sprites;
            InitializeComponent();
        }

        private void richTextBox1_LinkClicked(object sender, System.Windows.Forms.LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}