using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using LAZYSHELL.Properties;

namespace LAZYSHELL.Dialogues
{
    /// <summary>
    /// Class for encoding and decoding text used in menus and battle dialogues.
    /// </summary>
    [Serializable()]
    public sealed class ParserReduced : Parser
    {
        #region Variables

        // Instance
        private static readonly object padlock = new object();
        private static ParserReduced instance = null;
        public static ParserReduced Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                        instance = new ParserReduced();
                    return instance;
                }
            }
        }

        private Settings settings = Settings.Default;

        #region Description tags

        private const string code02 = "pauseInput";
        private const string code03 = "delayInput";
        private const string code0C = "delay";

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
        /// <param name="textType">The type of text to decode. 0 = battle dialogue, 1 = item/spell description.</param>
        /// <param name="keystrokes">The keystroke table to use in the operation.</param>
        /// <returns></returns>
        public char[] Decode(char[] input, bool byteView, int textType, string[] keystrokes)
        {
            int count = keystrokes.Length - 1;
            List<char> output = new List<char>();
            bool lastBrace = true;
            for (int i = 0; i < input.Length; i++) // For every character of text
            {
                // skip if out of bounds
                if (input[i] >= keystrokes.Length)
                    continue;
                if (byteView) // We are decoding to numbers
                {
                    if (keystrokes[input[i]] == "") // Is encoded character
                    {
                        switch ((byte)input[i])
                        {
                            case 0x1C:
                                output.Add('[');
                                output.AddRange(((byte)input[i]).ToString());
                                output.Add(']');
                                if (input.Length > i + 1)
                                {
                                    i++;
                                    goto default;
                                }
                                break;
                            default:
                                output.Add('[');
                                output.AddRange(((byte)input[i]).ToString());
                                output.Add(']');
                                break;
                        }
                    }
                    else // Not encoded character
                        output.Add(Convert.ToChar(keystrokes[input[i]]));
                }
                else // We are decoding to words
                {
                    if (keystrokes[input[i]] == "") // Current byte is encoded
                    {
                        lastBrace = true;
                        switch ((byte)input[i])
                        {
                            case 0x00: output.Add('['); output.AddRange(code00); break;
                            case 0x01: output.Add('['); output.AddRange(code01); break;
                            case 0x02: output.Add('['); output.AddRange(code02); break;
                            case 0x03: output.Add('['); output.AddRange(code03); break;
                            case 0x0C: output.Add('['); output.AddRange(code0C); break;
                            case 0x24: output.Add('['); output.AddRange(code24); break;
                            case 0x25: output.Add('['); output.AddRange(code25); break;
                            case 0x2A: output.Add('['); output.AddRange(code2A); break;
                            case 0x2B: output.Add('['); output.AddRange(code2B); break;
                            case 0x3B: output.Add('['); output.AddRange(code3B); break;
                            case 0x3C: output.Add('['); output.AddRange(code3C); break;
                            case 0x3D: output.Add('['); output.AddRange(code3D); break;
                            case 0x3E: output.Add('['); output.AddRange(code3E); break;
                            case 0x92: output.Add('['); output.AddRange(code92); break;
                            case 0x97: output.Add('['); output.AddRange(code97); break;
                            case 0x98: output.Add('['); output.AddRange(code98); break;
                            case 0x99: output.Add('['); output.AddRange(code99); break;
                            default:
                                output.Add('[');
                                output.AddRange("ERROR: ");
                                output.AddRange(((byte)input[i]).ToString());
                                break;
                        }
                        if (lastBrace)
                            output.Add(']');
                    }
                    else
                        output.Add(Convert.ToChar(keystrokes[input[i]]));
                }
            }
            return output.ToArray();
        }
        /// <summary>
        /// Converts an array of symbols which have been decoded for viewing and
        /// editing in a user interface into Mario RPG binary format.
        /// </summary>
        /// <param name="input">The symbols to convert.</param>
        /// <param name="byteView">Indicates whether the unparsed symbols in a formatted string 
        /// should be interpreted as a byte string or a descriptive tag.</param>
        /// <param name="textType">The type of text to encode. 0 = battle dialogue, 1 = item/spell description.</param>
        /// <param name="keystrokes">The keystroke table to use in the operation.</param>
        /// <returns></returns>
        public char[] Encode(char[] input, bool byteView, int textType, string[] keystrokes)
        {
            char[] backup = input;
            bool openQuote = true;
            List<char> output = new List<char>();
            for (int i = 0; i < input.Length; i++)
            {
                if (byteView)
                {
                    if (input[i] == '[' ||
                        input[i] == '\x20' ||
                        input[i] == '\x22' ||
                        input[i] == '\x2D' ||
                        input[i] == '\x27')
                    {
                        switch (input[i])
                        {
                            case '[':
                                if (input.Length > i + 1)
                                {
                                    if (input[i + 1] != ']') // would make 1
                                    {
                                        char digitOne = (char)(input[i + 1] - 0x30);
                                        if (input.Length > i + 2 && input[i + 2] != ']') // would make 2 digits
                                        {
                                            char digitTwo = (char)(input[i + 2] - 0x30);
                                            if (input.Length > i + 3 && input[i + 3] != ']') // would make 3 digits
                                            {
                                                char digitThree = (char)(input[i + 3] - 0x30);
                                                output.Add((char)((digitOne * 100) + (digitTwo * 10) + digitThree));
                                                i += 4;
                                                break;
                                            }
                                            else // 2 digits
                                            {
                                                output.Add((char)((digitOne * 10) + digitTwo));
                                                i += 3;
                                                break;
                                            }
                                        }
                                        output.Add((char)(digitOne));
                                        i += 2;
                                        break;
                                    }
                                    break; // none
                                }
                                break;
                            case '\x2D':
                                if (textType == 0)      // Battle Dialogue
                                    output.Add('\x2D');
                                else if (textType == 1) // Item/Spell Desc.
                                    output.Add('\x7D');
                                break;
                            case '\x27':
                                if (textType == 0)      // Battle Dialogue
                                    output.Add('\x9B');
                                else if (textType == 1) // Item/Spell Desc.
                                    output.Add('\x7E');
                                break;
                            case '\x22':
                                if (openQuote)
                                {
                                    output.Add('\x22');
                                    openQuote = false;
                                }
                                else
                                {
                                    output.Add('\x23');
                                    openQuote = true;
                                }
                                break;
                            default: output.Add('\x20'); break;
                        }
                    }
                    else
                    {
                        if (textType == 0)      // Battle Dialogue
                            output.Add(StringIndex(Lists.Keystrokes, input[i]));
                        else if (textType == 1) // Item/Spell Desc.
                            output.Add(StringIndex(Lists.KeystrokesDesc, input[i]));
                    }
                }
                else
                {
                    if (input[i] == '[' ||
                        input[i] == '\x22' ||
                        input[i] == '\x2D' ||
                        input[i] == '\x27')
                    {
                        switch (input[i])
                        {
                            case '[':
                                i++;
                                int length = 0;
                                while (length < input.Length - i && input[i + length] != ']')
                                    length++;
                                char[] code = new char[length];
                                for (int z = 0; z < length; z++)
                                    code[z] = input[i + z];
                                switch (new string(code))
                                {
                                    case code00: output.Add('\x00'); break;
                                    case code01: output.Add('\x01'); break;
                                    case code02: output.Add('\x02'); break;
                                    case code03: output.Add('\x03'); break;
                                    case code0C: output.Add('\x0C'); break;
                                    case code24: output.Add('\x24'); break;
                                    case code25: output.Add('\x25'); break;
                                    case code2A: output.Add('\x2A'); break;
                                    case code2B: output.Add('\x2B'); break;
                                    case code3B: output.Add('\x3B'); break;
                                    case code3C: output.Add('\x3C'); break;
                                    case code3D: output.Add('\x3D'); break;
                                    case code3E: output.Add('\x3E'); break;
                                    case code92: output.Add('\x92'); break;
                                    case code97: output.Add('\x97'); break;
                                    case code98: output.Add('\x98'); break;
                                    case code99: output.Add('\x99'); break;
                                    default: break;
                                }
                                i += length;
                                break;
                            case '\x2D':
                                if (textType == 0)      // Battle Dialogue
                                    output.Add('\x2D');
                                else if (textType == 1) // Item/Spell Desc.
                                    output.Add('\x7D');
                                break;
                            case '\x27':
                                if (textType == 0)      // Battle Dialogue
                                    output.Add('\x9B');
                                else if (textType == 1) // Item/Spell Desc.
                                    output.Add('\x7E');
                                break;
                            case '\x22': // handles user input quotes
                                if (openQuote)
                                {
                                    output.Add('\x22');
                                    openQuote = false;
                                }
                                else
                                {
                                    output.Add('\x23');
                                    openQuote = true;
                                }
                                break;
                            default: output.Add('\x20'); break;
                        }
                    }
                    else
                        output.Add(StringIndex(keystrokes, input[i]));
                }
            }
            char[] encoded = new char[output.Count];
            try
            {
                output.CopyTo(encoded);
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
