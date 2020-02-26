using UnityEngine;

namespace Modules.Level.Character
{
    [CreateAssetMenu]
    public class CharacterParams : ScriptableObject
    {
        [SerializeField]
        private string _title;
        public string Title => _title;

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
        private WeaponParams[] _weapons;
        public WeaponParams[] Weapons => _weapons;
    }
}
