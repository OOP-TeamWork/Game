using NeltharionRPGGame.Data;

namespace NeltharionRPGGame.Structure
{
    class Club : Item
    {
        public const SpriteType WeaponSpriteType = SpriteType.Club;

        public Club(int x, int y)
            : base(x, y, WeaponSpriteType)
        {
        }
    }
}
