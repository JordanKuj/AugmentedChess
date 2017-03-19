using AForge;
using AForge.Imaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BoardWatch.Models
{
    public class BlobData
    {
        //public BlobData()
        //{
        //    corners = new List<IntPoint>();
        //    leftedge = new List<System.Drawing.Point>();
        //    rightedge = new List<System.Drawing.Point>();
        //}

        public BlobData(Blob b, List<IntPoint> corners, List<System.Drawing.Point> ledge, List<System.Drawing.Point> redge)
        {
            this.Blob = b;
            this.corners = corners;
            this.leftedge = ledge;
            this.rightedge = redge;
            minx = corners.Min(x => x.X);
            miny = corners.Min(x => x.Y);
            maxx = corners.Max(x => x.X) - minx;
            maxy = corners.Max(x => x.Y) - miny;
            Rect = new Rectangle(minx, miny, maxx, maxy);


        }
        public Rectangle Rect { get; }
        public int minx { get; }
        public int miny { get; }
        public int maxx { get; }
        public int maxy { get; }
        public Blob Blob { get; }
        public List<IntPoint> corners { get; }
        public List<System.Drawing.Point> leftedge { get; }
        public List<System.Drawing.Point> rightedge { get; }
        public int GlyphDivisions { get; set; }


        public UnmanagedImage FlatImage { get; set; }
        public int[,] glyph { get; set; }
    }
}
