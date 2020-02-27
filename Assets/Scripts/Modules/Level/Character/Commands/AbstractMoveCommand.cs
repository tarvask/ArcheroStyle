using UnityEngine;

namespace Modules.Level.Character.Commands
{
    public abstract class AbstractMoveCommand : ICommand
    {
        public class DirectionRotationPair
        {
            public Vector3 Direction { get; set; }
            public Quaternion Rotation { get; set; }
        }

        // precalculated static direction and rotation pairs
        protected static readonly DirectionRotationPair _upDirection = new DirectionRotationPair()
        { Direction = Vector3.forward, Rotation = Quaternion.Euler(Vector3.zero) };
        protected static readonly DirectionRotationPair _upRightDirection = new DirectionRotationPair()
        { Direction = (Vector3.forward + Vector3.right).normalized, Rotation = Quaternion.Euler(new Vector3(0, 45, 0)) };
        protected static readonly DirectionRotationPair _rightDirection = new DirectionRotationPair()
        { Direction = Vector3.right, Rotation = Quaternion.Euler(new Vector3(0, 90, 0)) };
        protected static readonly DirectionRotationPair _downRightDirection = new DirectionRotationPair()
        { Direction = (Vector3.back + Vector3.right).normalized, Rotation = Quaternion.Euler(new Vector3(0, 135, 0)) };
        protected static readonly DirectionRotationPair _downDirection = new DirectionRotationPair()
        { Direction = Vector3.back, Rotation = Quaternion.Euler(new Vector3(0, 180, 0)) };
        protected static readonly DirectionRotationPair _downLeftDirection = new DirectionRotationPair()
        { Direction = (Vector3.back + Vector3.left).normalized, Rotation = Quaternion.Euler(new Vector3(0, -135, 0)) };
        protected static readonly DirectionRotationPair _leftDirection = new DirectionRotationPair()
        { Direction = Vector3.left, Rotation = Quaternion.Euler(new Vector3(0, -90, 0)) };
        protected static readonly DirectionRotationPair _upLeftDirection = new DirectionRotationPair()
        { Direction = (Vector3.forward + Vector3.left).normalized, Rotation = Quaternion.Euler(new Vector3(0, -45, 0)) };

        abstract protected DirectionRotationPair Direction { get; }

        public void Execute(CharacterState characterState,
                            CharacterParams characterConfig,
                            CharacterView characterView,
                            float deltaTime)
        {
            characterView.ChangePosition(Direction, deltaTime * characterState.Speed);
        }
    }
}
