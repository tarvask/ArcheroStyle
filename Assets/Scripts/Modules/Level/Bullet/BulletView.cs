using System;
using UnityEngine;

namespace Modules.Level.Bullet
{
    public class BulletView : MonoBehaviour
    {
        public event Action<Collider> OnSmashed;

        private void OnTriggerEnter(Collider other)
        {
            OnSmashed?.Invoke(other);
        }
    }
}
