using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace LazyShell
{
    public partial class ProgressBar : Controls.NewForm
    {
        #region Variables

        // ROM buffer
        private byte[] rom
        {
            get { return Model.ROM; }
            set { Model.ROM = value; }
        }

        // Background worker
        private BackgroundWorker backgroundWorker;

        #endregion

        // Constructors
        public ProgressBar(byte[] rom, string title, int max)
        {
            InitializeComponent();
            loadingWhat.Width += buttonCancel.Width + 2;
            buttonCancel.Visible = false;
            this.Text = title;
            this.progressBar1.Maximum = max;
        }
        public ProgressBar(byte[] rom, string title, int max, BackgroundWorker backgroundWorker)
        {
            InitializeComponent();
            this.rom = rom;
            this.Text = title;
            this.backgroundWorker = backgroundWorker;
            this.progressBar1.Maximum = max;
        }
        public ProgressBar(string title, int max, BackgroundWorker backgroundWorker)
        {
            InitializeComponent();
            this.Text = title;
            this.backgroundWorker = backgroundWorker;
            this.progressBar1.Maximum = max;
        }
        public ProgressBar(string title, int max)
        {
            InitializeComponent();
            loadingWhat.Width += buttonCancel.Width + 2;
            buttonCancel.Visible = false;
            this.Text = title;
            this.progressBar1.Maximum = max;
        }

        #region Methods

        public void PerformStep(string labelText)
        {
            progressBar1.PerformStep();
            loadingWhat.Text = labelText;
            this.Update();
        }
        public void PerformStep(string labelText, int steps)
        {
            progressBar1.Value += steps;
            loadingWhat.Text = labelText;
            this.Update();
        }

        #endregion

        // Event Handlers
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            backgroundWorker.CancelAsync();
        }
    }
}