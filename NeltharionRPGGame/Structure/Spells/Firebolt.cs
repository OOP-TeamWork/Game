using NeltharionRPGGame.Data;
using NeltharionRPGGame.Structure.Creatures;

namespace NeltharionRPGGame.Structure.Spells
{
    public class Firebolt : FireSpell
    {
        public const int FireboltSizeX = 20;
        public const int FireboltSizeY = 20;
        public const int FireboltAttackPower = 70;
        public const int FireboltRange = 400;
        public const int FireboltMaximumTimeout = 1;

        public Firebolt(int x, int y, Character caster)
            : base(x, y, FireboltSizeX, FireboltSizeY, caster,
            SpriteType.Firebolt, FireboltMaximumTimeout, FireboltAttackPower, FireboltRange)
        {
        }
    }
}
