namespace Modules.Level.Character.Commands
{
    public class TakeNextWeaponCommand : ICommand
    {
        public void Execute(CharacterState characterState,
                            CharacterParams characterConfig,
                            CharacterView characterView,
                            float deltaTime)
        {
            int currentWeaponIndex = System.Array.FindIndex(characterConfig.Weapons, (w) => (w == characterState.Weapon));
            WeaponParams nextWeapon;

            if (currentWeaponIndex < characterConfig.Weapons.Length - 1)
            {
                nextWeapon = characterConfig.Weapons[currentWeaponIndex + 1];
            }
            else
            {
                nextWeapon = characterConfig.Weapons[0];
            }

            characterState.ChangeWeapon(nextWeapon);
        }
    }
}
