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
        private readonly GlyphTools _gt;
        public SettingsForm(GlyphTools gt)
        {
            InitializeComponent();
            _gt = gt;
        }

        private void nudThresh_ValueChanged(object sender, EventArgs e)
        {
            _gt.ThreshFilter = (int)nudThresh.Value;
        }
        private void nudMinSize_ValueChanged(object sender, EventArgs e)
        {
            _gt.MinSize = (int)nudMinSize.Value;
        }


        private void SettingsForm_Load(object sender, EventArgs e)
        {
            nudMinSize.Value = _gt.MinSize;
            nudThresh.Value = _gt.ThreshFilter;
            trackBar1.Value = (int)(_gt.BlobSizeRatio * 100);
            TrackFullness.Value = (int)(_gt.Minfullness * 100);
            //nudMinSize.Refresh();
            //nudMinSize.Update();
            
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            var val = trackBar1.Value / 100f;
            _gt.BlobSizeRatio = val;
            LblVal.Text = val.ToString();
        }

        private void TrackFullness_ValueChanged(object sender, EventArgs e)
        {
            var val = TrackFullness.Value / 100f;
            _gt.Minfullness = val;
            LblFullnessVal.Text = val.ToString();
        }
    }
}
