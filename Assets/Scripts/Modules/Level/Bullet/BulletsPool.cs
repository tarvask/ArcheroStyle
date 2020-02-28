using UnityEngine;

namespace Modules.Level.Bullet
{
    public class BulletsPool
    {
        private Transform _poolTransform;

        private BulletController[] _pool;
        public BulletController[] Pool => _pool;

        public BulletsPool(BulletView bulletPrefab, Transform arenaTransform, int maxBulletsCount)
        {
            _poolTransform = new GameObject("BulletsPool").transform;
            _poolTransform.SetParent(arenaTransform);
            _poolTransform.localPosition = Vector3.zero;
            _poolTransform.localScale = Vector3.one;

            _pool = new BulletController[maxBulletsCount];

            for (int i = 0; i < maxBulletsCount; i++)
            {
                BulletView bulletView = Object.Instantiate(bulletPrefab, _poolTransform);
                bulletView.gameObject.SetActive(false);
                _pool[i] = new BulletController(bulletView);
            }
        }

        public BulletController Get()
        {
            BulletController bullet = null;

            for (int i = 0; i < _pool.Length; i++)
            {
                if (!_pool[i].State.IsActive)
                {
                    bullet = _pool[i];
                    bullet.State.Activate();
                    bullet.Transform.gameObject.SetActive(true);
                    break;
                }
            }

            return bullet;
        }

        public void Release(BulletController bullet)
        {
            bullet.State.Release();
            bullet.Transform.gameObject.SetActive(false);
        }
    }
}
