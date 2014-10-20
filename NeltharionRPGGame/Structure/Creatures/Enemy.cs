using System;
using NeltharionRPGGame.AI;
using NeltharionRPGGame.Helper;
using NeltharionRPGGame.Interfaces;
using NeltharionRPGGame.Structure.Items;

namespace NeltharionRPGGame.Structure
{
    public abstract class Enemy : Creature
    {
        protected static Random RandomGenerator = new Random();

        public ArtificialIntelligence aiController;

        private Item bonusWeaponHeld;

        protected Enemy(int x, int y, int sizeX, int sizeY,
            SpriteType spriteType, int healthPoints, int defensePoints,
            int attackPoints, int movementSpeed, int attackRange, Item weaponHeld, Item bonusWeaponHeld) 
            : base(x, y, sizeX, sizeY,
            spriteType, healthPoints, defensePoints,
            attackPoints, movementSpeed, attackRange, weaponHeld)
        {
            this.BonusWeaponHeld = bonusWeaponHeld;
            this.aiController = new ArtificialIntelligence(this);
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

        public Item BonusWeaponHeld
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

        public Item DropBonus()
        {
            return this.bonusWeaponHeld;
        }

        public override void Move()
        {
            int nextRandomXPosition = 0;
            int nextRandomYPosition = 0;
            this.aiController.DecideNextPosition(out nextRandomXPosition, out nextRandomYPosition);
            this.DirX = nextRandomXPosition;
            this.DirY = nextRandomYPosition;
            //if ((this.X + nextRandomXPosition) < (GlobalData.WindowWidth - this.SizeY) &&
            //    this.X + nextRandomXPosition > 0)
            //{
            //    this.DirX = nextRandomXPosition;
            //}
            //else
            //{
            //    this.DirX = 0;
            //}

            //if ((this.Y + nextRandomYPosition) < (GlobalData.WindowHeight - this.SizeX) &&
            //    this.Y + nextRandomYPosition > 0)
            //{
            //    this.DirY = nextRandomYPosition;
            //}
            //else
            //{
            //    this.DirY = 0;
            //}
            
            base.Move();
        }

        public Item ChooseRandomWeapon()
        {
            const int weaponsCount = 10;
            Random rand = new Random();

            Item[] weapons = new Item[weaponsCount]
            {
                new Axe(this.X, this.Y),
                new Bow(this.X, this.Y),
                new Club(this.X, this.Y),
                new Pike(this.X, this.Y),
                new PoleArm(this.X, this.Y),
                new Potion(this.X, this.Y),
                new Staff(this.X, this.Y),
                new Sword(this.X, this.Y),
                new Buckler(this.X, this.Y),
                new TowerShield(this.X, this.Y)
            };

            return weapons[rand.Next(0, weaponsCount)];
        }
    }
}
