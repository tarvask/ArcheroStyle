using UnityEngine;

namespace Modules.Level.Character.Commands
{
    public class MoveDownCommand : AbstractMoveCommand
    {
        protected override Vector3 Direction => _downDirection;
    }
}
