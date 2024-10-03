using System.Collections;
using System.Collections.Generic;
using FleqpeUtils.BreakInfinity;
using UnityEngine;
[System.Serializable]
public class ExperienceData
{
    public BigDouble xp, level = 1;
    public void EarnXP(BigDouble xp)
    {
        this.xp += xp;
        BigDouble requiredXP = GameDatabase.Instance.GetRequiredXP(level);
        bool calledLevelUp = false;
        while (xp >= requiredXP)
        {
            xp -= requiredXP;
            level += 1;
            if (!calledLevelUp)
            {
                EventBus.onLevelUp?.Invoke();
                calledLevelUp = true;
            }
        }
    }
}
