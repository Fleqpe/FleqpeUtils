using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BuildingUI : MonoBehaviour
{
      public GridBuildingSystem gridBuildingSystem;
      public GridRaycaster gridRaycaster;
      public GameObject buildingInfo;
      public GameObject builder;
      private void Start()
      {
            StartCoroutine("HandleBuilderMenu");
            StartCoroutine("HandleBuildingInfoMenu");
      }
      public IEnumerator HandleBuilderMenu()
      {
            yield return new WaitUntil(() => gridBuildingSystem.selectedPrefab != null && gridRaycaster.building == null);
            builder.GetComponent<RectTransform>().DOAnchorPosX(-200, 0.5f);
            yield return new WaitUntil(() => gridBuildingSystem.selectedPrefab == null);
            builder.GetComponent<RectTransform>().DOAnchorPosX(0, 0.5f);
            StartCoroutine("HandleBuilderMenu");
      }
      public IEnumerator HandleBuildingInfoMenu()
      {
            yield return new WaitUntil(() => gridRaycaster.building != null);
            buildingInfo.GetComponent<RectTransform>().DOAnchorPosY(0, 0.5f);
            yield return new WaitUntil(() => gridRaycaster.building == null);
            buildingInfo.GetComponent<RectTransform>().DOAnchorPosY(200, 0.5f);
            StartCoroutine("HandleBuildingInfoMenu");
      }
}
