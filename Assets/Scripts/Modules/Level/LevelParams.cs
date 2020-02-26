using UnityEngine;

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
        private Vector2 _playerSpawnPoint;
        public Vector3 PlayerSpawnPoint => _playerSpawnPoint;
    }
}
