using UnityEngine;

namespace Modules.Level.Character.Commands
{
    public class MoveUpCommand : AbstractMoveCommand
    {
        protected override DirectionRotationPair Direction => _upDirection;
    }
}
