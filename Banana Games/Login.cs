using System.Drawing;
using System.Windows.Forms;
using System;

namespace Banana_Games
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;


        }

        private void button1_Click(object sender, EventArgs e) // Play Button
        {
            panel1.Visible = false;
            panel2.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)  //sudoku button
        {
            Sudoku.SudokuForm sudokuFormOpen = new Sudoku.SudokuForm();
            sudokuFormOpen.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e) // xox button
        {
            // Yeni formun bir örneğini oluştur 
            XoxForm xoxFormOpen = new XoxForm();
            xoxFormOpen.ShowDialog(); //oluşturulan yeni dormu açar
        }

        private void button5_Click(object sender, EventArgs e) // ROCK-PAPAER-SCİSSORS button
        {
            Rock_Paper_Scissors rpsFormOpen = new Rock_Paper_Scissors();
            rpsFormOpen.ShowDialog();
        }

        private void chessButton_Click(object sender, EventArgs e)
        {
            Chess.Chess chessFormOpen = new Chess.Chess();
            chessFormOpen.ShowDialog();
        }

        private void contactButton_Click(object sender, EventArgs e)
        {
           
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Uygulamayı tamamen kapatır
            Application.Exit();
        }

        private void button1_Enter(object sender, EventArgs e)
        {
            // Fare düğmenin üzerine geldiğinde arka planı yeşil yap
            //button1.BackColor = Color.Green;
        }

        private void button1_Leave(object sender, EventArgs e)
        {
            // Fare düğmeden ayrıldığında arka planı varsayılan yap
            button1.BackColor = SystemColors.Control;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
