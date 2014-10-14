using System;

namespace NeltharionRPGGame.Structure
{
    class Sword : Item
    {
        public const SpriteType WeaponSpriteType = SpriteType.Sword;
        
        public Sword(int x, int y) 
            : base(x, y, WeaponSpriteType)
        {
        }
    }
}
