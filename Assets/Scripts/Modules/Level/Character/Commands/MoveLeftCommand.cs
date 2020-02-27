using UnityEngine;

namespace Modules.Level.Character.Commands
{
    public class MoveLeftCommand : AbstractMoveCommand
    {
        protected override DirectionRotationPair Direction => _leftDirection;
    }
}
