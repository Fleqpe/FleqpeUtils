using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "MaterialEntry", menuName = "ScriptableObjects/Entry/Material Entry")]
public class MaterialEntry : EntrySO<MaterialEntry>
{
    public string title;
    [Multiline(3)]
    public string description;
}
