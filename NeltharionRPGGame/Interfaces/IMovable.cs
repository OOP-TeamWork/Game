namespace NeltharionRPGGame
{
    public interface IMovable
    {
        int MovementSpeed { get; set; }

        int DirX { get; set; }

        int DirY { get; set; }

        void Move();
    }
}
