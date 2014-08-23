using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LAZYSHELL.Dialogues
{
    public class Parser
    {
        #region Variables

        /// <summary>
        /// Indicates whether an error was encountered during the last encoding operation.
        /// </summary>
        public bool Error { get; set; }

        // Descriptive tags
        public const string code00 = "endInput";
        public const string code01 = "newLine";
        public const string code24 = "heart";
        public const string code25 = "note";
        public const string code2A = "bullet";
        public const string code2B = "bullets";
        public const string code3B = "cornerLeft";
        public const string code3C = "cornerRight";
        public const string code3D = "cornerLeftBold";
        public const string code3E = "cornerRightBold";
        public const string code92 = "ellipsis";
        public const string code97 = "arrowUp";
        public const string code98 = "arrowRight";
        public const string code99 = "arrowLeft";

        #endregion

        #region Methods

        public bool VerifyText(char[] text)
        {
            bool openBracket = false;
            if (text.Length == 0)
                return true;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != '[' && text[i] != ']' && IsValidSymbol(text[i]) == false)
                    if (i == 0 || (text[i - 1] != '\x0B' && text[i - 1] != '\x0D'))
                        return false;
                if (text[i] == '[')
                {
                    if (openBracket)
                        return false;
                    openBracket = true;
                }
                if (text[i] == ']')
                {
                    if (!openBracket)
                        return false;
                    openBracket = false;
                }
            }
            if (openBracket == false)
                return true;
            return false;
        }
        public bool VerifySymbols(char[] symbols, bool byteView)
        {
            bool symbol = false, found = false;
            try
            {
                for (int i = 0; i < symbols.Length; i++)
                {
                    if (symbols[i] == '[')
                    {
                        if (symbols[i + 1] >= '\x30' && symbols[i + 1] <= '\x39')
                            symbol = true;
                        else
                            symbol = false;
                        found = true;
                    }
                    if (byteView != symbol && found)
                        return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool VerifyText(string text, bool byteView)
        {
            bool openBracket = false;
            char[] symbols = text.ToCharArray();
            for (int i = 0; i < symbols.Length; i++)
            {
                if (symbols[i] == '[')
                {
                    // If open bracket inside tag
                    if (openBracket)
                        return false;
                    openBracket = true;
                    for (int a = i + 1; a < symbols.Length && symbols[a] != ']'; a++, i++)
                    {
                        // Contains non-numeric symbols
                        if (byteView && !(symbols[a] >= '0' && symbols[a] <= '9'))
                            return false;
                    }
                }
                else if (!IsValidSymbol(symbols[i]))
                    return false;
                if (symbols[i] == ']')
                    openBracket = false;
            }
            return true;
        }
        public bool IsValidSymbol(char symbol)
        {
            if (symbol >= '\x00' && symbol <= '\x1C') return true;
            if (symbol >= '\x20' && symbol <= '\x5A') return true;
            if (symbol >= '\x5C' && symbol <= '\x9F') return true;
            foreach (string keystroke in Lists.Keystrokes)
                if (keystroke != "" && Convert.ToChar(keystroke) == symbol) return true;
            return false;
        }
        public char StringIndex(string[] strings, char symbol)
        {
            for (char i = (char)0; i < strings.Length; i++)
            {
                if (strings[i] == symbol.ToString())
                    return i;
            }
            return symbol;
        }
        public bool FindSubstring(char[] text, int index, string substring)
        {
            if (text.Length < substring.Length + index)
                return false;
            for (int i = 0; i < substring.Length; i++)
            {
                if (substring[i] != text[i + index])
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Replaces all line breaks in a TextBox's text with its tag.
        /// </summary>
        public void ReplaceLineBreaks(RichTextBox textBox, bool byteView)
        {
            int selectionStart = textBox.SelectionStart;
            int occurrences = Regex.Matches(textBox.Text, "\n").Count;
            if (byteView)
                textBox.Text = textBox.Text.Replace("\n", "[1]");
            else
                textBox.Text = textBox.Text.Replace("\n", code01);
            selectionStart += occurrences * 2;
            if (selectionStart < textBox.Text.Length)
                textBox.SelectionStart = selectionStart;
        }

        #endregion
    }
}
