namespace NeltharionRPGGame.Structure
{
    class Pike : Weapon
    {
        public const SpriteType WeaponSpriteType = SpriteType.Pike;

        public Pike(int x, int y)
            : base(x, y, WeaponSpriteType)
        {
        }
    }
}
