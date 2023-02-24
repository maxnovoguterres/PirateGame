using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Controller;
using UnityEngine;
using Bounds = Assets.Scripts.Model.Bounds;

namespace Assets.Scripts.View
{
    public class BoundsView : Shared.View
    {
        public Bounds Model;

        #region Getters
        public SpriteRenderer GetSpriteRenderer ()
        {
            return GetAndStoreComponent<SpriteRenderer>();
        }
        #endregion

        private void Start ()
        {
            BoundsController.Instance.SetBounds(this);
        }

        private void LateUpdate()
        {
            BoundsController.Instance.CheckBounds(this);
        }
    }
}