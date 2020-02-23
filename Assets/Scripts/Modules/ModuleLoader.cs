using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Modules.Level;

namespace Modules
{
    public class ModuleLoader
    {
        public Action OnMainMenuLoaded;
        public Action<LevelParams> OnLevelLoaded;

        private ApplicationManager _applicationManager;
        private LevelParams _currentLevel;

        // async scene load stuff
        private AsyncOperation _asyncLevelSceneLoad;

        public ModuleLoader(ApplicationManager applicationManager)
        {
            _applicationManager = applicationManager;
        }

        public void LoadMainMenu()
        {
            _applicationManager.StartCoroutine(LoadMainMenuAsync());
        }

        private IEnumerator LoadMainMenuAsync()
        {
            // unload game scenes
            if (_currentLevel != null)
            {
                _applicationManager.StartCoroutine(UnloadLevelSceneAsync());
            }

            _currentLevel = null;

            yield return SceneManager.LoadSceneAsync(ApplicationResources.SCENE_PATH_MAIN_MENU, LoadSceneMode.Additive);

            // is needed for scene activation
            yield return null;

            // make other preparations
            OnMainMenuLoaded?.Invoke();
        }

        public void LoadGame(LevelParams levelConfig)
        {
            // unload game scenes
            if (_currentLevel != null)
            {
                _applicationManager.StartCoroutine(UnloadLevelSceneAsync());
            }

            _currentLevel = null;
            _applicationManager.StartCoroutine(LoadGameAsync(levelConfig));
        }

        private IEnumerator LoadGameAsync(LevelParams levelConfig)
        {
            _currentLevel = levelConfig;
            yield return UnloadMainMenuAsync();

            yield return LoadLevelSceneAsync();

            // show both game scene parts
            _asyncLevelSceneLoad.allowSceneActivation = true;

            Scene levelScene = SceneManager.GetSceneByName(_currentLevel.SceneName);

            // is needed for scene activation
            yield return new WaitUntil(() => levelScene.isLoaded);

            OnLevelLoaded?.Invoke(_currentLevel);
        }

        private IEnumerator UnloadMainMenuAsync()
        {
            Scene mainMenuScene = SceneManager.GetSceneByName(ApplicationResources.SCENE_PATH_MAIN_MENU);

            if (mainMenuScene.isLoaded)
            {
                SceneManager.UnloadSceneAsync(ApplicationResources.SCENE_PATH_MAIN_MENU);
            }

            yield return null;
        }

        private IEnumerator LoadLevelSceneAsync()
        {
            _asyncLevelSceneLoad = SceneManager.LoadSceneAsync(_currentLevel.SceneName, LoadSceneMode.Additive);
            _asyncLevelSceneLoad.allowSceneActivation = false;

            while (!_asyncLevelSceneLoad.isDone)
            {
                if (_asyncLevelSceneLoad.progress >= 0.9f)
                {
                    yield break;
                }

                yield return null;
            }
        }

        private IEnumerator UnloadLevelSceneAsync()
        {
            Scene levelScene = SceneManager.GetSceneByName(_currentLevel.SceneName);

            if (levelScene.isLoaded)
            {
                SceneManager.UnloadSceneAsync(_currentLevel.SceneName);
            }

            yield return null;
        }
    }
}
