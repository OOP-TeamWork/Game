using NeltharionRPGGame.Events;
using NeltharionRPGGame.Interfaces;
using NeltharionRPGGame.Structure;

namespace NeltharionRPGGame.Structure
{
    public abstract class Character : Creature, GameObject, IMovable, IRenderable, ICreature
    {
        private Weapon[] inventory = new Weapon[3];

        protected Character(int x, int y, int sizeX, int sizeY,
            int healthPoints, int defensePoints, int attackPoints, int movementSpeed,
            int attackRange, SpriteType spriteType)
            : base(x, y, sizeX, sizeY, healthPoints, defensePoints, attackPoints, movementSpeed, attackRange, spriteType)
        {

        }

        public override void UseWeaponHeld()
        {
            throw new System.NotImplementedException();
        }
    }
}
