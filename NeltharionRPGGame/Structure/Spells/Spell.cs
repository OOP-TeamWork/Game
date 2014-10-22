using System.Collections.Generic;
using NeltharionRPGGame.Interfaces;
using NeltharionRPGGame.Structure.Creatures;

namespace NeltharionRPGGame.Structure.Spells
{
    public abstract class Spell : GameObject
    {
        protected Spell(int x, int y, int sizeX, int sizeY, 
            Character caster, SpellType spellType, SpriteType spriteType)
            : base(x, y, sizeX, sizeY, spriteType)
        {
            this.Caster = caster;
            this.SizeX = sizeX;
            this.SizeY = sizeY;
            this.SpellType = spellType;
            this.AddCoordinatesOffset();
        }

        public Character Caster { get; set; }

        public SpellType SpellType { get; set; }

        private void AddCoordinatesOffset()
        {
            this.X -= this.SizeX / 2;
            this.Y -= this.SizeY / 2;
        }
    }
}
