using System.Collections.Generic;
using System.Drawing.Printing;
using NeltharionRPGGame.Interfaces;
using NeltharionRPGGame.Structure;


namespace NeltharionRPGGame.GameEngine
{
    public class Engine
    {
        private IPaintInterface painter;
        private List<Creature> creaturesInWorld;
        private List<Weapon> droppedWeaponsFromEnemies;
        private List<Weapon> droppedWeaponsFromCharacters; 
        private Creature player;
        private int interval;

        public void InitializeWorld(IUserInputInterface controller, IPaintInterface painter)
        {
            InitializeVariables();
            SubscribeToUserInput(controller);
            InitializeCharacters();
            this.painter = painter;
            foreach (Creature creature in creaturesInWorld)
            {
                this.painter.AddObject(creature);
            }
        }

        private void InitializeCharacters()
        {
            var playerCharacter = new Mage(100, 100);
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

        public void PlayNextTurn()
        {
            RemoveDeadCreatures();
            ProcessArtificialIntelligentCreatures();
            this.creaturesInWorld.ForEach(creature => this.painter.RedrawObject(creature));
            // Remove comments when inventory is ready
            //this.droppedWeaponsFromEnemies.ForEach(weapon => this.painter.AddObject(weapon));
            //this.droppedWeaponsFromCharacters.ForEach(weapon => this.painter.RemoveObject(weapon));
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

        private void ProcessMovement(IMovable movableObject)
        {
            movableObject.Move();
        }

        private void ProcessWeaponUsage(ICreature creature)
        {
            // TODO Call UseWeaponHeld for each creature
        }

        // The methods below set unit`s next move so that IMoveable.Move() method can add these values to the unit`s current X, Y
        private void MovePlayerRight()
        {
            this.player.DirX = 1;
            this.player.DirY = 0;
            ProcessMovement(player);
        }

        private void MovePlayerDown()
        {
            this.player.DirX = 0;
            this.player.DirY = 1;
            ProcessMovement(player);
        }

        private void MovePlayerUp()
        {
            this.player.DirX = 0;
            this.player.DirY = -1;
            ProcessMovement(player);
        }

        private void MovePlayerLeft()
        {
            this.player.DirX = -1;
            this.player.DirY = 0;
            ProcessMovement(player);
        }

        private void SubscribeToUserInput(IUserInputInterface userInteface)
        {
            userInteface.OnUpPressed += (sender, args) =>
            {
                this.MovePlayerUp(); // this method will be called when the OnUpPressed event fires
            };

            userInteface.OnDownPressed += (sender, args) =>
            {
                this.MovePlayerDown();
            };

            userInteface.OnLeftPressed += (sender, args) =>
            {
                this.MovePlayerLeft();
            };

            userInteface.OnRightPressed += (sender, args) =>
            {
                this.MovePlayerRight();
            };
        }

        private void SubscribeToWeaponDropped(List<Creature> creatures)
        {
            foreach (Creature creature in creatures)
            {
                if (creature is Enemy)
                {
                    creature.weaponDropped += (sender, args) =>
                    {
                        this.droppedWeaponsFromEnemies.Add(args.BonusDropped);
                    };
                }
                else
                {
                    creature.weaponDropped += (sender, args) =>
                    {
                        this.droppedWeaponsFromCharacters.Add(args.BonusDropped);
                    };
                }
            }
        }
    }
}
