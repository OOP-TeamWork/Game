using NeltharionRPGGame.Data;

namespace NeltharionRPGGame.Structure.Items.Potions
{
    class AttackPotion : Potion
    {
        private const int bonusAttackEffect = 10;
        public const SpriteType attackPotion = SpriteType.AttackPotion;

        public AttackPotion(int x, int y)
            : base(x, y, attackPotion)
        {
        }

        public override int ReturnBonusEffect()
        {
            return bonusAttackEffect;
        }
    }
}