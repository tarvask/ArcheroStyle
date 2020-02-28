namespace Modules.Level.Character.Commands
{
    public class TakePreviousWeaponCommand : ICommand
    {
        public void Execute(CharacterState characterState,
                            CharacterParams characterConfig,
                            CharacterView characterView,
                            float deltaTime)
        {
            int currentWeaponIndex = System.Array.FindIndex(characterConfig.Weapons, (w) => (w == characterState.Weapon));
            WeaponParams previousWeapon;

            if (currentWeaponIndex > 0)
            {
                previousWeapon = characterConfig.Weapons[currentWeaponIndex - 1];
            }
            else
            {
                previousWeapon = characterConfig.Weapons[characterConfig.Weapons.Length - 1];
            }

            characterState.ChangeWeapon(previousWeapon);
        }
    }
}
