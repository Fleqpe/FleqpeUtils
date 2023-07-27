using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
      public string id;
      public void TriggerDialogue()
      {
            FindObjectOfType<DialogueManager>().StartDialogue(DialogueDatabase.GetDialogue("test"));
      }
}
