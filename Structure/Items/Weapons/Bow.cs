using NeltharionRPGGame.Data;

namespace NeltharionRPGGame.Structure.Items.Weapons
{
    class Bow : Weapon
    {
        private const int bonusAttackEffect = 25;
        public const SpriteType WeaponSpriteType = SpriteType.Bow;

        public Bow(int x, int y)
            : base(x, y, WeaponSpriteType)
        {
        }

        public override int ReturnBonusEffect()
        {
            return bonusAttackEffect;
        }
    }
}
