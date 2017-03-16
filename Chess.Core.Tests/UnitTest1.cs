using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess.BoardWatch.Models;
using System.Diagnostics;

namespace Chess.Core.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[,] pwn1 = new int[3, 3] { { 0, 1, 0 },
                                          { 0, 0, 0 },
                                          { 1, 0, 1 } };

            int[,] pwn2 = new int[3, 3] { { 1, 0, 0 },
                                          { 0, 0, 1 },
                                          { 1, 0, 0 } };

            int[,] pwn3 = new int[3, 3] { { 1, 0, 1 },
                                          { 0, 0, 0 },
                                          { 0, 1, 0 } };

            int[,] pwn4 = new int[3, 3] { { 0, 0, 1 },
                                          { 1, 0, 0 },
                                          { 0, 0, 1 } };

            int[,] kni = new int[3, 3] { { 0, 1, 0 },
                                         { 1, 0, 1 },
                                         { 1, 1, 0 } };

            int[,] rok = new int[3, 3] { { 0, 0, 1 },
                                         { 1, 1, 0 },
                                         { 1, 0, 1 } };

            Assert.AreEqual(PieceConstants.FindPieceType(pwn1), PieceType.Pawn);
            Assert.AreEqual(PieceConstants.FindPieceType(pwn2), PieceType.Pawn);
            Assert.AreEqual(PieceConstants.FindPieceType(pwn3), PieceType.Pawn);
            Assert.AreEqual(PieceConstants.FindPieceType(pwn4), PieceType.Pawn);

            EzTest(pwn1, PieceType.Pawn);
            EzTest(pwn2, PieceType.Pawn);
            EzTest(pwn3, PieceType.Pawn);
            EzTest(pwn4, PieceType.Pawn);

            EzTest(kni, PieceType.knight);
            EzTest(rok, PieceType.rook);



        }

        private static void EzTest(int[,] val, PieceType expected)
        {
            Assert.AreEqual(PieceConstants.FindPieceType(val), expected);
            foreach (PieceType p in Enum.GetValues(typeof(PieceType)))
                if (p != expected)
                    Assert.AreNotEqual(PieceConstants.FindPieceType(val), p);
        }



    }
}
