using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CountBasedQuestEntry", menuName = "ScriptableObjects/Entry/Count Based Quest Entry")]
public class CountBasedQuestEntry : EntrySO<CountBasedQuestEntry>
{
    public string title;
    [Multiline(3)]
    public string description;
    public int required;
}
