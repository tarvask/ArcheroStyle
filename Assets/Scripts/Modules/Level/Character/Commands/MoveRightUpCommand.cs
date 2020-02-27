using UnityEngine;

namespace Modules.Level.Character.Commands
{
    public class MoveRightUpCommand : AbstractMoveCommand
    {
        protected override Vector3 Direction => _upRightDirection;
    }
}
