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
        private readonly BoardWatchService _bws;
        public readonly BoardTools _bt;//; = new BoardTools();
        List<BetterPanel> panelsRed = new List<BetterPanel>();
        List<BetterPanel> panelsBlu = new List<BetterPanel>();

        private BoardView DialogBoardView;
        public Form1(BoardWatchService bws, IGlyphTools gt, BoardTools bt)
        {
            InitializeComponent();
            _bws = bws;
            _bt = bt;
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
            LoadPanels(panelsBlu, FlowBlu);
            LoadPanels(panelsRed, FlowRed);
            _bws.NewBlueData += _bws_NewBlueData;
            _bws.NewRedFrame += _bws_NewRedFrame;
            _bws.NewRawFrame += _bws_NewRawFrame;
        }

        private void _bws_NewRawFrame(UnmanagedImage obj)
        {
            PanelRawVideo.DrawImage(obj);
        }

        private void _bws_NewRedFrame(ChannelData obj)
        {
            PanelRed.DrawImage(obj.MaskImage);
            PanelRBW.DrawImage(obj.EdgeImage);
            PanelFinalR.DrawImage(obj.ThresImage);
            DrawEdges(obj.BlobData, PanelFinalR, panelsRed);
        }

        private void _bws_NewBlueData(ChannelData obj)
        {
            PanelBlue.DrawImage(obj.MaskImage);
            PanelBBW.DrawImage(obj.EdgeImage);
            PanelFinalB.DrawImage(obj.ThresImage);
            DrawEdges(obj.BlobData, PanelFinalB, panelsBlu);
        }




        private static void DrawEdges(IList<BlobData> blobs, BetterPanel p, List<BetterPanel> panels)
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


    }
}
