using WorkshopGame.Structure;

namespace WorkshopGame.Interfaces
{
    public interface IRenderable : IGameObject
    {
        SpriteType SpriteType { get; set; }
    }
}
