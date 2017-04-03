using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chess.BoardWatch.Models;

namespace Chess.BoardWatch.UI.Forms
{
    public partial class GlyphTestForm : Form
    {

        private int[,] _tmpboard = new int[5, 5]
                                                   {
                                                    { 1, 1, 1, 1, 1 },
                                                    { 1, 0, 0, 0, 1 },
                                                    { 1, 0, 0, 0, 1 },
                                                    { 1, 0, 0, 0, 1 },
                                                    { 1, 1, 1, 1, 1 },
                                                   };
        private int[,] tmpboard
        {
            get
            {
                return _tmpboard;
            }
        }



        public GlyphTestForm()
        {
            InitializeComponent();

            checkBox1.MouseClick += (sender, eventargs) => Modify(1, 1, !((CheckBox)sender).Checked);
            checkBox2.MouseClick += (sender, eventargs) => Modify(1, 2, !((CheckBox)sender).Checked);
            checkBox3.MouseClick += (sender, eventargs) => Modify(1, 3, !((CheckBox)sender).Checked);
            checkBox4.MouseClick += (sender, eventargs) => Modify(2, 1, !((CheckBox)sender).Checked);
            checkBox5.MouseClick += (sender, eventargs) => Modify(2, 2, !((CheckBox)sender).Checked);
            checkBox6.MouseClick += (sender, eventargs) => Modify(2, 3, !((CheckBox)sender).Checked);
            checkBox7.MouseClick += (sender, eventargs) => Modify(3, 1, !((CheckBox)sender).Checked);
            checkBox8.MouseClick += (sender, eventargs) => Modify(3, 2, !((CheckBox)sender).Checked);
            checkBox9.MouseClick += (sender, eventargs) => Modify(3, 3, !((CheckBox)sender).Checked);
        }

        private void Modify(int x, int y, bool val)
        {
            _tmpboard[x, y] = val.ToInt();
            update();
        }

        private void update()
        {
            var res = PieceConstants.FindPieceType(tmpboard);
            checkBox1.Checked = tmpboard[1, 1].ToBool();
            checkBox2.Checked = tmpboard[1, 2].ToBool();
            checkBox3.Checked = tmpboard[1, 3].ToBool();
            checkBox4.Checked = tmpboard[2, 1].ToBool();
            checkBox5.Checked = tmpboard[2, 2].ToBool();
            checkBox6.Checked = tmpboard[2, 3].ToBool();
            checkBox7.Checked = tmpboard[3, 1].ToBool();
            checkBox8.Checked = tmpboard[3, 2].ToBool();
            checkBox9.Checked = tmpboard[3, 3].ToBool();
            label1.Text = res.ToString();
        }




        private void BtnVertFlip_Click(object sender, EventArgs e)
        {
            var tl = _tmpboard[1, 1];
            var tc = _tmpboard[2, 1];
            var tr = _tmpboard[3, 1];


            _tmpboard[1, 1] = _tmpboard[1, 3];
            _tmpboard[2, 1] = _tmpboard[2, 3];
            _tmpboard[3, 1] = _tmpboard[3, 3];

            _tmpboard[1, 3] = tl;
            _tmpboard[2, 3] = tc;
            _tmpboard[3, 3] = tr;
            update();

            //var leftTop = checkBox1.Checked;
            //var leftCenter = checkBox4.Checked;
            //var leftBottom = checkBox7.Checked;


            //checkBox1.Checked = checkBox3.Checked;
            //checkBox4.Checked = checkBox6.Checked;
            //checkBox7.Checked = checkBox9.Checked;

            //checkBox3.Checked = leftTop;
            //checkBox6.Checked = leftCenter;
            //checkBox9.Checked = leftBottom;

        }

        private void BtnHorizFlip_Click(object sender, EventArgs e)
        {
            var tl = _tmpboard[1, 1];
            var tc = _tmpboard[1, 2];
            var tr = _tmpboard[1, 3];


            _tmpboard[1, 1] = _tmpboard[3, 1];
            _tmpboard[1, 2] = _tmpboard[3, 2];
            _tmpboard[1, 3] = _tmpboard[3, 3];

            _tmpboard[3, 1] = tl;
            _tmpboard[3, 2] = tc;
            _tmpboard[3, 3] = tr;
            update();
        }

        private void BtnRotate_Click(object sender, EventArgs e)
        {
            var newboard = new int[5, 5];

            const int newstart = 0;
            const int newInc = 1;

            int newx = newstart;
            int newy = newstart;
            for (int x = 0; x <= 4; x++)
            {
                newx = newstart;
                for (int y = 4; y >= 0; y--)
                {
                    newboard[newx, newy] = tmpboard[x, y];
                    newx += newInc;
                }
                newy += newInc;
            }

            _tmpboard = newboard;
            update();

        }
        private static int RotateCcw(int[,] arr, int x, int y)
        {
            if (x < 0 || y < 0) { throw new ArgumentOutOfRangeException(); }
            else if (x == 1 && y == 1) { x = 3; y = 1; }
            else if (x == 3 && y == 1) { x = 3; y = 3; }
            else if (x == 3 && y == 3) { x = 1; y = 3; }
            else if (x == 1 && y == 3) { x = 1; y = 1; }

            else if (x == 2 && y == 1) { x = 3; y = 3; }
            else if (x == 3 && y == 3) { x = 2; y = 3; }
            else if (x == 2 && y == 3) { x = 1; y = 3; }
            else if (x == 1 && y == 3) { x = 2; y = 1; }

            return arr[x, y];
        }

    }


    public static class Extensions
    {
        public static int ToInt(this CheckBox val)
        {
            return val.Checked.ToInt();
        }
        public static bool ToBool(this int val)
        {
            return val == 0 ? false : true;
        }

        public static int ToInt(this bool val)
        {

            return val ? 1 : 0;
        }


    }
}
