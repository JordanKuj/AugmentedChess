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
        public GlyphTestForm()
        {
            InitializeComponent();


            checkBox1.CheckedChanged += (sender, args) =>
            {
                tmpboard[1, 1] = checkBox1.Checked ? 1 : 0;
                update();
            };
            checkBox2.CheckedChanged += (sender, args) =>
            {
                tmpboard[1, 2] = checkBox2.Checked ? 1 : 0;
                update();
            };
            checkBox3.CheckedChanged += (sender, args) =>
            {
                tmpboard[1, 3] = checkBox3.Checked ? 1 : 0;
                update();
            };
            checkBox4.CheckedChanged += (sender, args) =>
            {
                tmpboard[2, 1] = checkBox4.Checked ? 1 : 0;
                update();
            };
            checkBox5.CheckedChanged += (sender, args) =>
            {
                tmpboard[2, 2] = checkBox5.Checked ? 1 : 0;
                update();
            };
            checkBox6.CheckedChanged += (sender, args) =>
            {
                tmpboard[2, 3] = checkBox6.Checked ? 1 : 0;
                update();
            };
            checkBox7.CheckedChanged += (sender, args) =>
            {
                tmpboard[3, 1] = checkBox7.Checked ? 1 : 0;
                update();
            };
            checkBox8.CheckedChanged += (sender, args) =>
            {
                tmpboard[3, 2] = checkBox8.Checked ? 1 : 0;
                update();
            };
            checkBox9.CheckedChanged += (sender, args) =>
            {
                tmpboard[3, 3] = checkBox9.Checked ? 1 : 0;
                update();
            };


        }

        private void update()
        {
            var res = PieceConstants.FindPieceType(tmpboard);
            label1.Text = res.ToString();
        }


        private int[,] tmpboard = new int[5, 5]
        {
            { 1, 1, 1, 1, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 1 },
        };

    }
}
