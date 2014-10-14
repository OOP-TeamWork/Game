using System;
using System.Windows.Forms;

namespace NeltharionRPGGame.Structure
{
    public abstract class Character : Creature
    {
        private Weapon[] inventory = new Weapon[3];

        protected Character(int x, int y, int sizeX, int sizeY,
            SpriteType spriteType, int healthPoints, int defensePoints,
            int attackPoints, int movementSpeed, int attackRange)
            : base(x, y, sizeX, sizeY, spriteType, healthPoints,
            defensePoints, attackPoints, movementSpeed, attackRange)
        {
        }

        public override void Move()
        {
            Timer asd = new Timer();
            asd.Interval = 30;
            asd.Tick += TakeASingleStepToDestination;
            asd.Start();
        }

        private void TakeASingleStepToDestination(object obj, EventArgs e)
        {
            if (this.X <= this.DirX - 30)
            {
                this.X++;
            }

            if (this.Y <= this.DirY - 15)
            {
                this.Y++;
            }

            if (this.X > this.DirX - 30)
            {
                this.X--;
            }

            if (this.Y > this.DirY - 15)
            {
                this.Y--;
            }
        }

        public override Weapon UseWeaponHeld()
        {
            throw new System.NotImplementedException();
        }
    }
}
