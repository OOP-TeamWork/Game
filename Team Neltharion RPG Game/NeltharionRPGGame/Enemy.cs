namespace NeltharionRPGGame
{
    using NeltharionRPGGame.Structure;

    public abstract class Enemy : Creature
    {
        public Enemy(int x, int y, int sizeX, int sizeY,
            int healthPoints, int defensePoints, int attackPoints, int movementSpeed,
            int attackRange, SpriteType spriteType) 
            : base(x, y, sizeX, sizeY, healthPoints, defensePoints, attackPoints,
            movementSpeed, attackRange, spriteType)
        {
        }
    }
}
