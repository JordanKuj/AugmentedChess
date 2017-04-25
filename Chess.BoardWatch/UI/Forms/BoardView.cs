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


        //private readonly LocalGameManager _lgm;
        public BoardView(BoardTools bt, BoardWatchService bws, IFactory<SettingsForm> settingsFormFactory, IFactory<Form1> form1Factory)
        {
            InitializeComponent();
            _bt = bt;
            _bws = bws;
            _bt.NewBoardState += BtOnNewBoardState;
            _bt.NewBoardStateAccepted += _bt_NewBoardStateAccepted;
            _settingsFormFactory = settingsFormFactory;
            _form1Factory = form1Factory;
        }
        private BoardState ValidState;
        private BoardState mainBoardToDraw;
        private IBoardState previousBoardToDraw => _bt.LastMove;
        private Bitmap _background;
        private bool validating;
        private bool validating2;
        private SettingsForm _settingsForm;

        private Stopwatch AcceptSw = new Stopwatch();
        private const int AcceptTimeout = 5000;

        private void _bt_NewBoardStateAccepted()
        {
            var count = _bt.States.Count - 1;
            LblMoveCount.Text = count.ToString();
            //LblPlayerTurn.Text = count % 2 == 0 ? "White" : "Black";
            LblPlayerTurn.Text = _bt.LastMove.Turn == Team.white ? Team.black.ToString() : Team.white.ToString();
            LblPlayerTurn.BackColor = (_bt.LastMove.Turn == Team.white) ? Color.Black : Color.White;
            LblPlayerTurn.ForeColor = (_bt.LastMove.Turn == Team.white) ? Color.White : Color.Black;
        }
        BoardState newestState;
        bool isNewestStateValid;
        private void BtOnNewBoardState(BoardState boardState, bool isvalid)
        {
            newestState = boardState;
            isNewestStateValid = isvalid;
        }

        public void DrawBoard(Bitmap background, BoardState board)
        {
            if (!validating && board != null)
            {
                _background = (Bitmap)background.Clone();
                mainBoardToDraw = board;
                betterPanel1.Invalidate();
            }
        }
        private void AcceptState()
        {
            timer1.Stop();
            _bt.SubmitNewState(ValidState);
            ValidState = null;
            AcceptSw.Reset();
        }

        public void DrawPreviousState()
        {
            if (!validating2)
            {
                betterPanel2.Invalidate();
            }
        }

        private static void DrawGrid(Graphics g, BetterPanel panel, double spaceWidth, double spaceHeight)
        {
            for (var x = 0; x < 9; x++)
            {
                var x1 = spaceWidth * x;
                var y1 = spaceHeight * x;
                g.DrawLine(Pens.Black, (int)x1, 0, (int)x1, panel.Height);
                g.DrawLine(Pens.Black, 0, (int)y1, panel.Width, (int)y1);
            }
        }
        private static void DrawGlyphIcons(Graphics g, IBoardState bs, double spaceWidth, double spaceHeight)
        {
            if (bs == null)
                return;

            foreach (var p in bs.Pieces)
            {
                var selectedImage = (System.Drawing.Image)GetImage(p);
                var rect = new Rectangle((int)(p.X * spaceWidth), (int)(p.Y * spaceHeight), (int)spaceWidth, (int)spaceHeight);
                g.DrawImage(selectedImage, rect);
            }
        }

        private void betterPanel1_Paint(object sender, PaintEventArgs e)
        {
            validating = true;
            betterPanel1.SuspendLayout();
            var g = e.Graphics;
            var width = (betterPanel1.Width - 1);
            var height = (betterPanel1.Height - 1);
            var spaceWidth = (width / 8.0);
            var spaceHeight = (height / 8.0);
            var b = _background?.Clone() as Bitmap;
            if (b != null)
                g.DrawImage(b, new Rectangle(0, 0, width, height));
            DrawGrid(g, betterPanel1, spaceWidth, spaceHeight);
            DrawGlyphIcons(g, mainBoardToDraw, spaceWidth, spaceHeight);
            betterPanel1.ResumeLayout();
            validating = false;
        }

        private void betterPanel2_Paint(object sender, PaintEventArgs e)
        {
            var panel = (BetterPanel)sender;
            validating2 = true;
            panel.SuspendLayout();
            var g = e.Graphics;

            var spaceWidth = ((panel.Width - 1) / 8.0);
            var spaceHeight = ((panel.Height - 1) / 8.0);
            DrawGrid(g, panel, spaceWidth, spaceHeight);
            DrawGlyphIcons(g, previousBoardToDraw, spaceWidth, spaceHeight);
            panel.ResumeLayout();
            validating2 = false;
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
        private void BtnSetRedMask_Click(object sender, EventArgs e)
        {
            if (_settingsForm != null)
            {
                _settingsForm.Dispose();
                _settingsForm = null;
            }
            if (_settingsForm == null)
                _settingsForm = _settingsFormFactory.GetInstance();
            _settingsForm.Show();
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ValidState != null)
            {
                if (!AcceptSw.IsRunning)
                    AcceptSw.Restart();
                if (AcceptSw.ElapsedMilliseconds >= AcceptTimeout)
                    AcceptState();

                BtnAccept.Text = $"Accept {((AcceptTimeout - AcceptSw.ElapsedMilliseconds) / 1000)}";
            }
            else
            {
                timer1.Stop();
                AcceptSw.Reset();
            }
        }

        private static Bitmap GetImage(IGlyphPiece p)
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

        private void BoardView_FormClosing(object sender, FormClosingEventArgs e)
        {
            _bt.NewBoardState -= BtOnNewBoardState;
            _bt.NewBoardStateAccepted -= _bt_NewBoardStateAccepted;
        }

        private void DisplayTimer_Tick(object sender, EventArgs e)
        {

            DrawPreviousState();

            var count = _bt.States.Count - 1;
            LblMoveCount.Text = count.ToString();
            //LblPlayerTurn.Text = count % 2 == 0 ? "White" : "Black";
            LblPlayerTurn.Text = _bt.LastMove.Turn == Team.white ? Team.black.ToString() : Team.white.ToString();
            LblPlayerTurn.BackColor = (_bt.LastMove.Turn == Team.white) ? Color.Black : Color.White;
            LblPlayerTurn.ForeColor = (_bt.LastMove.Turn == Team.white) ? Color.White : Color.Black;

            if (State.getDiff(_bt.LastMove.ToBoard(), newestState.ToBoard()))
            {
                BtnAccept.Text = "Please Make A Move";
                BtnAccept.BackColor = SystemColors.Control;
                BtnAccept.Enabled = false;
                DrawBoard(_background, newestState);
                return;
            }


            if (isNewestStateValid)
            {
                ValidState = newestState;
                timer1.Start();
            }
            else
            {
                BtnAccept.Text = "Please return board to previous state";
                ValidState = null;
                timer1.Stop();
            }
            BtnAccept.Enabled = isNewestStateValid;
            BtnAccept.BackColor = isNewestStateValid ? Color.PaleGreen : Color.PaleVioletRed;
            DrawBoard(_background, newestState);
        }

        private void BtnStartNewGame_Click(object sender, EventArgs e)
        {
            _bt.StartNewGame();
            ValidState = null;
            newestState = null;
            validating = false;
            validating2 = false;
            AcceptSw.Reset();
            mainBoardToDraw = null;
        }
    }
}
