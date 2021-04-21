using System;
using System.Windows.Forms;

namespace DrawMapping
{
    public partial class MainForm : Form
    {
        private System.Drawing.Point position;

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
            position.X = 0;
            position.Y = 0;
            mapping.Focus(0, 0);
        }

        private void fillButton_Click(object sender, EventArgs e)
        {
            if (position.X >= mapping.XCount) return;
            mapping.Fill(position.X, position.Y, fillTextBox.Text.Trim());
            if (position.X < mapping.XCount)
            {
                ++position.Y;
                if (position.Y >= mapping.YCount)
                {
                    ++position.X;
                    position.Y = 0;
                }
            }
            if (position.X < mapping.XCount && position.Y < mapping.YCount)
            {
                mapping.Focus(position.X, position.Y);
            }
        }
    }
}
