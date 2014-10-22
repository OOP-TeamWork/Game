using NeltharionRPGGame.Data;
using NeltharionRPGGame.Structure.Creatures;

namespace NeltharionRPGGame.Structure.Spells
{
    public abstract class UtilitySpell : Spell
    {
        protected UtilitySpell(int x, int y, int sizeX,
            int sizeY, Character caster, SpriteType spriteType) 
            : base(x, y, sizeX, sizeY, caster, SpellType.Utility, spriteType)
        {
        }
    }
}
