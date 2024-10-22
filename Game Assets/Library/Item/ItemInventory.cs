using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[System.Serializable]
public class ItemInventory
{
    public List<MaterialData> materials = new List<MaterialData>();
    public void AddMaterial(int IDToAdd, int countToAdd)
    {
        MaterialData materialData = materials.FirstOrDefault(x => x.ID == IDToAdd);
        if (materialData != null)
            materialData.count += countToAdd;
        else
        {
            materials.Add(new MaterialData
            {
                ID = IDToAdd,
                count = countToAdd
            });
        }
    }
}
