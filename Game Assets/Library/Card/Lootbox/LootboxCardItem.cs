using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObjects/Entry/Lootbox Card Item")]

public class LootboxCardItem : LootboxItem
{
    public CardInformation cardInformation;
    public override void Apply()
    {
        SaveManager.gameFiles.cardInventory.AddCardData(cardInformation.ID, count);
    }
    public override Rarity GetRarity()
    {
        return cardInformation.rarity;
    }
}
