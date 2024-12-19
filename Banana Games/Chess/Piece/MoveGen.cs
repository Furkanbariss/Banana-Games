using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Banana_Games.Chess.Piece
{
    public class MoveGen
    {
        public static bool ValidateCastling = true; 
        //Şah çekildiğinde oyuncunun şah durumundan kurtulmaya oynatmaya zorlamak için (#CPT baba sağolasın)
        public static List<Move> FilterIlegalMoves(List<Move> moveList, Board board)
        {
            Type king = board.Turn == Player.White ? Type.wKing : Type.bKing;

            foreach (Move move in moveList.ToArray())
            {
                Board nextBoard = Board.CopyBoard(board);
                Board.MovePiece(nextBoard, move.StartTile, move.EndTile);

                if (Board.KingChecked(king, nextBoard))
                    moveList.Remove(move); 
            }

            if (moveList.Count == 0)
            {
                board.CheckMate = true;
            }

            return moveList;
        }

        // ------------------------ Taş Hareketleri -----------------------------

        // ------------------------ ŞAH -----------------------------

        public static List<int> GetKingMoves(List<int> offsets, int tile, Board Board)
        {
            List<int> Movelist = new List<int>();
            
            //gidebileceği taş yerlerini atadık.
            foreach (int offset in offsets) {
                Movelist.Add(tile+offset);
            }

            //Sahanın dışına çıkmaması için sınırlandırdık
            foreach (int Kmove in Movelist.ToArray()) 
            {
                if (Kmove < 0 || Kmove > 63)
                {
                    Movelist.Remove(Kmove);
                }
                else if (Board.Pieces[Kmove] != null)
                {
                    if (Board.Pieces[tile].Player == Board.Pieces[Kmove].Player) //aynı renkse iptal et
                    {
                        Movelist.Remove(Kmove);
                    }
                }

                Coordinate tilePosition = new Coordinate(tile);
                Coordinate movePosition = new Coordinate(Kmove);

                if (Math.Abs((int)(movePosition.x - tilePosition.x)) > 1)
                {
                    Movelist.Remove(Kmove);
                }
            } 
            
            if (ValidateCastling == true)
            {
               int rank = Board.Turn == Player.White ? 7 : 63;
                Movelist.AddRange(GetRok(tile, rank, Board));
            }
            return Movelist;
        }

        // -----------------------------ROK HAMLESİ-------------------------------------
        public static List<int> GetRok(int tile, int rank ,Board board)
        {
            Type rok = rank == 7 ? Type.wRook : Type.bRook; //kale hareket etmiş olmamalı
            List<int> moveList = new List<int>();

            if (board.Pieces[tile].Moved == false )
            {
                ValidateCastling = false;

                if (board.Pieces[rank] != null && board.Pieces[rank - 1] == null && board.Pieces[rank - 2] == null)
                {
                    if (board.Pieces[rank].GetPiece == rok && board.Pieces[rank].Moved == false
                        && TileAttacked(rank - 1, board, false) == false && TileAttacked(rank - 2, board, false) == false)
                    {
                        moveList.Add(rank - 1);
                    }
                }

                if (board.Pieces[rank - 7] != null && board.Pieces[rank - 6] == null && board.Pieces[rank - 5] == null)
                {
                    if (board.Pieces[rank - 7].GetPiece == rok && board.Pieces[rank - 7].Moved == false
                       && TileAttacked(rank - 5, board, false) == false && TileAttacked(rank - 4, board, false) == false)
                    {
                        moveList.Add(rank - 5);
                    }
                } 
            }
           
            ValidateCastling = true;
            return moveList;
        }

        //belirli bir karenin rakip oyuncu tarafından tehdit edilip edilmediğini kontrol edebilmek için kulanıyoruz
        public static bool TileAttacked(int tile, Board board, bool filter = true)
        {
            Player  rival = board.Turn == Player.White ? board.Turn : Player.White;
            List<Move> legalMoves = Board.GetAllLegalMoves(rival, board, filter);

            foreach (var legal_move in legalMoves)
            {
                if (legal_move.EndTile == tile)
                { 
                    return true;
                }
            }
            return false;
        }


        // -----------------------------AT HAREKETLERİ-------------------------------------
        public static List<int> GetKnightMoves(List<int> offsets, Piece[] piesces, int tile)
        {
            List<int> moveList = new List<int>();

            foreach(var offset in offsets) 
            {
                moveList.Add(tile + offset);
            }

            foreach(var AtMove in moveList.ToArray())
            {
                if (AtMove < 0 || AtMove > 63)
                {
                    moveList.Remove(AtMove);
                }else if (piesces[AtMove] != null)
                {
                    if (piesces[tile].Player == piesces[AtMove].Player)
                    {
                        moveList.Remove(AtMove);
                    }
                }
                Coordinate tilePosition = new Coordinate(tile);
                Coordinate movePosition = new Coordinate(AtMove);

                if (Math.Abs((int)(movePosition.x - tilePosition.x)) > 2)
                {
                    moveList.Remove(AtMove);
                }

            }
            
            return moveList;
        }

        // sabit değişken hareketlerini metod olarak çağıramadım. sağ olsun cpt abim yardımcı oldu.
        // UP HAMLESİ
        private static List<int> up(Piece[] pieces, int tile)
        {
            List<int> legalMoves = new List<int>();
            Coordinate move = new Coordinate(tile);

            Player player = pieces[tile].Player;
            while(move.y < 7)
            {
                if ( pieces[tile + Vectors.up] == null)
                {
                    legalMoves.Add(tile +Vectors.up);
                }
                else if (player != pieces[tile + Vectors.up].Player)
                {
                    legalMoves.Add(tile + Vectors.up);
                    break;
                }
                else break;

                tile += Vectors.up;
                move = new Coordinate(tile);
            }
            return legalMoves;
        }

        // DOWN HAMLESİ
        private static List<int> down(Piece[] pieces, int tile)
        {
            List<int> legalMoves = new List<int>();
            Coordinate move = new Coordinate(tile);

            Player player = pieces[tile].Player;
            while (move.y > 0)
            {
                if (pieces[tile + Vectors.down] == null)
                {
                    legalMoves.Add(tile + Vectors.down);
                }
                else if (player != pieces[tile + Vectors.down].Player)
                {
                    legalMoves.Add(tile + Vectors.down);
                    break;
                }
                else break;

                tile += Vectors.down;
                move = new Coordinate(tile);
            }
            return legalMoves;
        }

        //LEFT HAMLESİ
        private static List<int> left(Piece[] pieces, int tile)
        {
            List<int> legalMoves = new List<int>();
            Coordinate move = new Coordinate(tile);

            Player player = pieces[tile].Player;
            while (move.x > 0)
            {
                if (pieces[tile + Vectors.left] == null)
                {
                    legalMoves.Add(tile + Vectors.left);
                }
                else if (player != pieces[tile + Vectors.left].Player)
                {
                    legalMoves.Add(tile + Vectors.left);
                    break;
                }
                else break;

                tile += Vectors.left;
                move = new Coordinate(tile);
            }
            return legalMoves;
        }

        // Right HAMLESİ
        private static List<int> right(Piece[] pieces, int tile)
        {
            List<int> legalMoves = new List<int>();
            Coordinate move = new Coordinate(tile);

            Player player = pieces[tile].Player;
            while (move.x < 7)
            {
                if (pieces[tile + Vectors.right] == null)
                {
                    legalMoves.Add(tile + Vectors.right);
                }
                else if (player != pieces[tile + Vectors.right].Player)
                {
                    legalMoves.Add(tile + Vectors.right);
                    break;
                }
                else break;

                tile += Vectors.right;
                move = new Coordinate(tile);
            }
            return legalMoves;
        }

        // sol üst çapraz

        private static List<int> upperLeft(Piece[] pieces, int tile)
        {
            List<int> legalMoves = new List<int>();
            Coordinate move = new Coordinate(tile);

            Player player = pieces[tile].Player;
            while (move.x > 0 && move.y < 7)
            {
                if (pieces[tile + Vectors.upLeft] == null)
                {
                    legalMoves.Add(tile + Vectors.upLeft);
                }
                else if (player != pieces[tile + Vectors.upLeft].Player)
                {
                    legalMoves.Add(tile + Vectors.upLeft);
                    break;
                }
                else break;

                tile += Vectors.upLeft;
                move = new Coordinate(tile);
            }
            return legalMoves;
        }

        // sağ üst çapraz

        private static List<int> upperRight(Piece[] pieces, int tile)
        {
            List<int> legalMoves = new List<int>();
            Coordinate move = new Coordinate(tile);

            Player player = pieces[tile].Player;
            while (move.x < 7 && move.y < 7)
            {
                if (pieces[tile + Vectors.upRight] == null)
                {
                    legalMoves.Add(tile + Vectors.upRight);
                }
                else if (player != pieces[tile + Vectors.upRight].Player)
                {
                    legalMoves.Add(tile + Vectors.upRight);
                    break;
                }
                else break;

                tile += Vectors.upRight;
                move = new Coordinate(tile);
            }
            return legalMoves;
        }

        private static List<int> lowerLeft(Piece[] pieces, int tile)
        {
            List<int> legalMoves = new List<int>();
            Coordinate move = new Coordinate(tile);

            Player player = pieces[tile].Player;
            while (move.x > 0 && move.y > 0)
            {
                if (pieces[tile + Vectors.lowLeft] == null)
                {
                    legalMoves.Add(tile + Vectors.lowLeft);
                }
                else if (player != pieces[tile + Vectors.lowLeft].Player)
                {
                    legalMoves.Add(tile + Vectors.lowLeft);
                    break;
                }
                else break;

                tile += Vectors.lowLeft;
                move = new Coordinate(tile);
            }
            return legalMoves;
        }

        private static List<int> lowerRight(Piece[] pieces, int tile)
        {
            List<int> legalMoves = new List<int>();
            Coordinate move = new Coordinate(tile);

            Player player = pieces[tile].Player;
            while (move.x < 7 && move.y > 0)
            {
                if (pieces[tile + Vectors.lowRight] == null)
                {
                    legalMoves.Add(tile + Vectors.lowRight);
                }
                else if (player != pieces[tile + Vectors.lowRight].Player)
                {
                    legalMoves.Add(tile + Vectors.lowRight);
                    break;
                }
                else break;

                tile += Vectors.lowRight;
                move = new Coordinate(tile);
            }
            return legalMoves;
        }


        // -----------------------------VEZİR HAREKETLERİ-------------------------------------
        public static List<int> GetQueenMoves(Piece[] pieces, int tile)
        {
            List<int> moveList = new List<int>();

            moveList.AddRange(up(pieces, tile));
            moveList.AddRange(down(pieces, tile));
            moveList.AddRange(left(pieces, tile));
            moveList.AddRange(right(pieces, tile));
            
            moveList.AddRange(upperLeft(pieces, tile));
            moveList.AddRange(upperRight(pieces, tile));
            moveList.AddRange(lowerRight(pieces, tile));
            moveList.AddRange(lowerLeft(pieces, tile));

            return moveList;
        }

        // -----------------------------kale HAREKETLERİ-------------------------------------
        public static List<int> GetRookMoves(Piece[] pieces, int tile)
        {
            List<int> moveList = new List<int>();

            moveList.AddRange(up(pieces, tile));
            moveList.AddRange(down(pieces, tile));
            moveList.AddRange(left(pieces, tile));
            moveList.AddRange(right(pieces, tile));

            return moveList;
        }

        // -----------------------------Fil HAREKETLERİ-------------------------------------
        public static List<int> GetBishopMoves(Piece[] pieces, int tile)
        {
            List<int> moveList = new List<int>();

            moveList.AddRange(upperLeft(pieces, tile));
            moveList.AddRange(upperRight(pieces, tile));
            moveList.AddRange(lowerLeft(pieces, tile));
            moveList.AddRange(lowerRight(pieces, tile));

            return moveList;
        }
        // -----------------------------Piyon HAREKETLERİ-------------------------------------
        public static List<int> GetPawnMoves(Piece[] pieces, int tile)
        {
            List<int> moveList = new List<int>();
            Coordinate position = new Coordinate(tile);

            if (pieces[tile].Player == Player.White)
            {
                if (position.y < 7)
                {
                    if (pieces[tile + Vectors.up] == null)
                    {
                        moveList.Add(tile + Vectors.up);

                        if (position.y == 1)
                        {
                            if (pieces[tile + Vectors.up * 2] == null)
                                moveList.Add(tile + Vectors.up * 2);
                        }

                    }
                }

                if (position.y < 7 && position.x > 0)
                {
                    if (pieces[tile + Vectors.upLeft] != null)
                    {
                        if (pieces[tile].Player != pieces[tile + Vectors.upLeft].Player)
                            moveList.Add(tile + Vectors.upLeft);
                    }
                }

                if (position.y < 7 && position.x < 7)
                {
                    if (pieces[tile + Vectors.upRight] != null)
                    {
                        if (pieces[tile].Player != pieces[tile + Vectors.upRight].Player)
                            moveList.Add(tile + Vectors.upRight);
                    }
                }
            }

            else if (pieces[tile].Player == Player.Black)
            {
                if (position.y > 0)
                {
                    if (pieces[tile + Vectors.down] == null)
                    {
                        moveList.Add(tile + Vectors.down);

                        if (position.y == 6)
                        {
                            if (pieces[tile + Vectors.down * 2] == null)
                                moveList.Add(tile + Vectors.down * 2);
                        }

                    }

                }

                if (position.y > 0 && position.x > 0)
                {
                    if (pieces[tile + Vectors.lowLeft] != null)
                    {
                        if (pieces[tile].Player != pieces[tile + Vectors.lowLeft].Player)
                            moveList.Add(tile + Vectors.lowLeft);
                    }
                }

                if (position.y > 0 && position.x < 7)
                {
                    if (pieces[tile + Vectors.lowRight] != null)
                    {
                        if (pieces[tile].Player != pieces[tile + Vectors.lowRight].Player)
                            moveList.Add(tile + Vectors.lowRight);
                    }
                }
            }

            return moveList;
        }
    }
}
