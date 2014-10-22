using NeltharionRPGGame.Structure.Creatures;

namespace NeltharionRPGGame.Structure.Spells
{
    public abstract class UtilitySpell : Spell
    {
        protected UtilitySpell(int x, int y, int sizeX,
            int sizeY, Character caster, SpellType spellType, SpriteType spriteType) 
            : base(x, y, sizeX, sizeY, caster, spellType, spriteType)
        {
        }
    }
}
