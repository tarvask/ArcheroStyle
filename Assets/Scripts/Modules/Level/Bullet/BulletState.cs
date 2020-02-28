using UnityEngine;

namespace Modules.Level.Bullet
{
    public class BulletState
    {
        public float Damage { get; private set; }
        public float Range { get; private set; }
        public float Speed { get; private set; }
        public Vector3 Origin { get; private set; }
        public Vector3 Direction { get; private set; }

        public bool IsActive { get; private set; }

        // create with empty state
        // init by demand
        public BulletState()
        {
            IsActive = false;
        }

        public void Init(float damage, float range, float speed, Vector3 origin, Vector3 direction)
        {
            Damage = damage;
            Range = range;
            Speed = speed;
            Origin = origin;
            Direction = direction;
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Release()
        {
            IsActive = false;
        }
    }
}
