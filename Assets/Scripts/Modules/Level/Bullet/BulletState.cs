using UnityEngine;

namespace Modules.Level.Bullet
{
    public class BulletState
    {
        public int Damage { get; private set; }
        public float Range { get; private set; }
        public float Speed { get; private set; }
        public Vector3 Origin { get; private set; }
        public Vector3 Direction { get; private set; }
        public Collider AuthorCollider { get; private set; }

        public bool IsActive { get; private set; }

        // create with empty state
        // init by demand
        public BulletState()
        {
            IsActive = false;
        }

        public void Init(int damage, float range, float speed, Vector3 origin, Vector3 direction, Collider shooterCollider)
        {
            Damage = damage;
            Range = range;
            Speed = speed;
            Origin = origin;
            Direction = direction;
            AuthorCollider = shooterCollider;
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
