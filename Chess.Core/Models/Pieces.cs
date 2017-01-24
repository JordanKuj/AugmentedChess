using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Core.Models
{
    public class King : BasePiece
    {
        public King(PieceColor team, int x, int y) : base(team, x, y)
        {
        }

        public override int MaxOfThisPiece => 1;

        public override ICollection<Vector2d> PossibleMoves(Board b)
        {
            throw new NotImplementedException();
        }
    }
    public class Queen : BasePiece
    {
        public Queen(PieceColor team, int x, int y) : base(team, x, y)
        {
        }
        public override ICollection<Vector2d> PossibleMoves(Board b)
        {
            throw new NotImplementedException();
        }
        public override int MaxOfThisPiece => 1;

    }
    public class Rook : BasePiece
    {
        public Rook(PieceColor team, int x, int y) : base(team, x, y)
        {
        }
        public override ICollection<Vector2d> PossibleMoves(Board b)
        {
            throw new NotImplementedException();
        }
        public override int MaxOfThisPiece => 2;
    }
    public class Bishop : BasePiece
    {
        public Bishop(PieceColor team, int x, int y) : base(team, x, y)
        {
        }
        public override ICollection<Vector2d> PossibleMoves(Board b)
        {
            throw new NotImplementedException();
        }
        public override int MaxOfThisPiece => 2;
    }
    public class Knight : BasePiece
    {
        public Knight(PieceColor team, int x, int y) : base(team, x, y)
        {
        }
        public override ICollection<Vector2d> PossibleMoves(Board b)
        {
            throw new NotImplementedException();
        }
        public override int MaxOfThisPiece => 2;
    }
    public class Pawn : BasePiece
    {
        public Pawn(PieceColor team, int x, int y) : base(team, x, y)
        {
        }

        public override ICollection<Vector2d> PossibleMoves(Board b)
        {
            throw new NotImplementedException();
        }
        public override int MaxOfThisPiece => 8;
    }

    public abstract class BasePiece : IPiece
    {
        public BasePiece(PieceColor team, int x, int y)
        {
            if (x < 0 || x > 15) { throw new ArgumentOutOfRangeException(); }
            if (y < 0 || y > 15) { throw new ArgumentOutOfRangeException(); }
            Team = team;
            Position = new Vector2d(x, y);
        }
        public PieceColor Team { get; set; }
        public Vector2d Position { get; set; }
        public int X => Position.X;
        public int Y => Position.Y;
        public abstract int MaxOfThisPiece { get; }
        public abstract ICollection<Vector2d> PossibleMoves(Board b);
    }


   


}
