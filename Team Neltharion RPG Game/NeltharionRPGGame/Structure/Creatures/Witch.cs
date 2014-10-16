using NeltharionRPGGame.Structure;

namespace NeltharionRPGGame
{
    public class Witch : Enemy
    {
        public const int WitchSizeX = 70;
        public const int WitchSizeY = 70;
        public const int WitchHealthPoints = 300;
        public const int WitchDefensePoints = 50;
        public const int WitchAttackPoints = 150;
        public const int WitchMovementSpeed = 10;
        public const int WitchAttackRange = 250;
        public const SpriteType WitchSpriteType = SpriteType.Witch;

        public Witch(int x, int y)
            : base(x, y, WitchSizeX, WitchSizeY, WitchSpriteType,
            WitchHealthPoints, WitchDefensePoints, WitchAttackPoints, WitchMovementSpeed,
            WitchAttackRange, new Sword(0, 0), new Sword(x, y))
        {
        }

        public override NextMoveDecision DecideNextMove()
        {
            int decision = RandomGenerator.Next(0, 4);
            switch (decision)
            {
                case 0:
                    return NextMoveDecision.UseWeaponHeld;
                case 1:
                    return NextMoveDecision.Move;
                default:
                    return NextMoveDecision.None;
            }
        }
    }
}
