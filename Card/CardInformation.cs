using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Localization.Settings;

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
    public static async UniTask<string> GetLocalizedString(this CardBonusType cardBonus, CancellationToken token)
    {
        var operation = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("StringTable", cardBonus.ToString());
        await UniTask.WaitUntil(() => operation.IsDone)
        .AttachExternalCancellation(token);
        return operation.Result;
    }
    public static CardInformation FirstOrDefault(this List<CardInformation> cardInformations, int ID)
    {
        return cardInformations.FirstOrDefault(x => x.ID == ID);
    }
}