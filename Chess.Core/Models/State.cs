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
                        Console.WriteLine("Board 1: {0},{1} :: {2}", i, j, state1.board[i, j].getName());

                        Console.WriteLine("Board 2: {0},{1} :: {2}", i, j, state2.board[i, j].getName());
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

                            Console.WriteLine("Board 2: {0},{1} :: {2}", i, j, state2.board[i, j].getName());
                        }
                        else if (!one && two)
                        {
                            Console.WriteLine("Board 1: {0},{1} :: {2}", i, j, state1.board[i, j].getName());

                            Console.WriteLine("Board 2: {0},{1} :: NULL", i, j);
                        }
                    }
                }
            }
            return true;
        }

        public int validState(Board state1, Board state2)
        {
            int[] horizontal = new int[64], vertical = new int[64];
            int count = 0;
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
                        horizontal[count] = i;
                        vertical[count] = j;
                        count++;
                        Console.WriteLine("Board 1: {0},{1} :: {2}", i, j, state1.board[i, j].getName());

                        Console.WriteLine("Board 2: {0},{1} :: {2}", i, j, state2.board[i, j].getName());
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
                            horizontal[count] = i;
                            vertical[count] = j;
                            count++;
                            Console.WriteLine("Board 1: {0},{1} :: NULL", i, j);

                            Console.WriteLine("Board 2: {0},{1} :: {2}", i, j, state2.board[i, j].getName());
                        }
                        else if (!one && two)
                        {
                            horizontal[count] = i;
                            vertical[count] = j;
                            count++;
                            Console.WriteLine("Board 1: {0},{1} :: {2}", i, j, state1.board[i, j].getName());

                            Console.WriteLine("Board 2: {0},{1} :: NULL", i, j);
                        }

                    }
                }
            }
            state1.printBoard();

            Console.WriteLine("STATE: {0},{1} - {2},{3}", horizontal[0], vertical[0], horizontal[1], vertical[1]);
            state1.validMove(horizontal[0], vertical[0], horizontal[1], vertical[1]);
            state1.printBoard();
            return count;
           
        }
    }
}
