using UnityEngine;
using Modules.Level.Character;
using Modules.Level.Bullet;

namespace Modules.Level
{
    public class BulletsManager
    {
        private BulletsPool _bulletsPool;

        public BulletsManager(PlayerManager playerManager,
                              EnemiesManager enemiesManager,
                              BulletView bulletPrefab,
                              Transform arenaTransform,
                              int maxBulletsCount)
        {
            playerManager.OnShotTriggered += ShowShot;
            enemiesManager.OnShotTriggered += ShowShot;

            // create pool
            _bulletsPool = new BulletsPool(bulletPrefab, arenaTransform, maxBulletsCount);

            // make subscriptions
            foreach (BulletController bullet in _bulletsPool.Pool)
            {
                bullet.OnSmashed += OnBulletSmashed;
            }
        }

        public void OuterUpdate(float deltaTime)
        {
            foreach (BulletController bullet in _bulletsPool.Pool)
            {
                if (bullet.State.IsActive)
                {
                    if (bullet.CheckRange())
                    {
                        bullet.Transform.localPosition += bullet.State.Direction * bullet.State.Speed * deltaTime;
                    }
                    else
                    {
                        // drop bullet which flew too far
                        _bulletsPool.Release(bullet);
                    }
                }
            }
        }

        private void ShowShot(WeaponParams weapon, Transform origin, Transform target)
        {
            BulletController bullet = _bulletsPool.Get();

            if (bullet != null)
            {
                Vector3 direction = (target.position - origin.position).normalized;
                Collider shooterCollider = origin.GetComponentInParent<Collider>();
                bullet.State.Init(weapon.Damage, weapon.Range, weapon.Speed, origin.position, direction, shooterCollider);
                bullet.Transform.position = origin.position;
            }
        }
        private void OnBulletSmashed(Transform otherTransform, BulletController bullet)
        {
            CharacterView character = otherTransform.parent.GetComponent<CharacterView>();

            if (character != null)
            {
                // hurt
                character.Smash(bullet.State);
            }

            // drop bullet that smashed
            _bulletsPool.Release(bullet);
        }
    }
}
