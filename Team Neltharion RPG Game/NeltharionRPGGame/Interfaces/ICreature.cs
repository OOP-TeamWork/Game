namespace NeltharionRPGGame.Interfaces
{
    public interface ICreature : IGameObject
    {
        int HealthPoints { get; set; }

        int MaximumHealthPoints { get; set; }

        int DefensePoints { get; set; }

        int AttackPoints { get; set; }
    }
}
