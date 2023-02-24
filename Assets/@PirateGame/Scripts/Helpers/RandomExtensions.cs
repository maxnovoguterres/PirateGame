using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Helpers
{
    public static class RandomExtensions
    {
        public static int GetRandomInt (int min, int max)
        {
            int randomNumber = Random.Range(min, max);
            return randomNumber;
        }

        public static float GetRandomFloat (float min, float max)
        {
            float randomNumber = Random.Range(min, max);
            return randomNumber;
        }
    }
}
