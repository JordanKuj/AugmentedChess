using System;
using System.Collections.Generic;
using AForge.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using ChessTest;

namespace Chess.BoardWatch.Tools
{


    public static class Extensions
    {
        public static int ToInt(this CheckBox val)
        {
            return val.Checked.ToInt();
        }
        public static bool ToBool(this int val)
        {
            return val == 0 ? false : true;
        }

        public static int ToInt(this bool val)
        {
            return val ? 1 : 0;
        }
        public static Point Center(this Rectangle r)
        {
            var x = (r.Width / 2f) + r.Location.X;
            var y = (r.Height / 2f) + r.Location.Y;
            return new Point((int)x, (int)y);
        }


        public static Board ToBoard(this BoardState state)
        {
            var b = new Board();
            b.turn = state.turn;
            for (int y = 0; y < 8; y++)
                for (int x = 0; x < 8; x++)
                {
                    b.board[x, y] = null;
                    var piece = state.Pieces.SingleOrDefault(z => z.X == x && z.Y == y);
                    if (piece != null)
                        b.board[x, y] = new Piece(piece.Team, piece.Type);
                }
            return b;
        }
        public static BoardState ToBoard(this Board b)
        {
            var state = new BoardState();
            state.turn = b.turn;
            for (int y = 0; y < 8; y++)
                for (int x = 0; x < 8; x++)
                {
                    Piece piece = b.board[x, y];
                    if (piece != null)
                        state.Pieces.Add(new GlyphPiece(piece.Name, piece.Team, x, y));
                }
            return state;
        }


    }
}
