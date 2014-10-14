using NeltharionRPGGame.Interfaces;
using NeltharionRPGGame.Structure;

namespace NeltharionRPGGame
{
    public abstract class GameObject : IGameObject, IRenderable
    {
        protected GameObject(int x, int y, int sizeX, int sizeY, SpriteType sptiteType)
        {
            this.X = x;
            this.Y = y;
            this.SizeX = sizeX;
            this.SizeY = sizeY;
            this.SpriteType = sptiteType;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int SizeX { get; set; }

        public int SizeY { get; set; }

        public SpriteType SpriteType { get; set; }
    }
}
