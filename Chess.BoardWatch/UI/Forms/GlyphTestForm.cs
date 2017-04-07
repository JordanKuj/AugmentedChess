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
using Chess.BoardWatch.Tools;

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
            _tmpboard = PieceConstants.Rotate(_tmpboard, RotateType.cw);
            update();
        }

        private void btnRotateCcw_Click(object sender, EventArgs e)
        {
            _tmpboard = PieceConstants.Rotate(_tmpboard, RotateType.ccw);
            update();
        }
    }


   
}
