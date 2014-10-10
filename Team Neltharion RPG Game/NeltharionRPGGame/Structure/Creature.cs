﻿using System.Security.AccessControl;

namespace NeltharionRPGGame
{
    using NeltharionRPGGame.Interfaces;
    using NeltharionRPGGame.Structure;

    public abstract class Creature : GameObject, IMovable, IRenderable, ICreature
    {
        private SpriteType _spriteType;
        private int _maxHealthPoints;
        private int _healthPoints;
        private int _defensePoints;
        private int _attackPoints;
        private int _movementSpeed;
        private int _attackRange;
        private bool _isAlive;
        private Weapon _weaponHeld;

        protected Creature(int x, int y, int sizeX, int sizeY,
            int healthPoints, int defensePoints, int attackPoints, int movementSpeed,
            int attackRange, SpriteType spriteType)
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
        }

        public SpriteType SpriteType
        {
            get
            {
                return this._spriteType;
            }

            set
            {
                this._spriteType = value;
            }
        }

        public int MaximumHealthPoints
        {
            get
            {
                return this._maxHealthPoints;
            }

            set
            {
                this._maxHealthPoints = value;
            }
        }

        public int HealthPoints 
        {
            get
            {
                return this._healthPoints;
            }

            set
            {
                this._healthPoints = value;
                if (this._healthPoints > this._maxHealthPoints)
                {
                    this._healthPoints = this._maxHealthPoints;
                }
                if (this._healthPoints <= 0)
                {
                    this.IsAlive = false;
                }
            }
        }

        public int DefensePoints
        {
            get
            {
                return this._defensePoints;
            }

            set
            {
                this._defensePoints = value;
            }
        }

        public int AttackPoints
        {
            get
            {
                return this._attackPoints;
            }

            set
            {
                this._attackPoints = value;
            }
        }

        public int AttackRange
        {
            get
            {
                return this._attackRange;
            }

            set
            {
                this._attackRange = value;
            }
        }

        public int MovementSpeed
        {
            get
            {
                return this._movementSpeed;
            }

            set
            {
                this._movementSpeed = value;
            }
        }

        public bool IsAlive
        {
            get
            {
                return this._isAlive;
            }

            set
            {
                this._isAlive = value;
            }
        }

        public int DirX { get; set; }

        public int DirY { get; set; }  

        // Public Methods
        public virtual void Move()
        {
            this.X += this.DirX * this.MovementSpeed;
            this.Y += this.DirY * this.MovementSpeed;
        }

        // According to the weapon held creature can
        // either fight or cast a magic
        /// <example>
        ///public abstract void UseWeaponHeld()
        ///{
        ///    if (this._weaponHeld != null)
        ///    {
        ///        if (this._weaponHeld is Spell)
        ///        {
        ///            this.CastSpell();
        ///        }
        ///        if (this._weaponHeld is FightWeapon)
        ///        {
        ///            this.Fight();
        ///        }
        ///    }
        ///    else
        ///    {
        ///        throw new NotSelectedWeaponException(); Custom Exception
        ///    }
        ///    
        ///}
        /// </example>
        public abstract void UseWeaponHeld();

        // The value for this mehtod is generated by
        // the Combat system
        public virtual void ReactToAttack(int healthPointsEffect)
        {
            this.HealthPoints += healthPointsEffect;
        }
    }                              
}
                                   