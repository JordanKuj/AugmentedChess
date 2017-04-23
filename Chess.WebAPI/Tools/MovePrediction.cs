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
        public static List<Move> predict(ChessTest.Board b, Team t)
        {
            Move move;
            List<Move> allMoves = new List<Move>();
            Vector v = new Vector();
            List<Vector> possibleMoves = new List<Vector>();
            List<Moveset> pm = b.listAllMoves(t);  // predicted moves
            List<Tuple<int, int>> endList;

            for (int i = 0; i < pm.LongCount(); i++)
            {
                var m = pm.ElementAt(i);
                Piece p = new Piece(t, m.piece.getName());
                move = new Move(p);
                endList = m.GetMoveEnds();
                foreach (var coord in endList)
                {
                    v.setX(coord.Item1);
                    v.setY(coord.Item2);
                    possibleMoves.Add(v);
                }
                move.setMoves(possibleMoves);
                allMoves.Add(move);
            }

            return allMoves;
        }

        public static void printPredict(List<Move> moves)
        {
            foreach (var m in moves)
            {
                for (int i = 0; i < m.moves.LongCount(); i++)
                {
                    Console.WriteLine(m.p.getNameString() + ": " + m.moves.ElementAt(i).x + ", " + m.moves.ElementAt(i).y);
                }

            }
        }

        /*public static void printPrediction(Moveset moves)
        {
            Piece p = moves.GetMovePiece();
            Tuple<int, int> s = moves.GetMoveStart();
            List<Tuple<int, int>> e = moves.GetMoveEnds();

            Console.WriteLine("Piece: " + p.getName());
            Console.WriteLine("Starts at: " + s.Item1 + ", " + s.Item2);
            Console.WriteLine("Can go to:");
            foreach (var ending in e)
                Console.WriteLine(ending.Item1 + ", " + ending.Item2);
        }

        public static void printAllPredictions(List<Moveset> allMoves)
        {
            foreach (var move in allMoves)
                printPrediction(move);
        }*/
    }
}