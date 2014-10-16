using System;

namespace NeltharionRPGGame.Structure
{
    class Bow : Weapon
    {
        public const SpriteType WeaponSpriteType = SpriteType.Bow;

        public Bow(int x, int y)
            : base(x, y, WeaponSpriteType)
        {
        }
    }
}
