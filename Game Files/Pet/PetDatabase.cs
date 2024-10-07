using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
[CreateAssetMenu(fileName = "PetDatabase", menuName = "ScriptableObjects/Database/Pet Database")]
public class PetDatabase : SingletonSO<PetDatabase>
{
    [TableList][SerializeField] private List<PetEntry> pets = new List<PetEntry>();
    public PetEntry GetPet(int ID)
    {
        return pets.FirstOrDefault(x => x.ID == ID);
    }
}
