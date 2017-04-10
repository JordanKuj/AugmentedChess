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
using Chess.BoardWatch.Models;
using Chess.BoardWatch.Properties;
using ChessTest;

namespace Chess.BoardWatch.UI.Forms
{
    public partial class BoardView : Form
    {
        private readonly BoardTools _bt;
        public BoardView(BoardTools bt)
        {
            InitializeComponent();
            _bt = bt;
            _bt.NewBoardState += BtOnNewBoardState;
        }

        private void BtOnNewBoardState(BoardState boardState, bool isvalid)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => BtOnNewBoardState(boardState, isvalid)));
                return;
            }
            BtnAccept.Enabled = isvalid;
            BtnAccept.BackColor = isvalid ? Color.PaleGreen : Color.PaleVioletRed;
        }

        private List<GlyphPiece> pieces;
        private Bitmap _background;
        private bool validating;
        public void DrawBoard(Bitmap bacground, BoardState board)
        {
            if (!validating && board != null)
            {
                _background = (Bitmap)bacground.Clone();
                pieces = new List<GlyphPiece>(board.Pieces);
                betterPanel1.Invalidate();
            }

        }

        private void betterPanel1_Paint(object sender, PaintEventArgs e)
        {
            validating = true;
            betterPanel1.SuspendLayout();
            var g = e.Graphics;

            var spaceWidth = (betterPanel1.Width / 8);
            var spaceHeight = (betterPanel1.Height / 8);
            if (_background != null)
                g.DrawImage(_background, new Rectangle(0, 0, betterPanel1.Width, betterPanel1.Height));
            //g.FillRectangle(Brushes.White, 0, 0, betterPanel1.Width, betterPanel1.Height);
            for (var x = 0; x < 9; x++)
            {
                var x1 = spaceWidth * x;
                var y1 = spaceHeight * x;
                g.DrawLine(Pens.Black, x1, 0, x1, betterPanel1.Height);
                g.DrawLine(Pens.Blue, 0, y1, betterPanel1.Width, y1);
            }
            if (pieces != null)
            {
                foreach (var p in pieces)
                {
                    var selectedImage = (Image)GetImage(p);

                    var rect = new Rectangle(p.X * spaceWidth, p.Y * spaceHeight, spaceWidth, spaceHeight);
                    //Debug.Print($"x:{p.X} y:{p.Y} w:{rect.Height} h:{rect.Height}");
                    g.DrawImage(selectedImage, rect);
                }
            }





            betterPanel1.ResumeLayout();


            validating = false;
        }

        private Bitmap GetImage(GlyphPiece p)
        {
            switch (p.Type)
            {
                case PieceType.pawn:
                    return p.Team == Team.black ? Resources.black_pawn : Resources.white_pawn;
                case PieceType.bishop:
                    return p.Team == Team.black ? Resources.black_bishop : Resources.white_bishop;
                case PieceType.king:
                    return p.Team == Team.black ? Resources.black_king : Resources.white_king;
                case PieceType.knight:
                    return p.Team == Team.black ? Resources.black_knight : Resources.white_knight;
                case PieceType.queen:
                    return p.Team == Team.black ? Resources.black_queen : Resources.white_queen;
                case PieceType.rook:
                    return p.Team == Team.black ? Resources.black_rook : Resources.white_rook;
                case PieceType.Debug:
                    return p.Team == Team.black ? Resources.black_debug : Resources.white_debug;
                default:
                    return Resources.errorPiece;
            }
        }




    }
}
