using NeltharionRPGGame.Data;

namespace NeltharionRPGGame.Structure.Items.Weapons
{
    class Buckler : Weapon
    {
        private const int bonusDefenceEffect = 45;
        public const SpriteType shieldSpriteType = SpriteType.Buckler;

        public Buckler(int x, int y)
            : base(x, y, shieldSpriteType)
        {
        }

        public override int ReturnBonusEffect()
        {
            return bonusDefenceEffect;
        }
    }
}
