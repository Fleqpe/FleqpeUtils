using System.Runtime.CompilerServices;
using UnityEngine;

public class PersistentSingletonManager<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            SetInstance();
            return _instance;
        }
    }
    private static void SetInstance()
    {
        if (_instance == null)
        {
            T[] instances = FindObjectsOfType<T>();
            if (instances.Length > 1)
            {
                Debug.LogWarning($"There are {instances.Length} instances of SingletonManager<{typeof(T)}>! Destroying extras...");
                for (int i = instances.Length - 1; i > 1; i--)
                    Destroy(instances[i].gameObject);
            }
            _instance = instances.Length > 0 ? instances[0] : new GameObject(typeof(T).ToString()).AddComponent<T>();
        }
        DontDestroyOnLoad(_instance.gameObject);
    }
}
