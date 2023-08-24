using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
      public static Singleton instance;
      public void SingletonChecker()
      {
            if (instance == null)
                  instance = this;
            else
                  Destroy(gameObject);
      }
      void Start()
      {
            DontDestroyOnLoad(gameObject);
            SingletonChecker();
      }
}
