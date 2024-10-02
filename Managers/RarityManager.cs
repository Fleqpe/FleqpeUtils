using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class RarityManager : PersistentSingletonManager<RarityManager>
{
    [SerializeField] private List<RarityAndMaterial> imageMaterials = new List<RarityAndMaterial>();
    [SerializeField] private List<RarityAndMaterial> textMaterials = new List<RarityAndMaterial>();
    public Material GetImageMaterial(Rarity rarity)
    {
        RarityAndMaterial rarityAndMaterial = imageMaterials.FirstOrDefault(x => x.rarity == rarity);
        if (rarityAndMaterial == null)
            return imageMaterials.First().material;
        else
            return rarityAndMaterial.material;
    }
    public Material GetTextMaterial(Rarity rarity)
    {
        RarityAndMaterial rarityAndMaterial = textMaterials.FirstOrDefault(x => x.rarity == rarity);
        if (rarityAndMaterial == null)
            return textMaterials.First().material;
        else
            return rarityAndMaterial.material;
    }
}
[System.Serializable]
public class RarityAndMaterial
{
    public Rarity rarity;
    public Material material;
}
public enum Rarity { Common, Uncommon, Rare, Epic, Legendary, Mythic, Ancient }
public static class Rarity_Extensions
{
    public static Dictionary<Rarity, Color> colors = new Dictionary<Rarity, Color>()
    {
    {Rarity.Common,Color.grey},
    {Rarity.Uncommon,Color.green},
    {Rarity.Rare,Color.blue},
    {Rarity.Epic,Color.magenta},
    {Rarity.Legendary,Color.yellow},
    {Rarity.Mythic,new Color(0f,0.3f,1f,1f)},
    {Rarity.Ancient,Color.red},
    };
    public static Color GetColor(this Rarity rarity)
    {
        if (colors.TryGetValue(rarity, out Color rarityColor))
            return colors[rarity];
        else
            return Rarity.Common.GetColor();
    }
    public static string GetColorHexCode(this Rarity rarity)
    {
        return ColorUtility.ToHtmlStringRGBA(rarity.GetColor());
    }

    public static async UniTask<string> GetLocalizedString(this Rarity rarity, CancellationToken token)
    {
        var operation = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("StringTable", rarity.ToString());
        await UniTask.WaitUntil(() => operation.IsDone)
        .AttachExternalCancellation(token);
        return operation.Result;
    }
    public static void SetTextMaterial(this TMP_Text text, Rarity rarity)
    {
        text.fontMaterial = RarityManager.Instance.GetTextMaterial(rarity);
    }
    public static void SetImageMaterial(this Image image, Rarity rarity)
    {
        image.material = RarityManager.Instance.GetImageMaterial(rarity);
    }
}