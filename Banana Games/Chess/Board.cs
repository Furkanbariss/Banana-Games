using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using System.Collections;
using System.Net.NetworkInformation;
using Banana_Games.Chess.Piece;
using Banana_Games.Chess.lib;

namespace Banana_Games.Chess
{
    public class Board
    {
        
        private Piece.Piece[] _pieces  = new Piece.Piece[64];
        private Player _turn = Player.White;
        private bool _checkMate = false; //şah mat kontrolü

        //Yapay zekanın ilk üç hamlede rastgele hareket yapması için kullanılan bir sayaç.
        private int _firstThreeMoves = 0;

        public Piece.Piece[] Pieces { get => _pieces; set => _pieces = value; }
        public bool CheckMate { get => _checkMate; set => _checkMate = value; }
        public Player Turn { get => _turn; set => _turn = value; }

        //taşları yerlerine yerleştirdik.
        public Board()
        {
            // beyazlar
            //uzun uzun yazmaktansa piyonları for döngüsü ile tek sırra halinde ekleemek daha kısa.
            for (int i = 0; i < 8; i++)
                Pieces[8 + i] = new Piece.Pawn(Type.wPawn, Player.White, 8 + i);

            Pieces[0] = new Piece.Rook(Type.wRook, Player.White, 0);
            Pieces[1] = new Piece.Knight(Type.wKnight, Player.White, 1);
            Pieces[2] = new Piece.Bishop(Type.wBishop, Player.White, 2);
            Pieces[3] = new Piece.Queen(Type.wQueen, Player.White, 3);
            Pieces[4] = new Piece.King(Type.wKing, Player.White, 4);
            Pieces[5] = new Piece.Bishop(Type.wBishop, Player.White, 5);
            Pieces[6] = new Piece.Knight(Type.wKnight, Player.White, 6);
            Pieces[7] = new Piece.Rook(Type.wRook, Player.White, 7);

            //siyahlar
            for (int i = 0; i < 8; i++)
                Pieces[48 + i] = new Piece.Pawn(Type.bPawn, Player.Black, 48 + i);

            Pieces[56] = new Piece.Rook(Type.bRook, Player.Black, 56);
            Pieces[57] = new Piece.Knight(Type.bKnight, Player.Black, 57);
            Pieces[58] = new Piece.Bishop(Type.bBishop, Player.Black, 58);
            Pieces[59] = new Piece.Queen(Type.bQueen, Player.Black, 59);
            Pieces[60] = new Piece.King(Type.bKing, Player.Black, 60);
            Pieces[61] = new Piece.Bishop(Type.bBishop, Player.Black, 61);
            Pieces[62] = new Piece.Knight(Type.bKnight, Player.Black, 62);
            Pieces[63] = new Piece.Rook(Type.bRook, Player.Black, 63);

            Turn = Player.White;

        }

        //Belirtilen karedeki taşın yapabileceği yasal hareketleri döner.
        public static List<int> GetLegalMoves(int tile, Board board)
        {
            List<int> legalMoves = new List<int>();
            if (board.Pieces[tile] != null)
                legalMoves = board.Pieces[tile].LegalMoves(tile, board);

            return legalMoves;
        }

        //Tüm taşların yapabileceiği legal hamleler.
        public static List<Move> GetAllLegalMoves(Player player, Board board, bool filter = true)
        {
            List<Move> allLegalMoves = new List<Move>();
            List<int> allPieces = GetPieces(board.Pieces, player);

            foreach (var tile in allPieces)
            {
                List<int> legalMoves = GetLegalMoves(tile, board);

                foreach (var move in legalMoves)
                {
                    allLegalMoves.Add(new Move(tile, move));
                }
            }

            return filter == true ?
            Piece.MoveGen.FilterIlegalMoves(allLegalMoves, board) : allLegalMoves;
        }

        // tahtadaki taşların yerlerini liste şeklinde döndürüren liste yukarıda kullanmak için.
        public static List<int> GetPieces(Piece.Piece[] pieces, Player player)
        {
            List<int> allPieces = new List<int>();

            for (int i = 0; i < pieces.Length; i++)
            {
                if (pieces[i] == null)
                {
                    continue;
                }
                else if (pieces[i].Player == player)
                {
                    allPieces.Add(i);
                }
            }
            return allPieces;
        }

        //taşların hareket etme mantığı
        public static void MovePiece(Board board, int StartTile, int EndTile)
        {
            //  Taşın ilk hareketini işaretle
            if (board.Pieces[StartTile] != null)
            {
                if (board.Pieces[StartTile].Moved == false)
                {
                    board.Pieces[StartTile].SetMoved(true);
                }

                // Taşı hedef kareye koy ve mevcut kareyi boş bırak
                board.Pieces[EndTile] = board.Pieces[StartTile];
                board.Pieces[StartTile] = null;

                // Taşın yeni pozisyonunu güncelle
                board.Pieces[EndTile].ChangePosition(EndTile);


                KingCastled(board, StartTile, EndTile); //Rok kontrolü
                PawnPromoted(board.Pieces, EndTile); // Piyon terfi kontrolü
            }
        }

        // rok kontrol edilir 
        public static void KingCastled(Board board, int StartTile, int EndTile)
        {
            if (StartTile == 4 || StartTile == 60)
            {
                if (board.Pieces[EndTile].GetPiece == Type.wKing || board.Pieces[EndTile].GetPiece == Type.bKing)
                {
                    int rank = board.Pieces[EndTile].GetPiece == Type.wKing ? 7 : 63;

                    if (EndTile == rank - 1 && board.Pieces[rank].Moved == false)
                        MovePiece(board, rank, rank - 2);

                    else if (EndTile == rank - 5 && board.Pieces[rank - 7].Moved == false)
                        MovePiece(board, rank - 7, rank - 4);
                }
            }
        }

        // 😎 oğlun başardı anne! o artık bir vezir.
        public static bool PawnPromoted(Piece.Piece[] pieces, int move)
        {
            Coordinate position = new Coordinate(move);

            if (pieces[move].GetPiece == Type.wPawn && position.y == 7)
            {
                pieces[move] = new Piece.Queen(Type.wQueen, Player.White, move);
                return true;
            }

            else if (pieces[move].GetPiece == Type.bPawn && position.y == 0)
            {
                pieces[move] = new Piece.Queen(Type.bQueen, Player.Black, move);
                return true;
            }

            return false;
        }

        //krala şah çekilmişmi kontrol amaçlı
        public static bool KingChecked(Type king, Board board)
        {
            Piece.MoveGen.ValidateCastling = false; //krala şah çekilmişse rok yapılamaz.

            Player opponent = king == Type.wKing ? Player.Black : Player.White;
            List<Move> legalMoves = Board.GetAllLegalMoves(opponent, board, false);

            Piece.MoveGen.ValidateCastling = true;
            foreach (Move move in legalMoves)
            {
                if (move.EndTile == Board.GetKingPosition(board.Pieces, king))
                {
                    return true;
                }
            }
            return false;
        }

        //kralın yerini alır
        public static int GetKingPosition(Piece.Piece[] pieces, Type piece)
        {
            for (int i = 0; i < pieces.Length; i++)
            {
                if (pieces[i] != null)
                {
                    if (pieces[i].GetPiece == piece)
                    {
                        return i;
                    }
                }
            }
            return 0;
        }

        //Tahtanın derin kopyasını alırız
        public static Board CopyBoard(Board oldBoard)
        {
            Board newBoard = new Board();
            newBoard = ObjectExtensions.Copy(oldBoard);
            return newBoard;
        }

        // kullanıcı hareketleri
        public bool GetMove(int tile, int next, Board board)
        {
            bool valid = false;

            List<Move> legalMoves = GetAllLegalMoves(Player.White, board);

            foreach (var move in legalMoves)
                if (move.StartTile == tile && move.EndTile == next)
                    valid = true;

            if (valid == false)
                return false;

            MovePiece(board, tile, next);

            if (IsCheckmated(Player.White))
                return false;

            board.Save(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\book\learn.txt", tile, next, board);

            Turn = Player.Black;
            BlackTurn();
            return true;
        }

        //Yapay Zeka Hareketleri
        public void BlackTurn()
        {
            AI ai = new AI(2); // pls set in range (1-3) {1,2,3}
            if (Turn == Player.Black)
            {
                Thread.Sleep(500);
                if (this._firstThreeMoves < 2)
                {
                    ai.EvaluateRandom(this);
                    this._firstThreeMoves += 1;
                }
                else
                {
                    ai.EvaluateAI(this);
                }

                if (IsCheckmated(Player.Black))
                    return;

                Turn = Player.White;
            }
        }

        //Şahmat durumunda Kazanan Belirleme
        public bool IsCheckmated(Player player)
        {
            if (CheckMate == true)
            {
                Player winner = player == Player.White ? Player.Black : Player.White;
                return true;
            }

            return false;
        }

        //History dosyasına maç geçmişi kaydetme
        public void Save(string fileName, int tile, int next, Board board)
        {
            StreamWriter writer = File.AppendText(fileName);
            try
            {
                string a;
                string b;

                if (tile < 10)
                {
                    a = "0";
                }
                else
                {
                    a = "";
                }

                if (next < 10)
                {
                    b = "0";
                }
                else
                {
                    b = "";
                }

                if (board.CheckMate == true)
                {
                    writer.WriteLine("End Game");
                }
                else
                {
                    writer.Write(board.Turn);
                    writer.Write("   ");
                    writer.Write(a + tile);
                    writer.Write("   ");
                    writer.Write(b + next);
                    writer.WriteLine("");
                }
            }
            finally
            {
                writer.Close();
            }
        }

       
        public void SaveStatus(string fileName, Board board)
        {
            // Dosyanın bulunduğu klasörü kontrol et ve yoksa oluştur.(book klasörü yoksa hata alınmaz)
            string directory = Path.GetDirectoryName(fileName);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            //Dosyayı aç ve yazmaya başla
            StreamWriter writer = File.AppendText(fileName); //learn.txt doyası yoksa oluşturur. varsa üstüne yazar.
            try
            {
                if (board._firstThreeMoves == 0)
                {
                    writer.WriteLine("New Game");
                    writer.WriteLine("");

                }
                if (board.CheckMate == true)
                {
                    writer.WriteLine("");
                    writer.WriteLine("End Game");
                    writer.WriteLine("");

                }
            }
            finally
            {
                writer.Close();
            }
        }
    }
}
