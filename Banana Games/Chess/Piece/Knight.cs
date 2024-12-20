using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Banana_Games.Chess.Piece
{
    public class Knight : Piece
    {
        public Knight(Type type, Player player, int position) : base(type, player, position)
        {

        }

        private List<int> _offsets = new List<int>() 
        {
            Vectors.AtUpLeft, Vectors.AtUpRight, Vectors.AtDownLeft, Vectors.AtDownRight,
            Vectors.AtLeftUp, Vectors.AtLeftDown, Vectors.AtRightUp, Vectors.AtRightDown
        };

        public override List<int> LegalMoves(int tile, Board board)
        {
            List<int> legalMoves = MoveGen.GetKnightMoves(_offsets, board.Pieces, tile);

            return legalMoves;
        }
    }
}


