using NeltharionRPGGame.Structure;

namespace NeltharionRPGGame.Interfaces
{
    public interface IDrawable
    {
        void AddObject(GameObject renderableObject);

        void RemoveObject(GameObject renderableObject);

        void RedrawObject(GameObject renderableObject);

        void DrawInventoryBar(Weapon[] weapons);

        void DrawHealthPointsBar(int maxHealthPoints, int healthPoints);
    }
}
