using UnityEngine;

namespace Modules.Level.Character.Commands
{
    public class MoveLeftCommand : AbstractMoveCommand
    {
        protected override Vector3 Direction => _leftDirection;
    }
}
