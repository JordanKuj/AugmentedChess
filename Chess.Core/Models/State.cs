using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTest
{
    public class State
    {


        //public StateCheck()
        //{
        //}

        private static bool SeeOutput = false;

        private static void writeLine(string txt)
        {
            if (SeeOutput)
                Console.WriteLine(txt);
        }

        public static bool Comparer()
        {
            return true;
        }

        public static bool getDiff(Board state1, Board state2)
        {
            for (int j = 0; j < 8; j++)
                for (int i = 0; i < 8; i++)
                {
                    Piece p1 = state1.board[i, j];
                    Piece p2 = state2.board[i, j];
                    if (p1?.getName() != p2?.getName() || p1?.getTeam() != p2?.getTeam())
                        return false;
                }
            return true;
        }

        public static bool validState(Board state1, Board state2)
        {
            List<Tuple<int, int>> locations = new List<Tuple<int, int>>();
            int count = 0;
            for (int j = 0; j < 8; j++)
            {
                for (int i = 0; i < 8; i++)
                {

                    var state1Null = state1.board[i, j] == null;
                    var state2Null = state2.board[i, j] == null;
                    var s1 = state1.board[i, j];
                    var s2 = state2.board[i, j];

                    if (state1Null && state2Null)
                        continue;
                    else if ((!state1Null && state2Null) || (state1Null && !state2Null))
                    {
                        writeLine($"VS count = {count}");
                        locations.Add(new Tuple<int, int>(i, j));
                        count++;
                    }
                    else if (s1.getName() != s2.getName() && s1.getTeam() != s2.getTeam())
                    {
                        writeLine($"VS count = {count}");
                        locations.Add(new Tuple<int, int>(i, j));
                        count++;
                    }
                    if (count > 4)
                        break;

                }
                if (count > 4)
                    break;
            }

            if (count == 4)
            {
                writeLine("4 differences, checking castling");
                // Possible castle
                //white long castle
                if (locations[0] == new Tuple<int, int>(0, 0) && locations[1] == new Tuple<int, int>(2, 0)
                            && locations[2] == new Tuple<int, int>(3, 0) && locations[0] == new Tuple<int, int>(4, 0))
                {
                    return state1.validMove(4, 0, 2, 0);
                }
                //white short castle
                else if (locations[0] == new Tuple<int, int>(4, 0) && locations[1] == new Tuple<int, int>(5, 0)
                            && locations[2] == new Tuple<int, int>(6, 0) && locations[0] == new Tuple<int, int>(7, 0))
                {
                    return state1.validMove(4, 0, 6, 0);
                }
                //black long castle
                if (locations[0] == new Tuple<int, int>(0, 7) && locations[1] == new Tuple<int, int>(2, 7)
                            && locations[2] == new Tuple<int, int>(3, 7) && locations[0] == new Tuple<int, int>(4, 7))
                {
                    return state1.validMove(4, 7, 2, 7);
                }
                //black short castle
                else if (locations[0] == new Tuple<int, int>(4, 7) && locations[1] == new Tuple<int, int>(5, 7)
                            && locations[2] == new Tuple<int, int>(6, 7) && locations[0] == new Tuple<int, int>(7, 7))
                {
                    return state1.validMove(4, 7, 6, 7);

                }
            }
            else if (count == 2)
            {
                writeLine("2 differences standard move");
                int x0 = locations[0].Item1;
                int y0 = locations[0].Item2;
                int x1 = locations[1].Item1;
                int y1 = locations[1].Item2;

                if (state1.board[x0, y0] != null)
                {
                    return state1.validMove(x0, y0, x1, y1);
                }
                else if (state1.board[x1, y1] != null)
                {
                    return state1.validMove(x1, y1, x0, y0);
                }

            }
            else
            {
                writeLine("Not enough pieces moved");
                return false;
            }
            return false;
        }
    }
}
