using System.Collections.Generic;
using System.Linq;
using NeltharionRPGGame.Data;
using NeltharionRPGGame.Interfaces;
using NeltharionRPGGame.Structure.Creatures;

namespace NeltharionRPGGame.Structure.Spells
{
    public abstract class OffensiveSpell : Spell, IRanged, ITargetSpells
    {
        protected OffensiveSpell(int x, int y, int sizeX,
            int sizeY, Character caster, SpellType spellType,
            SpriteType spriteType, int power, int range) 
            : base(x, y, sizeX, sizeY, caster, spellType, spriteType)
        {
            this.Power = power;
            this.Range = range;
        }

        public int Power { get; set; }

        public int Range { get; set; }

        public virtual IEnumerable<Creature> GetTargets(IEnumerable<Creature> targetList)
        {
            var targets = targetList.Where(t => t.Team != this.Caster.Team).ToList();

            return targets;
        }
    }
}
