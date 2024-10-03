using System.Collections.Generic;
using System.Linq;
using FleqpeUtils.BreakInfinity;
using UnityEngine;
[CreateAssetMenu(fileName = "GameDatabase", menuName = "ScriptableObjects/Database/Game Database")]
public class GameDatabase : SingletonSO<GameDatabase>
{
    [SerializeField] private BigDouble requiredXPEveryLevel, requiredXPEveryLevelForPets;
    [SerializeField] private BigDouble evolutionLevelForPets = 100;
    public BigDouble GetRequiredXP(BigDouble level)
    {
        return BigDouble.Multiply(requiredXPEveryLevel, level);
    }
    public BigDouble GetRequiredXPForPets(BigDouble level)
    {
        return BigDouble.Multiply(requiredXPEveryLevelForPets, level);
    }
}