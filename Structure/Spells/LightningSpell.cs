using NeltharionRPGGame.Data;
using NeltharionRPGGame.Structure.Creatures;

namespace NeltharionRPGGame.Structure.Spells
{
    public class LightningSpell : OffensiveSpell
    {
        public LightningSpell(int x, int y, int sizeX, int sizeY,
            Character caster, SpriteType spriteType, int power, int range) 
            : base(x, y, sizeX, sizeY, caster, SpellType.Lightning, spriteType, power, range)
        {
        }
    }
}
