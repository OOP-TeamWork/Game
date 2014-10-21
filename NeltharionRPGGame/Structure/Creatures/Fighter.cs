namespace NeltharionRPGGame.Structure.Creatures
{
    class Fighter : Enemy
    {
        public const int FighterSizeX = 130;
        public const int FighterSizeY = 130;
        public const int FighterHealthPoints = 300;
        public const int FighterDefensePoints = 50;
        public const int FighterAttackPoints = 150;
        public const int FighterMovementSpeed = 1;
        public const int FighterAttackRange = 10;
        public const SpriteType FighterSpriteType = SpriteType.FighterRight;

        public Fighter(int x, int y)
            : base(x, y, FighterSizeX, FighterSizeY, FighterSpriteType,
            FighterHealthPoints, FighterDefensePoints, FighterAttackPoints, FighterMovementSpeed,
            FighterAttackRange, new Sword(0, 0))
        {
        }

        protected override void UpdateSpriteDirection()
        {
            if (this.SightDirection == SightDirection.Left)
            {
                this.SpriteType = SpriteType.FighterLeft;
            }
            else
            {
                this.SpriteType = SpriteType.FighterRight;
            }
        }
    }
}
