using NeltharionRPGGame.Data;

namespace NeltharionRPGGame.Structure.Creatures
{
    class Viking : Character
    {
        public const int VikingSizeX = 130;
        public const int VikingSizeY = 130;
        public const int VikingHealthPoints = 500;
        public const int VikingDefensePoints = 70;
        public const int VikingAttackPoints = 120;
        public const int VikingMovementSpeed = 12;
        public const int VikingAttackRange = 40;
        public const SpriteType VikingSpriteType = SpriteType.VikingRight;

        public Viking(int x, int y, Item[] inventory)
            : base(x, y, VikingSizeX, VikingSizeY, VikingSpriteType, VikingHealthPoints, VikingDefensePoints,
            VikingAttackPoints, VikingMovementSpeed, VikingAttackRange, inventory)
        {
            base.SightDirection = SightDirection.Right;
        }

        protected override void UpdateSpriteDirection()
        {
            if (this.SightDirection == SightDirection.Left)
            {
                this.SpriteType = SpriteType.VikingLeft;
            }
            else
            {
                this.SpriteType = SpriteType.VikingRight;
            }
        }
    }
}
