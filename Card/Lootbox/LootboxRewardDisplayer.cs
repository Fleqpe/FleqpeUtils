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
        DisplayCard(lootboxItem).Forget();
    }
    private async UniTaskVoid DisplayCard(LootboxItem lootboxItem)
    {
        if (lootboxItem is not LootboxCardItem)
            return;
        LootboxCardItem cardItem = (LootboxCardItem)lootboxItem;
        await SetRarityText(cardItem)
        .AttachExternalCancellation(destroyCancellationToken);
        await SetBonusText(cardItem)
        .AttachExternalCancellation(destroyCancellationToken);
        SetItemInformation(cardItem);
        menu.Open();
    }
    private void SetItemInformation(LootboxCardItem cardItem)
    {
        count.text = "x" + cardItem.count.ToString();
        itemName.text = cardItem.cardInformation.cardName;
        itemImage.sprite = cardItem.cardInformation.sprite;
    }
    private async UniTask SetRarityText(LootboxCardItem cardItem)
    {
        rarity.text = await cardItem.cardInformation.rarity.GetLocalizedString(destroyCancellationToken);
        rarity.SetTextMaterial(cardItem.cardInformation.rarity);
        itemFrame.SetImageMaterial(cardItem.cardInformation.rarity);
    }
    private async UniTask SetBonusText(LootboxCardItem cardItem)
    {
        bonus.text = await cardItem.cardInformation.cardBonus.cardBonusType.GetLocalizedString(destroyCancellationToken);
        bonus.text += "<color=green>" + (cardItem.cardInformation.IsPercentageBased() ? " %" : " +") + cardItem.cardInformation.cardBonus.GetBonusAmount(1);
    }
}
