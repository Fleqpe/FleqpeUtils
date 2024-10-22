using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DropItem<T>
{
    public T item;
    public float chance = 0;
    [SerializeField] private bool showCount;
    public int count;
}