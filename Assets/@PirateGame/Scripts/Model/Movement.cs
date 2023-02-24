using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Model
{
    [Serializable]
    public class Movement
    {
        public bool isPlayer;
        public float moveSpeed = 4f;
        public float maxVelocity = 5f;
        public float rotationSpeed = 4f;

        [Header("Enemy")]
        public LayerMask obstacleLayer;
        public float detectionRange;
        public float maxRange;

        [HideInInspector] public bool isChasing;
        [HideInInspector] public Transform target;
    }
}