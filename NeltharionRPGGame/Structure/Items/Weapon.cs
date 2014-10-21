namespace NeltharionRPGGame.Structure.Items
{
    using System;

    public abstract class Weapon : Item
    {
        public Weapon(int x, int y, SpriteType weaponSpriteType) 
            : base(x, y, weaponSpriteType)
        {
        }


    }
}
