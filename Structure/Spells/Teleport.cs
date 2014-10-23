using NeltharionRPGGame.Data;
using NeltharionRPGGame.Structure.Creatures;

namespace NeltharionRPGGame.Structure.Spells
{
    public class Teleport : UtilitySpell
    {
        public Teleport(int destinationX, int destinationY, Character caster) 
            : base(0, 0, 0, 0, caster, SpriteType.None)
        {
            this.DestinationX = destinationX;
            this.DestinationY = destinationY;
        }

        public int DestinationX { get; set; }

        public int DestinationY { get; set; }

        public void PerformTeleportation()
        {
            this.Caster.X = DestinationX;
            this.Caster.Y = DestinationY;
        }
    }
}
