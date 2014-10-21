using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeltharionRPGGame.Controllers
{
    public class SpellCastEventArgs : EventArgs
    {
        public int CastX { get; set; }
        public int CastY { get; set; }

        public SpellCastEventArgs(int x, int y)
        {
            this.CastX = x;
            this.CastY = y;
        }
    }
}
