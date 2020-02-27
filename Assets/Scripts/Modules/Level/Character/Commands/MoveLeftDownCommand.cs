using UnityEngine;

namespace Modules.Level.Character.Commands
{
    public class MoveLeftDownCommand : AbstractMoveCommand
    {
        protected override DirectionRotationPair Direction => _downLeftDirection;
    }
}
