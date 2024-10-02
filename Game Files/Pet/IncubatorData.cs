using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class IncubatorData
{
    public PetData petInTheIncubator = new PetData();
    public float secondsLeft;
    public IncubatorData(PetData petInTheIncubator, float secondsLeft)
    {
        this.petInTheIncubator = petInTheIncubator;
        this.secondsLeft = secondsLeft;
    }
}
