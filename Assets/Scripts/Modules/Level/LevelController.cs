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
        private EnemiesManager _enemiesManager;
        private TargetsManager _targetsManager;
        private BulletsManager _bulletsManager;

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

            // player and enemy characters are spawn here
            _playerManager = new PlayerManager(levelConfig, generalConfig.PlayerConfig, _inputManager, _levelView.ArenaTransform);
            _enemiesManager = new EnemiesManager(levelConfig, _levelView.ArenaTransform, generalConfig.ObstaclesHeight);

            _targetsManager = new TargetsManager(_playerManager, _enemiesManager);
            _bulletsManager = new BulletsManager(_playerManager, _enemiesManager, generalConfig.BulletPrefab, _levelView.ArenaTransform, generalConfig.BulletsMaxCount);

            _levelView.StartCoroutine(WaitAndStartLevel(generalConfig.LevelStartCooldownInSeconds));
        }

        public void OuterUpdate(float deltaTime)
        {
            _inputManager.OuterUpdate();
            _enemiesManager.OuterUpdate(deltaTime);
            _playerManager.OuterUpdate(deltaTime);
            _bulletsManager.OuterUpdate(deltaTime);
        }

        private IEnumerator WaitAndStartLevel(int waitTimeSeconds)
        {
            yield return new WaitForSeconds(waitTimeSeconds);
            StartLevel();
        }

        private void StartLevel()
        {
            // activate player and enemy characters
            _playerManager.Activate();
            _enemiesManager.Activate();
        }
    }
}
