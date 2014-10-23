using NeltharionRPGGame.Data;

namespace NeltharionRPGGame.Structure.Items.Weapons
{
    class TowerShield : Weapon
    {
        public const SpriteType ShieldSpriteType = SpriteType.TowerShield;

        public TowerShield(int x, int y)
            : base(x, y, ShieldSpriteType)
        {
        }

        public override int ReturnBonusEffect()
        {
            throw new System.NotImplementedException();
        }
    }
}
