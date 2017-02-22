using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BoardWatch
{
    public class GlyphTools
    {

        private int Glypdivisions;
        private readonly int MinBlobSize;
        private readonly Threshold thresfilter = new Threshold(40);
        private readonly OtsuThreshold othreshFilter = new OtsuThreshold();
        private readonly DifferenceEdgeDetector edgefilter = new DifferenceEdgeDetector();
        private readonly BlobCounter blobCounter = new BlobCounter();
        private readonly SimpleShapeChecker shapeCheck = new SimpleShapeChecker();


        public GlyphTools(int minblobsize, int glypdivisions)
        {
            MinBlobSize = minblobsize;
            Glypdivisions = glypdivisions;
            blobCounter.MinHeight = MinBlobSize;
            blobCounter.MinWidth = MinBlobSize;
            blobCounter.FilterBlobs = true;
            blobCounter.ObjectsOrder = ObjectsOrder.XY;
        }


        public Blob[] GetBlobs(UnmanagedImage img)
        {
            blobCounter.ProcessImage(img);
            return blobCounter.GetObjectsInformation();
        }

        public Boolean QuadCheck(Blob b, out List<IntPoint> corners)
        {
            List<IntPoint> points = blobCounter.GetBlobsEdgePoints(b);
            return shapeCheck.IsQuadrilateral(points, out corners);
        }
        public void GetEdges(Blob b, out List<System.Drawing.Point> leftEdge, out List<System.Drawing.Point> rightEdge)
        {
            List<IntPoint> leftedge;
            List<IntPoint> rightedge;
            blobCounter.GetBlobsLeftAndRightEdges(b, out leftedge, out rightedge);
            leftEdge = new List<System.Drawing.Point>();
            rightEdge = new List<System.Drawing.Point>();
            foreach (var p in leftedge)
            {
                leftEdge.Add(new System.Drawing.Point(p.X, p.Y));
            }
            foreach (var p in rightedge)
            {
                rightEdge.Add(new System.Drawing.Point(p.X, p.Y));
            }
        }



        public UnmanagedImage DoThreshFilter(UnmanagedImage img)
        {
            return thresfilter.Apply(img);
        }
        public UnmanagedImage DoEdgeFilter(UnmanagedImage img)
        {
            return edgefilter.Apply(img);
        }


        public UnmanagedImage ProcessEdgeFilter(UnmanagedImage img)
        {
            return DoThreshFilter(DoEdgeFilter(img));
        }
        public UnmanagedImage QuadralateralizeImage(UnmanagedImage img, List<IntPoint> corners, int newWidth, int newHeight)
        {
            var qt = new QuadrilateralTransformation(corners, 100, 100);
            return othreshFilter.Apply(qt.Apply(img));
        }


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

        public static UnmanagedImage GetGrascaleImage(Bitmap img)
        {
            var tmp = UnmanagedImage.FromManagedImage(img);
            int h = tmp.Height;
            int w = tmp.Width;
            UnmanagedImage grayscaleimage = UnmanagedImage.Create(w, h, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
            Grayscale.CommonAlgorithms.BT709.Apply(tmp, grayscaleimage);
            return grayscaleimage;
            //UnmanagedImage grayscaleimage = UnmanagedImage.Create(img.Width, img.Height, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
            //Grayscale.CommonAlgorithms.BT709.Apply(img, grayscaleimage);
            //UnmanagedImage finalimage = gt.ProcessEdgeFilter(grayscaleimage.Clone());

        }
        public static UnmanagedImage GetUnmanagedImage(Bitmap img)
        {
            var tmp = UnmanagedImage.FromManagedImage(img);
            int h = tmp.Height;
            int w = tmp.Width;
            return UnmanagedImage.Create(w, h, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
        }


    }

}
