namespace B17_Ex05
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Drawing;
    using System.Windows.Forms;

    public class RowOfColoredCells
    {
        private const ushort k_ButtonWidth = 40;
        private const ushort k_ButtonHeight = 40;
        private const ushort k_NumOfButtons = 4;
        private const ushort k_ChosenDistancePlace = 4;
        private Button[] m_Buttons;

        public RowOfColoredCells()
        {
            m_Buttons = new Button[k_NumOfButtons];
            for (int i = 0; i < k_NumOfButtons; i++)
            {
                m_Buttons[i] = new Button();
                m_Buttons[i].Size = new Size(k_ButtonWidth, k_ButtonHeight);
                m_Buttons[i].Show();
            }

            m_Buttons[0].Left += 2 * k_ChosenDistancePlace;
            m_Buttons[1].Left = m_Buttons[0].Right + k_ChosenDistancePlace;
            m_Buttons[2].Left = m_Buttons[1].Right + k_ChosenDistancePlace;
            m_Buttons[3].Left = m_Buttons[2].Right + k_ChosenDistancePlace;
        }

        public void SetButtonsLocation(int i_YPosition)
        {
            foreach (Button button in m_Buttons)
            {
                button.Top += i_YPosition;
            }
        }

        public Button[] Button
        {
            get { return m_Buttons; }
        }

        public int Bottom
        {
            get { return m_Buttons[0].Bottom; }
        }
    }
}
