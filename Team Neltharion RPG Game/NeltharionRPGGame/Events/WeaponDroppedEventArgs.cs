using System;
using NeltharionRPGGame.Structure;

namespace NeltharionRPGGame.Events
{
    public class WeaponDroppedEventArgs : EventArgs
    {
        private Item _itemDropped;

        public WeaponDroppedEventArgs(Item item)
        {
            this.ItemDropped = item;
        }

        public Item ItemDropped 

        {
            get
            {
                return this._itemDropped;
            }

            set
            {
                this._itemDropped = value;
            }
        }
    }
}