using NeltharionRPGGame.Data;

namespace NeltharionRPGGame.Structure.Items
{
    class TowerShield : Item
    {
        public const SpriteType ShieldSpriteType = SpriteType.TowerShield;

        public TowerShield(int x, int y)
            : base(x, y, ShieldSpriteType)
        {
        }
    }
}
