namespace Modules.Level.Character.Commands
{
    public class MoveDownCommand : AbstractMoveCommand
    {
        protected override DirectionRotationPair Direction => _downDirection;
    }
}
