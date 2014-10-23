using NeltharionRPGGame.Data;

namespace NeltharionRPGGame.Structure.Items.Weapons
{
    class Sword : Weapon
    {
        private const int bonusAttackEffect = 20;
        public const SpriteType WeaponSpriteType = SpriteType.Sword;
        
        public Sword(int x, int y) 
            : base(x, y, WeaponSpriteType)
        {
        }

        public override int ReturnBonusEffect()
        {
            return bonusAttackEffect;
        }
    }
}
