using ChessTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chess.Core.Dtos;

namespace Chess.Core.Tools
{
    public class BoardConversion
    {
        /*********************
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

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var p = b.GetPiece(j, i);
                    // Console.WriteLine("j: " + j.ToString() + ", i: " + i.ToString());  // TODO

                    // if there's no piece there
                    if (p != null)
                    {
                        PieceType name = p.getName();
                        Team team = p.getTeam();
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
            }
            return s;
        }

        public static ChessTest.Board MakeBoard(string str)
        {
            ChessTest.Board b = new ChessTest.Board();
            char temp = 'x';
            int x = 0, y = 0;

            for (int i = 0; i < str.Length; i += 3)
            {
                temp = str[i];  // piece

                x = int.Parse(str[i + 1].ToString());// (int)char.GetNumericValue(str[i + 1]);
                y = int.Parse(str[i + 2].ToString());
                switch (temp)
                {
                    case 'a':
                        // x, y must be in here, otherwise out of bounds error
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
                    default:
                        // do nothing
                        break;
                }
            }
            return b;
        }


        public static ChessTest.Board ToBoard(Dtos.BoardstateDTO bs)
        {
            var res = MakeBoard(bs.State);
            res.turn = bs.Turn;

            return res;
        }

        public static Dtos.BoardstateDTO ToBoard(ChessTest.Board bs)
        {
            var res = new BoardstateDTO();
            res.Turn = bs.turn;
            res.State = MakeString(bs);
            return res;
        }
    }
}