using Chess.BoardWatch.Models;
using Chess.BoardWatch.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public SettingsForm(IGlyphTools gt, ICfgTool<MasterCfg> cfgtool)
        {
            InitializeComponent();
            _gt = gt;
            _cfgtool = cfgtool;
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
            LoadValues();
        }
        private void LoadValues()
        {
            NudGlyphDivs.Value = _gt.Glypdivisions;
            nudMinSize.Value = _gt.MinSize;
            NudMaxSize.Value = _gt.MaxSize;
            nudThresh.Value = _gt.ThreshFilter;
            trackBar1.Value = (int)(_gt.BlobSizeRatio * 100);
            TrackFullness.Value = (int)(_gt.Minfullness * 100);
            FilterCtrlGreen.Set(_gt.Green);
            FilterCtrlBlue.Set(_gt.Blue);
            FilterCtrlRed.Set(_gt.Red);
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

        private void FilterCtrlGreen_ValueChanged(ColorFilterSettings obj)
        {
            _gt.Green = FilterCtrlGreen.Get();
        }

        private void SettingsForm_Activated(object sender, EventArgs e)
        {
            FilterCtrlRed.DrawColor();
            FilterCtrlBlue.DrawColor();
            FilterCtrlGreen.DrawColor();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            _cfgtool.WriteCfg(new MasterCfg()
            {
                BlueFilter = FilterCtrlBlue.Get(),
                RedFilter = FilterCtrlRed.Get(),
                GreenFilter = FilterCtrlGreen.Get(),
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


    }
}
