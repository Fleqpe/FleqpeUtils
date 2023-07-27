using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace FleqpeUtils.Achievement
{
      public class IncrementalAchievementDisplay : AchievementDisplay
      {
            public override void DisplayAchievementInfoText()
            {
                  achievementInfoText.text = AchievementDatabase.GetIncrementalAchievement(id).achievementText;
            }
            public override void DisplayAchievementNameText()
            {
                  achievementNameText.text = AchievementDatabase.GetIncrementalAchievement(id).name;
            }
            public override void OnPointerEnter(PointerEventData eventData)
            {
                  achievementBox.SetActive(true);
                  DisplayAchievementInfoText();
                  DisplayAchievementNameText();
                  milestoneCheckTrigger.Invoke();
            }
            public override void OnPointerExit(PointerEventData eventData)
            {
                  achievementBox.SetActive(false);
            }

      }
}