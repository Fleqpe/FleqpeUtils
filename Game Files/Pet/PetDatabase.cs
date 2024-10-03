using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[CreateAssetMenu(fileName = "PetDatabase", menuName = "ScriptableObjects/Database/Pet Database")]
public class PetDatabase : SingletonSO<PetDatabase>
{
    [SerializeField] private List<PetEntry> pets = new List<PetEntry>();
    public PetEntry GetPet(int ID)
    {
        return pets.FirstOrDefault(x => x.ID == ID);
    }
}
