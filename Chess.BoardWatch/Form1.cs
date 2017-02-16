using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging;
using AForge.Imaging.Filters;

namespace Chess.BoardWatch
{
    public partial class Form1 : Form
    {

        VideoCaptureDevice stream;
        const int GlyphDivs = 5;
        const int QuadSize = 50;
        private readonly int hwsize = (int)((double)QuadSize / (double)GlyphDivs);
        GlyphTools gt = new GlyphTools(32, GlyphDivs);
        Pen left = new Pen(Brushes.Yellow, 5);
        Pen right = new Pen(Brushes.Green, 5);
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

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
            UnmanagedImage grayscaleimage = GlyphTools.GetGrascaleImage(eventArgs.Frame);
            UnmanagedImage finalimage = gt.ProcessEdgeFilter(grayscaleimage.Clone());

            var g = panel1.CreateGraphics();
            var g2 = ImgBwGlyph.CreateGraphics();
            var gBwCalc = ImgBwCalc.CreateGraphics();
            g.DrawImage(finalimage.ToManagedImage(), 0, 0, grayscaleimage.Width, grayscaleimage.Height);

            //TODO: the blob counters garbage collect a lot I might only want to do this every x frames
            Blob[] blobs = gt.GetBlobs(finalimage);// blobCounter.GetObjectsInformation();
            var b = blobs.FirstOrDefault();
            if (b != null)
            {
                List<IntPoint> corners;
                if (gt.QuadCheck(b, out corners))
                {
                    List<System.Drawing.Point> intleftedge;
                    List<System.Drawing.Point> intrightedge;

                    gt.GetEdges(b, out intleftedge, out intrightedge);
                    UnmanagedImage uBwImg = gt.QuadralateralizeImage(grayscaleimage, corners, QuadSize, QuadSize);

                    //BrightnessDiff();
                    var res = GlyphTools.GetGlyphData(uBwImg, GlyphDivs);

                    for (var x = 0; x < GlyphDivs; x++)
                        for (var y = 0; y < GlyphDivs; y++)
                            gBwCalc.FillRectangle(res[x, y] == 1 ? Brushes.Black : Brushes.White, x * hwsize, y * hwsize, hwsize, hwsize);

                    var bwimg = uBwImg.ToManagedImage();
                    int minx = corners.Min(x => x.X);
                    int miny = corners.Min(x => x.Y);
                    int maxx = corners.Max(x => x.X) - minx;
                    int maxy = corners.Max(x => x.Y) - miny;
                    var rect = new Rectangle(minx, miny, maxx, maxy);
                    g2.DrawImage(bwimg, 0, 0, bwimg.Width, bwimg.Height);
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
    }
}
