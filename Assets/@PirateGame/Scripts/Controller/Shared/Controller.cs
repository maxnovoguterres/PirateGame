using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Controller.Shared
{
    public abstract class Controller<T> : MonoBehaviour where T : MonoBehaviour
    {
        readonly UnityAction awake;

        protected Controller(UnityAction awake = null)
        {
            this.awake = awake;
        }

        private static T instance;
        public static T Instance
        {
            get => instance;
            set => instance = instance ?? value;
        }

        protected virtual void Awake()
        {
            GetInstance();

            awake?.Invoke();
        }

        private void GetInstance()
        {
            if (instance == null)
            {
                instance = this as T;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
            }
        }
    }
}