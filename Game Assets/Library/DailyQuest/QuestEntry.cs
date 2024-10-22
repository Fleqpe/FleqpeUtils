using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "QuestEntry", menuName = "ScriptableObjects/Entry/Quest Entry")]
public class QuestEntry : EntrySO<QuestEntry>
{
    public string title;
    [Multiline(3)]
    public string description;
}
