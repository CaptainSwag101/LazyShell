using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using SMRPGED.Properties;

namespace SMRPGED
{
    public class UniversalVariables
    {
        // This class only holds variables that need to be accessed, altered
        // and have changes reflected editor-wide
        private Settings settings;
        private DDlistName monsterNames;
        public DDlistName MonsterNames
        {
            get
            {
                if (monsterNames == null)
                    throw new Exception();

                return this.monsterNames;
            }
            set
            {
                this.monsterNames = value;
                monsterNames.SortAlpha();
            }
        }
        private DDlistName spellNames;
        public DDlistName SpellNames
        {
            get
            {
                if (spellNames == null)
                    throw new Exception();
                return this.spellNames;
            }
            set
            {
                this.spellNames = value;
                spellNames.SortAlpha();
            }
        }
        private DDlistName attackNames;
        public DDlistName AttackNames
        {
            get
            {
                if (attackNames == null)
                    throw new Exception();

                return this.attackNames;
            }
            set
            {
                this.attackNames = value;
                attackNames.SortAlpha();
            }
        }
        private DDlistName itemNames;
        public DDlistName ItemNames
        {
            get
            {
                if (itemNames == null)
                    throw new Exception();

                return this.itemNames;
            }
            set
            {
                this.itemNames = value;
                itemNames.SortAlpha();
            }
        }

        public UniversalVariables()
        {
            this.settings = Settings.Default;

        }

        private BattleDialogue[] battleDialogues;
        public BattleDialogue[] BattleDialogues
        {
            get
            {
                if (battleDialogues == null)
                    throw new Exception();
                return this.battleDialogues;
            }
            set { this.battleDialogues = value; }
        }
        private Dialogue[] dialogues;
        public Dialogue[] Dialogues
        {
            get
            {
                if (dialogues == null)
                    throw new Exception();
                return this.dialogues;
            }
            set { this.dialogues = value; }
        }
        private string[] levelNames;
        public string[] LevelNames
        {
            get
            {
                if (levelNames == null)
                    GenerateLevelNames();

                return levelNames;
            }

        }
        private void GenerateLevelNames()
        {
            System.Collections.Specialized.StringCollection names = settings.LevelNames;
            levelNames = new string[names.Count];

            for (int i = 0; i < names.Count; i++)
            {
                levelNames[i] = "[" + i.ToString("X3") + "]  " + names[i];
            }
        }
        public string GetLevelName(int levelNum)
        {
            if (levelNames == null)
                GenerateLevelNames();
            return levelNames[levelNum];
        }
        public void RefreshLevelName(int levelNum)
        {
            levelNames[levelNum] = "[" + levelNum.ToString("X3") + "]  " + settings.LevelNames[levelNum];
        }
    }
}
