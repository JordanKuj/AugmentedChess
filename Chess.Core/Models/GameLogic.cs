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
        /*
        //compare starting board state to ending board state and determine if a valid move was made
        public bool isValid() {
            
        }
        
        public void evaluate() {
            
        }

        public Piece getMoved() {
            foreach (Piece in StartState) {

            }
        }

        //returns an array of the max length a piece can move in a direction 
        //[upperleft, up, upperright, right, downright, down, downleft, left]
        //knight is excluded due to its L shaped moves
        public int[] moveset(Piece p)
        {
            int[] moves = new int[8];
            switch (p.GetName) {
                case "pawn":
                    moves = new int[] { 0, 1, 0, 0, 0, 0, 0, 0 };
                    return moves;
                case "rook":
                    moves = new int[] { 0, 7, 0, 7, 0, 7, 0, 7 };
                    return moves;
                case "bishop":
                    moves = new int[] { 7, 0, 7, 0, 7, 0, 7, 0 };
                    return moves;
                case "king":
                    moves = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 };
                    return moves;
                case "queen":
                    moves = new int[] { 7, 7, 7, 7, 7, 7, 7, 7 };
                    return moves;

                default:
                    return new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            }
        }
        */
    }
}