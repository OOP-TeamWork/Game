using NeltharionRPGGame.Data;
using NeltharionRPGGame.Structure.Creatures;

namespace NeltharionRPGGame.Structure.Spells
{
    public abstract class SelfDefenceSpell : DefensiveSpell
    {
        protected SelfDefenceSpell(int x, int y, int sizeX,
            int sizeY, Character caster, SpellType spellType,
            SpriteType spriteType, int defenseBonus, int healthBonus,
            int movementSpeedBonus, int timeout)
            : base(x, y, sizeX, sizeY, caster, spellType, spriteType,
            defenseBonus, healthBonus, movementSpeedBonus, timeout)
        {
        }

        public virtual Creature GetTargetSelf()
        {
            return this.Caster;
        }
    }
}
