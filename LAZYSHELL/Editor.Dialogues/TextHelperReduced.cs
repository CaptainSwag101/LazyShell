using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using LAZYSHELL.Properties;
namespace LAZYSHELL
{
    [Serializable()]
    public sealed class TextHelperReduced
    {
        static TextHelperReduced instance = null;
        static readonly object padlock = new object();
        private bool error = false; public bool Error { get { return error; } }
        private Settings settings = Settings.Default;

        TextHelperReduced()
        {

        }
        public static TextHelperReduced Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                        instance = new TextHelperReduced();
                    return instance;
                }
            }
        }

        // STRINGS (57)
        private const string code00 = "end"; // SURROUNDED BY {   }
        private const string code01 = "newLine"; // SURROUNDED BY {   }
        private const string code02 = "pauseInput"; // SURROUNDED BY {   }
        private const string code03 = "delayInput"; // SURROUNDED BY {   }
        private const string code0C = "delay";  // SURROUNDED BY {   }
        private const string code1C = "memNum..."; // no idea

        public char[] DecodeText(char[] decode, bool byteView, int textType, StringCollection keystrokes)
        {
            int count = keystrokes.Count - 1;
            ArrayList arrayList = new ArrayList();
            bool lastBrace = true;
            for (int i = 0; i < decode.Length; i++) // For every character of text
            {
                // skip if out of bounds
                if (decode[i] >= keystrokes.Count)
                    continue;
                if (byteView) // We are decoding to numbers
                {
                    if (keystrokes[decode[i]] == "") // Is encoded character
                    {
                        switch ((byte)decode[i]) // Since the byte is encoded, it musts coorespond to one of these cases
                        // All case numbers are for decoding to text for the plain text
                        {
                            case 0x1C:
                                string tem = ((byte)decode[i]).ToString();

                                char[] dec = tem.ToCharArray();
                                arrayList.Add('[');
                                for (int z = 0; z < dec.Length; z++)
                                {
                                    arrayList.Add(dec[z]);
                                }
                                arrayList.Add(']');
                                if (decode.Length > i + 1)
                                {
                                    i++;
                                    goto default;
                                }
                                break;
                            default:
                                string temp = ((byte)decode[i]).ToString();
                                char[] decoded = temp.ToCharArray();
                                arrayList.Add('[');
                                for (int z = 0; z < decoded.Length; z++)
                                    arrayList.Add(decoded[z]);
                                arrayList.Add(']');
                                break;
                        }
                    }
                    else // Not encoded character
                        arrayList.Add(Convert.ToChar(keystrokes[decode[i]]));
                }
                else // We are decoding to words
                {
                    if (keystrokes[decode[i]] == "") // Current byte is encoded
                    {
                        lastBrace = true;
                        switch ((byte)decode[i])
                        {
                            case 0x00:
                                arrayList.Add('[');
                                AddCharsToArrayList(arrayList, code00.ToCharArray());
                                break;
                            case 0x01:
                                arrayList.Add('[');
                                AddCharsToArrayList(arrayList, code01.ToCharArray());
                                break;
                            case 0x02:
                                arrayList.Add('[');
                                AddCharsToArrayList(arrayList, code02.ToCharArray());
                                break;
                            case 0x03:
                                arrayList.Add('[');
                                AddCharsToArrayList(arrayList, code03.ToCharArray());
                                break;
                            case 0x0C:
                                arrayList.Add('[');
                                AddCharsToArrayList(arrayList, code0C.ToCharArray());
                                break;
                            case 0x1C:
                                arrayList.Add('[');
                                AddCharsToArrayList(arrayList, code1C.ToCharArray());
                                arrayList.Add(']');
                                arrayList.Add('[');
                                arrayList.Add(' ');
                                i++;
                                string te = ((byte)decode[i]).ToString();

                                char[] de = te.ToCharArray();
                                for (int z = 0; z < de.Length; z++)
                                {
                                    arrayList.Add(de[z]);
                                }
                                break;
                            default:
                                arrayList.Add('[');
                                AddCharsToArrayList(arrayList, "THIS IS A BUG: ".ToCharArray());
                                string temp = ((byte)decode[i]).ToString();
                                AddCharsToArrayList(arrayList, temp.ToCharArray());
                                break;
                        }
                        if (lastBrace)
                            arrayList.Add(']');
                    }
                    else
                        arrayList.Add(Convert.ToChar(keystrokes[decode[i]]));
                }
            }

            char[] decodedStr = new char[arrayList.Count];
            arrayList.CopyTo(decodedStr);

            return decodedStr;
        }
        public char[] EncodeText(char[] array, bool byteView, int textType, StringCollection keystrokes)
        {
            bool openQuote = true;
            ArrayList arrayList = new ArrayList();
            char[] backup = array;

            for (int i = 0; i < array.Length; i++)
            {
                if (byteView)
                {
                    if (array[i] == '[' ||
                        array[i] == '\x20' ||
                        array[i] == '\x22' ||
                        array[i] == '\x2D' ||
                        array[i] == '\x27')
                    {
                        switch (array[i])
                        {
                            case '[':// Encode {123] to bytes
                                // Can get rid of by using 2 digit hex characters
                                if (array.Length > i + 1)
                                {
                                    if (array[i + 1] != ']') // would make 1
                                    {
                                        char digitOne = (char)(array[i + 1] - 0x30);

                                        if (array.Length > i + 2 && array[i + 2] != ']') // would make 2 digits
                                        {
                                            char digitTwo = (char)(array[i + 2] - 0x30);

                                            if (array.Length > i + 3 && array[i + 3] != ']') // would make 3 digits
                                            {
                                                char digitThree = (char)(array[i + 3] - 0x30);
                                                arrayList.Add((char)((digitOne * 100) + (digitTwo * 10) + digitThree));
                                                i += 4;
                                                break;
                                            }
                                            else // 2 digits
                                            {
                                                arrayList.Add((char)((digitOne * 10) + digitTwo));
                                                i += 3;
                                                break;
                                            }
                                        }
                                        arrayList.Add((char)(digitOne));
                                        i += 2;
                                        break;
                                    }
                                    break; // none
                                }
                                break;
                            case '\x2D':
                                if (textType == 0)      // Battle Dialogue
                                    arrayList.Add('\x2D');
                                else if (textType == 1) // Item/Spell Desc.
                                    arrayList.Add('\x7D');
                                break;
                            case '\x27':
                                if (textType == 0)      // Battle Dialogue
                                    arrayList.Add('\x9B');
                                else if (textType == 1) // Item/Spell Desc.
                                    arrayList.Add('\x7E');
                                break;
                            case '\x22':
                                if (openQuote)
                                {
                                    arrayList.Add('\x22');
                                    openQuote = false;
                                }
                                else
                                {
                                    arrayList.Add('\x23');
                                    openQuote = true;
                                }
                                break;
                            default: arrayList.Add('\x20'); break;
                        }
                    }
                    else
                    {
                        if (textType == 0)
                            arrayList.Add(StringIndex(settings.Keystrokes, array[i]));
                        else if (textType == 1)
                            arrayList.Add(StringIndex(settings.KeystrokesDesc, array[i]));
                    }
                }
                else
                {
                    if (array[i] == '[' ||
                        array[i] == '\x22' ||
                        array[i] == '\x2D' ||
                        array[i] == '\x27')
                    {
                        switch (array[i])
                        {
                            case '[':
                                int len;
                                i++;
                                for (len = 0; len < array.Length - i && array[i + len] != ']'; len++) ;
                                char[] codeChar = new char[len];
                                for (int z = 0; z < len; z++)
                                    codeChar[z] = array[i + z];
                                string codeStr = new string(codeChar);

                                switch (codeStr)
                                {
                                    case code00: arrayList.Add('\x00'); break;
                                    case code01: arrayList.Add('\x01'); break;
                                    case code02: arrayList.Add('\x02'); break;
                                    case code03: arrayList.Add('\x03'); break;
                                    case code0C: arrayList.Add('\x0C'); break;
                                    default: break;
                                }
                                i += len;
                                break;
                            case '\x2D':
                                if (textType == 0)      // Battle Dialogue
                                    arrayList.Add('\x2D');
                                else if (textType == 1) // Item/Spell Desc.
                                    arrayList.Add('\x7D');
                                break;
                            case '\x27':
                                if (textType == 0)      // Battle Dialogue
                                    arrayList.Add('\x9B');
                                else if (textType == 1) // Item/Spell Desc.
                                    arrayList.Add('\x7E');
                                break;
                            case '\x22': // handles user input quotes
                                if (openQuote)
                                {
                                    arrayList.Add('\x22');
                                    openQuote = false;
                                }
                                else
                                {
                                    arrayList.Add('\x23');
                                    openQuote = true;
                                }
                                break;
                            default: arrayList.Add('\x20'); break;
                        }
                    }
                    else
                        arrayList.Add(StringIndex(keystrokes, array[i]));
                }
            }

            char[] encodedStr = new char[arrayList.Count];
            try
            {
                arrayList.CopyTo(encodedStr);
            }
            catch
            {
                //MessageBox.Show("Input Error, text not valid. You probably entered a character that Super Mario RPG cannot parse. This text will not be saved unless the error is fixed.");
                error = true;
                return backup;
            }

            if (!VerifyText(encodedStr))
            {
                //MessageBox.Show("The text input is invalid. Please verify '[' and ']' brackets.\n\nIt may also be a character in the text that the ROM cannot parse.\nThis text will not be saved unless the error is fixed.", "LAZY SHELL");
                error = true;
                return backup;
            }
            error = false;


            return encodedStr;
        }
        public void AddCharsToArrayList(ArrayList arrayList, char[] chars)
        {
            for (int i = 0; i < chars.Length; i++)
            {
                arrayList.Add(chars[i]);
            }
        }
        public bool SearchForSubstring(char[] array, int index, string substring)
        {
            char[] subStr = substring.ToCharArray();
            if (array.Length < substring.Length + index)
                return false;
            for (int i = 0; i < subStr.Length; i++)
            {
                if (subStr[i] != array[i + index])
                    return false;
            }
            return true;
        }
        public bool VerifyText(char[] toTest)
        {
            bool openBracket = false;
            if (toTest.Length == 0)
            {
                return true;
            }
            for (int i = 0; i < toTest.Length; i++)
            {
                if (toTest[i] != '[' && toTest[i] != ']' && IsValidChar(toTest[i]) == false)
                    if (i == 0 || (toTest[i - 1] != '\x0B' && toTest[i - 1] != '\x0D'))
                        return false;

                if (toTest[i] == '[')
                {
                    if (openBracket == true)
                        return false;
                    openBracket = true;
                }
                if (toTest[i] == ']')
                {
                    if (openBracket == false)
                        return false;
                    openBracket = false;
                }
            }
            if (openBracket == false)
                return true;
            return false;
        }
        public bool IsValidChar(char toTest)
        {
            if (toTest >= '\x00' && toTest <= '\x1C') return true;
            if (toTest >= '\x20' && toTest <= '\x5A') return true;
            if (toTest >= '\x5C' && toTest <= '\x9F') return true;
            foreach (string temp in settings.Keystrokes)
                if (temp != "" && Convert.ToChar(temp) == toTest) return true;
            return false;
        }
        public bool VerifyCorrectSymbols(char[] toVerify, bool byteView)
        {
            bool symbol = false, found = false;
            try
            {
                for (int i = 0; i < toVerify.Length; i++)
                {
                    if (toVerify[i] == '[')
                    {
                        if (toVerify[i + 1] >= '\x30' && toVerify[i + 1] <= '\x39')
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
        public char StringIndex(StringCollection strings, char character)
        {
            for (char i = (char)0; i < strings.Count; i++)
            {
                if (strings[i] == character.ToString())
                    return i;
            }
            return character;
        }
    }
}
