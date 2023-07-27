using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FleqpeUtils.Achievement
{
      [System.Serializable]
      public class Achievement
      {
            public string name;
            public string id;
            [TextArea(3, 4)]
            public string achievementText;
      }
      [System.Serializable]
      public class IncrementalAchievement : Achievement
      {
            public List<int> milestones = new List<int>();
            public int GetTargetMilestone(int count)
            {
                  return milestones.Find(x => x > count);
            }
            public int GetCurrentMilestone(int count)
            {
                  return milestones.Find(x => x <= count);
            }
            public int GetTargetMilestoneIndex(int count)
            {
                  return milestones.IndexOf(milestones.Find(x => x > count)) + 1;
            }
            public int GetCurrentMilestoneIndex(int count)
            {
                  return milestones.IndexOf(milestones.Find(x => x <= count)) + 1;
            }
      }
      public class AchievementData
      {
            public static int winCount = 3;
      }
}