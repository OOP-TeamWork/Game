using NeltharionRPGGame.Data;
using NeltharionRPGGame.Interfaces;
using NeltharionRPGGame.Structure.Creatures;

namespace NeltharionRPGGame.Structure.Spells
{
    public abstract class Aura : PartyDefensiveSpell, IAreaEffect
    {
        protected Aura(int x, int y, int sizeX,
            int sizeY, Character caster, SpellType spellType,
            SpriteType spriteType, int defenseBonus, int healthBonus,
            int movementSpeedBonus, int areaEffect, int timeout) 
            : base(x, y, sizeX, sizeY, caster, spellType, spriteType,
            defenseBonus, healthBonus, movementSpeedBonus, timeout)
        {
            this.AreaOfEffect = areaEffect;
        }

        public int AreaOfEffect { get; set; }
    }
}
