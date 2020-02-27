using UnityEngine;

namespace Modules.Level.Character.Commands
{
    public class MoveRightDownCommand : AbstractMoveCommand
    {
        protected override DirectionRotationPair Direction => _downRightDirection;
    }
}
