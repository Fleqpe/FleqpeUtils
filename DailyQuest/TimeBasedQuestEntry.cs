using System.Collections;
using System.Collections.Generic;
using FleqpeUtils.BreakInfinity;
using UnityEngine;
[CreateAssetMenu(fileName = "TimeBasedQuestEntry", menuName = "ScriptableObjects/Entry/Time Based Quest Entry")]
public class TimeBasedQuestEntry : EntrySO<TimeBasedQuestEntry>
{
    public string title;
    [Multiline(3)]
    public string description;
    public int requiredTime;
    public BigDouble reward;
}
