namespace Modules.Level.Character.Commands
{
    public interface ICommand
    {
        void Execute(CharacterState characterState, CharacterParams characterConfig, CharacterView characterView, float deltaTime);
    }
}
