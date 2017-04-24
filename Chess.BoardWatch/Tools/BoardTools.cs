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
using Chess.Core.Dtos;

namespace Chess.BoardWatch
{
    public class BoardTools
    {
        public IList<IBoardState> States => _states.ToList<IBoardState>();
        public IBoardState LastMove => States.Last();
        private List<BoardState> _states = new List<BoardState>();

        public BoardState currentState;
        public event Action<BoardState, bool> NewBoardState;
        public event Action NewBoardStateAccepted;

        private Rectangle BoardArea { get; set; }
        public const int BoardDivisions = 8;

        public BoardTools()
        {
            Initalize();
        }
        private void Initalize()
        {
            //var currentGame = await _wc.GetCurrentGame();
            GamesDTO currentGame = null;
            if (currentGame == null)
            {
                currentGame = new GamesDTO();
                //await _wc.CreateGame(currentGame);
                //TODO:Try web api
                var b = new Board();
                b.fillNewBoard();
                var blankboard = b.ToBoard();
                blankboard.Turn = Team.error;
                _states.Add(blankboard);
            }
            else
            {
                //_wc.GetCurrentGameState()
            }
        }
        public bool SubmitNewState(BoardState state)
        {
            //if (!TInitalizing.IsCompleted)
            //    return false;
            Console.WriteLine("Current Board State");
            state.ToBoard().printBoard();
            Console.WriteLine("Previous Board State");
            LastMove.ToBoard().printBoard();
            if (!State.getDiff(state.ToBoard(), LastMove.ToBoard()))
                if (State.validState(LastMove.ToBoard(), state.ToBoard()))
                {
                    _states.Add(state);
                    NewBoardStateAccepted?.Invoke();
                    return true;
                }
            return false;
        }

        public Board IsCurrentStateValid()
        {
            if (currentState == null)
                return null;

            Board laststate = _states.LastOrDefault()?.ToBoard();
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
                _states.Add(valid.ToBoard());
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

            Team turn = Team.error;
            if (LastMove.Turn == Team.error || LastMove.Turn == Team.black)
                turn = Team.white;
            else if (LastMove.Turn == Team.white)
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
            //System.Threading.Thread.Sleep(1000);
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



    public interface IBoardState
    {
        IEnumerable<IGlyphPiece> Pieces { get; }
        Team Turn { get; }
    }




}
