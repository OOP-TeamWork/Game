using System;
using NeltharionRPGGame.Structure;

namespace NeltharionRPGGame.Events
{
    public class WeaponDroppedEventArgs : EventArgs
    {
        private Weapon weaponDropped;

        public WeaponDroppedEventArgs(Weapon weapon)
        {
            this.WeaponDropped = weapon;
        }

        public Weapon WeaponDropped 

        {
            get
            {
                return this.weaponDropped;
            }

            set
            {
                this.weaponDropped = value;
            }
        }
    }
}