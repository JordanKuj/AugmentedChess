using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTest
{
    class State
    {


        public State()
        {
        }


        public bool Comparer()
        {
            return true;
        }

        public bool getDiff(Board state1, Board state2)
        {
            bool one = false;
            bool two = false;
            for (int j = 0; j < 8; j++)
            {
                for (int i = 0; i < 8; i++)
                {
                    one = false;
                    two = false;
                    try
                    {
                        if (state1.board[i, j].getName() == state2.board[i, j].getName())
                        {
                            //Console.WriteLine("{0}{1} SAME", i, j);
                            continue;
                        }
                        Console.WriteLine("Board 1: {0},{1} :: {2}", i, j, state1.board[i, j].getName().ToString());

                        Console.WriteLine("Board 2: {0},{1} :: {2}", i, j, state2.board[i, j].getName().ToString());
                    }
                    //one is null
                    catch
                    {
                        try
                        {
                            state1.board[i, j].getTeam();
                        }
                        catch
                        {
                            one = true;
                        }
                        try
                        {
                            state2.board[i, j].getTeam();
                        }
                        catch
                        {
                            two = true;
                        }
                        if (one && two)
                        {
                            continue;
                        }
                        else if (one && !two)
                        {
                            Console.WriteLine("Board 1: {0},{1} :: NULL", i, j);

                            Console.WriteLine("Board 2: {0},{1} :: {2}", i, j, state2.board[i, j].getName().ToString());
                        }
                        else if (!one && two)
                        {
                            Console.WriteLine("Board 1: {0},{1} :: {2}", i, j, state1.board[i, j].getName().ToString());

                            Console.WriteLine("Board 2: {0},{1} :: NULL", i, j);
                        }

                    }



                }
            }
            return true;
        }

        public bool validState(Board state1, Board state2)
        {
            Tuple<int, int>[] locations = new Tuple<int, int>[10];
            int count = 0;
            for (int j = 0; j < 8; j++)
            {
                for (int i = 0; i < 8; i++)
                {

                    if (state1.board[i, j] == null && state2.board[i, j] == null)
                    {
                        continue;
                    }
                    else if ((state1.board[i, j] != null && state2.board[i, j] == null) || (state1.board[i, j] == null && state2.board[i, j] != null))
                    {
                        Console.WriteLine("VS count = {0}", count);
                        locations[count] = new Tuple<int, int>(i, j);
                        count++;
                    }
                    else if (state1.board[i, j].getName() != state2.board[i, j].getName() && state1.board[i, j].getTeam() != state2.board[i, j].getTeam())
                    {
                        Console.WriteLine("VS count = {0}", count);
                        locations[count] = new Tuple<int, int>(i, j);
                        count++;
                    }

                }
            }

            if (count == 4)
            {
                Console.WriteLine("4 differences, checking castling");
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
                Console.WriteLine("2 differences standard move");
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
                Console.WriteLine("Not enough pieces moved");
                return false;
            }
            return false;
        }
    }
}
