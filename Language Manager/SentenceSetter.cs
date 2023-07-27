using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
[RequireComponent(typeof(TextMeshProUGUI))]
public class SentenceSetter : MonoBehaviour
{
      public TMP_Text textToChange;
      public string keyword;
      public UnityEvent languageTrigger;
      private void Reset()
      {
            textToChange = this.gameObject.GetComponent<TMP_Text>();
      }
      private void Start()
      {
            InvokeRepeating("Trigger", 0f, 1f);
      }
      private void Trigger()
      {
            languageTrigger.Invoke();
      }

      public void SetSentence()
      {
            textToChange.text = LanguageManager.languageDictionary[keyword];
      }
}
