using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BoardWatch.Models
{
    public enum PieceType
    {
        Pawn =1, knight=2, rook=3, bishop=4, queen=5, king=6, none=0
    }
    public enum Team
    {
        black, white
    }
    public static class PieceConstants
    {

        public static int[,] pwn = new int[3, 3] { { 0, 1, 0 },
                                                   { 0, 0, 0 },
                                                   { 1, 0, 1 } };  //pawn

        public static int[,] kni = new int[3, 3] { { 0, 1, 0 },
                                                   { 1, 0, 1 },
                                                   { 1, 1, 0 } };  //knight

        public static int[,] rok = new int[3, 3] { { 0, 0, 1 },
                                                   { 1, 1, 0 },
                                                   { 1, 0, 1 } };  //rook

        public static int[,] bsh = new int[3, 3] { { 0, 0, 0 },
                                                   { 0, 0, 0 },
                                                   { 0, 0, 0 } };  //bishop

        public static int[,] qen = new int[3, 3] { { 0, 0, 0 },
                                                   { 0, 0, 0 },
                                                   { 0, 0, 0 } };  //queen

        public static int[,] kng = new int[3, 3] { { 0, 0, 0 },
                                                   { 0, 0, 0 },
                                                   { 0, 0, 0 } };  //king

        public static Dictionary<PieceType, int[,]> PieceLookup = new Dictionary<PieceType, int[,]> {
            { PieceType.Pawn, pwn },
            { PieceType.knight, kni },
            { PieceType.rook, rok },
            { PieceType.bishop, bsh },
            { PieceType.queen, qen },
            { PieceType.king, kng },
        };

        public static PieceType FindPieceType(int[,] blobout)
        {
            foreach (var t in PieceLookup)
                if (Compare(t.Value, blobout))
                    return t.Key;
            return PieceType.none;
        }
        private static bool Compare(int[,] a, int[,] b)
        {
            if (a[1, 1] != b[1, 1])
                return false;

            var tmpa = new List<int> { a[0, 0], a[1, 0], a[2, 0], a[2, 1], a[2, 2], a[1, 2], a[0, 2], a[0, 1] };
            var tmpb = new List<int> { b[0, 0], b[1, 0], b[2, 0], b[2, 1], b[2, 2], b[1, 2], b[0, 2], b[0, 1] };

            if (tmpa.Sum() != tmpb.Sum())
                return false;

            for (var c = 0; c < 8; c++)
            {
                var passed = true;
                for (var r = 0; r < 8; r++)
                {
                    passed &= tmpa[r] == tmpb[(c + r) % 8];
                    if (!passed)
                        break;
                }
                if (passed)
                    return true;
            }
            return false;
        }
        //private static void Rotate(ref int x, ref int y)
        //{
        //    if (x == 0 && y == 0)
        //        x = 2;
        //    else if (x == 2 && y == 0)
        //        y = 2;
        //    else if (x == 2 && y == 2)
        //        x = 0;
        //    else if (x == 0 && y == 2)
        //        y = 0;
        //}
    }

}
