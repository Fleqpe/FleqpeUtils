using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActiveSkillNodeDisplayer : SkillNodeDisplayer
{
      public override void DisplaySkill()
      {
            ActiveSkillData data = ActiveSkillDatabase.GetSkillData(node.id);
            skillName.text = data.skillName;
            skillDescription.text = data.description;
            skillStats.text = "Attack: " + data.skill.buff.attack
            + "\n"
            + "Speed: " + data.skill.buff.speed;
      }
      public override void OnPointerEnter(PointerEventData eventData)
      {
            skillInfoMenu.SetActive(true);
            DisplaySkill();
      }
      public override void OnPointerExit(PointerEventData eventData)
      {
            skillInfoMenu.SetActive(false);
      }
}
