using UnityEngine;

namespace Modules.Level.Character.Commands
{
    public class MoveRightCommand : AbstractMoveCommand
    {
        protected override Vector3 Direction => _rightDirection;
    }
}
