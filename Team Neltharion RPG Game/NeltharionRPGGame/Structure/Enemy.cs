using System;
using System.Windows.Forms;
using NeltharionRPGGame.Events;
using NeltharionRPGGame.Interfaces;
using NeltharionRPGGame.UI;

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
            int randomXPosition = RandomGenerator.Next(-1, 2);
            int randomYPosition = RandomGenerator.Next(-1, 2);
            Form active = GameWindow.ActiveForm;

            if ((this.X + randomXPosition) < active.Size.Width - this.SizeX &&
                this.X + randomXPosition > 0)
            {
                this.DirX += randomXPosition;
            }

            if ((this.Y + randomYPosition) < active.Size.Height - this.SizeY &&
                this.Y + randomYPosition > 0)
            {
                this.DirY += randomYPosition;
            }
            
            base.Move();
        }
    }
}
