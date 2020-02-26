using UnityEngine;

namespace Modules.Level.Character
{
    [CreateAssetMenu]
    public class CharacterParams : ScriptableObject
    {
        [SerializeField]
        private CharacterView _characterViewPrefab;
        public CharacterView CharacterViewPrefab => _characterViewPrefab;

        [SerializeField]
        private int _speed;
        public int Speed => _speed;

        [SerializeField]
        private int _healthPoints;
        public int HealthPoints => _healthPoints;

        [SerializeField]
        private WeaponConfig[] _weapons;
        public WeaponConfig[] Weapons => _weapons;
    }
}
