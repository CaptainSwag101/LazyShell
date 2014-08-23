using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL.Animations
{
    public static class Model
    {
        #region Variables

        // ROM buffer
        public static byte[] ROM
        {
            get { return LAZYSHELL.Model.ROM; }
            set { LAZYSHELL.Model.ROM = value; }
        }

        // Elements
        private static Script[] allySpells;
        private static Script[] battleEvents;
        private static Script[] items;
        private static Script[] monsterAttacks;
        private static Script[] monsterBehaviors;
        private static Script[] monsterEntrances;
        private static Script[] monsterSpells;
        private static Script[] weapons;
        public static Script[] AllySpells
        {
            get
            {
                if (allySpells == null)
                {
                    allySpells = new Script[27];
                    for (int i = 0; i < allySpells.Length; i++)
                        allySpells[i] = new Script(i, Set.AllySpell);
                }
                return allySpells;
            }
            set { allySpells = value; }
        }
        public static Script[] BattleEvents
        {
            get
            {
                if (battleEvents == null)
                {
                    battleEvents = new Script[102];
                    for (int i = 0; i < battleEvents.Length; i++)
                        battleEvents[i] = new Script(i, Set.BattleEvent);
                }
                return battleEvents;
            }
            set { battleEvents = value; }
        }
        public static Script[] Items
        {
            get
            {
                if (items == null)
                {
                    items = new Script[81];
                    for (int i = 0; i < items.Length; i++)
                        items[i] = new Script(i, Set.Item);
                }
                return items;
            }
            set { items = value; }
        }
        public static Script[] MonsterAttacks
        {
            get
            {
                if (monsterAttacks == null)
                {
                    monsterAttacks = new Script[129];
                    for (int i = 0; i < monsterAttacks.Length; i++)
                        monsterAttacks[i] = new Script(i, Set.MonsterAttack);
                }
                return monsterAttacks;
            }
            set { monsterAttacks = value; }
        }
        public static Script[] MonsterBehaviors
        {
            get
            {
                if (monsterBehaviors == null)
                {
                    monsterBehaviors = new Script[54];
                    for (int i = 0; i < monsterBehaviors.Length; i++)
                        monsterBehaviors[i] = new Script(i, Set.MonsterBehavior);
                }
                return monsterBehaviors;
            }
            set { monsterBehaviors = value; }
        }
        public static Script[] MonsterEntrances
        {
            get
            {
                if (monsterEntrances == null)
                {
                    monsterEntrances = new Script[16];
                    for (int i = 0; i < monsterEntrances.Length; i++)
                        monsterEntrances[i] = new Script(i, Set.MonsterEntrance);
                }
                return monsterEntrances;
            }
            set { monsterEntrances = value; }
        }
        public static Script[] MonsterSpells
        {
            get
            {
                if (monsterSpells == null)
                {
                    monsterSpells = new Script[45];
                    for (int i = 0; i < monsterSpells.Length; i++)
                        monsterSpells[i] = new Script(i, Set.MonsterSpell);
                }
                return monsterSpells;
            }
            set { monsterSpells = value; }
        }
        public static Script[] Weapons
        {
            get
            {
                if (weapons == null)
                {
                    weapons = new Script[36];
                    for (int i = 0; i < weapons.Length; i++)
                        weapons[i] = new Script(i, Set.Weapon);
                }
                return weapons;
            }
            set { weapons = value; }
        }

        #endregion

        #region Methods

        // Model management
        public static void ClearAll()
        {
            allySpells = null;
            battleEvents = null;
            items = null;
            monsterAttacks = null;
            monsterBehaviors = null;
            monsterEntrances = null;
            monsterSpells = null;
            weapons = null;
        }
        public static void LoadAll()
        {
            object dummy;
            dummy = AllySpells;
            dummy = BattleEvents;
            dummy = Items;
            dummy = MonsterAttacks;
            dummy = MonsterBehaviors;
            dummy = MonsterEntrances;
            dummy = MonsterSpells;
            dummy = Weapons;
        }

        #endregion
    }

    /// <summary>
    /// Specifies the set of animation scripts to access. All corresponding 
    /// instances of each animation script set are of the Animations.Script[] type.
    /// </summary>
    public enum Set
    {
        AllySpell, BattleEvent, Item, MonsterAttack, MonsterBehavior, MonsterEntrance, MonsterSpell, Weapon
    }
}
