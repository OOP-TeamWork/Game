using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using NeltharionRPGGame.Interfaces;
using NeltharionRPGGame.Structure;
using NeltharionRPGGame.UI;
using System.Drawing;

namespace NeltharionRPGGame.GameEngine
{
    public class Engine
    {
        private PaintBrush painter;
        private List<Creature> creaturesInWorld;
        private List<Item> newBonusesDroppedByEnemies;
        private List<Item> allBonusesDroppedByEnemiesCopy;
        private Character player;
        private int interval;

        public void InitializeWorld(IInputInterface controller, PaintBrush painter)
        {
            this.painter = painter;
            InitializeVariables();
            SubscribeToUserInput(controller);
            InitializeCharacters();
            creaturesInWorld
                .ForEach(creature => this.painter.AddObject(creature));
            this.painter.DrawInventoryBar(player.Inventory);
            this.painter.DrawHealthPointsBar(
                player.MaximumHealthPoints, player.HealthPoints);
        }

        public void PlayNextTurn()
        {
            GetBonusesFromDeadEnemies();
            RemoveDeadCreatures();
            ProcessArtificialIntelligentCreatures();
            this.creaturesInWorld.ForEach(creature => this.painter.RedrawObject(creature));
            this.painter.DrawInventoryBar(this.player.Inventory);
            this.newBonusesDroppedByEnemies.ForEach(weapon => this.painter.AddObject(weapon));
            this.newBonusesDroppedByEnemies.Clear();
        }

        private void InitializeCharacters()
        {
            Item stuff = new Staff(0, 0);
            Item poleArm = new PoleArm(30, 0);
            Item potion = new Sword(60, 0);
            Item[] weapons = { stuff, poleArm, potion};
            var playerCharacter = new Mage(100, 100, weapons);
            var witch = new Witch(650, 150);
            Thread.Sleep(100);
            var witch2 = new Witch(350, 150);
            var fighetr = new Fighter(300, 300);
            var fighetr1 = new Fighter(200, 320);
            player = playerCharacter;
            creaturesInWorld.Add(player);
            creaturesInWorld.Add(witch);
            creaturesInWorld.Add(witch2);
            creaturesInWorld.Add(fighetr);
            creaturesInWorld.Add(fighetr1);
        }

        private void InitializeVariables()
        {
            this.creaturesInWorld = new List<Creature>();
            this.newBonusesDroppedByEnemies = new List<Item>();
            this.allBonusesDroppedByEnemiesCopy = new List<Item>();
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
                    Enemy creatureAsenemy = creature as Enemy;
                    this.newBonusesDroppedByEnemies.Add(creatureAsenemy.DropBonus());
                }
            }
            this.allBonusesDroppedByEnemiesCopy.AddRange(this.newBonusesDroppedByEnemies);
        }

        private void ProcessArtificialIntelligentCreatures()
        {
            foreach (Creature creature in this.creaturesInWorld)
            {
                if (creature is Enemy)
                {
                    Enemy enemy = creature as Enemy;
                    enemy.aiController.GetPlayerPosition(this.player);
                    NextMoveDecision decision = enemy.aiController.DecideNextMove();
                    switch (decision)
                    {
                        case NextMoveDecision.Move:
                            ProcessMovement(enemy);
                            break;
                        case NextMoveDecision.UseWeaponHeld:
                            ProcessWeaponUsage(creature);
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

        private void ProcessWeaponUsage(Creature creature)
        {
            creature.UseWeaponHeld();
            // CombatSystem(this.player);
            // This system will check if there are
            // targets to attack
        }
       
        private void SubscribeToUserInput(IInputInterface userInteface)
        {
            userInteface.OnLeftMouseClicked += (sender, args) =>
            {
                this.MovePlayer(args);
                // Process Weapon Usage(this.player);
                Witch withch = this.creaturesInWorld[1] as Witch;
                if (withch != null)
                {
                    withch.UpdateHealthPoints(-320);
                }
            };

            userInteface.OnRightMouseClicked += (sender, args) =>
            {
                if (this.allBonusesDroppedByEnemiesCopy.Count > 0)
                {
                    MouseEventArgs userArgs = args as MouseEventArgs;
                    Item itemPicked = GetItemPicked(new Point(userArgs.X, userArgs.Y));
                    bool item = this.player.TryPickAnItem(itemPicked);
                    if (item)
                    {
                        this.painter.RemoveObject(itemPicked);
                        this.allBonusesDroppedByEnemiesCopy.Remove(itemPicked);
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
        }

        private Item GetItemPicked(Point playerClickPosition)
        {
            Item weaponPicked = null;

            foreach (var weapon in allBonusesDroppedByEnemiesCopy)
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
