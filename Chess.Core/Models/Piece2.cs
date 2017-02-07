using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Core.Models
{
    class Piece2
    {
        private string type { get; set; }
        private bool color { get; set; }
        private bool inPlay { get; set; } = true;
        //team color is true for white, false for black
        
        public Piece2(string name, bool team) {
            type = name;
            color = team;
        }
        
        //TODO readd methods for valid moves

        
    }
}
