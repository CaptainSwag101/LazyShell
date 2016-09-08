using System;
using System.Collections.Generic;
using System.Text;

namespace LazyShell.Audio
{
    [Serializable()]
    public class Command : LazyShell.Command
    {
        #region Variables

        /// <summary>
        /// SPC that owns this command.
        /// </summary>
        private SPC spc;

        public ElementType Type
        {
            get
            {
                if (spc is SPCTrack)
                    return ElementType.SPCTrack;
                else
                    return (spc as SPCSound).Type;
            }
        }
        /// <summary>
        /// Channel this command is in.
        /// </summary>
        public int Channel { get; set; }

        // Collection
        public List<Command> Commands
        {
            get { return spc.Channels[Channel]; }
            set { spc.Channels[Channel] = value; }
        }
        /// <summary>
        /// Returns the index of this command in its command list.
        /// </summary>
        public int Index
        {
            get { return this.Commands.IndexOf(this); }
        }
        public Command PrevSibling
        {
            get
            {
                if (Index > 0)
                    return Commands[Index - 1];
                return null;
            }
        }
        public Command NextSibling
        {
            get
            {
                if (Index < Commands.Count)
                    return Commands[Index + 1];
                return null;
            }
        }

        /// <summary>
        /// Creates a note out of this command.
        /// </summary>
        public Note Note
        {
            get { return new Note(this); }
        }

        #endregion

        // Constructor
        public Command(byte[] data, SPC spc, int channel)
        {
            this.spc = spc;
            this.Data = data;
            this.Channel = channel;
        }

        #region Methods

        /// <summary>
        /// Creates a deep copy of this instance.
        /// </summary>
        /// <returns></returns>
        public Command Copy()
        {
            return new Command(Bits.Copy(Data), this.spc, this.Channel);
        }

        // Override
        public override string ToString()
        {
            return Parser.ParseCommand(this);
        }

        #endregion
    }
}
