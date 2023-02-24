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
    public class Shooter
    {
        public PoolManager cannonBallPool;
        public Transform cannonBallSpawner;
        public float fireRate = 1;
        public float cannonBallVelocity = 1;
        public bool isPlayer;
        public ShootDirection shootDirection;
        
        [HideInInspector] public float fireTimer;
        [HideInInspector] public bool canShoot;
        [HideInInspector] public ShooterView[] shooterViews;
    }
}