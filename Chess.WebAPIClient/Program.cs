using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.WebAPI;
using ChessTest;  // TODO delete
using static Chess.WebAPI.Tools.MovePrediction;  // TODO delete
using Chess.Core.Dtos;

namespace Chess.WebAPIClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new Application();
            Console.WriteLine("Running...");
            Task.WaitAll(x.Run());
            //Task.WaitAll(x.Run());  // An unhandled exception of type 'System.AggregateException' occurred in mscorlib.dll
            Console.WriteLine("press any key to continue");
            Console.ReadKey();

            //ChessTest.Board b = new ChessTest.Board();
            //b.fillNewBoard();
            //List<Moveset> moves = predictAll(Team.white);
            //List<Moveset> moves = b.listAllMoves(Team.white);
            //Console.WriteLine("Should be predicting now");
            //List<Move> pm = predict(b, Team.white);
            //printPredict(pm);
            //foreach (var m in moves)
            //Console.WriteLine(m.GetMovePiece());
            //printAllPredictions(moves);
            /*String s = MakeString(b);
            Console.WriteLine(s);

            ChessTest.Board testB = new ChessTest.Board();
            testB.printBoard(); 
            testB = MakeBoard(s);
            Console.WriteLine("--------------------------");
            testB.printBoard();
            //testB.SetPiece(5, 5, Team.white, PieceType.pawn);
            testB.move(6, 6, 6, 5);
            Console.WriteLine("--------------------------");
            testB.printBoard();
            Console.WriteLine("--------------------------");

            ChessTest.Board testA = MakeBoard("b00");
            Console.WriteLine("--------------------------");
            testA.printBoard();
            Console.WriteLine("--------------------------");*/
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


            var s1 = await client.CreateBoardstate(new BoardstateDTO() { State = "AAAAAAAAAAAA", Timestamp = DateTime.Now });

            Console.WriteLine(g2.StartTime);

            var state = await client.GetCurrentGameState();
            Console.WriteLine($"{state.GameId}:{state.StateId}:{state.Timestamp}");
        }
    }
}
