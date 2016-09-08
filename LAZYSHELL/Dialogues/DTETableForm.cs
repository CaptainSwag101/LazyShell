using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LazyShell.Dialogues
{
    public partial class DTETableForm : Controls.DockForm
    {
        #region Variables

        // Forms
        private OwnerForm ownerForm;
        private DialoguesForm dialoguesForm
        {
            get { return ownerForm.DialoguesForm; }
            set { ownerForm.DialoguesForm = value; }
        }

        // Elements
        private Dialogue[] dialogues
        {
            get { return Model.Dialogues; }
            set { Model.Dialogues = value; }
        }
        private ParserMain parser;
        private bool byteView
        {
            get { return dialoguesForm.ByteView; }
            set { dialoguesForm.ByteView = value; }
        }
        private DTE[] dte
        {
            get { return Model.DTE; }
            set { Model.DTE = value; }
        }
        public bool ModifyDTE { get; set; }
        private string[] dteStrByte
        {
            get { return dialoguesForm.DTEStrByte; }
            set { dialoguesForm.DTEStrByte = value; }
        }
        private string[] dteStrText
        {
            get { return dialoguesForm.DTEStrText; }
            set { dialoguesForm.DTEStrText = value; }
        }
        private string[] dteStr
        {
            get
            {
                if (byteView)
                    return dteStrByte;
                else
                    return dteStrText;
            }
            set
            {
                if (byteView)
                    dteStrByte = value;
                else
                    dteStrText = value;
            }
        }

        #endregion

        // Constructor
        public DTETableForm(OwnerForm ownerForm)
        {
            this.ownerForm = ownerForm;
            InitializeVariables();
            InitializeComponent();
            LoadProperties();
            SetFreeBytesLabel();
        }

        #region Methods

        private void InitializeVariables()
        {
            this.parser = new ParserMain();
        }
        private void LoadProperties()
        {
            this.Updating = true;
            //
            this.dct0E.Text = dte[0].GetText(byteView); dct0E.Tag = 0;
            this.dct0F.Text = dte[1].GetText(byteView); dct0F.Tag = 1;
            this.dct10.Text = dte[2].GetText(byteView); dct10.Tag = 2;
            this.dct11.Text = dte[3].GetText(byteView); dct11.Tag = 3;
            this.dct12.Text = dte[4].GetText(byteView); dct12.Tag = 4;
            this.dct13.Text = dte[5].GetText(byteView); dct13.Tag = 5;
            this.dct14.Text = dte[6].GetText(byteView); dct14.Tag = 6;
            this.dct15.Text = dte[7].GetText(byteView); dct15.Tag = 7;
            this.dct16.Text = dte[8].GetText(byteView); dct16.Tag = 8;
            this.dct17.Text = dte[9].GetText(byteView); dct17.Tag = 9;
            this.dct18.Text = dte[10].GetText(byteView); dct18.Tag = 10;
            this.dct19.Text = dte[11].GetText(byteView); dct19.Tag = 11;
            //
            this.Updating = false;
        }
        private void SetFreeBytesLabel()
        {
            int left = Model.FreeDTESpace();
            this.freeTableBytes.Text = "(" + left.ToString() + " characters left)";
            this.freeTableBytes.BackColor = left >= 0 ? SystemColors.Control : Color.Red;
        }
        /// <summary>
        /// Sets the text of an index in the DTE to the text of a textBox
        /// in the compression table panel.
        /// </summary>
        /// <param name="textBox">The textBox containing the text to write.
        /// The index in the DTE is retrieved from the textBox's tag.</param>
        private void UpdateDTEText(TextBox textBox)
        {
            if (parser.VerifyText(textBox.Text, byteView))
            {
                int index = (int)textBox.Tag;
                dte[index].SetText(textBox.Text, byteView);
            }
            SetFreeBytesLabel();
        }
        private void EncodeDialogues()
        {
            this.Enabled = false;
            this.Text = "***ENCODING DIALOGUES***";

            // Re-encode all dialogues
            for (int i = 0; i < dialogues.Length; i++)
            {
                dialogues[i].SetText(dialogues[i].GetText(byteView, dteStr), byteView, Model.DTEStr(byteView));
                if (i % 16 == 0)
                    progressBar1.PerformStep();
            }

            // Finished
            this.Enabled = true;
            this.Text = "DIALOGUES - Lazy Shell";

            // Reset DTE variables
            ModifyDTE = false;
            progressBar1.Value = 0;
            dteStrByte = Model.DTEStr(true);
            dteStrText = Model.DTEStr(false);
            dialoguesForm.DialoguePreview.Reset();
            dialoguesForm.LoadProperties();
            dialoguesForm.SetTextImage();
        }

        #endregion

        #region Event Handlers

        // DTETableForm
        private void DTETableForm_Leave(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            if (ModifyDTE)
                EncodeDialogues();
        }

        // dct
        private void dct_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            UpdateDTEText(sender as TextBox);
            ModifyDTE = Model.FreeDTESpace() >= 0;
        }
        private void dct_Leave(object sender, EventArgs e)
        {
        }

        #endregion
    }
}
