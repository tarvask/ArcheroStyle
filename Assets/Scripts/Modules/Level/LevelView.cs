using UnityEngine;
using Modules.Level.UI;

namespace Modules.Level
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField]
        private HUD _hud;
        public HUD HUD => _hud;

        [SerializeField]
        private Transform _windowsRoot;

        [SerializeField]
        private AbstractWindow[] _levelWindows;

        [Space]
        [SerializeField]
        private Transform _arenaTransform;
        public Transform ArenaTransform => _arenaTransform;

        [SerializeField]
        private EscapeZoneView _escapeZone;
        public EscapeZoneView EscapeZone => _escapeZone;

        public T GetWindow<T>() where T : AbstractWindow
        {
            foreach (AbstractWindow window in _levelWindows)
            {
                if (window is T)
                {
                    return (T)Instantiate(window, _windowsRoot);
                }
            }

            return null;
        }
    }
}
