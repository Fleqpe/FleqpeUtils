using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PopUp : MonoBehaviour
{
      public TMP_Text infoText;
      public TMP_Text nameText;
      public void SetInfoText(string text)
      {
            infoText.text = text;
      }
      public void SetNameText(string text)
      {
            nameText.text = text;
      }

}
