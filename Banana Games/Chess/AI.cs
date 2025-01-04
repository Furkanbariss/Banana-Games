﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Banana_Games.Chess.Piece;
using Banana_Games.Chess;

namespace Banana_Games.Chess
{
    public class AI
    {
        /// <summary>
        /// The "evaluate" depth of minimax algorithm
        /// </summary>
        private int depth;

        /// <summary>
        /// Piece value
        /// </summary>
        private const int pawnValue = 100;
        private const int knightValue = 320;
        private const int bishopValue = 330;
        private const int rookValue = 500;
        private const int queenValue = 900;
        private const int kingValue = 20000;

        /// <summary>
        /// source : https://www.chessprogramming.org/Simplified_Evaluation_Function
        /// </summary>
        private static readonly int[] bestPawnPositions = {
              0,  0,  0,  0,  0,  0,  0,  0,
             50, 50, 50, 50, 50, 50, 50, 50,
             10, 10, 20, 30, 30, 20, 10, 10,
              5,  5, 10, 25, 25, 10,  5,  5,
              0,  0,  0, 20, 20,  0,  0,  0,
              5, -5,-10,  0,  0,-10, -5,  5,
              5, 10, 10,-20,-20, 10, 10,  5,
              0,  0,  0,  0,  0,  0,  0,  0
        };

        private static readonly int[] bestKnightPositions = {
            -50,-40,-30,-30,-30,-30,-40,-50,
            -40,-20,  0,  0,  0,  0,-20,-40,
            -30,  0, 10, 15, 15, 10,  0,-30,
            -30,  5, 15, 20, 20, 15,  5,-30,
            -30,  0, 15, 20, 20, 15,  0,-30,
            -30,  5, 10, 15, 15, 10,  5,-30,
            -40,-20,  0,  5,  5,  0,-20,-40,
            -50,-40,-30,-30,-30,-30,-40,-50,
        };

        private static readonly int[] bestBishopPositions = {
            -20,-10,-10,-10,-10,-10,-10,-20,
            -10,  0,  0,  0,  0,  0,  0,-10,
            -10,  0,  5, 10, 10,  5,  0,-10,
            -10,  5,  5, 10, 10,  5,  5,-10,
            -10,  0, 10, 10, 10, 10,  0,-10,
            -10, 10, 10, 10, 10, 10, 10,-10,
            -10,  5,  0,  0,  0,  0,  5,-10,
            -20,-10,-10,-10,-10,-10,-10,-20,
        };

        private static readonly int[] bestRookPositions = {
              0,  0,  0,  0,  0,  0,  0,  0,
              5, 10, 10, 10, 10, 10, 10,  5,
             -5,  0,  0,  0,  0,  0,  0, -5,
             -5,  0,  0,  0,  0,  0,  0, -5,
             -5,  0,  0,  0,  0,  0,  0, -5,
             -5,  0,  0,  0,  0,  0,  0, -5,
             -5,  0,  0,  0,  0,  0,  0, -5,
              0,  0,  0,  5,  5,  0,  0,  0
        };

        private static readonly int[] bestQueenPositions = {
             -20,-10,-10, -5, -5,-10,-10,-20,
             -10,  0,  0,  0,  0,  0,  0,-10,
             -10,  0,  5,  5,  5,  5,  0,-10,
              -5,  0,  5,  5,  5,  5,  0, -5,
               0,  0,  5,  5,  5,  5,  0, -5,
             -10,  5,  5,  5,  5,  5,  0,-10,
             -10,  0,  5,  0,  0,  0,  0,-10,
             -20,-10,-10, -5, -5,-10,-10,-20
        };

        private static readonly int[] bestKingPositions = {
            -30,-40,-40,-50,-50,-40,-40,-30,
            -30,-40,-40,-50,-50,-40,-40,-30,
            -30,-40,-40,-50,-50,-40,-40,-30,
            -30,-40,-40,-50,-50,-40,-40,-30,
            -20,-30,-30,-40,-40,-30,-30,-20,
            -10,-20,-20,-20,-20,-20,-20,-10,
             20, 20,  0,  0,  0,  0, 20, 20,
             20, 30, 10,  0,  0, 10, 30, 20
        };

        public AI(int _depth)
        {
            depth = _depth;
        }

        /// <summary>
        /// Calculate the point for evaluate
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public int CalculatePoint(Board board)
        {
            int scoreWhite = 0;
            int scoreBlack = 0;
            scoreWhite += GetScoreFromExistingPieces(Player.White, board);
            scoreBlack += GetScoreFromExistingPieces(Player.Black, board);

            int evaluation = scoreBlack - scoreWhite;

            int prespective = (board.Turn == Player.White) ? -1 : 1;
            return evaluation * prespective;
        }

        /// <summary>
        /// Get score from the existing pieces of the faction
        /// </summary>
        /// <param name="player"></param>
        /// <param name="board"></param>
        /// <returns></returns>
        private static int GetScoreFromExistingPieces(Player player, Board board)
        {
            int material = 0;

            for (int i = 0; i < 64; i++)
            {
                if (board.Pieces[i] != null)
                {
                    if (board.Pieces[i].GetType() == typeof(Piece.Pawn) && board.Pieces[i].Player == player)
                    {
                        material += (pawnValue + bestPawnPositions[i]); 
                    }
                    if (board.Pieces[i].GetType() == typeof(Piece.Knight) && board.Pieces[i].Player == player)
                    {
                        material += (knightValue); 
                    }
                    if (board.Pieces[i].GetType() == typeof(Piece.Bishop) && board.Pieces[i].Player == player)
                    {
                        material += (bishopValue); 
                    }
                    if (board.Pieces[i].GetType() == typeof(Piece.Rook) && board.Pieces[i].Player == player)
                    {
                        material += (rookValue); 
                    }
                    if (board.Pieces[i].GetType() == typeof(Piece.Queen) && board.Pieces[i].Player == player)
                    {
                        material += (queenValue); 
                    }
                    if (board.Pieces[i].GetType() == typeof(Piece.King) && board.Pieces[i].Player == player)
                    {
                        material += (kingValue); 
                    }
                }
            }
            return material;
        }



        //+++++++++++++++++++++++++++++++++++++ NEGAMAX ALGORITHM ++++++++++++++++++++++++++++++++++++

        
        // Main algorithm: Negamax
        
        
        public MoveWithScore CalculateBestMove(Board board, int depth)
        {
            if (depth == 0)
            {
                return new MoveWithScore(CalculatePoint(board));
            }
            else
            {
                MoveWithScore bestMove = new MoveWithScore(-9999999);
                List<Move> possibleMoves = Board.GetAllLegalMoves(board.Turn, board);
                OrderMoves(possibleMoves, board);
                foreach (Move move in possibleMoves)
                {
                    Board newBoard = GenerateMovedBoard(board, move);
                    MoveWithScore newMove = CalculateBestMove(newBoard, (depth - 1));
                    newMove.Move = move;
                    if (newMove.Score >= bestMove.Score)
                    {
                        bestMove.Score = newMove.Score;
                        bestMove.Move = newMove.Move;
                    }
                }
                return bestMove;
            }
        }
        //+++++++++++++ END +++++++++++++++++++ NEGAMAX ALGORITHM ++++++++++++++++++++++++++++++++++++




        //+++++++++++++++++++++++++++++++++++++ MINIMAX ALGORITHM ++++++++++++++++++++++++++++++++++++

        /// <summary>
        /// Copy the current board, then make move
        /// </summary>
        
        private Board GenerateMovedBoard(Board oldBoard, Move move)
        {
            Board newBoard = new Board();
            newBoard = ObjectExtensions.Copy(oldBoard);
            Board.MovePiece(newBoard, move.StartTile, move.EndTile);
            return newBoard;
        }
        // if not using the lib from Stack Overflow, the code will look like below, and maybe something is missing
        //private Board GenerateMovedBoard(Board oldBoard, Move move)
        //{
        //    Board newBoard = new Board();
        //    if (oldBoard.Turn == Player.Black)
        //    {
        //        newBoard.Turn = Player.White;
        //    }
        //    else
        //    {
        //        newBoard.Turn = Player.Black;
        //    }

        //    for (int i = 0; i < 64; i++)
        //    {

        //        if (oldBoard.Pieces[i] == null)
        //        {
        //            newBoard.Pieces[i] = null;
        //        }
        //        else
        //        {
        //            if (oldBoard.Pieces[i].Player == Player.White)
        //            {
        //                if (oldBoard.Pieces[i].GetType() == typeof(Pawn))
        //                {
        //                    newBoard.Pieces[i] = new Pawn(Type.wPawn, Player.White, i);
        //                }
        //                else if (oldBoard.Pieces[i].GetType() == typeof(Knight))
        //                {
        //                    newBoard.Pieces[i] = new Knight(Type.wKnight, Player.White, i);
        //                }
        //                else if (oldBoard.Pieces[i].GetType() == typeof(Bishop))
        //                {
        //                    newBoard.Pieces[i] = new Pawn(Type.wBishop, Player.White, i);
        //                }
        //                else if (oldBoard.Pieces[i].GetType() == typeof(Rook))
        //                {
        //                    newBoard.Pieces[i] = new Pawn(Type.wRook, Player.White, i);
        //                }
        //                else if (oldBoard.Pieces[i].GetType() == typeof(Queen))
        //                {
        //                    newBoard.Pieces[i] = new Pawn(Type.wQueen, Player.White, i);
        //                }
        //                else if (oldBoard.Pieces[i].GetType() == typeof(King))
        //                {
        //                    newBoard.Pieces[i] = new Pawn(Type.wKing, Player.White, i);
        //                }
        //            }
        //            else if (oldBoard.Pieces[i].Player == Player.Black)
        //            {
        //                if (oldBoard.Pieces[i].GetType() == typeof(Pawn))
        //                {
        //                    newBoard.Pieces[i] = new Pawn(Type.bPawn, Player.Black, i); ;
        //                }
        //                else if (oldBoard.Pieces[i].GetType() == typeof(Knight))
        //                {
        //                    newBoard.Pieces[i] = new Knight(Type.bKnight, Player.Black, i);
        //                }
        //                else if (oldBoard.Pieces[i].GetType() == typeof(Bishop))
        //                {
        //                    newBoard.Pieces[i] = new Pawn(Type.bBishop, Player.Black, i);
        //                }
        //                else if (oldBoard.Pieces[i].GetType() == typeof(Rook))
        //                {
        //                    newBoard.Pieces[i] = new Pawn(Type.bRook, Player.Black, i);
        //                }
        //                else if (oldBoard.Pieces[i].GetType() == typeof(Queen))
        //                {
        //                    newBoard.Pieces[i] = new Pawn(Type.bQueen, Player.Black, i);
        //                }
        //                else if (oldBoard.Pieces[i].GetType() == typeof(King))
        //                {
        //                    newBoard.Pieces[i] = new Pawn(Type.bKing, Player.Black, i);
        //                }
        //            }
        //        }

        //    }

        //    Board.MovePiece(newBoard, move.Tile, move.Next);
        //    return newBoard;
        //}


        /// <summary>
        /// Get the piece value
        /// </summary>
        /// <param name="board"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private int GetPieceValue(Board board, int index)
        {
            if (board.Pieces[index].GetType() == typeof(Piece.Pawn))
            {
                return pawnValue;
            }
            else if (board.Pieces[index].GetType() == typeof(Piece.Rook))
            {
                return rookValue;
            }
            else if (board.Pieces[index].GetType() == typeof(Piece.Knight))
            {
                return knightValue;
            }
            else if (board.Pieces[index].GetType() == typeof(Piece.Bishop))
            {
                return bishopValue;
            }
            else if (board.Pieces[index].GetType() == typeof(Piece.Queen))
            {
                return queenValue;
            }
            else if (board.Pieces[index].GetType() == typeof(Piece.King))
            {
                return kingValue;
            }

            return 0;
        }

        /// <summary>
        /// Sort the list to reduce the runtime of the algorithm
        /// </summary>
        /// <param name="moveList"></param>
        /// <param name="board"></param>
        private void OrderMoves(List<Move> moveList, Board board)
        {
            int[] moveScore = new int[moveList.Count];

            for (int i = 0; i < moveList.Count; i++)
            {
                moveScore[i] = 0;

                if (board.Pieces[moveList[i].EndTile] != null)
                {
                    moveScore[i] += 10 * GetPieceValue(board, moveList[i].EndTile) - GetPieceValue(board, moveList[i].StartTile);
                }

                if (Board.PawnPromoted(board.Pieces, moveList[i].EndTile))
                {
                    moveScore[i] += queenValue;
                }

            }

            for (int sorted = 0; sorted < moveList.Count; sorted++)
            {
                int bestScore = int.MinValue;
                int bestScoreIndex = 0;

                for (int i = sorted; i < moveList.Count; i++)
                {
                    if (moveScore[i] > bestScore)
                    {
                        bestScore = moveScore[i];
                        bestScoreIndex = i;
                    }
                }

                // swap

                Move bestMove = moveList[bestScoreIndex];
                moveList[bestScoreIndex] = moveList[sorted];
                moveList[sorted] = bestMove;
            }
        }

        /// <summary>
        /// Main algorithm: minimax
        /// </summary>
        /// <param name="board"></param>
        /// <param name="depth"></param>
        /// <param name="alpha"></param>
        /// <param name="beta"></param>
        /// <param name="isMaximizingPlayer"></param>
        /// <returns></returns>
        private int Minimax(Board board, int depth, int alpha, int beta, bool isMaximizingPlayer)
        {
            if (depth == 0)
                return CalculatePoint(board);

            if (isMaximizingPlayer)
            {
                int bestValue = int.MinValue;

                List<Move> possibleMoves = Board.GetAllLegalMoves(Player.Black, board);

                OrderMoves(possibleMoves, board);
                foreach (var move in possibleMoves)
                {
                    Board newBoard = GenerateMovedBoard(board, move);

                    int value = Minimax(newBoard, depth - 1, alpha, beta, false);

                    bestValue = Math.Max(value, bestValue);

                    alpha = Math.Max(alpha, value);

                    if (beta <= alpha)
                    {
                        break;
                    }
                }

                return bestValue;
            }
            else
            {
                int bestValue = int.MaxValue;

                List<Move> possibleMoves = Board.GetAllLegalMoves(Player.White, board);

                OrderMoves(possibleMoves, board);
                foreach (var move in possibleMoves)
                {
                    Board newBoard = GenerateMovedBoard(board, move);

                    int value = Minimax(board, depth - 1, alpha, beta, true);

                    bestValue = Math.Min(value, bestValue);

                    beta = Math.Min(beta, value);

                    if (beta <= alpha)
                    {
                        break;
                    }
                }

                return bestValue;
            }
        }

        /// <summary>
        /// Get the result after evaluate using minimax
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public Move GetBestMove(Board board)
        {
            int bestValue = int.MinValue;
            Move bestMove = null;
            bool turn;
            if (board.Turn == Player.Black)
            {
                turn = false;
            }
            else
            {
                turn = true;
            }

            List<Move> possibleMoves = Board.GetAllLegalMoves(board.Turn, board);

            OrderMoves(possibleMoves, board);
            foreach (var move in possibleMoves)
            {
                Board newBoard = GenerateMovedBoard(board, move);

                int value = Minimax(newBoard, depth, int.MinValue, int.MaxValue, turn);

                if (value >= bestValue)
                {
                    bestValue = value;
                    bestMove = move;
                }
            }

            return bestMove;
        }
        //+++++++++++++ END +++++++++++++++++++ MINIMAX ALGORITHM ++++++++++++++++++++++++++++++++++++               




        //+++++++++++++++++++++++++++++++++++++ RANDOM ALGORITHM +++++++++++++++++++++++++++++++++++++

        /// <summary>
        /// Random a move in legal moves
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public Move RandomMove(Board board)
        {
            Random rand = new Random();
            List<Move> legalMoves = Board.GetAllLegalMoves(Player.Black, board);

            if (board.CheckMate == true) return null;
            return legalMoves[rand.Next(0, legalMoves.Count)];
        }
        //+++++++++++++++++ END +++++++++++++++ RANDOM ALGORITHM +++++++++++++++++++++++++++++++++++++                     





        //===================================== USING EVALUATE =======================================

        /// <summary>
        /// AI generates random movement
        /// </summary>
        /// <param name="board"></param>
        public void EvaluateRandom(Board board)
        {

            Move move = RandomMove(board);

            if (move == null) return;

            Board.MovePiece(board, move.StartTile, move.EndTile);
            board.Save(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\book\learn.txt", move.StartTile, move.EndTile, board);


        }

        /// <summary>
        /// AI generates evaluated movement
        /// </summary>
        /// <param name="board"></param>
        public void EvaluateAI(Board board)
        {
            // uncomment this to use negamax algorithm

            //Move move = CalculateBestMove(board, 3).Move;
            //if (move == null) return;
            //Board.MovePiece(board, move.Tile, move.Next);
            //board.Save(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\book\learn.txt", move.Tile, move.Next, board);


            // uncomment this to use minimax algorithm
            // This doesn't work as I expected, as you increase the depth (Board.cs line 286)
            // The AI will take too long to make a "stupid" movement =(((

            Move move = GetBestMove(board);
            if (move == null) return;
            Board.MovePiece(board, move.StartTile, move.EndTile);
            board.Save(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\book\learn.txt", move.StartTile, move.EndTile, board);

        }


    }
}





