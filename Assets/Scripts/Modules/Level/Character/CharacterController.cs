using System.Collections.Generic;
using UnityEngine;
using Modules.Level.Character.Commands;

namespace Modules.Level.Character
{
    public class CharacterController
    {
        // dependencies
        private CharacterParams _config;
        private CharacterView _view;

        // own members
        private CharacterState _state;
        private Queue<ICommand> _commands;
        private Transform _transform;

        public CharacterController(CharacterParams config, CharacterView view)
        {
            // resolve dependencies
            _config = config;
            _view = view;

            // init own members
            _state = new CharacterState(_config);
            _commands = new Queue<ICommand>();
        }

        public bool IsActive => (_state.Condition == CharacterCondition.Active);
        public Vector3 ArenaPosition => _transform.localPosition;

        public void Activate()
        {
            _state.Activate();
        }

        public void AddCommand(ICommand command)
        {
            _commands.Enqueue(command);
        }

        public void Think(float deltaTime)
        {
            if (_state.HealthPoints < 0)
            {
                Die();
            }
            else
            {
                if (_commands != null)
                {
                    ExecuteCommands(deltaTime);
                    // decrease shooting timer by deltaTime
                    _state.Tick(deltaTime);
                }
                else
                {
                    Shoot(deltaTime);
                }
            }
        }

        private void Die()
        {
            _state.Die();
            // show dying animation and destroy
        }

        private void ExecuteCommands(float deltaTime)
        {
            while (_commands.Count > 0)
            {
                _commands.Dequeue().Execute(_state, _config, _view, deltaTime);
            }
        }

        private void Shoot(float deltaTime)
        {
            if (_state.ShootingTimer <= 0)
            {
                // shoot a bullet

                // set shoot timer to max
                _state.ReloadWeapon(_state.Weapon.ReloadingTimeSeconds);
            }
            else
            {
                // decrease shooting timer by deltaTime
                _state.Tick(deltaTime);
            }
        }
    }
}
