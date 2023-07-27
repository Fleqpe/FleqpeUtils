using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
      public static int targetSceneId = 0;
      public TMP_Text loadingProgressBarText;
      public Image loadingProgressBarImage;
      private void Start()
      {
            StartCoroutine("LoadToTargetScene");
      }
      public IEnumerator LoadToTargetScene()
      {
            AsyncOperation loadingToTargetScene = SceneManager.LoadSceneAsync(targetSceneId);
            while (!loadingToTargetScene.isDone)
            {
                  loadingProgressBarText.text = (loadingToTargetScene.progress / .9f).ToString();
                  loadingProgressBarImage.fillAmount = loadingToTargetScene.progress / .9f;
                  yield return new WaitForFixedUpdate();
            }
      }
}
