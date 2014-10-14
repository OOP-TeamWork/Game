namespace NeltharionRPGGame.Interfaces
{
    public interface IDrawable
    {
        void AddObject(IRenderable renderableObject);

        void RemoveObject(IRenderable renderableObject);

        void RedrawObject(IRenderable renderableObject);
    }
}
