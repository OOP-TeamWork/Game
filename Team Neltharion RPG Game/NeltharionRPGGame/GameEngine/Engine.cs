using System.Collections.Generic;
using NeltharionRPGGame.Interfaces;

namespace NeltharionRPGGame.GameEngine
{
    public class Engine
    {
        private IPaintInterface painter;
        private ICollection<ICreature> unitList;
        private Creature player;
        private int interval;

        public void InitializeWorld(IUserInputInterface controller, IPaintInterface painter)
        {
            InitializeVariables();
            SubscribeToUserInput(controller);
            InitializeCharacters();
            this.painter = painter;
            this.painter.AddObject(player);
        }

        private void InitializeCharacters()
        {
            var playerCharacter = new Mage(100, 100);
            player = playerCharacter;
            unitList.Add(player);
        }

        private void InitializeVariables()
        {
            this.unitList = new List<ICreature>();
        }

        public void PlayNextTurn()
        {
            this.painter.RedrawObject(this.player); // Has to redraw all units in the future, but for now just our test character
        }       

        public void ProcessMovement(IMovable movableObject)
        {
            movableObject.Move();
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
    }
}
