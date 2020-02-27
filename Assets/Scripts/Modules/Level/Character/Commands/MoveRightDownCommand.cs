using UnityEngine;

namespace Modules.Level.Character.Commands
{
    public class MoveRightDownCommand : AbstractMoveCommand
    {
        protected override Vector3 Direction => _downRightDirection;
    }
}
