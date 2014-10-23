using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using NeltharionRPGGame.Controllers;
using NeltharionRPGGame.CustomEvents;
using NeltharionRPGGame.CustomExceptions;
using NeltharionRPGGame.Data;
using NeltharionRPGGame.Interfaces;
using NeltharionRPGGame.Structure;
using NeltharionRPGGame.Structure.Creatures;
using NeltharionRPGGame.Structure.Spells;
using NeltharionRPGGame.UI;
using System.Drawing;
using NeltharionRPGGame.CombatSystem;

namespace NeltharionRPGGame.GameEngine
{
    public class Engine
    {
        private PaintBrush painter;
        private Combat combatSystem;

        public Character player; // Public modifier for test only
        private List<Creature> creaturesInWorld;
        private List<Item> newBonusesDroppedByEnemies;
        private List<Item> allBonusesDroppedByEnemies;
        private List<Spell> spellList;
        private int interval = GameWindow.RefreshInterval;
        private Enemy enemy;

        public event EndGameEventHandler endGame;

        public void InitializeWorld(IInputInterface controller, PaintBrush painter)
        {
            this.combatSystem = new Combat();
            this.painter = painter;
            InitializeVariables();
            SubscribeToUserInput(controller);
            InitializeCreatures();
            creaturesInWorld.ForEach(creature => this.painter.AddObject(creature));
            this.painter.DrawInventoryBar(player.Inventory);
            this.painter.DrawHealthPointsBar(
                player.MaximumHealthPoints, player.HealthPoints);
        }

        public void PlayNextTurn()
        {
            if (!player.IsAlive)
            {
                OnEndGAme("Game Over");
            }
            else if (creaturesInWorld.Count - 1 == 0) // No Enemies Left
            {
                OnEndGAme("You Win");
            }

            ProcessSpellBehavior();
            GetBonusesFromDeadEnemies();
            RemoveDeadCreatures();
            ProcessArtificialIntelligenceCreatures();
            if (player.HealthPoints < 0) player.HealthPoints = 0;
            this.creaturesInWorld.ForEach(creature => this.painter.RedrawObject(creature));
            this.painter.DrawInventoryBar(this.player.Inventory);
            this.newBonusesDroppedByEnemies.ForEach(weapon => this.painter.AddObject(weapon));
            this.newBonusesDroppedByEnemies.Clear();
        }

        public void OnEndGAme(string message)
        {
            if (endGame != null)
            {
                EndGameEventArgs args = new EndGameEventArgs(message);
                endGame(this, args);
            }
        }

        private void InitializeCreatures()
        {
            Item[] playerInventory = {null, null, null};
            var playerCharacter = new Mage(100, 100, playerInventory);
            player = playerCharacter;
            creaturesInWorld.Add(player);
            var witch = new Witch(850, 150);
            //Thread.Sleep(100);
            creaturesInWorld.Add(witch);
            var firstFighter = new Fighter(500, 300);
            var secondFighter = new Fighter(200, 320);
            creaturesInWorld.Add(firstFighter);
            creaturesInWorld.Add(secondFighter);
        }

        private void InitializeVariables()
        {
            this.creaturesInWorld = new List<Creature>();
            this.newBonusesDroppedByEnemies = new List<Item>();
            this.allBonusesDroppedByEnemies = new List<Item>();
            this.spellList = new List<Spell>();
        }

        private void RemoveDeadCreatures()
        {
            this.creaturesInWorld.Where(creature => !creature.IsAlive).ToList()
                .ForEach(deadCreature => this.painter.RemoveObject(deadCreature));
            this.creaturesInWorld.RemoveAll(creature => !creature.IsAlive);
        }

        private void GetBonusesFromDeadEnemies()
        {
            foreach (Creature creature in this.creaturesInWorld)
            {
                if (creature is Enemy && !creature.IsAlive)
                {
                    Enemy enemy = creature as Enemy;

                    this.newBonusesDroppedByEnemies.Add(enemy.DropBonus());
                }
            }

            this.allBonusesDroppedByEnemies.AddRange(this.newBonusesDroppedByEnemies);
        }

        private void ProcessArtificialIntelligenceCreatures()
        {
            foreach (Creature creature in this.creaturesInWorld)
            {
                if (creature is Enemy)
                {
                    Enemy enemy = creature as Enemy;
                    enemy.aiController.GetPlayerData(this.player);
                    NextMoveDecision decision = enemy.aiController.DecideNextMove();

                    switch (decision)
                    {
                        case NextMoveDecision.Move:
                            ProcessMovement(enemy);
                            break;
                        case NextMoveDecision.UseWeaponHeld:
                            combatSystem.PlayerAttacked(enemy, this.player);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void ProcessMovement(IMovable moveableObj)
        {
            moveableObj.Move();
        }

        private void SubscribeToUserInput(IInputInterface userInteface)
        {
            if (!userInteface.ControllerEnabled)
            {
                throw new UserControlDisabledException();
            }

            userInteface.OnLeftMouseClicked += (sender, args) =>
            {
                foreach (Creature creature in creaturesInWorld)
                {
                    if (creature is Enemy)
                    {
                        Enemy creatureAsEnemy = creature as Enemy;
                        combatSystem.EnemyAttacked(this.player, creatureAsEnemy);
                    }
                }

                this.MovePlayer(args);
            };

            userInteface.OnRightMouseClicked += (sender, args) =>
            {
                if (this.allBonusesDroppedByEnemies.Count > 0)
                {
                    MouseEventArgs userArgs = args as MouseEventArgs;
                    Item itemPicked = GetItemPicked(new Point(userArgs.X, userArgs.Y));
                    bool item = this.player.TryPickAnItem(itemPicked);

                    if (item)
                    {
                        this.painter.RemoveObject(itemPicked);
                        this.allBonusesDroppedByEnemies.Remove(itemPicked);
                    }
                }
            };

            userInteface.OnKeyOnePressed += (sender, args) =>
            {
                player.DropWeapon(0);
            };

            userInteface.OnKeyTwoPressed += (sender, args) =>
            {
                player.DropWeapon(1);
            };

            userInteface.OnKeyThreePressed += (sender, args) =>
            {
                player.DropWeapon(2);
            };

            // For Debugging
            userInteface.OnSpacePressed += (sender, args) =>
            {
                PlayNextTurn();
            };

            userInteface.OnQPressed += (sender, args) =>
            {
                var spellArgs = args as SpellCastEventArgs;
                this.CastPlayerSpell(0, spellArgs.CastX, spellArgs.CastY);
            };
        }

        private void CastPlayerSpell(int number, int spellX, int spellY)
        {
            var spell = this.player.CastSpell(0, spellX, spellY);
            ProcessSpellCast(spell);
        }

        private void ProcessSpellCast(Spell spell)
        {
            var caster = spell.Caster;
            int spellDistance = GetDistance(caster.X, caster.Y, spell.X, spell.Y);

            if (spellDistance <= caster.AttackRange)
            {
                this.painter.AddObject(spell);
                this.spellList.Add(spell);
            }
        }

        private void ProcessSpellBehavior()
        {
            foreach (var spell in this.spellList)
            {
                ITimeoutable timeOutSpell = spell as ITimeoutable;

                if (timeOutSpell != null)
                {
                    ProcessSpellTimeout(timeOutSpell);
                }
            }
        }

        private void ProcessSpellTimeout(ITimeoutable spell)
        {
            spell.CurrentTimeout += interval;

            if (spell.HasTimedOut)
            {
                this.painter.RemoveObject((Spell) spell);
            }
        }

        public bool IsWithinRange(IGameObject objectA, IGameObject objectB)
        {
            int objectAX1 = objectA.X;
            int objectAY1 = objectA.Y;
            int objectAX2 = objectAX1 + objectA.SizeX;
            int objectAY2 = objectAY1 + objectA.SizeY;

            int objectBX1 = objectB.X;
            int objectBY1 = objectB.Y;
            int objectBX2 = objectBX1 + objectB.SizeX;
            int objectBY2 = objectBY1 + objectB.SizeY;

            return objectAX1 < objectBX2
                   && objectAX2 > objectBX1
                   && objectAY1 < objectBY2
                   && objectAY2 > objectBY1;
        }

        public int GetDistance(int x1, int y1, int x2, int y2)
        {
            return (int)
                Math.Sqrt((x1 - x2)*(x1 - x2) + (y1 - y2)*(y1 - y2));
        }

        private Item GetItemPicked(Point playerClickPosition)
        {
            Item weaponPicked = null;

            foreach (var weapon in allBonusesDroppedByEnemies)
            {
                bool isBelowTopBorder = playerClickPosition.Y >= weapon.TopLeftPoint.Y;
                bool isInsideLeftBorder = playerClickPosition.X >= weapon.TopLeftPoint.X;
                bool isAboveBottomBorder = playerClickPosition.Y <= weapon.BottomLeftPoint.Y;
                bool isInsideRightBorder = playerClickPosition.X <= weapon.BottomRightPoint.X;

                bool isSelectedWeapon = isBelowTopBorder && isInsideLeftBorder &&
                                        isAboveBottomBorder && isInsideRightBorder;

                if (isSelectedWeapon)
                {
                    weaponPicked = weapon;
                    break;
                }
            }

            return weaponPicked;
        }

        private void MovePlayer(EventArgs args)
        {
            MouseEventArgs mouseArgs = args as MouseEventArgs;

            if (mouseArgs != null)
            {
                this.player.DirX = mouseArgs.X;
                this.player.DirY = mouseArgs.Y;

                ProcessMovement(player);
            }
        }
    }
}
