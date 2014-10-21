using System;
using NeltharionRPGGame.Controllers;
using NeltharionRPGGame.Structure.Items;

namespace NeltharionRPGGame.Structure.Creatures
{
    public abstract class Enemy : Creature
    {
        protected static Random RandomGenerator = new Random();

        public ArtificialIntelligence aiController;

        protected Enemy(int x, int y, int sizeX, int sizeY,
            SpriteType spriteType, int healthPoints, int defensePoints,
            int attackPoints, int movementSpeed, int attackRange, Item weaponHeld) 
            : base(x, y, sizeX, sizeY,
            spriteType, healthPoints, defensePoints,
            attackPoints, movementSpeed, attackRange, weaponHeld)
        {
            this.BonusWeaponHeld = this.ChooseRandomWeapon();
            this.aiController = new ArtificialIntelligence(this);
        }

        public Item BonusWeaponHeld { get; set; }

        public Item DropBonus()
        {
            return this.BonusWeaponHeld;
        }

        public override void Move()
        {
            int nextRandomXPosition;
            int nextRandomYPosition;
            this.aiController.DecideNextPosition(out nextRandomXPosition, out nextRandomYPosition);

            this.DirX = nextRandomXPosition;
            this.DirY = nextRandomYPosition;

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
