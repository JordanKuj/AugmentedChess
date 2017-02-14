using AForge.Video;
using System;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using System.Diagnostics;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using AForge.Imaging.Filters;
using AForge.Imaging;
using AForge;
using AForge.Math.Geometry;

namespace Chess.BoardWatch
{
    public partial class Form1 : Form
    {

        VideoCaptureDevice stream;
        byte last = 0;
        Threshold thresfilter = new Threshold(40);
        OtsuThreshold othreshFilter = new OtsuThreshold();
        DifferenceEdgeDetector edgefilter = new DifferenceEdgeDetector();
        BlobCounter blobCounter = new BlobCounter();
        SimpleShapeChecker shapeCheck = new SimpleShapeChecker();

        Pen left = new Pen(Brushes.Yellow, 5);
        Pen right = new Pen(Brushes.Green, 5);
        public Form1()
        {
            InitializeComponent();
        }

        //Grayscale grayFilter = new Grayscale(0.2125, 0.7154, 0.0721);

        private void Form1_Load(object sender, EventArgs e)
        {
            blobCounter.MinHeight = 32;
            blobCounter.MinWidth = 32;
            blobCounter.FilterBlobs = true;
            blobCounter.ObjectsOrder = ObjectsOrder.Size;
            stream = new VideoCaptureDevice();
            FilterInfoCollection devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            stream = new VideoCaptureDevice(devices[0].MonikerString);
            var c = new VideoCapabilities[stream.VideoCapabilities.Length];
            var capabilities = new List<VideoCapabilities>(c);
            stream.VideoCapabilities.CopyTo(c, 0);
            stream.VideoResolution = c[7];
            stream.NewFrame += Stream_NewFrame;
            panel1.Size = new Size(c[7].FrameSize.Width, c[7].FrameSize.Height);
            stream.Start();
        }
        private void Stream_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            const int rowcol = 5;
            var tmp = UnmanagedImage.FromManagedImage(eventArgs.Frame);
            int h = tmp.Height;
            int w = tmp.Width;
            UnmanagedImage grayscaleimage;
            if (tmp.PixelFormat == System.Drawing.Imaging.PixelFormat.Format8bppIndexed)
                grayscaleimage = tmp;
            else
            {
                grayscaleimage = UnmanagedImage.Create(w, h, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
                Grayscale.CommonAlgorithms.BT709.Apply(tmp, grayscaleimage);
            }
            UnmanagedImage finalimage = grayscaleimage.Clone();

            edgefilter.ApplyInPlace(finalimage);
            thresfilter.ApplyInPlace(finalimage);

            var g = panel1.CreateGraphics();
            var g2 = ImgBwGlyph.CreateGraphics();
            var gBwCalc = ImgBwCalc.CreateGraphics();
            Bitmap tm = finalimage.ToManagedImage();
            g.DrawImage(tm, 0, 0, w, h);

            //TODO: the blob counters garbage collect a lot I might only want to do this every x frames
            blobCounter.ProcessImage(finalimage);
            Blob[] blobs = blobCounter.GetObjectsInformation();
            var b = blobs.FirstOrDefault();
            if (b != null)
            {
                List<IntPoint> points = blobCounter.GetBlobsEdgePoints(b);
                List<IntPoint> corners;
                if (shapeCheck.IsQuadrilateral(points, out corners))
                {
                    List<IntPoint> leftedge;
                    List<IntPoint> rightedge;

                    List<System.Drawing.Point> intleftedge = new List<System.Drawing.Point>();
                    List<System.Drawing.Point> intrightedge = new List<System.Drawing.Point>();
                    blobCounter.GetBlobsLeftAndRightEdges(b, out leftedge, out rightedge);
                    foreach (var p in leftedge)
                    {
                        intleftedge.Add(new System.Drawing.Point(p.X, p.Y));
                    }
                    foreach (var p in rightedge)
                    {
                        intrightedge.Add(new System.Drawing.Point(p.X, p.Y));
                    }

                    var qt = new QuadrilateralTransformation(corners, 100, 100);

                    int minx = corners.Min(x => x.X);
                    int miny = corners.Min(x => x.Y);
                    int maxx = corners.Max(x => x.X) - minx;
                    int maxy = corners.Max(x => x.Y) - miny;

                    //BrightnessDiff();
                    UnmanagedImage uBwImg = othreshFilter.Apply(qt.Apply(grayscaleimage));
                    var res = GlyphTools.GetGlyphData(uBwImg, rowcol);
                    const int heightwidth = 100;
                    var hwsize = (int)((double)heightwidth / (double)rowcol);
                    for (var x = 0; x < rowcol; x++)
                        for (var y = 0; y < rowcol; y++)
                        {
                            var val = res[x, y];
                            gBwCalc.FillRectangle(val == 1 ? Brushes.Black : Brushes.White, x * hwsize, y * hwsize, hwsize, hwsize);
                        }

                    var bwimg = uBwImg.ToManagedImage();
                    g2.DrawImage(bwimg, 0, 0, bwimg.Width, bwimg.Height);
                    var rect = new Rectangle(minx, miny, maxx, maxy);
                    g.DrawRectangle(Pens.Red, rect);
                    g.DrawLines(left, intleftedge.ToArray());
                    g.DrawLines(right, intrightedge.ToArray());
                }
            }
        }


        //TODO:calculate the average differeance of light inside the box and outside the box
        private static float BrightnessDiff(List<IntPoint> leftEdgePoints, List<IntPoint> rightEdgePoints, UnmanagedImage image)
        {
            return 0;
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {

        }
    }
}
