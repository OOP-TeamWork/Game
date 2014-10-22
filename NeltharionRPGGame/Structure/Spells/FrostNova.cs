using NeltharionRPGGame.Data;
using NeltharionRPGGame.Structure.Creatures;

namespace NeltharionRPGGame.Structure.Spells
{
    public class FrostNova : ColdSpell
    {
        public const int FrostNovaSizeX = 20;
        public const int FrostNovaSizeY = 20;
        public const int FrostNovaAttackPower = 20;
        public const int FrostNovaRange = 450;
        public const int FrostNovaMaximumTimeout = 5;
        public const int FrostNovaSlowEffect = 300;

        public FrostNova(int x, int y, Character caster)
            : base(x, y, FrostNovaSizeX, FrostNovaSizeY, caster,
            SpriteType.FrostNova, FrostNovaAttackPower, FrostNovaRange, FrostNovaSlowEffect)
        {
        }
    }
}
