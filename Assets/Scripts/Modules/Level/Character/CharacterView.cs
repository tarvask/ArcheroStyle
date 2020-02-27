using UnityEngine;

namespace Modules.Level.Character
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField]
        private Transform _movementTransform;

        [SerializeField]
        private Transform _bodyTransform;

        public void ChangePosition(Commands.AbstractMoveCommand.DirectionRotationPair direction, float speed)
        {
            Vector3 nextPosition = _movementTransform.localPosition + direction.Direction * speed;
            _bodyTransform.localRotation = direction.Rotation;
            _movementTransform.localPosition = nextPosition;
        }
    }
}
