using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Banana_Games.Chess.Piece
{
    public class King : Piece
    {
        public King(Type type, Player player, int position) : base(type, player, position)
        {
        }

        private List<int> offsets = new List<int>()
        {
            Vectors.up, Vectors.down, Vectors.left, Vectors.right,
            Vectors.upLeft, Vectors.upRight, Vectors.lowLeft, Vectors.lowRight
        };

        public override List<int> LegalMoves(int tile, Board board)
        {
            List<int> legalMoves = MoveGen.GetKingMoves(offsets, tile, board);

            return legalMoves;
        }

    }
}
