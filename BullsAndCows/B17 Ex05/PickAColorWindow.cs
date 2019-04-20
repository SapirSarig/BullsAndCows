namespace B17_Ex05
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using System.Drawing;

    public class PickAColorWindow : Form
    {
        private const ushort k_NumOfButtonsInEachLine = 4;
        private const ushort k_NumOfLines = 2;
        private const ushort k_PickAColorWindowWidth = 300;
        private const ushort k_PickAColorWindowHeight = 100;
        private readonly Array r_ColorsArray = Enum.GetValues(typeof(eColors));
        private RowOfColoredCells[] m_RowOfColoredCells;
        private Color m_UserColorChoice;
        private bool v_IsColorChosen;

        public PickAColorWindow()
        {
            this.Size = new Size(k_PickAColorWindowWidth, k_PickAColorWindowHeight);
            this.Text = "Pick A Color:";
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.CenterToScreen();
            m_RowOfColoredCells = new RowOfColoredCells[k_NumOfLines];

            for (int i = 0; i < k_NumOfLines; i++)
            {
                m_RowOfColoredCells[i] = new RowOfColoredCells();
            }

            m_RowOfColoredCells[0].SetButtonsLocation(8);
            m_RowOfColoredCells[1].SetButtonsLocation(m_RowOfColoredCells[0].Button[0].Bottom + k_NumOfButtonsInEachLine);
            setColorsAndShowButtons();
            this.ClientSize = new Size((m_RowOfColoredCells[0].Button[0].Width * k_NumOfButtonsInEachLine) + 30, (m_RowOfColoredCells[0].Button[0].Height * k_NumOfLines) + 20);
            this.ShowDialog();
        }

        public bool IsColorChosen
        {
            get { return v_IsColorChosen; }
        }

        public Color ColorPicked
        {
            get { return m_UserColorChoice; }
        }

        private void setColorsAndShowButtons()
        {
            ushort readIndex = 0;
            for (int i = 0; i < k_NumOfLines; i++)
            {
                for (int j = 0; j < k_NumOfButtonsInEachLine; j++)
                {
                    m_RowOfColoredCells[i].Button[j].BackColor = Color.FromName(r_ColorsArray.GetValue(readIndex).ToString());
                    readIndex++;
                }
            }

            addAndShowButtons();
        }

        private void addAndShowButtons()
        {
            foreach (RowOfColoredCells line in m_RowOfColoredCells)
            {
                foreach (Button button in line.Button)
                {
                    button.Click += new EventHandler(colorButtonClicked);
                    this.Controls.Add(button);
                    button.Show();
                }
            }
        }

        private void colorButtonClicked(object sender, EventArgs e)
        {
            v_IsColorChosen = true;
            m_UserColorChoice = (sender as Button).BackColor;
            this.Close();
        }

        public Array ColorsArray
        {
            get { return r_ColorsArray; }
        }
    }
}
