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

        // might not need
        //public async Task RunAsync()
        //{
        //    client.BaseAddress = new Uri("http://localhost:50426/");
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //    // Console.ReadLine();
        //}

        public async Task<GamesDTO> GetCurrentGame()
        {
            string path;
            GamesDTO g = null;
            var client = GetNewClient();
            //g = await GetMostRecentGame();

            path = "api/Games";  // fix this?
            //path = "ap/Games/{id}";  ??
            HttpResponseMessage resp = await client.GetAsync(path);
            if (resp.IsSuccessStatusCode)
                g = await resp.Content.ReadAsAsync<GamesDTO>();

            return g;
        }

        public async Task<Uri> CreateGame(GamesDTO g)
        {
            var client = GetNewClient();

            HttpResponseMessage resp = await client.PostAsJsonAsync("api/Games", g);
            resp.EnsureSuccessStatusCode();
            return resp.Headers.Location;
        }

        public async Task<GamesDTO> EndGame(GamesDTO g)
        {
            HttpResponseMessage resp = await GetNewClient().PutAsJsonAsync($"api/Games/{g.GameId}", g);
            resp.EnsureSuccessStatusCode();

            g = await resp.Content.ReadAsAsync<GamesDTO>();
            return g;
        }

        public async Task<BoardstatesDTO> GetCurrentGameState(int sId)
        {
            string path;
            BoardstatesDTO bs = null;
            var client = GetNewClient();

            //bs = await GetMostRecentState();

            path = "api/Games/{" + sId + "}";
            HttpResponseMessage resp = await client.GetAsync(path);
            if (resp.IsSuccessStatusCode)
                bs = await resp.Content.ReadAsAsync<BoardstatesDTO>();

            return bs;
        }

        public async Task<Uri> CreateBoardstate(BoardstatesDTO bs)
        {
            var client = GetNewClient();

            HttpResponseMessage resp = await client.PostAsJsonAsync("api/Boardstates", bs);
            resp.EnsureSuccessStatusCode();
            return resp.Headers.Location;
        }
    }
}
