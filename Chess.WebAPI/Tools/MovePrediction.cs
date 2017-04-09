using ChessTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.WebAPI.Tools
{
    public class MovePrediction
    {
        /*
         * list of potential moves (boardstate + turn) in a new class Piece at x,y could move to... List<Vector()>
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

            public void setMoves(List<Vector> possibleMoves)
            {
                moves = possibleMoves;
            }
        }

        public static Move predict(Piece p)
        {
            Move m = new Move(p);
            List<Vector> possible = null;  // assuming no moves possible at start

            // logic tbd here
            m.setMoves(possible);

            return m;
        }
    }
}