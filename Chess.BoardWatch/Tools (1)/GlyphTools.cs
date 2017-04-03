using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;
using Chess.BoardWatch.Models;
using Chess.BoardWatch.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BoardWatch
{


    public class GlyphTools : IGlyphTools
    {
        #region Properties
        private int _minsize;
        private float _blobSizeRatio;
        private ColorFilterSettings _red;
        private ColorFilterSettings _blue;
        private ColorFilterSettings _green;
        private MasterCfg _cfg;


        public int MinSize
        {
            get { return _minsize; }
            set
            {
                _minsize = value;
                foreach (var b in blobcounters)
                {
                    b.MinHeight = value;
                    b.MinWidth = value;
                }
            }
        }
        public int ThreshFilter
        {
            get { return thresfilter.ThresholdValue; }
            set { thresfilter.ThresholdValue = value; }
        }
        public float BlobSizeRatio
        {
            get { return _blobSizeRatio; }
            set
            {
                if (value > 1 || value < 0) throw new Exception();
                _blobSizeRatio = value;
            }
        }
        public float Minfullness { get; set; }
        public int Glypdivisions { get; set; }
        public ColorFilterSettings Red
        {
            get { return _red; }
            set
            {
                _red = value;
                SetColorFilter(_red, RedFilter);
            }
        }
        public ColorFilterSettings Blue
        {
            get { return _blue; }
            set
            {
                _blue = value;
                SetColorFilter(_blue, BlueFilter);
            }
        }
        public ColorFilterSettings Green
        {
            get { return _green; }
            set
            {
                _green = value;
                SetColorFilter(_green, GreenFilter);
            }
        }



        public UnmanagedImage _GrayImage;
        public UnmanagedImage _EdgeGray;
        public UnmanagedImage _threshGray;
        public UnmanagedImage _RImage;
        public UnmanagedImage _GImage;
        public UnmanagedImage _BImage;
        public UnmanagedImage _edgeR;
        public UnmanagedImage _edgeG;
        public UnmanagedImage _edgeB;
        public UnmanagedImage _threshR;
        public UnmanagedImage _threshG;
        public UnmanagedImage _threshB;

        public UnmanagedImage GrayImage { get { return _GrayImage; } set { _GrayImage = value; } }
        public UnmanagedImage EdgeGray { get { return _EdgeGray; } set { _EdgeGray = value; } }
        public UnmanagedImage threshGray { get { return _threshGray; } set { _threshGray = value; } }
        public UnmanagedImage RImage { get { return _RImage; } set { _RImage = value; } }
        public UnmanagedImage GImage { get { return _GImage; } set { _GImage = value; } }
        public UnmanagedImage BImage { get { return _BImage; } set { _BImage = value; } }
        public UnmanagedImage edgeR { get { return _edgeR; } set { _edgeR = value; } }
        public UnmanagedImage edgeG { get { return _edgeG; } set { _edgeG = value; } }
        public UnmanagedImage edgeB { get { return _edgeB; } set { _edgeB = value; } }

        public UnmanagedImage threshR { get { return _threshR; } set { _threshR = value; } }
        public UnmanagedImage threshG { get { return _threshG; } set { _threshG = value; } }
        public UnmanagedImage threshB { get { return _threshB; } set { _threshB = value; } }

        public List<BlobData> Rblobs { get; private set; }
        public List<BlobData> Gblobs { get; private set; }
        public List<BlobData> Bblobs { get; private set; }
        public List<BlobData> GrayBlobs { get; private set; }

        public MasterCfg MasterCfg
        {
            private get { return _cfg; }
            set
            {
                _cfg = value;
                foreach (var b in blobcounters)
                {
                    b.FilterBlobs = true;
                    b.ObjectsOrder = ObjectsOrder.XY;
                }

                Red = _cfg.RedFilter;
                Green = _cfg.GreenFilter;
                Blue = _cfg.BlueFilter;
                Minfullness = _cfg.MinFullness;
                BlobSizeRatio = _cfg.MinBlobShapeRatio;
                MinSize = _cfg.MinBlobSize;
                thresfilter.ThresholdValue = _cfg.ThreshholdFilterValue;
                Glypdivisions = _cfg.Glypdivisions;
            }
        }

        private EuclideanColorFiltering RedFilter = new EuclideanColorFiltering();
        private EuclideanColorFiltering BlueFilter = new EuclideanColorFiltering();
        private EuclideanColorFiltering GreenFilter = new EuclideanColorFiltering();
        private readonly Threshold thresfilter = new Threshold(40);
        private readonly OtsuThreshold othreshFilter = new OtsuThreshold();
        private readonly SimpleShapeChecker shapeCheck = new SimpleShapeChecker();
        private readonly DifferenceEdgeDetector edgefilter = new DifferenceEdgeDetector();

        private readonly BlobCounter blobCounterGray = new BlobCounter();
        private readonly BlobCounter blobCounterRed = new BlobCounter();
        private readonly BlobCounter blobCounterBlue = new BlobCounter();
        private readonly BlobCounter blobCounterGreen = new BlobCounter();

        private readonly BlobCounter[] blobcounters;
        #endregion


        public GlyphTools(ICfgTool<MasterCfg> cfgtool)
        {
            blobcounters = new BlobCounter[] { blobCounterGray, blobCounterRed, blobCounterBlue, blobCounterGreen };
            var cfg = cfgtool.ReadCfg();
            Rblobs = new List<BlobData>();
            Bblobs = new List<BlobData>();
            Gblobs = new List<BlobData>();
            GrayBlobs = new List<BlobData>();
            this.MasterCfg = cfg;
        }


        long swhigh = 0;
        long swlow = int.MaxValue;
        public async Task ProcessImage(Bitmap origional)
        {
            var sw = Stopwatch.StartNew();
            var unmanagedOrig = UnmanagedImage.FromManagedImage(origional);
            _GrayImage = GetGrascaleImage(unmanagedOrig);
            var tGray = Task.Factory.StartNew(() =>
            {
                DoEdgeAndThresh(_GrayImage, out _EdgeGray, out _threshGray);
                var tmpGrayBlobs = GetBlobs(threshGray, blobCounterGray, BlobSizeRatio, Minfullness);
                GrayBlobs.Clear();
                GrayBlobs.AddRange(GetBlobData(tmpGrayBlobs, blobCounterGray, shapeCheck));
                DrawEdges(GrayBlobs, this);

            });
            var tRed = Task.Factory.StartNew(() =>
            {
                _RImage = RedFilter.Apply(unmanagedOrig);
                DoEdgeAndThresh(GetGrascaleImage(_RImage), out _edgeR, out _threshR);
                var tmpRblobs = GetBlobs(threshR, blobCounterRed, BlobSizeRatio, Minfullness);
                Rblobs.Clear();
                Rblobs.AddRange(GetBlobData(tmpRblobs, blobCounterRed, shapeCheck));
                DrawEdges(Rblobs, this);

            });
            var tGrn = Task.Factory.StartNew(() =>
            {
                _GImage = GreenFilter.Apply(unmanagedOrig);
                DoEdgeAndThresh(GetGrascaleImage(_GImage), out _edgeG, out _threshG);
                var tmpGblobs = GetBlobs(threshG, blobCounterGreen, BlobSizeRatio, Minfullness);
                Gblobs.Clear();
                Gblobs.AddRange(GetBlobData(tmpGblobs, blobCounterGreen, shapeCheck));
                DrawEdges(Gblobs, this);

            });
            var tBlu = Task.Factory.StartNew(() =>
            {
                _BImage = BlueFilter.Apply(unmanagedOrig);
                DoEdgeAndThresh(GetGrascaleImage(_BImage), out _edgeB, out _threshB);
                var tmpBblobs = GetBlobs(threshB, blobCounterBlue, BlobSizeRatio, Minfullness);
                Bblobs.Clear();
                Bblobs.AddRange(GetBlobData(tmpBblobs, blobCounterBlue, shapeCheck));
                DrawEdges(Bblobs, this);
            });



            await tGray;
            await tBlu;
            await tGrn;
            await tRed;


            sw.Stop();
            if (sw.ElapsedMilliseconds > swhigh)
                swhigh = sw.ElapsedMilliseconds;
            else if (sw.ElapsedMilliseconds < swlow)
                swlow = sw.ElapsedMilliseconds;
            Debug.Print($"ProcessImage high:{swhigh} low:{swlow} avg:{sw.ElapsedMilliseconds}");
        }
        const int QuadSize = 50;


        private static void DrawEdges(List<BlobData> blobs, IGlyphTools gt)
        {
            Pen left = new Pen(Brushes.Yellow, 5);
            Pen right = new Pen(Brushes.Green, 5);
            var c = 0;

            foreach (var b in blobs)
            {
                b.GlyphDivisions = gt.Glypdivisions;
                b.FlatImage = gt.QuadralateralizeImage(gt.GrayImage, b.corners, QuadSize);
                b.glyph = GlyphTools.GetGlyphData(b.FlatImage, gt.Glypdivisions);
            }
        }


        public static Blob[] GetBlobs(UnmanagedImage img, BlobCounter bc, float BlobSizeRatio, float Minfullness)
        {
            bc.ProcessImage(img);
            var filteredBlobs = new List<Blob>();
            var blobs = bc.GetObjectsInformation();
            foreach (var b in blobs)
            {
                var ratio = ((float)b.Rectangle.Height) / ((float)b.Rectangle.Width);
                if (ratio >= BlobSizeRatio)
                    if (b.Fullness >= Minfullness)
                        filteredBlobs.Add(b);
            }

            return filteredBlobs.ToArray();
        }
        private static IEnumerable<BlobData> GetBlobData(Blob[] blobs, BlobCounter bc, SimpleShapeChecker sc)
        {
            var bdata = new List<BlobData>();
            foreach (var b in blobs)
            {
                List<IntPoint> points = bc.GetBlobsEdgePoints(b);
                List<IntPoint> corners;
                if (sc.IsQuadrilateral(points, out corners))
                {
                    List<System.Drawing.Point> intleftedge;
                    List<System.Drawing.Point> intrightedge;
                    GetEdges(b, out intleftedge, out intrightedge, bc);
                    bdata.Add(new BlobData(b, corners, intleftedge, intrightedge));
                }
            }
            return bdata;
        }
        private static void SetColorFilter(ColorFilterSettings c, EuclideanColorFiltering filter)
        {
            filter.FillOutside = true;
            filter.FillColor = new RGB(0, 0, 0);
            filter.CenterColor = c.GetRgb;
            filter.Radius = c.Radius;
        }

        private static void GetEdges(Blob b, out List<System.Drawing.Point> leftEdge, out List<System.Drawing.Point> rightEdge, BlobCounter bc)
        {
            List<IntPoint> leftedge;
            List<IntPoint> rightedge;
            bc.GetBlobsLeftAndRightEdges(b, out leftedge, out rightedge);
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

        public UnmanagedImage QuadralateralizeImage(UnmanagedImage img, List<IntPoint> corners, int newsize)
        {
            var qt = new QuadrilateralTransformation(corners, newsize, newsize);
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
            for (double x = 0; x < w; x++)
            {
                for (double y = 0; y < h; y++)
                {
                    int xq = (int)Math.Floor(x / wr);
                    int yq = (int)Math.Floor(y / hr);
                    if (xq < rowcol && yq < rowcol)
                    {
                        var pixel = img.GetPixel((int)x, (int)y);
                        var val = pixel.R == 0 && pixel.G == 0 && pixel.B == 0;
                        values[xq, yq] += val ? 1 : 0;
                    }
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

        private static UnmanagedImage GetGrascaleImage(Bitmap img)
        {
            var tmp = UnmanagedImage.FromManagedImage(img);
            int h = tmp.Height;
            int w = tmp.Width;

            UnmanagedImage grayscaleimage = UnmanagedImage.Create(w, h, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
            Grayscale.CommonAlgorithms.BT709.Apply(tmp, grayscaleimage);
            return grayscaleimage;

        }
        private static UnmanagedImage GetGrascaleImage(UnmanagedImage tmp)
        {
            UnmanagedImage grayscaleimage = UnmanagedImage.Create(tmp.Width, tmp.Height,
                                                                System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
            Grayscale.CommonAlgorithms.BT709.Apply(tmp, grayscaleimage);
            return grayscaleimage;
        }
        //private UnmanagedImage DoThreshFilter(UnmanagedImage img)
        //{
        //    return thresfilter.Apply(img);
        //}
        //private UnmanagedImage DoEdgeFilter(UnmanagedImage img)
        //{
        //    return edgefilter.Apply(img);
        //}

        private void DoEdgeAndThresh(UnmanagedImage img, out UnmanagedImage edge, out UnmanagedImage thresh)
        {
            edge = edgefilter.Apply(img);
            thresh = thresfilter.Apply(edge);
        }
    }

}
