using System;
using NeltharionRPGGame.Data;

namespace NeltharionRPGGame.Structure
{
    class Staff : Item
    {
        public const SpriteType WeaponSpriteType = SpriteType.Stuff;

        public Staff(int x, int y)
            : base(x, y, WeaponSpriteType)
        {
        }
    }
}
