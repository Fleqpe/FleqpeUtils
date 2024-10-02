using System;
using System.Collections.Generic;
using System.Globalization;
[Serializable]
public class GameFiles
{
      public string version = "0";
      public string time = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);
      public CurrencyData currencyData = new CurrencyData();
      public SettingsData settingsData = new SettingsData();
      public PetInventory petInventory = new PetInventory();
      public DailyQuestData dailyQuestData = new DailyQuestData();
      public CardInventory cardInventory = new CardInventory();
}
