using UnityEngine;
using System;
using System.Globalization;
using System.Threading;
using Cysharp.Threading.Tasks;
[DefaultExecutionOrder(0)]
public class SaveManager : PersistentSingletonManager<SaveManager>
{
      public static GameFiles gameFiles { get { return Instance._gameFiles; } }
      [SerializeField] private float saveInterval;
      [SerializeField] private GameFiles _gameFiles = new GameFiles();
      [SerializeField] private bool isSaving = false;
      private CancellationTokenSource cts = new CancellationTokenSource();
      void OnDestroy()
      {
            cts?.Cancel();
            cts?.Dispose();
      }
      void Awake()
      {
            Load();
      }
      void Start()
      {
            RepeatSave().Forget();
      }
      private async UniTaskVoid RepeatSave()
      {
            while (!cts.Token.IsCancellationRequested)
            {
                  await UniTask.Delay(TimeSpan.FromSeconds(saveInterval))
                  .AttachExternalCancellation(cts.Token);
                  await Save()
                  .AttachExternalCancellation(cts.Token);
            }
      }
      public async UniTask Save()
      {
            if (isSaving)
                  return;
            isSaving = true;
            gameFiles.time = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);
            gameFiles.version = Application.version;
            string saveString = JsonUtility.ToJson(gameFiles);
            PlayerPrefs.SetString("Save", saveString);
            await UniTask.WaitForSeconds(1f);
            isSaving = false;
      }
      public void Load()
      {
            string loadString = PlayerPrefs.GetString("Save", "null");
            if (loadString != "null")
                  JsonUtility.FromJsonOverwrite(loadString, gameFiles);
            else
                  Save().Forget();
      }
}