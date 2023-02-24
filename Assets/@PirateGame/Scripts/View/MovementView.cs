using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Model;
using Assets.Scripts.Controller;

namespace Assets.Scripts.View
{
    public class MovementView : Shared.View
    {
        public Movement Model;

        #region Getters
        public EnemyView GetEnemyView () => GetAndStoreComponent<EnemyView>();
        public Rigidbody2D GetRigidbody () => GetAndStoreComponent<Rigidbody2D>();
        #endregion

        void Awake()
        {
            Model.target = FindObjectOfType<PlayerView>().transform;
        }

        private void Update ()
        {
            if (GameController.Instance.HasMatchStarted())
            {
                MovementController.Instance.Rotate(this);
            }
        }

        private void FixedUpdate ()
        {
            if (GameController.Instance.HasMatchStarted())
            {
                MovementController.Instance.Move(this);
            }
        }
    }
}