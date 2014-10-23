using NeltharionRPGGame.Data;
using NeltharionRPGGame.Interfaces;
using NeltharionRPGGame.Structure.Creatures;

namespace NeltharionRPGGame.Structure.Spells
{
    public class FireSpell : OffensiveSpell, ITimeoutable
    {
        private int currentTimeout;

        public FireSpell(int x, int y, int sizeX, int sizeY,
            Character caster, SpriteType spriteType,
            int maximumTimeout, int power, int range) 
            : base(x, y, sizeX, sizeY, caster, SpellType.Fire, spriteType, power, range)
        {
            this.MaximumTimeout = maximumTimeout;
        }

        public int MaximumTimeout { get; set; }

        public int CurrentTimeout
        {
            get
            {
                return this.currentTimeout;
            }
            set
            {
                if (value >= this.MaximumTimeout)
                {
                    this.HasTimedOut = true;
                }

                this.currentTimeout = value;
            }
        }

        public bool HasTimedOut { get; set; }
    }
}
