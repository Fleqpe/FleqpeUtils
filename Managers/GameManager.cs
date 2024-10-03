using System.Threading;
using UnityEngine;
public class GameManager : PersistentSingletonManager<GameManager>
{
    [SerializeField] private GameFiles gameFiles = new GameFiles();
}
