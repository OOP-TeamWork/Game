namespace NeltharionRPGGame.Structure
{
    class Fighter : Enemy
    {
        public const int FighterSizeX = 70;
        public const int FighterSizeY = 70;
        public const int FighterHealthPoints = 300;
        public const int FighterDefensePoints = 50;
        public const int FighterAttackPoints = 150;
        public const int FighterMovementSpeed = 10;
        public const int FighterAttackRange = 250;
        public const SpriteType FighterSpriteType = SpriteType.Fighter;

        public Fighter(int x, int y)
            : base(x, y, FighterSizeX, FighterSizeY, FighterHealthPoints, FighterDefensePoints, FighterAttackPoints, FighterMovementSpeed,
            FighterAttackRange, FighterSpriteType, new Weapon(0, 0, 0, 0))
        {
        }

        public override void UseWeaponHeld()
        {
            // TODO Start fight
        }

        public override NextMoveDecision DecideNextMove()
        {
            // TODO Object that calculates distance between objects in the game
            int distanceToPlayer = 0;
            NextMoveDecision nextMove;

            if (distanceToPlayer <= 1)
            {
                nextMove = NextMoveDecision.UseWeaponHeld;
            }
            else
            {
                int randomDecision = RandomGenerator.Next(1, 4);
                switch (randomDecision)
                {
                    case 1:
                        nextMove = NextMoveDecision.Move;
                        break;
                    default:
                        nextMove = NextMoveDecision.None;
                        break;
                }
            }
            return nextMove;
        }
    }
}
