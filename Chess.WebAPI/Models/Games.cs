using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chess.WebAPI.Models
{
    public class Games
    {
        [Key]
        public int GameId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }

    public class Boardstates
    {
        [Key]
        public int StateId { get; set; }
        public DateTime Timestamp { get; set; }
        public Array[,] State { get; set; }

        // foreign key
        public int GameId { get; set; }
    }

    // data transfer objects, to be used in sprint 2
    /*public class GamesDTO
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
    }*/
}