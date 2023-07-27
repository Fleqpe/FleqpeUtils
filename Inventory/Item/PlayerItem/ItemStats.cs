using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ItemStats
{
      public int hp;
      public int armor;
      public int attack;
      public ItemStats(int hp, int armor, int attack)
      {
            this.hp = hp;
            this.armor = armor;
            this.attack = attack;
      }
}
