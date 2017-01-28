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

namespace Chess.BoardWatch
{
    public partial class Form1 : Form
    {

        VideoCaptureDevice stream;
        byte last = 0;
        Threshold thresfilter = new Threshold(40);
        DifferenceEdgeDetector edgefilter = new DifferenceEdgeDetector();
        BlobCounter blobCounter = new BlobCounter();
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
            var tmp = UnmanagedImage.FromManagedImage(eventArgs.Frame);
            int h = tmp.Height;
            int w = tmp.Width;
            UnmanagedImage bmp;
            if (tmp.PixelFormat == System.Drawing.Imaging.PixelFormat.Format8bppIndexed)
                bmp = tmp;
            else
            {
                bmp = UnmanagedImage.Create(w, h, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
                Grayscale.CommonAlgorithms.BT709.Apply(tmp, bmp);
            }
            edgefilter.ApplyInPlace(bmp);
            thresfilter.ApplyInPlace(bmp);
            blobCounter.ProcessImage(bmp);
            Blob[] blobs = blobCounter.GetObjectsInformation();
            using (Bitmap tm = bmp.ToManagedImage())
            {
                var g = panel1.CreateGraphics();
                g.DrawImage(tm, 0, 0, w, h);
            }
        }
    }
}
