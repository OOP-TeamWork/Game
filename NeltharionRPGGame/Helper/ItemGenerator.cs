using NeltharionRPGGame.Structure.Items;

namespace NeltharionRPGGame.Helper
{
    using NeltharionRPGGame.Structure;
    using NeltharionRPGGame.Structure.Items.Potions;
    using System;

    public static class ItemGenerator
    {
        public static Item ChooseRandomWeapon(int x, int y)
        {
            const int weaponsCount = 12;
            Random rand = new Random();

            Item[] weapons = new Item[weaponsCount]
            {
                new Axe(x, y),
                new Bow(x, y),
                new Club(x, y),
                new Pike(x, y),
                new PoleArm(x, y),
                new HealthPotion(x, y), 
                new DefencePotion(x, y),
                new AttackPotion(x, y), 
                new Staff(x, y),
                new Sword(x, y),
                new Buckler(x, y),
                new TowerShield(x, y)
            };

            return weapons[rand.Next(0, weaponsCount)];
        }
    }
}
