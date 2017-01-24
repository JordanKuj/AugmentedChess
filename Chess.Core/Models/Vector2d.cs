using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Core.Models
{
    public class Vector2d : IEquatable<Vector2d>
    {
        public Vector2d() { }
        public Vector2d(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }

        public bool Equals(Vector2d other)
        {
            return X == other.X && Y == other.Y;
        }
    }
}
