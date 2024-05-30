using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public int healthPotions = 0;
    public int manaPotions = 0;
    public int xpPotions = 0;
    public int helmetLevel = 1;
    public int bootsLevel = 1;
    public int bodyArmorLevel = 1;

    public void AddHealthPotion()
    {
        healthPotions++;
    }

    public void AddManaPotion()
    {
        manaPotions++;
    }

    public void UpgradeHelmet()
    {
        helmetLevel++;
    }

    public void UpgradeBoots()
    {
        bootsLevel++;
    }

    public void UpgradeBodyArmor()
    {
        bodyArmorLevel++;
    }

    public int GetHealthPotions()
    {
        return healthPotions;
    }

    public int GetManaPotions()
    {
        return manaPotions;
    }

    public int GetHelmetLevel()
    {
        return helmetLevel;
    }

    public int GetBootsLevel()
    {
        return bootsLevel;
    }

    public int GetBodyArmorLevel()
    {
        return bodyArmorLevel;
    }

    public bool ConsumeHPpotion()
    {
        if (healthPotions == 0 || FindObjectOfType<PlayerStats>().health == FindObjectOfType<PlayerStats>().maxHealth)
            return false;

        healthPotions--;
        FindObjectOfType<PlayerStats>().RestoreHealthPerc(20);
        
        return true;
    }

    public bool ConsumeMPpotion()
    {
        if (manaPotions == 0 || FindObjectOfType<PlayerStats>().mana == FindObjectOfType<PlayerStats>().maxMana)
            return false;

        manaPotions--;
        FindObjectOfType<PlayerStats>().RestoreManaPerc(15);

        return true;
    }

    public bool ConsumeXPpotion()
    {
        if (xpPotions == 0 || FindObjectOfType<PlayerStats>().experience == FindObjectOfType<PlayerStats>().MaxXP)
            return false;

        xpPotions--;
        FindObjectOfType<PlayerStats>().AddExperiencePerc(30);

        return true;

    }
}
