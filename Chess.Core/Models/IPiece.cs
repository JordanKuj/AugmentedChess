using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Core.Models
{
    public interface IPiece
    {
        /// <summary>
        /// An enumeration indicating what team this piece is on.
        /// </summary>
        PieceColor Team { get; set; }

        /// <summary>
        /// This will be the position of the piece on the chess board.
        /// </summary>
        Vector2d Position { get; set; }

        /// <summary>
        /// When Invoked a list of positions that this piece is able to move to will be provided.
        /// </summary>
        /// <param name="b">This will be the current state of the board that this piece is apart of</param>
        /// <returns>this returns a list of vector2d which have xy corridinates of available moves.</returns>
        ICollection<Vector2d> PossibleMoves(Board b);

        /// <summary>
        /// This Number will represent how many of this piece are allowed on the board per team.
        /// For example there can only be 8 pawns per side so this property would return an 8.
        /// </summary>
        int MaxOfThisPiece { get; }
    }
  
}
