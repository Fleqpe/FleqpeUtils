using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
      public static Player instance;
      public Stats stats = new Stats();
      private void Start()
      {
            if (instance != this && instance != null)
                  Destroy(this);
            else
                  instance = this;
      }
}
