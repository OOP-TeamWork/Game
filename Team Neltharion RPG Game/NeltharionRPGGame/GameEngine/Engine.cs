using System;
using System.Collections.Generic;
using System.Linq;
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
        private List<Weapon> droppedWeaponsByEnemies;
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
            this.droppedWeaponsByEnemies.ForEach(weapon => this.painter.AddObject(weapon));
            droppedWeaponsByEnemies.Clear();
        }

        private void InitializeCharacters()
        {
            Weapon stuff = new Stuff(0, 0);
            Weapon poleArm = new PoleArm(30, 0);
            Weapon potion = new Potion(60, 0);
            Weapon[] weapons = { stuff, poleArm, potion};
            var playerCharacter = new Mage(100, 100, weapons);
            var witch = new Witch(650, 150);
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
            this.droppedWeaponsByEnemies = new List<Weapon>();
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
                    this.droppedWeaponsByEnemies.Add(creatureAsenemy.DropBonus());
                }
            }
        }

        private void ProcessArtificialIntelligentCreatures()
        {
            foreach (Creature creature in this.creaturesInWorld)
            {
                if (creature is Enemy)
                {
                    Enemy enemy = creature as Enemy;
                    NextMoveDecision decision = enemy.DecideNextMove();
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
                MouseEventArgs userArgs = args as MouseEventArgs;
                Weapon weaponPicked = GetWeaponPicked(new Point(userArgs.X, userArgs.Y));
                this.player.pickWeapon(weaponPicked);
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

        private Weapon GetWeaponPicked(Point playerClickPosition)
        {
            Weapon weaponPicked = null;
            foreach (var weapon in droppedWeaponsByEnemies)
            {
                // compare weaponInput.
                bool isBelowTopBorder = weapon.TopLeftPoint.Y >= playerClickPosition.Y;
                bool isInsideLeftBorder = weapon.TopLeftPoint.X >= playerClickPosition.X;
                bool isAboveBottomBorder = weapon.BottomLeftPoint.Y <= playerClickPosition.Y;
                bool isInsideRightBorder = weapon.BottomRightPoint.X <= playerClickPosition.X;

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
