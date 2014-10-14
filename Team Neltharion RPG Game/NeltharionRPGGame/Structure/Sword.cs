using System;

namespace NeltharionRPGGame.Structure
{
    class Sword : Weapon
    {
        public const SpriteType WeaponSpriteType = SpriteType.Sword;
        public const int SizeX = 30;
        public const int SizeY = 30;

        public Sword(int x, int y) 
            : base(x, y, SizeX, SizeY, WeaponSpriteType)
        {
        }
    }
}
