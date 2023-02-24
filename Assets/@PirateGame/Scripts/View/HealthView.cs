using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Model;
using Assets.Scripts.Controller;

namespace Assets.Scripts.View
{
    public class HealthView : Shared.View
    {
        public Health Model;

        #region Getters
        public SpriteRenderer GetSpriteRenderer () => GetAndStoreComponent<SpriteRenderer>();
        
        public EnemyView GetEnemyView () => GetAndStoreComponent<EnemyView>();
        #endregion

        void OnEnable ()
        {
            HealthController.Instance.ResetHealth(this);
        }

        void Update()
        {
            if (Model.lastZRotation != transform.eulerAngles.z)
            {
                HealthController.Instance.SetHealthBarRotation(this);
            }
        }
    }
}