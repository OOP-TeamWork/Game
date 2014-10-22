using NeltharionRPGGame.Data;

namespace NeltharionRPGGame.Structure
{
    class Bow : Item
    {
        public const SpriteType WeaponSpriteType = SpriteType.Bow;

        public Bow(int x, int y)
            : base(x, y, WeaponSpriteType)
        {
        }
    }
}
