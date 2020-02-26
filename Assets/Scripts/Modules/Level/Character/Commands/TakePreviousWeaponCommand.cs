namespace Modules.Level.Character.Commands
{
    public class TakePreviousWeaponCommand : ICommand
    {
        public void Execute(CharacterState characterState, CharacterParams characterConfig)
        {
            int currentWeaponIndex = System.Array.FindIndex(characterConfig.Weapons, (w) => characterState.Weapon);
            WeaponConfig previousWeapon;

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
