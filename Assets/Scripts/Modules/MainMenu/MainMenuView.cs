using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Modules.Level;

namespace Modules.MainMenu
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField]
        private Button _menuButtonPrefab;

        [SerializeField]
        private Transform _buttonsRoot;

        public event Action<LevelParams> OnLevelClicked;
        public event Action OnExitGameClicked;

        public void Init(LevelParams[] levels)
        {
            // level buttons
            foreach (LevelParams levelConfig in levels)
            {
                LevelButton levelButton = CreateLevelButton(levelConfig);
                levelButton.OnLevelButtonClicked += (l) => OnLevelClicked?.Invoke(l);
            }

            // credits button
            Button creditsButton = CreateMenuButton("Credits");
            creditsButton.onClick.AddListener(() => { });

            // exit game button
            Button exitGameButton = CreateMenuButton("Exit");
            exitGameButton.onClick.AddListener(() => OnExitGameClicked?.Invoke());
        }

        private LevelButton CreateLevelButton(LevelParams levelConfig)
        {
            Button buttonInstance = CreateMenuButton(levelConfig.SceneName);
            LevelButton result = new LevelButton(buttonInstance, levelConfig);
            return result;
        }

        private Button CreateMenuButton(string buttonText)
        {
            Button result = Instantiate(_menuButtonPrefab, _buttonsRoot);
            result.GetComponentInChildren<Text>().text = buttonText;
            return result;
        }

        private class LevelButton
        {
            public event Action<LevelParams> OnLevelButtonClicked;

            private readonly Button _button;
            private readonly LevelParams _level;

            public LevelButton(Button button, LevelParams level)
            {
                _button = button;
                _level = level;

                _button.onClick.AddListener(() => OnLevelButtonClicked?.Invoke(_level));
            }

            private void OnLevelButtonClickedHandler()
            {
                OnLevelButtonClicked?.Invoke(_level);
            }
        }
    }
}
