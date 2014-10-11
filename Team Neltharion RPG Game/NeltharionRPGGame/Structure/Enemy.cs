using System;
using NeltharionRPGGame.Events;
using NeltharionRPGGame.Interfaces;

namespace NeltharionRPGGame.Structure
{
    public abstract class Enemy : Creature, IArtificialIntelligent
    {
        // This the weapon that player wins when enemy is dead
        private Weapon bonusWeaponHeald;
        public event BonusDroppedEventHandler weaponDropped;
        protected static Random RandomGenerator = new Random();

        protected Enemy(int x, int y, int sizeX, int sizeY,
            int healthPoints, int defensePoints, int attackPoints, int movementSpeed,
            int attackRange, SpriteType spriteType, Weapon bonusWeaponHeld) 
            : base(x, y, sizeX, sizeY,
            healthPoints, defensePoints, attackPoints, movementSpeed,
            attackRange, spriteType)
        {
            this.BonusWeaponHeld = bonusWeaponHeld;
        }

        public override bool IsAlive { get; set; }

        public Weapon BonusWeaponHeld
        {
            get
            {
                return this.bonusWeaponHeald;
            }

            private set
            {
                this.bonusWeaponHeald = value;
                if (!this.IsAlive)
                {
                    OnBonusDropped();
                }
            }
        }

        public abstract NextMoveDecision DecideNextMove();

        public override void Move()
        {
            this.DirX = RandomGenerator.Next(-1, 2);
            this.DirY = RandomGenerator.Next(-1, 2);
            base.Move();
        }

        public override void UpdateHealthPoints(int healthPointsEffect)
        {
            base.UpdateHealthPoints(healthPointsEffect);
        }

        public void OnBonusDropped()
        {
            if (weaponDropped != null)
            {
                BonusDroppedEventArgs bonusDroppedEventArgs =
                    new BonusDroppedEventArgs(this.BonusWeaponHeld);
                weaponDropped(this, bonusDroppedEventArgs);
            }
        }
    }
}
