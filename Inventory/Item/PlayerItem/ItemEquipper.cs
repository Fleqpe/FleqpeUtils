using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemEquipper : MonoBehaviour
{
      public PlayerItemDisplayer itemDisplayer;
      public void Equip()
      {
            if (GlobalInventory.equipped.Exists(x => x.type == itemDisplayer.item.type))
                  DeEquip();

            GlobalInventory.equipped.Add(itemDisplayer.item);
            GlobalInventory.player.Remove(itemDisplayer.item);
      }
      public void DeEquip()
      {
            GlobalInventory.player.Add(itemDisplayer.item);
            GlobalInventory.equipped.Remove(itemDisplayer.item);
      }
}
