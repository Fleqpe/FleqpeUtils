using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[CreateAssetMenu(fileName = "ItemDatabase", menuName = "ScriptableObjects/Database/Item Database")]
public class ItemDatabase : SingletonSO<ItemDatabase>
{
    [SerializeField] private List<MaterialEntry> materials = new List<MaterialEntry>();
    public MaterialEntry GetMaterial(int ID)
    {
        return materials.FirstOrDefault(x => x.ID == ID);
    }

}
