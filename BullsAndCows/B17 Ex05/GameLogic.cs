namespace B17_Ex05
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using System.Drawing;

    public class GameLogic
    {
        private const ushort k_NumberOfColorsToChooseFrom = 8;
        private const ushort k_NumberOfColors = 4;
        private readonly Array r_ColorsArray = Enum.GetValues(typeof(eColors));
        private Color[] m_ComputerChoice;
        
        public GameLogic()
        {
            setRandomColorsForComputerChoice();
        }

        public Color[] ComputerChoice
        {
            get { return m_ComputerChoice; }
        }

        private void setRandomColorsForComputerChoice()
        {
            Random randomIndex = new Random();
            bool[] chosenColors = new bool[k_NumberOfColorsToChooseFrom];
            int indexForColors;
            m_ComputerChoice = new Color[k_NumberOfColors];

            for (int i = 0; i < k_NumberOfColorsToChooseFrom; i++)
            {
                chosenColors[i] = false;
            }

            for (int i = 0; i < k_NumberOfColors; i++)
            {
                do
                {
                    indexForColors = randomIndex.Next(0, k_NumberOfColorsToChooseFrom);
                }
                while (chosenColors[indexForColors]);

                m_ComputerChoice[i] = Color.FromName(r_ColorsArray.GetValue(indexForColors).ToString());
                chosenColors[indexForColors] = true;
            }
        }

        public void CheckUserGuess(RowOfColoredCells i_UserChanceLineToCheck, ref ushort io_boolCounter, ref ushort io_PgiaCounter)
        {
            Button[] buttonsArray = i_UserChanceLineToCheck.Button;
            ushort readIndexForButtons = 0, readIndexForColors = 0;

            foreach (Button button in buttonsArray)
            {
                foreach (Color color in m_ComputerChoice)
                {
                    if (button.BackColor.Equals(color))
                    {
                        if (readIndexForColors == readIndexForButtons)
                        {
                            io_boolCounter++;
                        }
                        else
                        {
                            io_PgiaCounter++;
                        }

                        readIndexForColors = 0;
                        break;
                    }
                    else
                    {
                        readIndexForColors++;
                    }
                }

                readIndexForButtons++;
                readIndexForColors = 0;
            }
        }
    }
}
