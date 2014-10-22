using NeltharionRPGGame.Data;

namespace NeltharionRPGGame.Structure.Creatures
{
    public class Witch : Enemy
    {
        public const int WitchSizeX = 130;
        public const int WitchSizeY = 130;
        public const int WitchHealthPoints = 300;
        public const int WitchDefensePoints = 50;
        public const int WitchAttackPoints = 150;
        public const int WitchMovementSpeed = 10;
        public const int WitchAttackRange = 20;
        public const SpriteType WitchSpriteType = SpriteType.WitchLeft;

        public Witch(int x, int y)
            : base(x, y, WitchSizeX, WitchSizeY, WitchSpriteType,
            WitchHealthPoints, WitchDefensePoints, WitchAttackPoints, WitchMovementSpeed,
            WitchAttackRange, new Sword(0, 0))
        {
        }

        protected override void UpdateSpriteDirection()
        {
            if (this.SightDirection == SightDirection.Left)
            {
                this.SpriteType = SpriteType.WitchLeft;
            }
            else
            {
                this.SpriteType = SpriteType.WitchRight;
            }
        }
    }
}
