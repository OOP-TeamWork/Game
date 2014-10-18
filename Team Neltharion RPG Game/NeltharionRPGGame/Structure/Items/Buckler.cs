namespace NeltharionRPGGame.Structure.Items
{
    class Buckler : Item
    {
        public const SpriteType shieldSpriteType = SpriteType.Buckler;

        public Buckler(int x, int y)
            : base(x, y, shieldSpriteType)
        {
        }
    }
}
