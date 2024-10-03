using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class PetInventory
{
    public List<PetData> pets = new List<PetData>();
    public List<IncubatorData> petsInTheIncubator = new List<IncubatorData>();
    public List<ExplorationData> petsInTheExploration = new List<ExplorationData>();
    public void AddPetToIncubator(PetData pet, int timeToSpentInIncubator)
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
        IncubatorData incubatorData = petsInTheIncubator.FirstOrDefault(x => x.pet == pet);
        if (incubatorData == null)
            return;
        else
        {
            pets.Add(incubatorData.pet);
            petsInTheIncubator.Remove(incubatorData);
        }
    }
    public void AddPetToExploration(int ID, PetData pet, int timeToSpentInExploration)
    {
        if (!pets.Contains(pet))
            return;
        else
        {
            pets.Remove(pet);
            petsInTheExploration.Add(new ExplorationData(ID, pet, timeToSpentInExploration));
        }
    }
    public void RemovePetFromExploration(PetData pet)
    {
        ExplorationData explorationData = petsInTheExploration.FirstOrDefault(x => x.pet == pet);
        if (explorationData == null)
            return;
        else
        {
            pets.Add(explorationData.pet);
            petsInTheExploration.Remove(explorationData);
        }
    }
}