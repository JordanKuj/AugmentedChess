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
using System.Threading.Tasks;
using Chess.BoardWatch.UI.Forms;

namespace Chess.BoardWatch
{
    public partial class Form1 : Form
    {
        public static IKernel kernal;
        public readonly BoardTools _bt;//; = new BoardTools();
        VideoCaptureDevice stream;
        //const int GlyphDivs = 5;
        //const int QuadSize = 50;
        //private readonly int hwsize = (int)((double)QuadSize / (double)GlyphDivs);
        //Pen left = new Pen(Brushes.Yellow, 5);
        //Pen right = new Pen(Brushes.Green, 5);
        private readonly IGlyphTools _gt;
        List<BetterPanel> panelsBnw = new List<BetterPanel>();
        List<BetterPanel> panelsRed = new List<BetterPanel>();
        List<BetterPanel> panelsGrn = new List<BetterPanel>();
        List<BetterPanel> panelsBlu = new List<BetterPanel>();

        private BoardView DialogBoardView;
        public Form1()
        {
            InitializeComponent();
            kernal = new StandardKernel(new Bindings());
            _gt = kernal.Get<IGlyphTools>();// new GlyphTools(CfgUtil.ReadCfg());
            _bt = kernal.Get<BoardTools>();
        }

        private static void LoadPanels(List<BetterPanel> panels, FlowLayoutPanel flowpanel)
        {
            for (var x = 0; x < 11; x++)
            {
                var p = new BetterPanel();
                p.Height = 105;
                p.Width = 105;
                p.BorderStyle = BorderStyle.FixedSingle;
                panels.Add(p);

                flowpanel.Controls.Add(p);
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadPanels(panelsBnw, FlowBnw);
            LoadPanels(panelsBlu, FlowBlu);
            LoadPanels(panelsRed, FlowRed);
            LoadPanels(panelsGrn, FlowGrn);

            stream = new VideoCaptureDevice();
            FilterInfoCollection devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            stream = new VideoCaptureDevice(devices[1].MonikerString);
            var c = new VideoCapabilities[stream.VideoCapabilities.Length];
            var capabilities = new List<VideoCapabilities>(c);
            stream.VideoCapabilities.CopyTo(c, 0);
            var vidres = c[0];
            stream.VideoResolution = vidres;
            stream.NewFrame += Stream_NewFrame;
            stream.Start();
            var dilg = kernal.Get<SettingsForm>();
            dilg.Show();

            DialogBoardView = kernal.Get<BoardView>();
            DialogBoardView.Show();
        }


        Task ProcessingImage;

        private void Stream_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            PanelRawVideo.DrawImage(eventArgs.Frame);
            if (ProcessingImage == null || ProcessingImage.IsCompleted)
                ProcessingImage = ProcessImage((Bitmap)eventArgs.Frame.Clone());
        }


        private async Task ProcessImage(Bitmap origional)
        {
            await _gt.ProcessImage(origional);
            var state = _bt.UpdateCurrentState(_gt.Rblobs, _gt.Bblobs, new Rectangle(0, 0, origional.Width, origional.Height));

            DialogBoardView.DrawBoard(origional, state);
            EdgePanel.DrawImage(_gt.EdgeBlack);
            PanelBw.DrawImage(_gt.BlackImage);
            PanelFinal.DrawImage(_gt.threshBlack);



            PanelRed.DrawImage(_gt.RImage);
            PanelGreen.DrawImage(_gt.GImage);
            PanelBlue.DrawImage(_gt.BImage);
            PanelRBW.DrawImage(_gt.edgeR);
            PanelGBW.DrawImage(_gt.edgeG);
            PanelBBW.DrawImage(_gt.edgeB);
            PanelFinalR.DrawImage(_gt.threshR);
            PanelFinalG.DrawImage(_gt.threshG);
            PanelFinalB.DrawImage(_gt.threshB);


            //TODO: the blob counters garbage collect a lot I might only want to do this every x frames

            DrawEdges(_gt.BlackBlobs, PanelFinal, panelsBnw);
            DrawEdges(_gt.Rblobs, PanelFinalR, panelsRed);
            DrawEdges(_gt.Gblobs, PanelFinalG, panelsGrn);
            DrawEdges(_gt.Bblobs, PanelFinalB, panelsBlu);

            //gt.GrayBlobs.Select(x=>x.Blob.Rectangle)

            //var whitePieces = gt.Rblobs;
            //var blackPieces = gt.Bblobs;



        }

        private static void DrawEdges(List<BlobData> blobs, BetterPanel p, List<BetterPanel> panels)
        {
            var c = 0;
            p.DrawBlobs(blobs);
            foreach (var b in blobs)
            {
                if (c < panels.Count)
                {
                    panels[c].DrawMe(b.glyph, b.GlyphDivisions);
                    c++;
                }
            }
            panels.Skip(c).ToList().ForEach(x => x.Clear());
        }


        //TODO:calculate the average difference of light inside the box and outside the box
        private static float BrightnessDiff(List<IntPoint> leftEdgePoints, List<IntPoint> rightEdgePoints, UnmanagedImage image)
        {
            return 0;
        }
    }
}
