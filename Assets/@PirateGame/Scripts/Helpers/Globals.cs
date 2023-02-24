using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Helpers
{
    public static class Globals
    {
        public static List<T> FindObjectsOfTypeAll<T> ()
        {
            return SceneManager.GetActiveScene().GetRootGameObjects()
                .SelectMany(g => g.GetComponentsInChildren<T>(true))
                .ToList();
        }
    }
}