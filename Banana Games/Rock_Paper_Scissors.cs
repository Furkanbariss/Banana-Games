using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Banana_Games
{
    public partial class Rock_Paper_Scissors : Form
    {
        private int playerScore = 0;
        private int computerScore = 0;

        public Rock_Paper_Scissors()
        {
            InitializeComponent();
        }

        private void Rock_Paper_Scissors_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(34, 58, 95); // Arka plan rengi
            panelResults.Visible = false;
        }

        private void btnRock_Click(object sender, EventArgs e)
        {
            PlayGame("Rock");
            btnRock.Visible = false;
            btnPaper.Visible = false;
            btnScissors.Visible = false;
        }

        private void btnPaper_Click(object sender, EventArgs e)
        {
            PlayGame("Paper");
            btnRock.Visible = false;
            btnPaper.Visible = false;
            btnScissors.Visible = false;
        }

        private void btnScissors_Click(object sender, EventArgs e)
        {
            PlayGame("Scissors");
            btnRock.Visible = false;
            btnPaper.Visible = false;
            btnScissors.Visible = false;
        }

        private void PlayGame(string playerChoice)
        {
            string[] choices = { "Rock", "Paper", "Scissors" };
            Random random = new Random();
            string computerChoice = choices[random.Next(choices.Length)];

            panelResults.Controls.Clear();
            ShowGameResult(playerChoice, computerChoice);

            // Skoru güncelle
            if (playerChoice == computerChoice)
            {
                ShowResultText("IT'S A DRAW!");
            }
            else if ((playerChoice == "Rock" && computerChoice == "Scissors") ||
                     (playerChoice == "Paper" && computerChoice == "Rock") ||
                     (playerChoice == "Scissors" && computerChoice == "Paper"))
            {
                playerScore++;
                ShowResultText("YOU WON!");
                scoreYou.Text = playerScore.ToString();
            }
            else
            {
                computerScore++;
                ShowResultText("YOU LOST!");
                scoreCom.Text = computerScore.ToString();
            }
        }

        private void ShowGameResult(string playerChoice, string computerChoice)
        {
            panelResults.Visible = true;

            // Oyuncu ve bilgisayar seçim resimleri
            PictureBox playerPicture = new PictureBox
            {
                Image = GetChoiceImage(playerChoice),
                SizeMode = PictureBoxSizeMode.Zoom,
                Width = 100,
                Height = 100,
                Location = new Point(0, 50),
                BackColor = Color.Goldenrod // Çerçeve etkisi
            };

            PictureBox computerPicture = new PictureBox
            {
                Image = GetChoiceImage(computerChoice),
                SizeMode = PictureBoxSizeMode.Zoom,
                Width = 100,
                Height = 100,
                Location = new Point(panelResults.Width - 100, 50),
                BackColor = Color.RoyalBlue // Çerçeve etkisi
            };

            // Oyuncu başlıkları
            Label lblPlayer = new Label
            {
                Text = "YOU",
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(0, 20),
                Width = 100,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label lblComputer = new Label
            {
                Text = "OPPONENT",
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(panelResults.Width - 120, 20),
                Width = 100,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // "Play Again" butonu
            Button btnPlayAgain = new Button
            {
                Text = "PLAY AGAIN",
                BackColor = Color.Orange,
                ForeColor = Color.Black,
                Font = new Font("Arial", 12, FontStyle.Bold),
                Width = 140,
                Height = 40,
                FlatStyle = FlatStyle.Flat,
                Location = new Point((panelResults.Width - 140) / 2, panelResults.Height - 80)
            };
            btnPlayAgain.Click += btnPlayAgain_Click;

            // Kontrolleri ekle
            panelResults.Controls.Add(playerPicture);
            panelResults.Controls.Add(computerPicture);
            panelResults.Controls.Add(lblPlayer);
            panelResults.Controls.Add(lblComputer);
            panelResults.Controls.Add(btnPlayAgain);
        }

        private void ShowResultText(string resultText)
        {
            Label lblResult = new Label
            {
                Text = resultText,
                Font = new Font("Arial", 16, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 50
            };
            panelResults.Controls.Add(lblResult);

        }

        private Image GetChoiceImage(string choice)
        {
            return choice switch
            {
                "Rock" => ımageList1.Images[1],// Taş resmi
                "Paper" => ımageList1.Images[4], // Kağıt resmi
                "Scissors" => ımageList1.Images[3], // Makas resmi
                _ => ımageList1.Images[6]
            };
        }

        private void btnPlayAgain_Click(object? sender, EventArgs e)
        {
            if(sender == null)
            {
                return;
            }

            panelResults.Controls.Clear();
            panelResults.Visible = false;
            btnRock.Visible = true;
            btnPaper.Visible = true;
            btnScissors.Visible = true;
        }

        private void btnRules_Click(object sender, EventArgs e)
        {
            Rules rules = new Rules();

            // Form2'yi göster
            rules.Show();

            // Eğer yeni form açıldığında mevcut formu gizlemek istiyorsanız:
            // this.Hide();
        }
    }
}
