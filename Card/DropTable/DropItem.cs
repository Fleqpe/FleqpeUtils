using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[System.Serializable]
public class DropItem<T>
{
    public T item;
    public float chance = 0;
    [SerializeField] private bool showCount;
    [ShowIf("showCount")]
    public int count;
}