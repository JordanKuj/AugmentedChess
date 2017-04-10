using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.WebAPI;
using ChessTest;  // TODO delete
using static Chess.WebAPI.Tools.MovePrediction;  // TODO delete
using static Chess.WebAPI.Tools.BoardConversion;
using static ChessTest.Board;  // TODO delete

namespace Chess.WebAPIClient
{
    class Program
    {
        static void Main(string[] args)
        {

            var x = new Application();
            Console.WriteLine("Running...");
            //Task.WaitAll(x.Run());  // An unhandled exception of type 'System.AggregateException' occurred in mscorlib.dll
            Console.WriteLine("press any key to continue");
            Console.ReadKey();

            ChessTest.Board b = new ChessTest.Board();
            List<Moveset> moves = predictAll(Team.white);
            String s = MakeString(b);
            Console.WriteLine(s);

            ChessTest.Board testB = MakeBoard(s);
            Console.WriteLine("----------------------");
            testB.printBoard();
            Console.WriteLine("----------------------");

            ChessTest.Board testA = MakeBoard("b00");
            testA.printBoard();
            //testB.SetPiece(5,5, Team.white, PieceType.pawn);
            //testB.printBoard();
            // Console.WriteLine(testB.printBoard());
            // Console.WriteLine(moves);
            // moves.
            // Vector v = new Vector();
            Console.ReadKey();

        }





    }

    public class Application
    {

        public async Task Run()
        {
            var client = new WebClient();

            var game = new GamesDTO();

            game.StartTime = DateTime.Now;

            await client.CreateGame(game);


            var g2 = await client.GetCurrentGame();

            Console.WriteLine(g2.StartTime);
        }



    }

}
