using NeltharionRPGGame.Data;
using NeltharionRPGGame.Interfaces;
using NeltharionRPGGame.Structure.Creatures;

namespace NeltharionRPGGame.Structure.Spells
{
    public abstract class DefensiveSpell : Spell, ITimeoutable
    {
        private int currentTimeout;

        protected DefensiveSpell(int x, int y, int sizeX,
            int sizeY, Character caster, SpellType spellType,
            SpriteType spriteType, int defenseBonus, int healthBonus,
            int movementSpeedBonus, int timeout) 
            : base(x, y, sizeX, sizeY, caster, spellType, spriteType)
        {
            this.DefenseBonus = defenseBonus;
            this.HealthBonus = healthBonus;
            this.MovementSpeedBonus = movementSpeedBonus;
            this.MaximumTimeout = timeout;
        }

        public int DefenseBonus { get; set; }

        public int HealthBonus { get; set; }

        public int MovementSpeedBonus { get; set; }

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
