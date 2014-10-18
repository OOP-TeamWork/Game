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
                return base.IsAlive;
            }

            set
            {
                base.IsAlive = value;
            }
        }

        public Weapon BonusWeaponHeld
        {
            get
            {
                return this.bonusWeaponHeld;
            }

            set
            {
                this.bonusWeaponHeld = value;
            }
        }

        public Weapon DropBonus()
        {
            return this.bonusWeaponHeld;
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

        public Weapon ChooseRandomWeapon()
        {
            const int weaponsCount = 8;
            Random rand = new Random();

            Weapon[] weapons = new Weapon[weaponsCount]
            {
                new Axe(this.X, this.Y),
                new Bow(this.X, this.Y),
                new Club(this.X, this.Y),
                new Pike(this.X, this.Y),
                new PoleArm(this.X, this.Y),
                new Potion(this.X, this.Y),
                new Staff(this.X, this.Y),
                new Sword(this.X, this.Y)
            };

            return weapons[rand.Next(0, weaponsCount)];
        }
    }
}
