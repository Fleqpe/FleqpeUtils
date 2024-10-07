using System;

public static class EventBus
{
    public static Action onPremiumCurrencyEarn;
    public static Action<ExperienceData> onPetLevelUp;
}
