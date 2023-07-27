using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerItem : Item
{
      public ItemStats stats;
      public ItemType type;
      public Rarity rarity;
      public PlayerItem(string id, ItemStats stats, ItemType type, Rarity rarity) : base(id)
      {
            this.stats = stats;
            this.type = type;
            this.rarity = rarity;
      }
}
