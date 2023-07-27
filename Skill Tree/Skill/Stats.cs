using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Stats
{
      public int attack;
      public int speed;
      public static Stats operator +(Stats a, Stats b)
      {
            a.attack += b.attack;
            a.speed += b.speed;
            return a;
      }
      public static Stats operator -(Stats a, Stats b)
      {
            a.attack -= b.attack;
            a.speed -= b.speed;
            return a;
      }
      public static Stats operator *(Stats a, Stats b)
      {
            a.attack *= b.attack;
            a.speed *= b.speed;
            return a;
      }
      public static Stats operator *(Stats a, int b)
      {
            a.attack *= b;
            a.speed *= b;
            return a;
      }
}
