using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
[RequireComponent(typeof(ActiveSkillNodeDisplayer))]
public class ActiveSkillNode : SkillNode
{
      private void Start()
      {
            CheckSkill();
      }
      public override void CheckSkill()
      {
            if (parentNode != null)
            {
                  if (SkillInventory.activeSkillIDs.Exists(x => x == parentNode.id))
                  {
                        if (SkillInventory.activeSkillIDs.Exists(x => x == id))
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
