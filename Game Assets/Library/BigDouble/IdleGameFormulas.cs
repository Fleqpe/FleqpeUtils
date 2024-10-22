using FleqpeUtils.BreakInfinity;
public static class IdleGameFormulas
{
    public static BigDouble CalculateCost(int ID, BigDouble costMultiplyByID, BigDouble basePrice, BigDouble priceGrowthRateMultiplier, BigDouble currentLevel, BigDouble desiredLevelCount)
    {
        return BigDouble.Pow(costMultiplyByID, ID) * basePrice
        * priceGrowthRateMultiplier.Pow(currentLevel) * (priceGrowthRateMultiplier.Pow(desiredLevelCount) - BigDouble.One)
        / (priceGrowthRateMultiplier - BigDouble.One);
    }
    public static BigDouble CalculateMaxLevelYouCanBuy(int ID, BigDouble costMultiplyByID, BigDouble basePrice, BigDouble priceGrowthRateMultiplier, BigDouble currentLevel, BigDouble ownedMoney)
    {
        return BigDouble.Floor(
            BigDouble.Log(
        (
        (ownedMoney * (priceGrowthRateMultiplier - BigDouble.One)
        / (BigDouble.Pow(costMultiplyByID, ID) * basePrice * priceGrowthRateMultiplier.Pow(currentLevel))) + BigDouble.One

        ), priceGrowthRateMultiplier));
    }
    public static BigDouble CalculateRevenue(int ID, BigDouble revenueMultiplyByID, BigDouble baseRevenue, BigDouble currentLevel, BigDouble revenueMultiplyStep)
    {
        BigDouble revenueMultiplyByLevel = currentLevel / revenueMultiplyStep;
        BigDouble two = new BigDouble(2, 0);
        return BigDouble.Pow(revenueMultiplyByID, ID) * baseRevenue * currentLevel * two.Pow(revenueMultiplyByLevel);
    }
}