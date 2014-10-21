using System.Collections.Generic;
using System.Linq;
using NeltharionRPGGame.Structure.Creatures;

namespace NeltharionRPGGame.Structure.Spells
{
    public class BurningGround : Spell
    {
        public const int BurningGroundRange = 300;
        public const int BurningGroundSizeX = 74;
        public const int BurningGroundSizeY = 74;
        public const int BurningGroundTimeout = 850;
        public const int BurningGroundPower = 50;
        public const SpellType BurningGroundSpellType = SpellType.Damage;
        public const SpriteType BurningGroundSpriteType = SpriteType.BurningGround;

        public BurningGround(int x, int y, Character caster)
            : base(x, y, BurningGroundSizeX, BurningGroundSizeY, caster, BurningGroundPower, 
            BurningGroundRange, BurningGroundTimeout, BurningGroundSpellType, BurningGroundSpriteType)
        {
        }

        public override IEnumerable<Creature> GetTargets(IEnumerable<Creature> targetList)
        {
            var targets = targetList.ToList();

            return targets; 
        }
    }
}
