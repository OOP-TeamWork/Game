using NeltharionRPGGame.Data;
using NeltharionRPGGame.Structure.Creatures;

namespace NeltharionRPGGame.Structure.Spells
{
    public class ShiverArmor : SelfDefenceSpell
    {
        public const int ShiverArmorEffectSizeX = 10;
        public const int ShiverArmorEffectSizeY = 10;
        public const int ShiverArmorDefenseBonus = 70;
        public const int ShiverArmorHealthBonus = 0;
        public const int ShiverArmorMovementBonus = 0;
        public const int ShiverArmorTimeout = 2000;

        public ShiverArmor(Character caster)
            : base(caster.X, caster.Y, ShiverArmorEffectSizeX, ShiverArmorEffectSizeY,
            caster, SpellType.Shield, SpriteType.ShiverArmor, ShiverArmorDefenseBonus,
            ShiverArmorHealthBonus, ShiverArmorMovementBonus, ShiverArmorTimeout)
        {
        }

        public void CastOnSelf()
        {
            this.Caster.HealthPoints += this.HealthBonus;
            this.Caster.DefensePoints += this.DefenseBonus;
        }

        public void Debuff()
        {
            this.Caster.HealthPoints -= this.HealthBonus;
            this.Caster.DefensePoints -= this.DefenseBonus;
        }
    }
}
