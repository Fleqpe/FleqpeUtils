using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class PetInventory
{
    public List<PetData> pets = new List<PetData>();
    public List<IncubatorData> petsInTheIncubator = new List<IncubatorData>();
    public void AddPetToIncubator(PetData pet, float timeToSpentInIncubator)
    {
        if (!pets.Contains(pet))
            return;
        else
        {
            pets.Remove(pet);
            petsInTheIncubator.Add(new IncubatorData(pet, timeToSpentInIncubator));
        }
    }
    public void RemovePetFromIncubator(PetData pet)
    {
        IncubatorData incubatorData = petsInTheIncubator.FirstOrDefault(x => x.petInTheIncubator == pet);
        if (incubatorData == null)
            return;
        else
        {
            pets.Add(incubatorData.petInTheIncubator);
            petsInTheIncubator.Remove(incubatorData);
        }
    }
}