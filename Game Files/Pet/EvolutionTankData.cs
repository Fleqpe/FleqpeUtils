using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class EvolutionTankData
{
    public int tankIndex;
    public PetData pet = new PetData();
    public EvolutionTankData(PetData pet, int tankIndex)
    {
        this.pet = pet;
        this.tankIndex = tankIndex;
    }
    public void PassTime(int time)
    {
        pet.experienceData.EarnXP(GameDatabase.Instance.GetXPGain(time));
    }
}
