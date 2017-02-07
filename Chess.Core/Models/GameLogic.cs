using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Core.Models
{
    class GameLogic
    {
        public Board StartState;
        public Board EndState;
        

        public GameLogic(Board  State1, Board State2) {
            StartState = State1;
            EndState = State2;
        }

        //compare starting board state to ending board state and determine if a valid move was made
        public bool isValid() {
            
        }

        //step through piece movement and check if it passes pieces when it shouldn't
        public bool step() {

        }

        //determines what type of piece has moved
        public BasePiece findPiece() {
            
        }

    }
}
