using System.Collections.Generic;
using UnityEngine;
using Modules.Level.Character;
using Modules.Level.Character.Commands;

namespace Modules.Level
{
    public class EnemiesManager
    {
        private List<CharacterView> _enemies = new List<CharacterView>();

        public EnemiesManager(LevelParams levelConfig, Transform arenaTransform, float obstaclesHeight)
        {
            _enemies = EnemiesSpawner.Spawn(levelConfig.Enemies, arenaTransform, levelConfig.ArenaSize, levelConfig.EnemiesSpawnBound, obstaclesHeight);
        }

        public void OuterUpdate(float deltaTime)
        {

        }
    }
}
