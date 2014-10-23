using System;
using NeltharionRPGGame.Controllers;
using NeltharionRPGGame.Data;
using NeltharionRPGGame.Helper;
using NeltharionRPGGame.Structure.Items.Weapons;

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
            attackPoints, movementSpeed, attackRange, Team.Scourge, weaponHeld)
        {
            this.aiController = new ArtificialIntelligence(this);
        }

        public Item BonusItemHeld { get; set; }

        public Item DropBonus()
        {
            return ItemGenerator.ChooseRandomWeapon(this.X, this.Y);
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

        protected override void UpdateSightDirection()
        {
            base.UpdateSightDirection();
        }
    }
}
