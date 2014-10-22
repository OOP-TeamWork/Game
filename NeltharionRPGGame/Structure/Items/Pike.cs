using NeltharionRPGGame.Data;

namespace NeltharionRPGGame.Structure
{
    class Pike : Item
    {
        public const SpriteType WeaponSpriteType = SpriteType.Pike;

        public Pike(int x, int y)
            : base(x, y, WeaponSpriteType)
        {
        }
    }
}
