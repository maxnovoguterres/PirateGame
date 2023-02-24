using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.View;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class HealthController : Shared.Controller<HealthController>
    {
        public void GetDamage(HealthView View, int damage, Vector2 collisionPosition)
        {
            if (View.Model.currentHealth > 0)
            {
                View.Model.currentHealth -= damage;

                SpriteRenderer sr = View.GetSpriteRenderer();
                float healthPercentage = (float)View.Model.currentHealth / View.Model.maxHealth * 100;
                foreach (KeyValuePair<int, Sprite> pair in View.Model.healthSpritesInPercentage)
                {
                    if (pair.Key > healthPercentage)
                    {
                        sr.sprite = pair.Value;
                        break;
                    }
                }
                View.Model.healthBar.value = healthPercentage;
                if (healthPercentage <= View.Model.badHealthPercentage &&
                    !View.Model.firesVFX.activeSelf)
                {
                    View.Model.firesVFX.SetActive(true);
                }

                if (View.Model.currentHealth <= 0)
                {
                    View.Model.currentHealth = 0;
                    if (View.Model.isPlayer)
                    {
                        GameController.Instance.GameOver();
                        View.gameObject.SetActive(false);
                    }
                    else
                    {
                        EnemyView enemyView = View.GetEnemyView();
                        GameController.Instance.AddPoints(enemyView.Model.points);
                        enemyView.Model.pool.Despawn(enemyView.gameObject);
                    }
                    GameObject deathExplosionObj = GameController.Instance.explosionPool.Spawn(View.transform.position, Quaternion.identity);
                    deathExplosionObj.transform.localScale *= 2;
                    GameController.Instance.explosionPool.Despawn(deathExplosionObj, 0.09f);
                }

                GameObject shootExplosionObj = GameController.Instance.explosionPool.Spawn(collisionPosition, Quaternion.identity);
                GameController.Instance.explosionPool.Despawn(shootExplosionObj, 0.09f);
            }
        }

        public void SetHealthBarRotation(HealthView View)
        {
            View.Model.healthBar.transform.parent.localEulerAngles = new Vector3(0, 0, -View.transform.eulerAngles.z);
            View.Model.lastZRotation = View.transform.eulerAngles.z;
        }

        public void ResetHealth(HealthView View)
        {
            View.Model.currentHealth = View.Model.maxHealth;
            float healthPercentage = (float)View.Model.currentHealth / View.Model.maxHealth * 100;
            View.Model.healthBar.value = healthPercentage;
            View.Model.lastZRotation = 0;
            View.Model.healthBar.transform.parent.rotation = Quaternion.identity;
            View.Model.firesVFX.SetActive(false);
        }
    }
}