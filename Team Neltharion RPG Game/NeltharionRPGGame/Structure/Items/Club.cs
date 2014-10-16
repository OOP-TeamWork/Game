namespace NeltharionRPGGame.Structure
{
    class Club : Weapon
    {
        public const SpriteType WeaponSpriteType = SpriteType.Club;

        public Club(int x, int y)
            : base(x, y, WeaponSpriteType)
        {
        }
    }
}
