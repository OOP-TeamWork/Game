using NeltharionRPGGame.Data;

namespace NeltharionRPGGame.Structure.Creatures
{
    class Paladin : Character
    {
        public const int PaladinSizeX = 130;
        public const int PaladinSizeY = 130;
        public const int PaladinHealthPoints = 350;
        public const int PaladinDefensePoints = 100;
        public const int PaladinAttackPoints = 110;
        public const int PaladinMovementSpeed = 8;
        public const int PaladinAttackRange = 40;
        public const SpriteType PaladinSpriteType = SpriteType.PaladinRight;

        public Paladin(int x, int y, Item[] inventory)
            : base(x, y, PaladinSizeX, PaladinSizeY, PaladinSpriteType, PaladinHealthPoints, PaladinDefensePoints,
            PaladinAttackPoints, PaladinMovementSpeed, PaladinAttackRange, inventory)
        {
            base.SightDirection = SightDirection.Right;
        }

        protected override void UpdateSpriteDirection()
        {
            if (this.SightDirection == SightDirection.Left)
            {
                this.SpriteType = SpriteType.PaladinLeft;
            }
            else
            {
                this.SpriteType = SpriteType.PaladinRight;
            }
        }
    }
}
