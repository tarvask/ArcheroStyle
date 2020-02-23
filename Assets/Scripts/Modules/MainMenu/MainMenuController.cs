using System;
using Modules.Level;

namespace Modules.MainMenu
{
    public class MainMenuController
    {
        public event Action<LevelParams> OnLevelClicked;
        public event Action OnExitGameClicked;

        private MainMenuView _mainMenuView;

        public MainMenuController(ApplicationConfig applicationConfig)
        {
            _mainMenuView = UnityEngine.Object.FindObjectOfType<MainMenuView>();
            _mainMenuView.Init(applicationConfig.Levels);
            _mainMenuView.OnLevelClicked += OnMainMenuLevelClicked;
            _mainMenuView.OnExitGameClicked += OnMainMenuExitGameClicked;
        }

        private void OnMainMenuLevelClicked(LevelParams level)
        {
            OnLevelClicked?.Invoke(level);
        }

        private void OnMainMenuExitGameClicked()
        {
            OnExitGameClicked?.Invoke();
        }
    }
}
