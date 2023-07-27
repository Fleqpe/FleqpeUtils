using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;
public abstract class InventoryDisplayer : MonoBehaviour
{
      public Button decreasePageButton, increasePageButton;
      public List<GameObject> itemBoxObjects = new List<GameObject>();
      public int currentPage = 0;
      public void IncreasePage()
      {
            currentPage += 1;
      }
      public void DecreasePage()
      {
            currentPage -= 1;
      }
      public abstract void Display();
}
