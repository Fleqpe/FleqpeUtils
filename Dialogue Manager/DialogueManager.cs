using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueManager : MonoBehaviour
{
      public TMP_Text dialogueText, nameText;
      public Queue<string> sentences = new Queue<string>();
      public void StartDialogue(Dialogue dialogue)
      {
            nameText.text = dialogue.name;
            sentences.Clear();
            foreach (string sentence in dialogue.sentences)
                  sentences.Enqueue(sentence);
            DisplayNextSentence();
      }
      public void DisplayNextSentence()
      {
            if (sentences.Count == 0)
            {
                  EndDialogue();
                  return;
            }
            string sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
      }
      public IEnumerator TypeSentence(string sentence)
      {
            dialogueText.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                  dialogueText.text += letter;
                  yield return new WaitForFixedUpdate();
            }
      }
      public void EndDialogue()
      {
            dialogueText.text = "Dialogue Ended.";
      }
}
