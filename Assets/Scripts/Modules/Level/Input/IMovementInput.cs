namespace Modules.Level.Input
{
    public interface IMovementInput
    {
        bool IsUpButtonPressed { get; }
        bool IsLeftButtonPressed { get; }
        bool IsRightButtonPressed { get; }
        bool IsDownButtonPressed { get; }
    }
}
