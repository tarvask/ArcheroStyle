using System;
using System.Collections.Generic;
using UnityEngine;
using Modules.Level.Character.Commands;

namespace Modules.Level.Character
{
    public class CharacterController
    {
        // interface
        public event Action OnAimingStarted;
        public event Action<WeaponParams, Transform, Transform> OnShotTriggered;

        // dependencies
        private CharacterParams _config;
        private CharacterView _view;

        // own members
        private CharacterState _state;
        private Queue<ICommand> _commands;
        private CharacterController _shootingTarget;

        public CharacterController(CharacterParams config, CharacterView view)
        {
            // resolve dependencies
            _config = config;
            _view = view;

            // init own members
            _state = new CharacterState(_config);
            _commands = new Queue<ICommand>();
            _shootingTarget = null;
        }

        public bool IsActive => _state.Condition == CharacterCondition.Active;
        public bool IsAlive => _state.Condition != CharacterCondition.Dead;
        public Vector3 ArenaPosition => _view.MovementTransform.localPosition;

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
                if (_commands.Count > 0)
                {
                    ExecuteCommands(deltaTime);
                    // decrease shooting timer by deltaTime
                    _state.Tick(deltaTime);
                    // stop following target
                    _shootingTarget = null;
                }
                else
                {
                    Shoot(deltaTime);
                }
            }
        }

        public void SetTarget(CharacterController target)
        {
            _shootingTarget = target;
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
            // all enemies can be dead
            if (Aim())
            {
                if (_state.ShootingTimer <= 0)
                {
                    // shoot a bullet
                    OnShotTriggered?.Invoke(_state.Weapon, _view.GunTransform, _shootingTarget._view.BodyTransform);

                    // set shoot timer to max
                    _state.ReloadWeapon(_state.Weapon.ReloadingTimeSeconds);
                }
                else
                {
                    // decrease shooting timer by deltaTime
                    _state.Tick(deltaTime);
                }
            }
            else
            {
                // decrease shooting timer by deltaTime
                _state.Tick(deltaTime);
            }
        }

        private bool Aim()
        {
            if (_shootingTarget == null || !_shootingTarget.IsAlive)
            {
                // target will be found and passed after this call
                OnAimingStarted?.Invoke();
            }

            bool hasTarget = _shootingTarget != null;

            if (hasTarget)
            {
                // rotate to target
                _view.BodyTransform.LookAt(_shootingTarget._view.BodyTransform);
            }

            return hasTarget;
        }
    }
}
