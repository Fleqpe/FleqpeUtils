using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ActiveSkillDatabase", menuName = "ScriptableObject/Active Skill Database")]
public class ActiveSkillDatabase : ScriptableObject
{
      public List<ActiveSkillData> skills = new List<ActiveSkillData>();
      public static ActiveSkillData GetSkillData(string id)
      {
            return GetDatabase().skills.Find(x => x.skill.id == id);
      }
      private static ActiveSkillDatabase GetDatabase()
      {
            return Resources.Load<ActiveSkillDatabase>("ActiveSkillDatabase");
      }
}
