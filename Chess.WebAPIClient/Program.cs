using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.WebAPIClient
{
    class Program
    {
        static void Main(string[] args)
        {

            var x = new Application();
            Task.WaitAll(x.Run());
            Console.WriteLine("press any key to continue");
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
