using System;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.Level.UI
{
    public class EndLevelWindow : AbstractWindow
    {
        [SerializeField]
        private Text _levelResultText;

        [SerializeField]
        private Button _restartLevelButton;

        [SerializeField]
        private Button _nextLevelButton;

        [SerializeField]
        private Button _mainMenuButton;

        private Action OnRestartLevelClicked;
        private Action OnNextLevelClicked;
        private Action OnMainMenuClicked;

        private void Awake()
        {
            _restartLevelButton.onClick.AddListener(() => OnRestartLevelClicked?.Invoke());
            _nextLevelButton.onClick.AddListener(() => OnNextLevelClicked?.Invoke());
            _mainMenuButton.onClick.AddListener(() => OnMainMenuClicked?.Invoke());
        }

        public void Init(string caption, Action onRestartClickAction, Action onNextLevelClick, Action onMainMenuClick)
        {
            _levelResultText.text = caption;
            OnRestartLevelClicked = onRestartClickAction;
            OnNextLevelClicked = onNextLevelClick;
            OnMainMenuClicked = onMainMenuClick;
        }
    }
}
