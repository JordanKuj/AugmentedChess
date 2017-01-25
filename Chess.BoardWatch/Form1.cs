using AForge.Video;
using System;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using System.Diagnostics;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace Chess.BoardWatch
{
    public partial class Form1 : Form
    {

        VideoCaptureDevice stream;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //stream = new  VideoCaptureDevice()
            FilterInfoCollection devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            stream = new VideoCaptureDevice(devices[0].MonikerString);
            var c = new VideoCapabilities[stream.VideoCapabilities.Length];
            var capabilities = new List<VideoCapabilities>(c);
            stream.VideoCapabilities.CopyTo(c, 0);
            stream.VideoResolution = c[7];
            stream.NewFrame += Stream_NewFrame;
            pictureBox1.Size = new Size(c[7].FrameSize.Width, c[7].FrameSize.Height);
            stream.Start();
        }
        Bitmap bmp;
        private void Stream_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image?.Dispose();
            bmp = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = bmp;
        }
    }
}
