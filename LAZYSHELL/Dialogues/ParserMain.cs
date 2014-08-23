using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Collections.Specialized;
using System.Windows.Forms;
using LAZYSHELL.Properties;

namespace LAZYSHELL.Dialogues
{
    /// <summary>
    /// Class for encoding and decoding text used in overworld dialogues.
    /// </summary>
    [Serializable()]
    public sealed class ParserMain : Parser
    {
        #region Variables

        // Instance
        private static readonly object padlock = new object();
        private static ParserMain instance = null;
        public static ParserMain Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                        instance = new ParserMain();
                    return instance;
                }
            }
        }

        // Keystrokes
        private string[] keystrokes = Lists.Keystrokes;

        #region Descriptive tags

        private const string code02 = "newLineInput";
        private const string code03 = "newPageInput";
        private const string code04 = "newPage";
        private const string code05 = "pauseInput";
        private const string code06 = "end";
        private const string code07 = "option";
        private const string code08 = "  ";
        private const string code09 = "   ";
        private const string code0A = "    ";
        private const string code0C = "delay";
        private const string code0D = "delay...";
        private const string code1A = "memItem";
        private const string code1C = "memNum...";

        #endregion

        #endregion

        #region Methods

        /// <summary>
        /// Converts an array of symbols in Mario RPG binary format to a character array 
        /// for viewing and editing in a user interface.
        /// </summary>
        /// <param name="input">The symbols to convert.</param>
        /// <param name="byteView">Indicates whether the array's unparsed symbols will be 
        /// converted to a byte string or a descriptive tag.</param>
        /// <param name="dte">The compression table to use for converting compressed values to strings.</param>
        /// <returns></returns>
        public char[] Decode(char[] input, bool byteView, string[] dte)
        {
            List<char> letters = new List<char>();
            bool lastBrace = true;
            for (int i = 0; i < input.Length; i++) // For every character of text
            {
                // skip if out of bounds
                if (input[i] >= keystrokes.Length)
                    continue;
                // if a table
                if (dte != null && input[i] >= 0x0E && input[i] <= 0x19)
                {
                    letters.AddRange(dte[input[i] - 0x0E].ToCharArray());
                    continue;
                }
                #region Byte view
                if (byteView) // We are decoding to numbers
                {
                    if (keystrokes[input[i]] == "") // Is encoded character
                    {
                        switch ((byte)input[i])
                        {
                            case 0x08: letters.AddRange(code08.ToCharArray()); break;
                            case 0x09: letters.AddRange(code09.ToCharArray()); break;
                            case 0x0A: letters.AddRange(code0A.ToCharArray()); break;
                            case 0x0B: // number of spaces
                                if (input.Length > i + 1)
                                {
                                    i++;
                                    for (int a = 0; a < input[i]; a++)
                                        letters.Add(' ');
                                }
                                break;
                            case 0x0D: goto case 0xFF;
                            case 0x1C: goto case 0xFF;
                            case 0xFF:
                                letters.Add('[');
                                letters.AddRange(((byte)input[i]).ToString());
                                letters.Add(']');
                                if (input.Length > i + 1)
                                {
                                    i++;
                                    goto default;
                                }
                                break;
                            default:
                                letters.Add('[');
                                letters.AddRange(((byte)input[i]).ToString());
                                letters.Add(']');
                                break;
                        }
                    }
                    else // Not encoded character
                        letters.Add(Convert.ToChar(keystrokes[input[i]]));
                }
                #endregion
                #region Text view
                else // We are decoding to words
                {
                    if (keystrokes[input[i]] == "") // Current byte is encoded
                    {
                        lastBrace = true;
                        switch ((byte)input[i])
                        {
                            case 0x00: letters.Add('['); letters.AddRange(code00); break;
                            case 0x01: letters.Add('['); letters.AddRange(code01); break;
                            case 0x02: letters.Add('['); letters.AddRange(code02); break;
                            case 0x03: letters.Add('['); letters.AddRange(code03); break;
                            case 0x04: letters.Add('['); letters.AddRange(code04); break;
                            case 0x05: letters.Add('['); letters.AddRange(code05); break;
                            case 0x06: letters.Add('['); letters.AddRange(code06); break;
                            case 0x07: letters.Add('['); letters.AddRange(code07); break;
                            case 0x08: letters.AddRange(code08); lastBrace = false; break;
                            case 0x09: letters.AddRange(code09); lastBrace = false; break;
                            case 0x0A: letters.AddRange(code0A); lastBrace = false; break;
                            case 0x0B:
                                i++;
                                for (int a = 0; a < input[i]; a++)
                                    letters.Add(' ');
                                lastBrace = false;
                                break;
                            case 0x0C: letters.Add('['); letters.AddRange(code0C); break;
                            case 0x0D:
                                letters.Add('[');
                                letters.AddRange(code0D);
                                letters.Add(']');
                                letters.Add('[');
                                letters.Add(' ');
                                i++;
                                letters.AddRange(((byte)input[i]).ToString());
                                break;
                            case 0x1A: letters.Add('['); letters.AddRange(code1A); break;
                            case 0x1C:
                                letters.Add('[');
                                letters.AddRange(code1C);
                                letters.Add(']');
                                letters.Add('[');
                                letters.Add(' ');
                                i++;
                                letters.AddRange(((byte)input[i]).ToString());
                                break;
                            case 0x24: letters.Add('['); letters.AddRange(code24); break;
                            case 0x25: letters.Add('['); letters.AddRange(code25); break;
                            case 0x2A: letters.Add('['); letters.AddRange(code2A); break;
                            case 0x2B: letters.Add('['); letters.AddRange(code2B); break;
                            case 0x3B: letters.Add('['); letters.AddRange(code3B); break;
                            case 0x3C: letters.Add('['); letters.AddRange(code3C); break;
                            case 0x3D: letters.Add('['); letters.AddRange(code3D); break;
                            case 0x3E: letters.Add('['); letters.AddRange(code3E); break;
                            case 0x92: letters.Add('['); letters.AddRange(code92); break;
                            case 0x97: letters.Add('['); letters.AddRange(code97); break;
                            case 0x98: letters.Add('['); letters.AddRange(code98); break;
                            case 0x99: letters.Add('['); letters.AddRange(code99); break;
                            default:
                                letters.Add('[');
                                letters.AddRange("ERROR: ");
                                letters.AddRange(((byte)input[i]).ToString());
                                break;
                        }
                        if (lastBrace)
                            letters.Add(']');
                    }
                    else
                        letters.Add(Convert.ToChar(keystrokes[input[i]]));
                }
                #endregion
            }
            return letters.ToArray();
        }
        /// <summary>
        /// Converts an array of symbols which have been decoded for viewing and
        /// editing in a user interface into Mario RPG binary format.
        /// </summary>
        /// <param name="input">The symbols to convert.</param>
        /// <param name="byteView">Indicates whether the unparsed symbols in a formatted string 
        /// should be interpreted as a byte string or a descriptive tag.</param>
        /// <param name="dte">The compression table to use for converting strings to compressed values.</param>
        /// <returns></returns>
        public char[] Encode(char[] input, bool byteView, string[] dte)
        {
            bool openQuote = true;
            List<char> letters = new List<char>();
            char[] backup = input;
            for (int i = 0; i < input.Length; i++)
            {
                // first see if substring of a table
                if (dte != null)
                {
                    bool skip = false;
                    for (int a = 0; a < 12; a++)
                    {
                        if (dte[a].Length > 0 && FindSubstring(input, i, dte[a]))
                        {
                            letters.Add((char)(a + 0x0E));
                            i += dte[a].Length - 1;
                            skip = true;
                            break;
                        }
                    }
                    // if substring found, cancel operation
                    if (skip) continue;
                }
                #region Byte view
                if (byteView)
                {
                    // check for byte characters, multiple spaces, or open quotes
                    if (input[i] == '[' || input[i] == '\x20' || input[i] == '\x22')
                    {
                        switch (input[i])
                        {
                            case '[':
                                if (input[i + 1] != ']') // if character at least 1-digit
                                {
                                    char digitOne = (char)(input[i + 1] - 0x30);
                                    if (input.Length > i + 2 && input[i + 2] != ']') // if character at least 2-digit
                                    {
                                        char digitTwo = (char)(input[i + 2] - 0x30);
                                        if (input.Length > i + 3 && input[i + 3] != ']') // if character at least 3-digit
                                        {
                                            char digitThree = (char)(input[i + 3] - 0x30);
                                            letters.Add((char)((digitOne * 100) + (digitTwo * 10) + digitThree));
                                            i += 4;
                                            break;
                                        }
                                        else // 2 digits
                                        {
                                            letters.Add((char)((digitOne * 10) + digitTwo));
                                            i += 3;
                                            break;
                                        }
                                    }
                                    letters.Add(digitOne);
                                    i += 2;
                                    break;
                                }
                                break; // none
                            case '\x20':
                                if (FindSubstring(input, i, "     ")) // code 0B
                                {
                                    int a = 0;
                                    while (i + a < input.Length && input[i + a] == ' ') a++; //; count spaces
                                    letters.Add('\x0B'); // space encode byte
                                    letters.Add((char)a); // space count
                                    i += a - 1; // allign array
                                    break;
                                }
                                if (FindSubstring(input, i, code0A))
                                {
                                    letters.Add('\x0A');
                                    i += code0A.Length - 1;
                                    break;
                                }
                                if (FindSubstring(input, i, code09))
                                {
                                    letters.Add('\x09');
                                    i += code09.Length - 1;
                                    break;
                                }
                                if (FindSubstring(input, i, code08))
                                {
                                    letters.Add('\x08');
                                    i += code08.Length - 1;
                                    break;
                                }
                                letters.Add('\x20');
                                break;
                            case '\x22':
                                if (openQuote)
                                {
                                    letters.Add('\x22');
                                    openQuote = false;
                                }
                                else
                                {
                                    letters.Add('\x23');
                                    openQuote = true;
                                }
                                break;
                            default: letters.Add('\x20'); break;
                        }
                    }
                    else
                        letters.Add(StringIndex(keystrokes, input[i]));
                }
                #endregion
                #region Text view
                else
                {
                    if (input[i] == '[' || input[i] == '\x20' || input[i] == '\x22')
                    {
                        switch (input[i])
                        {
                            case '[':
                                i++;
                                int length = 0;
                                while (length < input.Length - i && input[i + length] != ']')
                                    length++;
                                char[] code = new char[length];
                                for (int a = 0; a < length; a++)
                                    code[a] = input[i + a];
                                switch (new string(code))
                                {
                                    case code00: letters.Add('\x00'); break;
                                    case code01: letters.Add('\x01'); break;
                                    case code02: letters.Add('\x02'); break;
                                    case code03: letters.Add('\x03'); break;
                                    case code04: letters.Add('\x04'); break;
                                    case code05: letters.Add('\x05'); break;
                                    case code06: letters.Add('\x06'); break;
                                    case code07: letters.Add('\x07'); break;
                                    case code0C: letters.Add('\x0C'); break;
                                    case code0D:
                                        letters.Add('\x0D');
                                        i += length + 1;
                                        if (input[i + 1] == ' ')
                                            i++; // take care of space
                                        if (input[i + 1] != ']') // would make 1
                                        {
                                            char digitOne = (char)(input[i + 1] - 0x30);
                                            if (input.Length > i + 2 && input[i + 2] != ']') // would make 2 digits
                                            {
                                                char digitTwo = (char)(input[i + 2] - 0x30);
                                                if (input.Length > i + 3 && input[i + 3] != ']') // would make 3 digits
                                                {
                                                    char digitThree = (char)(input[i + 3] - 0x30);
                                                    letters.Add((char)((digitOne * 100) + (digitTwo * 10) + digitThree));
                                                    length = 4;
                                                    break;
                                                }
                                                else // 2 digits
                                                {
                                                    letters.Add((char)((digitOne * 10) + digitTwo));
                                                    length = 3;
                                                    break;
                                                }
                                            }
                                            letters.Add((char)(digitOne));
                                            length = 2;
                                            break;
                                        }
                                        break;
                                    case code1A: letters.Add('\x1A'); break;
                                    case code1C:
                                        letters.Add('\x1C');
                                        i += length + 1;
                                        if (input[i + 1] == ' ')
                                            i++; // take care of space
                                        if (input[i + 1] != ']') // would make 1
                                        {
                                            char digitOne = (char)(input[i + 1] - 0x30);
                                            if (input.Length > i + 2 && input[i + 2] != ']') // would make 2 digits
                                            {
                                                char digitTwo = (char)(input[i + 2] - 0x30);
                                                if (input.Length > i + 3 && input[i + 3] != ']') // would make 3 digits
                                                {
                                                    char digitThree = (char)(input[i + 3] - 0x30);
                                                    letters.Add((char)((digitOne * 100) + (digitTwo * 10) + digitThree));
                                                    length = 4;
                                                    break;
                                                }
                                                else // 2 digits
                                                {
                                                    letters.Add((char)((digitOne * 10) + digitTwo));
                                                    length = 3;
                                                    break;
                                                }
                                            }
                                            letters.Add((char)(digitOne));
                                            length = 2;
                                            break;
                                        }
                                        break;
                                    case code24: letters.Add('\x24'); break;
                                    case code25: letters.Add('\x25'); break;
                                    case code2A: letters.Add('\x2A'); break;
                                    case code2B: letters.Add('\x2B'); break;
                                    case code3B: letters.Add('\x3B'); break;
                                    case code3C: letters.Add('\x3C'); break;
                                    case code3D: letters.Add('\x3D'); break;
                                    case code3E: letters.Add('\x3E'); break;
                                    case code92: letters.Add('\x92'); break;
                                    case code97: letters.Add('\x97'); break;
                                    case code98: letters.Add('\x98'); break;
                                    case code99: letters.Add('\x99'); break;
                                    default: break;
                                }
                                i += length;
                                break;
                            case '\x20':
                                if (FindSubstring(input, i, "     ")) // code 0B
                                {
                                    int a = 0;
                                    while (i + a < input.Length && input[i + a] == ' ')
                                        a++;
                                    letters.Add('\x0B');
                                    letters.Add((char)a);
                                    i += a - 1;
                                    break;
                                }
                                if (FindSubstring(input, i, code0A))
                                {
                                    letters.Add('\x0A');
                                    i += code0A.Length - 1;
                                    break;
                                }
                                if (FindSubstring(input, i, code09))
                                {
                                    letters.Add('\x09');
                                    i += code09.Length - 1;
                                    break;
                                }
                                if (FindSubstring(input, i, code08))
                                {
                                    letters.Add('\x08');
                                    i += code08.Length - 1;
                                    break;
                                }
                                letters.Add('\x20');
                                break;
                            case '\x22': // handles user input quotes
                                if (openQuote)
                                {
                                    letters.Add('\x22');
                                    openQuote = false;
                                }
                                else
                                {
                                    letters.Add('\x23');
                                    openQuote = true;
                                }
                                break;
                            default: letters.Add('\x20'); break;
                        }
                    }
                    else
                        letters.Add(StringIndex(keystrokes, input[i]));
                }
                #endregion
            }
            char[] encoded = new char[letters.Count];
            try
            {
                letters.CopyTo(encoded);
            }
            catch
            {
                Error = true;
                return backup;
            }
            if (!VerifyText(encoded))
            {
                Error = true;
                return backup;
            }
            Error = false;
            return encoded;
        }
        
        #endregion
    }
}