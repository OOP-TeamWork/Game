using NeltharionRPGGame.Interfaces;
using NeltharionRPGGame.Structure;

namespace NeltharionRPGGame
{
    public abstract class Unit : GameObject, IMovable, IRenderable, IUnit
    {
        private int currentHealthPoints;

        protected Unit(int x, int y, int sizeX, int sizeY,
            int healthPoints, int defensePoints, int attackPoints, int movementSpeed,
            int attackRange, SpriteType spriteType)
            : base(x, y, sizeX, sizeY)
        {
            this.MaximumHealthPoints = healthPoints;
            this.CurrentHealthPoints = this.MaximumHealthPoints;
            this.DefensePoints = defensePoints;
            this.AttackPoints = attackPoints;
            this.MovementSpeed = movementSpeed;
            this.AttackRange = attackRange;
            this.SpriteType = spriteType;
            this.IsAlive = true;
        }

        public SpriteType SpriteType { get; set; }

        public int MovementSpeed { get; set; }

        public int MaximumHealthPoints { get; set; }

        public int CurrentHealthPoints 
        {
            get
            {
                return this.currentHealthPoints;
            }
            set
            {
                this.currentHealthPoints = value;

                if (value <= 0)
                {
                    this.IsAlive = false;
                }
            }
        }

        public int DefensePoints { get; set; }

        public int AttackPoints { get; set; }

        public int AttackRange { get; set; }

        public bool IsAlive { get; set; }

        public int DirX { get; set; }

        public int DirY { get; set; }  

        public virtual void Move()
        {
            this.X += this.DirX * this.MovementSpeed;
            this.Y += this.DirY * this.MovementSpeed;
        }
    }
}
