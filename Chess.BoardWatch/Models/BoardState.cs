using ChessTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Core.Dtos;

namespace Chess.BoardWatch.Models
{
    public class BoardState : IBoardState
    {
        public List<GlyphPiece> Pieces { get; set; }
        public Team Turn { get; set; }

        IEnumerable<IGlyphPiece> IBoardState.Pieces => Pieces;

        public BoardState()
        {
            Pieces = new List<GlyphPiece>();
        }

        public BoardState(List<GlyphPiece> pieces, Team turn)
        {
            Pieces = pieces;
            Turn = turn;
        }

       
    }
}
