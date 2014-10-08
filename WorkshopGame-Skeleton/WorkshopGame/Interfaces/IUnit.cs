namespace WorkshopGame.Interfaces
{
    public interface IUnit : IGameObject
    {
        int CurrentHealthPoints { get; set; }

        int MaximumHealthPoints { get; set; }

        int DefensePoints { get; set; }

        int AttackPoints { get; set; }
    }
}
