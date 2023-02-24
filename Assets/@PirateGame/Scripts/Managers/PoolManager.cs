using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Helpers;
using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Scripts.Managers
{
    [CreateAssetMenu(fileName = "New Pool", menuName = "Scriptable Objects/Pool")]
    public class PoolManager : ScriptableObject
    {
        public GameObject prefab;
        public int defaultCapacity = 10;
        public int maxCapacity = 20;
        private ObjectPool<GameObject> gameObjectPool;

        public void ResetPool ()
        {
            gameObjectPool = null;
        }

        public void Setup ()
        {
            gameObjectPool = new ObjectPool<GameObject>(CreateObject, OnGetObjectFromPool, OnReleaseObjectToPool, OnDestroyPoolObject, true, defaultCapacity, maxCapacity);

            List<GameObject> newGameObjects = new List<GameObject>();
            for (int i = 0; i < maxCapacity; i++)
            {
                newGameObjects.Add(Spawn(Vector3.zero, Quaternion.identity));
            }
            newGameObjects.ForEach(Despawn);
        }

        public GameObject Spawn (Vector3 position, Quaternion rotation, Transform parent = null)
        {
            if (gameObjectPool == null)
            {
                Setup();
                Debug.LogWarning($"Pool:{prefab.name} wasn't created");
            }
            GameObject gameObject = gameObjectPool.Get();
            gameObject.transform.position = position;
            gameObject.transform.rotation = rotation;
            if (parent != null)
            {
                gameObject.transform.parent = parent;
            }
            return gameObject;
        }

        public void Despawn (GameObject gameObject)
        {
            gameObjectPool.Release(gameObject);
        }

        public void Despawn (GameObject gameObject, float timeToDespawn)
        {
            MonoInstance.Instance.StartCoroutine(DespawnCoroutine(timeToDespawn, gameObject));
        }

        private IEnumerator DespawnCoroutine (float timeToDespawn, GameObject gameObject)
        {
            yield return new WaitForSeconds(timeToDespawn);
            if (gameObject.activeSelf)
            {
                Despawn(gameObject);
            }
        }

        private GameObject CreateObject ()
        {
            return Instantiate(prefab);
        }

        private void OnGetObjectFromPool (GameObject gameObject)
        {
            gameObject.SetActive(true);
        }

        private void OnReleaseObjectToPool (GameObject gameObject)
        {
            gameObject.SetActive(false);
        }

        private void OnDestroyPoolObject (GameObject gameObject)
        {
            Destroy(gameObject);
        }
    }
}