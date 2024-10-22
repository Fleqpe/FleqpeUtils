using FleqpeUtils.BreakInfinity;
public static class CurrencyConverter
{
    private static string[] suffix = new string[] { "", "K", "M", "B", "T", "q", "Q", "s", "S", "o", "n", "d", "U", "D", "A", "B", "C", "D" };
    public static string GetString(this BigDouble valueToConvert)
    {
        int scale = (int)BigDouble.Log(valueToConvert, 1000);
        if (scale < 1)
            return valueToConvert.ToString("F0");
        else if (scale >= suffix.Length)
            return valueToConvert.ToString("E1");
        else
            return (valueToConvert / BigDouble.Pow(1000, scale)).ToString("F1") + " " + suffix[scale];
    }
}