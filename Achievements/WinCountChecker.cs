using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace FleqpeUtils.Achievement
{
      public class WinCountChecker : MonoBehaviour
      {
            public AchievementDisplay display;
            public void DisplayProgress()
            {
                  display.achievementNameText.text += " " +
            AchievementDatabase.GetIncrementalAchievement(display.id).GetCurrentMilestoneIndex(AchievementData.winCount).ToString() + "/"
            + AchievementDatabase.GetIncrementalAchievement(display.id).GetTargetMilestoneIndex(AchievementData.winCount).ToString();
            }
            public void DisplayTargetMilestone()
            {
                  display.achievementInfoText.text = display.achievementInfoText.text.Replace("x",
                  AchievementData.winCount
                  + "/"
                  + AchievementDatabase.GetIncrementalAchievement(display.id).GetTargetMilestone(AchievementData.winCount).ToString());
            }
      }
}