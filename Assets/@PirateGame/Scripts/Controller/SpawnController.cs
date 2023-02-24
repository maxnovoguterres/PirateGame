using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Enums;
using Assets.Scripts.Helpers;
using Assets.Scripts.Managers;
using Assets.Scripts.View;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Controller
{
    public class SpawnController : Shared.Controller<SpawnController>
    {
        public List<PoolManager> enemies;
        public Vector2 maxPositionToSpawn;
        public Vector2 minPositionToSpawn;
        public float radiusToDetectNearObjects;
        private EnemySpawnParent enemySpawnParent;

        public void ResetEnemyPool()
        {
            foreach (PoolManager enemy in enemies)
            {
                enemy.ResetPool();
            }
        }

        public void SpawnEnemy()
        {
            StartCoroutine(SpawnEnemyCoroutine());
        }

        private IEnumerator SpawnEnemyCoroutine()
        {
            while (GameController.Instance.HasMatchStarted())
            {
                bool hasEnemySpawned = false;

                while (!hasEnemySpawned)
                {
                    float angle = RandomExtensions.GetRandomFloat(0f, 360f);
                    Vector2 position = new Vector2(RandomExtensions.GetRandomFloat(minPositionToSpawn.x, maxPositionToSpawn.x), RandomExtensions.GetRandomFloat(minPositionToSpawn.y, maxPositionToSpawn.y));
                    Quaternion rotation = Quaternion.Euler(0f, 0f, angle);

                    Collider2D[] colliders = Physics2D.OverlapCircleAll(position, radiusToDetectNearObjects);
                    if (colliders.Length == 0)
                    {
                        PoolManager enemy = enemies[RandomExtensions.GetRandomInt(0, enemies.Count)];
                        GameObject enemySpawned = enemy.Spawn(position, rotation);
                        EnemyView enemyView = enemySpawned.GetComponent<EnemyView>();
                        enemyView.Model.pool = enemy;
                        hasEnemySpawned = true;
                        yield return new WaitForSeconds(GameController.Instance.GetEnemySpawnRate());
                    }
                }
            }
        }
    }
}