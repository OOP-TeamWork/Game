using NeltharionRPGGame.Data;
using NeltharionRPGGame.Structure.Creatures;

namespace NeltharionRPGGame.Structure.Spells
{
    public class Icebolt : ColdSpell
    {
        public const int IceboltSizeX = 20;
        public const int IceboltSizeY = 20;
        public const int IceboltAttackPower = 50;
        public const int IceboltRange = 450;
        public const int IceboltMaximumTimeout = 3;
        public const int IceboltSlowEffect = 200;

        public Icebolt(int x, int y, Character caster)
            : base(x, y, IceboltSizeX, IceboltSizeY, caster,
            SpriteType.Meteor, IceboltAttackPower, IceboltRange, IceboltSlowEffect)
        {
        }
    }
}
