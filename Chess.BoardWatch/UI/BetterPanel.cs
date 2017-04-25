using AForge.Imaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chess.BoardWatch.Models;

namespace Chess.BoardWatch
{
    public class BetterPanel : Panel
    {

        //const int GlyphDivs = 5;
        //private int hwsize => ((int)((double)this.Width / (double)GlyphDivs));
        private Graphics g;

        private float xscale = 1;
        private float yscale = 1;

        public BetterPanel()
        {
            this.SetStyle(
              System.Windows.Forms.ControlStyles.UserPaint |
              System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
              System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
              true);
            this.DoubleBuffered = true;
            g = this.CreateGraphics();
        }

        public void DrawMe(int[,] vals, int GlyphDivs)
        {
            var hwsize = ((int)((double)this.Width / (double)GlyphDivs));
            for (var x = 0; x < vals.GetLength(0); x++)
                for (var y = 0; y < vals.GetLength(1); y++)
                    g.FillRectangle(vals[x, y] == 1 ? Brushes.Black : Brushes.White, x * hwsize, y * hwsize, hwsize, hwsize);
        }
        public void DrawImage(Bitmap img)
        {
            var b = this.CreateGraphics();
            xscale = (float)this.Width / (float)img.Width;
            yscale = (float)this.Height / (float)img.Height;
            b.DrawImage(img, 0, 0, this.Width, this.Height);
        }
        public void DrawLines(Pen p, List<System.Drawing.Point> edge)
        {
            var points = edge.ToArray();
            GetNewMatrix().TransformPoints(points);
            this.CreateGraphics().DrawLines(p, points);
        }
        private Matrix GetNewMatrix()
        {
            Matrix m = new Matrix();
            m.Scale(xscale, yscale);
            return m;
        }

        public void DrawBlobs(IList<BlobData> blobs)
        {
            Pen left = new Pen(Brushes.Yellow, 5);
            Pen right = new Pen(Brushes.Green, 5);
            foreach (var b in blobs)
            {
                this.DrawRectangle(Pens.Red, b.Rect);
                this.DrawLines(left, b.leftedge);
                this.DrawLines(right, b.rightedge);
            }
        }

        public void DrawRectangle(Pen p, Rectangle rect)
        {
            RectangleF rf = (rect);
            var b = this.CreateGraphics();
            rf.X *= xscale;
            rf.Y *= yscale;
            rf.Width *= xscale;
            rf.Height *= yscale;
            b.DrawRectangle(Pens.Red, new Rectangle((int)rf.X, (int)rf.Y, (int)rf.Width, (int)rf.Height));
        }
        public void DrawImage(UnmanagedImage img)
        {
            DrawImage(img.ToManagedImage());
        }
        public void Clear()
        {
            this.SuspendLayout();
            this.Invalidate();
            this.ResumeLayout();
        }

        public void DrawChessBoard()
        {

        }



    }
}
