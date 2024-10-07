using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
[System.Serializable]
public class PetInventory
{
    public List<PetData> pets = new List<PetData>();
    public List<EvolutionTankData> petsInTheEvolutionTank = new List<EvolutionTankData>();
    public List<ExplorationData> petsInTheExploration = new List<ExplorationData>();
    public ExplorationData GetExplorationData(int ID)
    {
        return petsInTheExploration.FirstOrDefault(x => x.ID == ID);
    }
    public EvolutionTankData GetEvolutionTankData(int index)
    {
        return petsInTheEvolutionTank.FirstOrDefault(x => x.tankIndex == index);
    }
    public void AddPetToEvolutionTank(PetData pet, int tankIndex)
    {
        if (!pets.Contains(pet))
            return;
        else
        {
            pets.Remove(pet);
            petsInTheEvolutionTank.Add(new EvolutionTankData(pet, tankIndex));
        }
    }
    public void RemovePetFromEvolutionTank(PetData pet)
    {
        EvolutionTankData evolutionTankData = petsInTheEvolutionTank.FirstOrDefault(x => x.pet == pet);
        if (evolutionTankData == null)
            return;
        else
        {
            pets.Add(evolutionTankData.pet);
            petsInTheEvolutionTank.Remove(evolutionTankData);
        }
    }
    public void AddPetToExploration(int ID, PetData pet, int timeToSpentInExploration)
    {
        if (!pets.Contains(pet))
        {
            return;
        }
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