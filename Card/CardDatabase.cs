using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
[CreateAssetMenu(fileName = "CardDatabase", menuName = "ScriptableObjects/Database/Card Database")]
public class CardDatabase : SingletonSO<CardDatabase>
{
    public int maxEquippableCardAmount;
    [TableList][SerializeField] private List<CardInformation> cardInformations = new List<CardInformation>();
    [TableList][SerializeField] private List<CardSellValue> cardSellValues = new List<CardSellValue>();
    public CardInformation GetCardInformation(int cardID)
    {
        return cardInformations.FirstOrDefault(x => x.ID == cardID);
    }
    public CardSellValue GetCardSellValue(int cardID)
    {
        return cardSellValues.FirstOrDefault(x => x.rarity == GetCardInformation(cardID).rarity);
    }
}
