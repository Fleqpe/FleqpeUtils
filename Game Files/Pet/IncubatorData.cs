using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class IncubatorData
{
    public PetData pet = new PetData();
    public int secondsLeft;
    public bool isCompleted;
    public IncubatorData(PetData pet, int secondsLeft)
    {
        this.pet = pet;
        this.secondsLeft = secondsLeft;
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
