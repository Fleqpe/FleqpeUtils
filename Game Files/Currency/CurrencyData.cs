using System;
using FleqpeUtils.BreakInfinity;
[Serializable]
public class CurrencyData
{
    public BigDouble money = new BigDouble(5, 2);
    public BigDouble premiumMoney = new BigDouble(0, 0);
    public BigDouble level = 0;
    public BigDouble xp = 0;
    public void SpendMoney(BigDouble amount)
    {
        money -= amount;
    }
    public void EarnMoney(BigDouble amount)
    {
        money += amount;
    }
    public void SpendPremiumMoney(BigDouble amount)
    {
        premiumMoney -= amount;
    }
    public void EarnPremiumMoney(BigDouble amount)
    {
        premiumMoney += amount;
    }
    public bool HaveEnoughMoney(BigDouble amount) { return money >= amount; }
}
