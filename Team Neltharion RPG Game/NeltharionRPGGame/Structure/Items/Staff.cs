using System;

namespace NeltharionRPGGame.Structure
{
    class Staff : Weapon
    {
        public const SpriteType WeaponSpriteType = SpriteType.Stuff;

        public Staff(int x, int y)
            : base(x, y, WeaponSpriteType)
        {
        }
    }
}
