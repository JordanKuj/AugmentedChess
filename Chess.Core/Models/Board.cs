using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Core.Models
{
    class Board
    {
        //turn is true for white, false for black
        bool turn;

        //array of Pieces initialized to 8x8 starting position
        Piece[,] board;
        /*
         * layout of board
        board[x,y] 
        7 R N B K Q B N R
        6 P P P P P P P P
        5 0 0 0 0 0 0 0 0     
     Y  4 0 0 0 0 0 0 0 0     
        3 0 0 0 0 0 0 0 0     
        2 0 0 0 0 0 0 0 0
        1 P P P P P P P P     
        0 R N B K Q B N R     
          0 1 2 3 4 5 6 7
                 X
        */
        //initializes a board to the starting layout
        public Board()
        {
            board = new Piece[8, 8];

            board[0, 0] = new Piece(true, "rook");
            board[1, 0] = new Piece(true, "knight");
            board[2, 0] = new Piece(true, "bishop");
            board[3, 0] = new Piece(true, "king");
            board[4, 0] = new Piece(true, "queen");
            board[5, 0] = new Piece(true, "bishop");
            board[6, 0] = new Piece(true, "knight");
            board[7, 0] = new Piece(true, "rook");
            board[0, 1] = new Piece(true, "pawn");
            board[1, 1] = new Piece(true, "pawn");
            board[2, 1] = new Piece(true, "pawn");
            board[3, 1] = new Piece(true, "pawn");
            board[4, 1] = new Piece(true, "pawn");
            board[5, 1] = new Piece(true, "pawn");
            board[6, 1] = new Piece(true, "pawn");
            board[7, 1] = new Piece(true, "pawn");
            //set up white team

            board[0, 7] = new Piece(false, "rook");
            board[1, 7] = new Piece(false, "knight");
            board[2, 7] = new Piece(false, "bishop");
            board[3, 7] = new Piece(false, "king");
            board[4, 7] = new Piece(false, "queen");
            board[5, 7] = new Piece(false, "bishop");
            board[6, 7] = new Piece(false, "knight");
            board[7, 7] = new Piece(false, "rook");
            board[0, 6] = new Piece(false, "pawn");
            board[1, 6] = new Piece(false, "pawn");
            board[2, 6] = new Piece(false, "pawn");
            board[3, 6] = new Piece(false, "pawn");
            board[4, 6] = new Piece(false, "pawn");
            board[5, 6] = new Piece(false, "pawn");
            board[6, 6] = new Piece(false, "pawn");
            board[7, 6] = new Piece(false, "pawn");
            //set up black team
            turn = true;
        }

        //loops through board and prints layout to console used for debugging
        public void printBoard()
        {
            for (int j = 7; j >= 0; j--)
            {
                Console.Write("{0}: ", j);
                for (int i = 0; i < 8; i++)
                {
                    if (board[i, j] == null)
                    {
                        Console.Write("   ");
                    }
                    else
                    {
                        switch (board[i, j].getName())
                        {
                            case "rook":
                                Console.Write("R  ");
                                break;
                            case "knight":
                                Console.Write("N  ");
                                break;
                            case "bishop":
                                Console.Write("B  ");
                                break;
                            case "king":
                                Console.Write("K  ");
                                break;
                            case "queen":
                                Console.Write("Q  ");
                                break;
                            case "pawn":
                                Console.Write("P  ");
                                break;
                            default:
                                Console.Write("");
                                break;
                        }
                    }

                }
                Console.Write("\n");
            }
            Console.WriteLine("   0  1  2  3  4  5  6  7");
            return;
        }

        public bool teamMove(int a, int b, int x, int y)
        {
            if (turn != board[a, b].getTeam())
            {
                Console.WriteLine("Not Your Turn");
                return false;
            }
            if (!validMove(a, b, x, y))
            {
                return false;
            }
            turn = !turn;
            return true;
        }

        //move piece from [a,b] to [x,y]
        //no checks, no logic, will replace any piece at end position
        public bool move(int a, int b, int x, int y)
        {
            Console.WriteLine("MOVE: {0}:{1} to {2}:{3}", a, b, x, y);
            Piece temp = board[a, b].copy();
            board[x, y] = board[a, b];
            board[a, b] = null;
            board[x, y].setHasMoved();
            return true;
        }


        //checks logic of the move and determines if valid for that piece
        //does not check collisions, those are handled by called methods
        public bool validMove(int a, int b, int x, int y)
        {
            //check if any indexes are out of bounds
            if (a < 0 || b < 0 || x < 0 || y < 0 || a > 7 || b > 7 || x > 7 || y > 7)
            {
                Console.WriteLine("INDEX OUT OF BOUNDS");
                return false;
            }

            //check the move distance so it is not 0
            if (a == x && b == y)
            {
                Console.WriteLine("MOVE MUST HAVE A DISTANCE");
                return false;
            }

            //check if a piece is at the starting position
            if (board[a, b] == null)
            {
                Console.WriteLine("NO PIECE AT START LOCATION");
                return false;
            }

            //checks the name of the piece at the starting position and if the move is valid for that type of piece
            switch (board[a, b].getName())
            {
                //rook can move up down left or right so a-x or b-y most be 0
                case "rook":
                    if (a - x == 0 || b - y == 0)
                    {
                        if (stepThrough(a, b, x, y))
                        {

                            return move(a, b, x, y);
                        }
                        else
                        {
                            Console.WriteLine("Collision in Loop");
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("INVALID ROOK MOVE {0},{1}", x - a, y - b);
                        return false;
                    }
                    break;
                
                //knight can move in L shape so x dist + y dist must be three with neither being three by itself
                case "knight":
                    if (Math.Abs(a - x) + Math.Abs(b - y) == 3 && Math.Abs(a - x) != 3 && Math.Abs(b - y) != 3)
                    {
                        return move(a, b, x, y);
                    }
                    else
                    {
                        Console.WriteLine("INVALID KNIGHT MOVE {0},{1}", x - a, y - b);
                        return false;
                    }
                    break;

                //bishop can move diagonally so |a-x| == |b-y|
                case "bishop":
                    if (Math.Abs(a - x) == Math.Abs(b - y))
                    {
                        if (stepThrough(a, b, x, y))
                        {
                            return move(a, b, x, y);
                        }
                        else
                        {
                            Console.WriteLine("Collision in Loop");
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("INVALID BISHOP MOVE {0},{1}", x - a, y - b);
                        return false;
                    }
                    break;

                //king can move one square in any direction so |a-x| and |b-y| must be one or 0
                case "king":
                    if ((Math.Abs(a - x) == 1 || Math.Abs(a - x) == 0) && (Math.Abs(b - y) == 1 || Math.Abs(b - y) == 0))
                    {

                    }
                    else
                    {
                        Console.WriteLine("INVALID KING MOVE {0},{1}", x - a, y - b);
                        return false;
                    }
                    break;

                //queen combines rook and bishop logic
                case "queen":
                    if ((a - x == 0 || b - y == 0) || (Math.Abs(a - x) == Math.Abs(b - y)))
                    {
                        if (stepThrough(a, b, x, y))
                        {
                            return move(a, b, x, y);
                        }
                        else
                        {
                            Console.WriteLine("Collision in Loop");
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("INVALID QUEEN MOVE {0},{1}", x - a, y - b);
                        return false;
                    }
                    break;

                //pawn can move straight up and down one space or 2 if it is the first move
                //TODO create logic for taking and team specific movesets
                case "pawn":
                    //pawn can always move one square
                    if (a - x == 0 && Math.Abs(b - y) == 1)
                    {
                        move(a, b, x, y);
                        return true;
                    }
                    //if pawn has not moved, it can move 2 spaces
                    if (!board[a, b].getHasMoved() && (a - x == 0 && Math.Abs(b - y) == 2))
                    {
                        move(a, b, x, y);
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("INVALID PAWN MOVE {0},{1}", x - a, y - b);
                        return false;
                    }
                    break;
                //code should never reach default state
                default:
                    Console.WriteLine("NO PIECE AT START LOCATION");
                    break;
            }
            //function should return in cases
            Console.WriteLine("Should Not Get Here");
            return false;
        }

        //determine the direction moved, up, down left right or diagonal
        public bool stepThrough(int a, int b, int x, int y)
        {
            Console.WriteLine("Step Through [{0},{1}] [{2},{3}]", a, b, x, y);
            //if move is straight up or down
            if (a == x)
            {
                //move is up
                if (b < y)
                {
                    return loopUp(a, b, x, y);
                }
                //move is down
                else return loopDown(a, b, x, y);
            }
            //if move is straight left or right
            if (b == y)
            {
                //move is right
                if (a < x)
                {
                    return loopRight(a, b, x, y);
                }
                //move is left
                else return loopLeft(a, b, x, y);
            }
            //if move is up left or up right
            if (a < x)
            {
                //move is up right
                if (b < y)
                {
                    return loopUpRight(a, b, x, y);
                }
                //move is up left
                else return loopDownRight(a, b, x, y);
            }
            //if move is down left or down right
            if (a > x)
            {
                //move is down right
                if (b < y)
                {
                    return loopDownRight(a, b, x, y);
                }
                //move is down left
                else return loopDownLeft(a, b, x, y);
            }

            //code should return before this point
            Console.WriteLine("SHOULD NOT PRINT");
            return false;

        }

        //-------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------
        //methods below are used to loop through the grid and return true if no collisions, false if collision is found
        //may be replaced with recursive methods in sprint  2
        public bool loopUp(int a, int b, int x, int y)
        {
            Console.WriteLine("LOOP UP");
            for (int i = b + 1; i < y; i++)
            {
                Console.WriteLine("Checking [{0},{1}]", a, i);
                if (board[a, i] == null)
                {
                    continue;
                }
                return false;
            }
            return true;
        }
        public bool loopUpRight(int a, int b, int x, int y)
        {
            Console.WriteLine("LOOP UP RIGHT");
            int j = b + 1;
            for (int i = a + 1; i < x; i++, j++)
            {
                Console.WriteLine("Checking [{0},{1}]", i, j);
                if (board[i, j] == null)
                {
                    continue;
                }
                return false;
            }
            return true;
        }
        public bool loopRight(int a, int b, int x, int y)
        {
            Console.WriteLine("LOOP RIGHT");
            for (int i = a + 1; i < x; i++)
            {
                Console.WriteLine("Checking [{0},{1}]", i, b);
                if (board[i, b] == null)
                {
                    continue;
                }
                return false;
            }
            return true;
        }
        public bool loopDownRight(int a, int b, int x, int y)
        {
            int j = b - 1;
            for (int i = a + 1; i < x; i++, j--)
            {
                Console.WriteLine("Checking [{0},{1}]", i, j);
                if (board[i, j] == null)
                {
                    continue;
                }
                return false;
            }
            return true;
        }
        public bool loopDown(int a, int b, int x, int y)
        {
            Console.WriteLine("LOOP DOWN");
            for (int i = b - 1; i > y; i--)
            {
                Console.WriteLine("Checking [{0},{1}]", a, i);
                if (board[a, i] == null)
                {
                    continue;
                }
                return false;
            }
            return true;
        }
        public bool loopDownLeft(int a, int b, int x, int y)
        {
            Console.WriteLine("LOOP DOWN LEFT");
            int j = b - 1;
            for (int i = a - 1; i > x; i--, j--)
            {
                Console.WriteLine("Checking [{0},{1}]", i, j);
                if (board[a, i] == null)
                {
                    continue;
                }
                return false;
            }
            return true;
        }
        public bool loopLeft(int a, int b, int x, int y)
        {
            Console.WriteLine("LOOP LEFT");
            for (int i = a - 1; i > x; i--)
            {
                Console.WriteLine("Checking [{0},{1}]", i, b);
                if (board[i, a] == null)
                {
                    continue;
                }
                return false;
            }
            return true;
        }
        public bool loopUpLeft(int a, int b, int x, int y)
        {
            Console.WriteLine("LOOP UP LEFT");
            int j = b + 1;
            for (int i = a - 1; i > x; i--, j++)
            {
                Console.WriteLine("Checking [{0},{1}]", i, j);
                if (board[i, j] == null)
                {
                    continue;
                }
                return false;
            }
            return true;
        }

    }
}
