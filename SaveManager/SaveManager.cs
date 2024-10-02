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
            RepeatTask().Forget();
      }
      private async UniTaskVoid RepeatTask()
      {
            await UniTask.Delay(TimeSpan.FromSeconds(saveInterval))
            .AttachExternalCancellation(cts.Token);
            Save();
            RepeatTask().Forget();
      }
      public void Save()
      {
            gameFiles.time = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);
            gameFiles.version = Application.version;
            string saveString = JsonUtility.ToJson(gameFiles);
            PlayerPrefs.SetString("Save", saveString);
      }
      public void Load()
      {
            string loadString = PlayerPrefs.GetString("Save", "null");
            if (loadString != "null")
                  JsonUtility.FromJsonOverwrite(loadString, gameFiles);
            else
                  Save();
      }
}