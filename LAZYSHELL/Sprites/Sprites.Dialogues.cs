using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public partial class Sprites
    {
        #region Variables

        private UniversalVariables universal;
        private Previewer.DialoguePreview dialoguePreview;
        private Previewer.BattleDialoguePreview battleDialoguePreview;
        private TextHelper textHelper;
        private TextHelperReduced textHelperReduced;
        private bool textCodeFormat = true;

        // dialogue variables
        private int currentDialogue = 0;
        private bool updatingDialogue;
        private bool[] isDialogueChanged = new bool[4096];

        // battle dialogue variables
        private int currentBattleDialogue = 0;
        private bool updatingBattleDialogue;

        private Bitmap
            dialogueBGImage,
            dialogueTextImage,
            battleDialogueTextImage;

        #endregion

        #region Methods

        // initialize properties
        private void InitializeDialogueEditor()
        {
            updatingDialogue = true;

            this.universal.Dialogues = spriteModel.Dialogues; // Get Dialogues

            FindDuplicateDialoguePointers();
            FindWithinDialogues();

            RefreshDialogueEditor();
            SetDialogueTextImage();
            dialogueMemory.SelectedIndex = 0;

            updatingDialogue = false;
        }
        private void InitializeBattleDialogueEditor()
        {
            updatingBattleDialogue = true;

            this.universal.BattleDialogues = spriteModel.BattleDialogues; // Get Battle Dialogues

            string temp;
            for (int i = 0; i < universal.BattleDialogues.Length; i++)
            {
                temp = universal.BattleDialogues[i].GetBattleDialogue(textCodeFormat);
                if (temp.Length > 40)
                    battleDialogueName.Items.Add(temp.Substring(0, 40));
                else
                    battleDialogueName.Items.Add(temp);
            }
            this.battleDlgType.SelectedIndex = 0;
            this.battleDialogueName.SelectedIndex = 0;

            RefreshBattleDialogueEditor();
            SetBattleDialogueTextImage();

            updatingBattleDialogue = false;
        }

        // refresh properties
        private void RefreshDialogueEditor()
        {
            updatingDialogue = true;

            this.currentDialogue = (int)this.dialogueNum.Value;
            this.dialogueTextBox.Text = this.universal.Dialogues[currentDialogue].GetDialogue(textCodeFormat);
            this.dialogueTextBox.SelectionStart = this.universal.Dialogues[currentDialogue].GetCaretPosition(textCodeFormat);

            int temp = CalculateDialogueFreeSpace();
            this.label196.Text = "AVAILABLE BYTES: " + temp.ToString();
            this.label196.BackColor = temp >= 0 ? SystemColors.ControlDark : Color.Red;

            updatingDialogue = false;
        }
        private void RefreshBattleDialogueEditor()
        {
            updatingBattleDialogue = true;

            this.label187.Text = CalculateBattleDialogueFreeSpace();

            this.currentBattleDialogue = (int)this.battleDialogueNum.Value;
            this.battleDialogueName.SelectedIndex = this.currentBattleDialogue;
            if (battleDlgType.SelectedIndex == 0)
            {
                this.battleDialogueTextBox.Text = this.universal.BattleDialogues[currentBattleDialogue].GetBattleDialogue(textCodeFormat);
                this.battleDialogueTextBox.SelectionStart = this.universal.BattleDialogues[currentBattleDialogue].GetCaretPosition(textCodeFormat);
            }
            else
            {
                this.battleDialogueTextBox.Text = spriteModel.BattleMessages[currentBattleDialogue].GetBattleDialogue(textCodeFormat);
                this.battleDialogueTextBox.SelectionStart = spriteModel.BattleMessages[currentBattleDialogue].GetCaretPosition(textCodeFormat);
            }

            updatingBattleDialogue = false;
        }

        // set images
        private void SetDialogueBGImage()
        {
            switch (fontPalette.SelectedIndex)
            {
                case 0: dialogueBGImage = new Bitmap(DrawImageFromIntArr(dialogueTileset.GetTilesetPixelArray(), 256, 56)); break;
                case 1: dialogueBGImage = new Bitmap(256, 56); break;
            }
            pictureBoxDialogue.BackColor = Color.FromArgb(paletteRedDialogue[0], paletteGreenDialogue[0], paletteBlueDialogue[0]);
            pictureBoxDialogue.Invalidate();
        }
        private void SetDialogueTextImage()
        {
            char[] text = dialogueTextBox.Text.ToCharArray();
            bool preview = true, valid = true, fail = false;
            char[] swap;
            int temp;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '[' && preview == false) // Open bracket when we have already had an open bracket
                    fail = true;

                if (text[i] == '[') // Open Bracket
                {
                    preview = false;
                    i++;
                    temp = i;

                    while (temp < text.Length && text[temp] != ']')
                    {
                        if (textCodeFormat)
                        {
                            if (!(text[temp] >= '0' && text[temp] <= '9'))
                                fail = true;
                        }
                        temp++;
                    }
                }
                else if (preview == false && text[i] == ']') // Close bracket after open bracket
                    preview = true;
                else if (preview == true && valid == true)
                    valid = textHelper.IsValidChar(text[i]);

                if (i < text.Length && text[i] == '\n')
                {
                    int tempSel = dialogueTextBox.SelectionStart;
                    swap = new char[text.Length + 2];
                    for (int x = 0; x < i; x++)
                        swap[x] = text[x];
                    swap[i] = '[';
                    swap[i + 1] = '1';
                    swap[i + 2] = ']';
                    for (int x = i + 3; x < swap.Length; x++)
                        swap[x] = text[x - 2];
                    dialogueTextBox.Text = new string(swap);
                    text = dialogueTextBox.Text.ToCharArray();
                    i += 2;
                    dialogueTextBox.SelectionStart = tempSel + 2;
                }
            }
            if (preview && valid && !fail)
            {
                universal.Dialogues[currentDialogue].SetDialogue(dialogueTextBox.Text, textCodeFormat);
                int[] pixels = dialoguePreview.GetPreview(fontDialogue, fontTriangle, GetFontPalette(fontPalette.SelectedIndex), GetFontPalette(0), universal.Dialogues[currentDialogue].RawDialogue, 16);
                dialogueTextImage = new Bitmap(DrawImageFromIntArr(pixels, 256, 56));
            }
            pictureBoxDialogue.Invalidate();
        }
        private void SetBattleDialogueTextImage()
        {
            char[] text = battleDialogueTextBox.Text.ToCharArray();
            bool preview = true, valid = true, fail = false;
            char[] swap;
            int temp;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '[' && preview == false) // Open bracket when we have already had an open bracket
                    fail = true;

                if (text[i] == '[') // Open Bracket
                {
                    preview = false;
                    i++;
                    temp = i;

                    while (temp < text.Length && text[temp] != ']')
                    {
                        if (textCodeFormat)
                        {
                            if (!(text[temp] >= '0' && text[temp] <= '9'))
                                fail = true;
                        }
                        temp++;
                    }
                }
                else if (preview == false && text[i] == ']') // Close bracket after open bracket
                    preview = true;
                else if (preview == true && valid == true)
                    valid = textHelper.IsValidChar(text[i]);

                if (i < text.Length && text[i] == '\n')
                {
                    int tempSel = battleDialogueTextBox.SelectionStart;
                    swap = new char[text.Length + 2];
                    for (int x = 0; x < i; x++)
                        swap[x] = text[x];
                    swap[i] = '[';
                    swap[i + 1] = '1';
                    swap[i + 2] = ']';
                    for (int x = i + 3; x < swap.Length; x++)
                        swap[x] = text[x - 2];
                    battleDialogueTextBox.Text = new string(swap);
                    text = battleDialogueTextBox.Text.ToCharArray();
                    i += 2;
                    battleDialogueTextBox.SelectionStart = tempSel + 2;
                }
            }
            if (preview && valid && !fail)
            {
                if (battleDlgType.SelectedIndex == 0)
                {
                    universal.BattleDialogues[currentBattleDialogue].SetBattleDialogue(battleDialogueTextBox.Text, textCodeFormat);
                    int[] pixels = battleDialoguePreview.GetPreview(fontDialogue, GetFontPalette(0), universal.BattleDialogues[currentBattleDialogue].RawBattleDialogue, false);
                    battleDialogueTextImage = new Bitmap(DrawImageFromIntArr(pixels, 256, 32));
                }
                else
                {
                    spriteModel.BattleMessages[currentBattleDialogue].SetBattleDialogue(battleDialogueTextBox.Text, textCodeFormat);
                    int[] pixels = battleDialoguePreview.GetPreview(fontDialogue, GetFontPalette(0), spriteModel.BattleMessages[currentBattleDialogue].RawBattleDialogue, false);
                    battleDialogueTextImage = new Bitmap(DrawImageFromIntArr(pixels, 256, 32));
                }
            }
            pictureBoxBattleDialogue.Invalidate();
        }

        // duplicate dialogues
        private void FindWithinDialogues()
        {
            int i = 0; int diff = 0;
            for (i = 0; i < 0x800; i++)
            {
                if (i < 0x7FF) diff = universal.Dialogues[i + 1].DialoguePtr - universal.Dialogues[i].DialoguePtr;
                if (i < 0x7FF && universal.Dialogues[i].RawDialogue.Length > diff && diff > 0)
                {
                    universal.Dialogues[i + 1].WithinDialogues = i;
                    universal.Dialogues[i + 1].WithinDialoguesLocation = diff;
                }
            }
            i = 0; diff = 0;
            for (i = 0x800; i < 0xC00; i++)
            {
                if (i < 0xBFF) diff = universal.Dialogues[i + 1].DialoguePtr - universal.Dialogues[i].DialoguePtr;
                if (i < 0xBFF && universal.Dialogues[i].RawDialogue.Length > diff && diff > 0)
                {
                    universal.Dialogues[i + 1].WithinDialogues = i;
                    universal.Dialogues[i + 1].WithinDialoguesLocation = diff;
                }
            }
            i = 0; diff = 0;
            for (i = 0xC00; i < 0x1000; i++)
            {
                if (i < 0xFFF) diff = universal.Dialogues[i + 1].DialoguePtr - universal.Dialogues[i].DialoguePtr;
                if (i < 0xFFF && universal.Dialogues[i].RawDialogue.Length > diff && diff > 0)
                {
                    universal.Dialogues[i + 1].WithinDialogues = i;
                    universal.Dialogues[i + 1].WithinDialoguesLocation = diff;
                }
            }
        }
        private void FindDuplicateDialoguePointers()
        {
            int i, a;
            for (i = 0; i < 0x800; i++)
            {
                a = i;
                if (universal.Dialogues[i + 1].DialoguePtr == universal.Dialogues[a].DialoguePtr)
                {
                    universal.Dialogues[i].DuplicateDialogues = i; i++;
                    while (i < 0x800 && universal.Dialogues[i].DialoguePtr == universal.Dialogues[a].DialoguePtr)
                    {
                        universal.Dialogues[i].DuplicateDialogues = a;
                        i++;
                    }
                    i--;
                }
                else universal.Dialogues[i].DuplicateDialogues = i;
            }
            for (i = 0x800; i < 0xC00; i++)
            {
                a = i;
                if (universal.Dialogues[i + 1].DialoguePtr == universal.Dialogues[a].DialoguePtr)
                {
                    universal.Dialogues[i].DuplicateDialogues = i; i++;
                    while (i < 0xC00 && universal.Dialogues[i].DialoguePtr == universal.Dialogues[a].DialoguePtr)
                    {
                        universal.Dialogues[i].DuplicateDialogues = a;
                        i++;
                    }
                    i--;
                }
                else universal.Dialogues[i].DuplicateDialogues = i;
            }
            for (i = 0xC00; i < 0x1000; i++)
            {
                a = i;
                if (universal.Dialogues[i + 1].DialoguePtr == universal.Dialogues[a].DialoguePtr)
                {
                    universal.Dialogues[i].DuplicateDialogues = i; i++;
                    while (i < 0x1000 && universal.Dialogues[i].DialoguePtr == universal.Dialogues[a].DialoguePtr)
                    {
                        universal.Dialogues[i].DuplicateDialogues = a;
                        i++;
                    }
                    i--;
                }
                else universal.Dialogues[i].DuplicateDialogues = i;
            }
        }

        private int CalculateDialogueFreeSpace()
        {
            int used = 0;
            int size = 0;
            int index = 0;
            int end = 0;
            int left = 0;

            if (currentDialogue >= 0x0C00)
            {
                size = (0xFFFF - 0xEDE0) + 0x9000;
                index = 0x0C00;
                end = 0x1000;
            }
            else if (currentDialogue >= 0x0800)
            {
                size = 0xF2D5;
                index = 0x0800;
                end = 0x0C00;
            }
            else
            {
                size = 0xFD18;
                index = 0x0000;
                end = 0x0800;
            }

            for (int i = index; i < end; i++)
            {
                if (i == universal.Dialogues[i].DuplicateDialogues && universal.Dialogues[i].WithinDialoguesLocation == 0)
                {
                    used += universal.Dialogues[i].DialogueLen;

                    if (i < end - 1 && used + universal.Dialogues[i + 1].DialogueLen > size && i + 1 == universal.Dialogues[i + 1].DuplicateDialogues && universal.Dialogues[i + 1].WithinDialoguesLocation == 0)
                    {
                        bool test = false;
                        test = (size >= used + universal.Dialogues[i + 1].DialogueLen);
                    }
                }
            }

            left = size - used;

            return left;
        }
        private string CalculateBattleDialogueFreeSpace()
        {
            int used = 0;
            double left = 0;
            int size;

            if (battleDlgType.SelectedIndex == 0)
            {
                size = (0x92d1 - 0x6754) + (0x2aa9 - 0x260a) + (0xbfff - 0xbc58);/*(0xffff - 0xf400) USED FOR BATTLE SCRIPTS NOW*/
                for (int i = 0; i < universal.BattleDialogues.Length - 1; i++)
                {
                    used += universal.BattleDialogues[i].BattleDialogueLen;

                    if (used + universal.BattleDialogues[i].BattleDialogueLen > size)
                    {
                        bool test = false;

                        test = size >= used + universal.BattleDialogues[i].BattleDialogueLen;

                        if (!test)
                        {
                            i++;
                            return "Entry " + i.ToString() + " Too Long - Cannot Save";
                        }
                    }
                }
            }
            else
            {
                size = (0x2A00 - 0x274D);
                for (int i = 0; i < spriteModel.BattleMessages.Length; i++)
                {
                    used += spriteModel.BattleMessages[i].BattleDialogueLen;

                    //if (used + spriteModel.BattleMessages[i].BattleDialogueLen > size)
                    //{
                    //    bool test = false;

                    //    test = size >= used + spriteModel.BattleMessages[i].BattleDialogueLen;

                    //    if (!test)
                    //    {
                    //        i++;
                    //        return "Entry " + i.ToString() + " Too Long - Cannot Save";
                    //    }
                    //}
                }
            }

            left = (double)(size - used);

            return "AVAILABLE BYTES: " + left.ToString();
        }
        private bool DialogueFreeSpace(int current)
        {
            int used = 0;
            int size = 0;
            int index = 0;
            int end = 0;
            double left = 0;

            if (current >= 0x0C00)
            {
                size = (0xFFFF - 0xEDE0) + 0x9000;
                index = 0x0C00;
                end = 0x1000;
            }
            else if (current >= 0x0800)
            {
                size = 0xF2D5;
                index = 0x0800;
                end = 0x0C00;
            }
            else
            {
                size = 0xFD18;
                index = 0x0000;
                end = 0x0800;
            }

            for (int i = index; i < end; i++)
            {
                if (i == universal.Dialogues[i].DuplicateDialogues && universal.Dialogues[i].WithinDialoguesLocation == 0)
                {
                    used += universal.Dialogues[i].DialogueLen;

                    if (i < end - 1 && used + universal.Dialogues[i + 1].DialogueLen > size && i + 1 == universal.Dialogues[i + 1].DuplicateDialogues && universal.Dialogues[i + 1].WithinDialoguesLocation == 0)
                    {
                        bool test = false;
                        test = (size >= used + universal.Dialogues[i + 1].DialogueLen);

                        if (!test)
                        {
                            i++;
                            return false;
                        }
                    }
                }
            }

            left = (double)(size - used);

            return true;
        }
        private bool BattleDialogueFreeSpace(bool message)
        {
            int used = 0;
            int size;

            if (!message)
            {
                size = (0x92d1 - 0x6754) + (0x2aa9 - 0x260a) + (0xbfff - 0xbc58);/*(0xffff - 0xf400) USED FOR BATTLE SCRIPTS NOW*/
                for (int i = 0; i < universal.BattleDialogues.Length - 1; i++)
                    used += universal.BattleDialogues[i].BattleDialogueLen;
            }
            else
            {
                size = (0x2A00 - 0x274D);
                for (int i = 0; i < spriteModel.BattleMessages.Length; i++)
                    used += spriteModel.BattleMessages[i].BattleDialogueLen;
            }

            return size - used < 0;
        }

        public void InsertIntoDialogueText(string toInsert)
        {
            char[] newText = new char[dialogueTextBox.Text.Length + toInsert.Length];

            dialogueTextBox.Text.CopyTo(0, newText, 0, dialogueTextBox.SelectionStart);
            toInsert.CopyTo(0, newText, dialogueTextBox.SelectionStart, toInsert.Length);
            dialogueTextBox.Text.CopyTo(dialogueTextBox.SelectionStart, newText, dialogueTextBox.SelectionStart + toInsert.Length, this.dialogueTextBox.Text.Length - this.dialogueTextBox.SelectionStart);

            universal.Dialogues[currentDialogue].SetCaretPosition(this.dialogueTextBox.SelectionStart + toInsert.Length, textCodeFormat);
            universal.Dialogues[currentDialogue].SetDialogue(new string(newText), textCodeFormat);
            RefreshDialogueEditor();
            SetDialogueTextImage();
        }
        public void InsertIntoBattleDialogueText(string toInsert)
        {
            char[] newText = new char[battleDialogueTextBox.Text.Length + toInsert.Length];

            battleDialogueTextBox.Text.CopyTo(0, newText, 0, battleDialogueTextBox.SelectionStart);
            toInsert.CopyTo(0, newText, battleDialogueTextBox.SelectionStart, toInsert.Length);
            battleDialogueTextBox.Text.CopyTo(battleDialogueTextBox.SelectionStart, newText, battleDialogueTextBox.SelectionStart + toInsert.Length, this.battleDialogueTextBox.Text.Length - this.battleDialogueTextBox.SelectionStart);

            if (battleDlgType.SelectedIndex == 0)
            {
                universal.BattleDialogues[currentBattleDialogue].SetCaretPosition(this.battleDialogueTextBox.SelectionStart + toInsert.Length, textCodeFormat);
                universal.BattleDialogues[currentBattleDialogue].SetBattleDialogue(new string(newText), textCodeFormat);
            }
            else
            {
                spriteModel.BattleMessages[currentBattleDialogue].SetCaretPosition(this.battleDialogueTextBox.SelectionStart + toInsert.Length, textCodeFormat);
                spriteModel.BattleMessages[currentBattleDialogue].SetBattleDialogue(new string(newText), textCodeFormat);
            }
            RefreshBattleDialogueEditor();
            SetBattleDialogueTextImage();
        }

        private void LoadSearch()
        {
            string dialogueSearch = "";
            int j = 0;

            for (int i = 0; i < universal.Dialogues.Length; i++)
            {
                if (Contains(universal.Dialogues[i].GetDialogue(textCodeFormat), textBoxSearch.Text, StringComparison.CurrentCultureIgnoreCase))
                {
                    j++;
                    dialogueSearch += "[" + universal.Dialogues[i].DialogueNum.ToString() + "]\n";
                    dialogueSearch += universal.Dialogues[i].GetDialogue(textCodeFormat) + "\n\n";
                }
            }
            this.searchResults.Text = j.ToString() + " results...\n\n" + dialogueSearch;
        }

        // assembler
        private void AssembleDialogues()
        {
            // Assemble the Battle Dialogue

            int i = 0;
            ushort len = 0x6754;
            if (!BattleDialogueFreeSpace(false))
            {
                for (; i < universal.BattleDialogues.Length && len + universal.BattleDialogues[i].BattleDialogueLen < 0x92d1; i++)
                    len += universal.BattleDialogues[i].Assemble(len);

                len = 0x260A;// - 0x392AA9
                for (; i < universal.BattleDialogues.Length && len + universal.BattleDialogues[i].BattleDialogueLen < 0x2aa9; i++)
                    len += universal.BattleDialogues[i].Assemble(len);

                len = 0xBC58;// - 0x39BFFF
                for (; i < universal.BattleDialogues.Length && len + universal.BattleDialogues[i].BattleDialogueLen < 0xbfff; i++)
                    len += universal.BattleDialogues[i].Assemble(len);

            }
            else
                MessageBox.Show("Battle Dialogue exceeds max size, decrease total size to save correctly.\nNote: not all text has been saved.");

            if (!BattleDialogueFreeSpace(true))
            {
                i = 0;
                len = 0x274D;
                for (; i < spriteModel.BattleMessages.Length && len + spriteModel.BattleMessages[i].BattleDialogueLen < 0x2A00; i++)
                    len += spriteModel.BattleMessages[i].Assemble(len);
            }
            else
                MessageBox.Show("Battle Message exceeds max size, decrease total size to save correctly.\nNote: not all text has been saved.");

            // Assemble the dialogue
            string original, within;
            int temp = currentDialogue;

            // 000 - 1ff
            if (DialogueFreeSpace(0))
            {
                len = 0x0008;
                for (i = 0; i < 0x0800 && (len + universal.Dialogues[i].DialogueLen < 0xFD18 || (i != universal.Dialogues[i].DuplicateDialogues && !isDialogueChanged[i])); i++)
                {
                    if (i == universal.Dialogues[i].DuplicateDialogues && universal.Dialogues[i].WithinDialoguesLocation == 0)
                        len += universal.Dialogues[i].Assemble(len);
                    else if (universal.Dialogues[i].WithinDialoguesLocation != 0)
                    {
                        original = new string(universal.Dialogues[universal.Dialogues[i].WithinDialogues].RawDialogue);
                        within = new string(universal.Dialogues[i].RawDialogue);
                        universal.Dialogues[i].Assemble((ushort)(universal.Dialogues[universal.Dialogues[i].WithinDialogues].DialoguePtr + original.IndexOf(within) + 8));
                    }
                    else
                        universal.Dialogues[i].Assemble((ushort)(universal.Dialogues[universal.Dialogues[i].DuplicateDialogues].DialoguePtr + 8));
                    // if the next dialogue has a smaller pointer or points to a place in the current dialogue, and both the current and next universal.Dialogues haven't changed
                }
            }
            else
                MessageBox.Show("The dialogue in bank 1 was not saved. Please delete the necessary number of bytes for space.\n\nLast dialogue saved was #" + i.ToString() + ". It should have been #2047", 
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (DialogueFreeSpace(0x800))
            {
                len = 0x0004;
                for (i = 0x0800; i < 0x0C00 && (len + universal.Dialogues[i].DialogueLen < 0xF2D5 || (i != universal.Dialogues[i].DuplicateDialogues && !isDialogueChanged[i])); i++)
                {
                    if (i == universal.Dialogues[i].DuplicateDialogues && universal.Dialogues[i].WithinDialoguesLocation == 0)
                        len += universal.Dialogues[i].Assemble(len);
                    else if (universal.Dialogues[i].WithinDialoguesLocation != 0)
                    {
                        original = new string(universal.Dialogues[universal.Dialogues[i].WithinDialogues].RawDialogue);
                        within = new string(universal.Dialogues[i].RawDialogue);
                        universal.Dialogues[i].Assemble((ushort)(universal.Dialogues[universal.Dialogues[i].WithinDialogues].DialoguePtr + original.IndexOf(within) + 4));
                    }
                    else
                        universal.Dialogues[i].Assemble((ushort)(universal.Dialogues[universal.Dialogues[i].DuplicateDialogues].DialoguePtr + 4));
                }
            }
            else
                MessageBox.Show("The dialogue in bank 2 was not saved. Please delete the necessary number of bytes for space.\n\nLast dialogue saved was #" + i.ToString() + ". It should have been #2047",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (DialogueFreeSpace(0xC00))
            {
                len = 0x0004;
                for (i = 0x0C00; i < 0x1000 && len + universal.Dialogues[i].DialogueLen < 0x8FFF; i++)
                {
                    if (i == universal.Dialogues[i].DuplicateDialogues && universal.Dialogues[i].WithinDialoguesLocation == 0)
                        len += universal.Dialogues[i].Assemble(len);
                    else if (universal.Dialogues[i].WithinDialoguesLocation != 0)
                    {
                        original = new string(universal.Dialogues[universal.Dialogues[i].WithinDialogues].RawDialogue);
                        within = new string(universal.Dialogues[i].RawDialogue);
                        universal.Dialogues[i].Assemble((ushort)(universal.Dialogues[universal.Dialogues[i].WithinDialogues].DialoguePtr + original.IndexOf(within) + 4));
                    }
                    else
                        universal.Dialogues[i].Assemble((ushort)(universal.Dialogues[universal.Dialogues[i].DuplicateDialogues].DialoguePtr + 4));
                }

                len = 0xEDE0;
                for (; i < 0x1000 && len + universal.Dialogues[i].DialogueLen < 0xFFFF; i++)
                {
                    if (i == universal.Dialogues[i].DuplicateDialogues && universal.Dialogues[i].WithinDialoguesLocation == 0)
                        len += universal.Dialogues[i].Assemble(len);
                    else if (universal.Dialogues[i].WithinDialoguesLocation != 0)
                    {
                        original = new string(universal.Dialogues[universal.Dialogues[i].WithinDialogues].RawDialogue);
                        within = new string(universal.Dialogues[i].RawDialogue);
                        universal.Dialogues[i].Assemble((ushort)(universal.Dialogues[universal.Dialogues[i].WithinDialogues].DialoguePtr + original.IndexOf(within) + 4));
                    }
                    else
                        universal.Dialogues[i].Assemble((ushort)(universal.Dialogues[universal.Dialogues[i].DuplicateDialogues].DialoguePtr + 4));
                }
            }
            else
                MessageBox.Show("The dialogue in bank 3 was not saved. Please delete the necessary number of bytes for space.\n\nLast dialogue saved was #" + i.ToString() + ". It should have been #2047",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #endregion

        #region Eventhandlers

        // dialogue
        private void byteOrTextView_Click(object sender, System.EventArgs e)
        {
            string test = dialogueTextBox.Text;

            if (universal.Dialogues[currentDialogue].SetDialogue(this.dialogueTextBox.Text, textCodeFormat) && universal.BattleDialogues[currentBattleDialogue].SetBattleDialogue(this.battleDialogueTextBox.Text, textCodeFormat))
                textCodeFormat = !byteOrTextView.Checked;
            else
                byteOrTextView.Checked = !byteOrTextView.Checked;

            byteOrTextView.ForeColor = byteOrTextView.Checked ? SystemColors.ControlText : SystemColors.ControlDark;

            this.dialogueTextBox.Text = this.universal.Dialogues[currentDialogue].GetDialogue(textCodeFormat);
            this.battleDialogueTextBox.Text = this.universal.BattleDialogues[currentBattleDialogue].GetBattleDialogue(textCodeFormat);
        }
        private void dialogueNum_ValueChanged(object sender, System.EventArgs e)
        {
            if (updatingDialogue) return;

            dialoguePreview.Reset();

            RefreshDialogueEditor();
            SetDialogueTextImage();
        }
        private void dialoguePreviewPageDown_Click(object sender, System.EventArgs e)
        {
            dialoguePreview.PageDown(universal.Dialogues[currentDialogue].RawDialogue.Length);
            SetDialogueTextImage();
        }
        private void dialoguePreviewPageUp_Click(object sender, System.EventArgs e)
        {
            dialoguePreview.PageUp();
            SetDialogueTextImage();
        }
        private void dialogueTextBox_KeyDown(Object sender, KeyEventArgs e)
        {
            int temp = universal.Dialogues[currentDialogue].DuplicateDialogues;
            //DialogResult result;
            if (e.KeyValue >= 0 && e.KeyValue <= 0x9F)
            {
                universal.Dialogues[currentDialogue].DuplicateDialogues = currentDialogue;

                if (!isDialogueChanged[currentDialogue])
                {
                    if (currentDialogue < 0x800)
                    {
                        for (int i = 0; i < 0x800; i++)
                        {
                            if (universal.Dialogues[i].DuplicateDialogues == currentDialogue)
                            {
                                universal.Dialogues[i].DuplicateDialogues = i;
                            }
                            if (universal.Dialogues[i].WithinDialogues == currentDialogue)
                                universal.Dialogues[i].WithinDialogues = 0;
                        }
                    }
                    else if (currentDialogue < 0xC00)
                    {
                        for (int i = 0x800; i < 0xC00; i++)
                        {
                            if (universal.Dialogues[i].DuplicateDialogues == currentDialogue)
                            {
                                universal.Dialogues[i].DuplicateDialogues = i;
                            }
                            if (universal.Dialogues[i].WithinDialogues == currentDialogue)
                                universal.Dialogues[i].WithinDialogues = 0;
                        }
                    }
                    else if (currentDialogue < 0x1000)
                    {
                        for (int i = 0xC00; i < 0x1000; i++)
                        {
                            if (universal.Dialogues[i].DuplicateDialogues == currentDialogue)
                            {
                                universal.Dialogues[i].DuplicateDialogues = i;
                            }
                            if (universal.Dialogues[i].WithinDialogues == currentDialogue)
                                universal.Dialogues[i].WithinDialogues = 0;
                        }
                    }
                }

                isDialogueChanged[currentDialogue] = true;
            }
        }
        private void dialogueTextBox_TextChanged(Object sender, EventArgs e)
        {
            if (updatingDialogue) return;

            SetDialogueTextImage();

            int temp = CalculateDialogueFreeSpace();
            this.label196.Text = "AVAILABLE BYTES: " + temp.ToString();
            this.label196.BackColor = temp >= 0 ? SystemColors.ControlDark : Color.Red;
        }
        private void dialogueTextBox_Leave(object sender, EventArgs e)
        {
            if (!dialogueTextBox.Text.EndsWith("[0]") && !dialogueTextBox.Text.EndsWith("[6]"))
            {
                dialogueTextBox.SelectionStart = dialogueTextBox.Text.Length;
                InsertIntoDialogueText("[0]");
            }
        }
        private void dialogueTextBox_Enter(object sender, EventArgs e)
        {
            if (currentDialogue != universal.Dialogues[currentDialogue].DuplicateDialogues)
                MessageBox.Show("This dialogue is a duplicate of another.\n\n" +
                    "Modifying it might result in a significant loss of available byte space.",
                    "LAZY SHELL");
            for (int i = 0; i < universal.Dialogues.Length; i++)
            {
                if (i != currentDialogue && currentDialogue == universal.Dialogues[i].DuplicateDialogues)
                {
                    MessageBox.Show("This dialogue is a template for one or more duplicates.\n\n" +
                        "Modifying it might result in a significant loss of available byte space.",
                        "LAZY SHELL");
                    break;
                }
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (listBox1.SelectedIndex)
            {
                case 0:
                    if (textCodeFormat)
                        InsertIntoDialogueText("[0]");
                    else
                        InsertIntoDialogueText("[endInput]");
                    break;
                case 1:
                    if (textCodeFormat)
                        InsertIntoDialogueText("[6]");
                    else
                        InsertIntoDialogueText("[end]");
                    break;
                case 2:
                    if (textCodeFormat)
                        InsertIntoDialogueText("[2]");
                    else
                        InsertIntoDialogueText("[newLineInput]");
                    break;
                case 3:
                    if (textCodeFormat)
                        InsertIntoDialogueText("[1]");
                    else
                        InsertIntoDialogueText("[newLine]");
                    break;
                case 4:
                    if (textCodeFormat)
                        InsertIntoDialogueText("[3]");
                    else
                        InsertIntoDialogueText("[newPageInput]");
                    break;
                case 5:
                    if (textCodeFormat)
                        InsertIntoDialogueText("[4]");
                    else
                        InsertIntoDialogueText("[newPage]");
                    break;
                case 6:
                    if (textCodeFormat)
                        InsertIntoDialogueText("[5]");
                    else
                        InsertIntoDialogueText("[pauseInput]");
                    break;
                case 7:
                    if (textCodeFormat)
                        InsertIntoDialogueText("[12]");
                    else
                        InsertIntoDialogueText("[delay]");
                    break;
                case 8:
                    if (textCodeFormat)
                        InsertIntoDialogueText("[7]");
                    else
                        InsertIntoDialogueText("[option]");
                    break;
            }
            dialogueTextBox.Focus();
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (textCodeFormat)
                InsertIntoDialogueText("[13][" + this.dialogueByteValue.Value.ToString() + "]");
            else
                InsertIntoDialogueText("[FRAME DELAY][ " + this.dialogueByteValue.Value.ToString() + "]");
            dialogueTextBox.Focus();
        }
        private void buttonInsertVAR_Click(object sender, EventArgs e)
        {
            int variable = this.dialogueMemory.SelectedIndex;
            if (textCodeFormat)
            {
                if (variable > 0)
                {
                    variable--;
                    InsertIntoDialogueText("[28][" + variable.ToString() + "]");
                }
                else
                    InsertIntoDialogueText("[26]");
            }
            else
            {
                if (variable > 0)
                {
                    variable--;
                    InsertIntoDialogueText("[NUMBER FROM EVENT MEMORY][ " + variable.ToString() + "]");
                }
                else
                    InsertIntoDialogueText("[ITEM VARIABLE FROM EVENT MEMORY 00:70A7]");
            }
            dialogueTextBox.Focus();
        }
        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 0x0D)
                LoadSearch();
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            LoadSearch();
        }
        private void pictureBoxDialogue_Paint(object sender, PaintEventArgs e)
        {
            if (dialogueBGImage != null)
                e.Graphics.DrawImage(dialogueBGImage, 0, 0);
            if (dialogueTextImage != null)
                e.Graphics.DrawImage(dialogueTextImage, 0, 0);
        }

        // battle dialogue
        private void battleDlgType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string temp;
            if (battleDlgType.SelectedIndex == 0)
            {
                battleDialogueNum.Maximum = 255;
                battleDialogueName.Items.Clear();
                for (int i = 0; i < universal.BattleDialogues.Length; i++)
                {
                    temp = universal.BattleDialogues[i].GetBattleDialogue(textCodeFormat);
                    if (temp.Length > 40)
                        battleDialogueName.Items.Add(temp.Substring(0, 40));
                    else
                        battleDialogueName.Items.Add(temp);
                }
            }
            else
            {
                battleDialogueNum.Maximum = 45;
                battleDialogueName.Items.Clear();
                for (int i = 0; i < spriteModel.BattleMessages.Length; i++)
                {
                    temp = spriteModel.BattleMessages[i].GetBattleDialogue(textCodeFormat);
                    if (temp.Length > 40)
                        battleDialogueName.Items.Add(temp.Substring(0, 40));
                    else
                        battleDialogueName.Items.Add(temp);
                }
            }
            RefreshBattleDialogueEditor();
            SetBattleDialogueTextImage();
        }
        private void battleDialogueName_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (updatingBattleDialogue) return;

            this.battleDialogueNum.Value = (int)this.battleDialogueName.SelectedIndex;
        }
        private void battleDialogueNum_ValueChanged(object sender, System.EventArgs e)
        {
            if (updatingBattleDialogue) return;

            battleDialoguePreview.Reset();
            battleDialogueName.SelectedIndex = (int)battleDialogueNum.Value;

            RefreshBattleDialogueEditor();
            SetBattleDialogueTextImage();
        }
        private void battleDialoguePageDown_Click(object sender, System.EventArgs e)
        {
            if (battleDlgType.SelectedIndex == 0)
                battleDialoguePreview.PageDown(universal.BattleDialogues[currentBattleDialogue].RawBattleDialogue.Length);
            else
                battleDialoguePreview.PageDown(spriteModel.BattleMessages[currentBattleDialogue].RawBattleDialogue.Length);
            SetBattleDialogueTextImage();
        }
        private void battleDialoguePageUp_Click(object sender, System.EventArgs e)
        {
            battleDialoguePreview.PageUp();
            SetBattleDialogueTextImage();
        }
        private void battleDialogueTextBox_TextChanged(object sender, EventArgs e)
        {
            if (updatingBattleDialogue) return;

            SetBattleDialogueTextImage();

            this.label187.Text = CalculateBattleDialogueFreeSpace();
        }
        private void battleDialogueTextBox_Leave(object sender, EventArgs e)
        {
            if (!battleDialogueTextBox.Text.EndsWith("[0]"))
            {
                battleDialogueTextBox.SelectionStart = battleDialogueTextBox.Text.Length;
                InsertIntoBattleDialogueText("[0]");
            }
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (listBox2.SelectedIndex)
            {
                case 0:
                    if (textCodeFormat)
                        InsertIntoBattleDialogueText("[0]");
                    else
                        InsertIntoBattleDialogueText("[end]");
                    break;
                case 1:
                    if (textCodeFormat)
                        InsertIntoBattleDialogueText("[1]");
                    else
                        InsertIntoBattleDialogueText("[newLine]");
                    break;
                case 2:
                    if (textCodeFormat)
                        InsertIntoBattleDialogueText("[2]");
                    else
                        InsertIntoBattleDialogueText("[pauseInput]");
                    break;
                case 3:
                    if (textCodeFormat)
                        InsertIntoBattleDialogueText("[3]");
                    else
                        InsertIntoBattleDialogueText("[delayInput]");
                    break;
                case 4:
                    if (textCodeFormat)
                        InsertIntoBattleDialogueText("[12]");
                    else
                        InsertIntoBattleDialogueText("[delay]");
                    break;
            }
            battleDialogueTextBox.Focus();
        }
        private void pictureBoxBattleDialogue_Paint(object sender, PaintEventArgs e)
        {
            if (battleDialogueTilesetImage != null)
                e.Graphics.DrawImage(battleDialogueTilesetImage, 0, 0);
            if (battleDialogueTextImage != null)
                e.Graphics.DrawImage(battleDialogueTextImage, 0, 0);
        }
        #endregion
    }
}
