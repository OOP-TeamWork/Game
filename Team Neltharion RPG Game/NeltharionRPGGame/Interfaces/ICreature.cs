using NeltharionRPGGame.Events;
using NeltharionRPGGame.Structure;

namespace NeltharionRPGGame.Interfaces
{
    public interface ICreature : IGameObject
    {
        int HealthPoints { get; }

        int MaximumHealthPoints { get; }

        int DefensePoints { get; set; }

        int AttackPoints { get; set; }

        event WeaponDroppedEventHandler weaponDropped;

        Weapon UseWeaponHeld();
    }
}
