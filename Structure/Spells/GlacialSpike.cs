using NeltharionRPGGame.Data;
using NeltharionRPGGame.Interfaces;
using NeltharionRPGGame.Structure.Creatures;

namespace NeltharionRPGGame.Structure.Spells
{
    public class GlacialSpike : ColdSpell, IAreaEffect
    {
        public const int GlacialSpikeSizeX = 30;
        public const int GlacialSpikeSizeY = 30;
        public const int GlacialSpikeAttackPower = 90;
        public const int GlacialSpikeRange = 335;
        public const int GlacialSpikeMaximumTimeout = 6;
        public const int GlacialSpikeSlowEffect = 400;
        public const int GlacialSpikeAreaOfEffect = 190;

        public GlacialSpike(int x, int y, Character caster)
            : base(x, y, GlacialSpikeSizeX, GlacialSpikeSizeY, caster,
            SpriteType.GlacialSpike, GlacialSpikeAttackPower, GlacialSpikeRange, GlacialSpikeSlowEffect)
        {
            this.AreaOfEffect = GlacialSpikeAreaOfEffect;
        }

        public int AreaOfEffect { get; set; }
    }
}
