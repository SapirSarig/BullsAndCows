namespace B17_Ex05
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using System.Drawing;

    public class StartWindow : Form
    {
        private const ushort k_MaxNumGuesses = 10;
        private Button m_StartButton;
        private NumOfChancesButton m_NumOfChancesButton;
        private ushort m_NumOfChances;
        private bool v_isStartButtonClicked;

        public StartWindow()
        {
            this.CenterToScreen();
            this.Text = "Bool Pgia";
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            initNumOfChancesButton();
            this.ClientSize = new Size(m_NumOfChancesButton.Width + 15, m_NumOfChancesButton.Height * 4);
            initStartButton();
        }

        private void initNumOfChancesButton()
        {
            m_NumOfChancesButton = new NumOfChancesButton();
            this.Controls.Add(m_NumOfChancesButton);
            m_NumOfChancesButton.Click += new EventHandler(numOfChancesButtonClicked);
            m_NumOfChances = m_NumOfChancesButton.MinNumOfChances; 
        }

        private void initStartButton()
        {
            m_StartButton = new Button();
            m_StartButton.Height = m_NumOfChancesButton.Height;
            m_StartButton.Width = m_NumOfChancesButton.Width / 3;
            m_StartButton.Location = new Point(m_NumOfChancesButton.Right - m_StartButton.Width, this.ClientSize.Height - m_StartButton.Height - 8);
            m_StartButton.Text = "Start";
            m_StartButton.Show();
            this.Controls.Add(m_StartButton);
            m_StartButton.Click += new EventHandler(startButtonClicked);
        }

        public ushort NumOfChances
        {
            get { return m_NumOfChances; }
        }

        private void numOfChancesButtonClicked(object sender, EventArgs e)
        {
            if ((sender as NumOfChancesButton).NumOfChances < k_MaxNumGuesses)
            {
                (sender as NumOfChancesButton).NumOfChances++;
                (sender as NumOfChancesButton).SetText();
                m_NumOfChances = (sender as NumOfChancesButton).NumOfChances;
            }
        }

        private void startButtonClicked(object sender, EventArgs e)
        {
            v_isStartButtonClicked = true;
            this.Close();
        }

        public bool IsStartButtonClicked
        {
            get { return v_isStartButtonClicked; }
        }
    }
}
