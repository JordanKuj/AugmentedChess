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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int GameId { get; set; }

        //[Column(TypeName = "datetime2")]
        public DateTime StartTime { get; set; }

        //[Column(TypeName = "datetime2")]
        public DateTime EndTime { get; set; }

        public virtual ICollection<Boardstates> States { get; set; }

        public Games() { }
        public Games(GamesDTO g)
        {
            this.GameId = g.GameId;
            this.StartTime = g.StartTime;
            this.EndTime = g.EndTime;
        }
    }

    public class Boardstates
    {
        [Key]
        public int StateId { get; set; }
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
            this.Timestamp = bs.Timestamp;
            this.State = bs.State;
            this.GameId = bs.GameId;
        }
    }

    // data transfer objects
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