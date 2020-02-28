using UnityEngine;
using Modules.Level;
using Modules.Level.Character;
using Modules.Level.Bullet;

// [CreateAssetMenu]
// commented to avoid creating another instance of Application Config
public class ApplicationConfig : ScriptableObject
{
    [SerializeField]
    private LevelParams[] _levels;
    public LevelParams[] Levels => _levels;

    [SerializeField]
    private int _levelStartCooldownInSeconds = 3;
    public int LevelStartCooldownInSeconds => _levelStartCooldownInSeconds;

    [SerializeField]
    private float _obstaclesHeight = 3f;
    public float ObstaclesHeight => _obstaclesHeight;

    [SerializeField]
    private CharacterParams _playerConfig;
    public CharacterParams PlayerConfig => _playerConfig;

    [SerializeField]
    private BulletView _bulletPrefab;
    public BulletView BulletPrefab => _bulletPrefab;

    [SerializeField]
    private int _bulletsMaxCount;
    public int BulletsMaxCount => _bulletsMaxCount;

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
