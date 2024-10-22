using System.Collections.Generic;
using System.Linq;
[System.Serializable]
public class CardInventory
{
    public List<int> equippedCards = new List<int>();
    public List<CardData> cardDatas = new List<CardData>();
    public void EquipCardData(int ID)
    {
        if (equippedCards.Exists(x => x == ID) || equippedCards.Count >= CardDatabase.Instance.maxEquippableCardAmount) return;
        equippedCards.Add(ID);
    }
    public void UnequipCardData(int ID)
    {
        if (!equippedCards.Exists(x => x == ID)) return;
        equippedCards.Remove(ID);
    }
    public void AddCardData(int cardIDToAdd, int cardCountToAdd)
    {
        CardData foundCardData = cardDatas.FirstOrDefault(x => x.ID == cardIDToAdd);
        if (foundCardData == null)
            cardDatas.Add(new CardData() { ID = cardIDToAdd, count = cardCountToAdd });
        else
            foundCardData.count += cardCountToAdd;
    }
}
