using UnityEngine;
[System.Serializable]
public class CardBonus
{
    public CardBonusType cardBonusType;
    [SerializeField] private float bonusAmount;
    [SerializeField] private float bonusAmountIncreasePerLevel;
    public float GetBonusAmount(int level)
    {
        return bonusAmount + (bonusAmountIncreasePerLevel * (level - 1));
    }
}
public enum CardBonusType
{
    MaterialMultiplyChance, XPEarn, GoldEarn
}