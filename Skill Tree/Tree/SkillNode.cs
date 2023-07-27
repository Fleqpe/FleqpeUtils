using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public abstract class SkillNode : MonoBehaviour
{
      public string id;
      public SkillNode parentNode;
      public SkillNodeState state = SkillNodeState.Inactive;
      public abstract void CheckSkill();
}