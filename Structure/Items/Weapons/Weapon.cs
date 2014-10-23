namespace NeltharionRPGGame.Structure.Items.Weapons
{
    using System;
    using NeltharionRPGGame.Data;

    public abstract class Weapon : Item
    {
        protected Weapon(int x, int y, SpriteType weaponSpriteType) 
            : base(x, y, weaponSpriteType)
        {
        }

        public abstract int ReturnBonusEffect();
    }
}
