using FleqpeUtils.BreakInfinity;

[System.Serializable]
public class PetData
{
    public int ID, stars, crowns;
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
    public Stats GetPetStats()
    {
        BigDouble starAndCrownBonus = ((stars + crowns) / 100f * 10f) + 1f;
        PetEntry petEntry = PetDatabase.Instance.GetPet(ID);
        Stats statsMultiplier = petEntry != null ? petEntry.statsMultiplier : new Stats();
        return statsMultiplier.MultiplyWith(BigDouble.Multiply(starAndCrownBonus, experienceData.level));
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