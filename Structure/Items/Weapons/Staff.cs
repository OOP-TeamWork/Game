using NeltharionRPGGame.Data;

namespace NeltharionRPGGame.Structure.Items.Weapons
{
    class Staff : Weapon
    {
        private const int bonusAttackEffect = 20;
        public const SpriteType WeaponSpriteType = SpriteType.Stuff;

        public Staff(int x, int y)
            : base(x, y, WeaponSpriteType)
        {
        }

        public override int ReturnBonusEffect()
        {
            return bonusAttackEffect;
        }
    }
}
