using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class GridRaycaster : MonoBehaviour
{
      public GridBuildingSystem gridBuildingSystem;
      public Building building;
      private void Update()
      {
            if (Input.GetMouseButtonDown(0))
                  RaycastToGrid();
      }
      public void RaycastToGrid()
      {
            if (building != null)
                  return;
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.zero, 1);
            if (hit)
                  SetBuilding(hit.collider.GetComponent<Building>());
      }
      public void SetBuilding(Building building)
      {
            if (building == null)
            {
                  this.building.spriteRenderer.color = Color.white;
                  this.building = null;
            }
            else
            {
                  this.building = building;
                  building.spriteRenderer.color = Color.green;
            }

      }
}
