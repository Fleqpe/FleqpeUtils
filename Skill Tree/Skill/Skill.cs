using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Skill
{
      public string id = "";
      public abstract void Apply();
      public abstract void Remove();
}