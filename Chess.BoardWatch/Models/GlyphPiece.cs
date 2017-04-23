using ChessTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BoardWatch.Models
{
    public class GlyphPiece : IGlyphPiece
    {
        public GlyphPiece(PieceType type, Team team, int x, int y)
        {
            Type = type;
            Team = team;
            X = x;
            Y = y;
        }

        public PieceType Type { get; set; }
        public Team Team { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
