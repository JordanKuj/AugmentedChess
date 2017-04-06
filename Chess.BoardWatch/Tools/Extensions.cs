using System;
using System.Collections.Generic;
using AForge.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Chess.BoardWatch.Tools
{


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
        public static Point Center(this Rectangle r)
        {
            var x = (r.Width / 2f) + r.Location.X;
            var y = (r.Height / 2f) + r.Location.Y;
            return new Point((int)x, (int)y);
        }


    }
}
