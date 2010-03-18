using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using SMRPGED.StatsEditor.Stats;

namespace SMRPGED.StatsEditor
{
    public class StatsModel
    {
        private byte[] data; public byte[] Data { get { return this.data; } set { this.data = value; } }

        private Monster[] monsters; public Monster[] Monsters { get { return this.monsters; } }
        private Item[] items; public Item[] Items { get { return this.items; } }
        private Shop[] shops; public Shop[] Shops { get { return this.shops; } }
        private FormationPack[] formationPacks; public FormationPack[] FormationPacks { get { return this.formationPacks; } }
        private Formation[] formations; public Formation[] Formations { get { return this.formations; } }
        private byte[] formationMusics; public byte[] FormationMusics { get { return this.formationMusics; } }
        private Spell[] spells; public Spell[] Spells { get { return this.spells; } }
        private Attack[] attacks; public Attack[] Attacks { get { return this.attacks; } }
        private Character[] characters; public Character[] Characters { get { return this.characters; } }
        private Timing timing; public Timing Timing { get { return this.timing; } }
        private FontCharacter[] fontCharacters; public FontCharacter[] FontCharacters { get { return this.fontCharacters; } }
        private FontCharacter[] menuCharacters; public FontCharacter[] MenuCharacters { get { return this.menuCharacters; } }
        private FontCharacter[] descCharacters; public FontCharacter[] DescCharacters { get { return this.descCharacters; } }
        private Battlefield[] battlefields; public Battlefield[] Battlefields { get { return battlefields; } }
        private PaletteSet[] paletteSets; public PaletteSet[] PaletteSets { get { return paletteSets; } }
        private Slot[] slots; public Slot[] Slots { get { return this.slots; } set { this.slots = value; } }

        public StatsModel(byte[] data)
        {
            this.data = data;
            
            CreateMonsters();
            CreateItems();
            CreateShops();
            CreateFormationPacks();
            CreateFormations();
            CreateSpells();
            CreateAttacks();
            CreateCharacters();
            CreateSlots();
            CreateTiming();
            CreateFontCharacters();
            CreateBattlefields();
            CreatePaletteSets();
        }

        private void CreateMonsters()
        {
            this.monsters = new Monster[256];
            for (int i = 0; i < this.monsters.Length; i++)
            {
                this.monsters[i] = new Monster(data, i);
            }
        }
        private void CreateItems()
        {
            this.items = new Item[256];
            for (int i = 0; i < this.items.Length; i++)
            {
                this.items[i] = new Item(data, i);
            }
        }
        private void CreateShops()
        {
            this.shops = new Shop[33];
            for (int i = 0; i < this.shops.Length; i++)
            {
                this.shops[i] = new Shop(data, i);
            }
        }
        private void CreateFormationPacks()
        {
            this.formationPacks = new FormationPack[256];
            for (int i = 0; i < this.formationPacks.Length; i++)
            {
                this.formationPacks[i] = new FormationPack(data, i);
            }
        }
        private void CreateFormations()
        {
            this.formations = new Formation[512];
            for (int i = 0; i < this.formations.Length; i++)
            {
                this.formations[i] = new Formation(data, i, monsters);
            }
            this.formationMusics = new byte[8];
            for (int i = 0; i < this.formationMusics.Length; i++)
            {
                this.formationMusics[i] = data[0x029F51 + i];
            }
        }
        private void CreateSpells()
        {
            this.spells = new Spell[128];
            for (int i = 0; i < this.spells.Length; i++)
            {
                this.spells[i] = new Spell(data, i);
            }
        }
        private void CreateAttacks()
        {
            this.attacks = new Attack[129];
            for (int i = 0; i < this.attacks.Length; i++)
            {
                this.attacks[i] = new Attack(data, i);
            }
        }
        private void CreateCharacters()
        {
            this.characters = new Character[5];
            for (int i = 0; i < this.characters.Length; i++)
            {
                this.characters[i] = new Character(data, i);
            }
        }
        private void CreateSlots()
        {
            this.slots = new Slot[30];
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i] = new Slot(data, i);
            }
        }
        private void CreateTiming()
        {
            this.timing = new Timing(data);
        }
        private void CreateBattlefields()
        {
            this.battlefields = new Battlefield[64];
            for (int i = 0; i < this.battlefields.Length; i++)
            {
                this.battlefields[i] = new Battlefield(data, i);
            }
        }
        private void CreatePaletteSets()
        {
            this.paletteSets = new PaletteSet[94];
            for (int i = 0; i < this.paletteSets.Length; i++)
            {
                this.paletteSets[i] = new PaletteSet(data, i, i);
            }
        }
        private void CreateFontCharacters()
        {
            fontCharacters = new FontCharacter[128];
            menuCharacters = new FontCharacter[128];
            descCharacters = new FontCharacter[128];

            for (int i = 0; i < fontCharacters.Length; i++)
                fontCharacters[i] = new FontCharacter(data, i, 1);
            for (int i = 0; i < menuCharacters.Length; i++)
                menuCharacters[i] = new FontCharacter(data, i, 0);
            for (int i = 0; i < descCharacters.Length; i++)
                descCharacters[i] = new FontCharacter(data, i, 2);
        }

        public void Assemble()
        {
            AssembleAttacks();
            AssembleCharacters();
            AssembleFormations();
            AssembleFormationPacks();
            AssembleItems();
            AssembleMonsters();
            AssembleShops();
            AssembleSlots();
            AssembleSpells();
            AssembleTiming();
        }
        private void AssembleAttacks()
        {
            foreach (Attack a in attacks)
                a.Assemble();
        }
        private void AssembleCharacters()
        {
            foreach (Character c in characters)
                c.Assemble();
        }
        private void AssembleFormations()
        {
            foreach (Formation f in formations)
                f.Assemble();
            for (int i = 0; i < formationMusics.Length; i++)
                data[0x029F51 + i] = formationMusics[i];
        }
        private void AssembleFormationPacks()
        {
            foreach (FormationPack fp in formationPacks)
                fp.Assemble();
        }
        private void AssembleItems()
        {
            // Assemble the items
            int i;
            ushort len = 0x3120;

            for (i = 0; i < items.Length && len + (items[i].RawDescription != null ? items[i].RawDescription.Length : 0) < 0x40f1; i++)
                len += items[i].Assemble(len);
            len = 0xed44;
            for (; i < items.Length && len + (items[i].RawDescription != null ? items[i].RawDescription.Length : 0) < 0xffff; i++)
                len += items[i].Assemble(len);
            if (i != items.Length)
                System.Windows.Forms.MessageBox.Show("Item Descriptions total length exceeds max size, decrease total size to save correctly.\nNote: not all text has been saved.");
        }
        private void AssembleMonsters()
        {
            // Assemble the monsters
            int i;
            ushort len = 0xa1d1;
            for (i = 0; i < monsters.Length && len + monsters[i].RawPsychoMsg.Length < 0xb641; i++)
                len += monsters[i].Assemble(len);
            len = 0x1c2a;
            for (; i < monsters.Length && len + monsters[i].RawPsychoMsg.Length < 0x2229; i++)
                len += monsters[i].Assemble(len);
            if (i != monsters.Length)
                System.Windows.Forms.MessageBox.Show("Monster Psychpathic Messages total length exceeds max size, decrease total size to save correctly.\nNote: not all text has been saved.");
        }
        private void AssembleShops()
        {
            foreach (Shop s in shops)
                s.Assemble();
        }
        private void AssembleSlots()
        {
            foreach (Slot s in slots)
                s.Assemble();
        }
        private void AssembleSpells()
        {
            // Assemble the spells
            int i;
            ushort len = 0x2bb6; // offset to the start of spell descriptions
            for (i = 0; i < spells.Length && len + (spells[i].RawDescription != null ? spells[i].RawDescription.Length : 0) < (0x2bb6 + 0x36A); i++)
                len += spells[i].Assemble(len);
            len = 0x55f0; // offset for extra space
            for (; i < spells.Length && len + (spells[i].RawDescription != null ? spells[i].RawDescription.Length : 0) < (0x55f0 + 0xa10); i++)
                len += spells[i].Assemble(len);
            if (i != spells.Length)
                System.Windows.Forms.MessageBox.Show("Spell Descriptions total length exceeds max size, decrease total size to save correctly.\nNote: not all text has been saved.");
        }
        private void AssembleTiming()
        {
            this.timing.Assemble();
        }

        public void ExportAllStats(Model model, string path)
        {
            path += "\\" + model.GetFileNameWithoutPathOrExtension() + "_Stats\\";

            if (!CreateDir(path))
                return;

            Stream s;
            BinaryFormatter b = new BinaryFormatter();
            s = File.Create(path + "Do Not Modify This Directory Or Files Contained Within.txt");
            s.Close();

            try // Monsters
            {
                if (!CreateDir(path + "Monsters\\"))
                    return;

                for (int i = 0; i < this.monsters.Length; i++)
                {
                    s = File.Create(path + "Monsters\\" + "Monster_" + i.ToString("X3") + ".dat"); // Create data file

                    this.monsters[i].Data = null;
                    this.monsters[i].TextHelperReduced = null;
                    // Serialize object
                    b.Serialize(s, this.monsters[i]);
                    s.Close();

                    this.monsters[i].Data = model.Data;
                    this.monsters[i].TextHelperReduced = TextHelperReduced.Instance;
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("There was a problem exporting Monsters, ensure all files are present");
            }

            try // Items
            {
                if (!CreateDir(path + "Items\\"))
                    return;

                for (int i = 0; i < this.items.Length; i++)
                {
                    s = File.Create(path + "Items\\" + "Item_" + i.ToString("X3") + ".dat"); // Create data file

                    this.items[i].Data = null;
                    this.items[i].textHelperReduced = null;
                    // Serialize object
                    b.Serialize(s, this.items[i]);
                    s.Close();

                    this.items[i].Data = model.Data;
                    this.items[i].textHelperReduced = TextHelperReduced.Instance;
                }

            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("There was a problem exporting Items, ensure all files are present");
            }

            try // Shops
            {
                if (!CreateDir(path + "Shops\\"))
                    return;

                for (int i = 0; i < this.shops.Length; i++)
                {
                    s = File.Create(path + "Shops\\" + "Shop_" + i.ToString("X3") + ".dat"); // Create data file

                    this.shops[i].Data = null;
                    // Serialize object
                    b.Serialize(s, this.shops[i]);
                    s.Close();

                    this.shops[i].Data = model.Data;
                }

            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("There was a problem exporting Shops, ensure all files are present");
            }

            try // Spells
            {
                if (!CreateDir(path + "Spells\\"))
                    return;

                for (int i = 0; i < this.spells.Length; i++)
                {
                    s = File.Create(path + "Spells\\" + "Spell_" + i.ToString("X3") + ".dat"); // Create data file

                    this.spells[i].Data = null;
                    this.spells[i].TextHelperReduced = null;
                    // Serialize object
                    b.Serialize(s, this.spells[i]);
                    s.Close();

                    this.spells[i].Data = model.Data;
                    this.spells[i].TextHelperReduced = TextHelperReduced.Instance;
                }

            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("There was a problem exporting Spells, ensure all files are present");
            }

            try // Attacks
            {
                if (!CreateDir(path + "Attacks\\"))
                    return;

                for (int i = 0; i < this.attacks.Length; i++)
                {
                    s = File.Create(path + "Attacks\\" + "Attack_" + i.ToString("X3") + ".dat"); // Create data file

                    this.attacks[i].Data = null;
                    // Serialize object
                    b.Serialize(s, this.attacks[i]);
                    s.Close();

                    this.attacks[i].Data = model.Data;
                }

            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("There was a problem exporting Attacks, ensure all files are present");
            }

            try // Formation Packs
            {
                if (!CreateDir(path + "FormationPacks\\"))
                    return;

                for (int i = 0; i < this.formationPacks.Length; i++)
                {
                    s = File.Create(path + "FormationPacks\\" + "FormationPack_" + i.ToString("X3") + ".dat"); // Create data file

                    this.formationPacks[i].Data = null;
                    // Serialize object
                    b.Serialize(s, this.formationPacks[i]);
                    s.Close();

                    this.formationPacks[i].Data = model.Data;
                }

            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("There was a problem exporting Formation Packs, ensure all files are present");
            }

            try // Formations
            {
                if (!CreateDir(path + "Formations\\"))
                    return;

                for (int i = 0; i < this.formations.Length; i++)
                {
                    s = File.Create(path + "Formations\\" + "Formation_" + i.ToString("X3") + ".dat"); // Create data file

                    this.formations[i].Data = null;
                    // Serialize object
                    b.Serialize(s, this.formations[i]);
                    s.Close();

                    this.formations[i].Data = model.Data;
                }

            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("There was a problem exporting Formations, ensure all files are present");
            }

            try // Characters
            {
                if (!CreateDir(path + "Characters\\"))
                    return;

                for (int i = 0; i < this.characters.Length; i++)
                {
                    s = File.Create(path + "Characters\\" + "Character_" + i.ToString("X3") + ".dat"); // Create data file

                    this.characters[i].Data = null;
                    // Serialize object
                    b.Serialize(s, this.characters[i]);
                    s.Close();

                    this.characters[i].Data = model.Data;
                }

            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("There was a problem exporting Characters, ensure all files are present");
            }

            try // Timing
            {
                if (!CreateDir(path + "Timing\\"))
                    return;

                s = File.Create(path + "Timing\\" + "Timing.dat"); // Create data file

                this.timing.Data = null;
                // Serialize object
                b.Serialize(s, this.timing);
                s.Close();

                this.timing.Data = model.Data;


            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("There was a problem exporting Timing, ensure all files are present");
            }
        }
        public void ImportAllStats(Model model, string path)
        {
            Stream s;
            BinaryFormatter b = new BinaryFormatter();

            try
            {
                for (int i = 0; i < monsters.Length; i++)
                {
                    s = File.OpenRead(path + "Monsters\\" + "Monster_" + i.ToString("X3") + ".dat");
                    monsters[i] = (Monster)b.Deserialize(s);
                    s.Close();
                    monsters[i].Data = model.Data;
                    monsters[i].TextHelperReduced = TextHelperReduced.Instance;
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("There was a problem loading Monster data. Verify that the " +
                "Monster data files are correctly named and present.");
            }
            try
            {
                for (int i = 0; i < items.Length; i++)
                {
                    s = File.OpenRead(path + "Items\\" + "Item_" + i.ToString("X3") + ".dat");
                    this.items[i] = (Item)b.Deserialize(s);
                    s.Close();
                    this.items[i].Data = model.Data;
                    this.items[i].textHelperReduced = TextHelperReduced.Instance;
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("There was a problem loading Item data. Verify that the " +
                "Item data files are correctly named and present.");
            }
            try
            {
                for (int i = 0; i < this.shops.Length; i++)
                {
                    s = File.OpenRead(path + "Shops\\" + "Shop_" + i.ToString("X3") + ".dat");
                    this.shops[i] = (Shop)b.Deserialize(s);
                    s.Close();
                    this.shops[i].Data = model.Data;
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("There was a problem loading Shop data. Verify that the " +
                "Shop data files are correctly named and present.");
            }
            try
            {
                for (int i = 0; i < spells.Length; i++)
                {
                    s = File.OpenRead(path + "Spells\\" + "Spell_" + i.ToString("X3") + ".dat");
                    this.spells[i] = (Spell)b.Deserialize(s);
                    s.Close();
                    this.spells[i].Data = model.Data;
                    this.spells[i].TextHelperReduced = TextHelperReduced.Instance;
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("There was a problem loading Spell data. Verify that the " +
                "Spell data files are correctly named and present.");
            }
            try
            {
                for (int i = 0; i < this.attacks.Length; i++)
                {
                    s = File.OpenRead(path + "Attacks\\" + "Attack_" + i.ToString("X3") + ".dat");
                    this.attacks[i] = (Attack)b.Deserialize(s);
                    s.Close();
                    this.attacks[i].Data = model.Data;
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("There was a problem loading Attack data. Verify that the " +
                "Attack data files are correctly named and present.");
            }
            try
            {
                for (int i = 0; i < this.formationPacks.Length; i++)
                {
                    s = File.OpenRead(path + "FormationPacks\\" + "FormationPack_" + i.ToString("X3") + ".dat");
                    this.formationPacks[i] = (FormationPack)b.Deserialize(s);
                    s.Close();
                    this.formationPacks[i].Data = model.Data;
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("There was a problem loading Formation Pack data. Verify that the " +
                "Formation Pack data files are correctly named and present.");
            }
            try
            {
                for (int i = 0; i < this.formations.Length; i++)
                {
                    s = File.OpenRead(path + "Formations\\" + "Formation_" + i.ToString("X3") + ".dat");
                    this.formations[i] = (Formation)b.Deserialize(s);
                    s.Close();
                    this.formations[i].Data = model.Data;
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("There was a problem loading Formation data. Verify that the " +
                "Formation data files are correctly named and present.");
            }
            try
            {
                for (int i = 0; i < this.characters.Length; i++)
                {
                    s = File.OpenRead(path + "Characters\\" + "Character_" + i.ToString("X3") + ".dat");
                    this.characters[i] = (Character)b.Deserialize(s);
                    s.Close();
                    this.characters[i].Data = model.Data;
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("There was a problem loading Character data. Verify that the " +
                "Character data files are correctly named and present.");
            }
            try
            {
                s = File.OpenRead(path + "Timing\\" + "Timing.dat");
                this.timing = (Timing)b.Deserialize(s);
                s.Close();
                this.timing.Data = model.Data;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("There was a problem loading Timing data. Verify that the " +
                "Timing data file is correctly named and present.");
            }
        }

        private bool CreateDir(string dir)
        {
            DirectoryInfo di = new DirectoryInfo(dir);

            try
            {
                if (!di.Exists)
                {
                    di.Create();
                }
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Sorry, there was an error trying to create the directory : " + dir, "Error");
                return false;
            }
        }
    }
}
