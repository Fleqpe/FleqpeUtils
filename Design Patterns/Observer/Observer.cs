using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Observer : MonoBehaviour
{
      private void Start()
      {
            InvokeRepeating("TriggerEvent", 0f, 1f);
      }
      public void TriggerEvent()
      {
            trigger.Invoke();
      }
      public static UnityEvent trigger = new UnityEvent();
}
