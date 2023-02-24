using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Enums;
using Assets.Scripts.View;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class ShooterController : Shared.Controller<ShooterController>
    {
        public float timeToDespawnCannonBall;

        private const string killPlayerTag = "KillPlayer";
        private const string killEnemyTag = "KillEnemy";

        public void Shoot(ShooterView View)
        {
            GameObject cannonBall = View.Model.cannonBallPool.Spawn(View.Model.cannonBallSpawner.position, Quaternion.identity);
            cannonBall.tag = View.Model.isPlayer ? killEnemyTag : killPlayerTag;
            Rigidbody2D rb = cannonBall.GetComponent<Rigidbody2D>();
            rb.AddForce(View.transform.right * View.Model.cannonBallVelocity, ForceMode2D.Force);
            View.Model.canShoot = false;
            View.Model.cannonBallPool.Despawn(cannonBall, timeToDespawnCannonBall);
            cannonBall.GetComponent<Projectile>().pool = View.Model.cannonBallPool;
        }
    }
}