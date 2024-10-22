using UnityEngine;

public class SingletonSO<T> : ScriptableObject where T : ScriptableObject
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
                _instance = Resources.Load<T>("Database/" + typeof(T).ToString());
            return _instance;
        }
    }
}
