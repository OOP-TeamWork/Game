namespace NeltharionRPGGame.Interfaces
{
    public interface IDrawable
    {
        void AddObject(GameObject renderableObject);

        void RemoveObject(GameObject renderableObject);

        void RedrawObject(GameObject renderableObject);
    }
}
