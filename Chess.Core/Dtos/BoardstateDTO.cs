using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessTest;

namespace Chess.Core.Dtos
{
    public class BoardstateDTO
    {
        public BoardstateDTO() { }

        public Team Turn { get; set; }
        public int StateId { get; set; }
        public DateTime Timestamp { get; set; }
        public string State { get; set; }
        public int GameId { get; set; }
    }
}
