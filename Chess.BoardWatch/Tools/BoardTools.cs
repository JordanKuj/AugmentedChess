using Chess.BoardWatch.Models;
using Chess.BoardWatch.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BoardWatch
{
    public class BoardTools
    {
        //TODO:create a way to offset the BoardArea's x y coordinates 
        //public Rectangle BoardSize
        //{
        //    get { return BoardArea; }
        //    set
        //    {
        //        BoardArea = value;
        //    }
        //}
        private Rectangle BoardArea { get; set; }
        public const int BoardDivisions = 8;
        public List<Piece> pieces { get; set; }

        public BoardTools()
        {
            pieces = new List<Piece>();
        }

        public BoardState SetPieces(IEnumerable<BlobData> black, IEnumerable<BlobData> white, Rectangle boardArea)
        {
            pieces.Clear();
            BoardArea = boardArea;
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
                    var blobcenter = b.Blob.Rectangle.Center();

                    int x = (int)Math.Floor(blobcenter.X / ((double)BoardArea.Width / BoardDivisions));
                    int y = (int)Math.Floor(blobcenter.Y / ((double)BoardArea.Height / BoardDivisions));
                    if (x > 8 || y > 8 || x < 0 || y < 0)
                    {
                        Debug.Print("error");
                    }
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
