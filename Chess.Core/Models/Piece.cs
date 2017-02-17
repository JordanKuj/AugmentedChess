using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Core.Models
{
    class Piece
    {
        public string Name;
        public bool Color;
        public bool InPlay;
        //team color is true for white, false for black

        public Piece(string pieceName, bool team) {
            Name = pieceName;
            Color = team;
            InPlay = true;
        }

        public string getName() {
            return Name;
        }

        public void setName(string x) {
            Name = x;
        }
        public bool getColor() {
            return Color;
        }
        public void setColor(bool x)
        {
            Color = x;
        }
        public bool getInPlay() {
            return InPlay;
        }
        public void setInPlay(bool x)
        {
            InPlay = x;
        }
    }
}
