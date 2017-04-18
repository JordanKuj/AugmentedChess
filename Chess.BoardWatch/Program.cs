using Chess.BoardWatch.Tools;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chess.BoardWatch.UI.Forms;

namespace Chess.BoardWatch
{
    public static class Program
    {
        public static IKernel kernal;

        private static BoardWatchService _bws;



        public static void Main()
        {
            kernal = new StandardKernel(new Bindings());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _bws = kernal.Get<BoardWatchService>();
            Application.Run(kernal.Get<BoardView>());
            //Application.Run(new GlyphTestForm());
            Console.WriteLine("hi");
            _bws.Stop();
        }


    }
}
