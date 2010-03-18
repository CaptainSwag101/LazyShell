using System;
using System.Collections.Generic;
using System.Text;

namespace SMRPGED.Undo
{
    class NewComboBox : System.Windows.Forms.ComboBox
    {
        private int lastValue = 0; public int LastValue { get { return lastValue; } set { lastValue = value; } }    
    }
}
