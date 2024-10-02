using System;
using System.Collections;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SoundManager : PersistentSingletonManager<SoundManager>
{
    [SerializeField] private AudioSource buy, music, click, success;
    private float buyStartVolume, musicStartVolume, clickStartVolume, successStartVolume;
    private CancellationTokenSource cts = new CancellationTokenSource();
    void OnDestroy()
    {
        cts?.Cancel();
        cts?.Dispose();
    }
    void Awake()
    {
        musicStartVolume = music.volume;
        buyStartVolume = buy.volume;
        clickStartVolume = click.volume;
    }
    void Start()
    {
        RepeatableTask().Forget();
    }
    private async UniTaskVoid RepeatableTask()
    {
        await UniTask.WaitForSeconds(0.5f)
            .AttachExternalCancellation(cts.Token);
        buy.volume = buyStartVolume * SaveManager.gameFiles.settingsData.sfx;
        music.volume = musicStartVolume * SaveManager.gameFiles.settingsData.music;
        click.volume = clickStartVolume * SaveManager.gameFiles.settingsData.sfx;
        success.volume = successStartVolume * SaveManager.gameFiles.settingsData.sfx;
        RepeatableTask().Forget();
    }
    public void PlayBuy()
    {
        buy.PlayOneShot(buy.clip);
    }
    public void PlayClick()
    {
        click.PlayOneShot(click.clip);
    }
    public void PlaySuccess()
    {
        success.PlayOneShot(success.clip);
    }
}
