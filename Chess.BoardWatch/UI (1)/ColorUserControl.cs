using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess.BoardWatch
{
    public partial class ColorUserControl : UserControl
    {
        public event Action<ColorFilterSettings> ValueChanged;
        public string Title { get { return groupBox1.Text; } set { groupBox1.Text = value; } }
        private byte Red => (byte)TrackBarRed.Value;
        private byte Blue => (byte)TrackBarBlue.Value;
        private byte Green => (byte)TrackBarGreen.Value;
        private short Radius => (short)numericUpDown1.Value;

        public ColorUserControl()
        {
            InitializeComponent();
        }

        public void Set(ColorFilterSettings s)
        {
            TrackBarBlue.Value = s.Blue;
            TrackBarRed.Value = s.Red;
            TrackBarGreen.Value = s.Green;
            numericUpDown1.Value = s.Radius;
            DrawColor();
        }

        public ColorFilterSettings Get()
        {
            return new ColorFilterSettings(Red, Green, Blue, Radius);
        }

        private void TrackBar_ValueChanged(object sender, EventArgs e)
        {
            LblBlueVal.Text = Blue.ToString();
            LblGreenVal.Text = Green.ToString();
            LblRedval.Text = Red.ToString();

            DrawColor();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ValueChanged?.Invoke(Get());
            DrawColor();
        }

        public void DrawColor()
        {
            var g = panel1.CreateGraphics();
            var b = new SolidBrush(Color.FromArgb(255, Red, Green, Blue));
            g.FillRectangle(Brushes.White, new Rectangle(0, 0, panel1.Width, panel1.Height));
            g.FillEllipse(b, new Rectangle(0, 0, Radius / 2, Radius / 2));
            ValueChanged?.Invoke(Get());
        }

    }
}
