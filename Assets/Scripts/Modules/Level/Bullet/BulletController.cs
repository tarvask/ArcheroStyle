using UnityEngine;

namespace Modules.Level.Bullet
{
    public class BulletController
    {
        public BulletState State { get; }
        public Transform Transform { get; }

        public BulletController(GameObject view)
        {
            State = new BulletState();
            Transform = view.transform;
        }

        public bool CheckRange()
        {
            return ((Transform.localPosition - State.Origin).sqrMagnitude < State.Range * State.Range);
        }
    }
}
