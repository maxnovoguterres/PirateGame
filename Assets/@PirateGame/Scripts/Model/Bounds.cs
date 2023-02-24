using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Model
{
    [Serializable]
    public class Bounds
    {
        [HideInInspector] public float maxTopBounds;
        [HideInInspector] public float maxBottomBounds;
        [HideInInspector] public float maxLeftBounds;
        [HideInInspector] public float maxRightBounds;
    }
}