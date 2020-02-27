using UnityEngine;

namespace Modules.Level.Character.Commands
{
    public class MoveUpCommand : AbstractMoveCommand
    {
        protected override Vector3 Direction => _upDirection;
    }
}
