using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorationData : MonoBehaviour
{
    public int explorationID;
    public PetData pet;
    public int secondsLeft;
    public bool isCompleted;
    public ExplorationData(int explorationID, PetData pet, int secondsLeft)
    {
        this.pet = pet;
        this.secondsLeft = secondsLeft;
        this.explorationID = explorationID;
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
