using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL.ScriptsEditor.Commands
{
    public class AnimationScriptCommand
    {
        private byte[] data;
        private byte[] animationData; public byte[] AnimationData { get { return this.animationData; } set { this.animationData = value; } }
        public byte Opcode
        {
            get
            {
                if (this.animationData.Length > 0)
                    return this.animationData[0];
                else
                    return 0;
            }
            set { this.animationData[0] = value; }
        }
        public byte Option
        {
            get
            {
                if (this.animationData.Length > 0)
                    return this.animationData[1];
                else
                    return 0;
            }
            set { this.animationData[1] = value; }
        }

        protected int offset; public int Offset { get { return this.offset; } set { this.offset = value; } }
        // Used to link up pointers outside of current script
        protected int originalOffset; public int OriginalOffset { get { return this.originalOffset; } set { this.originalOffset = value; } }
        // Used to link up pointers inside of current script
        protected int internalOffset; public int InternalOffset { get { return this.internalOffset; } set { this.internalOffset = value; } }
        // Used for updating internal offsets and pointers

        private ArrayList commands = new ArrayList(); public ArrayList Commands { get { return this.commands; } set { this.commands = value; } }

        private AnimationScript animationScript;
        private AnimationScriptCommand parent; public AnimationScriptCommand Parent { get { return parent; } }

        public AnimationScriptCommand(byte[] data, byte[] animationData, int offset, AnimationScript animationScript, AnimationScriptCommand asc)
        {
            this.data = data;
            this.animationData = animationData;
            this.parent = asc;
            this.offset = offset;
            this.originalOffset = offset;
            this.internalOffset = offset;

            this.animationScript = animationScript;     // for reading the "memory" variable

            int search = 0;
            switch (Opcode)
            {
                case 0xA3:
                    //System.Windows.Forms.MessageBox.Show(
                    //    "Animation #" + animationScript.AnimationNum + 
                    //    ", type " + animationScript.Type + 
                    //    "\n\nvalue = 0x" + Option.ToString("d3"));
                    break;
                case 0x09:
                    search = (offset & 0xFF0000) + Bits.GetShort(animationData, 1);
                    if (parent == null && !SearchForOffset(animationScript, search))
                        InitializeAnimationScript((offset & 0xFF0000) + Bits.GetShort(animationData, 1));
                    else if (parent != null && !parent.SearchForOffset(parent, search))
                        InitializeAnimationScript((offset & 0xFF0000) + Bits.GetShort(animationData, 1));
                    break;
                case 0x10:
                case 0x64:
                case 0x68:
                    if (offset == 0x3562C8 ||
                        offset == 0x3564FC)
                        animationScript.AMem = 0;
                    if ((offset & 0xFF0000) == 0x350000 && Bits.GetShort(animationData, 1) == 0x8499)
                        animationScript.AMem = 0;
                    if (offset == 0x3AA5EE)
                        animationScript.AMem = 12; // it's the only one that has enough pointers
                    InitializeAnimationScript((offset & 0xFF0000) + Bits.GetShort(animationData, 1));
                    break;
                case 0x5D:
                    InitializeAnimationScript((offset & 0xFF0000) + Bits.GetShort(animationData, 3));
                    break;

                case 0x20:
                case 0x21: if ((Option & 0x0F) == 0) animationScript.AMem = animationData[2]; break;
                case 0x2C:
                case 0x2D: if ((Option & 0x0F) == 0) animationScript.AMem += animationData[2]; break;
                case 0x2E:
                case 0x2F: if ((Option & 0x0F) == 0) animationScript.AMem -= animationData[2]; break;
                case 0x30:
                case 0x31: if ((Option & 0x0F) == 0) animationScript.AMem++; break;
                case 0x32:
                case 0x33: if ((Option & 0x0F) == 0) animationScript.AMem--; break;
                case 0x34:
                case 0x35: if ((Option & 0x0F) == 0) animationScript.AMem = 0; break;
                case 0x6A:
                case 0x6B: if ((Option & 0x0F) == 0) animationScript.AMem = (byte)(animationData[2] - 1); break;
                default:
                    if (Opcode >= 0x24 && Opcode <= 0x2B)
                    {
                        search = (offset & 0xFF0000) + Bits.GetShort(animationData, 4);
                        if (parent == null && !SearchForOffset(animationScript, search))
                            InitializeAnimationScript((offset & 0xFF0000) + Bits.GetShort(animationData, 4));
                        else if (parent != null && !parent.SearchForOffset(parent, search))
                            InitializeAnimationScript((offset & 0xFF0000) + Bits.GetShort(animationData, 4));
                    }
                    break;
            }
        }
        private void InitializeAnimationScript(int offset)
        {
            int len = 0;
            AnimationScriptCommand temp;

            switch (Opcode)
            {
                case 0x09:
                    while ((offset & 0xFFFF) < 0xFFFF)
                    {
                        // these are unusual cases, seems this is the only way
                        if (offset == 0x356076) break;
                        if (offset == 0x356087) break;
                        if (offset == 0x3560A9) break;
                        if (offset == 0x3560CD) break;
                        if (offset == 0x3560FE) break;
                        if (offset == 0x356131) break;
                        if (offset == 0x356152) break;
                        if (offset == 0x35617A) break;
                        if (offset == 0x3561AD) break;
                        if (offset == 0x3561E0) break;
                        if (offset == 0x356213) break;
                        if (offset == 0x35624B) break;
                        if (offset == 0x3A8A68) break;
                        if (offset == 0x3A8AC0) break;
                        if (offset == 0x3A8C8A) break;
                        if ((offset & 0xFF0000) == 0x3A0000 && offset < 0x3A60D0)
                            break;

                        len = GetAnimationOpcodeLength(data, offset);
                        temp = new AnimationScriptCommand(data, Bits.GetByteArray(data, offset, len), offset, animationScript, this);
                        commands.Add(temp);

                        if (data[offset] == 0x07 || // end animation packet
                            data[offset] == 0x09 || // jump directly to address (thus ending this)
                            data[offset] == 0x11 || // end subroutine
                            data[offset] == 0x5E)   // end sprite subroutine
                            break;

                        offset += len;
                    }
                    break;
                case 0x10: goto case 0x09;
                case 0x5D: goto case 0x09;
                case 0x64:
                    if (animationScript.AMem > 0x10)
                    {
                        //System.Windows.Forms.MessageBox.Show(animationScript.AMem.ToString("d3"));
                        animationScript.AMem = 0;
                        offset = (offset & 0xFF0000) + Bits.GetShort(data, offset);
                    }
                    else
                        offset = (offset & 0xFF0000) + Bits.GetShort(data, offset + (animationScript.AMem * 2));
                    goto case 0x09;
                case 0x68:
                    if (animationScript.AMem >= 0x40)
                    {
                        //System.Windows.Forms.MessageBox.Show(animationScript.Memory.ToString("d3"));
                        animationScript.AMem = 0;
                        offset = (offset & 0xFF0000) + Bits.GetShort(data, offset);
                    }
                    else
                        offset = (offset & 0xFF0000) + Bits.GetShort(data, offset + (animationScript.AMem * 2));
                    if (offset == 0x356919 ||
                        offset == 0x356969)
                        offset += 2;
                    else
                        offset = (offset & 0xFF0000) + Bits.GetShort(data, offset + animationData[3]);
                    goto case 0x09;
                default:
                    if (Opcode >= 0x24 && Opcode <= 0x2B)
                    {
                        offset = (offset & 0xFF0000) + Bits.GetShort(animationData, 4);
                        goto case 0x09;
                    }
                    break;
            }
        }
        public int GetAnimationOpcodeLength(byte[] data, int offset)
        {
            byte opcode, option;
            int len;

            opcode = data[offset];
            if (data.Length - offset > 1)
                option = data[offset + 1];
            else
                option = 0;

            len = A_ScriptEnums.GetAnimationOpcodeLength(opcode, option);

            return len;
        }
        public bool SearchForOffset(AnimationScriptCommand par, int offset)
        {
            bool found = false;
            foreach (AnimationScriptCommand asc in par.Commands)
            {
                if (asc.InternalOffset == offset)
                    return true;
            }
            if (par.Parent != null)
                found = SearchForOffset(par.Parent, offset);
            return found;
        }
        public bool SearchForOffset(AnimationScript script, int offset)
        {
            bool found = false;
            foreach (AnimationScriptCommand asc in script.Commands)
            {
                if (asc.InternalOffset == offset)
                    return true;
            }
            return found;
        }
        public void Modify(AnimationScriptCommand asc)
        {
            AnimationScriptCommand cmd;
            for (int i = 0; i < this.commands.Count; i++)
            {
                cmd = (AnimationScriptCommand)this.commands[i];
                if (asc.InternalOffset == cmd.InternalOffset)
                {
                    byte[] temp = new byte[asc.AnimationData.Length];
                    asc.AnimationData.CopyTo(temp, 0);
                    cmd = new AnimationScriptCommand(data, temp, asc.Offset, this.animationScript, this);
                }
                cmd.Modify(asc);
            }
        }
        public override string ToString()
        {
            return Interpreter.Instance.InterpretAnimationCommand(this);
        }
    }
}
