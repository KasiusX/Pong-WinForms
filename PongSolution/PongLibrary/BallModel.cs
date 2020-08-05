using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace PongLibrary
{
    public class BallModel
    {
        public int WidthHeight { get; set; }
        public int BallSpeedSide { get; set; }
        public int BallSpeedHeight { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

    }
}
