using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ExplorationData
{
    public int ID;
    public PetData pet;
    public int secondsLeft;
    public bool isCompleted;
    public ExplorationData(int ID, PetData pet, int secondsLeft)
    {
        this.pet = pet;
        this.secondsLeft = secondsLeft;
        this.ID = ID;
    }
    public void PassTime(int time)
    {
        if (isCompleted)
        {
            return;
        }
        else
        {
            if (secondsLeft <= 0)
                isCompleted = true;
            else
                secondsLeft -= time;
        }
    }
}
