using System.Collections;
using System.Collections.Generic;
using FleqpeUtils.BreakInfinity;
using UnityEngine;
[CreateAssetMenu(fileName = "ExplorationEntry", menuName = "ScriptableObjects/Entry/Exploration Entry")]
public class ExplorationEntry : EntrySO<ExplorationEntry>
{
    public BigDouble levelRequirement;
}
