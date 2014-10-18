﻿using System;
using System.Windows.Forms;

namespace NeltharionRPGGame.Structure
{
    public abstract class Character : Creature
    {
        private Item[] inventory;

        protected Character(int x, int y, int sizeX, int sizeY,
            SpriteType spriteType, int healthPoints, int defensePoints,
            int attackPoints, int movementSpeed, int attackRange, Item[] inventory)
            : base(x, y, sizeX, sizeY, spriteType, healthPoints,
            defensePoints, attackPoints, movementSpeed, attackRange)
        {
            this.Inventory = inventory;
        }

        public void DropWeapon(int indexInventory)
        {
            inventory[indexInventory] = null;
        }

        public Item[] Inventory
        {
            get
            {
                return this.inventory;
            }

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

            base.UpdateSightDirection();
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

        public override void UseWeaponHeld()
        {
        }

        public bool TryPickAWeapon(Item weaponPicked)
        {
            bool weaponPickedSuccessfully = false;

            if (weaponPicked != null)
            {
                for (int weapon = 0; weapon < this.inventory.Length; weapon++)
                {
                    if (this.inventory[weapon] == null)
                    {
                        this.inventory[weapon] = weaponPicked;
                        weaponPickedSuccessfully = true;
                        break;
                    }
                }
            }

            return weaponPickedSuccessfully;
        }
    }
}
