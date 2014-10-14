using System;
using NeltharionRPGGame.Helper;
using NeltharionRPGGame.Interfaces;

namespace NeltharionRPGGame.Structure
{
    public abstract class Enemy : Creature, IArtificialIntelligence
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

        public new bool IsAlive
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
            int nextRandomXPosition = RandomGenerator.Next(-1, 2);
            int nextRandomYPosition = RandomGenerator.Next(-1, 2);

            if ((this.X + nextRandomXPosition) < (GlobalData.WindowWidth - this.SizeY) &&
                this.X + nextRandomXPosition > 0)
            {
                this.DirX = nextRandomXPosition;
            }
            else
            {
                this.DirX = 0;
            }

            if ((this.Y + nextRandomYPosition) < (GlobalData.WindowHeight - this.SizeX) &&
                this.Y + nextRandomYPosition > 0)
            {
                this.DirY = nextRandomYPosition;
            }
            else
            {
                this.DirY = 0;
            }
            
            base.Move();
        }
    }
}
