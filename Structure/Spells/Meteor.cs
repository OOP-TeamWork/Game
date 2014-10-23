using NeltharionRPGGame.Data;
using NeltharionRPGGame.Interfaces;
using NeltharionRPGGame.Structure.Creatures;

namespace NeltharionRPGGame.Structure.Spells
{
    public class Meteor : FireSpell, IAreaEffect
    {
        public const int MeteorSizeX = 30;
        public const int MeteorSizeY = 30;
        public const int MeteorAttackPower = 210;
        public const int MeteorRange = 275;
        public const int MeteorMaximumTimeout = 6;
        public const int MeteorMaxRangeEffect = 300;

        public Meteor(int x, int y, Character caster)
            : base(x, y, MeteorSizeX, MeteorSizeY, caster,
            SpriteType.Meteor, MeteorMaximumTimeout, MeteorAttackPower, MeteorRange)
        {
            this.AreaOfEffect = MeteorMaxRangeEffect;
        }

        public int AreaOfEffect { get; set; }
    }
}
