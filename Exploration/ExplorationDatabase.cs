using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "ExplorationDatabase", menuName = "ScriptableObjects/Database/Exploration Database")]
public class ExplorationDatabase : SingletonSO<ExplorationDatabase>
{
    [TableList][SerializeField] private List<ExplorationEntry> explorations = new List<ExplorationEntry>();
    public ExplorationEntry GetExploration(int ID)
    {
        return explorations.FirstOrDefault(x => x.ID == ID);
    }
}
