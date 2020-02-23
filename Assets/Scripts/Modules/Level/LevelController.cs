using System;

namespace Modules.Level
{
    public class LevelController
    {
        public event Action<LevelParams> OnRestartLevelClicked;
        public event Action<LevelParams> OnNextLevelClicked;
        public event Action OnQuitGameClicked;

        private LevelParams _levelConfig;
        private LevelView _levelView;

        public LevelController(LevelParams levelConfig)
        {
            _levelConfig = levelConfig;
            _levelView = UnityEngine.Object.FindObjectOfType<LevelView>();
            _levelView.OnRestartLevelClicked += () => OnRestartLevelClicked?.Invoke(_levelConfig);
            _levelView.OnNextLevelClicked += () => OnNextLevelClicked?.Invoke(_levelConfig);
            _levelView.OnMainMenuClicked += () => OnQuitGameClicked?.Invoke();
        }
    }
}
