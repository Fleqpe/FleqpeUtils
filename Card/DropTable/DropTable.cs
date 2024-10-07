using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[System.Serializable]
public class DropTable<T>
{
    [SerializeField] private List<DropItem<T>> droppableItems = new List<DropItem<T>>();
    public List<DropItem<T>> GetItems()
    {
        return droppableItems;
    }
    public float GetTotalChance()
    {
        return droppableItems.FindAll(x => x != null).Sum(x => x.chance);
    }
    public float GetItemChance(DropItem<T> item)
    {
        return item.chance / GetTotalChance() * 100;
    }
    public DropItem<T> GetRandomItem()
    {
        float rolledNumber = Random.Range(0f, droppableItems.Sum(x => x.chance));
        float currentNumber = 0;
        foreach (DropItem<T> lootboxItem in droppableItems)
        {
            currentNumber += lootboxItem.chance;
            if (rolledNumber <= currentNumber)
                return lootboxItem;
        }
        return droppableItems.Find(x => x.chance == droppableItems.Max(x => x.chance));
    }
}