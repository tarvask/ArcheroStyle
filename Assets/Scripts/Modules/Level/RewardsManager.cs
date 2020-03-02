using System;
using Modules.Level.Character;

namespace Modules.Level
{
    public class RewardsManager
    {
        public event Action<int> OnCoinsAdded;

        // FIXME: should be replaced by Level or Application Config parameter
        // depending on game design
        private const int COINS_PER_ENEMY = 10;

        private int _coins;

        public RewardsManager(EnemiesManager enemiesManager)
        {
            enemiesManager.OnEnemyKilled += GiveEnemyReward;
        }

        private void GiveEnemyReward(CharacterParams enemyConfig)
        {
            _coins += COINS_PER_ENEMY;
            OnCoinsAdded?.Invoke(_coins);
        }
    }
}
