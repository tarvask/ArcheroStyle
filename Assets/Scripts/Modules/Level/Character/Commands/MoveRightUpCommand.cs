using UnityEngine;

namespace Modules.Level.Character.Commands
{
    public class MoveRightUpCommand : AbstractMoveCommand
    {
        protected override DirectionRotationPair Direction => _upRightDirection;
    }
}
