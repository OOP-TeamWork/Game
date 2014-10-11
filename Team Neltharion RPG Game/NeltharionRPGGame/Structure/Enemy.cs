using System;
using NeltharionRPGGame.Events;
using NeltharionRPGGame.Interfaces;

namespace NeltharionRPGGame.Structure
{
    public abstract class Enemy : Creature, IArtificialIntelligent
    {
        protected static Random RandomGenerator = new Random();

        private Weapon bonusWeaponHeld;

        protected Enemy(int x, int y, int sizeX, int sizeY,
            SpriteType spriteType, int healthPoints, int defensePoints,
            int attackPoints, int movementSpeed, int attackRange, Weapon weaponHeld, Weapon bonusWeaponHeld) 
            : base(x, y, sizeX, sizeY,
            spriteType, healthPoints, defensePoints,
            attackPoints, movementSpeed, attackRange, weaponHeld)
        {
            this.BonusWeaponHeld = bonusWeaponHeld;
        }

        public override bool IsAlive
        {
            get
            {
                return base.IsAlive; // Test this
            }

            set
            {
                base.IsAlive = value;
                if (!IsAlive)
                {
                    OnWeaponDropped();
                }
            }
        }

        public Weapon BonusWeaponHeld
        {
            get
            {
                return this.bonusWeaponHeld;
            }

            private set
            {
                this.bonusWeaponHeld = value;
            }
        }

        public abstract NextMoveDecision DecideNextMove();

        public override void Move()
        {
            this.DirX = RandomGenerator.Next(-1, 2);
            this.DirY = RandomGenerator.Next(-1, 2);
            base.Move();
        }
    }
}
