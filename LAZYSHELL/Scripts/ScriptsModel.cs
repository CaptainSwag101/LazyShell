using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LAZYSHELL.ScriptsEditor
{
    public class ScriptsModel
    {
        byte[] data;
        Model model;

        private BattleScript[] battleScripts; public BattleScript[] BattleScripts { get { return this.battleScripts; } }
        private EventScript[] eventScripts; public EventScript[] EventScripts { get { return this.eventScripts; } }
        private ActionQueue[] actionScripts; public ActionQueue[] ActionScripts { get { return this.actionScripts; } }
        private AnimationScript[] spellAnimMonsters; public AnimationScript[] SpellAnimMonsters { get { return this.spellAnimMonsters; } }
        private AnimationScript[] spellAnimAllies; public AnimationScript[] SpellAnimAllies { get { return this.spellAnimAllies; } }
        private AnimationScript[] attackAnimations; public AnimationScript[] AttackAnimations { get { return this.attackAnimations; } }
        private AnimationScript[] itemAnimations; public AnimationScript[] ItemAnimations { get { return this.itemAnimations; } }
        private AnimationScript[] battleEvents; public AnimationScript[] BattleEvents { get { return this.battleEvents; } }
        private AnimationScript[] behaviorAnimations; public AnimationScript[] BehaviorAnimations { get { return this.behaviorAnimations; } }
        private AnimationScript[] entranceAnimations; public AnimationScript[] EntranceAnimations { get { return this.entranceAnimations; } }
        private AnimationScript[] weaponAnimations; public AnimationScript[] WeaponAnimations { get { return this.weaponAnimations; } }
        private FontCharacter[] menuCharacters; public FontCharacter[] MenuCharacters { get { return this.menuCharacters; } }
        private FontCharacter[] fontCharacters; public FontCharacter[] FontCharacters { get { return this.fontCharacters; } }

        public ScriptsModel(byte[] data, Model model)
        {
            this.data = data;
            this.model = model;

            CreateBattleScripts();
            CreateEventScripts();
            CreateActionScripts();
            CreateAnimationScripts();
            CreateFontCharacters();
        }
        private void CreateBattleScripts()
        {
            this.battleScripts = new BattleScript[256];

            for (int i = 0; i < battleScripts.Length; i++)
                battleScripts[i] = new BattleScript(data, i);
        }
        public void CreateEventScripts()
        {
            this.eventScripts = new EventScript[4096];

            for (int i = 0; i < eventScripts.Length; i++)
                eventScripts[i] = new EventScript(data, i);
        }
        private void CreateActionScripts()
        {
            this.actionScripts = new ActionQueue[1024];

            for (int i = 0; i < actionScripts.Length; i++)
                actionScripts[i] = new ActionQueue(data, i);
        }
        private void CreateAnimationScripts()
        {
            spellAnimMonsters = new AnimationScript[45];
            spellAnimAllies = new AnimationScript[27];
            attackAnimations = new AnimationScript[129];
            battleEvents = new AnimationScript[102];
            itemAnimations = new AnimationScript[81];
            entranceAnimations = new AnimationScript[16];
            behaviorAnimations = new AnimationScript[54];
            weaponAnimations = new AnimationScript[36];

            for (int i = 0; i < behaviorAnimations.Length; i++)
                behaviorAnimations[i] = new AnimationScript(data, i, 0);
            for (int i = 0; i < spellAnimMonsters.Length; i++)
                spellAnimMonsters[i] = new AnimationScript(data, i, 1);
            for (int i = 0; i < entranceAnimations.Length; i++)
                entranceAnimations[i] = new AnimationScript(data, i, 2);
            for (int i = 0; i < attackAnimations.Length; i++)
                attackAnimations[i] = new AnimationScript(data, i, 3);
            for (int i = 0; i < itemAnimations.Length; i++)
                itemAnimations[i] = new AnimationScript(data, i, 4);
            for (int i = 0; i < spellAnimAllies.Length; i++)
                spellAnimAllies[i] = new AnimationScript(data, i, 5);
            for (int i = 0; i < weaponAnimations.Length; i++)
                weaponAnimations[i] = new AnimationScript(data, i, 6);
            for (int i = 0; i < battleEvents.Length; i++)
                battleEvents[i] = new AnimationScript(data, i, 7);
        }
        private void CreateFontCharacters()
        {
            menuCharacters = new FontCharacter[128];

            for (int i = 0; i < menuCharacters.Length; i++)
                menuCharacters[i] = new FontCharacter(data, i, 0);

            fontCharacters = new FontCharacter[128];

            for (int i = 0; i < fontCharacters.Length; i++)
                fontCharacters[i] = new FontCharacter(data, i, 1);
        }

        public void AssembleAllEventScripts()
        {
            foreach (EventScript es in eventScripts)
                es.Assemble();

            int i = 0;
            int pointer = 0;
            int bank = 0x1E0000;
            ushort offset = 0xC00;
            for (; i < 1536; i++, pointer += 2)
            {
                BitManager.SetShort(data, bank + pointer, offset);
                BitManager.SetByteArray(data, bank + offset, eventScripts[i].Script);
                offset += (ushort)eventScripts[i].Script.Length;
            }
            for (int a = offset; a < 0x10000; a++) data[bank + a] = 0xFF;

            pointer = 0;
            bank = 0x1F0000;
            offset = 0xC00;
            for (; i < 3072; i++, pointer += 2)
            {
                BitManager.SetShort(data, bank + pointer, offset);
                BitManager.SetByteArray(data, bank + offset, eventScripts[i].Script);
                offset += (ushort)eventScripts[i].Script.Length;
            }
            for (int a = offset; a < 0x10000; a++) data[bank + a] = 0xFF;

            pointer = 0;
            bank = 0x200000;
            offset = 0x800;
            for (; i < 4096; i++, pointer += 2)
            {
                BitManager.SetShort(data, bank + pointer, offset);
                BitManager.SetByteArray(data, bank + offset, eventScripts[i].Script);
                offset += (ushort)eventScripts[i].Script.Length;
            }
            for (int a = offset; a < 0xE000; a++) data[bank + a] = 0xFF;
        }
        public void AssembleAllBattleScripts()
        {
            // Assemble BattleScript Data
            // Block 1
            ushort offset = 0x32AA; // Starting point for storage
            int bank = 0x390000;
            int i = 0;

            int pointerTable = 0x3930AA;

            for (; i < battleScripts.Length && offset + battleScripts[i].ScriptLength <= 0x59F3; i++)
            {
                // write to the pointer array
                BitManager.SetShort(data, pointerTable + (i * 2), offset);
                // write to the data
                offset += battleScripts[i].Assemble(bank + offset);
            }
            // Block 2
            offset = 0xF400;
            for (; i < battleScripts.Length && offset + battleScripts[i].ScriptLength <= 0xFFFF; i++)
            {
                // write to the pointer array
                BitManager.SetShort(data, pointerTable + (i * 2), offset);
                // write to the data
                offset += battleScripts[i].Assemble(bank + offset);
            }

            if (i != battleScripts.Length)
                System.Windows.Forms.MessageBox.Show("Battle Scripts exceed max size, decrease total size to save correctly.\nNote: Saving stops when out of space.");
            // DONE ASSEMBLING BATTLE SCRIPT DATA
        }
        public void AssembleAllActionScripts()
        {
            foreach (ActionQueue ac in actionScripts)
                ac.Assemble();

            int i = 0;
            int pointer = 0;
            int bank = 0x210000;
            ushort offset = 0x800;
            for (; i < actionScripts.Length; i++, pointer += 2)
            {
                BitManager.SetShort(data, bank + pointer, offset);
                BitManager.SetByteArray(data, bank + offset, actionScripts[i].ActionQueueData);
                offset += (ushort)actionScripts[i].ActionQueueData.Length;
            }
        }
    }
}
