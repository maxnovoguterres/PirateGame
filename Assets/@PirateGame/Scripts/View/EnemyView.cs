using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Model;
using Assets.Scripts.Controller;
using Assets.Scripts.Enums;

namespace Assets.Scripts.View
{
    public class EnemyView : Shared.View
    {
        public Enemy Model;

        #region Getters
        public HealthView GetHealthView () => GetAndStoreComponent<HealthView>();
        public MovementView GetMovementView() => GetAndStoreComponent<MovementView>();
        #endregion
        
        void Awake()
        {
            if (Model.enemyType == EnemyType.Shooter)
            {
                Model.shooterViews = GetComponentsInChildren<ShooterView>();
            }
        }

        void Update ()
        {
            EnemyController.Instance.ChasePlayer(this);

            if (!GameController.Instance.HasMatchStarted() &&
                Model.isShooting)
            {
                StopShooting();
            }
        }

        public void StartShooting()
        {
            Model.isShooting = true;
            foreach (ShooterView shooterView in Model.shooterViews)
            {
                shooterView.ShootAllContinously();
            }
        }

        public void StopShooting()
        {
            Model.isShooting = false;
            foreach (ShooterView shooterView in Model.shooterViews)
            {
                shooterView.CancelInvoke();
            }
        }

        private void OnTriggerEnter2D (Collider2D other)
        {
            if (other.CompareTag("KillEnemy") &&
                GameController.Instance.HasMatchStarted())
            {
                HealthView healthView = GetHealthView();
                RaycastHit2D hit = Physics2D.Raycast(other.transform.position, transform.position);
                Vector2 collisionPosition = hit.point;
                HealthController.Instance.GetDamage(healthView, 1, collisionPosition);

                if (other.transform.gameObject.layer == LayerMask.NameToLayer("Projectile"))
                {
                    Projectile projectile = other.transform.GetComponent<Projectile>();
                    projectile.pool.Despawn(projectile.gameObject);
                }
            }
        }
    }
}