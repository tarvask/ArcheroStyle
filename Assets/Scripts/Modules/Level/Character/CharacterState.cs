using System;

namespace Modules.Level.Character
{
    public enum CharacterCondition
    {
        Wait = 0,
        Active = 1,
        Dead = 2
    }

    public class CharacterState
    {
        public int HealthPoints { get; private set; }
        public float Speed { get; private set; }
        public float ShootingTimer { get; private set; }
        public WeaponParams Weapon { get; private set; }
        public CharacterCondition Condition { get; private set; }

        public event Action<WeaponParams> OnWeaponChanged;

        public CharacterState(CharacterParams config)
        {
            HealthPoints = config.HealthPoints;
            Speed = config.Speed;
            ShootingTimer = 0f;
            Weapon = config.Weapons[0];
            Condition = CharacterCondition.Wait;
        }

        public void Hurt(int damage)
        {
            HealthPoints -= damage;
        }

        // not used yet, but speed surely can be changed
        public void ChangeSpeed(float newSpeed)
        {
            Speed = newSpeed;
        }

        public void Tick(float deltaTime)
        {
            if (ShootingTimer > 0)
            {
                ShootingTimer -= deltaTime;
            }
        }

        public void ReloadWeapon(float reloadingTime)
        {
            ShootingTimer = reloadingTime;
        }

        public void ChangeWeapon(WeaponParams newWeapon)
        {
            Weapon = newWeapon;
            OnWeaponChanged?.Invoke(Weapon);
        }

        public void Activate()
        {
            Condition = CharacterCondition.Active;
        }

        public void Pause()
        {
            Condition = CharacterCondition.Wait;
        }

        public void Die()
        {
            Condition = CharacterCondition.Dead;
        }
    }
}
