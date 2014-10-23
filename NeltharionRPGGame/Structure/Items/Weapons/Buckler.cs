using NeltharionRPGGame.Data;

namespace NeltharionRPGGame.Structure.Items.Weapons
{
    class Buckler : Weapon
    {
        public const SpriteType shieldSpriteType = SpriteType.Buckler;

        public Buckler(int x, int y)
            : base(x, y, shieldSpriteType)
        {
        }

        public override int ReturnBonusEffect()
        {
            throw new System.NotImplementedException();
        }
    }
}
