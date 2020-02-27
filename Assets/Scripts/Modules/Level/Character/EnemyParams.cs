using UnityEngine;

namespace Modules.Level.Character
{
    [CreateAssetMenu]
    public class EnemyParams : CharacterParams
    {
        [SerializeField]
        private float _freezeTime;
        public float FreezeTime => _freezeTime;

        [SerializeField]
        private float _movementRange;
        public float MovementRange => _movementRange;

        [SerializeField]
        private bool _isFlying;
        public bool IsFlying => _isFlying;
    }
}
