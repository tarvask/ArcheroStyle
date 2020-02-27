using UnityEngine;
using Modules.Level.Character;

namespace Modules.Level
{
    [CreateAssetMenu]
    public class LevelParams : ScriptableObject
    {
        [SerializeField]
        private string _sceneName;
        public string SceneName => _sceneName;

        // store as 2-dimensional,
        // return in suitable 3-dimensional form
        [SerializeField]
        private Vector3 _playerSpawnPoint;
        public Vector3 PlayerSpawnPoint => _playerSpawnPoint;

        [SerializeField]
        private Vector2Int _arenaSize;
        public Vector2Int ArenaSize => _arenaSize;

        [SerializeField]
        private int _enemiesSpawnBound;
        public int EnemiesSpawnBound => _enemiesSpawnBound;

        [SerializeField]
        private EnemyParams[] _enemies;
        public EnemyParams[] Enemies => _enemies;
    }
}
