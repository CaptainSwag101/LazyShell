using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL
{
    public class PrioritySet
    {
        private byte[] data;
        private int prioritySetNum;

        private bool mainscreenL1; public bool MainscreenL1 { get { return mainscreenL1; } set { mainscreenL1 = value; } }
        private bool mainscreenL2; public bool MainscreenL2 { get { return mainscreenL2; } set { mainscreenL2 = value; } }
        private bool mainscreenL3; public bool MainscreenL3 { get { return mainscreenL3; } set { mainscreenL3 = value; } }
        private bool mainscreenOBJ; public bool MainscreenOBJ { get { return mainscreenOBJ; } set { mainscreenOBJ = value; } }
        public bool IsDrawingMainscreen(int layer)
        {
            switch (layer)
            {
                case 0:
                    return mainscreenL1;
                case 1:
                    return mainscreenL2;
                case 2:
                    return mainscreenL3;
                case 3:
                    return mainscreenOBJ;
                default:
                    return false;
            }
        }
        private bool subscreenL1; public bool SubscreenL1 { get { return subscreenL1; } set { subscreenL1 = value; } }
        private bool subscreenL2; public bool SubscreenL2 { get { return subscreenL2; } set { subscreenL2 = value; } }
        private bool subscreenL3; public bool SubscreenL3 { get { return subscreenL3; } set { subscreenL3 = value; } }
        private bool subscreenOBJ; public bool SubscreenOBJ { get { return subscreenOBJ; } set { subscreenOBJ = value; } }
        public bool IsDrawingSubscreen(int layer)
        {
            switch (layer)
            {
                case 0:
                    return subscreenL1;
                case 1:
                    return subscreenL2;
                case 2:
                    return subscreenL3;
                case 3:
                    return subscreenOBJ;
                default:
                    return false;
            }
        }
        private bool colorMathL1; public bool ColorMathL1 { get { return colorMathL1; } set { colorMathL1 = value; } }
        private bool colorMathL2; public bool ColorMathL2 { get { return colorMathL2; } set { colorMathL2 = value; } }
        private bool colorMathL3; public bool ColorMathL3 { get { return colorMathL3; } set { colorMathL3 = value; } }
        private bool colorMathOBJ; public bool ColorMathOBJ { get { return colorMathOBJ; } set { colorMathOBJ = value; } }
        private bool colorMathBG; public bool ColorMathBG { get { return colorMathBG; } set { colorMathBG = value; } }
        public bool IsDrawingColorMath(int layer)
        {
            switch (layer)
            {
                case 0:
                    return colorMathL1;
                case 1:
                    return colorMathL2;
                case 2:
                    return colorMathL3;
                case 3:
                    return colorMathOBJ;
                case 4:
                    return colorMathBG;
                default:
                    return false;
            }

        }
        private byte colorMathHalfIntensity; public byte ColorMathHalfIntensity { get { return colorMathHalfIntensity; } set { colorMathHalfIntensity = value; } }
        private byte colorMathMinusSubscreen; public byte ColorMathMinusSubscreen { get { return colorMathMinusSubscreen; } set { colorMathMinusSubscreen = value; } }

        public PrioritySet(byte[] data, int prioritySetNum)
        {
            this.data = data;
            this.prioritySetNum = prioritySetNum;

            InitializePrioritySet();
        }

        private void InitializePrioritySet()
        {
            int layerPriorityOffset = (prioritySetNum * 3) + 0x1D0000;

            int temp = BitManager.GetByte(data, layerPriorityOffset); layerPriorityOffset++;

            if ((temp & 0x01) == 0x01) mainscreenL1 = true;
            if ((temp & 0x02) == 0x02) mainscreenL2 = true;
            if ((temp & 0x04) == 0x04) mainscreenL3 = true;
            if ((temp & 0x10) == 0x10) mainscreenOBJ = true;

            temp = BitManager.GetByte(data, layerPriorityOffset); layerPriorityOffset++;

            if ((temp & 0x01) == 0x01) subscreenL1 = true;
            if ((temp & 0x02) == 0x02) subscreenL2 = true;
            if ((temp & 0x04) == 0x04) subscreenL3 = true;
            if ((temp & 0x10) == 0x10) subscreenOBJ = true;

            temp = BitManager.GetByte(data, layerPriorityOffset); layerPriorityOffset++;

            if ((temp & 0x01) == 0x01) colorMathL1 = true;
            if ((temp & 0x02) == 0x02) colorMathL2 = true;
            if ((temp & 0x04) == 0x04) colorMathL3 = true;
            if ((temp & 0x10) == 0x10) colorMathOBJ = true;
            if ((temp & 0x20) == 0x20) colorMathBG = true;
            if ((temp & 0x40) == 0x40) colorMathHalfIntensity = 1; else colorMathHalfIntensity = 0;
            if ((temp & 0x80) == 0x80) colorMathMinusSubscreen = 1; else colorMathMinusSubscreen = 0;
        }
        public void Assemble()
        {
            int offset = (prioritySetNum * 3) + 0x1D0000;

            BitManager.SetBit(data, offset, 0, mainscreenL1);
            BitManager.SetBit(data, offset, 1, mainscreenL2);
            BitManager.SetBit(data, offset, 2, mainscreenL3);
            BitManager.SetBit(data, offset, 4, mainscreenOBJ);

            offset++;

            BitManager.SetBit(data, offset, 0, subscreenL1);
            BitManager.SetBit(data, offset, 1, subscreenL2);
            BitManager.SetBit(data, offset, 2, subscreenL3);
            BitManager.SetBit(data, offset, 4, subscreenOBJ);

            offset++;

            BitManager.SetBit(data, offset, 0, colorMathL1);
            BitManager.SetBit(data, offset, 1, colorMathL2);
            BitManager.SetBit(data, offset, 2, colorMathL3);
            BitManager.SetBit(data, offset, 4, colorMathOBJ);
            BitManager.SetBit(data, offset, 5, colorMathBG);
            if (colorMathHalfIntensity == 1) BitManager.SetBit(data, offset, 6, true); else BitManager.SetBit(data, offset, 6, false);
            if (colorMathMinusSubscreen == 1) BitManager.SetBit(data, offset, 7, true); else BitManager.SetBit(data, offset, 7, false);
        }
    }
}