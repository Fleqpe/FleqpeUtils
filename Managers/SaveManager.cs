using UnityEngine;
using System;
using System.Globalization;
using System.Threading;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
[DefaultExecutionOrder(0)]
public class SaveManager : PersistentSingletonManager<SaveManager>
{
      public static GameFiles gameFiles { get { return Instance._gameFiles; } }
      [SerializeField] private float saveInterval;
      [SerializeField] private GameFiles _gameFiles = new GameFiles();
      [SerializeField] private bool isSaving = false;
      private CancellationTokenSource cts = new CancellationTokenSource();
      private JsonSerializerSettings serializerSettings;
      void OnDestroy()
      {
            cts?.Cancel();
            cts?.Dispose();
      }
      void Awake()
      {
            InitializeJsonSerializerSettings();
            Load();
      }
      void Start()
      {
            RepeatSave().Forget();
      }
      private void InitializeJsonSerializerSettings()
      {
            serializerSettings = new JsonSerializerSettings
            {
                  TypeNameHandling = TypeNameHandling.Auto,
            };
      }
      private async UniTaskVoid RepeatSave()
      {
            while (!cts.Token.IsCancellationRequested)
            {
                  await UniTask.WaitForSeconds(saveInterval)
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
            string saveString = JsonConvert.SerializeObject(gameFiles, serializerSettings);
            PlayerPrefs.SetString("Save", saveString);
            await UniTask.WaitForSeconds(1f);
            isSaving = false;
      }
      private void Load()
      {
            string loadString = PlayerPrefs.GetString("Save", "null");
            if (loadString != "null")
                  _gameFiles = JsonConvert.DeserializeObject<GameFiles>(loadString, serializerSettings);
            else
                  Save().Forget();
      }
}