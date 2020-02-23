using UnityEngine;
using Modules;
using Modules.MainMenu;
using Modules.Level;

public class ApplicationManager : MonoBehaviour
{
    public enum ApplicationState
    {
        Warming,
        Loading,
        MainMenu,
        InGame
    }

    [SerializeField]
    private ApplicationConfig _applicationConfig;

    private ApplicationState _appState;
    private ModuleLoader _moduleLoader;
    private MainMenuController _mainMenuController;
    private LevelController _levelController;

    private void Awake()
    {
        _appState = ApplicationState.Warming;

        _moduleLoader = new ModuleLoader(this);
        _moduleLoader.OnMainMenuLoaded += InitMainMenu;
        _moduleLoader.OnLevelLoaded += InitGame;

        LoadMainMenu();
    }

    private void LoadMainMenu()
    {
        if (_appState != ApplicationState.MainMenu && _appState != ApplicationState.Loading)
        {
            _appState = ApplicationState.Loading;
            _moduleLoader.LoadMainMenu();
        }
    }

    private void InitMainMenu()
    {
        _mainMenuController = new MainMenuController(_applicationConfig);
        _mainMenuController.OnLevelClicked += LoadGame;
        _mainMenuController.OnExitGameClicked += ExitGame;

        _appState = ApplicationState.MainMenu;
    }

    private void LoadGame(LevelParams levelConfig)
    {
        if (_appState != ApplicationState.Loading)
        {
            _appState = ApplicationState.Loading;
            _moduleLoader.LoadGame(levelConfig);
        }
    }

    private void InitGame(LevelParams levelConfig)
    {
        _levelController = new LevelController(levelConfig);
        _levelController.OnRestartLevelClicked += LoadGame;
        _levelController.OnNextLevelClicked += LoadNextLevel;
        _levelController.OnQuitGameClicked += LoadMainMenu;

        _appState = ApplicationState.InGame;
    }

    private void LoadNextLevel(LevelParams currentLevelConfig)
    {
        LevelParams nextLevelConfig = _applicationConfig.GetNextLevel(currentLevelConfig);
        LoadGame(nextLevelConfig);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
