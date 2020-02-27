using UnityEngine;
using Modules.Level.Character;
using Modules.Level.Character.Commands;

namespace Modules.Level
{
    public class PlayerManager
    {
        private Character.CharacterController _character;

        public PlayerManager(LevelParams levelConfig, CharacterParams playerConfig, InputManager inputManager, Transform arenaTransform)
        {
            _character = CharacterSpawner.Spawn(playerConfig, arenaTransform, levelConfig.PlayerSpawnPoint);
            inputManager.OnMovementInput += MovePlayerCharacter;
            inputManager.OnChangeWeaponInput += ChangeCharacterWeapon;
        }

        public void Activate()
        {
            _character.Activate();
        }

        public void OuterUpdate(float deltaTime)
        {
            _character.Think(deltaTime);
        }

        private void MovePlayerCharacter(MovementDirection direction)
        {
            if (_character.IsActive)
            {
                ICommand command = CreateMoveCommand(direction);
                _character.AddCommand(command);
            }
        }

        private void ChangeCharacterWeapon(int delta)
        {
            if (_character.IsActive)
            {
                ICommand command = CreateChangeWeaponCommand(delta);
                _character.AddCommand(command);
            }
        }

        private ICommand CreateMoveCommand(MovementDirection direction)
        {
            ICommand command = null;

            // create command
            switch (direction)
            {
                case MovementDirection.Up:
                    command = new MoveUpCommand();
                    break;

                case MovementDirection.RightUp:
                    command = new MoveRightUpCommand();
                    break;

                case MovementDirection.Right:
                    command = new MoveRightCommand();
                    break;

                case MovementDirection.RightDown:
                    command = new MoveRightDownCommand();
                    break;

                case MovementDirection.Down:
                    command = new MoveDownCommand();
                    break;

                case MovementDirection.LeftDown:
                    command = new MoveLeftDownCommand();
                    break;

                case MovementDirection.Left:
                    command = new MoveLeftCommand();
                    break;

                case MovementDirection.LeftUp:
                    command = new MoveLeftUpCommand();
                    break;
            }

            return command;
        }

        private ICommand CreateChangeWeaponCommand(int delta)
        {
            ICommand command;

            if (delta > 0)
            {
                command = new TakeNextWeaponCommand();
            }
            else
            {
                command = new TakePreviousWeaponCommand();
            }

            return command;
        }
    }
}
