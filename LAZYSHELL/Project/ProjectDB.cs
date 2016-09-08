using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LazyShell
{
    [Serializable()]
    public class ProjectDB
    {
        #region Variables

        // Project information
        public string Title { get; set; }
        public string Author { get; set; }
        public string Date { get; set; }
        public string Webpage { get; set; }
        public string Description { get; set; }
        public string OtherInfo { get; set; }

        // Element notes
        public List<EIndex> ActionScripts { get; set; }
        public List<EIndex> Attacks { get; set; }
        public List<EIndex> Battlefields { get; set; }
        public List<EIndex> Dialogues { get; set; }
        public List<EIndex> Effects { get; set; }
        public List<EIndex> EventScripts { get; set; }
        public List<EIndex> Formations { get; set; }
        public List<EIndex> Items { get; set; }
        public List<EIndex> Areas { get; set; }
        public List<EIndex> MemoryBits { get; set; }
        public List<EIndex> Monsters { get; set; }
        public List<EIndex> Packs { get; set; }
        public List<EIndex> Shops { get; set; }
        public List<EIndex> Spells { get; set; }
        public List<EIndex> Sprites { get; set; }

        // Element lists
        public List<EList> ELists { get; set; }

        // Keystrokes
        public string[] Keystrokes { get; set; }
        public string[] KeystrokesMenu { get; set; }
        public string[] KeystrokesDesc { get; set; }

        #endregion

        // Constructor
        public ProjectDB()
        {
            InitializeProperties();
        }

        #region Methods

        private void InitializeProperties()
        {
            // project information
            Title = "";
            Author = "";
            Date = "";
            Webpage = "";
            Description = "";
            OtherInfo = "";
            // element notes
            ActionScripts = new List<EIndex>();
            Attacks = new List<EIndex>();
            Battlefields = new List<EIndex>();
            Dialogues = new List<EIndex>();
            Effects = new List<EIndex>();
            EventScripts = new List<EIndex>();
            Formations = new List<EIndex>();
            Items = new List<EIndex>();
            Areas = new List<EIndex>();
            MemoryBits = new List<EIndex>();
            Monsters = new List<EIndex>();
            Packs = new List<EIndex>();
            Shops = new List<EIndex>();
            Spells = new List<EIndex>();
            Sprites = new List<EIndex>();
            // element lists
            ELists = new List<EList>();
            foreach (EList elist in Model.ELists)
                ELists.Add(elist.Copy());
            //
            Keystrokes = Model.Keystrokes;
            KeystrokesMenu = Model.KeystrokesMenu;
            KeystrokesDesc = Model.KeystrokesDesc;
        }

        // Collection modification
        public void AddIndex(int index, List<EIndex> arrayList)
        {
            arrayList.Insert(index, new EIndex());
        }
        public void DeleteIndex(int index, List<EIndex> arrayList)
        {
            arrayList.RemoveAt(index);
        }
        public void SwitchIndex(int index, List<EIndex> arrayList)
        {
            arrayList.Reverse(index, 2);
        }

        #endregion
    }
    [Serializable()]
    public class EIndex
    {
        #region Variables

        public int Index { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public int Address { get; set; }
        public int AddressBit { get; set; }

        #endregion

        // Constructors
        public EIndex()
        {
            this.Index = 0;
            this.Label = "(no label)";
            this.Description = "(no description)";
            this.Address = 0x7000;
            this.AddressBit = 0;
        }
        public EIndex(string label, int index)
        {
            this.Index = index;
            this.Label = label;
            this.Description = "(no description)";
            this.Address = 0x7000;
            this.AddressBit = 0;
        }
        public EIndex(NotesDB.Index index)
        {
            this.Index = index.IndexNumber;
            this.Label = index.IndexLabel;
            this.Description = index.IndexDescription;
            this.Address = index.Address;
            this.AddressBit = index.AddressBit;
        }

        // Methods
        public override string ToString()
        {
            return Label;
        }
    }

    /// <summary>
    /// Class for managing a list of labels for an element in the Mario RPG ROM.
    /// </summary>
    [Serializable()]
    public class EList
    {
        #region Variables

        public string Name { get; set; }
        public string[] Labels
        {
            get
            {
                string[] labels = new string[Indexes.Length];
                for (int i = 0; i < labels.Length; i++)
                    labels[i] = Indexes[i].Label;
                return labels;
            }
        }
        public EIndex[] Indexes { get; set; }

        #endregion

        // Constructor
        public EList(string name, string[] labels)
        {
            Name = name;
            Indexes = new EIndex[labels.Length];
            for (int i = 0; i < labels.Length; i++)
                Indexes[i] = new EIndex(labels[i], i);
        }

        #region Methods

        public EList Copy()
        {
            return new EList(Name, Lists.Copy(Labels));
        }
        public void Reset()
        {
            EList source = Model.ELists.Find(delegate(EList list)
            {
                return list.Name == Name;
            });
            if (source == null)
                return;
            for (int i = 0; i < source.Indexes.Length && i < Indexes.Length; i++)
            {
                Indexes[i].Address = source.Indexes[i].Address;
                Indexes[i].AddressBit = source.Indexes[i].AddressBit;
                Indexes[i].Description = source.Indexes[i].Description;
                Indexes[i].Label = source.Indexes[i].Label;
                Indexes[i].Index = source.Indexes[i].Index;
            }
        }
        public override string ToString()
        {
            return Name;
        }

        #endregion
    }
}
