using System;
using System.Collections;
using System.Collections.Generic;
using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Model
{
    [Serializable]
    public class Health
    {
        [HideInInspector] public int currentHealth;
        [HideInInspector] public float lastZRotation;
        public bool isPlayer;
        public Slider healthBar;
        public int maxHealth;
        public float badHealthPercentage;
        public SerializableDictionaryBase<int, Sprite> healthSpritesInPercentage;
        public GameObject firesVFX;
    }
}