using System;

namespace NeltharionRPGGame.Structure
{
    class Stuff : Weapon
    {
        public const SpriteType WeaponSpriteType = SpriteType.Stuff;

        public Stuff(int x, int y)
            : base(x, y, WeaponSpriteType)
        {
        }
    }
}
