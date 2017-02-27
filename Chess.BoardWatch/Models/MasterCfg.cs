using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BoardWatch.Models
{
    public class MasterCfg
    {

        public MasterCfg()
        {
            RedFilter = new ColorFilterSettings(215, 30, 30, 100);
            GreenFilter = new ColorFilterSettings(30, 215, 30, 100);
            BlueFilter = new ColorFilterSettings(30, 30, 215, 100);
            MinFullness = .03f;
            MinBlobShapeRatio = .05f;
            MinBlobSize = 32;
            ThreshholdFilterValue = 40;
            Glypdivisions = 5;
        }




        public ColorFilterSettings RedFilter { get; set; }
        public ColorFilterSettings GreenFilter { get; set; }
        public ColorFilterSettings BlueFilter { get; set; }

        public float MinFullness { get; set; }
        public float MinBlobShapeRatio { get; set; }
        public int MinBlobSize { get; set; }
        public int ThreshholdFilterValue { get; set; }
        public int Glypdivisions { get; set; }



    }
}
