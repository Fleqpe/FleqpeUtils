using UnityEngine;

[System.Serializable]
public abstract class LootboxItem : EntrySO<LootboxItem>
{
    public int count;
    public abstract void Apply();
    public abstract Rarity GetRarity();
}

