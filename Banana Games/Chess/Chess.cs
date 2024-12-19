using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Banana_Games.Chess.Piece;

namespace Banana_Games.Chess
{
    public partial class Chess : Form
    {
        Board board;
        private Piece.Piece SelectedPiece { get; set; }
        public Chess()
        {
            InitializeComponent(); //Formun görsel bileşenlerini (butonlar, paneller vb.) hazırlar.
            board = new Board();    // Obje tanımlamadan yapıcı metod ile satranç tahtasını oluşturur.
            board.SaveStatus(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\book\learn.txt", board);
            /* 
            System.IO.Directory.GetCurrentDirectory() --> programın çalıştığı dosya dizin klasörünü alır.
            Directory.GetParent(...).Parent.Parent --> parent metodu ile 3 defa kullanılarak üst klasöre çıkılır yani projenin kök klasörüne ulaşırız. C:\Users\sonme\Desktop\development\c_sharp\ChessAIForms
            FullName + @"\history\memory.txt" --> bulunan dizinin tam yolunu alır ve \history\memory.txt eklenir. Final Yol: C:\Users\sonme\Desktop\development\c_sharp\ChessAI\history\memory.txt
            board.SaveStatus --> book.cs dosyasında ne yapıldığını yazdım.
            */
            updateUI(); //Oyun ekranını günceller ve hangi oyuncunun sırası olduğunu gösterir.

        }

        // oyun bilgisinin güncellenmesini sağlar.
        private void updateUI()
        {
            playerTurn.Text = board.Turn.ToString(); // sıranın kimde olacağını belirleriz. label'a yazdırır.
            if (SelectedPiece != null)
            {
                if (SelectedPiece.GetType() == typeof(Pawn))
                {
                    pieceselect.Text = "Pawn";
                }
                else if (SelectedPiece.GetType() == typeof(Rook))
                {
                    pieceselect.Text = "Rook";
                }
                else if (SelectedPiece.GetType() == typeof(Knight))
                {
                    pieceselect.Text = "Knight";
                }
                else if (SelectedPiece.GetType() == typeof(Bishop))
                {
                    pieceselect.Text = "Bishop";
                }
                else if (SelectedPiece.GetType() == typeof(Queen))
                {
                    pieceselect.Text = "Queen";
                }
                else if (SelectedPiece.GetType() == typeof(King))
                {
                    pieceselect.Text = "King";
                }
                selectX.Text = (SelectedPiece._position.x + 1).ToString(); // kullanıcı daha rahat okuması amaçlı 1 ekledik kordinatlara.
                selectY.Text = (SelectedPiece._position.y + 1).ToString();
            }
            else
            {
                pieceselect.Text = "null";
                selectX.Text = "null";
                selectY.Text = "null";
            }
            if (board.CheckMate == true)
            {
                board.SaveStatus(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\book\learn.txt", board);
                if (board.Turn == Player.White)
                {
                    List<Move> list = Board.GetAllLegalMoves(Player.Black, board);
                    foreach (Move move in list)
                    {
                        if (move.EndTile == Board.GetKingPosition(board.Pieces, Type.wKing))
                        {
                            MessageBox.Show("You Lose!");
                            this.Close();
                        }
                    }
                    MessageBox.Show("Draw!");
                    this.Close();
                }
                if (board.Turn == Player.Black)
                {
                    List<Move> list = Board.GetAllLegalMoves(Player.White, board);

                    foreach (Move move in list)
                    {
                        if (move.EndTile == Board.GetKingPosition(board.Pieces, Type.bKing))
                        {
                            MessageBox.Show("You Win!");
                            this.Close();

                        }
                    }
                    MessageBox.Show("Draw!");
                    this.Close();
                }
            }
        }

        //taşların çizimi
        public void DrawPiece(PaintEventArgs e, Player player, string white, string black, int i, int j)
        {
            Font drawFont = new Font("Arial", 26);
            SolidBrush textBrush = new SolidBrush(System.Drawing.Color.Black);
            int width = panel145.Width / 8;
            int height = panel145.Height / 8;

            switch (player)
            {
                case Player.White:
                    e.Graphics.DrawString(white, drawFont, textBrush, width / 8 + j * width, 8 * height - (7 * height / 9 + i * height));
                    break;
                case Player.Black:
                    e.Graphics.DrawString(black, drawFont, textBrush, width / 8 + j * width, 8 * height - (7 * height / 9 + i * height));
                    break;
            }
        }

        //Panel ile karoların çizimi
        public void DrawSquare(PaintEventArgs e, int x, int y)
        {
            Brush brush;
            if ((x + y) % 2 == 0)
            {
                brush = Brushes.White;
                if (SelectedPiece != null && SelectedPiece._position.x == x && SelectedPiece._position.y == y - 1)
                {
                    brush = Brushes.Yellow;
                }
            }
            else if (SelectedPiece != null && SelectedPiece._position.x == x && SelectedPiece._position.y == y - 1)
            {
                brush = Brushes.Yellow;
            }
            else
            {
                brush = Brushes.Green;
            }

            if (SelectedPiece != null)
            {
                int tile = SelectedPiece._position.x + SelectedPiece._position.y * 8;
                foreach (int move in SelectedPiece.LegalMoves(tile, board))
                {
                    int m = move / 8;
                    int n = move - m * 8;
                    if (m == y - 1 && n == x)
                    {
                        brush = Brushes.Red;
                    }
                }
            }

            int xPanel, yPanel;
            int width = panel145.Width / 8;
            int height = panel145.Height / 8;
            xPanel = x * width;
            yPanel = panel145.Height - height * y;
            e.Graphics.FillRectangle(brush, xPanel, yPanel, width, height);
        }

        //Taşların kendisi 
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Brush darkSquare = Brushes.Sienna;
            Brush lightSquare = Brushes.White;
            Font drawFont = new Font("Arial", 16);
            SolidBrush textBrush = new SolidBrush(System.Drawing.Color.Black);
            int width = panel145.Width / 8;
            int height = panel145.Height / 8;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j <= 8; j++)
                {
                    DrawSquare(e, i, j);
                }
            }


            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    int tile = x + y * 8;


                    if (board.Pieces[tile] != null)
                    {
                        Player player = board.Pieces[tile].Player;
                        if (board.Pieces[tile].GetType() == typeof(Pawn))
                        {
                            DrawPiece(e, player, "♙", "♟", y, x);
                        }
                        else if (board.Pieces[tile].GetType() == typeof(Rook))
                        {
                            DrawPiece(e, player, "♖", "♜", y, x);
                        }
                        else if (board.Pieces[tile].GetType() == typeof(Knight))
                        {
                            DrawPiece(e, player, "♘", "♞", y, x);
                        }
                        else if (board.Pieces[tile].GetType() == typeof(Bishop))
                        {
                            DrawPiece(e, player, "♗", "♝", y, x);
                        }
                        else if (board.Pieces[tile].GetType() == typeof(Queen))
                        {
                            DrawPiece(e, player, "♕", "♛", y, x);
                        }
                        else if (board.Pieces[tile].GetType() == typeof(King))
                        {
                            DrawPiece(e, player, "♔", "♚", y, x);
                        }
                    }
                }
            }
        }

        //Kullanıcının mouse ile oynayabilmesi için
        private void Chess_MouseClick(object sender, MouseEventArgs e)
        {
            if (board.Turn == Player.White)
            {
                decimal width = panel145.Width / 8;
                decimal height = panel145.Height / 8;

                decimal x = e.X / width;
                decimal i = Math.Floor(x);
                decimal y = e.Y / height;
                decimal j = 7 - Math.Floor(y);

                decimal clickedSquarePoint = (j * 8 + i);
                int clicked = Convert.ToInt32(clickedSquarePoint);
                Piece.Piece p = board.Pieces[clicked];
                if (SelectedPiece == null && p != null)
                {
                    if (p.Player == board.Turn)
                    {
                        SelectedPiece = p;
                        panel145.Invalidate();

                    }
                    else
                    {
                        MessageBox.Show("This is black piece");
                    }
                }
                else
                {
                    if (p != null && p.Player == board.Turn)
                    {
                        SelectedPiece = p;
                        panel145.Invalidate();
                    }
                    else
                    {
                        if (SelectedPiece != null)
                        {
                            int m = SelectedPiece._position.x;
                            int n = SelectedPiece._position.y;
                            int tile = (m + n * 8);

                            if (board.GetMove(tile, clicked, board) == false)
                            {
                                MessageBox.Show("Can't move");
                            }


                            SelectedPiece = null;
                            panel145.Invalidate();

                        }
                        else
                        {
                            SelectedPiece = null;
                        }
                    }
                }
                updateUI();
            }
        }

        private void panel145_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Chess_Load(object sender, EventArgs e)
        {

        }
    }
}
