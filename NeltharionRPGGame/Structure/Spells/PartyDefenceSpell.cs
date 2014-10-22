using System;
using System.Collections.Generic;
using System.Linq;
using NeltharionRPGGame.Data;
using NeltharionRPGGame.Interfaces;
using NeltharionRPGGame.Structure.Creatures;

namespace NeltharionRPGGame.Structure.Spells
{
    public abstract class PartyDefensiveSpell : DefensiveSpell, ITargetSpells
    {
        protected PartyDefensiveSpell(int x, int y, int sizeX, int sizeY,
            Character caster, SpellType spellType, SpriteType spriteType,
            int defenseBonus, int healthBonus, int movementSpeedBonus, int timeout) 
            : base(x, y, sizeX, sizeY, caster, spellType, spriteType,
            defenseBonus, healthBonus, movementSpeedBonus, timeout)
        {
        }

        public IEnumerable<Creature> GetTargets(IEnumerable<Creature> targetList)
        {
            var targets = targetList.Where(t => t.Team == this.Caster.Team).ToList();

            return targets;
        }
    }
}
