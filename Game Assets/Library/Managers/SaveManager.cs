using UnityEngine;
using System;
using System.Globalization;
using Cysharp.Threading.Tasks;
[DefaultExecutionOrder(0)]
public class SaveManager : PersistentSingletonManager<SaveManager>
{
      public static GameFiles gameFiles { get { return Instance._gameFiles; } }
      [SerializeField] private float saveInterval;
      [SerializeField] private GameFiles _gameFiles = new GameFiles();
      [SerializeField] private bool isSaving = false;
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
            while (!destroyCancellationToken.IsCancellationRequested)
            {
                  await UniTask.WaitForSeconds(saveInterval)
                  .AttachExternalCancellation(destroyCancellationToken);
                  await Save()
                  .AttachExternalCancellation(destroyCancellationToken);
            }
      }
      public async UniTask Save()
      {
            if (isSaving)
                  return;
            isSaving = true;
            gameFiles.time = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);
            gameFiles.version = Application.version;
            string saveString = JsonUtility.ToJson(gameFiles, true);
            PlayerPrefs.SetString("Save", saveString);
            await UniTask.WaitForSeconds(1f);
            isSaving = false;
      }
      private void Load()
      {
            string loadString = PlayerPrefs.GetString("Save", "null");
            if (loadString != "null")
                  JsonUtility.FromJsonOverwrite(loadString, _gameFiles);
            else
                  Save().Forget();
      }
}