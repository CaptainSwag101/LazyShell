using System;
using System.Collections.Generic;
using System.Text;

namespace LazyShell
{
    [Serializable()]
    public abstract class Command
    {
        #region Variables

        // ROM buffer
        public byte[] ROM
        {
            get { return Model.ROM; }
            set { Model.ROM = value; }
        }
        /// <summary>
        /// This command's binary data.
        /// </summary>
        public byte[] Data { get; set; }
        /// <summary>
        /// Total length of the command's binary data.
        /// </summary>
        public int Length
        {
            get { return Data.Length; }
        }

        // Offsets
        public int Offset { get; set; }
        /// <summary>
        /// Used to link up pointers outside of current script.
        /// </summary>
        public int OriginalOffset { get; set; }
        /// <summary>
        /// Used to link up pointers inside of current script
        /// </summary>
        public int InternalOffset { get; set; }
        /// <summary>
        /// Used for updating internal offsets and pointers.
        /// </summary>
        public bool[] PointerChanged { get; set; }

        /// <summary>
        /// Difference between offset and original offset.
        /// </summary>
        public int Delta
        {
            get { return this.Offset - OriginalOffset; }
        }
        /// <summary>
        /// Indicates whether this command has be previously modified for
        /// using the correct color for the node's text.
        /// </summary>
        public bool Modified { get; set; }

        // Parameters
        public byte Opcode
        {
            get
            {
                if (this.Data.Length > 0)
                    return this.Data[0];
                else
                    return 0;
            }
            set
            {
                if (this.Data != null && this.Data.Length > 0) 
                    this.Data[0] = value;
            }
        }
        public byte Param1
        {
            get
            {
                if (this.Data.Length > 1)
                    return this.Data[1];
                else
                    return 0;
            }
            set
            {
                if (this.Data != null && this.Data.Length > 1)
                    this.Data[1] = value;
            }
        }
        public byte Param2
        {
            get
            {
                if (this.Data.Length > 2)
                    return this.Data[2];
                else
                    return 0;
            }
            set
            {
                if (this.Data != null && this.Data.Length > 2)
                    this.Data[2] = value;
            }
        }
        public byte Param3
        {
            get
            {
                if (this.Data.Length > 3)
                    return this.Data[3];
                else
                    return 0;
            }
            set
            {
                if (this.Data != null && this.Data.Length > 3)
                    this.Data[3] = value;
            }
        }
        public byte Param4
        {
            get
            {
                if (this.Data.Length > 4)
                    return this.Data[4];
                else
                    return 0;
            }
            set
            {
                if (this.Data != null && this.Data.Length > 4)
                    this.Data[4] = value;
            }
        }
        public byte Param5
        {
            get
            {
                if (this.Data.Length > 5)
                    return this.Data[5];
                else
                    return 0;
            }
            set
            {
                if (this.Data != null && this.Data.Length > 5)
                    this.Data[5] = value;
            }
        }
        public byte Param6
        {
            get
            {
                if (this.Data.Length > 6)
                    return this.Data[6];
                else
                    return 0;
            }
            set
            {
                if (this.Data != null && this.Data.Length > 6)
                    this.Data[6] = value;
            }
        }

        #endregion
    }
}
