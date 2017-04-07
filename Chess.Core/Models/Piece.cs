using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTest
{
    public enum PieceType
    {
        pawn, rook, knight, bishop, king, queen, error = 0
    }
    public enum Team
    {
        black, white, error = 0
    }
    public class Piece
    {
        Team Team;
        PieceType Name;
        bool HasMoved;

        public Piece(Team t, PieceType n)
        {
            Team = t;
            Name = n;
            HasMoved = false;
        }
        public Piece(Piece p)
        {
            Team = p.Team;
            Name = p.Name;
            HasMoved = p.HasMoved;
        }

        public Team getTeam()
        {
            return Team;
        }

        public PieceType getName()
        {
            return Name;
        }
        public string getNameString()
        {
            switch (Name)
            {
                case PieceType.pawn:
                    return "Pawn";
                case PieceType.rook:
                    return "Rook";
                case PieceType.knight:
                    return "Knight";
                case PieceType.bishop:
                    return "Bishop";
                case PieceType.king:
                    return "King";
                case PieceType.queen:
                    return "Queen";
                default:
                    return "ERROR";
            }
        }
        public bool getHasMoved()
        {
            return HasMoved;
        }
        public void setHasMoved()
        {
            HasMoved = true;
        }
        public Piece copy()
        {
            return new Piece(Team, Name);
        }

        public void setTeam(Team t)
        {
            this.Team = t;
        }

        public void setName(PieceType type)
        {
            this.Name = type;
        }
    }
}
