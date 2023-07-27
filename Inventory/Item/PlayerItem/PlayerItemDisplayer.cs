using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerItemDisplayer : ItemDisplayer, IPointerEnterHandler, IPointerExitHandler
{
      public PlayerItem item;
      public override void DisplayItem()
      {
            ItemData itemData = PlayerItemDatabase.GetPlayerItemData(item.type, item.id);
            itemName.text = rarityColors[item.rarity] + itemData.name;
            itemDetails.text = rarityColors[item.rarity] + itemData.details;
            itemImage.sprite = itemData.sprite;
            itemType.text = rarityColors[item.rarity] + item.type.ToString() + " - " + item.rarity.ToString();
            DisplayStats();
      }
      public override void ResetDisplay()
      {
            item = new PlayerItem("", new ItemStats(0, 0, 0), ItemType.None, Rarity.Common);
            itemName.text = "";
            itemDetails.text = "";
            itemImage.sprite = null;
            itemType.text = "";
            itemStats.text = "";
            infoMenu.SetActive(false);
      }
      public void DisplayStats()
      {
            ItemStats stats = item.stats;
            itemStats.text = rarityColors[item.rarity] +
            "Armor: " + stats.armor + "\n" +
            "Max Health: " + stats.hp + "\n" +
            "Attack: " + stats.attack;
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
