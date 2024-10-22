using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Entry/Lootbox Drop Table")]
public class LootboxDropTable : ScriptableObject
{
    [SerializeField] private DropTable<LootboxItem> dropTable = new DropTable<LootboxItem>();
    public float GetTotalChanceOfRarity(Rarity rarity)
    {
        return dropTable.GetItems().FindAll(x => x != null && x.item.GetRarity() == rarity).Sum(x => x.chance);
    }
    public float GetTotalChance()
    {
        return dropTable.GetItems().FindAll(x => x != null).Sum(x => x.chance);
    }
    public LootboxItem GetRandomItem()
    {
        return dropTable.GetRandomItem().item;
    }
}