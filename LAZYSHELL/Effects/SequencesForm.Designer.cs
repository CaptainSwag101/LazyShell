
namespace LAZYSHELL.Effects
{
    partial class SequencesForm
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
            this.frameMold = new LAZYSHELL.Controls.NewToolStripNumericUpDown();
            this.duration = new LAZYSHELL.Controls.NewToolStripNumericUpDown();
            this.pictureSequence = new System.Windows.Forms.PictureBox();
            this.panelSequence = new System.Windows.Forms.Panel();
            this.toolStripFrame = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.play = new System.Windows.Forms.ToolStripButton();
            this.pause = new System.Windows.Forms.ToolStripButton();
            this.back = new System.Windows.Forms.ToolStripButton();
            this.forward = new System.Windows.Forms.ToolStripButton();
            this.toolStripFrames = new System.Windows.Forms.ToolStrip();
            this.newFrame = new System.Windows.Forms.ToolStripButton();
            this.deleteFrame = new System.Windows.Forms.ToolStripButton();
            this.duplicate = new System.Windows.Forms.ToolStripButton();
            this.reverseFrames = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.moveFrameBack = new System.Windows.Forms.ToolStripButton();
            this.moveFrameForward = new System.Windows.Forms.ToolStripButton();
            this.frames = new LAZYSHELL.Controls.NewPanel();
            this.PlaybackSequence = new System.ComponentModel.BackgroundWorker();
            this.listBoxFrames = new System.Windows.Forms.ListBox();
            this.panelFrames = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSequence)).BeginInit();
            this.panelSequence.SuspendLayout();
            this.toolStripFrame.SuspendLayout();
            this.toolStripFrames.SuspendLayout();
            this.panelFrames.SuspendLayout();
            this.SuspendLayout();
            // 
            // frameMold
            // 
            this.frameMold.AutoSize = false;
            this.frameMold.ContextMenuStrip = null;
            this.frameMold.Hexadecimal = false;
            this.frameMold.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.frameMold.Location = new System.Drawing.Point(44, 1);
            this.frameMold.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.frameMold.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.frameMold.Name = "frameMold";
            this.frameMold.Size = new System.Drawing.Size(50, 21);
            this.frameMold.Text = "0";
            this.frameMold.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.frameMold.ValueChanged += new System.EventHandler(this.frameMold_ValueChanged);
            // 
            // duration
            // 
            this.duration.AutoSize = false;
            this.duration.ContextMenuStrip = null;
            this.duration.Hexadecimal = false;
            this.duration.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.duration.Location = new System.Drawing.Point(153, 1);
            this.duration.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.duration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.duration.Name = "duration";
            this.duration.Size = new System.Drawing.Size(50, 21);
            this.duration.Text = "1";
            this.duration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.duration.ValueChanged += new System.EventHandler(this.duration_ValueChanged);
            // 
            // pictureSequence
            // 
            this.pictureSequence.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.pictureSequence.Location = new System.Drawing.Point(15, 0);
            this.pictureSequence.Name = "pictureSequence";
            this.pictureSequence.Size = new System.Drawing.Size(256, 256);
            this.pictureSequence.TabIndex = 396;
            this.pictureSequence.TabStop = false;
            this.pictureSequence.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureSequence_Paint);
            // 
            // panelSequence
            // 
            this.panelSequence.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelSequence.Controls.Add(this.pictureSequence);
            this.panelSequence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSequence.Location = new System.Drawing.Point(78, 50);
            this.panelSequence.Name = "panelSequence";
            this.panelSequence.Size = new System.Drawing.Size(594, 286);
            this.panelSequence.TabIndex = 4;
            this.panelSequence.SizeChanged += new System.EventHandler(this.panelSequence_SizeChanged);
            // 
            // toolStripFrame
            // 
            this.toolStripFrame.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.frameMold,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.duration,
            this.toolStripSeparator4,
            this.play,
            this.pause,
            this.back,
            this.forward});
            this.toolStripFrame.Location = new System.Drawing.Point(78, 25);
            this.toolStripFrame.Name = "toolStripFrame";
            this.toolStripFrame.Size = new System.Drawing.Size(594, 25);
            this.toolStripFrame.TabIndex = 2;
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(35, 22);
            this.toolStripLabel2.Text = "Mold";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(53, 22);
            this.toolStripLabel1.Text = "Duration";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // play
            // 
            this.play.Image = global::LAZYSHELL.Properties.Resources.play;
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(23, 22);
            this.play.ToolTipText = "Play";
            this.play.Click += new System.EventHandler(this.play_Click);
            // 
            // pause
            // 
            this.pause.Image = global::LAZYSHELL.Properties.Resources.stop;
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(23, 22);
            this.pause.ToolTipText = "Stop";
            this.pause.Click += new System.EventHandler(this.pause_Click);
            // 
            // back
            // 
            this.back.Image = global::LAZYSHELL.Properties.Resources.back;
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(23, 22);
            this.back.ToolTipText = "Select Previous Frame";
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // forward
            // 
            this.forward.Image = global::LAZYSHELL.Properties.Resources.foward;
            this.forward.Name = "forward";
            this.forward.Size = new System.Drawing.Size(23, 22);
            this.forward.ToolTipText = "Select Next Frame";
            this.forward.Click += new System.EventHandler(this.forward_Click);
            // 
            // toolStripFrames
            // 
            this.toolStripFrames.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFrame,
            this.deleteFrame,
            this.duplicate,
            this.reverseFrames,
            this.toolStripSeparator1,
            this.moveFrameBack,
            this.moveFrameForward});
            this.toolStripFrames.Location = new System.Drawing.Point(0, 0);
            this.toolStripFrames.Name = "toolStripFrames";
            this.toolStripFrames.Size = new System.Drawing.Size(672, 25);
            this.toolStripFrames.TabIndex = 0;
            // 
            // newFrame
            // 
            this.newFrame.Image = global::LAZYSHELL.Properties.Resources.new_file;
            this.newFrame.Name = "newFrame";
            this.newFrame.Size = new System.Drawing.Size(23, 22);
            this.newFrame.ToolTipText = "New Frame";
            this.newFrame.Click += new System.EventHandler(this.newFrame_Click);
            // 
            // deleteFrame
            // 
            this.deleteFrame.Image = global::LAZYSHELL.Properties.Resources.delete;
            this.deleteFrame.Name = "deleteFrame";
            this.deleteFrame.Size = new System.Drawing.Size(23, 22);
            this.deleteFrame.ToolTipText = "Delete Frame";
            this.deleteFrame.Click += new System.EventHandler(this.deleteFrame_Click);
            // 
            // duplicate
            // 
            this.duplicate.Image = global::LAZYSHELL.Properties.Resources.duplicate;
            this.duplicate.Name = "duplicate";
            this.duplicate.Size = new System.Drawing.Size(23, 22);
            this.duplicate.ToolTipText = "Duplicate Frame";
            this.duplicate.Click += new System.EventHandler(this.duplicate_Click);
            // 
            // reverseFrames
            // 
            this.reverseFrames.Image = global::LAZYSHELL.Properties.Resources.widthDecrease;
            this.reverseFrames.Name = "reverseFrames";
            this.reverseFrames.Size = new System.Drawing.Size(23, 22);
            this.reverseFrames.ToolTipText = "Reverse Frames";
            this.reverseFrames.Click += new System.EventHandler(this.reverseFrames_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // moveFrameBack
            // 
            this.moveFrameBack.Image = global::LAZYSHELL.Properties.Resources.back;
            this.moveFrameBack.Name = "moveFrameBack";
            this.moveFrameBack.Size = new System.Drawing.Size(23, 22);
            this.moveFrameBack.ToolTipText = "Move Frame Back";
            this.moveFrameBack.Click += new System.EventHandler(this.moveFrameBack_Click);
            // 
            // moveFrameForward
            // 
            this.moveFrameForward.Image = global::LAZYSHELL.Properties.Resources.foward;
            this.moveFrameForward.Name = "moveFrameForward";
            this.moveFrameForward.Size = new System.Drawing.Size(23, 22);
            this.moveFrameForward.ToolTipText = "Move Frame Forward";
            this.moveFrameForward.Click += new System.EventHandler(this.moveFrameFoward_Click);
            // 
            // frames
            // 
            this.frames.BackgroundImage = global::LAZYSHELL.Properties.Resources._canvas;
            this.frames.Location = new System.Drawing.Point(0, 0);
            this.frames.Name = "frames";
            this.frames.Size = new System.Drawing.Size(104, 104);
            this.frames.TabIndex = 0;
            // 
            // PlaybackSequence
            // 
            this.PlaybackSequence.WorkerReportsProgress = true;
            this.PlaybackSequence.WorkerSupportsCancellation = true;
            this.PlaybackSequence.DoWork += new System.ComponentModel.DoWorkEventHandler(this.PlaybackSequence_DoWork);
            this.PlaybackSequence.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.PlaybackSequence_ProgressChanged);
            this.PlaybackSequence.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.PlaybackSequence_RunWorkerCompleted);
            // 
            // listBoxFrames
            // 
            this.listBoxFrames.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBoxFrames.FormattingEnabled = true;
            this.listBoxFrames.IntegralHeight = false;
            this.listBoxFrames.Location = new System.Drawing.Point(0, 25);
            this.listBoxFrames.Name = "listBoxFrames";
            this.listBoxFrames.Size = new System.Drawing.Size(78, 311);
            this.listBoxFrames.TabIndex = 1;
            this.listBoxFrames.SelectedIndexChanged += new System.EventHandler(this.listBoxFrames_SelectedIndexChanged);
            // 
            // panelFrames
            // 
            this.panelFrames.AutoScroll = true;
            this.panelFrames.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelFrames.BackgroundImage = global::LAZYSHELL.Properties.Resources._canvas;
            this.panelFrames.Controls.Add(this.frames);
            this.panelFrames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFrames.Location = new System.Drawing.Point(78, 50);
            this.panelFrames.Name = "panelFrames";
            this.panelFrames.Size = new System.Drawing.Size(594, 286);
            this.panelFrames.TabIndex = 3;
            this.panelFrames.SizeChanged += new System.EventHandler(this.panelFrames_SizeChanged);
            // 
            // SequencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 336);
            this.Controls.Add(this.panelFrames);
            this.Controls.Add(this.panelSequence);
            this.Controls.Add(this.toolStripFrame);
            this.Controls.Add(this.listBoxFrames);
            this.Controls.Add(this.toolStripFrames);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "SequencesForm";
            this.Text = "Sequences";
            ((System.ComponentModel.ISupportInitialize)(this.pictureSequence)).EndInit();
            this.panelSequence.ResumeLayout(false);
            this.toolStripFrame.ResumeLayout(false);
            this.toolStripFrame.PerformLayout();
            this.toolStripFrames.ResumeLayout(false);
            this.toolStripFrames.PerformLayout();
            this.panelFrames.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.PictureBox pictureSequence;
        private System.Windows.Forms.Panel panelSequence;
        private System.Windows.Forms.ToolStrip toolStripFrame;
        private System.Windows.Forms.ToolStripButton play;
        private System.Windows.Forms.ToolStripButton pause;
        private System.Windows.Forms.ToolStripButton back;
        private System.Windows.Forms.ToolStripButton forward;
        private System.Windows.Forms.ToolStrip toolStripFrames;
        private System.Windows.Forms.ToolStripButton newFrame;
        private System.Windows.Forms.ToolStripButton deleteFrame;
        private System.Windows.Forms.ToolStripButton duplicate;
        private Controls.NewPanel frames;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.ComponentModel.BackgroundWorker PlaybackSequence;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton moveFrameBack;
        private System.Windows.Forms.ToolStripButton moveFrameForward;
        private System.Windows.Forms.ListBox listBoxFrames;
        private System.Windows.Forms.Panel panelFrames;
        private Controls.NewToolStripNumericUpDown frameMold;
        private Controls.NewToolStripNumericUpDown duration;
        private System.Windows.Forms.ToolStripButton reverseFrames;
    }
}