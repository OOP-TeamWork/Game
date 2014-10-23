using NeltharionRPGGame.Data;

namespace NeltharionRPGGame.Structure.Items.Weapons
{
    class Sword : Weapon
    {
        public const SpriteType WeaponSpriteType = SpriteType.Sword;
        
        public Sword(int x, int y) 
            : base(x, y, WeaponSpriteType)
        {
        }

        public override int ReturnBonusEffect()
        {
            throw new System.NotImplementedException();
        }
    }
}
