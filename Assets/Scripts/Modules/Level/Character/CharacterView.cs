using UnityEngine;

namespace Modules.Level.Character
{
    public class CharacterView : MonoBehaviour
    {
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
    }
}
