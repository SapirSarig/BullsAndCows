namespace B17_Ex05
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using System.Drawing;

    public class Game
    {
        private StartWindow m_StartWindow;
        private GameWindow m_GameWindow;

        public void Run()
        {
            m_StartWindow = new StartWindow();
            m_StartWindow.ShowDialog();

            if (m_StartWindow.IsStartButtonClicked)
            {
                m_GameWindow = new GameWindow(m_StartWindow.NumOfChances);
                m_GameWindow.ShowDialog();
            }
        }
    }
}
