using System;
using System.Collections.Generic;
using System.Text;

namespace LazyShell.Audio
{
    [Serializable()]
    public abstract class SPC : Element
    {
        public override abstract int Index { get; set; }
        public abstract List<Command>[] Channels { get; set; }
        public abstract bool[] ActiveChannels { get; set; }
        public abstract SampleIndex[] Samples { get; set; }
        public abstract List<Percussive> Percussives { get; set; }
        public abstract byte DelayTime { get; set; }
        public abstract byte DecayFactor { get; set; }
        public abstract byte Echo { get; set; }
        public abstract void WriteToROM();
        public abstract List<Note>[] Notes { get; set; }
        public abstract void CreateNotes();
    }
}
