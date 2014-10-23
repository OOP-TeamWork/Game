using System;

namespace NeltharionRPGGame.CustomEvents
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
