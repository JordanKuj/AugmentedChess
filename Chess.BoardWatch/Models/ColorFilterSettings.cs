
using AForge.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BoardWatch
{
    public class ColorFilterSettings
    {

        public ColorFilterSettings() { }

        public ColorFilterSettings(byte r, byte g, byte b, short radius)
        {
            Red = r;
            Blue = b;
            Green = g;
            Radius = radius;
        }


        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
        public short Radius { get; set; }

        public RGB GetRgb { get { return new RGB(Red, Green, Blue); } }

    }
}
