using NeltharionRPGGame.Structure;

namespace NeltharionRPGGame.Interfaces
{
    public interface IRenderable : IGameObject
    {
        SpriteType SpriteType { get; set; }
    }
}
