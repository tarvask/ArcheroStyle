using UnityEngine;

namespace Modules.Level.Character.Commands
{
    public class MoveLeftDownCommand : AbstractMoveCommand
    {
        protected override Vector3 Direction => _downLeftDirection;
    }
}
