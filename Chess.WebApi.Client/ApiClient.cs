using Newtonsoft.Json;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Chess.WebApi.Client
{
    public class ApiClient
    {



        public ApiClient() { }

        private string BaseAddress => "http://localhost:50426/api/";
        private const string BoardState = "Boardstates";



        private async Task<string> GetRequest(string path)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(BaseAddress + path);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }


        public async Task<ICollection<GamesDTO>> GetGame()
        {

            var result = await GetRequest(BoardState);
            var games = JsonConvert.DeserializeObject<ICollection<GamesDTO>>(result);
            return games;
        }

        public async Task<GamesDTO> GetGame(int id)
        {
            var result = await GetRequest(BoardState + "/" + id.ToString());
            var games = JsonConvert.DeserializeObject<GamesDTO>(result);
            return games;
        }

        public async Task<BoardstatesDTO> PostGame(BoardstatesDTO state)
        {
            using (HttpClient client = new HttpClient())
            {
                var stateData = JsonConvert.SerializeObject(state);
                var content = new StringContent(stateData, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(BaseAddress + BoardState, content);
                response.EnsureSuccessStatusCode();
                var respString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BoardstatesDTO>(respString);
            }
        }



        public class GamesDTO
        {
            public int GameId { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
        }

        public class BoardstatesDTO
        {
            public int StateId { get; set; }
            public DateTime Timestamp { get; set; }
            public Array[,] State { get; set; }
            public int GameId { get; set; }
        }
    }
}
