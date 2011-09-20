using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Media;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
    public partial class Audio : Form
    {
        // variables

        private long checksum;
        private SoundPlayer soundPlayer = new SoundPlayer();
        private byte[] wav;
        private int index { get { return (int)sampleNum.Value; } set { sampleNum.Value = value; } }
        private BRRSample[] audioSamples { get { return Model.AudioSamples; } set { Model.AudioSamples = value; } }
        private BRRSample audioSample { get { return audioSamples[index]; } set { audioSamples[index] = value; } }
        private int sampleRate
        {
            get
            {
                if (rate8000Hz.Checked)
                    return 8000;
                if (rate16000Hz.Checked)
                    return 16000;
                if (rate22050Hz.Checked)
                    return 22050;
                if (rate32000Hz.Checked)
                    return 32000;
                if (rate44100Hz.Checked)
                    return 44100;
                if (rateManual.Checked)
                    return (int)rateManualValue.Value;
                return 8000;
            }
        }
        // constructor
        public Audio()
        {
            checksum = Do.GenerateChecksum(audioSamples);
            InitializeComponent();
            if (Settings.Default.LastAudioSample == 0)
                wav = BRR.Decode(audioSample.Sample, sampleRate);
            else
                sampleNum.Value = Settings.Default.LastAudioSample;
            new History(this);
        }
        // functions
        private void DrawWavelength(Graphics g, int width, int height, byte[] wav)
        {
            int size = Bits.Get32Bit(wav, 0x0028) / 2;
            int offset = 0x2C;
            List<Point> points = new List<Point>();
            double w_ratio = (double)width / (double)size;
            double h_ratio = (double)height / 65536.0;
            for (int i = 0; i < size; i++)
            {
                int x = (int)((double)i * w_ratio);
                int y = (int)((double)(Bits.GetShort(wav, offset) ^ 0x8000) * h_ratio);
                points.Add(new Point(x, y));
                offset += 2;
            }
            g.DrawLines(new Pen(Color.Lime), points.ToArray());
        }
        // event handlers
        private void sampleNum_ValueChanged(object sender, EventArgs e)
        {
            wav = BRR.Decode(audioSample.Sample, sampleRate);
            pictureBox1.Invalidate();
            Settings.Default.LastAudioSample = (int)sampleNum.Value;
        }
        private void sampleRate_CheckedChanged(object sender, EventArgs e)
        {
            wav = BRR.Decode(audioSample.Sample, sampleRate);
            rateManualValue.Enabled = rateManual.Checked;
        }
        private void rateManualValue_ValueChanged(object sender, EventArgs e)
        {
            wav = BRR.Decode(audioSample.Sample, sampleRate);
        }
        private void play_Click(object sender, EventArgs e)
        {
            soundPlayer.Stop();
            Do.Play(soundPlayer, wav, sampleRate);
        }
        private void back_Click(object sender, EventArgs e)
        {
            if (sampleNum.Value > 0)
                sampleNum.Value--;
            soundPlayer.Stop();
            Do.Play(soundPlayer, wav, sampleRate);
        }
        private void foward_Click(object sender, EventArgs e)
        {
            if (sampleNum.Value < sampleNum.Maximum)
                sampleNum.Value++;
            soundPlayer.Stop();
            Do.Play(soundPlayer, wav, sampleRate);
        }
        private void pause_Click(object sender, EventArgs e)
        {
            soundPlayer.Stop();
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            DrawWavelength(e.Graphics, pictureBox1.Width, pictureBox1.Height, wav);
        }
        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
        //
        private void Audio_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Do.GenerateChecksum(audioSamples) == checksum)
                return;
            soundPlayer.Stop();
            DialogResult result = MessageBox.Show(
              "Audio has not been saved.\n\nWould you like to save changes?", "LAZY SHELL",
              MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                save_Click(null, null);
            else if (result == DialogResult.No)
            {
                Model.AudioSamples = null;
                return;
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }
        }
        private void save_Click(object sender, EventArgs e)
        {
            int i = 0;
            int offset06 = 0x060939;
            int offset14 = 0x146000;
            int offset1C = 0x1C8000;
            int offset1D = 0x1DC600;
            // check if room for next in bank 14
            for (; i < audioSamples.Length && offset14 + audioSamples[i].Length < 0x148000; i++)
                audioSamples[i].Assemble(ref offset14);
            // check if room for next in bank 06
            for (; i < audioSamples.Length && offset06 + audioSamples[i].Length < 0x094000; i++)
                audioSamples[i].Assemble(ref offset06);
            // check if room for next in bank 1C
            for (; i < audioSamples.Length && offset1C + audioSamples[i].Length < 0x1CEA00; i++)
                audioSamples[i].Assemble(ref offset1C);
            // check if room for next in bank 1D
            for (; i < audioSamples.Length && offset1D + audioSamples[i].Length < 0x1DDE00; i++)
                audioSamples[i].Assemble(ref offset1D);

            if (i < audioSamples.Length)
                MessageBox.Show("Not enough space to save all samples. Stopped saving at index " + i.ToString("d3") + ".");
            checksum = Do.GenerateChecksum(audioSamples);
        }
        private void import_Click(object sender, EventArgs e)
        {
            new IOElements((Element[])Model.AudioSamples, index, "IMPORT SAMPLES...").ShowDialog();
            wav = BRR.Decode(audioSample.Sample, sampleRate);
            pictureBox1.Invalidate();
        }
        private void export_Click(object sender, EventArgs e)
        {
            new IOElements((Element[])Model.AudioSamples, index, "EXPORT SAMPLES...", sampleRate).ShowDialog();
        }
        private void clear_Click(object sender, EventArgs e)
        {
            new ClearElements(Model.AudioSamples, index, "CLEAR SAMPLES...").ShowDialog();
            wav = BRR.Decode(audioSample.Sample, sampleRate);
            pictureBox1.Invalidate();
        }
        private void label1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
    }
}
