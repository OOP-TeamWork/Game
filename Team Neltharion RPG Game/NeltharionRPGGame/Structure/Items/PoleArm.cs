namespace NeltharionRPGGame.Structure
{
    class PoleArm : Weapon
    {
        public const SpriteType WeaponSpriteType = SpriteType.PoleArm;

        public PoleArm(int x, int y)
            : base(x, y, WeaponSpriteType)
        {
        }
    }
}
