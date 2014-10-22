using NeltharionRPGGame.Structure.Creatures;

namespace NeltharionRPGGame.Structure.Spells
{
    public class Firebolt : FireSpell
    {
        public const int FireboltSizeX = 20;
        public const int FireboltSizeY = 20;
        public const int FireboltAttackPower = 70;
        public const int FireboltRange = 400;
        public const int FireboltMaximumTimeout = 2;

        public Firebolt(int x, int y, Character caster)
            : base(x, y, FireboltSizeX, FireboltSizeY, caster, SpellType.Fire,
            SpriteType.Firebolt, FireboltMaximumTimeout, FireboltAttackPower, FireboltRange)
        {
        }
    }
}
