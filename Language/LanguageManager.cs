using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LanguageManager : PersistentSingletonManager<LanguageManager>
{
    public bool isLanguageSystemReady = false;
    private CancellationTokenSource cts = new CancellationTokenSource();
    private void Awake()
    {
        Initialize().Forget();
        GetCurrentLocale().Forget();
    }
    private async UniTaskVoid Initialize()
    {
        await LocalizationSettings.InitializationOperation.ToUniTask()
        .AttachExternalCancellation(cts.Token);
        isLanguageSystemReady = true;
    }
    public void ChangeLocale(int localeID)
    {
        if (!isLanguageSystemReady) return;
        SetLocale(localeID).Forget();
    }
    private async UniTaskVoid GetCurrentLocale()
    {
        await UniTask.WaitUntil(() => isLanguageSystemReady)
        .AttachExternalCancellation(cts.Token);
        int id = LocalizationSettings.AvailableLocales.Locales.IndexOf(LocalizationSettings.SelectedLocale);
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[PlayerPrefs.GetInt("LocaleKey", id)];
    }
    public async UniTaskVoid SetLocale(int localeID)
    {
        isLanguageSystemReady = false;
        await LocalizationSettings.InitializationOperation.ToUniTask()
        .AttachExternalCancellation(cts.Token);
        isLanguageSystemReady = true;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeID];
        PlayerPrefs.SetInt("LocaleKey", localeID);
    }
}
