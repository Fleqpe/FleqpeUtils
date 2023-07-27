using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueDatabase", menuName = "ScriptableObject/Dialogue Database")]
public class DialogueDatabase : ScriptableObject
{
      [SerializeField] private List<Dialogue> dialogues;
      private static DialogueDatabase GetDatabase()
      {
            return Resources.Load<DialogueDatabase>("DialogueDatabase");
      }
      public static Dialogue GetDialogue(string id)
      {
            return GetDatabase().dialogues.Find(x => x.id == id);
      }
}
