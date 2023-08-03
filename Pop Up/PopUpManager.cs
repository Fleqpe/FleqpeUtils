using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
public class PopUpManager : MonoBehaviour
{
      public GameObject popUpObject;
      public Queue<GameObject> popUpQueue = new Queue<GameObject>();
      public GameObject canvasObject;
      private void Start()
      {
            CreatePopUp("Test Pop Up Name", "Test Pop Up Info");
      }
      public void CreatePopUp(string nameText, string infoText)
      {
            GameObject createdPopUp = Instantiate(popUpObject);
            createdPopUp.transform.SetParent(canvasObject.transform, false);
            createdPopUp.GetComponent<PopUp>().SetInfoText(infoText);
            createdPopUp.GetComponent<PopUp>().SetNameText(name);
            popUpQueue.Enqueue(createdPopUp);
            MovePopUp();
      }
      public void MovePopUp()
      {
            GameObject lastPopUp = popUpQueue.Dequeue();
            lastPopUp.GetComponent<RectTransform>().DOAnchorPosY(-100, 5f, true)
            .OnComplete(() => Destroy(lastPopUp))
            .SetEase(Ease.Linear);
      }
}
