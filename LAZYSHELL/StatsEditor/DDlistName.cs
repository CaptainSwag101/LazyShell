using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using LAZYSHELL.StatsEditor.Stats;
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
    public class DDlistName
    {
        public string[] names;
        public int[] nums;
        private object[] obj;

        public DDlistName(object[] obj)
        {
            this.obj = obj;
            Type t = obj.GetType();

            if (t == typeof(Monster[]))
            {
                Monster[] monsters = (Monster[])obj;
                names = new string[monsters.Length];
                nums = new int[monsters.Length];

                for (int i = 0; i < monsters.Length; i++)
                {
                    names[i] = new string(monsters[i].Name);
                    nums[i] = monsters[i].MonsterNum;
                }
            }
            else if (t == typeof(Spell[]))
            {
                Spell[] spells = (Spell[])obj;
                names = new string[spells.Length];
                nums = new int[spells.Length];

                for (int i = 0; i < spells.Length; i++)
                {
                    names[i] = new string(spells[i].Name);
                    nums[i] = spells[i].SpellNum;
                }
            }
            else if (t == typeof(Attack[]))
            {
                Attack[] attacks = (Attack[])obj;
                names = new string[attacks.Length];
                nums = new int[attacks.Length];

                for (int i = 0; i < attacks.Length; i++)
                {
                    names[i] = new string(attacks[i].Name);
                    nums[i] = attacks[i].AttackNum;
                }
            }
            else if (t == typeof(Item[]))
            {
                Item[] items = (Item[])obj;
                names = new string[items.Length];
                nums = new int[items.Length];

                for (int i = 0; i < items.Length; i++)
                {
                    names[i] = new string(items[i].Name);
                    nums[i] = items[i].ItemNum;
                }
            }
        }

        public string[] GetNames() { return names; }
        public string[] Names { get { return this.names; } }
        public int[] GetNums() { return nums; }
        public int GetNum(int index) { return nums[index]; }
        public string GetName(int index) { return names[index]; }

        public void SetName(string value, int index) { names[index] = value; }
        public void SetNames(string[] value) { names = value; }

        public string GetNameByNum(int num)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (num == nums[i])
                {
                    return names[i];
                }
            }
            return null;
        }

        public void SortAlpha()
        {
            if (IsSortedAlpha())
                return;

            int index = 0;
            Type t = obj.GetType();
            if (t == typeof(Item[]))
                index = 1;
            string tmp;
            int tmpNum;
            int n = names.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (names[j + 1].Substring(index).CompareTo(names[j].Substring(index)) < 0)
                    {
                        tmp = names[j];
                        names[j] = names[j + 1];
                        names[j + 1] = tmp;

                        tmpNum = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = tmpNum;
                    }
                }
            }
        }
        public void SortNum()
        {
            string tmp;
            int tmpNum;
            int n = names.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (nums[j + 1] > nums[j])
                    {
                        tmpNum = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = tmpNum;

                        tmp = names[j];
                        names[j] = names[j + 1];
                        names[j + 1] = tmp;
                    }
                }
            }
        }
        public int GetIndexFromNum(int num)
        {
            if (!IsSortedAlpha())
                SortAlpha();

            for (int i = 0; i < names.Length; i++)
            {
                if (nums[i] == num)
                    return i;
            }
            return 0;
        }
        public int GetNumFromIndex(int index)
        {
            if (!IsSortedAlpha())
                SortAlpha();

            return nums[index];
        }
        public void SwapName(int num, string name)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (num == nums[i])
                {
                    names[i] = name;
                }
            }
        }
        private bool IsSortedAlpha()
        {
            int index = 0;
            Type t = obj.GetType();
            if (t == typeof(Item[]))
                index = 1;
            for (int i = 0; i < names.Length - 1; i++)
            {
                if (names[i].Substring(index).CompareTo(names[i + 1].Substring(index)) > 0)
                {
                    return false;
                }
            }
            return true;
        }
        private bool IsSortedNum()
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] > nums[i + 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
