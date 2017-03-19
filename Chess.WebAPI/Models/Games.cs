using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Chess.WebAPI.Models
{
    public class Games
    {
        // repository pattern
        // business/entity models
        [Key]
        public int GameId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public virtual ICollection<Boardstates> States { get; set; }

        // todo see below for bs but w/games
    }

    public class Boardstates
    {
        [Key]
        public int StateId { get; set; }
        [Timestamp]
        public DateTime Timestamp { get; set; }
        [Required]
        public string State { get; set; }

        // foreign key
        public int GameId { get; set; }

        [ForeignKey("GameId")]
        public virtual Games Game { get; set; }

        public Boardstates() { }
        public Boardstates(BoardstatesDTO bs)
        {
            this.StateId = bs.StateId;
            // todo the others
        }
    }

    // data transfer objects, to be used in sprint 2
    public class GamesDTO
    {
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
            // todo the others
        }

        public int StateId { get; set; }
        public DateTime Timestamp { get; set; }
        public Array[,] State { get; set; }
        public int GameId { get; set; }
    }
}