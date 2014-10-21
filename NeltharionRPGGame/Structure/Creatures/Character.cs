using System;
using System.Windows.Forms;
using NeltharionRPGGame.Structure.Items.Potions;

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
            base.UpdateSpriteDirection();
        }

        private void TakeASingleStepToDestination(object obj, EventArgs e)
        {
            if (this.X <= this.DirX - this.SizeY / 2)
            {
                this.X++;
            }

            if (this.Y <= this.DirY - this.SizeX / 2)
            {
                this.Y++;
            }

            if (this.X > this.DirX - this.SizeY / 2)
            {
                this.X--;
            }

            if (this.Y > this.DirY - this.SizeX / 2)
            {
                this.Y--;
            }
        }

        public override void UseWeaponHeld()
        {
        }



        public bool TryPickAnItem(Item itemPicked)
        {
            bool itemPickedSuccessfully = false;

            if (itemPicked != null)
            {
                if (!(itemPicked is Potion))
                {
                    for (int weapon = 0; weapon < this.inventory.Length; weapon++)
                    {
                        if (this.inventory[weapon] == null)
                        {
                            this.inventory[weapon] = itemPicked;
                            itemPickedSuccessfully = true;
                            break;
                        }
                    }
                }
                else
                {
                    UsePotion(itemPicked as Potion);
                    itemPickedSuccessfully = true;
                }
            }

            return itemPickedSuccessfully;
        }

        private void UsePotion(Potion potion)
        {
            if (potion is HealthPotion)
            {
                base.HealthPoints += potion.ReturnBonusEffect();
            }
            else if (potion is DefencePotion)
            {
                base.DefensePoints += potion.ReturnBonusEffect();
            }
            else
            {
                base.AttackPoints += potion.ReturnBonusEffect();
            }
        }
    }
}
