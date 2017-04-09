using Chess.WebAPI.Controllers;
using ChessTest;
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
        public static string MakeString(ChessTest.Board b)
        {
            string s = string.Empty;
            ChessTest.Piece p;
            PieceType name;
            Team team;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    //p = b.GetPiece(i,j);
                    p = b.GetPiece(j,i);
                    Console.WriteLine("j: " + j.ToString() + ", i: " + i.ToString());

                    // if there's no piece there
                    if (p == null)
                    {
                        break;
                    }
                    Console.WriteLine(p.getName());
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
                            s += j;  // x
                            s += i;  // y
                            break;
                        case PieceType.rook:
                            if (team == Team.white)
                                s += "b";
                            else
                                s += "h";
                            //.WriteLine(i); // TODO
                            //Console.WriteLine(j);  // TODO
                            s += j;  // x
                            s += i;  // y
                            break;
                        case PieceType.knight:
                            if (team == Team.white)
                                s += "c";
                            else
                                s += "i";
                            s += j;  // x
                            s += i;  // y
                            break;
                        case PieceType.bishop:
                            if (team == Team.white)
                                s += "d";
                            else
                                s += "j";
                            s += j;  // x
                            s += i;  // y
                            break;
                        case PieceType.king:
                            if (team == Team.white)
                                s += "e";
                            else
                                s += "k";
                            s += j;  // x
                            s += i;  // y
                            break;
                        case PieceType.queen:
                            if (team == Team.white)
                                s += "f";
                            else
                                s += "l";
                            s += j;  // x
                            s += i;  // y
                            break;

                        default:  // shouldn't ever reach here, but just in case
                            break;
                    }
                }
            }
            return s;
        }

        public static ChessTest.Board MakeBoard(string str)
        {
            ChessTest.Board b = new ChessTest.Board();
            char temp = 'x';
            int x = 0, y = 0;

            //Console.WriteLine(str[0]);  // TODO
            //Console.WriteLine(str[1]);  // TODO
            //Console.WriteLine(str[2]);  // TODO

            for (int i = 0; i < str.Length; i+=2)
            {
                temp = str[i];  // piece
                Console.WriteLine(temp);  // TODO
                //x = str[i+1];  // x coord.
                //x = str.Substring(i+1,1);

                //y = str[i+2];  // y coord.
                //x = str[1];
                //y = str[2];
                //Console.WriteLine(str[i+1]);  // TODO
                //Console.WriteLine(str[i+2]);  // TODO
                //Console.WriteLine(x);  // TODO
                //Console.WriteLine(y);  // TODO

                switch (temp)
                {
                    case 'a':
                        b.SetPiece(x, y, Team.white, PieceType.pawn);
                        break;
                    case 'b':
                        Console.WriteLine(str[i + 1]);  // TODO
                        Console.WriteLine(str[i + 2]);  // TODO
                        b.SetPiece(str[i + 1], str[i + 2], Team.white, PieceType.rook);
                        break;
                    case 'c':
                        b.SetPiece(str[i + 1], str[i + 2], Team.white, PieceType.knight);
                        break;
                    case 'd':
                        b.SetPiece(str[i + 1], str[i + 2], Team.white, PieceType.bishop);
                        break;
                    case 'e':
                        b.SetPiece(str[i + 1], str[i + 2], Team.white, PieceType.king);
                        break;
                    case 'f':
                        b.SetPiece(str[i + 1], str[i + 2], Team.white, PieceType.queen);
                        break;
                    case 'g':
                        b.SetPiece(str[i + 1], str[i + 2], Team.black, PieceType.pawn);
                        break;
                    case 'h':
                        b.SetPiece(str[i + 1], str[i + 2], Team.black, PieceType.rook);
                        break;
                    case 'i':
                        b.SetPiece(str[i + 1], str[i + 2], Team.black, PieceType.knight);
                        break;
                    case 'j':
                        b.SetPiece(str[i + 1], str[i + 2], Team.black, PieceType.bishop);
                        break;
                    case 'k':
                        b.SetPiece(str[i + 1], str[i + 2], Team.black, PieceType.king);
                        break;
                    case 'l':
                        b.SetPiece(str[i + 1], str[i + 2], Team.black, PieceType.queen);
                        break;
                    case 'x':
                        // do nothing
                        break;

                    default:
                        // do nothing
                        break;
                }
            }
            return b;
        }
    }
}