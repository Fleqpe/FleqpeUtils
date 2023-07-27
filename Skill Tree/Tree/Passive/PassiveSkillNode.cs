using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
[RequireComponent(typeof(PassiveSkillNodeDisplayer))]
public class PassiveSkillNode : SkillNode
{
      private void Start()
      {
            CheckSkill();
      }
      public override void CheckSkill()
      {
            if (parentNode != null)
            {
                  if (SkillInventory.passiveSkillIDs.Exists(x => x == parentNode.id))
                  {
                        if (SkillInventory.passiveSkillIDs.Exists(x => x == id))
                              state = SkillNodeState.Active;
                        else
                              state = SkillNodeState.NotOpened;
                  }
                  else
                        state = SkillNodeState.Inactive;

            }
            else
                  state = SkillNodeState.NotOpened;
      }

}
