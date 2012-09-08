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
    public partial class SampleEditor : Form
    {
        // variables
        private Settings settings = Settings.Default;
        public SoundPlayer SoundPlayer = new SoundPlayer();
        private byte[] wav;
        private byte[] loop;
        public int Index { get { return (int)sampleNum.Value; } set { sampleNum.Value = value; } }
        private BRRSample[] audioSamples { get { return Model.AudioSamples; } set { Model.AudioSamples = value; } }
        private BRRSample audioSample { get { return audioSamples[Index]; } set { audioSamples[Index] = value; } }
        private int sampleRate
        {
            get
            {
                int rate = 0;
                if (rateFixed.Checked)
                    switch (sampleRateName.SelectedIndex)
                    {
                        case 0: rate = 1000; break;
                        case 1: rate = 2000; break;
                        case 2: rate = 4000; break;
                        case 3: rate = 8000; break;
                        case 4: rate = 16000; break;
                        case 5: rate = 32000; break;
                        case 6: rate = 64000; break;
                        case 7: rate = 128000; break;
                    }
                else if (rateManual.Checked)
                    rate = (int)rateManualValue.Value;
                rate += audioSample.RelativeFrequency * 8;
                return rate;
            }
        }
        // constructor
        public SampleEditor()
        {
            InitializeComponent();
            sampleName.Items.AddRange(Lists.Numerize(Lists.SampleNames));
            sampleRateName.SelectedIndex = 5;
            sampleName.SelectedIndex = 0;
            if (settings.RememberLastIndex)
            {
                if (settings.LastAudioSample == 0)
                {
                    wav = BRR.BRRToWAV(audioSample.Sample, sampleRate);
                    loop = BRR.BRRToWAV(audioSample.Sample, sampleRate, audioSample.LoopStart);
                }
                else
                    sampleNum.Value = settings.LastAudioSample;
            }
            else
            {
                wav = BRR.BRRToWAV(audioSample.Sample, sampleRate);
                loop = BRR.BRRToWAV(audioSample.Sample, sampleRate, audioSample.LoopStart);
            }
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
            g.DrawLines(Pens.Lime, points.ToArray());
        }
        public void Assemble()
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
        }
        // event handlers
        private void sampleNum_ValueChanged(object sender, EventArgs e)
        {
            sampleName.SelectedIndex = (int)sampleNum.Value;
            //
            wav = BRR.BRRToWAV(audioSample.Sample, sampleRate);
            loop = BRR.BRRToWAV(audioSample.Sample, sampleRate, audioSample.LoopStart);
            pictureBox1.Invalidate();
            if (settings.RememberLastIndex)
                settings.LastAudioSample = (int)sampleNum.Value;
        }
        private void sampleName_SelectedIndexChanged(object sender, EventArgs e)
        {
            sampleNum.Value = sampleName.SelectedIndex;
        }
        private void sampleRate_CheckedChanged(object sender, EventArgs e)
        {
            wav = BRR.BRRToWAV(audioSample.Sample, sampleRate);
            loop = BRR.BRRToWAV(audioSample.Sample, sampleRate, audioSample.LoopStart);
            sampleRateName.Enabled = rateFixed.Checked;
            rateManualValue.Enabled = rateManual.Checked;
        }
        private void sampleRateName_SelectedIndexChanged(object sender, EventArgs e)
        {
            wav = BRR.BRRToWAV(audioSample.Sample, sampleRate);
            loop = BRR.BRRToWAV(audioSample.Sample, sampleRate, audioSample.LoopStart);
        }
        private void rateManualValue_ValueChanged(object sender, EventArgs e)
        {
            wav = BRR.BRRToWAV(audioSample.Sample, sampleRate);
            loop = BRR.BRRToWAV(audioSample.Sample, sampleRate, audioSample.LoopStart);
        }
        private void play_Click(object sender, EventArgs e)
        {
            SoundPlayer.Stop();
            if (infiniteLoop.Checked)
                Do.Play(SoundPlayer, loop, true);
            else
                Do.Play(SoundPlayer, wav, false);
        }
        private void back_Click(object sender, EventArgs e)
        {
            if (sampleNum.Value > 0)
                sampleNum.Value--;
            SoundPlayer.Stop();
            Do.Play(SoundPlayer, wav, false);
        }
        private void foward_Click(object sender, EventArgs e)
        {
            if (sampleNum.Value < sampleNum.Maximum)
                sampleNum.Value++;
            SoundPlayer.Stop();
            Do.Play(SoundPlayer, wav, false);
        }
        private void pause_Click(object sender, EventArgs e)
        {
            SoundPlayer.Stop();
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
        private void import_Click(object sender, EventArgs e)
        {
            new IOElements((Element[])Model.AudioSamples, Index, "IMPORT SAMPLE WAVs...").ShowDialog();
            wav = BRR.BRRToWAV(audioSample.Sample, sampleRate);
            pictureBox1.Invalidate();
        }
        private void importBRR_Click(object sender, EventArgs e)
        {
            new IOElements((Element[])Model.AudioSamples, Index, "IMPORT SAMPLE BRRs...").ShowDialog();
            wav = BRR.BRRToWAV(audioSample.Sample, sampleRate);
            pictureBox1.Invalidate();
        }
        private void export_Click(object sender, EventArgs e)
        {
            new IOElements((Element[])Model.AudioSamples, Index, "EXPORT SAMPLE WAVs...", sampleRate).ShowDialog();
        }
        private void exportBRR_Click(object sender, EventArgs e)
        {
            new IOElements((Element[])Model.AudioSamples, Index, "EXPORT SAMPLE BRRs...", sampleRate).ShowDialog();
        }
        private void clear_Click(object sender, EventArgs e)
        {
            new ClearElements(Model.AudioSamples, Index, "CLEAR SAMPLES...").ShowDialog();
            wav = BRR.BRRToWAV(audioSample.Sample, sampleRate);
            pictureBox1.Invalidate();
        }
        private void label1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
    }
}
