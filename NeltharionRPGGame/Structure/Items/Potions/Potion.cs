namespace NeltharionRPGGame.Structure.Items.Potions
{
    public abstract class Potion : Item
    {
        protected Potion(int x, int y, SpriteType weaponSpriteType)
            : base(x, y, weaponSpriteType)
        {
        }

        public abstract int ReturnBonusEffect();
    }
}