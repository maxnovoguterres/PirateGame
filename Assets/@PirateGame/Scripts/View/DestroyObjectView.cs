using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Model;
using Assets.Scripts.Controller;

namespace Assets.Scripts.View
{
    public class DestroyObjectView : Shared.View
    {
        public DestroyObject Model;

        private void Start()
        {
            if (Model.isDestroyedByTime)
            {
                Destroy(gameObject, Model.timeToDestroy);
            }
        }

        private void Update()
        {
            if (Model.canDestroy)
            {
                Destroy(gameObject);
            }
        }
    }
}