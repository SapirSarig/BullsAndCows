namespace B17_Ex05
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using System.Drawing;

    public class NumOfChancesButton : Button
    {
        private const ushort k_MinNumOfChances = 4; 
        private const ushort k_MaxNumOfChances = 10;
        private const ushort k_NumOfChancesButtonWidth = 200;
        private const ushort k_NumOfChancesButtonHeight = 20;
        private ushort m_NumOfChances = k_MinNumOfChances;

        public NumOfChancesButton()
        {
            this.Width = k_NumOfChancesButtonWidth;
            this.Height = k_NumOfChancesButtonHeight;
            this.Location = new Point(8, 8);
            SetText();
            this.Show();
        }

        public void SetText()
        {
            this.Text = string.Format("Number of Chances: {0}", m_NumOfChances);
        }

        public ushort NumOfChances
        {
            get { return m_NumOfChances; }
            set { m_NumOfChances = value; }
        }

        public ushort MinNumOfChances
        {
            get { return k_MinNumOfChances; }
        }
    }
}