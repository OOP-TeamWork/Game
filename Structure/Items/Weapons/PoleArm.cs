using NeltharionRPGGame.Data;

namespace NeltharionRPGGame.Structure.Items.Weapons
{
    class PoleArm : Weapon
    {
        private const int bonusAttackEffect = 20;
        public const SpriteType WeaponSpriteType = SpriteType.PoleArm;

        public PoleArm(int x, int y)
            : base(x, y, WeaponSpriteType)
        {
        }

        public override int ReturnBonusEffect()
        {
            return bonusAttackEffect;
        }
    }
}
