using Chess.BoardWatch.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BoardWatch
{
    public class BoardTools
    {
        //TODO:create a way to offset the BoardArea's x y coordinates 
        public int BoardSize
        {
            get { return _boardSize; }
            set
            {
                _boardSize = value;
                BoardArea = new Rectangle(0, 0, _boardSize, _boardSize);
            }
        }
        private int _boardSize;
        private Rectangle BoardArea { get; set; }
        public const int BoardDivisions = 8;
        public List<Piece> pieces { get; set; }

        public BoardTools()
        {
            BoardSize = 500;
        }

        public BoardState SetPieces(IEnumerable<BlobData> black, IEnumerable<BlobData> white)
        {
            pieces.Clear();
            SetData(pieces, black, BoardArea, Team.black);
            SetData(pieces, white, BoardArea, Team.white);

            return new BoardState(pieces);  
        }

        private static void SetData(List<Piece> pieces, IEnumerable<BlobData> bd, Rectangle BoardArea, Team t)
        {
            foreach (var b in bd)
            {
                if (BoardArea.Contains(b.Blob.Rectangle.Location))
                {
                    int x = (int)Math.Floor(((double)BoardArea.Width / BoardDivisions) / b.Blob.Rectangle.X);
                    int y = (int)Math.Floor(((double)BoardArea.Height / BoardDivisions) / b.Blob.Rectangle.Y);
                    var ptype = PieceConstants.FindPieceType(b.glyph);
                    pieces.Add(new Piece(ptype, t, x, y));
                }
            }
        }
    }

    public class Piece
    {
        public Piece(PieceType type, Team team, int x, int y)
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

    public class BoardState
    {

        public List<Piece> Pieces { get; set; }
        public Team turn;

        public BoardState()
        {
            Pieces = new List<Piece>();
        }

        public BoardState(List<Piece> pieces)
        {
            Pieces = pieces;
        }
    }



}
