using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FleqpeUtils.Achievement
{
      [CreateAssetMenu(fileName = "AchievementDatabase", menuName = "ScriptableObject/Achievement Database")]
      public class AchievementDatabase : ScriptableObject
      {
            [SerializeField] private List<IncrementalAchievement> incrementalAchievements;
            private static AchievementDatabase GetDatabase()
            {
                  return Resources.Load<AchievementDatabase>("AchievementDatabase");
            }
            public static IncrementalAchievement GetIncrementalAchievement(string id)
            {
                  return GetDatabase().incrementalAchievements.Find(x => x.id == id);
            }
      }
}