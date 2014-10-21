﻿using System;
using NeltharionRPGGame.Interfaces;
using NeltharionRPGGame.Structure;
using NeltharionRPGGame.Structure.Creatures;

namespace NeltharionRPGGame.Controllers
{
    public class ArtificialIntelligence : IArtificialIntelligence
    {
        private Enemy enemyControled;

        public ArtificialIntelligence(Enemy enemy)
        {
            this.enemyControled = enemy;
        }

        public int PlayerPositionX { get; set; }

        public int PlayerPositionY { get; set; }

        public NextMoveDecision DecideNextMove()
        {
            bool isPlayerInRange = IsPlayerInRange();

            if (isPlayerInRange)
            {
                return NextMoveDecision.UseWeaponHeld;
            }
            else
            {
                return NextMoveDecision.Move;
            }
        }

        public void GetPlayerPosition(Character player)
        {
            this.PlayerPositionX = player.X;
            this.PlayerPositionY = player.Y;
        }

        public void DecideNextPosition(out int positionX, out int positionY)
        {
            positionX = 0;
            positionY = 0;

            int distanceToPlayerXAxe = PlayerPositionX - enemyControled.X;
            int distanceToPlayerYAxe = PlayerPositionY - enemyControled.Y;

            if (distanceToPlayerXAxe < 0) // Enemy - Right / Player - Left
            {
                positionX = -1;
            }
            else if (distanceToPlayerXAxe > 0)
            {
                positionX = 1;
            }

            if (distanceToPlayerYAxe > 0)
            {
                positionY = 1;
            }
            else if (distanceToPlayerYAxe < 0)
            {
                positionY = -1;
            }
        }

        private bool IsPlayerInRange()
        {
            int distanceToPlayerXAxe = Math.Abs(PlayerPositionX - enemyControled.X);
            int distanceToPlayerYAxe = Math.Abs(PlayerPositionY - enemyControled.Y);
            bool isInRange = distanceToPlayerXAxe <= enemyControled.AttackRange ||
                distanceToPlayerYAxe <= enemyControled.AttackRange;

            return isInRange;
        }
    }
}
