using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class CraftItemDisplayer : ItemDisplayer, IPointerEnterHandler, IPointerExitHandler
{
      public CraftItem item;
      public override void DisplayItem()
      {
            ItemData itemData = CraftItemDatabase.GetCraftItemData(item.id);
            itemName.text = itemData.name;
            itemDetails.text = itemData.details;
            itemImage.sprite = itemData.sprite;
            itemType.text = "Craft Item";
      }
      public override void ResetDisplay()
      {
            item = new CraftItem("");
            itemName.text = "";
            itemDetails.text = "";
            itemImage.sprite = null;
            itemType.text = "";
            itemStats.text = "";
            infoMenu.SetActive(false);
      }
      private void Update()
      {
            button.interactable = item.id != "";
      }
      public void OnPointerEnter(PointerEventData eventData)
      {
            if (item.id == "")
                  return;
            infoMenu.SetActive(true);
            this.gameObject.transform.parent.SetAsLastSibling();
      }
      public void OnPointerExit(PointerEventData eventData)
      {
            if (item.id == "")
                  return;
            infoMenu.SetActive(false);
            this.gameObject.transform.parent.SetAsFirstSibling();
      }
}
