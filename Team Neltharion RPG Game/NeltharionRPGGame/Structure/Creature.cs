﻿using NeltharionRPGGame.Events;
using NeltharionRPGGame.Interfaces;
using NeltharionRPGGame.Structure;

namespace NeltharionRPGGame
{
    public abstract class Creature : GameObject, IMovable, IRenderable, ICreature
    {
        private const int AttackPointsCap = 5000;
        private const int DefensePointsCap = 5000;
        private const int MovementSpeedCap = 1000;
        private const int AttackRangeCap = 500;

        private SpriteType spriteType;
        private int maxHealthPoints;
        private int healthPoints;
        private int defensePoints;
        private int attackPoints;
        private int movementSpeed;
        private int attackRange;
        private bool isAlive;
        private Weapon weaponHeld;

        protected Creature(int x, int y, int sizeX, int sizeY,
            SpriteType spriteType, int healthPoints, int defensePoints,
            int attackPoints, int movementSpeed, int attackRange, Weapon weaponHeld = null)
            : base(x, y, sizeX, sizeY)
        {
            this.SpriteType = spriteType;
            this.MaximumHealthPoints = healthPoints;
            this.HealthPoints = healthPoints;
            this.DefensePoints = defensePoints;
            this.AttackPoints = attackPoints;
            this.MovementSpeed = movementSpeed;
            this.AttackRange = attackRange;
            this.IsAlive = true;
            this.WeaponHeld = weaponHeld;
        }

        public event WeaponDroppedEventHandler weaponDropped;

        public SpriteType SpriteType { get; set; }

        public int MaximumHealthPoints
        {
            get
            {
                return this.maxHealthPoints;
            }

            private set
            {
                checked
                {
                    this.maxHealthPoints = value;
                }
            }
        }

        public int HealthPoints 
        {
            get
            {
                return this.healthPoints;
            }

            set
            {
                this.healthPoints = value;

                if (this.healthPoints > this.maxHealthPoints)
                {
                    this.healthPoints = this.maxHealthPoints;
                }

                if (this.healthPoints <= 0)
                {
                    this.IsAlive = false;
                }            
            }
        }

        public int DefensePoints
        {
            get
            {
                return this.defensePoints;
            }

            set
            {
                if (value > DefensePointsCap)
                {
                    value = DefensePointsCap;
                }

                if (value <= 0)
                {
                    this.defensePoints = 0;
                }

                this.defensePoints = value;
            }
        }

        public int AttackPoints
        {
            get
            {
                return this.attackPoints;
            }

            set
            {
                if (value > AttackPointsCap)
                {
                    value = AttackPointsCap;
                }

                if (value <= 0)
                {
                    this.attackPoints = 0;
                }

                this.attackPoints = value;
            }
        }

        public int AttackRange
        {
            get
            {
                return this.attackRange;
            }

            set
            {
                if (value > AttackRangeCap)
                {
                    value = AttackRangeCap;
                }

                if (value <= 0)
                {
                    this.attackRange = 0;
                }

                this.attackRange = value;
            }
        }

        public int MovementSpeed
        {
            get
            {
                return this.movementSpeed;
            }

            set
            {
                if (value > MovementSpeedCap)
                {
                    value = MovementSpeedCap;
                }

                if (value <= 0)
                {
                    this.movementSpeed = 0;
                }

                this.movementSpeed = value;
            }
        }

        public bool IsAlive { get; set; }

        public Weapon WeaponHeld { get; set; }

        public int DirX { get; set; }

        public int DirY { get; set; }

        public void OnWeaponDropped()
        {
            if (weaponDropped != null)
            {
                WeaponDroppedEventArgs weaponDroppedEventArgs =
                    new WeaponDroppedEventArgs(this.WeaponHeld);
                weaponDropped(this, weaponDroppedEventArgs);
            }
        }

        public virtual void Move()
        {
            this.X += this.DirX * this.MovementSpeed;
            this.Y += this.DirY * this.MovementSpeed;
        }

        public virtual Weapon UseWeaponHeld()
        {
            return this.WeaponHeld;
        }

        // The value for this method is generated by
        // the Combat system
        public virtual void UpdateHealthPoints(int healthPointsEffect)
        {
            this.HealthPoints += healthPointsEffect;
        }

        public virtual void UpdateDefencePoints(int defencePoints)
        {
            this.DefensePoints += defencePoints;
        }
    }                              
}
                                   