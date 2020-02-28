using System;
using UnityEngine;

namespace Modules.Level
{
    public class EscapeZoneView : MonoBehaviour
    {
        public event Action<Collider> OnZoneEntered;
        public event Action<Collider> OnZoneLeft;

        private void OnTriggerEnter(Collider other)
        {
            OnZoneEntered?.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            OnZoneLeft?.Invoke(other);
        }
    }
}
