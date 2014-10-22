using System.Collections.Generic;
using System.Linq;
using NeltharionRPGGame.Interfaces;
using NeltharionRPGGame.Structure.Creatures;

namespace NeltharionRPGGame.Structure.Spells
{
    public abstract class DefensiveSpell : Spell, ITargetSpells
    {
        protected DefensiveSpell(int x, int y, int sizeX,
            int sizeY, Character caster, SpellType spellType,
            SpriteType spriteType, int defenseBonus, int healthBonus,
            int movementSpeedBonus) 
            : base(x, y, sizeX, sizeY, caster, spellType, spriteType)
        {
            this.DefenseBonus = defenseBonus;
            this.HealthBonus = healthBonus;
            this.MovementSpeedBonus = movementSpeedBonus;
        }

        public int DefenseBonus { get; set; }

        public int HealthBonus { get; set; }

        public int MovementSpeedBonus { get; set; }

        public virtual IEnumerable<Creature> GetTargets(IEnumerable<Creature> targetList)
        {
            var targets = targetList.Where(t => t.Team == this.Caster.Team).ToList();

            return targets;
        }
    }
}
