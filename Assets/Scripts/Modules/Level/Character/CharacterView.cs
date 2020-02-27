using UnityEngine;

namespace Modules.Level.Character
{
    public class CharacterView : MonoBehaviour
    {
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        public void ChangePosition(Vector3 deltaPosition)
        {
            _transform.localPosition += deltaPosition;
        }
    }
}
