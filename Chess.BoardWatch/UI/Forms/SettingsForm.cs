using AForge.Imaging;
using Chess.BoardWatch.Models;
using Chess.BoardWatch.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess.BoardWatch
{
    public partial class SettingsForm : Form
    {
        private readonly IGlyphTools _gt;
        private readonly ICfgTool<MasterCfg> _cfgtool;
        private readonly BoardWatchService _bws;
        public SettingsForm(IGlyphTools gt, ICfgTool<MasterCfg> cfgtool, BoardWatchService bws)
        {
            InitializeComponent();
            _gt = gt;
            _cfgtool = cfgtool;
            _bws = bws;
        }

        private void nudThresh_ValueChanged(object sender, EventArgs e)
        {
            _gt.ThreshFilter = ThreshholdVal;
        }
        private void nudMinSize_ValueChanged(object sender, EventArgs e)
        {
            _gt.MinSize = MinGlyphSize;
        }
        private void NudMaxSize_ValueChanged(object sender, EventArgs e)
        {
            _gt.MaxSize = MaxGlyphSize;

        }
        int Glyphdivs => (int)NudGlyphDivs.Value;
        int ThreshholdVal => (int)nudThresh.Value;
        int MinGlyphSize => (int)nudMinSize.Value;
        int MaxGlyphSize => (int)NudMaxSize.Value;
        float BlobSizeRatio => trackBar1.Value / 100f;
        float MinFullness => TrackFullness.Value / 100f;
        //int GlyphDivisions => 

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            _bws.NewRawFrame += _bws_NewRawFrame;
            _bws.NewBlueData += _bws_NewBlueData; ;
            _bws.NewRedFrame += _bws_NewRedFrame; ;
            LoadValues();
        }

        private void _bws_NewRedFrame(ChannelData obj)
        {
            RedPanel.DrawImage(obj.MaskImage);
        }

        private void _bws_NewBlueData(ChannelData obj)
        {
            BluePanel.DrawImage(obj.MaskImage);
        }

        UnmanagedImage RawImage;
        private void _bws_NewRawFrame(AForge.Imaging.UnmanagedImage obj)
        {
            RawImage = obj;
            if (obj != null)
                betterPanel1.DrawImage(obj.ToManagedImage());
        }

        private void LoadValues()
        {
            NudGlyphDivs.Value = _gt.Glypdivisions;
            nudMinSize.Value = _gt.MinSize;
            NudMaxSize.Value = _gt.MaxSize;
            nudThresh.Value = _gt.ThreshFilter;
            trackBar1.Value = (int)(_gt.BlobSizeRatio * 100);
            TrackFullness.Value = (int)(_gt.Minfullness * 100);
            //FilterCtrlGreen.Set(_gt.Green);
            FilterCtrlBlue.Set(_gt.Blue);
            FilterCtrlRed.Set(_gt.Red);
            //FilterCtrlBlack.Set(_gt.Black);
            DrawColors();
        }
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            _gt.BlobSizeRatio = BlobSizeRatio;
            LblVal.Text = BlobSizeRatio.ToString();
        }

        private void TrackFullness_ValueChanged(object sender, EventArgs e)
        {
            _gt.Minfullness = MinFullness;
            LblFullnessVal.Text = MinFullness.ToString();
        }

        private void FilterCtrlRed_ValueChanged(ColorFilterSettings obj)
        {
            _gt.Red = FilterCtrlRed.Get();
        }

        private void FilterCtrlBlue_ValueChanged(ColorFilterSettings obj)
        {
            _gt.Blue = FilterCtrlBlue.Get();
        }

        //private void FilterCtrlGreen_ValueChanged(ColorFilterSettings obj)
        //{
        //    //_gt.Green = FilterCtrlGreen.Get();
        //}
        //private void FilterCtrlBlack_ValueChanged(ColorFilterSettings obj)
        //{
        //    //_gt.Black = FilterCtrlBlack.Get();

        //}

        private void DrawColors()
        {
            FilterCtrlRed.DrawColor();
            FilterCtrlBlue.DrawColor();
            //FilterCtrlGreen.DrawColor();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            _cfgtool.WriteCfg(new MasterCfg()
            {
                BlueFilter = FilterCtrlBlue.Get(),
                RedFilter = FilterCtrlRed.Get(),
                //GreenFilter = FilterCtrlGreen.Get(),
                Glypdivisions = Glyphdivs,
                MinBlobSize = this.MinGlyphSize,
                MaxBlobSize = this.MaxGlyphSize,
                MinFullness = this.MinFullness,
                MinBlobShapeRatio = this.BlobSizeRatio,
                ThreshholdFilterValue = this.ThreshholdVal
            });
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            _gt.MasterCfg = _cfgtool.ReadCfg();
            LoadValues();
        }

        private void NudGlyphDivs_ValueChanged(object sender, EventArgs e)
        {
            _gt.Glypdivisions = Glyphdivs;
        }


        private bool EyeDropperState = false;

        private void BtnEyeDropper_Click(object sender, EventArgs e)
        {
            EyeDropperState = !EyeDropperState;
            BluePanel.Cursor = Cursors.Cross;
            RedPanel.Cursor = Cursors.Cross;
        }



        private void RadEyeOff_CheckedChanged(object sender, EventArgs e)
        {
            var rad = (RadioButton)sender;
            if (rad == RadEyeOff)
            {
                EyeDropperState = false;
                betterPanel1.Cursor = Cursors.Default;
            }
            else if (rad == RadBlueEye || rad == RadRedEye)
            {
                EyeDropperState = true;
                betterPanel1.Cursor = Cursors.Cross;
            }
        }

        private void betterPanel1_Click(object sender, EventArgs e)
        {
            if (RadEyeOff.Checked)
                return;

            var corrds = betterPanel1.PointToClient(Cursor.Position);

            var xRatio = (float)corrds.X / betterPanel1.Width;
            var yRatio = (float)corrds.Y / betterPanel1.Height;

            Debug.WriteLine($"{corrds.X},{corrds.Y}");

            var pixel = RawImage.GetPixel(new AForge.IntPoint((int)(RawImage.Width * xRatio), (int)(RawImage.Height * yRatio)));

            if (RadBlueEye.Checked)
            {
                var settings = FilterCtrlBlue.Get();
                FilterCtrlBlue.Set(new ColorFilterSettings { Radius = settings.Radius, Blue = pixel.B, Red = pixel.R, Green = pixel.G });

            }
            else if (RadRedEye.Checked)
            {
                var settings = FilterCtrlRed.Get();
                FilterCtrlRed.Set(new ColorFilterSettings { Radius = settings.Radius, Blue = pixel.B, Red = pixel.R, Green = pixel.G });
            }


        }
    }
}
