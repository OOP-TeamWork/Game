using NeltharionRPGGame.Data;

namespace NeltharionRPGGame.Structure
{
    class Axe : Item
    {
        public const SpriteType WeaponSpriteType = SpriteType.Axe;

        public Axe(int x, int y)
            : base(x, y, WeaponSpriteType)
        {
        }
    }
}
