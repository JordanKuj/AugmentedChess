//using AForge;
//using AForge.Imaging;
//using AForge.Imaging.Filters;
//using AForge.Math.Geometry;
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Chess.BoardWatch.Tools
//{
//    public class FilterTool
//    {
//        private EuclideanColorFiltering filter = new EuclideanColorFiltering();
//        private readonly Threshold thresfilter = new Threshold(40);
//        private readonly OtsuThreshold othreshFilter = new OtsuThreshold();
//        private readonly SimpleShapeChecker shapeCheck = new SimpleShapeChecker();
//        private readonly DifferenceEdgeDetector edgefilter = new DifferenceEdgeDetector();
//        private readonly BlobCounter blobCounter = new BlobCounter();

//        UnmanagedImage redImage;
//        UnmanagedImage edgeR;
//        UnmanagedImage threshR;


//        private UnmanagedImage imgraw;
//        public FilterTool()
//        {
//            blobCounter.FilterBlobs = true;
//            blobCounter.ObjectsOrder = ObjectsOrder.XY;
//        }

//        public void SetCfg(ColorFilterSettings cfg)
//        {
//            filter.FillOutside = true;
//            filter.FillColor = new RGB(0, 0, 0);
//            filter.CenterColor = cfg.GetRgb;
//            filter.Radius = cfg.Radius;
//            thresfilter.ThresholdValue = cfg.FilterThreshold;
//        }
//        public void ProcessImage(Bitmap i)
//        {
//            imgraw = UnmanagedImage.FromManagedImage(i);
//            redImage = GetFiltered(imgraw);
//            edgeR = DoEdgeFilter(redImage);
//            threshR = DoThreshFilter(edgeR);

//        }

//        private UnmanagedImage GetFiltered(UnmanagedImage img)
//        {
//            return filter.Apply(img);
//        }
//        private UnmanagedImage DoEdgeFilter(UnmanagedImage img)
//        {
//            return edgefilter.Apply(img);
//        }
//        private UnmanagedImage DoThreshFilter(UnmanagedImage img)
//        {
//            return thresfilter.Apply(img);
//        }

   
//        public UnmanagedImage QuadralateralizeImage(UnmanagedImage img, List<IntPoint> corners, int newWidth, int newHeight)
//        {
//            var qt = new QuadrilateralTransformation(corners, 100, 100);
//            return othreshFilter.Apply(qt.Apply(img));
//        }

//        /// <summary>
//        /// This method will return an array of 1s and 0s that will represent the glyph
//        /// </summary>
//        /// <param name="img">This should be a black and white image of the glyph. No gray</param>
//        /// <param name="rowcol">this will be the number of rows and columns to split the image up by</param>
//        public static int[,] GetGlyphData(UnmanagedImage img, int rowcol)
//        {
//            if (rowcol <= 1)
//                throw new ArgumentException("rowcol must be larger than 1");
//            if (img == null)
//                throw new ArgumentNullException("img cannot be null");

//            var w = img.Width;
//            var h = img.Height;
//            double wr = (w / rowcol);
//            double hr = (h / rowcol);

//            double[,] values = new double[rowcol, rowcol];
//            //double quadrantValue = 0;
//            for (double x = 0; x < w; x++)
//            {
//                for (double y = 0; y < h; y++)
//                {
//                    int xq = (int)Math.Floor(x / wr);
//                    int yq = (int)Math.Floor(y / hr);
//                    if (xq < rowcol && yq < rowcol)
//                    {
//                        var pixel = img.GetPixel((int)x, (int)y);
//                        var val = pixel.R == 0 && pixel.G == 0 && pixel.B == 0;
//                        values[xq, yq] += val ? 1 : 0;
//                    }
//                    //Debug.Print($"x:{x}, y:{y}, xq:{xq}, yq:{yq},  {pixel.ToString()}");
//                }
//            }
//            int[,] intvalues = new int[rowcol, rowcol];
//            int boxArea = (int)(wr * hr);
//            for (var x = 0; x < rowcol; x++)
//            {
//                for (var y = 0; y < rowcol; y++)
//                {
//                    var avg = (values[x, y] / boxArea);
//                    intvalues[x, y] = avg > .5 ? 1 : 0;
//                }
//            }
//            return intvalues;
//        }


//        public void GetEdges(Blob b, out List<System.Drawing.Point> leftEdge, out List<System.Drawing.Point> rightEdge)
//        {
//            List<IntPoint> leftedge;
//            List<IntPoint> rightedge;
//            blobCounter.GetBlobsLeftAndRightEdges(b, out leftedge, out rightedge);
//            leftEdge = new List<System.Drawing.Point>();
//            rightEdge = new List<System.Drawing.Point>();
//            foreach (var p in leftedge)
//            {
//                leftEdge.Add(new System.Drawing.Point(p.X, p.Y));
//            }
//            foreach (var p in rightedge)
//            {
//                rightEdge.Add(new System.Drawing.Point(p.X, p.Y));
//            }
//        }

//        public static UnmanagedImage GetGrascaleImage(Bitmap img)
//        {
//            var tmp = UnmanagedImage.FromManagedImage(img);
//            int h = tmp.Height;
//            int w = tmp.Width;

//            UnmanagedImage grayscaleimage = UnmanagedImage.Create(w, h, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
//            Grayscale.CommonAlgorithms.BT709.Apply(tmp, grayscaleimage);
//            return grayscaleimage;

//        }

//        public static UnmanagedImage GetGrascaleImage(UnmanagedImage tmp)
//        {
//            UnmanagedImage grayscaleimage = UnmanagedImage.Create(tmp.Width, tmp.Height,
//                                                                System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
//            Grayscale.CommonAlgorithms.BT709.Apply(tmp, grayscaleimage);
//            return grayscaleimage;
//        }

//    }
//}
