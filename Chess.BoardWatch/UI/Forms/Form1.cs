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
using Chess.BoardWatch.Tools;
using Chess.BoardWatch.Models;
using Ninject;

namespace Chess.BoardWatch
{
    public partial class Form1 : Form
    {
        public static IKernel kernal;

        VideoCaptureDevice stream;
        //const int GlyphDivs = 5;
        const int QuadSize = 50;
        //private readonly int hwsize = (int)((double)QuadSize / (double)GlyphDivs);
        readonly IGlyphTools gt;//= new GlyphTools(32, GlyphDivs);
        Pen left = new Pen(Brushes.Yellow, 5);
        Pen right = new Pen(Brushes.Green, 5);
        List<BetterPanel> panels;
        public Form1()
        {
            InitializeComponent();
            panels = new List<BetterPanel>() { betterPanel1,betterPanel2,betterPanel3,betterPanel4,
                                                betterPanel5,betterPanel6,betterPanel7,betterPanel8,
                                                betterPanel9,betterPanel10,betterPanel11,betterPanel12 };
            kernal = new StandardKernel(new Bindings());
            gt = kernal.Get<IGlyphTools>();// new GlyphTools(CfgUtil.ReadCfg());
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
            stream.Start();
            var dilg = kernal.Get<SettingsForm>();
            dilg.Show();
        }


        private void Stream_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap origional = eventArgs.Frame;
            gt.ProcessImage(origional);

            var glyphRawCropped = ImgBwGlyph.CreateGraphics();
            var GlyphFinal = ImgBwCalc.CreateGraphics();

            PanelRawVideo.DrawImage(origional);
            EdgePanel.DrawImage(gt.EdgeGray);
            PanelBw.DrawImage(gt.GrayImage);
            PanelFinal.DrawImage(gt.threshGray);



            PanelRed.DrawImage(gt.RImage);
            PanelGreen.DrawImage(gt.GImage);
            PanelBlue.DrawImage(gt.BImage);
            PanelRBW.DrawImage(gt.edgeR);
            PanelGBW.DrawImage(gt.edgeG);
            PanelBBW.DrawImage(gt.edgeB);
            PanelFinalR.DrawImage(gt.threshR);
            PanelFinalG.DrawImage(gt.threshG);
            PanelFinalB.DrawImage(gt.threshB);


            //TODO: the blob counters garbage collect a lot I might only want to do this every x frames

            DrawEdges(gt.GrayBlobs, PanelFinal);
            DrawEdges(gt.Rblobs, PanelFinalR);
            DrawEdges(gt.Gblobs, PanelFinalG);
            DrawEdges(gt.Bblobs, PanelFinalB);

            //Blob[] blobs = gt.GrayBlobs;// blobCounter.GetObjectsInformation();







            //    var count = 0;
            //    foreach (var b in gt.GrayBlobs)
            //    {
            //        List<IntPoint> corners;
            //        if (gt.QuadCheck(b, out corners) && count < panels.Count)
            //        {
            //            List<System.Drawing.Point> intleftedge;
            //            List<System.Drawing.Point> intrightedge;
            //            gt.GetEdges(b, out intleftedge, out intrightedge);
            //            UnmanagedImage uBwImg = gt.QuadralateralizeImage(gt.GrayImage, corners, QuadSize, QuadSize);
            //            //BrightnessDiff();
            //            var p = panels.ElementAt(count);
            //            var res = GlyphTools.GetGlyphData(uBwImg, gt.Glypdivisions);
            //            p.DrawMe(res, gt.Glypdivisions);
            //            var bwimg = uBwImg.ToManagedImage();
            //            int minx = corners.Min(x => x.X);
            //            int miny = corners.Min(x => x.Y);
            //            int maxx = corners.Max(x => x.X) - minx;
            //            int maxy = corners.Max(x => x.Y) - miny;
            //            var rect = new Rectangle(minx, miny, maxx, maxy);
            //            glyphRawCropped.DrawImage(bwimg, 0, 0, bwimg.Width, bwimg.Height);
            //            PanelFinal.DrawRectangle(Pens.Red, rect);
            //            PanelFinal.DrawLines(left, intleftedge);
            //            PanelFinal.DrawLines(right, intrightedge);
            //            count += 1;
            //        }
            //    }
            //    panels.Skip(count).ToList().ForEach(x => x.Clear());
        }

        private static void DrawEdges(List<BlobData> blobs, BetterPanel p)
        {
            Pen left = new Pen(Brushes.Yellow, 5);
            Pen right = new Pen(Brushes.Green, 5);
            foreach (var b in blobs)
            {
                p.DrawRectangle(Pens.Red, b.Rect);
                p.DrawLines(left, b.leftedge);
                p.DrawLines(right, b.rightedge);
            }
        }


        //TODO:calculate the average differeance of light inside the box and outside the box
        private static float BrightnessDiff(List<IntPoint> leftEdgePoints, List<IntPoint> rightEdgePoints, UnmanagedImage image)
        {
            return 0;
        }
    }
}
