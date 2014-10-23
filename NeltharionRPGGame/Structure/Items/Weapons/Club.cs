using NeltharionRPGGame.Data;

namespace NeltharionRPGGame.Structure.Items.Weapons
{
    class Club : Weapon
    {
        public const SpriteType WeaponSpriteType = SpriteType.Club;

        public Club(int x, int y)
            : base(x, y, WeaponSpriteType)
        {
        }

        public override int ReturnBonusEffect()
        {
            throw new System.NotImplementedException();
        }
    }
}
