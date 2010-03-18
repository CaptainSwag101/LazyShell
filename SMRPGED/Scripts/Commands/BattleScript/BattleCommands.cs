using System;
using System.Collections.Generic;
using System.Text;

namespace SMRPGED.ScriptsEditor.Commands
{
    // These classes should only contains stuff that is specific to each BattleCommand

    // Length 1 Commands
    public class BattleCommandLE0 : BattleScriptCommand
    {
        public BattleCommandLE0(byte[] commandData, DDlistName attackNames)
            : base(commandData)
        {
            this.length = 1;
            this.option = -1;
            this.names = attackNames;
        }

        public override void ModifyCommand(int offset, byte change)
        {
            if (offset == 0)
                this.commandData[0] = change;
        }

        public override string ToString()
        {
            string atkName;

            if (commandData[0] == 0xFB) atkName = "{Do nothing}";
            else atkName = "[" + commandData[0].ToString("d3") + "]  " + names.GetNameByNum(commandData[0]);

            return "Do 1 attack:  " + atkName;
        }

    }
    public class BattleCommandEC : BattleScriptCommand
    {
        /*
         * Notes about this command
         * 
         * Exits the current battle
         * Length 0
         * ect...
         * 
         */
        public BattleCommandEC(byte[] commandData)
            : base(commandData)
        {
            this.length = 1; // initialize the length of this command
            this.option = -1;
        }

        public override void ModifyCommand(int offset, byte change)
        {
            // Nothing to change
        }

        public override string ToString()
        {
            return "Exit Battle";
        }

    }
    public class BattleCommandFB : BattleScriptCommand
    {
        public BattleCommandFB(byte[] commandData)
            : base(commandData)
        {
            this.length = 1;
            this.option = -1;

        }

        public override void ModifyCommand(int offset, byte change)
        {

        }

        public override string ToString()
        {
            return "Do nothing";
        }

    }
    public class BattleCommandFD : BattleScriptCommand
    {


        public BattleCommandFD(byte[] commandData)
            : base(commandData)
        {
            this.length = 1;
            this.option = -1;

        }

        public override void ModifyCommand(int offset, byte change)
        {

        }

        public override string ToString()
        {
            return "Wait 1 turn";
        }

    }
    public class BattleCommandFE : BattleScriptCommand
    {


        public BattleCommandFE(byte[] commandData)
            : base(commandData)
        {
            this.length = 1;
            this.option = -1;

        }

        public override void ModifyCommand(int offset, byte change)
        {
        }

        public override string ToString()
        {
            return "Wait 1 turn, restart script";
        }

    }
    public class BattleCommandFF : BattleScriptCommand
    {


        public BattleCommandFF(byte[] commandData)
            : base(commandData)
        {
            this.length = 1;
            this.option = -1;

        }

        public override void ModifyCommand(int offset, byte change)
        {

        }

        public override string ToString()
        {
            return "Counter commands";
        }

    }
    // Length 2 Commands
    public class BattleCommandE2 : BattleScriptCommand
    {
        public BattleCommandE2(byte[] commandData, string[] targetNames)
            : base(commandData)
        {
            this.length = 2;
            this.option = commandData[1];
            this.targetNames = targetNames;
        }

        public override void ModifyCommand(int offset, byte change)
        {
            commandData[1] = change;
        }

        public override string ToString()
        {
            return "Set target:  " + targetNames[commandData[1]];
        }

    }
    public class BattleCommandE3 : BattleScriptCommand
    {
        public BattleCommandE3(byte[] commandData, BattleDialogue[] battleDialogues)
            : base(commandData)
        {
            this.length = 2;
            this.option = commandData[1];
            this.battleDialogues = battleDialogues;
        }

        public override void ModifyCommand(int offset, byte change)
        {
            commandData[1] = change;
        }

        public override string ToString()
        {
            return "Run battle dialogue:  [" + commandData[1].ToString("d3") + "] \"" + battleDialogues[commandData[1]].GetBattleDialogueStub() + "\"";
        }

    }
    public class BattleCommandE5 : BattleScriptCommand
    {
        public BattleCommandE5(byte[] commandData, string[] battleEventNames)
            : base(commandData)
        {
            this.length = 2;
            this.option = commandData[1];
            this.battleEventNames = battleEventNames;
        }

        public override void ModifyCommand(int offset, byte change)
        {
            commandData[1] = change;
        }

        public override string ToString()
        {
            return "Run battle event:  " + battleEventNames[commandData[1]];
        }

    }
    public class BattleCommandE8 : BattleScriptCommand
    {
        public BattleCommandE8(byte[] commandData)
            : base(commandData)
        {
            this.length = 2;
            this.option = commandData[1];

        }

        public override void ModifyCommand(int offset, byte change)
        {
            commandData[offset] = change;
        }

        public override string ToString()
        {
            return "Clear memory address:  7EE00" + commandData[1].ToString("X1");
        }

    }
    public class BattleCommandED : BattleScriptCommand
    {
        public BattleCommandED(byte[] commandData)
            : base(commandData)
        {
            this.length = 2;
            this.option = commandData[1];

        }

        public override void ModifyCommand(int offset, byte change)
        {
            commandData[1] = change;
        }

        public override string ToString()
        {
            return "Store to 7EE005 a random number less than:  " + commandData[1].ToString("d3");
        }

    }
    public class BattleCommandEF : BattleScriptCommand
    {
        public BattleCommandEF(byte[] commandData, DDlistName spellNames)
            : base(commandData)
        {
            this.length = 2;
            this.option = commandData[1];
            this.names = spellNames;
        }

        public override void ModifyCommand(int offset, byte change)
        {
            this.commandData[1] = change;
        }

        public override string ToString()
        {
            string name;

            if (commandData[1] == 0xFB) name = "{Do nothing}";
            else name = "[" + commandData[1].ToString("d3") + "]  " + names.GetNameByNum(commandData[1]);

            name.Trim('\x20');

            return "Do 1 spell:  " + name;
        }

    }
    public class BattleCommandF1 : BattleScriptCommand
    {
        public BattleCommandF1(byte[] commandData)
            : base(commandData)
        {
            this.length = 2;
            this.option = commandData[1];

        }

        public override void ModifyCommand(int offset, byte change)
        {
            commandData[1] = change;
        }

        public override string ToString()
        {
            return "Run object sequence:  " + commandData[1].ToString("d3");
        }

    }
    // Length 3 Commands
    public class BattleCommandE6 : BattleScriptCommand
    {
        public BattleCommandE6(byte[] commandData)
            : base(commandData)
        {
            this.length = 3;
            this.option = commandData[1];

        }

        public override void ModifyCommand(int offset, byte change)
        {
            commandData[offset] = change;
        }

        public override string ToString()
        {
            switch (option)
            {
                case 0:
                    return "Increment memory address:  7EE00" + commandData[2].ToString("X1");
                case 1:
                    return "Decrement memory address:  7EE00" + commandData[2].ToString("X1");
                default:
                    return "ERROR";
            }
        }

    }
    public class BattleCommandEB : BattleScriptCommand
    {
        public BattleCommandEB(byte[] commandData, string[] targetNames)
            : base(commandData)
        {
            this.length = 3;
            this.option = commandData[1];
            this.targetNames = targetNames;
        }

        public override void ModifyCommand(int offset, byte change)
        {
            commandData[2] = change;
        }

        public override string ToString()
        {
            if (option == 0) return "Set invincibility for target:  " + targetNames[commandData[2]];
            else return "Null invincibility for target:  " + targetNames[commandData[2]];
        }

    }
    public class BattleCommandF2 : BattleScriptCommand
    {
        public BattleCommandF2(byte[] commandData)
            : base(commandData)
        {
            this.length = 3;
            this.option = commandData[1];

        }

        public override void ModifyCommand(int offset, byte change)
        {
            commandData[2] = change;
        }

        public override string ToString()
        {
            string theTarget;
            if (commandData[2] == 0) theTarget = "self";
            else theTarget = "monster " + commandData[2].ToString();

            switch (option)
            {
                case 0: return "Disable target:  " + theTarget;
                case 1: return "Enable target:  " + theTarget;
                default: return "ERROR";
            }
        }

    }
    public class BattleCommandF3 : BattleScriptCommand
    {
        /*
         * Notes about this command
         * Enables and disables commands
         * 
         * 
         */
        public BattleCommandF3(byte[] commandData)
            : base(commandData)
        {
            this.length = 3;
            this.option = commandData[1];
        }

        public override void ModifyCommand(int offset, byte change)
        {
            commandData[offset] = change;
        }

        public override string ToString()
        {
            string[] commandNames = new string[3];

            bool before = false;

            for (int i = 0x01, j = 0; i < 0x05; i *= 2, j++)
            {
                if ((commandData[2] & i) == i)
                {
                    if (before && j > 0) commandNames[j] = " ,  ";

                    if (j == 0) commandNames[j] += "Attack";
                    else if (j == 1) commandNames[j] += "Special";
                    else commandNames[j] += "Item";

                    before = true;
                }
                else commandNames[j] = "";
            }

            switch (option)
            {
                case 0:
                    return "Enable Command(s):  " + commandNames[0] + commandNames[1] + commandNames[2];
                case 1:
                    return "Disable Command(s):  " + commandNames[0] + commandNames[1] + commandNames[2];
                default:
                    return "ERROR";
            }
        }
    }
    // Length 4 Commands
    public class BattleCommandE0 : BattleScriptCommand
    {
        public BattleCommandE0(byte[] commandData, DDlistName attackNames)
            : base(commandData)
        {
            this.length = 4;
            this.option = commandData[1];
            this.names = attackNames;
        }

        public override void ModifyCommand(int offset, byte change)
        {
            this.commandData[offset] = change;
        }

        public override string ToString()
        {
            string[] name = new string[3];

            for (int i = 0; i < 3; i++)
            {
                if (commandData[i + 1] == 0xFB) name[i] = "{Do nothing}";
                else name[i] = "[" + commandData[i + 1].ToString("d3") + "]  " + names.GetNameByNum(commandData[i + 1]);
                name[i] = TrimTailSpaces(name[i]);
            }

            return
                "Do 1 of 3 possible attacks:  " +
                name[0] + "  /  " + name[1] + "  /  " + name[2];
        }

        private string TrimTailSpaces(string src)
        {
            int lastIndex = src.Length - 1;

            while (src[lastIndex] == ' ' || src[lastIndex] == '\0')
                lastIndex--;

            return src.Substring(0, lastIndex + 1);
        }
    }
    public class BattleCommandE7 : BattleScriptCommand
    {


        public BattleCommandE7(byte[] commandData)
            : base(commandData)
        {
            this.length = 4;
            this.option = commandData[1];

        }

        public override void ModifyCommand(int offset, byte change)
        {
            commandData[offset] = change;
        }

        public override string ToString()
        {
            string[] bits = new string[8];
            bool before = false;

            for (int i = 0x01, j = 0; i < 0x81; i *= 2, j++)
            {
                if ((commandData[3] & i) == i)
                {
                    if (before && j > 0) bits[j] = " ,  ";
                    bits[j] += j.ToString();

                    before = true;
                }
                else bits[j] = "";
            }

            switch (option)
            {
                case 0:
                    return "Set memory address:  7EE00" +
                        commandData[2].ToString("X1") +
                        " ,  bit(s):  " +
                        bits[0] +
                        bits[1] +
                        bits[2] +
                        bits[3] +
                        bits[4] +
                        bits[5] +
                        bits[6] +
                        bits[7];
                case 1:
                    return "Clear memory address:  7EE00" +
                        commandData[2].ToString("X1") +
                        " ,  bit(s):  " +
                        bits[0] +
                        bits[1] +
                        bits[2] +
                        bits[3] +
                        bits[4] +
                        bits[5] +
                        bits[6] +
                        bits[7];
                default: return "ERROR";
            }
        }

    }
    public class BattleCommandEA : BattleScriptCommand
    {
        public BattleCommandEA(byte[] commandData, string[] targetNames)
            : base(commandData)
        {
            this.length = 4;
            this.option = commandData[1];
            this.targetNames = targetNames;
        }

        public override void ModifyCommand(int offset, byte change)
        {
            commandData[3] = change;
        }

        public override string ToString()
        {
            switch (option)
            {
                case 0: return "Remove target from battle:  " + targetNames[commandData[3]];
                case 1: return "Call target to battle:  " + targetNames[commandData[3]];
                default: return "ERROR";
            }
        }

    }
    public class BattleCommandF0 : BattleScriptCommand
    {
        public BattleCommandF0(byte[] commandData, DDlistName spellNames)
            : base(commandData)
        {
            this.length = 4;
            this.option = commandData[1];
            this.names = spellNames;
        }

        public override void ModifyCommand(int offset, byte change)
        {
            this.commandData[offset] = change;
        }

        public override string ToString()
        {
            string[] name = new string[3];

            for (int i = 0; i < 3; i++)
            {
                if (commandData[i + 1] == 0xFB) name[i] = "{Do nothing}";
                else name[i] = "[" + commandData[i + 1].ToString("d3") + "]  " + names.GetNameByNum(commandData[i + 1]);
                name[i] = TrimTailSpaces(name[i]);
            }

            return
                "Do 1 of 3 possible spells:  " +
                name[0] + "  /  " + name[1] + "  /  " + name[2];
        }
        private string TrimTailSpaces(string src)
        {
            int lastIndex = src.Length - 1;

            while (src[lastIndex] == ' ' || src[lastIndex] == '\0')
                lastIndex--;

            return src.Substring(0, lastIndex + 1);
        }
    }
    public class BattleCommandF4 : BattleScriptCommand
    {

        public BattleCommandF4(byte[] commandData)
            : base(commandData)
        {
            this.length = 4;
            this.option = commandData[1];

        }

        public override void ModifyCommand(int offset, byte change)
        {
            commandData[2] = change;
        }

        public override string ToString()
        {
            switch (commandData[2])
            {
                case 0: return "Clear item inventory";
                case 1: return "Restore item inventory";
                default: return "ERROR";
            }
        }

    }
    public class BattleCommandFC : BattleScriptCommand
    {
        /*
        * Notes about this command
        * Command ID: 0xFC has 0x14 different options, account for these in the constructor
        * 
        */
        public BattleCommandFC(byte[] commandData, DDlistName spellNames, DDlistName itemNames, string[] targetNames)
            : base(commandData)
        {
            this.length = 4;
            this.option = commandData[1];
            this.targetNames = targetNames;

            if (option == 2) names = spellNames;
            else names = itemNames;
        }

        public override void ModifyCommand(int offset, byte change)
        {
            commandData[offset] = change;
        }

        private string TrimTailSpaces(string src)
        {
            int lastIndex = src.Length - 1;

            while (src[lastIndex] == ' ' || src[lastIndex] == '\0')
                lastIndex--;

            return src.Substring(0, lastIndex + 1);
        }
        public override string ToString()
        {
            string[] bits = new string[8];
            bool before = false;

            string[] commandNames = new string[5];
            string[] name = new string[3];
            commandNames[2] = "Attack";
            commandNames[3] = "Special";
            commandNames[4] = "Item";
            string[] elementNames = new string[4];
            string[] statusNames = new string[8];

            switch (option)
            {
                case 1:
                    return "If attacked by command:  " +
                    commandNames[commandData[2]] +
                    "  /  " +
                    commandNames[commandData[3]];
                case 2:
                    for (int i = 0; i < 2; i++)
                    {
                        if (commandData[i + 2] == 0xFB) name[i] = "{Do nothing}";
                        else name[i] = "[" + commandData[i + 2].ToString("d3") + "]  " + names.GetNameByNum(commandData[i + 2]);
                        name[i] = TrimTailSpaces(name[i]);
                    }
                    return "If attacked by spell:  " + name[0] + "  /  " + name[1];
                case 3:
                    for (int i = 0; i < 2; i++)
                    {
                        if (commandData[i + 2] == 0xFB) name[i] = "{Do nothing}";
                        else name[i] = "[" + commandData[i + 2].ToString("d3") + "]  " + names.GetNameByNum(commandData[i + 2]);
                        name[i] = TrimTailSpaces(name[i]);
                    }
                    return "If attacked by item:  " + name[0] + "  /  " + name[1];
                case 4:
                    for (int i = 0x10, j = 0; i < 0x81; i *= 2, j++)
                    {
                        if ((commandData[2] & i) == i)
                        {
                            if (before && j > 0) elementNames[j] = " ,  ";

                            if (j == 0) elementNames[j] += "Ice";
                            else if (j == 1) elementNames[j] += "Thunder";
                            else if (j == 2) elementNames[j] += "Fire";
                            else elementNames[j] += "Jump";

                            before = true;
                        }
                        else elementNames[j] = "";
                    }

                    return "If attacked by element:  " +
                    elementNames[0] +
                    elementNames[1] +
                    elementNames[2] +
                    elementNames[3];
                case 5:
                    return "If attacked";
                case 6:
                    return "If target:  " + targetNames[commandData[2]] + " ,  " + "HP is below:  " + (commandData[3] * 16).ToString();
                case 7:
                    return "If HP is below:  " + ((commandData[3] * 0x100) + commandData[2]).ToString();
                case 8:
                    for (int i = 0x01, j = 0; i < 0x81; i *= 2, j++)
                    {
                        if ((commandData[3] & i) == i)
                        {
                            if (before && j > 0) statusNames[j] = " ,  ";

                            if (j == 0) statusNames[j] += "Mute";
                            else if (j == 1) statusNames[j] += "Sleep";
                            else if (j == 2) statusNames[j] += "Poison";
                            else if (j == 3) statusNames[j] += "Fear";
                            else if (j == 4) statusNames[j] += "";
                            else if (j == 5) statusNames[j] += "Mushroom";
                            else if (j == 6) statusNames[j] += "Scarecrow";
                            else if (j == 7) statusNames[j] += "Invincible";

                            before = true;
                        }
                        else statusNames[j] = "";
                    }

                    return "If target:  " +
                    targetNames[commandData[2]] +
                    " ,  is affected by status:  " +
                    statusNames[0] +
                    statusNames[1] +
                    statusNames[2] +
                    statusNames[3] +
                    statusNames[5] +
                    statusNames[6] +
                    statusNames[7];
                case 9:
                    for (int i = 0x01, j = 0; i < 0x81; i *= 2, j++)
                    {
                        if ((commandData[3] & i) == i)
                        {
                            if (before && j > 0) statusNames[j] = " ,  ";

                            if (j == 0) statusNames[j] += "Mute";
                            else if (j == 1) statusNames[j] += "Sleep";
                            else if (j == 2) statusNames[j] += "Poison";
                            else if (j == 3) statusNames[j] += "Fear";
                            else if (j == 4) statusNames[j] += "";
                            else if (j == 5) statusNames[j] += "Mushroom";
                            else if (j == 6) statusNames[j] += "Scarecrow";
                            else if (j == 7) statusNames[j] += "Invincible";

                            before = true;
                        }
                        else statusNames[j] = "";
                    }

                    return "If target:  " +
                    targetNames[commandData[2]] +
                    " ,  is NOT affected by status:  " +
                    statusNames[0] +
                    statusNames[1] +
                    statusNames[2] +
                    statusNames[3] +
                    statusNames[5] +
                    statusNames[6] +
                    statusNames[7];
                case 10:
                    return "If attack phase counter (7EE006) = " + commandData[2].ToString("d3");
                case 12:
                    return "If address:  7EE00" + commandData[2].ToString("X1") + " ,  is less than:  " + commandData[3].ToString("d3");
                case 13:
                    return "If address:  7EE00" + commandData[2].ToString("X1") + " ,  is greater than / equal to:  " + commandData[3].ToString("d3");
                case 16:
                    if (commandData[2] == 0) return "If target is alive:  " + targetNames[commandData[3]];
                    else if (commandData[2] == 1) return "If target is dead:  " + targetNames[commandData[3]];
                    else return "ERROR";
                case 17:
                    for (int i = 0x01, j = 0; i < 0x81; i *= 2, j++)
                    {
                        if ((commandData[3] & i) == i)
                        {
                            if (before && j > 0) bits[j] = " ,  ";
                            bits[j] += j.ToString();

                            before = true;
                        }
                        else bits[j] = "";
                    }

                    return "If memory address:  7EE00" +
                        commandData[2].ToString("X1") +
                        " ,  bit(s) are set:  " +
                        bits[0] +
                        bits[1] +
                        bits[2] +
                        bits[3] +
                        bits[4] +
                        bits[5] +
                        bits[6] +
                        bits[7];
                case 18:
                    for (int i = 0x01, j = 0; i < 0x81; i *= 2, j++)
                    {
                        if ((commandData[3] & i) == i)
                        {
                            if (before && j > 0) bits[j] = " ,  ";
                            bits[j] += j.ToString();

                            before = true;
                        }
                        else bits[j] = "";
                    }

                    return "If memory address:  7EE00" +
                        commandData[2].ToString("X1") +
                        " ,  bit(s) are clear:  " +
                        bits[0] +
                        bits[1] +
                        bits[2] +
                        bits[3] +
                        bits[4] +
                        bits[5] +
                        bits[6] +
                        bits[7];
                case 19:
                    return "If in formation:  " + ((commandData[3] * 0x100) + commandData[2]).ToString();
                case 20:
                    return "If only one monster alive";
                default: return "ERROR";
            }
        }

    }

}
