using NeltharionRPGGame.Data;
using NeltharionRPGGame.Structure.Creatures;

namespace NeltharionRPGGame.Structure.Spells
{
    public class ChargedBolt : LightningSpell
    {
        public const int ChargedBoltSizeX = 20;
        public const int ChargedBoltSizeY = 20;
        public const int ChargedBoltAttackPower = 60;
        public const int ChargedBoltRange = 650;
        
        public ChargedBolt(int x, int y, Character caster)
            : base(x, y, ChargedBoltSizeX, ChargedBoltSizeY, caster,
            SpriteType.ChargedBolt, ChargedBoltAttackPower, ChargedBoltRange)
        {
        }
    }
}
