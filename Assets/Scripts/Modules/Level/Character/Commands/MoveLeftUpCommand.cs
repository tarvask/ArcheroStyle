using UnityEngine;

namespace Modules.Level.Character.Commands
{
    public class MoveLeftUpCommand : AbstractMoveCommand
    {
        protected override Vector3 Direction => _upLeftDirection;
    }
}
