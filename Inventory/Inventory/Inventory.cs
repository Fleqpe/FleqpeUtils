using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Inventory<T>
{
      public List<T> items = new List<T>();
      public Inventory(List<T> items)
      {
            this.items = items;
      }
      public Inventory()
      {
      }

      public void Add(T item)
      {
            items.Add(item);
      }
      public void Remove(T item)
      {
            items.Remove(item);
      }
      public T Find(System.Predicate<T> match)
      {
            return items.Find(match);
      }
      public bool Exists(System.Predicate<T> match)
      {
            return items.Exists(match);
      }
      public int Count
      {
            get
            {
                  return items.Count;
            }
      }
}
public static class GlobalInventory
{
      public static Inventory<PlayerItem> player = new Inventory<PlayerItem>(new List<PlayerItem>(){
            new PlayerItem("test",new ItemStats(10,1,32),ItemType.Weapon,Rarity.Common)
      });
      public static Inventory<PlayerItem> equipped = new Inventory<PlayerItem>();
      public static Inventory<CraftItem> craft = new Inventory<CraftItem>(new List<CraftItem>()
      {
      new CraftItem("craftTest1")
      });
}