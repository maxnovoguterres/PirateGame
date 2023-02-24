using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Enums;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class InputController : Shared.Controller<InputController>
    {
        public KeyCode frontShootKey = KeyCode.Z;
        public KeyCode sideShootKey = KeyCode.X;
        private float horizontalMovement;
        private float verticalMovement;
        private bool isShootingFront;
        private bool isShootingSide;

        void Update()
        {
            if (GameController.Instance.HasMatchStarted())
            {
                horizontalMovement = Input.GetAxisRaw("Horizontal");
                verticalMovement = Input.GetAxis("Vertical");
                if (Input.GetKeyDown(frontShootKey))
                {
                    isShootingFront = true;
                }
                if (Input.GetKeyDown(sideShootKey))
                {
                    isShootingSide = true;
                }
            }
        }

        public float GetHorizontalMovement() => horizontalMovement;
        public float GetVerticalMovement() => verticalMovement;
        public bool GetFrontShoot () => isShootingFront;
        public bool GetSideShoot () => isShootingSide;

        public void SetFrontShoot (bool isShooting) => isShootingFront = isShooting;
        public void SetSideShoot (bool isShooting) => isShootingSide = isShooting;
    }
}