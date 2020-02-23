using UnityEngine;
using Modules.Level;

// [CreateAssetMenu]
// commented to avoid creating another instance of Application Config
public class ApplicationConfig : ScriptableObject
{
    [SerializeField]
    private LevelParams[] _levels;
    public LevelParams[] Levels => _levels;

    // levels are looped
    public LevelParams GetNextLevel(LevelParams levelConfig)
    {
        int levelIndex = System.Array.IndexOf(_levels, levelConfig);
        int nextLevelIndex;

        if (levelIndex < _levels.Length - 1)
        {
            nextLevelIndex = levelIndex + 1;
        }
        else
        {
            nextLevelIndex = 0;
        }

        return _levels[nextLevelIndex];
    }
}
