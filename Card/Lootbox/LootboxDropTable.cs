using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Entry/Lootbox Drop Table")]
public class LootboxDropTable : ScriptableObject
{
    [SerializeField] private List<LootboxItemAndChance> lootboxItems = new List<LootboxItemAndChance>();
    public float GetTotalChance()
    {
        return lootboxItems.FindAll(x => x != null).Sum(x => x.chance);
    }
    public float GetTotalChanceOfRarity(Rarity rarity)
    {
        return lootboxItems.FindAll(x => x != null && x.item.GetRarity() == rarity).Sum(x => x.chance);
    }
    public LootboxItem GetRandomItem()
    {
        float rolledNumber = Random.Range(0f, lootboxItems.Sum(x => x.chance));
        float currentNumber = 0;
        foreach (LootboxItemAndChance lootboxItem in lootboxItems)
        {
            currentNumber += lootboxItem.chance;
            if (rolledNumber <= currentNumber)
                return lootboxItem.item;
        }
        return lootboxItems.Find(x => x.chance == lootboxItems.Max(x => x.chance)).item;
    }
}
[System.Serializable]
public class LootboxItemAndChance
{
    public LootboxItem item;
    public float chance = 0;
}