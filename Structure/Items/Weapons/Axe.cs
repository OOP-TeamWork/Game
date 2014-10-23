using NeltharionRPGGame.Data;

namespace NeltharionRPGGame.Structure.Items.Weapons
{
    class Axe : Weapon
    {
        private const int bonusAttackEffect = 20;
        public const SpriteType WeaponSpriteType = SpriteType.Axe;

        public Axe(int x, int y)
            : base(x, y, WeaponSpriteType)
        {
        }

        public override int ReturnBonusEffect()
        {
            return bonusAttackEffect;
        }
    }
}
