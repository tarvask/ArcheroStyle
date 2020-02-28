using System.Collections.Generic;
using UnityEngine;
using Modules.Level.Character;

namespace Modules.Level
{
    public static class EnemiesSpawner
    {
        public static List<Character.CharacterController> Spawn(EnemyParams[] enemiesParams,
                                                Transform arenaTransform,
                                                Vector2Int arenaSize,
                                                int bottomSpawnBound,
                                                float obstaclesHeight)
        {
            List<Character.CharacterController> result = new List<Character.CharacterController>();
            List<Vector3> possibleSpawnPoints = GetPossibleSpawnPoints(arenaSize, bottomSpawnBound);

            foreach (EnemyParams singleEnemyParams in enemiesParams)
            {
                int randomSpawnPointNumber = Random.Range(0, possibleSpawnPoints.Count);

                Vector3 spawnPoint = possibleSpawnPoints[randomSpawnPointNumber];
                // remove used spawn point
                possibleSpawnPoints.RemoveAt(randomSpawnPointNumber);

                // spawn single enemy
                Character.CharacterController enemy = SpawnSingleEnemy(singleEnemyParams, arenaTransform, spawnPoint, obstaclesHeight);
                result.Add(enemy);
            }

            return result;
        }

        private static List<Vector3> GetPossibleSpawnPoints(Vector2Int arenaSize, int bottomSpawnBound)
        {
            List<Vector3> possibleSpawnPoints = new List<Vector3>();

            // do not assume last meter to stay inside
            int topSpawnBound = arenaSize.y - 1;
            int rightSpawnBound = arenaSize.x - 1;

            for (int i = bottomSpawnBound; i < topSpawnBound; i++)
            {
                for (int j = 0; j < rightSpawnBound; j++)
                {
                    possibleSpawnPoints.Add(new Vector3(j + 0.5f, 0, i + 0.5f));
                }
            }

            return possibleSpawnPoints;
        }

        private static Character.CharacterController SpawnSingleEnemy(EnemyParams enemyParams,
                                                      Transform arenaTransform,
                                                      Vector3 spawnPoint,
                                                      float obstaclesHeight)
        {
            CharacterView enemyView = Object.Instantiate(enemyParams.CharacterViewPrefab, arenaTransform);

            if (enemyParams.IsFlying)
            {
                //spawnPoint += new Vector3(0, obstaclesHeight, 0);
            }

            enemyView.transform.localPosition = spawnPoint;
            enemyView.transform.localRotation = Quaternion.Euler(0, -180, 0);
            Character.CharacterController enemyController = new Character.CharacterController(enemyParams, enemyView);

            return enemyController;
        }
    }
}
