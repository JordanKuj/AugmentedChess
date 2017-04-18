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
using Chess.BoardWatch.Tools;
using AForge.Imaging;
using Chess.BoardWatch.Factories;

namespace Chess.BoardWatch.UI.Forms
{
    public partial class BoardView : Form
    {
        private readonly BoardWatchService _bws;
        private readonly BoardTools _bt;
        private readonly IFactory<SettingsForm> _settingsFormFactory;
        private readonly IFactory<Form1> _form1Factory;
        public BoardView(BoardTools bt, BoardWatchService bws, IFactory<SettingsForm> settingsFormFactory, IFactory<Form1> form1Factory)
        {
            InitializeComponent();
            _bt = bt;
            _bws = bws;
            _bt.NewBoardState += BtOnNewBoardState;
            _settingsFormFactory = settingsFormFactory;
            _form1Factory = form1Factory;
        }

        private void BtOnNewBoardState(BoardState boardState, bool isvalid)
        {
            if (InvokeRequired)
            {
                this?.Invoke(new Action(() => BtOnNewBoardState(boardState, isvalid)));
                return;
            }
            BtnAccept.Enabled = isvalid;
            BtnAccept.BackColor = isvalid ? Color.PaleGreen : Color.PaleVioletRed;
            DrawBoard(_background, boardState);
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
            var b = _background?.Clone() as Bitmap;
            if (b != null)
                g.DrawImage(b, new Rectangle(0, 0, betterPanel1.Width, betterPanel1.Height));
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
                    var selectedImage = (System.Drawing.Image)GetImage(p);

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

        private void BoardView_Load(object sender, EventArgs e)
        {
            //_bws.NewBlueData += _bws_NewBlueData;
            //_bws.NewRedFrame += _bws_NewRedFrame;
            _bws.NewRawFrame += _bws_NewRawFrame;
        }

        private void _bws_NewRawFrame(UnmanagedImage obj)
        {
            _background = obj.ToManagedImage(true);
        }

        //private void _bws_NewRedFrame(ChannelData obj)
        //{
        //}

        //private void _bws_NewBlueData(ChannelData obj)
        //{
        //}
    }
}
