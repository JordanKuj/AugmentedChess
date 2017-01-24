using Chess.Core.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Chess.Core.Models
{
    public class Board : IBoard
    {
        private List<IPiece> BoardSpots = new List<IPiece>(64);

        int ICollection<IPiece>.Count => BoardSpots.Count;

        bool ICollection<IPiece>.IsReadOnly => false;

        void ICollection<IPiece>.Add(IPiece p)
        {
            if (BoardSpots.Any(x => x.Equals(p)))
                throw new Exception($"There is a piece already occupying the postion x:{p.Position.X} y:{p.Position.Y}");
            if (BoardSpots.Count > 32)
                throw new Exception("Added to many pieces");

            var max = p.MaxOfThisPiece;
            var count = BoardSpots.Count(x => x.GetType() == p.GetType() && x.Team == p.Team);
            if (count > max)
                throw new Exception($"Adding to many of type {p.GetType()}");

            BoardSpots.Add(p);
        }

        void ICollection<IPiece>.Clear()
        {
            BoardSpots.Clear();
        }

        bool ICollection<IPiece>.Contains(IPiece item)
        {
            return BoardSpots.Contains(item);
        }

        void ICollection<IPiece>.CopyTo(IPiece[] array, int arrayIndex)
        {
            BoardSpots.CopyTo(array, arrayIndex);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return BoardSpots.GetEnumerator();
        }

        IEnumerator<IPiece> IEnumerable<IPiece>.GetEnumerator()
        {
            return BoardSpots.GetEnumerator();
        }

        bool ICollection<IPiece>.Remove(IPiece item)
        {
            return BoardSpots.Remove(item);
        }
    }


    public interface IBoard : ICollection<IPiece>
    {
        //Bool MovePiece(vector2d source,vector2d dest)
        //Ilist<Vector2d>ValidMovesForPieceAt(Vector2d location)
    }






}
