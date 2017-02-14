using AForge.Imaging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BoardWatch
{
    public static class GlyphTools
    {

        /// <summary>
        /// This method will return an array of 1s and 0s that will represent the glyph
        /// </summary>
        /// <param name="img">This should be a black and white image of the glyph. No gray</param>
        /// <param name="rowcol">this will be the number of rows and columns to split the image up by</param>
        public static int[,] GetGlyphData(UnmanagedImage img, int rowcol)
        {
            if (rowcol <= 1)
                throw new ArgumentException("rowcol must be larger than 1");
            if (img == null)
                throw new ArgumentNullException("img cannot be null");

            var w = img.Width;
            var h = img.Height;
            double wr = (w / rowcol);
            double hr = (h / rowcol);

            double[,] values = new double[rowcol, rowcol];
            //double quadrantValue = 0;
            for (var x = 0; x < w; x++)
            {
                for (var y = 0; y < h; y++)
                {
                    int xq = (int)Math.Floor(x / wr);
                    int yq = (int)Math.Floor(y / hr);
                    var pixel = img.GetPixel(x, y);
                    var val = pixel.R == 0 && pixel.G == 0 && pixel.B == 0;
                    values[xq, yq] += val ? 1 : 0;
                    //Debug.Print($"x:{x}, y:{y}, xq:{xq}, yq:{yq},  {pixel.ToString()}");
                }
            }
            int[,] intvalues = new int[rowcol, rowcol];
            int boxArea = (int)(wr * hr);
            for (var x = 0; x < rowcol; x++)
            {
                for (var y = 0; y < rowcol; y++)
                {
                    var avg = (values[x, y] / boxArea);
                    intvalues[x, y] = avg > .5 ? 1 : 0;
                }
            }
            return intvalues;
        }




    }
}
