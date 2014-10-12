namespace NeltharionRPGGame.Structure
{
    public abstract class Character : Creature
    {
        private Weapon[] inventory = new Weapon[3];

        protected Character(int x, int y, int sizeX, int sizeY,
            SpriteType spriteType, int healthPoints, int defensePoints,
            int attackPoints, int movementSpeed, int attackRange)
            : base(x, y, sizeX, sizeY, spriteType, healthPoints,
            defensePoints, attackPoints, movementSpeed, attackRange)
        {
        }

        public override Weapon UseWeaponHeld()
        {
            throw new System.NotImplementedException();
        }
    }
}
