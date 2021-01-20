using System;
using System.Windows.Forms;

namespace DrawMapping
{
    public partial class MainForm : Form
    {
        private int row = 0;
        private int column = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void genButton_Click(object sender, EventArgs e)
        {
            bool canParse = int.TryParse(xTextBox.Text.Trim(), out int x);
            canParse &= int.TryParse(yTextBox.Text.Trim(), out int y);

            if (!canParse) return;

            mapping.InitializeMapping(x, y);
            row = 0; column = 0;
        }

        private void fillButton_Click(object sender, EventArgs e)
        {
            if (column >= mapping.YCount) return;

            mapping.FillRect(row, column, fillTextBox.Text.Trim());
            row++;
            if (row >= mapping.XCount)
            {
                column++;
                row = 0;
            }
            if (column < mapping.YCount)
            {
                mapping.FocusRect(row, column);
            }
        }
    }
}
