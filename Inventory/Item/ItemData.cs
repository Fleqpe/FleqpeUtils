using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class ItemData
{
      public string name;
      public Sprite sprite;
      [TextArea(3, 5)]
      public string details;
      public string id;
}
