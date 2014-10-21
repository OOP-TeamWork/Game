namespace NeltharionRPGGame.Structure.Items.Potions
{
    class HealthPotion : Potion
    {
        private const int bonusHealthEffect = 20;
        public const SpriteType healthPotion = SpriteType.HealthPotion;

        public HealthPotion(int x, int y)
            : base(x, y, healthPotion)
        {
        }

        public override int ReturnBonusEffect()
        {
            return bonusHealthEffect;
        }
    }
}
