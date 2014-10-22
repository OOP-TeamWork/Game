using NeltharionRPGGame.Interfaces;
using NeltharionRPGGame.Structure.Creatures;

namespace NeltharionRPGGame.Structure.Spells
{
    public class Fireball : FireSpell, IAreaEffect
    {
        public const int FireballSizeX = 30;
        public const int FireballSizeY = 30;
        public const int FireballAttackPower = 110;
        public const int FireballRange = 300;
        public const int FireballMaximumTimeout = 4;
        public const int FireballMaxAreaEffect = 100;

        public Fireball(int x, int y, Character caster)
            : base(x, y, FireballSizeX, FireballSizeY, caster, SpellType.Fire,
            SpriteType.Fireball, FireballMaximumTimeout, FireballAttackPower, FireballRange)
        {
            this.AreaOfEffect = FireballMaxAreaEffect;
        }

        public int AreaOfEffect { get; set; }
    }
}
