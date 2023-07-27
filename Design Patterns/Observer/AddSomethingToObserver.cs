using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSomethingToObserver : MonoBehaviour
{
      private void OnEnable()
      {
            Observer.trigger.AddListener(DummyFunction);
      }
      private void OnDisable()
      {
            Observer.trigger.RemoveListener(DummyFunction);
      }
      public void DummyFunction()
      {
            Debug.Log("Dummy Function is firing.");
      }
}
