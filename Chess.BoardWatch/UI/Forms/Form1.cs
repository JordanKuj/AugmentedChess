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
        List<BetterPanel> panels;
        public Form1()
        {
            InitializeComponent();
            panels = new List<BetterPanel>() { betterPanel1,betterPanel2,betterPanel3,betterPanel4,
                                                betterPanel5,betterPanel6,betterPanel7,betterPanel8,
                                                betterPanel9,betterPanel10,betterPanel11,betterPanel12 };
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            stream = new VideoCaptureDevice();
            FilterInfoCollection devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            stream = new VideoCaptureDevice(devices[0].MonikerString);
            var c = new VideoCapabilities[stream.VideoCapabilities.Length];
            var capabilities = new List<VideoCapabilities>(c);
            stream.VideoCapabilities.CopyTo(c, 0);
            var vidres = c[0];
            stream.VideoResolution = vidres;
            stream.NewFrame += Stream_NewFrame;
            //panel1.Size = new Size(vidres.FrameSize.Width, vidres.FrameSize.Height);
            stream.Start();
            var dilg = new SettingsForm(gt);
            dilg.Show();

            //var w1 = panel1.Width / 2;
            //var h1 = panel1.Height / 2;
            //topleft = new Rectangle(0, 0, w1, h1);
            //topright = new Rectangle(w1, 0, w1, h1);
            //bottomleft = new Rectangle(0, h1, w1, h1);
            //bottomright = new Rectangle(w1, h1, w1, h1);
        }


        private Rectangle topleft;
        private Rectangle topright;
        private Rectangle bottomleft;
        private Rectangle bottomright;

        private void Stream_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap origional = eventArgs.Frame;
            UnmanagedImage redImage = gt.GetRed(origional);
            UnmanagedImage grayscaleimage = GlyphTools.GetGrascaleImage(origional);
            //UnmanagedImage grayscaleimage = GlyphTools.GetGrascaleImage(originalimg);
            UnmanagedImage edgeimg = gt.DoEdgeFilter(grayscaleimage);
            UnmanagedImage finalimage = gt.DoThreshFilter(edgeimg);


            //panels.ForEach(x => x.Clear());

            //var RawVid = panel1.CreateGraphics();
            var glyphRawCropped = ImgBwGlyph.CreateGraphics();
            var GlyphFinal = ImgBwCalc.CreateGraphics();

            PanelRawVideo.DrawImage(origional);
            BWPanel.DrawImage(grayscaleimage);
            EdgePanel.DrawImage(edgeimg);
            FinalPanel.DrawImage(finalimage);
            PanelRed.DrawImage(redImage);
            //RawVid.DrawImage(origional, topleft);
            //RawVid.DrawImage(grayscaleimage.ToManagedImage(), topright);
            //RawVid.DrawImage(edgeimg.ToManagedImage(), bottomleft);
            //RawVid.DrawImage(finalimage.ToManagedImage(), bottomright);
            //g.DrawImage(finalimage.ToManagedImage(), 0, 0, grayscaleimage.Width, grayscaleimage.Height);

            //TODO: the blob counters garbage collect a lot I might only want to do this every x frames
            Blob[] blobs = gt.GetBlobs(finalimage);// blobCounter.GetObjectsInformation();
            var count = 0;
            foreach (var b in blobs.ToList())
            {
                List<IntPoint> corners;
                if (gt.QuadCheck(b, out corners) && count < panels.Count)
                {
                    List<System.Drawing.Point> intleftedge;
                    List<System.Drawing.Point> intrightedge;

                    gt.GetEdges(b, out intleftedge, out intrightedge);
                    UnmanagedImage uBwImg = gt.QuadralateralizeImage(grayscaleimage, corners, QuadSize, QuadSize);

                    //BrightnessDiff();
                    var p = panels.ElementAt(count);
                    var res = GlyphTools.GetGlyphData(uBwImg, GlyphDivs);
                    //for (var x = 0; x < GlyphDivs; x++)
                    //    for (var y = 0; y < GlyphDivs; y++)
                    //        GlyphFinal.FillRectangle(res[x, y] == 1 ? Brushes.Black : Brushes.White, x * hwsize, y * hwsize, hwsize, hwsize);
                    p.DrawMe(res);
                    var bwimg = uBwImg.ToManagedImage();
                    int minx = corners.Min(x => x.X);
                    int miny = corners.Min(x => x.Y);
                    int maxx = corners.Max(x => x.X) - minx;
                    int maxy = corners.Max(x => x.Y) - miny;
                    var rect = new Rectangle(minx, miny, maxx, maxy);
                    glyphRawCropped.DrawImage(bwimg, 0, 0, bwimg.Width, bwimg.Height);
                    FinalPanel.DrawRectangle(Pens.Red, rect);
                    FinalPanel.DrawLines(left, intleftedge);
                    FinalPanel.DrawLines(right, intrightedge);
                    count += 1;
                }
            }
            panels.Skip(count).ToList().ForEach(x => x.Clear());
        }


        //TODO:calculate the average differeance of light inside the box and outside the box
        private static float BrightnessDiff(List<IntPoint> leftEdgePoints, List<IntPoint> rightEdgePoints, UnmanagedImage image)
        {
            return 0;
        }
    }
}
