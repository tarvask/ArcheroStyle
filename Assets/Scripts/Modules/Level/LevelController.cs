using System;
using System.Collections;
using UnityEngine;

namespace Modules.Level
{
    public class LevelController
    {
        // interface
        public event Action<LevelParams> OnRestartLevelClicked;
        public event Action<LevelParams> OnNextLevelClicked;
        public event Action OnQuitGameClicked;

        // dependencies
        private LevelParams _levelConfig;
        private LevelView _levelView;

        // members
        private InputManager _inputManager;
        private PlayerManager _playerManager;
        private object _enemiesManager;

        public LevelController(LevelParams levelConfig, ApplicationConfig generalConfig)
        {
            // resolve dependencies
            _levelConfig = levelConfig;
            _levelView = UnityEngine.Object.FindObjectOfType<LevelView>();

            _levelView.HUD.Init();
            _levelView.OnRestartLevelClicked += () => OnRestartLevelClicked?.Invoke(_levelConfig);
            _levelView.OnNextLevelClicked += () => OnNextLevelClicked?.Invoke(_levelConfig);
            _levelView.OnMainMenuClicked += () => OnQuitGameClicked?.Invoke();

            _inputManager = new InputManager(_levelView.HUD);


            _playerManager = new PlayerManager(levelConfig, generalConfig.PlayerConfig, _inputManager, _levelView.ArenaTransform);

            // spawn player and enemy characters

            _levelView.StartCoroutine(WaitAndStartLevel(generalConfig.LevelStartCooldownInSeconds));
        }

        public void OuterUpdate(float deltaTime)
        {
            _inputManager.OuterUpdate();

            _playerManager.OuterUpdate(deltaTime);
        }

        private IEnumerator WaitAndStartLevel(int waitTimeSeconds)
        {
            yield return new WaitForSeconds(waitTimeSeconds);
            StartLevel();
        }

        private void StartLevel()
        {
            // activate player and enemy characters
        }
    }
}
