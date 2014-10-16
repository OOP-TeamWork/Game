using System;

namespace NeltharionRPGGame.Structure
{
    class Axe : Weapon
    {
        public const SpriteType WeaponSpriteType = SpriteType.Axe;

        public Axe(int x, int y)
            : base(x, y, WeaponSpriteType)
        {
        }
    }
}
