using UnityEngine;

namespace Modules.Level.Character.Commands
{
    public class MoveLeftUpCommand : AbstractMoveCommand
    {
        protected override DirectionRotationPair Direction => _upLeftDirection;
    }
}
