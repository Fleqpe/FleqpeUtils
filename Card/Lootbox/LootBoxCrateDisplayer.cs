using System;
using System.Collections;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LootboxCrateDisplayer : MonoBehaviour
{
    [SerializeField] private LootboxDropTable lootboxDropTable;
    [SerializeField] private TMP_Text rarityList, priceText;
    [SerializeField] private Button button;
    [SerializeField] private LootboxRewardDisplayer lootboxRewardDisplayer;
    [SerializeField] private int price;
    private void Start()
    {
        Display().Forget();
    }
    private async UniTaskVoid Display()
    {
        while (!destroyCancellationToken.IsCancellationRequested)
        {
            await UniTask.WaitForSeconds(0.1f)
            .AttachExternalCancellation(destroyCancellationToken);
            await UniTask.WaitUntil(() => LanguageManager.Instance.isLanguageSystemReady)
            .AttachExternalCancellation(destroyCancellationToken);
            await SetTexts();
            SetButtons();
        }
    }
    private void SetButtons()
    {
        button.interactable = SaveManager.gameFiles.playerData.currencyData.premiumMoney >= price;
    }
    private async UniTask SetTexts()
    {
        priceText.text = price.ToString("F0") + "<sprite=0>";
        rarityList.text = "";
        foreach (Rarity rarity in Enum.GetValues(typeof(Rarity)))
            rarityList.text += await GetRarityText(rarity);
    }
    private async UniTask<string> GetRarityText(Rarity rarity)
    {
        float totalChance = lootboxDropTable.GetTotalChance();
        float chance = lootboxDropTable.GetTotalChanceOfRarity(rarity);
        if (chance > 0)
            return $"<color={"#" + rarity.GetColorHexCode()}>{await rarity.GetLocalizedString(destroyCancellationToken)} %{chance / totalChance * 100}" + "\n";
        else
            return "";
    }
    public void OpenBox()
    {
        if (SaveManager.gameFiles.playerData.currencyData.premiumMoney < price) return;
        LootboxItem lootboxItem = lootboxDropTable.GetRandomItem();
        lootboxItem.Apply();
        lootboxRewardDisplayer.Display(lootboxItem);
        CardDisplayerManager.onUnbox.Invoke();
        SaveManager.gameFiles.playerData.currencyData.SpendPremiumMoney(price);
    }
}
