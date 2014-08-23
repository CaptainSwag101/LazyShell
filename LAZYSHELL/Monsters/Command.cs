using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.EventScripts;

namespace LAZYSHELL.Monsters
{
    [Serializable()]
    public class Command : LAZYSHELL.Command
    {
        #region Variables

        public bool Locked = true;
        public bool Valid { get; set; }

        #endregion

        // Constructor
        public Command(byte[] commandData)
        {
            this.Data = commandData;
        }

        #region Methods

        public TreeNode Node
        {
            get
            {
                TreeNode node = new TreeNode(ToString());
                if (Opcode == 0xFD || Opcode == 0xFE)
                    node.BackColor = Color.FromArgb(255, 255, 200);
                else if (Opcode == 0xFF)
                    node.BackColor = Color.FromArgb(208, 255, 208);
                node.ForeColor = Modified ? Color.Red : SystemColors.ControlText;
                node.Checked = Modified;
                node.Tag = this;
                return node;
            }
        }
        public Command Copy()
        {
            return new Command(Bits.Copy(Data));
        }
        public override string ToString()
        {
            return Parser.ParseCommand(this);
        }

        #endregion
    }
}
