namespace NeltharionRPGGame.Structure
{
    public abstract class Weapon : GameObject
    {
        public const int SizeX = 30;
        public const int SizeY = 30;

        public Weapon(int x, int y, SpriteType weaponSpriteType)
            : base(x, y, SizeX, SizeY, weaponSpriteType)
        {

        }
    }
}
