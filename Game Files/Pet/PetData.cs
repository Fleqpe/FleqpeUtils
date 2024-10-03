[System.Serializable]
public class PetData
{
    public int ID, stars;
    public ExperienceData experienceData = new ExperienceData();
    public PetData()
    {
    }
    public PetData(PetData petDataToCopy)
    {
        if (petDataToCopy != null)
        {
            this.ID = petDataToCopy.ID;
            this.stars = petDataToCopy.stars;
        }
    }
}
/*
Pets Can explore areas to earn materials.
Evolving is based on stars.
Evolving requires level,xp,materials.
Pets can be sacrificed for xp.
Arena.
Raid.
*/