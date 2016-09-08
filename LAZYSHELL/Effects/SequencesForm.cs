using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LazyShell.Effects
{
    public partial class SequencesForm : Controls.DockForm
    {
        #region Variables

        // Index
        private int index
        {
            get { return (int)frames.Tag; }
            set
            {
                if (value >= sequence.Frames.Count)
                    value = 0;
                if (value < 0)
                    value = sequence.Frames.Count - 1;
                if (sequence.Frames.Count > 0)
                {
                    frames.Tag = value;
                    this.Updating = true;
                    listBoxFrames.SelectedIndex = value;
                    this.Updating = false;
                    LoadProperties();
                }
                foreach (Control picture in frames.Controls)
                    picture.Invalidate();
            }
        }

        // Forms
        private OwnerForm ownerForm;
        private PropertiesForm propertiesForm
        {
            get { return ownerForm.PropertiesForm; }
            set { ownerForm.PropertiesForm = value; }
        }
        private MoldsForm moldsForm
        {
            get { return ownerForm.MoldsForm; }
            set { ownerForm.MoldsForm = value; }
        }

        // Elements
        private Effect effect
        {
            get { return ownerForm.Effect; }
            set { ownerForm.Effect = value; }
        }
        private Animation animation
        {
            get { return ownerForm.Animation; }
            set { ownerForm.Animation = value; }
        }
        private Mold mold
        {
            get { return animation.Molds[(int)frameMold.Value]; }
        }
        private Sequence sequence
        {
            get { return animation.Sequences[0]; }
        }
        private Sequence.Frame frame
        {
            get { return (Sequence.Frame)sequence.Frames[index]; }
        }
        private Tileset tileset
        {
            get { return animation.Tileset_tiles; }
            set { animation.Tileset_tiles = value; }
        }

        // Picture
        private List<Bitmap> sequenceImages;
        private Bitmap sequenceImage;
        private Bitmap frameImage;
        private int width
        {
            get { return animation.Width * 16; }
        }
        private int height
        {
            get { return animation.Height * 16; }
        }
        private double ratio
        {
            get { return (double)width / (double)height; }
        }

        // Misc
        private int duration_temp;
        private int availableBytes
        {
            get { return propertiesForm.FreeBytes; }
            set { propertiesForm.FreeBytes = value; }
        }

        #endregion

        // Constructor
        public SequencesForm(OwnerForm ownerForm)
        {
            this.ownerForm = ownerForm;
            this.Owner = ownerForm;
            this.animation = animation;

            // Initialization
            InitializeComponent();
            InitializeVariables();
            InitializeControls();
            InitializeFrames();
        }
        public void Reload(OwnerForm ownerForm)
        {
            this.ownerForm = ownerForm;
            this.animation = animation;

            // Initialization
            InitializeVariables();
            InitializeControls();
            InitializeFrames();
        }

        #region Methods

        // Initialization
        private void InitializeVariables()
        {
            this.sequenceImages = new List<Bitmap>();
        }
        private void InitializeControls()
        {
            this.pictureSequence.Size = new Size(animation.Width * 16, animation.Height * 16);
            this.pictureSequence.Location = new Point(
                (panelSequence.Width / 2) - (pictureSequence.Width / 2),
                (panelSequence.Height / 2) - (pictureSequence.Height / 2));
        }
        private void InitializeFrames()
        {
            this.Updating = true;
            //
            panelFrames.AutoScrollPosition = new Point(0, 0);
            DrawFrames();
            if (sequence.Frames.Count == 0)
                EnableToolStripControls(false);
            else
            {
                index = 0;
                EnableToolStripControls(true);
                this.frameMold.Value = frame.Mold;
                this.duration.Value = frame.Duration;
            }
            //
            SetFrameImages();
            //
            this.Updating = false;
        }
        private void LoadProperties()
        {
            this.Updating = true;
            //
            if (sequence.Frames.Count != 0)
            {
                this.frameMold.Enabled = true;
                this.duration.Enabled = true;
                this.frameMold.Value = frame.Mold;
                this.duration.Value = frame.Duration;
                this.panelFrames.AutoScrollPosition = new Point(index * (frames.Controls[index].Width + 4), 0);
            }
            else
            {
                frameMold.Enabled = false; frameMold.Value = 0;
                duration.Enabled = false; duration.Value = 1;
                sequenceImage = null;
            }
            //
            this.Updating = false;
        }
        private void EnableToolStripControls(bool enabled)
        {
            // Collection properties
            duplicate.Enabled = enabled;
            deleteFrame.Enabled = enabled;
            moveFrameBack.Enabled = enabled;
            moveFrameForward.Enabled = enabled;
            reverseFrames.Enabled = enabled;

            // Frame properties
            toolStripFrame.Enabled = enabled;
        }

        // Painting
        public void DrawFrames()
        {
            this.Updating = true;
            //
            this.frames.Controls.Clear();
            this.listBoxFrames.BeginUpdate();
            this.listBoxFrames.Items.Clear();
            this.frames.Width = (width + 4) * sequence.Frames.Count + Screen.PrimaryScreen.WorkingArea.Width;
            this.frames.Height = height + 8;
            for (int i = 0; i < sequence.Frames.Count; i++)
            {
                PictureBox frame = new PictureBox();
                frame.BackgroundImage = global::LazyShell.Properties.Resources._transparent;
                frame.BorderStyle = BorderStyle.None;
                frame.Name = "frame" + i;
                frame.Size = new Size(width, height);
                frame.Location = new Point((frame.Width + 4) * i + 4, 4);
                frame.Tag = i;
                frame.MouseDown += new MouseEventHandler(frame_MouseDown);
                frame.Paint += new PaintEventHandler(frame_Paint);
                frame.PreviewKeyDown += new PreviewKeyDownEventHandler(frame_PreviewKeyDown);
                this.frames.Controls.Add(frame);
                listBoxFrames.Items.Add("Frame " + i);
            }
            this.listBoxFrames.EndUpdate();
            //
            this.Updating = false;
        }
        public void RealignFrames()
        {
            this.Updating = true;
            //
            this.frames.Width = (width + 4) * sequence.Frames.Count + Screen.PrimaryScreen.WorkingArea.Width;
            this.frames.Height = height + 8;
            int i = 0;
            foreach (PictureBox frame in frames.Controls)
            {
                frame.Location = new Point((frame.Width + 4) * i + 4, 4);
                frame.Size = new Size(width, height);
                frame.Tag = i;
                listBoxFrames.Items[i] = "Frame " + i++;
            }
            //
            this.Updating = false;
        }
        public void InvalidateFrameImages()
        {
            pictureSequence.Invalidate();
            foreach (PictureBox frame in frames.Controls)
                frame.Invalidate();
        }
        public void SetFrameImages()
        {
            sequenceImages.Clear();
            int i = 0;
            foreach (var frame in sequence.Frames)
            {
                if (frame.Mold < animation.Molds.Count)
                {
                    int[] pixels = animation.Molds[frame.Mold].GetPixels(animation, tileset);
                    frameImage = Do.PixelsToImage(pixels, width, height);
                    sequenceImages.Add(new Bitmap(frameImage));
                }
                else
                    sequenceImages.Add(new Bitmap(256, 256));
                i++;
            }
            this.pictureSequence.Size = new Size(animation.Width * 16, animation.Height * 16);
        }

        #endregion

        #region Event Handlers

        // Frames
        private void frame_Paint(object sender, PaintEventArgs e)
        {
            var frame = sender as PictureBox;

            // Cancel painting if tag out of bounds
            if ((int)frame.Tag >= sequenceImages.Count)
                return;

            // Fill background with BG color
            if (moldsForm.ShowBG)
                e.Graphics.Clear(Color.FromArgb(animation.PaletteSet.Palette[0]));

            // Draw frame image
            Rectangle dst = new Rectangle(0, 0, frame.Width, frame.Height);
            Rectangle src = new Rectangle(0, 0, width, height);
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
            e.Graphics.DrawImage(sequenceImages[(int)frame.Tag], dst, src, GraphicsUnit.Pixel);

            // Draw invalid alert
            if (sequence.Frames[(int)frame.Tag].Mold >= animation.Molds.Count)
            {
                Font font = new Font("Tahoma", 10F, FontStyle.Bold);
                SizeF size = e.Graphics.MeasureString("(INVALID MOLD INDEX)", font, new PointF(0, 0), StringFormat.GenericDefault);
                Point point = new Point((frame.Width - (int)size.Width) / 2, (frame.Height - (int)size.Height) / 2);
                Do.DrawString(e.Graphics, point, "(INVALID MOLD INDEX)", Color.Black, Color.Red, font);
            }

            // Draw frame border
            if (index == (int)frame.Tag)
            {
                e.Graphics.DrawRectangle(
                    new Pen(new SolidBrush(Color.Red)),
                    new Rectangle(0, 0, frame.Width - 1, frame.Height - 1));
                if (!moldsForm.Picture.Focused)
                    frame.Focus();
            }
            else
            {
                e.Graphics.DrawRectangle(
                    new Pen(new SolidBrush(SystemColors.ControlDark)),
                    new Rectangle(0, 0, frame.Width - 1, frame.Height - 1));
            }
        }
        private void frame_MouseDown(object sender, MouseEventArgs e)
        {
            if (PlaybackSequence.IsBusy)
                return;
            var frame = sender as PictureBox;
            frame.Focus();
            index = (int)frame.Tag;
        }
        private void frame_SizeChanged(object sender, EventArgs e)
        {
            var frame = sender as PictureBox;
            double ratio = (double)width / (double)height;
            frame.Width = (int)(frame.Height * ratio);
        }
        private void frame_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (PlaybackSequence.IsBusy)
                return;
            if (e.KeyData == Keys.Right || e.KeyData == Keys.Down)
                index++;
            if (e.KeyData == Keys.Left || e.KeyData == Keys.Up)
                index--;
            if (e.KeyData == Keys.Delete)
                deleteFrame.PerformClick();
        }
        private void panelFrames_SizeChanged(object sender, EventArgs e)
        {
            double ratio = (double)width / (double)height;
            frames.Width = (width + 4) * sequence.Frames.Count + Screen.PrimaryScreen.WorkingArea.Width;
        }
        private void listBoxFrames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            index = listBoxFrames.SelectedIndex;
        }
        private void duration_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            frame.Duration = (byte)duration.Value;
            SetFrameImages();
        }
        private void frameMold_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            if ((int)frameMold.Value >= animation.Molds.Count)
                frameMold.Value = animation.Molds.Count - 1;
            frame.Mold = (byte)frameMold.Value;
            SetFrameImages();
            InvalidateFrameImages();
        }

        // Playback
        private void pictureSequence_Paint(object sender, PaintEventArgs e)
        {
            if (frames.Tag == null)
                return;
            if (moldsForm.ShowBG)
                e.Graphics.Clear(Color.FromArgb(animation.PaletteSet.Palette[0]));
            if (sequenceImage != null)
                e.Graphics.DrawImage(sequenceImage, 0, 0);
        }
        private void panelSequence_SizeChanged(object sender, EventArgs e)
        {
            pictureSequence.Location = new Point(
                (panelSequence.Width / 2) - (pictureSequence.Width / 2),
                (panelSequence.Height / 2) - (pictureSequence.Height / 2));
        }
        private void play_Click(object sender, EventArgs e)
        {
            PlaybackSequence.CancelAsync();
            ownerForm.EnableOnPlayback(false);
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
        private void forward_Click(object sender, EventArgs e)
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
                duration_temp = sequence.Frames[i].Duration;
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
            sequenceImage = new Bitmap(sequenceImages[e.ProgressPercentage]);
            pictureSequence.Invalidate();
        }
        private void PlaybackSequence_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Updating = false;
            ownerForm.EnableOnPlayback(true);
            panelFrames.BringToFront();
            LoadProperties();
        }

        // Collection editing
        private void newFrame_Click(object sender, EventArgs e)
        {
            // Check if too many frames
            if (sequence.Frames.Count == 256)
            {
                MessageBox.Show("Sequences cannot contain more than 256 frames total.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Increase index
            int index;
            if (sequence.Frames.Count != 0)
                index = this.index + 1;
            else
                index = this.index;

            // Insert new frame
            sequence.Frames.Insert(index, new Sequence.Frame().New());

            // Draw new frame and load properties
            DrawFrames();
            LoadProperties();
            SetFrameImages();
            this.index = index;

            // Update animation data
            animation.WriteToBuffer();
            propertiesForm.SetFreeBytesLabel();
            EnableToolStripControls(true);
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
            LoadProperties();
            RealignFrames();
            // update free space
            animation.WriteToBuffer();
            propertiesForm.SetFreeBytesLabel();
            if (sequence.Frames.Count == 0)
                EnableToolStripControls(false);
        }
        private void duplicate_Click(object sender, EventArgs e)
        {
            int index = this.index;
            sequence.Frames.Insert(index + 1, this.frame.Copy());
            DrawFrames();
            LoadProperties();
            SetFrameImages();
            this.index = index + 1;
            // update free space
            animation.WriteToBuffer();
            propertiesForm.SetFreeBytesLabel();
        }
        private void moveFrameBack_Click(object sender, EventArgs e)
        {
            if (this.index == 0)
                return;
            int index = this.index - 1;
            sequence.Frames.Reverse(index, 2);
            sequenceImages.Reverse(index, 2);
            RealignFrames();
            this.index--;
        }
        private void moveFrameFoward_Click(object sender, EventArgs e)
        {
            if (this.index == sequence.Frames.Count - 1)
                return;
            int index = this.index;
            sequence.Frames.Reverse(index, 2);
            sequenceImages.Reverse(index, 2);
            RealignFrames();
            this.index++;
        }
        private void reverseFrames_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You are about to reverse the order of all frames in the effect sequence.\n\n" +
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
