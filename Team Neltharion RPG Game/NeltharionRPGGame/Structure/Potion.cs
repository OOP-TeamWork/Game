using System;

namespace NeltharionRPGGame.Structure
{
    class Potion : Weapon
    {
        public const SpriteType WeaponSpriteType = SpriteType.Potion;

        public Potion(int x, int y)
            : base(x, y, WeaponSpriteType)
        {
        }
    }
}
