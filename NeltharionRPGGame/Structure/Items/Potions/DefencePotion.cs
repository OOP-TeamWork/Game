namespace NeltharionRPGGame.Structure.Items.Potions
{
    class DefencePotion : Potion
    {
        private const int bonusDefenceEffect = 5;
        public const SpriteType defensePotion = SpriteType.DefensePotion;

        public DefencePotion(int x, int y)
            : base(x, y, defensePotion)
        {
        }

        public override int ReturnBonusEffect()
        {
            return bonusDefenceEffect;
        }
    }
}