﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NeltharionRPGGame.Data;
using NeltharionRPGGame.Structure.Items.Weapons;
using NeltharionRPGGame.Structure.Spells;
using NeltharionRPGGame.Structure.Items.Potions;

namespace NeltharionRPGGame.Structure.Creatures
{
    public abstract class Character : Creature
    {
        private Item[] inventory;

        protected Character(int x, int y, int sizeX, int sizeY,
            SpriteType spriteType, int healthPoints, int defensePoints,
            int attackPoints, int movementSpeed, int attackRange, Item[] inventory)
            : base(x, y, sizeX, sizeY, spriteType, healthPoints,
            defensePoints, attackPoints, movementSpeed, attackRange, Team.Alliance)
        {
            this.Inventory = inventory;
            Spells = new List<Spell>();
        }   

        List<Spell> Spells { get; set; }

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

        public void DropWeapon(int indexInventory)
        {
            inventory[indexInventory] = null;
        }

        public override void Move()
        {
            Timer asd = new Timer();
            asd.Interval = 30;
            asd.Tick += TakeASingleStepToDestination;
            asd.Start();

            base.UpdateSightDirection();   
            UpdateSpriteDirection();
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

                    if (itemPicked is Axe) base.DefensePoints += (itemPicked as Axe).ReturnBonusEffect();
                    else if (itemPicked is Bow) base.DefensePoints += (itemPicked as Bow).ReturnBonusEffect();
                    else if (itemPicked is Buckler) base.DefensePoints += (itemPicked as Buckler).ReturnBonusEffect();
                    else if (itemPicked is Club) base.DefensePoints += (itemPicked as Club).ReturnBonusEffect();
                    else if (itemPicked is Pike) base.DefensePoints += (itemPicked as Pike).ReturnBonusEffect();
                    else if (itemPicked is PoleArm) base.DefensePoints += (itemPicked as PoleArm).ReturnBonusEffect();
                    else if (itemPicked is Staff) base.DefensePoints += (itemPicked as Staff).ReturnBonusEffect();
                    else if (itemPicked is Sword) base.DefensePoints += (itemPicked as Sword).ReturnBonusEffect();
                    else if (itemPicked is TowerShield) base.DefensePoints += (itemPicked as TowerShield).ReturnBonusEffect();
                }
                else
                {
                    UsePotion(itemPicked as Potion);
                    itemPickedSuccessfully = true;
                }
            }

            return itemPickedSuccessfully;
        }

        public Spell CastSpell(int spellNumber, int mouseX, int mouseY)
        {
            {
                Spell spell = null;
                switch (spellNumber)
                {
                    case 0:
                        spell = new BurningGround(mouseX, mouseY, this);
                        break;
                    default:
                        break;
                }
                return spell;
            }
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
