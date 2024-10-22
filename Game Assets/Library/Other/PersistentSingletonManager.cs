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
            T[] instances = FindObjectsByType<T>(FindObjectsSortMode.None);
            if (instances.Length > 1)
            {
                for (int i = instances.Length - 1; i > 1; i--)
                    Destroy(instances[i].gameObject);
            }
            _instance = instances.Length > 0 ? instances[0] : new GameObject(typeof(T).ToString()).AddComponent<T>();
            DontDestroyOnLoad(_instance.gameObject);
        }
    }
}
