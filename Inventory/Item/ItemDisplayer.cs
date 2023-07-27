using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
public abstract class ItemDisplayer : MonoBehaviour
{
      public TMP_Text itemName;
      public TMP_Text itemDetails;
      public TMP_Text itemStats;
      public TMP_Text itemType;
      public Image itemImage;
      public GameObject infoMenu;
      public Button button;
      public Dictionary<Rarity, string> rarityColors = new Dictionary<Rarity, string>()
      {
      {Rarity.Common,"<color=grey>"},
      {Rarity.Uncommon,"<color=green>"},
      {Rarity.Rare,"<color=blue>"},
      {Rarity.Epic,"<color=purple>"},
      {Rarity.Sealed,"<color=orange>"},
      {Rarity.Legendary,"<color=yellow>"},
      {Rarity.Fable,"<color=red>"},
      {Rarity.Mythic,"<color=black>"}
      };

      public abstract void ResetDisplay();
      public abstract void DisplayItem();
}
