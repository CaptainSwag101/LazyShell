using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SMRPGED
{
    public partial class ProgressBar : Form
    {
        private byte[] data;
        private Model model;
        public ProgressBar(Model model, byte[] data, string title, int max)
        {
            InitializeComponent();
            this.model = model;
            this.data = data;
            this.Text = title;
            this.progressBar1.Maximum = max;
        }
        public void PerformStep(string labelText)
        {
            progressBar1.PerformStep();
            loadingWhat.Text = labelText;
            this.Update();
        }
        public void PerformSteps(int amount)
        {
            progressBar1.Value += amount;
            this.Update();
        }
    }
}