using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.View.Shared
{
    public class View : MonoBehaviour
    {
        public Dictionary<string, object> Components = new Dictionary<string, object>();

        protected T GetAndStoreComponent<T>()
        {
            string name = typeof(T).Name;
            if (!Components.ContainsKey(name))
            {
                Components[name] = GetComponent<T>();
            }

            return (T)Components[name];
        }

        public static explicit operator GameObject(View b) => b.gameObject;
    }
}