using NeltharionRPGGame.Data;
using NeltharionRPGGame.Structure.Creatures;

namespace NeltharionRPGGame.Structure.Spells
{
    public class BurningGround : FireSpell
    {
        public const int BurningGroundRange = 300;
        public const int BurningGroundSizeX = 74;
        public const int BurningGroundSizeY = 74;
        public const int BurningGroundTimeout = 850;
        public const int BurningGroundPower = 50;

        public BurningGround(int x, int y, Character caster)
            : base(x, y, BurningGroundSizeX, BurningGroundSizeY,caster, SpriteType.BurningGround,
            BurningGroundTimeout, BurningGroundPower, BurningGroundRange)
        {
        }
    }
}
