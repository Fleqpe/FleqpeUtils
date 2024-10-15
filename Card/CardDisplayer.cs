using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplayer : MonoBehaviour
{
    [SerializeField] private CardData cardData;
    [SerializeField] private Button upgradeButton, switchButton;
    [SerializeField] private TMP_Text cardName, level, count, rarity, buff;
    [SerializeField] private Image cardFrame, cardImage;
    [SerializeField] private GameObject equipIndicator;
    private void Start()
    {
        if (CardDatabase.Instance.GetCardInformation(cardData.ID) != null)
            Display().Forget();
        else
            Destroy(gameObject);
    }
    public void SetCardData(CardData cardData)
    {
        this.cardData = cardData;
    }
    public void Switch()
    {
        List<int> equippedCards = SaveManager.gameFiles.cardInventory.equippedCards;
        SoundManager.Instance.PlayClick();
        if (CanDequip(equippedCards))
            Dequip();
        else
            Equip();
    }
    public void Upgrade()
    {
        CardInformation cardInformation = CardDatabase.Instance.GetCardInformation(cardData.ID);
        if (!CanUpgrade(cardInformation))
            return;
        else
        {
            cardData.level += 1;
            cardData.count -= cardInformation.requiredForUpgrade;
            SoundManager.Instance.PlayBuy();
        }
    }
    private bool CanUpgrade(CardInformation cardInformation)
    {
        bool haveEnoughCardsToUpgrade = cardData.count >= cardInformation.requiredForUpgrade;
        bool isLowerThanMaxLevel = cardInformation?.maxLevel > cardData.level;
        bool canUpgrade = haveEnoughCardsToUpgrade && isLowerThanMaxLevel;
        return canUpgrade;
    }
    private void Equip()
    {
        List<int> equippedCards = SaveManager.gameFiles.cardInventory.equippedCards;
        if (!CanEquip(equippedCards))
            return;
        else
        {
            Destroy(gameObject);
            equippedCards.Add(cardData.ID);
            CardDisplayerManager.onEquip.Invoke(cardData);
        }
    }
    private bool CanEquip(List<int> equippedCards)
    {
        bool tooManyEquipped = equippedCards.Count >= CardDatabase.Instance.maxEquippableCardAmount;
        bool alreadyEquippedSameID = equippedCards.Exists(x => x == cardData.ID);
        bool canEquip = !tooManyEquipped || !alreadyEquippedSameID;
        return canEquip;
    }
    private bool CanDequip(List<int> equippedCards)
    {
        return equippedCards.Exists(x => x == cardData.ID);
    }
    private void Dequip()
    {
        List<int> equippedCards = SaveManager.gameFiles.cardInventory.equippedCards;
        if (!CanDequip(equippedCards))
            return;
        else
        {
            Destroy(gameObject);
            equippedCards.Remove(cardData.ID);
            CardDisplayerManager.onDequip.Invoke(cardData);
        }
    }
    private async UniTaskVoid Display()
    {
        while (!destroyCancellationToken.IsCancellationRequested)
        {
            await UniTask.WaitUntil(() => LanguageManager.Instance.isLanguageSystemReady)
            .AttachExternalCancellation(destroyCancellationToken);
            CardInventory cardInventory = SaveManager.gameFiles.cardInventory;
            CardInformation cardInformation = CardDatabase.Instance.GetCardInformation(cardData.ID);
            SetButtons(cardInformation, cardInventory);
            SetCardData(cardInformation);
            await SetText(cardInformation)
            .AttachExternalCancellation(destroyCancellationToken);
            await UniTask.WaitForSeconds(0.25f)
            .AttachExternalCancellation(destroyCancellationToken);
        }
    }
    private async UniTask SetText(CardInformation cardInformation)
    {
        buff.text = "<color=green>" + (cardInformation.IsPercentageBased() ? " %" : " +") + cardInformation.cardBonus.GetBonusAmount(cardData.level);
        buff.text += " </color>" + await cardInformation.cardBonus.cardBonusType.GetLocalizedString(destroyCancellationToken);
        cardName.text = cardInformation.cardName;
        level.text = cardData.level < cardInformation.maxLevel ? "Lv " + cardData.level.ToString() : "MAX";
        count.text = cardData.count.ToString() + $"/{cardInformation.requiredForUpgrade}";
        rarity.text = await cardInformation.rarity.GetLocalizedString(destroyCancellationToken);
    }
    private void SetButtons(CardInformation cardInformation, CardInventory cardInventory)
    {
        switchButton.interactable = cardInventory.equippedCards.Count < CardDatabase.Instance.maxEquippableCardAmount || cardInventory.equippedCards.Exists(x => x == cardData.ID);
        upgradeButton.interactable = cardData.count >= cardInformation.requiredForUpgrade;
        upgradeButton.gameObject.SetActive(cardInformation?.maxLevel > cardData.level);
    }
    private void SetCardData(CardInformation cardInformation)
    {
        cardFrame.material = RarityManager.Instance.GetImageMaterial(cardInformation.rarity);
        rarity.fontMaterial = RarityManager.Instance.GetTextMaterial(cardInformation.rarity);
        cardImage.sprite = cardInformation.sprite;
    }
}
