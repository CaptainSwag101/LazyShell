using System;
using System.Collections.Generic;
using System.Text;

namespace SMRPGED.ScriptsEditor.Commands
{
    [Serializable()]
    public abstract class EventActionCommand
    {
        protected int offset; public int Offset { get { return this.offset; } set { this.offset = value; } }
        // Used to link up pointers outside of current script
        protected int originalOffset; public int OriginalOffset { get { return this.originalOffset; } set { this.originalOffset = value; } }
        // Used to link up pointers inside of current script
        protected int internalOffset; public int InternalOffset { get { return this.internalOffset; } set { this.internalOffset = value; } }
        // Used for updating internal offsets and pointers
        protected bool pointerChangedA; public bool PointerChangedA { get { return this.pointerChangedA; } set { this.pointerChangedA = value; } }
        protected bool pointerChangedB; public bool PointerChangedB { get { return this.pointerChangedB; } set { this.pointerChangedB = value; } }
        public int CommandDelta { get { return this.offset - originalOffset; } }
        public byte Opcode { get { return GetOpcode(); } set { SetOpcode(value); } }
        public byte Option { get { return GetOption(); } set { SetOption(value); } }
        public abstract ushort ReadPointer();
        public abstract void WritePointer(ushort pointer);
        public abstract ushort ReadPointerSpecial(int index);
        public abstract void WritePointerSpecial(int index, ushort pointer);
        protected abstract byte GetOpcode();
        protected abstract void SetOpcode(byte opcode);
        protected abstract byte GetOption();
        protected abstract void SetOption(byte option);
    }
}
