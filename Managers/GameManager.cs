using System.Threading;
using UnityEngine;
public class GameManager : PersistentSingletonManager<GameManager>
{
    void Awake()
    {
        Application.targetFrameRate = -1;
    }
}