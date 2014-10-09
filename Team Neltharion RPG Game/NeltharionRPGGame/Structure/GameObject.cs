using NeltharionRPGGame.Interfaces;

namespace NeltharionRPGGame
{
    public abstract class GameObject : IGameObject
    {
        protected GameObject(int x, int y, int sizeX, int sizeY)
        {
            this.X = x;
            this.Y = y;
            this.SizeX = sizeX;
            this.SizeY = sizeY;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int SizeX { get; set; }

        public int SizeY { get; set; }
    }
}
