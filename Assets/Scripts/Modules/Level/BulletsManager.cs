using UnityEngine;
using Modules.Level.Character;
using Modules.Level.Bullet;

namespace Modules.Level
{
    public class BulletsManager
    {
        private BulletsPool _bulletsPool;
        private float _bulletSpeed;

        public BulletsManager(PlayerManager playerManager,
                              EnemiesManager enemiesManager,
                              GameObject bulletPrefab,
                              Transform arenaTransform,
                              int maxBulletsCount)
        {
            playerManager.OnShotTriggered += ShowShot;
            enemiesManager.OnShotTriggered += ShowShot;

            _bulletsPool = new BulletsPool(bulletPrefab, arenaTransform, maxBulletsCount);
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
                bullet.State.Init(weapon.Damage, weapon.Range, weapon.Speed, origin.position, direction);
                bullet.Transform.position = origin.position;
            }
        }
    }
}
