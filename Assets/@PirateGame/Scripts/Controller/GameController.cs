using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Enums;
using Assets.Scripts.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Controller
{
    public class GameController : Shared.Controller<GameController>
    {
        public PoolManager explosionPool;
        public PoolManager cannonBallPool;

        private int points;
        private float matchDuration;
        private float enemySpawnRate;
        private float matchTimer;
        private bool hasMatchStarted;

        protected override void Awake()
        {
            if (Instance != null)
            {
                Instance.matchTimer = matchTimer;

                if (SceneManager.GetActiveScene().name == SceneType.Gameplay.ToString())
                {
                    StartGame();
                }
            }
            else
            {
                if (SceneManager.GetActiveScene().name == SceneType.Gameplay.ToString())
                {
                    StartGame();
                }
            }
            base.Awake();
        }

        void Update()
        {
            if (hasMatchStarted)
            {
                matchTimer += Time.deltaTime;

                if (matchDuration < matchTimer)
                {
                    hasMatchStarted = false;
                    matchTimer = 0;
                    GameOver();
                }
            }
        }

        public int GetPoints() => points;

        public void AddPoints(int pointsToAdd) => points += pointsToAdd;

        public float GetEnemySpawnRate() => enemySpawnRate;

        public void SetMatchDuration(float matchDuration) => this.matchDuration = matchDuration;
        public void SetEnemySpawnRate(float enemySpawnRate) => this.enemySpawnRate = enemySpawnRate;

        public bool HasMatchStarted() => hasMatchStarted;

        public void GameOver()
        {
            hasMatchStarted = false;
            UIController.Instance.endGameSection.SetPoints();
            UIController.Instance.ShowEndGameSection();
        }

        public void StartGame(bool isRestartingGame = false)
        {
            Instance.points = 0;
            Instance.hasMatchStarted = true;
            if (!isRestartingGame)
            {
                SpawnController.Instance.ResetEnemyPool();
                cannonBallPool.ResetPool();
                explosionPool.ResetPool();
            }
            else
            {
                matchTimer = 0;
            }
            SpawnController.Instance.SpawnEnemy();
        }
    }
}