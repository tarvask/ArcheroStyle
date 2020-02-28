using System.Collections.Generic;

namespace Modules.Level
{
    public class TargetsManager
    {
        // dependencies
        private Character.CharacterController _player;
        private List<Character.CharacterController> _enemies;

        public TargetsManager(PlayerManager playerManager, EnemiesManager enemiesManager)
        {
            // resolve dependencies
            _player = playerManager.Player;
            _enemies = enemiesManager.Enemies;

            playerManager.OnAimingStarted += FindEnemy;
            enemiesManager.SetPlayer(_player);
        }

        private void FindEnemy()
        {
            _player.SetTarget(FindClosestAliveEnemy());
        }

        private Character.CharacterController FindClosestAliveEnemy()
        {
            float minSqrDistance = -1;
            Character.CharacterController closestEnemy = null;

            foreach (Character.CharacterController enemy in _enemies)
            {
                if (enemy.IsAlive)
                {
                    float sqrDistance = (enemy.ArenaPosition - _player.ArenaPosition).sqrMagnitude;

                    if (sqrDistance < minSqrDistance || minSqrDistance < 0)
                    {
                        minSqrDistance = sqrDistance;
                        closestEnemy = enemy;
                    }
                }
            }

            return closestEnemy;
        }
    }
}
