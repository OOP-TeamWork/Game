namespace NeltharionRPGGame.Structure
{
    public abstract class Item : GameObject
    {
        public const int SizeX = 40;
        public const int SizeY = 40;

        public Item(int x, int y, SpriteType weaponSpriteType)
            : base(x, y, SizeX, SizeY, weaponSpriteType)
        {

        }
    }
}
