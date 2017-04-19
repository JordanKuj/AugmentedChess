using Chess.BoardWatch.Models;
using Chess.BoardWatch.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessTest;

namespace Chess.BoardWatch
{
    public class BoardTools
    {
        public List<BoardState> States = new List<BoardState>();
        public BoardState currentState;
        public event Action<BoardState, bool> NewBoardState;

        private Rectangle BoardArea { get; set; }
        public const int BoardDivisions = 8;

        public BoardTools()
        {
        }

        public Board IsCurrentStateValid()
        {
            if (currentState == null)
                return null;

            Board laststate = States.LastOrDefault()?.ToBoard();
            Board current = currentState.ToBoard();
            if (laststate == null)
            {
                laststate = new Board();
                laststate.fillNewBoard();
            }
            //var newboard = new Board();
            //newboard.fillNewBoard();
            //if (State.getDiff( current, newboard))
            //{
            //    return current;
            //}

            if (State.getDiff(laststate, current))
            {
                return null;
            }
            var sw = Stopwatch.StartNew();
            if (State.validState(laststate, current))
            {
                //Debug.Print("validState = " + sw.ElapsedMilliseconds.ToString());
                return laststate;
            }
            //Debug.Print("validState = " + sw.ElapsedMilliseconds.ToString());
            return null;
        }
        public bool AcceptCurrentState()
        {
            var valid = IsCurrentStateValid();
            if (valid != null)
            {
                States.Add(valid.ToBoard());
                return true;
            }
            return false;
        }
        public BoardState UpdateCurrentState(IEnumerable<BlobData> black, IEnumerable<BlobData> white, Rectangle boardArea)
        {
            var pieces = new List<GlyphPiece>();
            BoardArea = boardArea;
            SetData(pieces, black, BoardArea, Team.black);
            SetData(pieces, white, BoardArea, Team.white);

            var laststate = States.LastOrDefault();
            Team turn;
            if (laststate != null)
                turn = (laststate.Turn == Team.white ? Team.black : Team.white);
            else
                turn = Team.black;

            currentState = new BoardState(pieces, turn);
            if (currentState.Pieces.Any(x => currentState.Pieces.Any(y => y != x && y.X == x.X && y.Y == x.Y)))
                NewBoardState?.Invoke(currentState, false);
            else
            {
                var isvalid = IsCurrentStateValid() != null;
                NewBoardState?.Invoke(currentState, isvalid);
            }
            return currentState;
        }

        private static void SetData(List<GlyphPiece> pieces, IEnumerable<BlobData> bd, Rectangle BoardArea, Team t)
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
                    if (pieces.Any(z => z.X == x && z.Y == y))
                    {
                        Debug.Print("error2");
                    }
                    var ptype = PieceConstants.FindPieceType(b.glyph);
                    pieces.Add(new GlyphPiece(ptype, t, x, y));
                }
            }
        }
    }


    public interface IGlyphPiece
    {
        PieceType Type { get; }
        Team Team { get; }
        int X { get; }
        int Y { get; }
    }
    public class GlyphPiece
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


    public interface IBoardState
    {
        IEnumerable<IGlyphPiece> Pieces { get; }
        Team Turn { get; }
    }
    public class BoardState
    {
        public List<GlyphPiece> Pieces { get; set; }
        public Team Turn { get; set; }

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
