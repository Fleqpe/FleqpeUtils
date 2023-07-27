using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSkillTimer : MonoBehaviour
{
      public ActiveSkillTrigger skillTrigger;
      public float timeLeft;
      private void FixedUpdate()
      {
            if (timeLeft > 0)
                  timeLeft -= Time.deltaTime;
      }
      public void ChangeTimeLeft()
      {
            timeLeft = skillTrigger.interval;
      }
}
