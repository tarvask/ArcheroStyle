using System;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.Level
{
    public class LevelView : MonoBehaviour
    {
        public event Action OnRestartLevelClicked;
        public event Action OnNextLevelClicked;
        public event Action OnMainMenuClicked;

        [SerializeField]
        private HUD _hud;
        public HUD HUD => _hud;

        [SerializeField]
        private IWindow[] _levelWindows;

        [SerializeField]
        private Button _restartLevelButton;

        [SerializeField]
        private Button _nextLevelButton;

        [SerializeField]
        private Button _mainMenuButton;

        [Space]
        [SerializeField]
        private Transform _arenaTransform;
        public Transform ArenaTransform => _arenaTransform;

        private void Awake()
        {
            _restartLevelButton.onClick.AddListener(() => OnRestartLevelClicked?.Invoke());
            _nextLevelButton.onClick.AddListener(() => OnNextLevelClicked?.Invoke());
            _mainMenuButton.onClick.AddListener(() => OnMainMenuClicked?.Invoke());
        }

        public T GetWindow<T>() where T : MonoBehaviour, IWindow
        {
            foreach (IWindow window in _levelWindows)
            {
                if (window is T)
                {
                    return (T)window;
                }
            }

            return null;
        }
    }
}
