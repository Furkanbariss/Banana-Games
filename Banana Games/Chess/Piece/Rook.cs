using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banana_Games.Chess.Piece
{
    public class Rook : Piece
    {
        public Rook(Type type, Player player, int position) : base(type, player, position)
        {

        }
        public override List<int> LegalMoves(int tile, Board board)
        {
            List<int> legalMoves = MoveGen.GetRookMoves(board.Pieces, tile);
            return legalMoves;
        }
    }
}
