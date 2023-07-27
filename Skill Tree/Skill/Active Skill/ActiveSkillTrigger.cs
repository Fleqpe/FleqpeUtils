using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ActiveSkillTrigger : MonoBehaviour
{
      public UnityEvent startTrigger;
      public UnityEvent endTrigger;
      public float interval;
      public string id;
      public void TriggerSkill()
      {
            StartCoroutine("TriggerCoroutine");
      }
      public IEnumerator TriggerCoroutine()
      {
            StartSkill();
            yield return new WaitForSeconds(interval);
            EndSkill();
      }
      private void StartSkill()
      {
            Debug.Log("Triggering " + ActiveSkillDatabase.GetSkillData(id).skillName);
            ActiveSkillDatabase.GetSkillData(id).skill.Apply();
            startTrigger.Invoke();
      }
      private void EndSkill()
      {
            Debug.Log("Ending " + ActiveSkillDatabase.GetSkillData(id).skillName);
            ActiveSkillDatabase.GetSkillData(id).skill.Remove();
            endTrigger.Invoke();
      }
}
