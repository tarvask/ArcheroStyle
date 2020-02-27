using UnityEngine;

namespace Modules.Level.Character.Commands
{
    public class MoveRightCommand : AbstractMoveCommand
    {
        protected override DirectionRotationPair Direction => _rightDirection;
    }
}
