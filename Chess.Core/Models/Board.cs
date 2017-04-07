using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTest
{
    public class Board
    {
        Team turn;
        public class Moveset
        {
            public Piece piece;
            public Tuple<int, int> start;
            public List<Tuple<int, int>> end;
        }
        public Piece[,] board;
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
        public Board()
        {
            board = new Piece[8, 8];

            board[0, 0] = new Piece(Team.white, PieceType.rook);
            board[1, 0] = new Piece(Team.white, PieceType.knight);
            board[2, 0] = new Piece(Team.white, PieceType.bishop);
            board[3, 0] = new Piece(Team.white, PieceType.queen);
            board[4, 0] = new Piece(Team.white, PieceType.king);
            board[5, 0] = new Piece(Team.white, PieceType.bishop);
            board[6, 0] = new Piece(Team.white, PieceType.knight);
            board[7, 0] = new Piece(Team.white, PieceType.rook);
            board[0, 1] = new Piece(Team.white, PieceType.pawn);
            board[1, 1] = new Piece(Team.white, PieceType.pawn);
            board[2, 1] = new Piece(Team.white, PieceType.pawn);
            board[3, 1] = new Piece(Team.white, PieceType.pawn);
            board[4, 1] = new Piece(Team.white, PieceType.pawn);
            board[5, 1] = new Piece(Team.white, PieceType.pawn);
            board[6, 1] = new Piece(Team.white, PieceType.pawn);
            board[7, 1] = new Piece(Team.white, PieceType.pawn);
            //set up white team

            board[0, 7] = new Piece(Team.black, PieceType.rook);
            board[1, 7] = new Piece(Team.black, PieceType.knight);
            board[2, 7] = new Piece(Team.black, PieceType.bishop);
            board[3, 7] = new Piece(Team.black, PieceType.queen);
            board[4, 7] = new Piece(Team.black, PieceType.king);
            board[5, 7] = new Piece(Team.black, PieceType.bishop);
            board[6, 7] = new Piece(Team.black, PieceType.knight);
            board[7, 7] = new Piece(Team.black, PieceType.rook);
            board[0, 6] = new Piece(Team.black, PieceType.pawn);
            board[1, 6] = new Piece(Team.black, PieceType.pawn);
            board[2, 6] = new Piece(Team.black, PieceType.pawn);
            board[3, 6] = new Piece(Team.black, PieceType.pawn);
            board[4, 6] = new Piece(Team.black, PieceType.pawn);
            board[5, 6] = new Piece(Team.black, PieceType.pawn);
            board[6, 6] = new Piece(Team.black, PieceType.pawn);
            board[7, 6] = new Piece(Team.black, PieceType.pawn);
            //set up black team
            turn = Team.white;
        }
        public Board(Board b)
        {
            turn = b.turn;
            board = b.board;
        }

        public Piece getAt(int x, int y)
        {
            return board[x, y];
        }
        
        public void printBoard()
        {
            for (int j = 7; j >= 0; j--)
            {
                Console.Write("{0}: ", j);
                for (int i = 0; i < 8; i++)
                {
                    if (getAt(i, j) == null)
                    {
                        Console.Write("   ");
                    }
                    else
                    {
                        switch (getAt(i, j).getName())
                        {
                            case PieceType.rook:
                                Console.Write("R  ");
                                break;
                            case PieceType.knight:
                                Console.Write("N  ");
                                break;
                            case PieceType.bishop:
                                Console.Write("B  ");
                                break;
                            case PieceType.king:
                                Console.Write("K  ");
                                break;
                            case PieceType.queen:
                                Console.Write("Q  ");
                                break;
                            case PieceType.pawn:
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
        public bool inCheck(Team t, bool checkmate)
        {
            int x = 0;
            int y = 0;
            bool flag = true;
            for (int ky = 0; ky < 8 && flag; ky++)
            {
                for (int kx = 0; kx < 8 && flag; kx++)
                {
                    Console.WriteLine("{0},{1}  {2}  {3}", kx, ky, getAt(kx, ky)?.getName(), getAt(kx, ky)?.getTeam());
                    if (getAt(kx, ky) != null && getAt(kx, ky).getName() == PieceType.king && getAt(kx, ky).getTeam() == t)
                    {
                        x = kx;
                        y = ky;
                        Console.WriteLine("Found");
                        flag = false;
                        break;
                    }
                }

            }

            Console.WriteLine("King at {0}{1}", x, y);
            if (x == 8 || y == 8)
            {
                return false;
            }
            if (t == Team.white)
            {


                for (int j = 0; j < 8; j++)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        if (getAt(i, j) != null && getAt(i, j).getTeam() == Team.black)
                        {
                            Console.WriteLine("{0}{1} {2}{3}", i, j, x, y);
                            Console.WriteLine("{0}", validNoMove(i, j, x, y));
                            if (validNoMove(i, j, x, y))
                            {
                                Console.WriteLine("White King in Check");
                                if (checkmate)
                                {
                                    inCheckmate(Team.white);
                                }

                                return true;
                            }
                        }
                    }

                }
                return false;
            }
            if (t == Team.black)
            {

                for (int j = 0; j < 8; j++)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        if (getAt(i, j) != null && getAt(i, j).getTeam() == Team.white)
                        {
                            if (validNoMove(i, j, x, y))
                            {
                                Console.WriteLine("Black King in Check");
                                if (checkmate)
                                {
                                    inCheckmate(Team.black);
                                }
                                return true;
                            }
                        }
                    }

                }
            }
            return false;
        }
        public bool inCheckmate(Team t)
        {
            int kingx = 0;
            int kingy = 0;
            bool flag = true;
            Tuple<int, int>[] locations = new Tuple<int, int>[15];
            int locCount = 0;
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (getAt(x, y) != null && getAt(x, y).getTeam() == t)
                    {
                        locations[locCount] = new Tuple<int, int>(x, y);
                        locCount++;
                    }
                    if (flag && getAt(x, y) != null && getAt(x, y).getName() == PieceType.king && getAt(x, y).getTeam() == t)
                    {
                        flag = false;
                        kingx = x;
                        kingy = y;
                    }
                }

            }
            //try {
            Board copy = new Board();

            for (int l = 0; l < locCount; l++)
            {
                for (int j = 0; j < 8; j++)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        copy.board = (Piece[,])board.Clone();
                        if (copy.validMove(locations[l].Item1, locations[l].Item2, i, j) && copy.inCheck(t, false))
                        {
                            Console.WriteLine("NOT IN CHECKMATE");
                            return false;
                        }



                    }
                }



            }
            // }
            //catch(Exception e)
            // {
            //Console.WriteLine(e);
            //Console.WriteLine("THROW {0} in checkmate", t.ToString());
            //return true;
            // }

            Console.WriteLine("{0} in checkmate", t.ToString());
            return true;
        }
        public bool teamMove(int a, int b, int x, int y)
        {
            if (turn != getAt(a, b).getTeam())
            {
                Console.WriteLine("Not Your Turn");
                return false;
            }
            if (!validMove(a, b, x, y))
            {
                return false;
            }
            turn = turn == Team.white ? Team.black : Team.white;
            return true;
        }
        public bool move(int a, int b, int x, int y)
        {
            Console.WriteLine("MOVE: {0}:{1} to {2}:{3}", a, b, x, y);
            board[x, y] = getAt(a, b);
            board[a, b] = null;
            getAt(x, y).setHasMoved();
            return true;
        }
        public bool capture(int x, int y)
        {
            if (getAt(x, y) == null)
            {
                //Console.WriteLine("no piece at end");
                return true;
            }
            if (getAt(x, y).getTeam() == turn)
            {
                // Console.WriteLine("Cannot capture own team {0} at {1},{2}", getAt(x, y).getName(), x, y);
                return false;
            }

            Console.WriteLine("Capturing {0} at {1},{2}", getAt(x, y).getName(), x, y);
            return true;
        }
        
      public bool validMove(int a, int b, int x, int y)
        {
            if (a < 0 || b < 0 || x < 0 || y < 0)
            {
                Console.WriteLine("INDEX OUT OF BOUNDS");
                return false;
            }
            if (a == x && b == y)
            {
                Console.WriteLine("MOVE MUST HAVE A DISTANCE");
                return false;
            }
            if (getAt(a, b) == null)
            {
                Console.WriteLine("NO PIECE AT START LOCATION");
                return false;
            }

            switch (getAt(a, b).getName())
            {
                case PieceType.rook:
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

                case PieceType.knight:
                    if (Math.Abs(a - x) + Math.Abs(b - y) == 3 && Math.Abs(a - x) != 3 && Math.Abs(b - y) != 3 && board[x, y]?.getTeam() != getAt(a, b)?.getTeam())
                    {
                        return move(a, b, x, y);
                    }
                    else
                    {
                        Console.WriteLine("INVALID KNIGHT MOVE {0},{1}", x - a, y - b);
                        return false;
                    }

                case PieceType.bishop:
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

                case PieceType.king:
                    if ((Math.Abs(a - x) == 1 || Math.Abs(a - x) == 0) && (Math.Abs(b - y) == 1 || Math.Abs(b - y) == 0) ||
                        (Math.Abs(a - x) == 2 && b - y == 0))
                    {
                        if (Math.Abs(a - x) == 2)
                        {
                            Console.WriteLine("castling");
                            return castle(x, y);
                        }
                        else if (stepThrough(a, b, x, y))
                        {
                            return move(a, b, x, y);
                        }
                    }
                    else
                    {
                        Console.WriteLine("INVALID KING MOVE {0},{1}", x - a, y - b);
                        return false;
                    }
                    break;
                case PieceType.queen:
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

                case PieceType.pawn:
                    if (a - x == 0 && ((b - y == -1 && getAt(a, b).getTeam() == Team.white)
                                                || (b - y == 1 && getAt(a, b).getTeam() == Team.white)))
                    {
                        return true;
                    }
                    else if (!getAt(a, b).getHasMoved() && (a - x == 0 && Math.Abs(b - y) == 2))
                    {
                        return true;
                    }
                    else if (Math.Abs(a - x) == 1 && ((b - y == 1 && getAt(a, b).getTeam() == Team.black)
                                                || (b - y == -1 && getAt(a, b).getTeam() == Team.white)))
                    {
                        //diagonal capture
                        return true;
                    }
                    else
                    {

                        return false;
                    }

                default:
                    Console.WriteLine("NO PIECE AT START LOCATION");
                    break;
            }
            Console.WriteLine("Should Not Get Here");
            return false;
        }
        public bool stepThrough(int a, int b, int x, int y)
        {
            //Console.WriteLine("Step Through [{0},{1}] [{2},{3}]", a, b, x, y);
            //if move is straight up or down
            if (a == x)
            {
                if (b < y)
                {
                    return loopUp(a, b, x, y);
                }
                else return loopDown(a, b, x, y);
            }
            //if move is straight left or right
            if (b == y)
            {
                if (a < x)
                {
                    return loopRight(a, b, x, y);
                }
                else return loopLeft(a, b, x, y);
            }
            //if move is up left or up right
            if (a < x)
            {
                if (b < y)
                {
                    return loopUpRight(a, b, x, y);
                }
                else return loopDownRight(a, b, x, y);
            }
            //if move is down left or down right
            if (a > x)
            {
                if (b < y)
                {
                    return loopUpLeft(a, b, x, y);
                }
                else return loopDownLeft(a, b, x, y);
            }
            //Console.WriteLine("SHOULD NOT PRINT");
            return false;
        }
        public bool loopUp(int a, int b, int x, int y)
        {
            //Console.WriteLine("Checking {0},{1}", a, b + 1);

            if (b + 1 == y)
            {
                return capture(x, y);
            }
            else if (board[a, b + 1] != null)
            {
                return false;
            }
            return loopUp(a, b + 1, x, y);

        }
        public bool loopDown(int a, int b, int x, int y)
        {
            Console.WriteLine("Checking {0},{1}", a, b - 1);

            if (b - 1 == y)
            {
                return capture(x, y);
            }
            else if (board[a, b - 1] != null)
            {
                return false;
            }
            return loopDown(a, b - 1, x, y);
        }
        public bool loopRight(int a, int b, int x, int y)
        {
            //Console.WriteLine("Checking {0},{1}", a + 1, b);

            if (a + 1 == x)
            {
                return capture(x, y);
            }
            else if (board[a + 1, b] != null)
            {
                return false;
            }
            return loopRight(a + 1, b, x, y);
        }
        public bool loopLeft(int a, int b, int x, int y)
        {
            //Console.WriteLine("Checking {0},{1}", a - 1, b);

            if (a - 1 == x)
            {
                return capture(x, y);
            }
            else if (board[a - 1, b] != null)
            {
                return false;
            }
            return loopLeft(a - 1, b, x, y);
        }
        public bool loopUpLeft(int a, int b, int x, int y)
        {
            //Console.WriteLine("Checking {0},{1}", a - 1, b + 1);

            if (a - 1 == x)
            {
                return capture(x, y);
            }
            else if (board[a - 1, b + 1] != null)
            {
                return false;
            }
            return loopUpLeft(a - 1, b + 1, x, y);
        }
        public bool loopUpRight(int a, int b, int x, int y)
        {
            //Console.WriteLine("Checking {0},{1}", a + 1, b + 1);

            if (a + 1 == x)
            {
                return capture(x, y);
            }
            else if (board[a + 1, b + 1] != null)
            {
                return false;
            }
            return loopUpRight(a + 1, b + 1, x, y);
        }
        public bool loopDownLeft(int a, int b, int x, int y)
        {
            //Console.WriteLine("Checking {0},{1}", a - 1, b - 1);

            if (a - 1 == x)
            {
                return capture(x, y);
            }
            else if (board[a - 1, b - 1] != null)
            {
                return false;
            }
            return loopDownLeft(a - 1, b - 1, x, y);
        }
        public bool loopDownRight(int a, int b, int x, int y)
        {
            //Console.WriteLine("Checking {0},{1}", a + 1, b - 1);

            if (a + 1 == x)
            {
                return capture(x, y);
            }
            else if (board[a + 1, b - 1] != null)
            {
                return false;
            }
            return loopDownRight(a + 1, b - 1, x, y);
        }
        public bool castle(int x, int y)
        {

            if (y == 0)
            {
                //white long castle
                if (x == 2 && board[0, 0].getName() == PieceType.rook
                        && !board[0, 0].getHasMoved() && !board[4, 0].getHasMoved()
                        && board[1, 0] == null && board[2, 0] == null && board[3, 0] == null)
                {
                    move(0, 0, 3, 0);
                    move(4, 0, 2, 0);
                    return true;
                }
                //white short castle
                else if (x == 6 && board[7, 0].getName() == PieceType.rook
                        && !board[7, 0].getHasMoved() && !board[4, 0].getHasMoved()
                        && board[5, 0] == null && board[6, 0] == null)
                {

                    move(7, 0, 5, 0);
                    move(4, 0, 6, 0);
                    return true;
                }

            }
            else if (y == 7)
            {
                //black long castle
                if (x == 2 && board[0, 7].getName() == PieceType.rook
                        && !board[0, 7].getHasMoved() && !board[4, 0].getHasMoved()
                        && board[1, 7] == null && board[2, 7] == null && board[3, 7] == null)
                {
                    move(0, 7, 3, 7);
                    move(4, 7, 2, 7);
                    return true;
                }
                //black short castle
                else if (x == 6 && board[0, 7].getName() == PieceType.rook
                        && !board[7, 7].getHasMoved() && !board[4, 7].getHasMoved()
                        && board[5, 7] == null && board[6, 7] == null)
                {

                    move(7, 7, 5, 7);
                    move(4, 7, 6, 7);
                    return true;
                }
            }

            return false;
        }
        public bool validNoMove(int a, int b, int x, int y)
        {
            if (a < 0 || b < 0 || x < 0 || y < 0)
            {

                return false;
            }
            if (a == x && b == y)
            {

                return false;
            }
            if (getAt(a, b) == null)
            {

                return false;
            }

            switch (getAt(a, b).getName())
            {
                case PieceType.rook:
                    if (a - x == 0 || b - y == 0)
                    {
                        if (stepThrough(a, b, x, y))
                        {

                            return true;
                        }
                        else
                        {

                            return false;
                        }
                    }
                    else
                    {

                        return false;
                    }

                case PieceType.knight:
                    if (Math.Abs(a - x) + Math.Abs(b - y) == 3 && Math.Abs(a - x) != 3 && Math.Abs(b - y) != 3 && getAt(x, y)?.getTeam() != getAt(a, b).getTeam())
                    {
                        return true;
                    }
                    else
                    {

                        return false;
                    }

                case PieceType.bishop:
                    if (Math.Abs(a - x) == Math.Abs(b - y))
                    {
                        if (stepThrough(a, b, x, y))
                        {
                            return true;
                        }
                        else
                        {

                            return false;
                        }
                    }
                    else
                    {

                        return false;
                    }

                case PieceType.king:
                    if ((Math.Abs(a - x) == 1 || Math.Abs(a - x) == 0) && (Math.Abs(b - y) == 1 || Math.Abs(b - y) == 0) ||
                        (Math.Abs(a - x) == 2 && b - y == 0))
                    {
                        if (Math.Abs(a - x) == 2)
                        {

                            return castleNoMove(x, y);
                        }
                        else if (stepThrough(a, b, x, y))
                        {
                            return true;
                        }
                    }
                    else
                    {

                        return false;
                    }
                    break;
                case PieceType.queen:
                    //Console.WriteLine("MOVE {0}{1} {2}{3}", a, b, x, y);
                    if ((a - x == 0 || b - y == 0) || (Math.Abs(a - x) == Math.Abs(b - y)))
                    {
                        //Console.WriteLine("Valid direction");
                        if (stepThrough(a, b, x, y))
                        {
                            //Console.WriteLine("Valid step");
                            return true;
                        }
                        else
                        {

                            return false;
                        }
                    }
                    else
                    {

                        return false;
                    }

                case PieceType.pawn:
                    if (a - x == 0 && ((b - y == -1 && getAt(a, b).getTeam() == Team.white)
                                                || (b - y == 1 && getAt(a, b).getTeam() == Team.black)))
                    {
                        return true;
                    }
                    else if (!getAt(a, b).getHasMoved() && (a - x == 0 && Math.Abs(b - y) == 2))
                    {
                        return true;
                    }
                    else if (Math.Abs(a - x) == 1 && ((b - y == 1 && getAt(a, b).getTeam() == Team.black && getAt(x, y) != null && getAt(x, y).getTeam() == Team.white)
                                                || (b - y == -1 && getAt(a, b).getTeam() == Team.white && getAt(x, y) != null && getAt(x, y).getTeam() == Team.black)))
                    {
                        //diagonal capture
                        return true;
                    }
                    else
                    {

                        return false;
                    }

                default:

                    break;
            }
            Console.WriteLine("Should Not Get Here");
            return false;
        }
        public bool castleNoMove(int x, int y)
        {

            if (y == 0)
            {
                //white long castle
                if (x == 2 && board[0, 0].getName() == PieceType.rook
                        && !board[0, 0].getHasMoved() && !board[4, 0].getHasMoved()
                        && board[1, 0] == null && board[2, 0] == null && board[3, 0] == null)
                {
                    return true;
                }
                //white short castle
                else if (x == 6 && board[7, 0].getName() == PieceType.rook
                        && !board[7, 0].getHasMoved() && !board[4, 0].getHasMoved()
                        && board[5, 0] == null && board[6, 0] == null)
                {
                    return true;
                }

            }
            else if (y == 7)
            {
                //black long castle
                if (x == 2 && board[0, 7].getName() == PieceType.rook
                        && !board[0, 7].getHasMoved() && !board[4, 0].getHasMoved()
                        && board[1, 7] == null && board[2, 7] == null && board[3, 7] == null)
                {
                    return true;
                }
                //black short castle
                else if (x == 6 && board[0, 7].getName() == PieceType.rook
                        && !board[7, 7].getHasMoved() && !board[4, 7].getHasMoved()
                        && board[5, 7] == null && board[6, 7] == null)
                {
                    return true;
                }
            }

            return false;
        }


        //returns a list of Moveset which contains a Piece, starting coordinates and a list of end coordinates
        public List<Moveset> listAllMoves(Team t)
        {
            List<Moveset> TeamMoveset = new List<Moveset>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (getAt(i, j) != null && getAt(i, j).getTeam() == t)
                    {
                        Moveset ms = new Moveset();
                        ms.piece = getAt(i, j);
                        ms.start = new Tuple<int, int>(i, j);
                        ms.end = new List<Tuple<int, int>>();
                        for (int x = 0; x < 8; x++)
                        {
                            for (int y = 0; y < 8; y++)
                            {
                                if (validNoMove(i, j, x, y))
                                {
                                    Tuple<int, int> p = new Tuple<int, int>(x, y);
                                    ms.end.Add(p);
                                    //Console.WriteLine("{0}: {1},{2} -> {3},{4}", getAt(i, j).getNameString(), i, j, x, y);
                                }
                            }
                        }
                        TeamMoveset.Add(ms);
                    }
                }

            }

            return TeamMoveset;
        
  public Piece GetPiece(int x, int y)
        {
            Piece p;
            p = board[x, y];

            // no piece there? return null
            if (p == null)
                return null;
            return p;
        }

        public void SetPiece(int x, int y, Team team, PieceType type)
        {
            board[x, y] = new Piece(team, type);
        }
    }
}