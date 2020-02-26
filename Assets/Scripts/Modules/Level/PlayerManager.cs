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
                    // create up movement command
                    Debug.Log("Move Up");
                    break;

                case MovementDirection.RightUp:
                    // create right-up movement command
                    Debug.Log("Move Right Up");
                    break;

                case MovementDirection.Right:
                    // create right movement command
                    Debug.Log("Move Right");
                    break;

                case MovementDirection.RightDown:
                    // create right-down movement command
                    Debug.Log("Move Right Down");
                    break;

                case MovementDirection.Down:
                    // create down movement command
                    Debug.Log("Move Down");
                    break;

                case MovementDirection.LeftDown:
                    // create left-down movement command
                    Debug.Log("Move Left Down");
                    break;

                case MovementDirection.Left:
                    // create left movement command
                    Debug.Log("Move Left");
                    break;

                case MovementDirection.LeftUp:
                    // create left-up movement command
                    Debug.Log("Move Left Up");
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
