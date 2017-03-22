using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Core.Models
{
    class Piece
    {
        bool Team;
        string Name;
        bool HasMoved;

        public Piece(bool t, string n)
        {
            Team = t;
            Name = n;
            HasMoved = false;
        }
        
        //getters for variables
        public bool getTeam()
        {
            return Team;
        }

        public string getName()
        {
            return Name;
        }

        public bool getHasMoved()
        {
            return HasMoved;
        }

        //when piece has moved set HasMoved to true
        public void setHasMoved()
        {
            HasMoved = true;
        }
        
        //make a copy of a piece
        public Piece copy()
        {
            return new Piece(Team, Name);
        }
    }
}
