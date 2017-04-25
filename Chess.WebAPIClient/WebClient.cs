using Chess.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

// at solution explorer right-click, go to properties to run two projects at once

namespace Chess.WebAPIClient
{
    public class WebClient
    {
        //HttpClient client = new HttpClient();

        private HttpClient GetNewClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:50426/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        private static string PathBuilder(params string[] args)
        {
            return string.Join("/", args);
        }

        // might not need
        //public async Task RunAsync()
        //{
        //    client.BaseAddress = new Uri("http://localhost:50426/");
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //    // Console.ReadLine();
        //}

        const string API = "api";
        const string games = "Games";
        const string boardstates = "Boardstates";


        public GamesDTO GetCurrentGame()
        {
            var client = GetNewClient();
            //path = "ap/Games/{id}";  ??
            HttpResponseMessage resp = client.GetAsync(PathBuilder(games)).Result;
            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadAsAsync<GamesDTO>().Result;
            return null;
        }

        public Uri CreateGame(GamesDTO g)
        {
            var client = GetNewClient();

            HttpResponseMessage resp = client.PostAsJsonAsync(PathBuilder(games), g).Result;
            resp.EnsureSuccessStatusCode();
            return resp.Headers.Location;
        }

        public GamesDTO EndGame(GamesDTO g)
        {
            var client = GetNewClient();

            HttpResponseMessage resp = client.PutAsJsonAsync(PathBuilder(games, g.GameId.ToString()), g).Result;
            resp.EnsureSuccessStatusCode();

            g = resp.Content.ReadAsAsync<GamesDTO>().Result;
            return g;
        }

        public bool SubmitGameState(BoardstateDTO bs)
        {
            var client = GetNewClient();
            HttpResponseMessage resp = client.PostAsJsonAsync(PathBuilder(boardstates), bs).Result;
            return resp.IsSuccessStatusCode;
        }

        //public async Task<BoardstateDTO> GetCurrentGameState()
        //{
        //    var client = GetNewClient();
        //    HttpResponseMessage resp = await client.GetAsync(PathBuilder(boardstates));
        //    if (resp.IsSuccessStatusCode)
        //        return await resp.Content.ReadAsAsync<BoardstateDTO>();
        //    return null;
        //}

        //public async Task<Uri> CreateBoardstate(BoardstateDTO bs)
        //{
        //    var client = GetNewClient();
        //    HttpResponseMessage resp = await client.PutAsJsonAsync(PathBuilder(boardstates), bs);
        //    resp.EnsureSuccessStatusCode();
        //    return resp.Headers.Location;
        //}
    }
}
