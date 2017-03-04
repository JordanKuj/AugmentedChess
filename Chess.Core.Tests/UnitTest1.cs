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

            Assert.AreEqual(PieceConstants.FindPieceType(pwn1), Piece.Pawn);
            Assert.AreEqual(PieceConstants.FindPieceType(pwn2), Piece.Pawn);
            Assert.AreEqual(PieceConstants.FindPieceType(pwn3), Piece.Pawn);
            Assert.AreEqual(PieceConstants.FindPieceType(pwn4), Piece.Pawn);

            EzTest(pwn1, Piece.Pawn);
            EzTest(pwn2, Piece.Pawn);
            EzTest(pwn3, Piece.Pawn);
            EzTest(pwn4, Piece.Pawn);

            EzTest(kni, Piece.knight);
            EzTest(rok, Piece.rook);



        }

        private static void EzTest(int[,] val, Piece expected)
        {
            Assert.AreEqual(PieceConstants.FindPieceType(val), expected);
            foreach (Piece p in Enum.GetValues(typeof(Piece)))
                if (p != expected)
                    Assert.AreNotEqual(PieceConstants.FindPieceType(val), p);
        }



    }
}
