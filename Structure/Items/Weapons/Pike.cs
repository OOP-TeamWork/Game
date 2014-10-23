using NeltharionRPGGame.Data;

namespace NeltharionRPGGame.Structure.Items.Weapons
{
    class Pike : Weapon
    {
        private const int bonusAttackEffect = 20;
        public const SpriteType WeaponSpriteType = SpriteType.Pike;

        public Pike(int x, int y)
            : base(x, y, WeaponSpriteType)
        {
        }

        public override int ReturnBonusEffect()
        {
            return bonusAttackEffect;
        }
    }
}
