using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftInventoryDisplayer : InventoryDisplayer
{
      public override void Display()
      {
            DisplayCraftItems();
      }
      private void Start()
      {
            Display();
      }
      private void Update()
      {
            increasePageButton.gameObject.SetActive(currentPage < (int)(GlobalInventory.craft.Count / itemBoxObjects.Count));
            decreasePageButton.gameObject.SetActive(currentPage > 0);
      }
      private void DisplayCraftItems()
      {
            for (int i = 0; i < itemBoxObjects.Count; i++)
            {
                  ItemDisplayer itemDisplayer = itemBoxObjects[i].GetComponent<ItemDisplayer>();
                  itemDisplayer.ResetDisplay();
            }
            for (int i = itemBoxObjects.Count * currentPage; i < itemBoxObjects.Count * (currentPage + 1); i++)
            {
                  if (i >= GlobalInventory.craft.Count)
                        break;
                  int objectIndex = i - itemBoxObjects.Count * currentPage;
                  CraftItemDisplayer itemDisplayer = itemBoxObjects[objectIndex].GetComponent<CraftItemDisplayer>();
                  itemDisplayer.item = GlobalInventory.craft.items[i];
                  itemDisplayer.DisplayItem();
            }
      }

}
