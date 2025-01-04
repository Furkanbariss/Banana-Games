




using System;
using System.Windows.Forms;

namespace Banana_Games
{
    public partial class XoxForm : Form
    {
        private bool isXTurn = true; // Oyuncu s�ras� (X ba�lar)
        private string[,] board = new string[3, 3]; // Oyun tahtas�

        public XoxForm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton.Text == "") // E�er buton bo�sa
            {
                clickedButton.Text = isXTurn ? "X" : "O";
                UpdateBoard(clickedButton);
                if (CheckWinner())
                {
                    label1.Text = $"{(isXTurn ? "X" : "O")} Kazand�!";
                    DisableButtons();
                }
                else if (IsDraw())
                {
                    label1.Text = "Beraberlik!";
                }
                else
                {
                    isXTurn = !isXTurn; // S�ray� de�i�tir
                    label1.Text = $"S�ra: {(isXTurn ? "X" : "O")}";
                }
            }
        }

        private void UpdateBoard(Button button)
        {
            int row = button.TabIndex / 3;
            int col = button.TabIndex % 3;
            board[row, col] = button.Text;
        }

        private bool CheckWinner()
        {
            // Sat�r ve s�tun kontrol�
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2] && !string.IsNullOrEmpty(board[i, 0]))
                    return true;
                if (board[0, i] == board[1, i] && board[1, i] == board[2, i] && !string.IsNullOrEmpty(board[0, i]))
                    return true;
            }
            // �apraz kontrol�
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && !string.IsNullOrEmpty(board[0, 0]))
                return true;
            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && !string.IsNullOrEmpty(board[0, 2]))
                return true;

            return false;
        }

        private bool IsDraw()
        {
            foreach (string cell in board)
            {
                if (string.IsNullOrEmpty(cell))
                    return false;
            }
            return true;
        }

        private void DisableButtons()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button button && button.Name != "btnReset")
                {
                    button.Enabled = false;
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button button && button.Name != "btnReset")
                {
                    button.Text = "";
                    button.Enabled = true;
                }
            }
            board = new string[3, 3];
            isXTurn = true;
            label1.Text = "S�ra: X";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
