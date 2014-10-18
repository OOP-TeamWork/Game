namespace NeltharionRPGGame.Structure
{
    class PoleArm : Item
    {
        public const SpriteType WeaponSpriteType = SpriteType.PoleArm;

        public PoleArm(int x, int y)
            : base(x, y, WeaponSpriteType)
        {
        }
    }
}
