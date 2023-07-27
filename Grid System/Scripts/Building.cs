using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
public class Building : MonoBehaviour
{
      public bool isPlaced = false;
      public BoundsInt area = new BoundsInt();
      public SpriteRenderer spriteRenderer;
      private BuildingData _buildingData;
      public BuildingData buildingData
      {
            get { return _buildingData; }
            set { _buildingData = value; }
      }
      public async void Toggle()
      {
            await Task.Delay(500);
            isPlaced = !isPlaced;
            this.gameObject.GetComponent<BoxCollider2D>().enabled = isPlaced;
      }
}
