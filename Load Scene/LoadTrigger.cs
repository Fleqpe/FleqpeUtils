using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadTrigger : MonoBehaviour
{
      public void ChangeScenes(int targetSceneId)
      {
            SceneLoader.targetSceneId = targetSceneId;
            SceneManager.LoadScene(0);
      }
}
