using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Model;
using Assets.Scripts.Controller;
using Assets.Scripts.Enums;

namespace Assets.Scripts.View
{
    public class ShooterView : Shared.View
    {
        public Shooter Model;

        #region Getters
        public EnemyView GetEnemyView () => GetAndStoreComponent<EnemyView>();
        #endregion

        void Awake ()
        {
            Model.shooterViews = GetComponentsInChildren<ShooterView>();
        }

        void OnDisable()
        {
            if (!Model.isPlayer)
            {
                EnemyView enemyView = GetEnemyView();
                if (enemyView != null)
                {
                    enemyView.Model.isShooting = false;
                }
            }

            CancelInvoke();
        }

        void Update()
        {
            if (!Model.canShoot)
            {
                Model.fireTimer += Time.deltaTime;
                if (Model.fireRate < Model.fireTimer)
                {
                    Model.canShoot = true;
                    Model.fireTimer = 0;
                }
            }
        }

        public void ShootAllContinously()
        {
            InvokeRepeating("EnemyShootAll", Model.fireTimer, Model.fireRate);
        }

        public void PlayerShootAll(ShootDirection shootDirection)
        {
            if (shootDirection == Model.shootDirection &&
                Model.canShoot)
            {
                ShooterController.Instance.Shoot(this);
            }
        }

        private void EnemyShootAll ()
        {
            ShooterController.Instance.Shoot(this);
        }
    }
}