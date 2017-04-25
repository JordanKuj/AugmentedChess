using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Core.Dtos
{
    public class BoardstatesDTO
    {
        public BoardstatesDTO() { }
        public int StateId { get; set; }
        public DateTime Timestamp { get; set; }
        public string State { get; set; }
        public int GameId { get; set; }
    }
}
