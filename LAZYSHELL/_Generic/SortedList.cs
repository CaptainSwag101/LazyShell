using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using LazyShell.Properties;

namespace LazyShell
{
    /// <summary>
    /// Class for managing a sorted list based on element names in the Mario RPG Rom.
    /// </summary>
    [Serializable()]
    public class SortedList
    {
        #region Variables

        /// <summary>
        /// The string array of element names generated from the element associated with this instance.
        /// Sorted status is based on prior calls to the SortAlphabetically and SortNumerically functions.
        /// </summary>
        public string[] Names { get; set; }
        private object[] elementCollection;
        /// <summary>
        /// The unsorted collection of names.
        /// </summary>
        private int[] unsorted;
        private bool IsSortedAlphabetically
        {
            get
            {
                int index = 0;
                if (elementCollection is Items.Item[])
                    index = 1;
                for (int i = 0; i < Names.Length - 1; i++)
                {
                    if (Names[i].Substring(index).CompareTo(Names[i + 1].Substring(index)) > 0)
                        return false;
                }
                return true;
            }
        }
        private bool IsSortedNumerically
        {
            get
            {
                for (int i = 0; i < unsorted.Length - 1; i++)
                    if (unsorted[i] > unsorted[i + 1])
                        return false;
                return true;
            }
        }

        #endregion

        /// <summary>
        /// Class for managing a sorted list based on element names in the Mario RPG Rom.
        /// </summary>
        /// <param name="elementCollection">The collection of elements to analyze in the creation of this instance's list.
        /// All instances must already be initialized and the properties loaded from the ROM buffer.</param>
        public SortedList(object[] elementCollection)
        {
            this.elementCollection = elementCollection;
            if (elementCollection is Monsters.Monster[])
            {
                var monsters = elementCollection as Monsters.Monster[];
                Names = new string[monsters.Length];
                unsorted = new int[monsters.Length];
                for (int i = 0; i < monsters.Length; i++)
                {
                    Names[i] = new string(monsters[i].Name);
                    unsorted[i] = i;
                }
            }
            else if (elementCollection is Magic.Spell[])
            {
                var spells = elementCollection as Magic.Spell[];
                Names = new string[spells.Length];
                unsorted = new int[spells.Length];
                for (int i = 0; i < spells.Length; i++)
                {
                    Names[i] = new string(spells[i].Name);
                    unsorted[i] = i;
                }
            }
            else if (elementCollection is Attacks.Attack[])
            {
                var attacks = elementCollection as Attacks.Attack[];
                Names = new string[attacks.Length];
                unsorted = new int[attacks.Length];
                for (int i = 0; i < attacks.Length; i++)
                {
                    Names[i] = new string(attacks[i].Name);
                    unsorted[i] = i;
                }
            }
            else if (elementCollection is Items.Item[])
            {
                var items = elementCollection as Items.Item[];
                Names = new string[items.Length];
                unsorted = new int[items.Length];
                for (int i = 0; i < items.Length; i++)
                {
                    Names[i] = new string(items[i].Name);
                    unsorted[i] = i;
                }
            }
        }

        #region Methods

        #region Get index / name

        /// <summary>
        /// Get the sorted index of an item in an alphabetically sorted name list.
        /// </summary>
        /// <param name="index">The unsorted index of the item</param>
        /// <returns></returns>
        public int GetSortedIndex(int index)
        {
            if (!IsSortedAlphabetically)
                SortAlphabetically();
            for (int i = 0; i < Names.Length; i++)
            {
                if (unsorted[i] == index)
                    return i;
            }
            return 0;
        }
        /// <summary>
        /// Get the unsorted index of an item in an alphabetically sorted name list.
        /// </summary>
        /// <param name="index">The sorted index of the item.</param>
        /// <returns></returns>
        public int GetUnsortedIndex(int index)
        {
            if (!IsSortedAlphabetically)
                SortAlphabetically();
            if (index < unsorted.Length)
                return unsorted[index];
            return 0;
        }
        /// <summary>
        /// Returns the name in the unsorted list.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetUnsortedName(int index)
        {
            for (int i = 0; i < unsorted.Length; i++)
                if (index == unsorted[i])
                    return Names[i];
            return "";
        }
        public string GetUnsortedName(int index, string[] keystrokes)
        {
            string name = GetUnsortedName(index);
            return Do.RawToASCII(name.ToCharArray(), keystrokes);
        }
        public string GetUnsortedNameSubstring(int index, int startIndex)
        {
            string name = GetUnsortedName(index);
            return name.Substring(startIndex);
        }
        public void SetName(int index, string name)
        {
            for (int i = 0; i < Names.Length; i++)
                if (index == unsorted[i])
                    Names[i] = name;
        }

        #endregion

        #region Numerize

        public string NumerizeUnsorted(int index)
        {
            return NumerizeUnsorted(index, 0);
        }
        /// <summary>
        /// Returns the name tagged with {index} based on its unsorted index.
        /// </summary>
        /// <param name="index">The unsorted index of the name.</param>
        /// <returns></returns>
        public string NumerizeUnsorted(int index, int substringIndex)
        {
            int length = (Names.Length - 1).ToString().Length;
            string name = GetUnsortedName(index).Substring(substringIndex).Trim(new char[] { ' ', '\0' });
            return "{" + index.ToString("d" + length) + "}  " + name;
        }
        public string NumerizeUnsorted(int index, string[] keystrokes)
        {
            return NumerizeUnsorted(index, 0, keystrokes);
        }
        public string NumerizeUnsorted(int index, int substringIndex, string[] keystrokes)
        {
            int length = (Names.Length - 1).ToString().Length;
            string name = GetUnsortedName(index).Substring(substringIndex).Trim(new char[] { ' ', '\0' });
            return "{" + index.ToString("d" + length) + "}  " + Do.RawToASCII(name.ToCharArray(), keystrokes);
        }
        public string NumerizeSorted(int index)
        {
            return NumerizeSorted(index, 0);
        }
        /// <summary>
        /// Returns the name tagged with {index} based on its sorted index.
        /// </summary>
        /// <param name="index">The sorted index of the name.</param>
        /// <returns></returns>
        public string NumerizeSorted(int index, int substringIndex)
        {
            int length = (Names.Length - 1).ToString().Length;
            string name = Names[index].Substring(substringIndex).Trim(new char[] { ' ', '\0' });
            return "{" + index.ToString("d" + length) + "}  " + name;
        }

        #endregion

        /// <summary>
        /// Sorts the elements in the Names property alphabetically.
        /// </summary>
        public void SortAlphabetically()
        {
            if (IsSortedAlphabetically)
                return;
            int startIndex = 0;
            if (elementCollection is Items.Item[])
                startIndex = 1;
            string name;
            int index;
            int length = Names.Length;
            for (int a = 0; a < length - 1; a++)
            {
                for (int b = 0; b < length - 1 - a; b++)
                {
                    if (Names[b + 1].Substring(startIndex).CompareTo(Names[b].Substring(startIndex)) < 0)
                    {
                        name = Names[b];
                        Names[b] = Names[b + 1];
                        Names[b + 1] = name;
                        //
                        index = unsorted[b];
                        unsorted[b] = unsorted[b + 1];
                        unsorted[b + 1] = index;
                    }
                }
            }
        }
        /// <summary>
        /// Sorts the elements in the Names property numerically.
        /// </summary>
        public void SortNumerically()
        {
            string name;
            int index;
            int length = Names.Length;
            for (int a = 0; a < length - 1; a++)
            {
                for (int b = 0; b < length - 1 - a; b++)
                {
                    if (unsorted[b + 1] > unsorted[b])
                    {
                        index = unsorted[b];
                        unsorted[b] = unsorted[b + 1];
                        unsorted[b + 1] = index;
                        //
                        name = Names[b];
                        Names[b] = Names[b + 1];
                        Names[b + 1] = name;
                    }
                }
            }
        }

        #endregion
    }
}
