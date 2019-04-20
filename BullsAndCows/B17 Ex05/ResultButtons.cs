namespace B17_Ex05
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using System.Drawing;

    public class ResultButtons
    {
        private const ushort k_NumOfButtons = 4;
        private const ushort k_ButtonHeight = 17;
        private const ushort k_ButtonWidth = 17;
        private Button[] m_ResultButtons;
       
        public ResultButtons(int i_TopLocation, int i_RightLocation)
        {
            m_ResultButtons = new Button[k_NumOfButtons];

            for (int i = 0; i < k_NumOfButtons; i++)
            {
                m_ResultButtons[i] = new Button();
                m_ResultButtons[i].Size = new Size(k_ButtonWidth, k_ButtonHeight);
                m_ResultButtons[i].Enabled = false;
            }

            m_ResultButtons[0].Left = i_RightLocation;
            m_ResultButtons[0].Top = i_TopLocation;

            m_ResultButtons[1].Left = m_ResultButtons[0].Right + 4;
            m_ResultButtons[1].Top = m_ResultButtons[0].Top;

            m_ResultButtons[2].Left = m_ResultButtons[0].Left;
            m_ResultButtons[2].Top = m_ResultButtons[0].Bottom + 4;

            m_ResultButtons[3].Left = m_ResultButtons[1].Left;
            m_ResultButtons[3].Top = m_ResultButtons[2].Top;
        }

        public Button[] Buttons
        {
            get { return m_ResultButtons; }
        }
    }
}
