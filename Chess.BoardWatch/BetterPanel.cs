using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess.BoardWatch
{
    public class BetterPanel:Panel
    {
        public BetterPanel()
        {
            this.SetStyle(
              System.Windows.Forms.ControlStyles.UserPaint |
              System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
              System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
              true);
        }
    }
}
