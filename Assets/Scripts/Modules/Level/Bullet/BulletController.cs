using System;
using UnityEngine;

namespace Modules.Level.Bullet
{
    public class BulletController
    {
        public BulletState State { get; }
        public Transform Transform { get; }

        public event Action<Transform, BulletController> OnSmashed; 

        public BulletController(BulletView view)
        {
            State = new BulletState();
            Transform = view.transform;
            view.OnSmashed += CheckCollision;
        }

        public bool CheckRange()
        {
            // compare max range and current flight length
            return ((Transform.localPosition - State.Origin).sqrMagnitude < State.Range * State.Range);
        }

        public void CheckCollision(Collider otherCollider)
        {
            // bullet collides with shooting character,
            // so don't take suck collisions into account
            if (otherCollider != State.AuthorCollider)
            {
                OnSmashed?.Invoke(otherCollider.transform, this);
            }
        }
    }
}
