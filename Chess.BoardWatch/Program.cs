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



        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GlyphTestForm());
        }


    }
}
