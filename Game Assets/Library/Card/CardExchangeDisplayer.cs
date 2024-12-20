using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using FleqpeUtils.BreakInfinity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardExchangeDisplayer : MonoBehaviour
{
    [SerializeField] private CardData cardData;
    [SerializeField] private TMP_Text cardName, level, count, sellValue;
    [SerializeField] private Image cardFrame, cardImage;
    [SerializeField] private int countToSell = 0;
    [SerializeField] private Button countIncrease, countDecrease, sellButton;
    private void Start()
    {
        CardInformation cardInformation = CardDatabase.Instance.GetCardInformation(cardData.ID);
        CardSellValue cardSellValues = CardDatabase.Instance.GetCardSellValue(cardData.ID);
        if (cardInformation != null && cardSellValues != null)
            Display().Forget();
        else
            Destroy(gameObject);
    }
    private bool CanSell()
    {
        return cardData.count >= countToSell;
    }
    public void SetCardData(CardData cardData)
    {
        this.cardData = cardData;
    }
    public void SellCards()
    {
        if (CanSell()) return;
        BigDouble singleSellPrice = CardDatabase.Instance.GetCardSellValue(cardData.ID).value;
        BigDouble totalSellPrice = BigDouble.Multiply(singleSellPrice, countToSell);

        cardData.count -= countToSell;
        SaveManager.gameFiles.playerData.currencyData.EarnPremiumMoney(totalSellPrice);

        sellButton.interactable = false;
        SoundManager.Instance.PlayBuy();
    }
    public void IncreaseCount()
    {
        countToSell = Math.Min(cardData.count, countToSell + 1);
        SoundManager.Instance.PlayClick();
    }
    public void DecreaseCount()
    {
        countToSell = Math.Max(0, countToSell - 1);
        SoundManager.Instance.PlayClick();
    }

    private async UniTaskVoid Display()
    {
        while (!destroyCancellationToken.IsCancellationRequested)
        {
            CardInformation cardInformation = CardDatabase.Instance.GetCardInformation(cardData.ID);
            SetTexts(cardInformation);
            SetImages(cardInformation);
            SetButtons();
            await UniTask.WaitForSeconds(0.25f)
             .AttachExternalCancellation(destroyCancellationToken);
        }
    }
    private void SetTexts(CardInformation cardInformation)
    {
        CardSellValue cardSellValues = CardDatabase.Instance.GetCardSellValue(cardData.ID);
        cardName.text = cardInformation.cardName;
        level.text = cardData.level < cardInformation.maxLevel ? "Lv " + cardData.level.ToString() : "MAX";
        count.text = cardData.count.ToString();
        sellValue.text = BigDouble.Multiply(cardSellValues.value, countToSell).GetString() + " <sprite=0>";
    }
    private void SetImages(CardInformation cardInformation)
    {
        cardFrame.material = RarityManager.Instance.GetImageMaterial(cardInformation.rarity);
        cardImage.sprite = cardInformation.sprite;
    }
    private void SetButtons()
    {
        countIncrease.gameObject.SetActive(cardData.count > countToSell);
        countDecrease.gameObject.SetActive(countToSell > 0);
        sellButton.interactable = cardData.count >= countToSell;
        if (cardData.count <= 0)
            Destroy(gameObject);
    }
}
[System.Serializable]
public class CardSellValue
{
    public Rarity rarity = Rarity.Common;
    public BigDouble value = new BigDouble(0, 0);
}
