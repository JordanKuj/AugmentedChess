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
         * l = queen black
         * *******************/
        public static string MakeString(Board b)
        {
            string s = string.Empty;
            Piece p;
            PieceType name;
            Team team;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    p = b.GetPiece(i,j);

                    // if there's no piece there
                    if (p == null)
                    {
                        s += "x";
                        break;
                    }
                    name = p.getName();
                    team = p.getTeam();

                    switch (name)
                    {
                        case PieceType.pawn:
                            // add piece
                            if (team == Team.white)
                                s += "a";
                            else // black
                                s += "g";
                            // where is the piece?
                            s += i;  // x
                            s += j;  // y
                            break;
                        case PieceType.rook:
                            if (team == Team.white)
                                s += "b";
                            else
                                s += "h";
                            s += i;
                            s += j;
                            break;
                        case PieceType.knight:
                            if (team == Team.white)
                                s += "c";
                            else
                                s += "i";
                            s += i;
                            s += j;
                            break;
                        case PieceType.bishop:
                            if (team == Team.white)
                                s += "d";
                            else
                                s += "j";
                            s += i;
                            s += j;
                            break;
                        case PieceType.king:
                            if (team == Team.white)
                                s += "e";
                            else
                                s += "k";
                            s += i;
                            s += j;
                            break;
                        case PieceType.queen:
                            if (team == Team.white)
                                s += "f";
                            else
                                s += "l";
                            s += i;
                            s += j;
                            break;

                        default:  // shouldn't ever reach here, but just in case
                            s += "x";
                            break;
                    }
                }
            }
            return s;
        }

        public static Board MakeBoard(string str)
        {
            Board b = new Board();
            char temp = 'x';
            int x = 0, y = 0;

            for (int i = 0; i < str.Length; i++)
            {
                temp = str[i];  // piece
                x = str[i+1];  // x coord.
                y = str[i+2];  // y coord.

                switch (temp)
                {
                    case 'a':
                        b.SetPiece(x, y, Team.white, PieceType.pawn);
                        break;
                    case 'b':
                        b.SetPiece(x, y, Team.white, PieceType.rook);
                        break;
                    case 'c':
                        b.SetPiece(x, y, Team.white, PieceType.knight);
                        break;
                    case 'd':
                        b.SetPiece(x, y, Team.white, PieceType.bishop);
                        break;
                    case 'e':
                        b.SetPiece(x, y, Team.white, PieceType.king);
                        break;
                    case 'f':
                        b.SetPiece(x, y, Team.white, PieceType.queen);
                        break;
                    case 'g':
                        b.SetPiece(x, y, Team.black, PieceType.pawn);
                        break;
                    case 'h':
                        b.SetPiece(x, y, Team.black, PieceType.rook);
                        break;
                    case 'i':
                        b.SetPiece(x, y, Team.black, PieceType.knight);
                        break;
                    case 'j':
                        b.SetPiece(x, y, Team.black, PieceType.bishop);
                        break;
                    case 'k':
                        b.SetPiece(x, y, Team.black, PieceType.king);
                        break;
                    case 'l':
                        b.SetPiece(x, y, Team.black, PieceType.queen);
                        break;
                    case 'x':
                        // do nothing
                        break;

                    default:  // i = 0-8
                        // do nothing
                        break;
                }
            }
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