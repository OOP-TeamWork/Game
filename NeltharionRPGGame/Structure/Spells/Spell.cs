using System.Collections.Generic;
using NeltharionRPGGame.Interfaces;
using NeltharionRPGGame.Structure.Creatures;

namespace NeltharionRPGGame.Structure.Spells
{
    public abstract class Spell : GameObject, ITimeoutable, IRenderable
    {
        private int currentTimeout;

        protected Spell(int x, int y, int sizeX, int sizeY, 
            Character caster, int power, int range, int millisecTimeout, SpellType spellType, SpriteType spriteType)
            : base(x, y, sizeX, sizeY, spriteType)
        {
            this.Caster = caster;
            this.Power = power;
            this.Range = range;
            this.MaximumTimeout = millisecTimeout;
            this.currentTimeout = 0;
            this.HasTimedOut = false;
            this.SizeX = sizeX;
            this.SizeY = sizeY;
            this.SpellType = spellType;
            this.AddCoordinatesOffset();
        }

        public Character Caster { get; set; }

        public int Power { get; set; }

        public int Range { get; set; }

        public SpellType SpellType { get; set; }

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

        public abstract IEnumerable<Creature> GetTargets(IEnumerable<Creature> targetList);

        private void AddCoordinatesOffset()
        {
            this.X -= this.SizeX / 2;
            this.Y -= this.SizeY / 2;
        }
    }
}
