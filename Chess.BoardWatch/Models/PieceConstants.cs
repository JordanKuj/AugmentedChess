using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ChessTest;

namespace Chess.BoardWatch.Models
{
    //public enum PieceType
    //{
    //    Pawn = 1, knight = 2, rook = 3, bishop = 4, queen = 5, king = 6, Debug = 7, none = 0
    //}
    //public enum Team
    //{
    //    black, white
    //}
    public enum RotateType { cw, ccw }

    public static class PieceConstants
    {


        public static int[,] dbg = new int[5, 5] { { 1, 1, 1, 1, 1},
                                                   { 1, 0, 1, 0, 1},
                                                   { 1, 0, 0, 0, 1},
                                                   { 1, 1, 0, 1, 1},
                                                   { 1, 1, 1, 1, 1} };  //debug

        public static int[,] pwn = new int[5, 5] { { 1, 1, 1, 1, 1},
                                                   { 1, 0, 0, 0, 1},
                                                   { 1, 0, 1, 0, 1},
                                                   { 1, 1, 1, 1, 1},
                                                   { 1, 1, 1, 1, 1} };  //pawn

        public static int[,] kni = new int[5, 5] { { 1, 1, 1, 1, 1},
                                                   { 1, 0, 0, 1, 1},
                                                   { 1, 0, 1, 1, 1},
                                                   { 1, 0, 0, 0, 1},
                                                   { 1, 1, 1, 1, 1} };  //knight

        public static int[,] rok = new int[5, 5] { { 1, 1, 1, 1, 1},
                                                   { 1, 0, 1, 0, 1},
                                                   { 1, 1, 0, 1, 1},
                                                   { 1, 0, 1, 0, 1},
                                                   { 1, 1, 1, 1, 1} };  //rook

        public static int[,] bsh = new int[5, 5] { { 1, 1, 1, 1, 1},
                                                   { 1, 0, 1, 0, 1},
                                                   { 1, 1, 1, 1, 1},
                                                   { 1, 0, 1, 0, 1},
                                                   { 1, 1, 1, 1, 1} };  //bishop

        public static int[,] qen = new int[5, 5] { { 1, 1, 1, 1, 1},
                                                   { 1, 1, 1, 1, 1},
                                                   { 1, 0, 1, 0, 1},
                                                   { 1, 1, 1, 1, 1},
                                                   { 1, 1, 1, 1, 1} };  //queen

        public static int[,] kng = new int[5, 5] { { 1, 1, 1, 1, 1},
                                                   { 1, 0, 1, 0, 1},
                                                   { 1, 0, 0, 1, 1},
                                                   { 1, 0, 1, 0, 1},
                                                   { 1, 1, 1, 1, 1} };  //king

        public static Dictionary<PieceType, int[,]> PieceLookup = new Dictionary<PieceType, int[,]> {
            { PieceType.pawn, pwn },
            { PieceType.knight, kni },
            { PieceType.rook, rok },
            { PieceType.bishop, bsh },
            { PieceType.queen, qen },
            { PieceType.king, kng },
            { PieceType.Debug, dbg }
        };

        public static PieceType FindPieceType(int[,] blobout)
        {
            foreach (var t in PieceLookup)
                if (Compare(t.Value, blobout))
                    return t.Key;
            return PieceType.error;
        }


        public static int[,] Rotate(int[,] tmpboard, RotateType type)
        {

            var newboard = new int[5, 5] { { 1, 1, 1, 1, 1},
                                           { 1, 0, 0, 0, 1},
                                           { 1, 0, 0, 0, 1},
                                           { 1, 0, 0, 0, 1},
                                           { 1, 1, 1, 1, 1} };
            //initializing the outside border so then only the inside 3x3 needs to rotate

            int newx = 1;
            int newy = 1;
            for (int x = 1; x <= 3; x++)
            {
                newx = 1;
                for (int y = 3; y >= 1; y--)
                {
                    if (type == RotateType.cw)
                        newboard[newy, newx] = tmpboard[y, x];
                    else
                        newboard[newx, newy] = tmpboard[x, y];
                    newx += 1;
                }
                newy += 1;
            }
            return newboard;
        }
        private static bool Compare(int[,] a, int[,] b)
        {
            //if (a[1, 1] != b[1, 1])
            //    return false;
            var asum = 0;
            var bsum = 0;
            for (var y = 0; y < 5; y++)
                for (var x = 0; x < 5; x++)
                {
                    asum += (a[x, y]);
                    bsum += (b[x, y]);
                }

            if (asum != bsum)
                return false;

            if (CheckGlyps(a, b))
                return true;
            b = Rotate(b, RotateType.cw);
            if (CheckGlyps(a, b))
                return true;
            b = Rotate(b, RotateType.cw);
            if (CheckGlyps(a, b))
                return true;
            b = Rotate(b, RotateType.cw);
            if (CheckGlyps(a, b))
                return true;
            return false;
        }

        private static bool CheckGlyps(int[,] a, int[,] b)
        {
            var passed = true;
            for (var x = 1; x < 5; x++)
                for (var y = 1; y < 5; y++)
                {
                    passed = a[x, y] == b[x, y];
                    if (!passed)
                        return false;
                }
            return true;
        }
    }

}
