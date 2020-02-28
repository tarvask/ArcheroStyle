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

        // dependencies
        private Character.CharacterController _player;

        // own members
        private List<Character.CharacterController> _enemies = new List<Character.CharacterController>();
        public List<Character.CharacterController> Enemies => _enemies;

        public EnemiesManager(LevelParams levelConfig, Transform arenaTransform, float obstaclesHeight)
        {
            _enemies = EnemiesSpawner.Spawn(levelConfig.Enemies, arenaTransform, levelConfig.ArenaSize, levelConfig.EnemiesSpawnBound, obstaclesHeight);

            foreach (var enemy in _enemies)
            {
                enemy.OnAimingStarted += () => enemy.SetTarget(_player);
                enemy.OnShotTriggered += (weapon, originTransform, targetTransform) => OnShotTriggered?.Invoke(weapon, originTransform, targetTransform);
            }
        }

        public void SetPlayer(Character.CharacterController player)
        {
            _player = player;
        }

        public void OuterUpdate(float deltaTime)
        {

        }
    }
}
