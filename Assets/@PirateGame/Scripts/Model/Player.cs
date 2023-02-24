using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.View;
using UnityEngine;

namespace Assets.Scripts.Model
{
    [Serializable]
    public class Player
    {
        [HideInInspector] public ShooterView[] shooterViews;
    }
}