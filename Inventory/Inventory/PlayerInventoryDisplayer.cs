using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryDisplayer : InventoryDisplayer
{
      public List<EquippedItemBox> equippedItemBoxObjects = new List<EquippedItemBox>();
      public override void Display()
      {
            DisplayPlayerItems();
            DisplayEquipped();
      }
      private void Start()
      {
            Display();
      }
      private void Update()
      {
            increasePageButton.gameObject.SetActive(currentPage < (int)(GlobalInventory.player.Count / itemBoxObjects.Count));
            decreasePageButton.gameObject.SetActive(currentPage > 0);
      }
      private void DisplayPlayerItems()
      {
            for (int i = 0; i < itemBoxObjects.Count; i++)
            {
                  ItemDisplayer itemDisplayer = itemBoxObjects[i].GetComponent<ItemDisplayer>();
                  itemDisplayer.ResetDisplay();
            }
            for (int i = itemBoxObjects.Count * currentPage; i < itemBoxObjects.Count * (currentPage + 1); i++)
            {
                  if (i >= GlobalInventory.player.items.Count)
                        break;
                  int objectIndex = i - itemBoxObjects.Count * currentPage;
                  PlayerItemDisplayer itemDisplayer = itemBoxObjects[objectIndex].GetComponent<PlayerItemDisplayer>();
                  itemDisplayer.item = GlobalInventory.player.items[i];
                  itemDisplayer.DisplayItem();
            }
      }
      private void DisplayEquipped()
      {
            for (int i = 0; i < equippedItemBoxObjects.Count; i++)
            {
                  ItemDisplayer itemDisplayer = equippedItemBoxObjects[i].itemBoxObject.GetComponent<ItemDisplayer>();
                  itemDisplayer.ResetDisplay();
            }
            foreach (PlayerItem item in GlobalInventory.equipped.items)
            {
                  PlayerItemDisplayer itemDisplayer = equippedItemBoxObjects.Find(x => x.type == item.type).itemBoxObject.GetComponent<PlayerItemDisplayer>();
                  itemDisplayer.item = item;
                  itemDisplayer.DisplayItem();
            }
      }
}
