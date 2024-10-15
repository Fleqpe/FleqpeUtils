using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillDatabase", menuName = "ScriptableObjects/Database/Skill Database")]
public class SkillDatabase : SingletonSO<SkillDatabase>
{
    [TableList][SerializeField] private List<SkillEntry> skills = new List<SkillEntry>();
    public SkillEntry GetSkill(int ID)
    {
        return skills.FirstOrDefault(x => x.ID == ID);
    }
}
