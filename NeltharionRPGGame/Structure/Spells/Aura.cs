using NeltharionRPGGame.Interfaces;
using NeltharionRPGGame.Structure.Creatures;

namespace NeltharionRPGGame.Structure.Spells
{
    public abstract class Aura : DefensiveSpell, IAreaEffect
    {
        protected Aura(int x, int y, int sizeX,
            int sizeY, Character caster, SpellType spellType,
            SpriteType spriteType, int defenseBonus, int healthBonus,
            int movementSpeedBonus, int range) 
            : base(x, y, sizeX, sizeY, caster, spellType, spriteType, defenseBonus, healthBonus, movementSpeedBonus)
        {
            this.AreaOfEffect = range;
        }

        public int AreaOfEffect { get; set; }
    }
}
