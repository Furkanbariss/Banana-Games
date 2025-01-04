using System;
using System.Windows.Forms;

namespace Banana_Games.Sudoku
{
    public partial class NumpadGrid9Dialog : Form
    {
        public int Value { get; set; } = -1;
        
        public NumpadGrid9Dialog()
        {
            InitializeComponent();
        }

        private void BtnNumber_Click(object sender, EventArgs e)
        {
            Value = Convert.ToInt32((sender as Button).Text);
            Close();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            Value = 0;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}