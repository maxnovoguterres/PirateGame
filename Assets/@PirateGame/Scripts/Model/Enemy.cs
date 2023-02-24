using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Enums;
using Assets.Scripts.Managers;
using Assets.Scripts.View;
using UnityEngine;

namespace Assets.Scripts.Model
{
    [Serializable]
    public class Enemy
    {
        public EnemyType enemyType;
        public int points;
        public float detectionRange = 10f;

        [HideInInspector] public ShooterView[] shooterViews;
        [HideInInspector] public bool isShooting;
        [HideInInspector] public PoolManager pool;
    }
}