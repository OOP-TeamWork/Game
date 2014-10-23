using NeltharionRPGGame.Data;

namespace NeltharionRPGGame.Structure.Items.Weapons
{
    class Pike : Weapon
    {
        public const SpriteType WeaponSpriteType = SpriteType.Pike;

        public Pike(int x, int y)
            : base(x, y, WeaponSpriteType)
        {
        }

        public override int ReturnBonusEffect()
        {
            throw new System.NotImplementedException();
        }
    }
}
