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

        public async Task<IEnumerable<GamesDTO>> GetGame()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(BaseAddress + BoardState);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var games = JsonConvert.DeserializeObject<IEnumerable<GamesDTO>>(result);
            return games;
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
