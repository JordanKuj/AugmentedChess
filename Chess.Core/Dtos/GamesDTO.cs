using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Core.Dtos
{
    public class GamesDTO
    {
        public GamesDTO()
        {
            States = new List<BoardstateDTO>();
        }

        public int GameId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public List<BoardstateDTO> States { get; set; }
    }
}
