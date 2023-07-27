using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
      public Singleton instance;
      void Start()
      {
            if (instance != this && instance != null)
                  Destroy(instance);
            else
                  instance = this;
      }
}
