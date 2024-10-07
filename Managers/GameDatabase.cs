using System.Collections.Generic;
using System.Linq;
using FleqpeUtils.BreakInfinity;
using UnityEngine;
[CreateAssetMenu(fileName = "GameDatabase", menuName = "ScriptableObjects/Database/Game Database")]
public class GameDatabase : SingletonSO<GameDatabase>
{
    [SerializeField] private BigDouble requiredXPEveryLevel, requiredXPEveryLevelForPets;
    [SerializeField] private BigDouble xpGainPerSecond, xpGainFactor;
    [SerializeField] private BigDouble evolutionLevelForPets = 100;
    [SerializeField] private BigDouble maxCrownItCanReach = 3;
    public BigDouble GetXPGain(BigDouble seconds)
    {
        return seconds * xpGainFactor * xpGainPerSecond;
    }
    public BigDouble GetRequiredXP(BigDouble level)
    {
        return BigDouble.Multiply(requiredXPEveryLevel, level + 1);
    }
    public BigDouble GetRequiredXPForPets(BigDouble level)
    {
        return BigDouble.Multiply(requiredXPEveryLevelForPets, level + 1);
    }
    public BigDouble GetMaxLevel()
    {
        return evolutionLevelForPets;
    }
    public BigDouble GetMaxCrowns()
    {
        return maxCrownItCanReach;
    }
}