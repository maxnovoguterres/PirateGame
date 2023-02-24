using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Model;
using Assets.Scripts.Controller;

namespace Assets.Scripts.View
{
    public class CameraView : Shared.View
    {
        public Model.Camera Model;

        private void FixedUpdate()
        {
            transform.localPosition = CameraController.Instance.SmoothPosition(Model, transform.localPosition);
            CameraController.Instance.CheckBounds(this);
        }
    }
}