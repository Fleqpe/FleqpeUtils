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
    [SerializeField] private AudioClip buy, click, success;
    [SerializeField] private AudioSource music, sfx;
    private float musicVolume, sfxVolume;
    private CancellationTokenSource cts = new CancellationTokenSource();
    void OnDestroy()
    {
        cts?.Cancel();
        cts?.Dispose();
    }
    void Awake()
    {
        musicVolume = music.volume;
        sfxVolume = sfx.volume;
    }
    void Start()
    {
        RepeatableTask().Forget();
    }
    private async UniTaskVoid RepeatableTask()
    {
        while (!cts.Token.IsCancellationRequested)
        {
            await UniTask.WaitForSeconds(0.5f)
                .AttachExternalCancellation(cts.Token);
            SettingsData settingsData = SaveManager.gameFiles.playerData.settingsData;
            music.volume = musicVolume * settingsData.music;
            sfx.volume = sfxVolume * settingsData.sfx;
        }
    }
    public void PlayBuy()
    {
        sfx.clip = buy;
        sfx.Play();
    }
    public void PlayClick()
    {
        sfx.clip = click;
        sfx.Play();
    }
    public void PlaySuccess()
    {
        sfx.clip = success;
        sfx.Play();
    }
}
