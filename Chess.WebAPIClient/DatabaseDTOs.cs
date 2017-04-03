using Chess.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.WebAPIClient
{
    public class DatabaseDTOs
    {
        public class GamesDTO
        {
            public GamesDTO() { }
            public GamesDTO(Games g)
            {
                this.GameId = g.GameId;
                this.StartTime = g.StartTime;
                this.EndTime = g.EndTime;
            }

            public int GameId { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
        }

        public class BoardstatesDTO
        {
            public BoardstatesDTO() { }
            public BoardstatesDTO(Boardstates bs)
            {
                this.StateId = bs.StateId;
                this.Timestamp = bs.Timestamp;
                this.State = bs.State;
                this.GameId = bs.GameId;
            }

            public int StateId { get; set; }
            public DateTime Timestamp { get; set; }
            public string State { get; set; }
            public int GameId { get; set; }
        }
    }
}
