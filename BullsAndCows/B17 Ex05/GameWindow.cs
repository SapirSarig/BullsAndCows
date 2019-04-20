namespace B17_Ex05
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using System.Drawing;

    public enum eColors
    {
        Purple,
        Red,
        LawnGreen,
        LightSkyBlue,
        Blue,
        Yellow,
        DarkRed,
        White
    }

    public class GameWindow : Form
    {
        private const ushort k_NumOfButtons = 8;
        private const ushort k_NumOfCellsInLine = 4;
        private const ushort k_NumOfResultButtonsInLine = 2;
        private readonly ushort r_NumOfChances;
        private RowOfColoredCells[] m_RowOfColoredCells;
        private Button[] m_CheckAnswerButtons;
        private ResultButtons[] m_ResultButtons;
        private RowOfColoredCells m_ComputersChoice;
        private PickAColorWindow m_PickAColorWindow;
        private ushort m_CurrUserChanceIndex;
        private GameLogic m_GameLogic;
        
        public GameWindow(ushort i_NumOfChances)
        {
            m_GameLogic = new GameLogic();
            int widthOfGameWindow, heightOfGameWindow;
            this.CenterToScreen();
            this.Top -= 100;
            this.Text = "Bool Pgia";
            r_NumOfChances = i_NumOfChances;
            setComputerChoiceLine();
            setLinesOfUserChances();
            setCheckAnswerButtons();
            setResultButtons();
            widthOfGameWindow = ((m_RowOfColoredCells[0].Button[0].Width + 8) * k_NumOfCellsInLine) + m_CheckAnswerButtons[0].Width + (k_NumOfResultButtonsInLine * m_ResultButtons[0].Buttons[0].Width) + 4;
            heightOfGameWindow = m_RowOfColoredCells[r_NumOfChances - 1].Button[0].Location.Y + 50;
            this.ClientSize = new Size(widthOfGameWindow, heightOfGameWindow);
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void setComputerChoiceLine()
        {
            m_ComputersChoice = new RowOfColoredCells();
            m_ComputersChoice.SetButtonsLocation(k_NumOfButtons);
            foreach (Button button in m_ComputersChoice.Button)
            {
                button.BackColor = Color.Black;
                button.Enabled = false;
                this.Controls.Add(button);
                button.Show();
            }
        }

        private void setResultButtons()
        {
            m_ResultButtons = new ResultButtons[r_NumOfChances];

            for (int i = 0; i < r_NumOfChances; i++)
            {
                m_ResultButtons[i] = new ResultButtons(m_RowOfColoredCells[i].Button[0].Top, m_CheckAnswerButtons[i].Right + 5);
                addAndShowButtonsToGameWindow(m_ResultButtons[i].Buttons);
            }
        }

        private void setCheckAnswerButtons()
        {
            m_CheckAnswerButtons = new Button[r_NumOfChances];

            for (int i = 0; i < r_NumOfChances; i++)
            {
                m_CheckAnswerButtons[i] = new Button();
                m_CheckAnswerButtons[i].Text = "-->>";
                m_CheckAnswerButtons[i].Size = new Size(m_RowOfColoredCells[i].Button[0].Width, 20);
                m_CheckAnswerButtons[i].Top = m_RowOfColoredCells[i].Button[0].Top + 8;
                m_CheckAnswerButtons[i].Left += m_RowOfColoredCells[i].Button[3].Right + 3;
                m_CheckAnswerButtons[i].Enabled = false;
                m_CheckAnswerButtons[i].Click += new EventHandler(checkAnswerButtonClicked);
                this.Controls.Add(m_CheckAnswerButtons[i]);
                m_CheckAnswerButtons[i].Show();
            }
        }

        private void checkAnswerButtonClicked(object sender, EventArgs e)
        {
            ushort boolCounter = 0, pgiaCounter = 0;

            (sender as Button).Enabled = false;
            disableTheCellsOfColors();
            m_GameLogic.CheckUserGuess(m_RowOfColoredCells[m_CurrUserChanceIndex], ref boolCounter, ref pgiaCounter);
            setResultButtons(boolCounter, pgiaCounter);
            m_CurrUserChanceIndex++;
        }

        private void disableTheCellsOfColors()
        {
            foreach (Button button in m_RowOfColoredCells[m_CurrUserChanceIndex].Button)
            {
                button.Enabled = false;
            }
        }

        private void setResultButtons(ushort i_boolCounter, ushort i_PgiaCounter)
        {
            ushort writeIndex = 0;
            for (int i = 0; i < i_boolCounter; i++)
            {
                m_ResultButtons[m_CurrUserChanceIndex].Buttons[writeIndex].BackColor = Color.Black;
                writeIndex++;
            }

            for (int i = 0; i < i_PgiaCounter; i++)
            {
                m_ResultButtons[m_CurrUserChanceIndex].Buttons[writeIndex].BackColor = Color.Yellow;
                writeIndex++;
            }

            if (i_boolCounter == k_NumOfCellsInLine)
            {
                winner();
            }
            else
            {
                if (m_CurrUserChanceIndex == r_NumOfChances - 1)
                {
                    lost();
                }
            }
        }

        private void winner()
        {
            showComputerChoice();
            if (m_CurrUserChanceIndex < r_NumOfChances - 1)
            {
                enableAllButtons();
            }
        }

        private void lost()
        {
            showComputerChoice();
        }

        private void enableAllButtons()
        {
            for (int i = m_CurrUserChanceIndex + 1; i < r_NumOfChances; i++)
            {
                foreach (Button button in m_RowOfColoredCells[i].Button)
                {
                    button.Enabled = false;
                }
            }
        }

        private void showComputerChoice()
        {
            ushort read = 0;

            foreach (Button button in m_ComputersChoice.Button)
            {
                button.BackColor = m_GameLogic.ComputerChoice[read];
                read++;
                button.Show();
            }
        }

        private void setLinesOfUserChances()
        {
            m_RowOfColoredCells = new RowOfColoredCells[r_NumOfChances];

            for (int i = 0; i < r_NumOfChances; i++)
            {
                m_RowOfColoredCells[i] = new RowOfColoredCells();
            }

            m_RowOfColoredCells[0].SetButtonsLocation(m_ComputersChoice.Bottom + 20);

            for (int i = 1; i < r_NumOfChances; i++)
            {
                m_RowOfColoredCells[i].SetButtonsLocation(m_RowOfColoredCells[i - 1].Bottom + 8);
            }

            foreach (RowOfColoredCells Line in m_RowOfColoredCells)
            {
                foreach (Button button in Line.Button)
                {
                    button.Click += new EventHandler(cellClicked);
                    this.Controls.Add(button);
                    button.Show();
                }
            }
        }

        private void cellClicked(object sender, EventArgs e)
        {
            m_PickAColorWindow = new PickAColorWindow();
            if (m_PickAColorWindow.IsColorChosen)
            {
                (sender as Button).BackColor = m_PickAColorWindow.ColorPicked;
            }

            checkAndActionIfButtonsAreColored();
        }

        private void checkAndActionIfButtonsAreColored()
        {
            bool v_isAllColored = true;
            foreach (Button button in m_RowOfColoredCells[m_CurrUserChanceIndex].Button)
            {
                if (button.UseVisualStyleBackColor)
                {
                    v_isAllColored = false;
                }
            }

            if (v_isAllColored)
            {
                m_CheckAnswerButtons[m_CurrUserChanceIndex].Enabled = true;
            }
        }

        private void addAndShowButtonsToGameWindow(Button[] i_ButtonsArr)
        {
            foreach (Button button in i_ButtonsArr)
            {
                this.Controls.Add(button);
                button.Show();
            }
        }
    }
}
