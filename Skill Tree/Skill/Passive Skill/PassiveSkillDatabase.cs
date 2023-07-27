using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PassiveSkillDatabase", menuName = "ScriptableObject/Passive Skill Database")]
public class PassiveSkillDatabase : ScriptableObject
{
      public List<PassiveSkillData> skills = new List<PassiveSkillData>();
      public static PassiveSkillData GetSkillData(string id)
      {
            return GetDatabase().skills.Find(x => x.skill.id == id);
      }
      private static PassiveSkillDatabase GetDatabase()
      {
            return Resources.Load<PassiveSkillDatabase>("PassiveSkillDatabase");
      }
}
