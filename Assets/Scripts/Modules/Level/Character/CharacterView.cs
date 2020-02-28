using System;
using UnityEngine;
using Modules.Level.Bullet;

namespace Modules.Level.Character
{
    public class CharacterView : MonoBehaviour
    {
        public event Action<BulletState> OnSmashed;

        [SerializeField]
        private Transform _movementTransform;
        public Transform MovementTransform => _movementTransform;

        [SerializeField]
        private Transform _bodyTransform;
        public Transform BodyTransform => _bodyTransform;

        [SerializeField]
        private Transform _gunTransform;
        public Transform GunTransform => _gunTransform;

        public void ChangePosition(Commands.AbstractMoveCommand.DirectionRotationPair direction, float speed)
        {
            Vector3 nextPosition = _movementTransform.localPosition + direction.Direction * speed;
            _bodyTransform.localRotation = direction.Rotation;
            _movementTransform.localPosition = nextPosition;
        }

        public void Smash(BulletState bulletConfig)
        {
            OnSmashed?.Invoke(bulletConfig);
        }
    }
}
