using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class ActiveSkillButton : MonoBehaviour
{
      public Button button;
      public ActiveSkillTimer skillTimer;
      public KeyCode key;
      private void Update()
      {
            if (Input.GetKeyDown(key) && skillTimer.timeLeft <= 0)
                  button.onClick.Invoke();
            button.interactable = skillTimer.timeLeft <= 0;
      }

}
