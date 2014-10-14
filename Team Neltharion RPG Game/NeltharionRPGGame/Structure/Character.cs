using System;
using System.Windows.Forms;

namespace NeltharionRPGGame.Structure
{
    public abstract class Character : Creature
    {
        private Weapon[] inventory;

        protected Character(int x, int y, int sizeX, int sizeY,
            SpriteType spriteType, int healthPoints, int defensePoints,
            int attackPoints, int movementSpeed, int attackRange, Weapon[] inventory)
            : base(x, y, sizeX, sizeY, spriteType, healthPoints,
            defensePoints, attackPoints, movementSpeed, attackRange)
        {
            this.Inventory = inventory;
        }

        public void DropWeapon(int indexInventory)
        {
            if (inventory[indexInventory] != null)
            {
                inventory[indexInventory] = null;
            }
        }

        public Weapon[] Inventory
        {
            get { return this.inventory; }
            private set
            {
                this.inventory = value;
            }
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

        public void pickWeapon(Weapon weapon)
        {
            for (int i = 0; i < this.inventory.Length; i++)
            {
                if (this.inventory[i] == null)
                {
                    this.inventory[i] = weapon;
                    break;
                }
            }
        }
    }
}
