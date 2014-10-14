namespace NeltharionRPGGame.Structure
{
    public abstract class Weapon : GameObject
    {
        public Weapon(int x, int y, int sizeX, int sizeY, SpriteType weaponSpriteType)
            : base(x, y, sizeX, sizeY, weaponSpriteType)
        {
        }
    }
}
