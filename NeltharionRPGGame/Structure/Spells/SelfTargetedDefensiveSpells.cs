using NeltharionRPGGame.Structure.Creatures;

namespace NeltharionRPGGame.Structure.Spells
{
    public abstract class SelfTargetedDefensiveSpells : DefensiveSpell
    {
        protected SelfTargetedDefensiveSpells(int x, int y, int sizeX,
            int sizeY, Character caster, SpellType spellType,
            SpriteType spriteType, int defenseBonus, int healthBonus, int movementSpeedBonus) 
            : base(x, y, sizeX, sizeY, caster, spellType, spriteType, defenseBonus, healthBonus, movementSpeedBonus)
        {
        }

        public virtual Creature GetTargetSelf()
        {
            return this.Caster;
        }
    }
}
