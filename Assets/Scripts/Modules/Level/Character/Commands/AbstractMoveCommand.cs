using UnityEngine;

namespace Modules.Level.Character.Commands
{
    public abstract class AbstractMoveCommand : ICommand
    {
        // precalculated static direction vectors
        protected static Vector3 _upDirection = Vector3.forward;
        protected static Vector3 _upRightDirection = (Vector3.forward + Vector3.right).normalized;
        protected static Vector3 _rightDirection = Vector3.right;
        protected static Vector3 _downRightDirection = (Vector3.back + Vector3.right).normalized;
        protected static Vector3 _downDirection = Vector3.back;
        protected static Vector3 _downLeftDirection = (Vector3.back + Vector3.left).normalized;
        protected static Vector3 _leftDirection = Vector3.left;
        protected static Vector3 _upLeftDirection = (Vector3.forward + Vector3.left).normalized;

        abstract protected Vector3 Direction { get; }

        public void Execute(CharacterState characterState,
                            CharacterParams characterConfig,
                            CharacterView characterView,
                            float deltaTime)
        {
            characterView.ChangePosition(Direction * deltaTime * characterState.Speed);
        }
    }
}
