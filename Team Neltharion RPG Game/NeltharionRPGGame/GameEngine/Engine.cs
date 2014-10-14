using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NeltharionRPGGame.Interfaces;
using NeltharionRPGGame.Structure;

namespace NeltharionRPGGame.GameEngine
{
    public class Engine
    {
        private IDrawable painter;
        private List<Creature> creaturesInWorld;
        private List<Weapon> droppedWeaponsByEnemies;
        private Character player;
        private int interval;

        public void InitializeWorld(IInputInterface controller, IDrawable painter)
        {
            this.painter = painter;
            InitializeVariables();
            SubscribeToUserInput(controller);
            InitializeCharacters();
            SubscribeToWeaponDropped(creaturesInWorld);
            foreach (Creature creature in creaturesInWorld)
            {
                this.painter.AddObject(creature);
            }
            this.painter.DrawInventoryBar(player.Inventory);
        }

        public void PlayNextTurn()
        {
            RemoveDeadCreatures();
            ProcessArtificialIntelligentCreatures();
            this.creaturesInWorld.ForEach(creature => this.painter.RedrawObject(creature));
            this.painter.DrawInventoryBar(this.player.Inventory);
            // Remove comments when inventory is ready
            // this.droppedWeaponsByEnemies.ForEach(weapon => this.painter.AddObject(weapon));
        }

        private void InitializeCharacters()
        {
            Weapon sword = new Sword(0, 0);
            Weapon sword1 = new Sword(30, 0);
            Weapon sword2 = new Sword(60, 0);
            Weapon[] weapons = { sword, sword1, sword2};
            var playerCharacter = new Mage(100, 100, weapons);
            var witch = new Witch(650, 150);
            var fighetr = new Fighter(300, 300);
            player = playerCharacter;
            creaturesInWorld.Add(player);
            creaturesInWorld.Add(witch);
            creaturesInWorld.Add(fighetr);
        }

        private void InitializeVariables()
        {
            this.creaturesInWorld = new List<Creature>();
        }

        private void RemoveDeadCreatures()
        {
            this.creaturesInWorld.RemoveAll(creature => !creature.IsAlive);
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
            // TODO Call UseWeaponHeld for each creature
        }
       
        private void SubscribeToUserInput(IInputInterface userInteface)
        {
            userInteface.OnLeftMouseClicked += (sender, args) =>
            {
                this.MovePlayer(args);
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

        private void SubscribeToWeaponDropped(List<Creature> creatures)
        {
            foreach (Creature creature in creatures)
            {
                if (creature is Enemy)
                {
                    creature.weaponDropped += (sender, args) =>
                    {
                        this.droppedWeaponsByEnemies.Add(args.WeaponDropped);
                    };
                }
            }
        }
    }
}
