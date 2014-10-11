using System;
using NeltharionRPGGame.Structure;

namespace NeltharionRPGGame.Events
{
    public class BonusDroppedEventArgs : EventArgs
    {
        private Weapon bonusDropped;

        public BonusDroppedEventArgs(Weapon bonus)
        {
            this.BonusDropped = bonus;
        }

        public Weapon BonusDropped 

        {
            get
            {
                return this.bonusDropped;
            }

            set
            {
                this.bonusDropped = value;
            }
        }
    }
}