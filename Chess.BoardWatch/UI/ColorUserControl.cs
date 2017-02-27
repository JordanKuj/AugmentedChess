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


        public ColorUserControl()
        {
            InitializeComponent();
        }


        public string Title { get { return groupBox1.Text; } set { groupBox1.Text = value; } }


        public void Set(ColorFilterSettings s)
        {
            TrackBarBlue.Value = s.Blue;
            TrackBarRed.Value = s.Red;
            TrackBarGreen.Value = s.Green;
            numericUpDown1.Value = s.Radius;
        }
        public ColorFilterSettings Get()
        {
            return new ColorFilterSettings(Red, Green, Blue, Radius);
        }



        private byte Red => (byte)TrackBarRed.Value;
        private byte Blue => (byte)TrackBarBlue.Value;
        private byte Green => (byte)TrackBarGreen.Value;
        private short Radius => (short)numericUpDown1.Value;

        private void TrackBar_ValueChanged(object sender, EventArgs e)
        {
            LblBlueVal.Text = Blue.ToString();
            LblGreenVal.Text = Green.ToString();
            LblRedval.Text = Red.ToString();

            var g = panel1.CreateGraphics();
            var b = new SolidBrush(Color.FromArgb(255, Red, Green, Blue));

            g.FillRectangle(b, new Rectangle(0, 0, panel1.Width, panel1.Height));

            ValueChanged.Invoke(Get());
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ValueChanged.Invoke(Get());
        }
    }
}
