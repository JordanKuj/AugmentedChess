using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Core.Models
{
    class Board2
    {
        public int a = 0, b = 1, c = 2, d = 3, e = 4, f = 5, g = 6, h = 7;
        // integers defined so that chess notation can be used for pieces
        public Piece2[,] board;

        public Board2() {
            board[0,a] = new Piece2("rook", true);
            board[0,a] = new Piece2("knight", true);
            board[0,a] = new Piece2("bishop", true);
            board[0,a] = new Piece2("king", true);
            board[0,a] = new Piece2("queen", true);
            board[0,a] = new Piece2("bishop", true);
            board[0,a] = new Piece2("knight", true);
            board[0,a] = new Piece2("rook", true);
            for (int i=a; i<h; i++) {
                board[1, i] = new Piece2("pawn", true);
            }
            board[7, h] = new Piece2("rook", false);
            board[7, h] = new Piece2("knight", false);
            board[7, h] = new Piece2("bishop", false);
            board[7, h] = new Piece2("king", false);
            board[7, h] = new Piece2("queen", false);
            board[7, h] = new Piece2("bishop", false);
            board[7, h] = new Piece2("knight", false);
            board[7, h] = new Piece2("rook", false);
            for (int i=a; i<h; i++)
            {
                board[6, i] = new Piece2("pawn", false);
            }

        }

        //Compare the current board state to the next to see if a move has been made
        public bool move(Board2 other) {
            if (this.board != other.board)
            {
                return true;
            }
            else return false;
        }

        //Check which spaces the move occupies and whether or not the piece can perform that move
        public bool validate(Board2 other) {
            if (move(other))
            {
                bool flag = false;
                for (int x = 0; x < 8; x++) {
                    for (int y = 0; y < 8; y++) {
                        if (this.board[x,y] != other.board[x,y]) {
                            if (!flag)
                            {
                                int[] pos1 = new int[] { x, y };
                                flag = true;
                            }
                            else {
                                int[] pos2 = new int[] { x, y };
                                goto Outside;
                            }
                        }
                    }
                }
                Outside:
                //TODO add logic to check against piece type and if the spaces could be moved between

            }
            else return false;
        }

       
    }
}
