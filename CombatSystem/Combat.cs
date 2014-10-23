using System;
using NeltharionRPGGame.Structure.Creatures;

namespace NeltharionRPGGame.CombatSystem
{
    public class Combat
    {
        public bool CharacterInRange(Enemy enemy, Character player)
        {
            if (Math.Abs(player.X - enemy.X) < 1000 &&
                Math.Abs(player.Y - enemy.Y) < 1000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EnemyInRange(Enemy enemy, Character player)
        {
            int distanceToEnemyXAxe = Math.Abs(player.X - enemy.X);
            int distanceToEnemyYAxe = Math.Abs(player.Y - enemy.Y);
            if (distanceToEnemyXAxe < player.AttackRange &&
                distanceToEnemyYAxe < player.AttackRange)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PlayerAttacked(Enemy enemy, Character player)
        {
            int reducedDamage;
            if (CharacterInRange(enemy, player))
            {
                reducedDamage = enemy.AttackPoints - player.DefensePoints;
                player.HealthPoints -= reducedDamage;
            }
            else if(CharacterInRange(enemy, player))
            {
                player.HealthPoints -= enemy.AttackPoints;
            }
        }

        public void EnemyAttacked(Character player, Enemy enemy)
        {
            int reducedDamage;
            if (EnemyInRange(enemy, player))
            {
                reducedDamage = player.AttackPoints - enemy.DefensePoints;
                enemy.HealthPoints -= reducedDamage;
            }
            else if(EnemyInRange(enemy, player))
            {
                enemy.HealthPoints -= player.AttackPoints;
            }
        }
    }
}
