﻿using NeltharionRPGGame.Data;

namespace NeltharionRPGGame.Structure.Creatures
{
    public abstract class Creature : GameObject, IMovable
    {
        private const int AttackPointsCap = 5000;
        private const int DefensePointsCap = 5000;
        private const int MovementSpeedCap = 1000;
        private const int AttackRangeCap = 500;

        private int maxHealthPoints;
        private int healthPoints;
        private int defensePoints;
        private int attackPoints;
        private int movementSpeed;
        private int attackRange;
        private bool isAlive;
        private Item weaponHeld;
        private SightDirection sightDirection;

        protected Creature(int x, int y, int sizeX, int sizeY,
            SpriteType spriteType, int healthPoints, int defensePoints,
            int attackPoints, int movementSpeed, int attackRange, Team team, Item weaponHeld = null)
            : base(x, y, sizeX, sizeY, spriteType)
        {
            this.SpriteType = spriteType;
            this.MaximumHealthPoints = healthPoints;
            this.HealthPoints = healthPoints;
            this.DefensePoints = defensePoints;
            this.AttackPoints = attackPoints;
            this.MovementSpeed = movementSpeed;
            this.AttackRange = attackRange;
            this.IsAlive = true;
            this.Team = team;
            this.WeaponHeld = weaponHeld;
        }

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

        public Team Team { get; set; }

        public Item WeaponHeld { get; set; }

        public SightDirection SightDirection { get; set; }

        public int DirX { get; set; }

        public int DirY { get; set; }

        public virtual void Move()
        {
            UpdateSightDirection();
            UpdateSpriteDirection();

            this.X += this.DirX * this.MovementSpeed;
            this.Y += this.DirY * this.MovementSpeed;
        }

        public virtual void UseWeaponHeld()
        {
        }

        protected virtual void UpdateSightDirection()
        {
            if (this.DirX > this.X)
            {
                this.SightDirection = SightDirection.Right;
            }
            else
            {
                this.SightDirection = SightDirection.Left;
            }
        }

        protected abstract void UpdateSpriteDirection();
    }
}
                                   