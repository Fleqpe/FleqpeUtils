using System.Collections;
using System.Collections.Generic;
using FleqpeUtils.BreakInfinity;
using UnityEngine;
[System.Serializable]
public class ExperienceData
{
    public BigDouble xp, level = 1;
    public void EarnXP(BigDouble earnedXP)
    {
        xp += earnedXP;
        BigDouble initialLevel = level;
        while (xp >= GameDatabase.Instance.GetRequiredXPForPets(level))
        {
            xp -= GameDatabase.Instance.GetRequiredXPForPets(level);
            level += 1;
        }
        if (level > initialLevel)
            EventBus.onPetLevelUp?.Invoke(this);
    }
}
