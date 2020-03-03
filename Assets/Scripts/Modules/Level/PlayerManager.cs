using System;
using UnityEngine;
using Modules.Level.Character;
using Modules.Level.Character.Commands;

namespace Modules.Level
{
    public class PlayerManager
    {
        // interface
        public event Action OnAimingStarted;
        public event Action<WeaponParams, Transform, Transform> OnShotTriggered;
        public event Action<CharacterParams> OnPlayerKilled;
        public event Action<WeaponParams> OnWeaponChanged;

        // own members
        private Character.CharacterController _player;
        public Character.CharacterController Player => _player;

        public PlayerManager(LevelParams levelConfig, CharacterParams playerConfig, InputManager inputManager, Transform arenaTransform)
        {
            _player = CharacterSpawner.Spawn(playerConfig, arenaTransform, levelConfig.PlayerSpawnPoint);
            _player.OnAimingStarted += () => OnAimingStarted?.Invoke();
            _player.OnShotTriggered += (weapon, originTransform, targetTransform) => OnShotTriggered?.Invoke(weapon, originTransform, targetTransform);
            _player.OnKilled += (config) => OnPlayerKilled?.Invoke(config);
            _player.OnWeaponChanged += (weapon) => OnWeaponChanged?.Invoke(weapon);

            inputManager.OnMovementInput += MovePlayerCharacter;
            inputManager.OnChangeWeaponInput += ChangeCharacterWeapon;
        }

        public void Activate()
        {
            _player.Activate();
        }

        public void Pause()
        {
            _player.Pause();
        }

        public void OuterUpdate(float deltaTime)
        {
            if (_player.IsActive)
            {
                _player.Think(deltaTime);
            }
        }

        private void MovePlayerCharacter(MovementDirection direction)
        {
            if (_player.IsActive)
            {
                ICommand command = CreateMoveCommand(direction);
                _player.AddCommand(command);
            }
        }

        private void ChangeCharacterWeapon(int delta)
        {
            if (_player.IsActive)
            {
                ICommand command = CreateChangeWeaponCommand(delta);
                _player.AddCommand(command);
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
