using NeltharionRPGGame.Data;
using NeltharionRPGGame.Interfaces;
using NeltharionRPGGame.Structure.Creatures;

namespace NeltharionRPGGame.Structure.Spells
{
    public class ColdSpell : OffensiveSpell, ISlowEffect, ITimeoutable
    {
        private int currentTimeout;

        public ColdSpell(int x, int y, int sizeX, int sizeY,
            Character caster, SpriteType spriteType,
            int power, int range, int slowEffect) 
            : base(x, y, sizeX, sizeY, caster, SpellType.Cold, spriteType, power, range)
        {
            this.SlowEffect = slowEffect;
        }

        public int SlowEffect { get; set; }

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
