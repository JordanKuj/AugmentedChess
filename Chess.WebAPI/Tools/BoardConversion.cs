using Chess.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.WebAPI.Tools
{
    public class BoardConversion
    {
        /*********************
         * x = blank space/no piece
         * a = pawn white
         * b = rook white
         * c = knight white
         * d = bishop white
         * e = king white
         * f = queen white
         * g = pawn black
         * h = rook black
         * i = knight black
         * j = bishop black
         * k = king black
         * *******************/
        public static string MakeString(Board b)
        {
            string s = string.Empty;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    //
                }
            }
            return s;
        }

        public static Board MakeBoard(string str)
        {
            Board b = new Board();
            return b;
        }
    }

    /*
     * list of potential moves (boardstate + turn) in a new class Piece at x,y could move to... List<List<>>
     * f
     */

    public class Vector
    {
        public int x;
        public int y;
    }

    public class Move
    {
        public Piece p;
        public List<Vector> moves;

        public Move(Piece piece)
        {
            moves = new List<Vector>();
            p = piece;
        }
    }
}