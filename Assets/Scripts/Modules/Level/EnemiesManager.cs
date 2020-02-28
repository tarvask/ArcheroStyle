using System;
using System.Collections.Generic;
using UnityEngine;
using Modules.Level.Character;
using Modules.Level.Character.Commands;

namespace Modules.Level
{
    public class EnemiesManager
    {
        // interface
        public event Action<WeaponParams, Transform, Transform> OnShotTriggered;
        public event Action OnEnemyKilled;

        // dependencies
        private Character.CharacterController _player;

        // own members
        private List<Character.CharacterController> _enemies = new List<Character.CharacterController>();
        public List<Character.CharacterController> Enemies => _enemies;

        public EnemiesManager(LevelParams levelConfig, Transform arenaTransform, float obstaclesHeight)
        {
            _enemies = EnemiesSpawner.Spawn(levelConfig.Enemies, arenaTransform, levelConfig.ArenaSize, levelConfig.EnemiesSpawnBound, obstaclesHeight);

            foreach (Character.CharacterController enemy in _enemies)
            {
                enemy.OnAimingStarted += () => TrySetTarget(enemy);
                enemy.OnShotTriggered += (weapon, originTransform, targetTransform) => OnShotTriggered?.Invoke(weapon, originTransform, targetTransform);
                enemy.OnKilled += () => OnEnemyKilled?.Invoke();
            }
        }

        public void SetPlayer(Character.CharacterController player)
        {
            _player = player;
        }

        public void OuterUpdate(float deltaTime)
        {
            foreach (Character.CharacterController enemy in _enemies)
            {
                if (enemy.IsActive)
                {
                    enemy.Think(deltaTime);
                }
            }
        }

        public void Activate()
        {
            foreach (Character.CharacterController enemy in _enemies)
            {
                enemy.Activate();
            }
        }

        public void Pause()
        {
            foreach (Character.CharacterController enemy in _enemies)
            {
                enemy.Pause();
            }
        }

        private void TrySetTarget(Character.CharacterController enemy)
        {
            if (_player.IsAlive)
            {
                enemy.SetTarget(_player);
            }
            else
            {
                enemy.SetTarget(null);
            }
        }
    }
}
