using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public int healthPotions = 0;
    public int manaPotions = 0;
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
}
