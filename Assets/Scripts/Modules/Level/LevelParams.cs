using UnityEngine;

namespace Modules.Level
{
    [CreateAssetMenu]
    public class LevelParams : ScriptableObject
    {
        [SerializeField]
        private string _sceneName;
        public string SceneName => _sceneName;
    }
}
