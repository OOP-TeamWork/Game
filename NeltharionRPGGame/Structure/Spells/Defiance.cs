using NeltharionRPGGame.Data;
using NeltharionRPGGame.Structure.Creatures;

namespace NeltharionRPGGame.Structure.Spells
{
    public class Defiance : Aura
    {
        public const int DefianceAuraSizeX = 300;
        public const int DefianceAuraSizeY = 300;
        public const int DefianceAuraDefenseBonus = 100;
        public const int DefianceAuraHealthBonus = 0;
        public const int DefianceAuraEffectRange = 100;
        public const int DefianceAuraMovementBonus = 100;
        public const int DefianceAuraTimeout = 5000;

        public Defiance(Character caster)
            : base(caster.X, caster.Y, DefianceAuraSizeX, DefianceAuraSizeY,
            caster, SpellType.Aura, SpriteType.DefianceAura,
            DefianceAuraDefenseBonus, DefianceAuraHealthBonus,
            DefianceAuraMovementBonus, DefianceAuraEffectRange, DefianceAuraTimeout)
        {
        }
    }
}
