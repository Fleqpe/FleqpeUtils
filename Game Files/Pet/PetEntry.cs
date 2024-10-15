using System.Collections;
using System.Collections.Generic;
using FleqpeUtils.BreakInfinity;
using UnityEngine;
[CreateAssetMenu(fileName = "PetEntry", menuName = "ScriptableObjects/Entry/Pet Entry")]
public class PetEntry : EntrySO<PetEntry>
{
    public string title;
    [Multiline(3)]
    public string description;
    public Sprite sprite;
    public GameObject prefab;
    public Stats statsMultiplier = new Stats();
}
