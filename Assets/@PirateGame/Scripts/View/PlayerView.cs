using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Controller;
using Assets.Scripts.Enums;
using Assets.Scripts.Model;
using UnityEngine;

namespace Assets.Scripts.View
{
    public class PlayerView : Shared.View
    {
        public Player Model;

        #region Getters
        public HealthView GetHealthView () => GetAndStoreComponent<HealthView>();
        public Rigidbody2D GetRigidbody () => GetAndStoreComponent<Rigidbody2D>();
        #endregion

        void Awake()
        {
            Model.shooterViews = GetComponentsInChildren<ShooterView>();
        }

        void FixedUpdate ()
        {
            if (InputController.Instance.GetFrontShoot() &&
                GameController.Instance.HasMatchStarted())
            {
                foreach (ShooterView shooterView in Model.shooterViews)
                {
                    shooterView.PlayerShootAll(ShootDirection.Front);
                }
                InputController.Instance.SetFrontShoot(false);
            }

            if (InputController.Instance.GetSideShoot() &&
                GameController.Instance.HasMatchStarted())
            {
                foreach (ShooterView shooterView in Model.shooterViews)
                {
                    shooterView.PlayerShootAll(ShootDirection.Side);
                }
                InputController.Instance.SetSideShoot(false);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("KillPlayer") &&
                GameController.Instance.HasMatchStarted())
            {
                HealthView healthView = GetHealthView();
                RaycastHit2D hit = Physics2D.Raycast(other.transform.position, transform.position);
                Vector2 collisionPosition = hit.point;
                HealthController.Instance.GetDamage(healthView, 1, collisionPosition);

                EnemyView enemyView = other.transform.GetComponentInParent<EnemyView>();
                if (other.transform.gameObject.layer == LayerMask.NameToLayer("Projectile"))
                {
                    Projectile projectile = other.transform.GetComponent<Projectile>();
                    projectile.pool.Despawn(projectile.gameObject);
                }
                if (enemyView != null &&
                    enemyView.Model.enemyType == EnemyType.Chaser)
                {
                    enemyView.Model.pool.Despawn(enemyView.gameObject);
                }
            }
        }
    }
}
