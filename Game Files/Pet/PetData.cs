[System.Serializable]
public class PetData
{
    public int ID, XP, stars;
    public int level;
    public PetData()
    {
    }

    public PetData(PetData petDataToCopy)
    {
        if (petDataToCopy != null)
        {
            this.ID = petDataToCopy.ID;
            this.XP = petDataToCopy.XP;
            this.stars = petDataToCopy.stars;
            this.level = petDataToCopy.level;
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