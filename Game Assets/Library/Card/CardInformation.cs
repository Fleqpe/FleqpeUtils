using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Entry/CardInformation")]
public class CardInformation : EntrySO<CardInformation>
{
    public string cardName;
    public int requiredForUpgrade, maxLevel;
    public Rarity rarity;
    public Sprite sprite;
    public CardBonus cardBonus = new CardBonus();
    public bool IsPercentageBased()
    {
        switch (cardBonus.cardBonusType)
        {
            case CardBonusType.MaterialMultiplyChance:
                return true;
            case CardBonusType.GoldEarn:
                return true;
            case CardBonusType.XPEarn:
                return true;
            default:
                return false;
        }
    }
}
public static class CardInformationExtension
{
    public static CardInformation FirstOrDefault(this List<CardInformation> cardInformations, int ID)
    {
        return cardInformations.FirstOrDefault(x => x.ID == ID);
    }
}