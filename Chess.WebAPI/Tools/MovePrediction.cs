using ChessTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static ChessTest.Board;

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

            public void setX(int xMove)
            {
                this.x = xMove;
            }

            public void setY(int yMove)
            {
                this.y = yMove;
            }
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

        // sets all moves possible for team t
        public static List<Moveset> predictAll(Team t)
        {
            ChessTest.Board b = new ChessTest.Board();
            List<Moveset> moves = new List<Moveset>();
            moves = b.listAllMoves(t);
            return moves;
        }
    }
}