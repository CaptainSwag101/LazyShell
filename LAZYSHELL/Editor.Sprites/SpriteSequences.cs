using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public partial class SpriteSequences : Form
    {
        #region Variables
        // main editor accessed variables

        private Sprites spritesEditor;
        private Sprite sprite { get { return spritesEditor.Sprite; } set { spritesEditor.Sprite = value; } }
        private SpriteMolds molds { get { return spritesEditor.Molds; } set { spritesEditor.Molds = value; } }
        private Animation animation { get { return spritesEditor.Animation; } set { spritesEditor.Animation = value; } }
        private GraphicPalette image { get { return spritesEditor.Image; } set { spritesEditor.Image = value; } }
        private int[] palette { get { return spritesEditor.Palette; } }
        private int availableBytes { get { return spritesEditor.AvailableBytes; } set { spritesEditor.AvailableBytes = value; } }
        // local variables
        private bool updating = false;
        private Mold mold { get { return animation.Molds[(int)frameMold.Value]; } }
        private Sequence sequence { get { return animation.Sequences[sequences.SelectedIndex]; } }
        private Sequence.Frame frame { get { return sequence.Frames[index]; } }
        private int index
        {
            get
            {
                if (frames.Tag != null)
                    return (int)frames.Tag;
                else
                    return 0;
            }
            set
            {
                if (value >= sequence.Frames.Count)
                    value = 0;
                if (value < 0)
                    value = sequence.Frames.Count - 1;
                if (sequence.Frames.Count > 0)
                {
                    frames.Tag = value;
                    updating = true;
                    listBoxFrames.SelectedIndex = value;
                    updating = false;
                    RefreshFrame();
                }
                foreach (PictureBox picture in frames.Controls)
                    picture.Invalidate();
            }
        }
        private List<Bitmap> sequenceImages = new List<Bitmap>();
        private Bitmap sequenceImage;
        private Bitmap frameImage;
        private int duration_temp = 0;
        private Sequence sequence_temp = null;
        private ArrayList skip = new ArrayList();
        private int width = 256;
        private int height = 256;
        // special controls
        #endregion
        #region Functions
        public SpriteSequences(Sprites spritesEditor)
        {
            this.spritesEditor = spritesEditor;
            InitializeComponent();
            this.skip.Add(pause);
            updating = true;
            this.sequences.Items.Clear();
            for (int i = 0; i < animation.Sequences.Count; i++)
            {
                if (spritesEditor.Index >= 256 && spritesEditor.Index <= 511)
                    switch (i)
                    {
                        case 0: this.sequences.Items.Add("Idle front"); break;
                        case 1: this.sequences.Items.Add("Idle back"); break;
                        case 2: this.sequences.Items.Add("Recoil"); break;
                        case 3: this.sequences.Items.Add("Attack"); break;
                        case 4: this.sequences.Items.Add("Cast"); break;
                        default: this.sequences.Items.Add("Sequence " + i.ToString()); break;
                    }
                else
                    this.sequences.Items.Add("Sequence " + i.ToString());
            }
            sequences.SelectedIndex = 0;
            sequenceActive.Checked = sequence.Active;
            InitializeFrames();
            index = 0;
            updating = false;
        }
        public void Reload(Sprites spritesEditor)
        {
            if (PlaybackSequence.IsBusy)
                PlaybackSequence.CancelAsync();
            this.spritesEditor = spritesEditor;
            updating = true;
            this.sequences.Items.Clear();
            for (int i = 0; i < animation.Sequences.Count; i++)
            {
                if (spritesEditor.Index >= 256 && spritesEditor.Index <= 511)
                    switch (i)
                    {
                        case 0: this.sequences.Items.Add("Idle front"); break;
                        case 1: this.sequences.Items.Add("Idle back"); break;
                        case 2: this.sequences.Items.Add("Recoil"); break;
                        case 3: this.sequences.Items.Add("Attack"); break;
                        case 4: this.sequences.Items.Add("Cast"); break;
                        default: this.sequences.Items.Add("Sequence " + i.ToString()); break;
                    }
                else
                    this.sequences.Items.Add("Sequence " + i.ToString());
            }
            sequences.SelectedIndex = 0;
            sequenceActive.Checked = sequence.Active;
            InitializeFrames();
            index = 0;
            updating = false;
        }
        public void SetToolTips(ToolTip toolTip1)
        {
            toolTip1.SetToolTip(this.sequences,
                "The collection of sequences used by the sprite's animation.\n\n" +
                "A sequence is a collection of frames, where each frame is \n" +
                "assigned a mold from the selection of molds under \"MOLDS\" \n" +
                "and a duration, creating an animation that can be played \n" +
                "back in the image to the right.");

            this.newSequence.ToolTipText =
                "Insert a new sequence after the currently selected \n" +
                "sequence.";

            this.deleteSequence.ToolTipText =
                "Delete the currently selected sequence.";

            toolTip1.SetToolTip(this.listBoxFrames,
                "The collection of frames used by the currently selected \n" +
                "sequence at the left. Each frame is assigned a mold from \n" +
                "the selection of molds under \"MOLDS\" and a duration, \n" +
                "creating an animation that can be played back in the image \n" +
                "to the right.");

            this.newFrame.ToolTipText =
                "Insert a new frame after the currently selected frame.";

            this.deleteFrame.ToolTipText =
                "Delete the currently selected frame.";

            this.frameMold.ToolTipText =
                "The mold used by the currently selected frame. This value \n" +
                "is based on the collection of molds under \"MOLDS\".";

            this.duration.ToolTipText =
                "The duration of the currently selected frame, or how long \n" +
                "the frame will pause before the next frame starts. This \n" +
                "value refers to the # of frames based on a 60-frames-per-\n" +
                "second unit.";

            this.moveFrameBack.ToolTipText =
                "Move the currently selected frame back.";

            this.moveFrameFoward.ToolTipText =
                "Move the currently selected frame forward.";
        }
        private void RefreshSequence()
        {
            if (PlaybackSequence.IsBusy)
                PlaybackSequence.CancelAsync();
            updating = true;
            sequenceActive.Checked = sequence.Active;
            updating = false;
            if (sequence.Frames.Count != 0)
            {
                toolStrip1.Enabled = true;
                deleteFrame.Enabled = true;
                duplicateFrame.Enabled = true;
                moveFrameBack.Enabled = true;
                moveFrameFoward.Enabled = true;
                reverseFrames.Enabled = true;
                panelSequence.Enabled = true;
                frames.Enabled = true;
                InitializeFrames();
            }
            else
            {
                toolStrip1.Enabled = false;
                deleteFrame.Enabled = false;
                duplicateFrame.Enabled = false;
                moveFrameBack.Enabled = false;
                moveFrameFoward.Enabled = false;
                reverseFrames.Enabled = false;
                panelSequence.Enabled = false;
                frames.Enabled = false;
                frames.Controls.Clear();
                listBoxFrames.Items.Clear();
                sequenceImage = null;
                frames.Tag = null;
                pictureBoxSequence.Invalidate();
            }
        }
        private void InitializeFrames()
        {
            updating = true;
            panelFrames.AutoScrollPosition = new Point(0, 0);
            DrawFrames();
            if (sequence.Frames.Count == 0)
                toolStrip1.Enabled = false;
            else
            {
                index = 0;
                toolStrip1.Enabled = true;
                this.frameMold.Value = frame.Mold;
                this.duration.Value = frame.Duration;
            }
            updating = false;
            SetSequenceFrameImages();
        }
        private void RefreshFrame()
        {
            updating = true;
            if (sequence.Frames.Count != 0)
            {
                this.frameMold.Enabled = true;
                this.duration.Enabled = true;
                this.frameMold.Value = frame.Mold;
                this.duration.Value = frame.Duration;
                //this.panelFrames.AutoScrollPosition = new Point(index * ((this.width / 2) + 4), 0);
            }
            else
            {
                frameMold.Enabled = false; frameMold.Value = 0;
                duration.Enabled = false; duration.Value = 0;
                sequenceImage = null;
            }
            updating = false;
            SetSequenceFrameImage();
        }
        private void DrawFrames()
        {
            this.panelFrames.AutoScrollPosition = new Point(0, 0);
            this.frames.Controls.Clear();
            this.listBoxFrames.BeginUpdate();
            this.listBoxFrames.Items.Clear();
            frames.Width = sequence.Frames.Count * (this.width + 4) + Screen.PrimaryScreen.WorkingArea.Width;
            for (int i = 0; i < sequence.Frames.Count; i++)
            {
                PictureBox frame = new PictureBox();
                frame.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
                frame.BorderStyle = BorderStyle.None;
                frame.Location = new Point(i * (this.width + 4) + 4, 4);
                frame.Name = "frame" + i;
                frame.Size = new Size(this.width, this.height);
                frame.Tag = i;
                frame.MouseDown += new MouseEventHandler(frame_MouseDown);
                frame.Paint += new PaintEventHandler(frame_Paint);
                frame.PreviewKeyDown += new PreviewKeyDownEventHandler(frame_PreviewKeyDown);
                this.frames.Controls.Add(frame);
                listBoxFrames.Items.Add("Frame " + i);
            }
            this.listBoxFrames.EndUpdate();
        }
        private void RealignFrames()
        {
            int i = 0;
            foreach (PictureBox frame in frames.Controls)
            {
                frame.Tag = i;
                frame.Left = i * (frame.Width + 4) + 4;
                listBoxFrames.Items[i] = "Frame " + i;
                i++;
            }
            frames.Width = sequence.Frames.Count * (this.width + 4) + Screen.PrimaryScreen.WorkingArea.Width;
        }
        public void InvalidateImages()
        {
            pictureBoxSequence.Invalidate();
            foreach (PictureBox frame in frames.Controls)
                frame.Invalidate();
        }
        public void SetSequenceFrameImages()
        {
            sequenceImages.Clear();
            int i = 0;
            foreach (Sequence.Frame frame in sequence.Frames)
            {
                if (frame.Mold < animation.Molds.Count)
                {
                    int[] pixels = (animation.Molds[frame.Mold]).MoldPixels();
                    frameImage = new Bitmap(Do.PixelsToImage(pixels, 256, 256));
                    sequenceImages.Add(new Bitmap(frameImage));
                }
                else
                {
                    //MessageBox.Show("Mold for frame #" + i.ToString() + " is not valid. Change to lower value.", "LAZY SHELL");
                    sequenceImages.Add(new Bitmap(256, 256));
                }
                i++;
            }
            SetSequenceFrameImage();
        }
        public void SetSequenceFrameImage()
        {
            if (index < sequenceImages.Count)
                sequenceImage = new Bitmap((Bitmap)sequenceImages[index]);
            else
                sequenceImage = new Bitmap(256, 256);
            foreach (PictureBox picture in frames.Controls)
                picture.Invalidate();
            pictureBoxSequence.Invalidate();
        }
        #endregion
        #region Event Handlers
        private void pictureBoxSequence_Paint(object sender, PaintEventArgs e)
        {
            if (frames.Tag == null)
                return;
            if (molds.ShowBG)
                e.Graphics.Clear(Color.FromArgb(palette[0]));
            if (sequenceImage != null)
                e.Graphics.DrawImage(sequenceImage, 0, 0);
        }
        private void frame_Paint(object sender, PaintEventArgs e)
        {
            if (sequence.Frames.Count == 0) return;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
            PictureBox frame = (PictureBox)sender;
            int index = (int)frame.Tag;
            if (molds.ShowBG)
                e.Graphics.Clear(Color.FromArgb(palette[0]));
            Rectangle dst = new Rectangle(0, 0, 256, 256);
            Rectangle src;
            if (sequence.Frames[index].Mold < animation.Molds.Count)
            {
                src = new Rectangle(0, 0, 256, 256);
                if (index < sequenceImages.Count)
                    e.Graphics.DrawImage(sequenceImages[index], dst, src, GraphicsUnit.Pixel);
            }
            else
            {
                Font font = new Font("Tahoma", 10F, FontStyle.Bold);
                SizeF size = e.Graphics.MeasureString("(INVALID MOLD INDEX)", font, new PointF(0, 0), StringFormat.GenericDefault);
                Point point = new Point((frame.Width - (int)size.Width) / 2, (frame.Height - (int)size.Height) / 2);
                Do.DrawString(e.Graphics, point, "(INVALID MOLD INDEX)", Color.Black, Color.Red, font);
            }
            if (this.index == index)
            {
                e.Graphics.DrawRectangle(
                    new Pen(new SolidBrush(Color.Red)),
                    new Rectangle(0, 0, this.width - 1, this.height - 1));
                frame.Focus();
            }
            else
            {
                e.Graphics.DrawRectangle(
                    new Pen(new SolidBrush(SystemColors.ControlDark)),
                    new Rectangle(0, 0, this.width - 1, this.height - 1));
            }
        }
        private void frame_MouseDown(object sender, MouseEventArgs e)
        {
            if (PlaybackSequence.IsBusy) return;
            PictureBox frame = (PictureBox)sender;
            frame.Focus();
            index = (int)frame.Tag;
            if (panelFrames.HorizontalScroll.Visible)
                panelFrames.HorizontalScroll.Value = index * (this.width + 4);
        }
        private void frame_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (PlaybackSequence.IsBusy) return;
            if (e.KeyData == Keys.Right || e.KeyData == Keys.Down)
                index++;
            if (e.KeyData == Keys.Left || e.KeyData == Keys.Up)
                index--;
            if (panelFrames.HorizontalScroll.Visible)
                panelFrames.HorizontalScroll.Value = index * (this.width + 4);
        }
        private void panelFrames_SizeChanged(object sender, EventArgs e)
        {
            frames.Width = sequence.Frames.Count * (this.width + 4) + Screen.PrimaryScreen.WorkingArea.Width;
        }
        private void panelSequence_SizeChanged(object sender, EventArgs e)
        {
            pictureBoxSequence.Location = new Point(
                (panelSequence.Width / 2) - (pictureBoxSequence.Width / 2),
                (panelSequence.Height / 2) - (pictureBoxSequence.Height / 2));
        }
        private void listBoxFrames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PlaybackSequence.IsBusy)
                PlaybackSequence.CancelAsync();
            if (updating) return;
            index = listBoxFrames.SelectedIndex;
            if (panelFrames.HorizontalScroll.Visible)
                panelFrames.HorizontalScroll.Value = index * (this.width + 4);
        }
        private void sequences_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            RefreshSequence();
            sequences.Focus();
        }
        private void duration_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            frame.Duration = (byte)duration.Value;
        }
        private void frameMold_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            if ((int)frameMold.Value >= animation.Molds.Count)
                frameMold.Value = animation.Molds.Count - 1;
            frame.Mold = (byte)frameMold.Value;
            SetSequenceFrameImages();
        }
        private void play_Click(object sender, EventArgs e)
        {
            sequence_temp = sequence;
            if (sequence_temp == null) return;
            PlaybackSequence.CancelAsync();
            spritesEditor.EnableOnPlayback(false);
            panelSequence.BringToFront();
            PlaybackSequence.RunWorkerAsync();
        }
        private void pause_Click(object sender, EventArgs e)
        {
            if (PlaybackSequence.IsBusy) PlaybackSequence.CancelAsync();
        }
        private void back_Click(object sender, EventArgs e)
        {
            index--;
        }
        private void foward_Click(object sender, EventArgs e)
        {
            index++;
        }
        private void PlaybackSequence_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; !PlaybackSequence.CancellationPending; i++)
            {
                if (PlaybackSequence.CancellationPending)
                    break;
                if (i >= frames.Controls.Count)
                    i = 0;
                PlaybackSequence.ReportProgress(i);
                duration_temp = sequence_temp.Frames[i].Duration;
                if (duration_temp >= 1)
                    Thread.Sleep(duration_temp * (1000 / 60));
                else
                    Thread.Sleep(1000 / 60);
                if (PlaybackSequence.CancellationPending)
                    break;
            }
        }
        private void PlaybackSequence_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            sequenceImage = new Bitmap((Bitmap)sequenceImages[e.ProgressPercentage]);
            pictureBoxSequence.Invalidate();
            // if at last frame and no infinite playback
            if (e.ProgressPercentage >= sequenceImages.Count - 1 && !infinitePlayback.Checked)
                PlaybackSequence.CancelAsync();
        }
        private void PlaybackSequence_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            spritesEditor.EnableOnPlayback(true);
            panelFrames.BringToFront();
            RefreshFrame();
        }
        private void saveSequenceImages_Click(object sender, EventArgs e)
        {
            int counter = 0;
            int frameCounter = 0;
            foreach (Sequence.Frame frame in sequence.Frames)
            {
                int duration = (int)(((double)frame.Duration / 60.0 * 100.0) / 3);
                while (duration-- > 0)
                    (sequenceImages[frameCounter]).Save(
                        "sprite." + sprite.Index.ToString("d4") + ".Sequence." +
                        index.ToString("d2") + ".Frame." + counter++.ToString("d3") + ".png");
                frameCounter++;
            }
        }
        // adding,deleting
        private void sequenceActive_CheckedChanged(object sender, EventArgs e)
        {
            if (updating) return;
            sequence.Active = sequenceActive.Checked;
        }
        private void newSequence_Click(object sender, EventArgs e)
        {
            if (animation.Sequences.Count == 16)
            {
                MessageBox.Show("Animations cannot contain more than 16 sequences total.", "LAZY SHELL",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int index = sequences.SelectedIndex + 1;
            animation.Sequences.Insert(index, sequence.New());
            updating = true;
            sequences.BeginUpdate();
            sequences.Items.Insert(index, "Sequence " + index);
            for (int i = 0; i < sequences.Items.Count; i++)
                sequences.Items[i] = "Sequence " + i;
            sequences.EndUpdate();
            updating = false;
            sequences.SelectedIndex = index;
        }
        private void deleteSequence_Click(object sender, EventArgs e)
        {
            if (animation.Sequences.Count == 1)
            {
                MessageBox.Show("Animations must contain at least one sequence.", "LAZY SHELL",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int index = sequences.SelectedIndex;
            animation.Sequences.RemoveAt(index);
            updating = true;
            sequences.BeginUpdate();
            sequences.Items.RemoveAt(index);
            for (int i = 0; i < sequences.Items.Count; i++)
                sequences.Items[i] = "Sequence " + i;
            sequences.EndUpdate();
            updating = false;
            if (index < sequences.Items.Count)
                sequences.SelectedIndex = index;
            else
                sequences.SelectedIndex = index - 1;
        }
        private void duplicateSequence_Click(object sender, EventArgs e)
        {
            if (animation.Sequences.Count == 16)
            {
                MessageBox.Show("Animations cannot contain more than 16 sequences total.", "LAZY SHELL",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int index = sequences.SelectedIndex + 1;
            animation.Sequences.Insert(index, sequence.Copy());
            updating = true;
            sequences.BeginUpdate();
            sequences.Items.Insert(index, "Sequence " + index);
            for (int i = 0; i < sequences.Items.Count; i++)
                sequences.Items[i] = "Sequence " + i;
            sequences.EndUpdate();
            updating = false;
            sequences.SelectedIndex = index;
        }
        private void moveSequenceBack_Click(object sender, EventArgs e)
        {
            if (sequences.SelectedIndex == 0) return;
            int index = sequences.SelectedIndex - 1;
            animation.Sequences.Reverse(index, 2);
            updating = true;
            sequences.SelectedIndex--;
            updating = false;
        }
        private void moveSeqeuenceFoward_Click(object sender, EventArgs e)
        {
            if (sequences.SelectedIndex == animation.Sequences.Count - 1) return;
            int index = sequences.SelectedIndex;
            animation.Sequences.Reverse(index, 2);
            updating = true;
            sequences.SelectedIndex++;
            updating = false;
        }
        private void newFrame_Click(object sender, EventArgs e)
        {
            if (sequence.Frames.Count == 256)
            {
                MessageBox.Show("Sequences cannot contain more than 256 frames total.", "LAZY SHELL",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int index = 0;
            if (sequence.Frames.Count != 0)
                index = this.index + 1;
            sequence.Frames.Insert(index, new Sequence.Frame().New());
            DrawFrames();
            RefreshFrame();
            SetSequenceFrameImages();
            this.index = index;
            // update free space
            animation.Assemble();
            spritesEditor.CalculateFreeSpace();
            toolStrip1.Enabled = duplicateFrame.Enabled = deleteFrame.Enabled =
                moveFrameBack.Enabled = moveFrameFoward.Enabled = reverseFrames.Enabled = true;
        }
        private void duplicateFrame_Click(object sender, EventArgs e)
        {
            if (sequence.Frames.Count == 256)
            {
                MessageBox.Show("Sequences cannot contain more than 256 frames total.", "LAZY SHELL",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int index;
            if (sequence.Frames.Count != 0)
                index = this.index + 1;
            else
                index = this.index;
            sequence.Frames.Insert(index, this.frame.Copy());
            DrawFrames();
            RefreshFrame();
            SetSequenceFrameImages();
            this.index = index;
            // update free space
            animation.Assemble();
            spritesEditor.CalculateFreeSpace();
            toolStrip1.Enabled = duplicateFrame.Enabled = deleteFrame.Enabled =
                moveFrameBack.Enabled = moveFrameFoward.Enabled = reverseFrames.Enabled = true;
        }
        private void deleteFrame_Click(object sender, EventArgs e)
        {
            int index = this.index;
            sequence.Frames.RemoveAt(index);
            frames.Controls.RemoveAt(index);
            sequenceImages.RemoveAt(index);
            listBoxFrames.Items.RemoveAt(index);
            if (index >= sequence.Frames.Count && sequence.Frames.Count != 0)
                this.index = index - 1;
            else if (sequence.Frames.Count != 0)
                this.index = index;
            RefreshFrame();
            RealignFrames();
            // update free space
            animation.Assemble();
            spritesEditor.CalculateFreeSpace();
            if (sequence.Frames.Count == 0)
                toolStrip1.Enabled = duplicateFrame.Enabled = deleteFrame.Enabled =
                    moveFrameBack.Enabled = moveFrameFoward.Enabled = reverseFrames.Enabled = false;
        }
        private void moveFrameBack_Click(object sender, EventArgs e)
        {
            if (this.index == 0) return;
            int index = this.index - 1;
            sequence.Frames.Reverse(index, 2);
            sequenceImages.Reverse(index, 2);
            RealignFrames();
            this.index--;
        }
        private void moveFrameFoward_Click(object sender, EventArgs e)
        {
            if (this.index == sequence.Frames.Count - 1) return;
            int index = this.index;
            sequence.Frames.Reverse(index, 2);
            sequenceImages.Reverse(index, 2);
            RealignFrames();
            this.index++;
        }
        private void reverseFrames_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You are about to reverse the order of all frames in the current sequence.\n\n" +
                "Continue with process?", "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;
            for (int i = 1; i < sequence.Frames.Count; i++)
            {
                for (int c = 0; c < sequence.Frames.Count - i; c++)
                {
                    sequence.Frames.Reverse(c, 2);
                    sequenceImages.Reverse(c, 2);
                }
            }
            index = 0;
            RealignFrames();
        }
        #endregion
    }
}
