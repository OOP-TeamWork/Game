﻿using NeltharionRPGGame.Structure;

namespace NeltharionRPGGame
{
    public class Mage : Character
    {
        public const int MageSizeX = 130;
        public const int MageSizeY = 130;
        public const int MageHealthPoints = 300;
        public const int MageDefensePoints = 50;
        public const int MageAttackPoints = 150;
        public const int MageMovementSpeed = 10;
        public const int MageAttackRange = 250;
        public const SpriteType MageSpriteType = SpriteType.Mage;

        public Mage(int x, int y, Weapon[] inventory)
            : base(x, y, MageSizeX, MageSizeY, MageSpriteType, MageHealthPoints, MageDefensePoints, 
            MageAttackPoints, MageMovementSpeed, MageAttackRange, inventory)
        {
            base.SightDirection = SightDirection.Right;
        }
    }
}
