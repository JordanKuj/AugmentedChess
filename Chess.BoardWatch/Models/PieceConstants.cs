using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BoardWatch.Models
{
    public enum PieceType
    {
        Pawn = 1, knight = 2, rook = 3, bishop = 4, queen = 5, king = 6, none = 0
    }
    public enum Team
    {
        black, white
    }
    public static class PieceConstants
    {
        public static int[,] pwn = new int[5, 5] { { 1, 1, 1, 1, 1},
                                                   { 1, 0, 1, 0, 1},
                                                   { 1, 0, 0, 0, 1},
                                                   { 1, 1, 0, 1, 1},
                                                   { 1, 1, 1, 1, 1} };  //pawn

        public static int[,] kni = new int[5, 5] { { 1, 1, 1, 1, 1},
                                                   { 1, 0, 1, 0, 1},
                                                   { 1, 1, 0, 1, 1},
                                                   { 1, 1, 1, 0, 1},
                                                   { 1, 1, 1, 1, 1} };  //knight

        public static int[,] rok = new int[5, 5] { { 1, 1, 1, 1, 1},
                                                   { 1, 0, 0, 1, 1},
                                                   { 1, 1, 1, 0, 1},
                                                   { 1, 1, 0, 1, 1},
                                                   { 1, 1, 1, 1, 1} };  //rook

        public static int[,] bsh = new int[5, 5] { { 1, 1, 1, 1, 1},
                                                   { 1, 1, 0, 1, 1},
                                                   { 1, 1, 1, 1, 1},
                                                   { 1, 0, 1, 0, 1},
                                                   { 1, 1, 1, 1, 1} };  //bishop

        public static int[,] qen = new int[5, 5] { { 1, 1, 1, 1, 1},
                                                   { 1, 0, 0, 0, 1},
                                                   { 1, 0, 0, 0, 1},
                                                   { 1, 0, 0, 0, 1},
                                                   { 1, 1, 1, 1, 1} };  //queen

        public static int[,] kng = new int[5, 5] { { 1, 1, 1, 1, 1},
                                                   { 1, 0, 0, 0, 1},
                                                   { 1, 0, 0, 0, 1},
                                                   { 1, 0, 0, 0, 1},
                                                   { 1, 1, 1, 1, 1} };  //king
        //public static int[,] pwn = new int[3, 3] { { 0, 1, 0 },
        //                                           { 0, 0, 0 },
        //                                           { 1, 0, 1 } };  //pawn

        //public static int[,] kni = new int[3, 3] { { 0, 1, 0 },
        //                                           { 1, 0, 1 },
        //                                           { 1, 1, 0 } };  //knight

        //public static int[,] rok = new int[3, 3] { { 0, 0, 1 },
        //                                           { 1, 1, 0 },
        //                                           { 1, 0, 1 } };  //rook

        //public static int[,] bsh = new int[3, 3] { { 1, 0, 1 },
        //                                           { 1, 1, 1 },
        //                                           { 0, 1, 0 } };  //bishop

        //public static int[,] qen = new int[3, 3] { { 0, 0, 0 },
        //                                           { 0, 0, 0 },
        //                                           { 0, 0, 0 } };  //queen

        //public static int[,] kng = new int[3, 3] { { 0, 0, 0 },
        //                                           { 0, 0, 0 },
        //                                           { 0, 0, 0 } };  //king

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
            //if (a[1, 1] != b[1, 1])
            //    return false;

            var tmpa = new List<int>();
            var tmpb = new List<int>();
            for (var y = 0; y < 5; y++)
            {
                for (var x = 0; x < 5; x++)
                {
                    tmpa.Add(a[x, y]);
                    tmpb.Add(b[x, y]);
                }
            }

            //var tmpa = new List<int>
            //{
            //    a[0, 0],
            //    a[1, 0],
            //    a[2, 0],
            //    a[3, 0],
            //    a[4, 0],
            //    a[0, 1],
            //    a[1, 1],
            //    a[2, 1],
            //    a[3, 1],
            //    a[4, 1],
            //    a[0, 2],
            //    a[1, 2],
            //    a[2, 2],
            //    a[3, 2],
            //    a[4, 2],
            //    a[0, 3],
            //    a[1, 3],
            //    a[2, 3],
            //    a[3, 3],
            //    a[4, 3],
            //    a[0, 4],
            //    a[1, 4],
            //    a[2, 4],
            //    a[3, 4],
            //    a[4, 4]
            //};
            //var tmpb = new List<int>
            //{
            //    b[0, 0],
            //    b[1, 0],
            //    b[2, 0],
            //    b[3, 0],
            //    b[4, 0],
            //    b[0, 1],
            //    b[1, 1],
            //    b[2, 1],
            //    b[3, 1],
            //    b[4, 1],
            //    b[0, 2],
            //    b[1, 2],
            //    b[2, 2],
            //    b[3, 2],
            //    b[4, 2],
            //    b[0, 3],
            //    b[1, 3],
            //    b[2, 3],
            //    b[3, 3],
            //    b[4, 3],
            //    b[0, 4],
            //    b[1, 4],
            //    b[2, 4],
            //    b[3, 4],
            //    b[4, 4]
            //};
            Debug.Print("");
            Debug.Print("");
            Debug.Print("");
            Debug.Print("tmpa");
            PrintArray(tmpa);
            Debug.Print("-------");
            Debug.Print("tmpblob");
            PrintArray(tmpb);
            //var tmpb = new List<int> { b[0, 0], b[1, 0], b[2, 0], b[2, 1], b[2, 2], b[1, 2], b[0, 2], b[0, 1] };

            var asum = tmpa.Sum();
            var bsum = tmpb.Sum();

            if (tmpa.Sum() != tmpb.Sum())
                return false;

            if (CheckGlyps(a, b, 0))
                return true;
            if (CheckGlyps(a, b, 1))
                return true;
            if (CheckGlyps(a, b, 2))
                return true;
            if (CheckGlyps(a, b, 3))
                return true;
            //for (var c = 0; c < 8; c++)
            //{
            //    var passed = true;
            //    for (var r = 0; r < 8; r++)
            //    {
            //        passed &= tmpa[r] == tmpb[(c + r) % 8];
            //        if (!passed)
            //            break;
            //    }
            //    if (passed)
            //        return true;
            //}
            return false;
        }

        private static bool CheckGlyps(int[,] a, int[,] b, int flipmode)
        {
            var passed = true;
            for (var x = 0; x < 5; x++)
            {
                for (var y = 0; y < 5; y++)
                {
                    switch (flipmode)
                    {
                        case 0:
                            passed = a[x, y] == b[x, y];
                            break;
                        case 1:
                            passed = a[x, y] == b[Flip(x), y];
                            break;
                        case 2:
                            passed = a[x, y] == b[x, Flip(y)];
                            break;
                        case 3:
                            passed = a[x, y] == b[Flip(x), Flip(y)];
                            break;
                    }
                    if (!passed)
                        return false;
                }
            }
            return true;
        }

        //private static int RotateCw(int x, int y, int times)
        //{
        //     if
        //}
        private static int Flip(int val)
        {
            switch (val)
            {
                case 0:
                    return 4;
                case 1:
                    return 3;
                case 2:
                    return 2;
                case 3:
                    return 1;
                case 4:
                    return 0;
            }
            throw new ArgumentOutOfRangeException();
        }

        private static void PrintArray(List<int> vals, int colcount = 5)
        {
            var count = 1;
            foreach (var val in vals)
            {
                var endchar = count % colcount == 0 ? "\n" : ",";
                Debug.Write($"{val}{endchar}");
                count++;
            }
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
