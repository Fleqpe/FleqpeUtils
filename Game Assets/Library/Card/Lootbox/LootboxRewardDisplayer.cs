using System.Collections;
using System.Threading;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LootboxRewardDisplayer : MonoBehaviour
{
    [SerializeField] private SwitchableCanvasGroup menu;
    [SerializeField] private TMP_Text itemName, count, rarity, bonus;
    [SerializeField] private Image itemImage, itemFrame;
    public void Display(LootboxItem lootboxItem)
    {
        DisplayCard(lootboxItem);
    }
    private void DisplayCard(LootboxItem lootboxItem)
    {
        if (lootboxItem is not LootboxCardItem)
            return;
        LootboxCardItem cardItem = (LootboxCardItem)lootboxItem;
        SetRarityText(cardItem);
        SetBonusText(cardItem);
        SetItemInformation(cardItem);
        menu.Open();
    }
    private void SetItemInformation(LootboxCardItem cardItem)
    {
        count.text = "x" + cardItem.count.ToString();
        itemName.text = cardItem.cardInformation.cardName;
        itemImage.sprite = cardItem.cardInformation.sprite;
    }
    private void SetRarityText(LootboxCardItem cardItem)
    {
        rarity.text = cardItem.cardInformation.rarity.ToString();
        rarity.SetTextMaterial(cardItem.cardInformation.rarity);
        itemFrame.SetImageMaterial(cardItem.cardInformation.rarity);
    }
    private void SetBonusText(LootboxCardItem cardItem)
    {
        bonus.text = cardItem.cardInformation.cardBonus.cardBonusType.ToString();
        bonus.text += "<color=green>" + (cardItem.cardInformation.IsPercentageBased() ? " %" : " +") + cardItem.cardInformation.cardBonus.GetBonusAmount(1);
    }
}
