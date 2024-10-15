using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;
[CreateAssetMenu(fileName = "SkillEntry", menuName = "ScriptableObjects/Entry/Skill Entry")]
public class SkillEntry : EntrySO<SkillEntry>
{
    public SkillManager prefab;
    public SkillType skillType;
    public SkillTarget skillTarget;
    [ShowIf("@skillType==SkillType.Attack || skillType==SkillType.DamageOverTime")]
    public float attackBonus;
    [ShowIf("skillType", SkillType.DamageOverTime)]
    public float round;
    [ShowIf("skillType", SkillType.Buff)]
    public float buffBonus;
    public async UniTask PlaySkill(Transform parent, PetManager caster, List<PetManager> targets)
    {
        await Instantiate(prefab, parent).skillBehaviour.Activate(caster, targets);
    }
}

public enum SkillType
{
    Attack, Buff, DamageOverTime
}
public enum SkillTarget
{
    AreaOfEffect, Self, Enemy
}