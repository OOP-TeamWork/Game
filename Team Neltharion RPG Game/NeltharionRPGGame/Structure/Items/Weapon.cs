using System.Drawing;
namespace NeltharionRPGGame.Structure
{
    public abstract class Item : GameObject
    {
        public const int SizeX = 40;
        public const int SizeY = 40;

        protected Item(int x, int y, SpriteType weaponSpriteType)
            : base(x, y, SizeX, SizeY, weaponSpriteType)
        {
        }

        public Point TopLeftPoint
        {
            get
            {
                return new Point(this.X, this.Y);
            }
        }

        public Point TopRightPoint
        {
            get
            {
                return new Point(this.X + SizeX, this.Y);
            }
        }

        public Point BottomLeftPoint
        {
            get
            {
                return new Point(this.X, this.Y + SizeY);
            }
        }

        public Point BottomRightPoint
        {
            get
            {
                return new Point(this.X + SizeX, this.Y + SizeY);
            }
        }
    }
}
