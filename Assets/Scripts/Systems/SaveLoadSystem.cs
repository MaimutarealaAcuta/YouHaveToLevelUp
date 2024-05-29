using UnityEngine;
using System.Collections;

public class SaveLoadSystem : MonoBehaviour
{
    public PlayerStats playerStats;
    public BankSystem bankSystem;
    public InventorySystem inventorySystem;
    public TimerSystem timerSystem;

    void Start()
    {
        LoadGame();
        StartCoroutine(AutoSave());
    }

    IEnumerator AutoSave()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            SaveGame();
        }
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("Level", playerStats.level);
        PlayerPrefs.SetInt("Experience", playerStats.experience);
        PlayerPrefs.SetInt("Health", playerStats.health);
        PlayerPrefs.SetInt("MaxHealth", playerStats.maxHealth);
        PlayerPrefs.SetInt("Mana", playerStats.mana);
        PlayerPrefs.SetInt("MaxMana", playerStats.maxMana);
        PlayerPrefs.SetInt("Attack", playerStats.attack);
        PlayerPrefs.SetInt("Defense", playerStats.defense);
        PlayerPrefs.SetInt("Money", bankSystem.GetMoney());
        PlayerPrefs.SetInt("HealthPotions", inventorySystem.GetHealthPotions());
        PlayerPrefs.SetInt("ManaPotions", inventorySystem.GetManaPotions());
        PlayerPrefs.SetInt("HelmetLevel", inventorySystem.GetHelmetLevel());
        PlayerPrefs.SetInt("BootsLevel", inventorySystem.GetBootsLevel());
        PlayerPrefs.SetInt("BodyArmorLevel", inventorySystem.GetBodyArmorLevel());
        PlayerPrefs.SetFloat("TimeElapsed", timerSystem.timeElapsed);
        PlayerPrefs.SetInt("SawInfoPanel", 1); // Assuming this is a bool, 1 means true
        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            playerStats.level = PlayerPrefs.GetInt("Level");
            playerStats.experience = PlayerPrefs.GetInt("Experience");
            playerStats.health = PlayerPrefs.GetInt("Health");
            playerStats.maxHealth = PlayerPrefs.GetInt("MaxHealth");
            playerStats.mana = PlayerPrefs.GetInt("Mana");
            playerStats.maxMana = PlayerPrefs.GetInt("MaxMana");
            playerStats.attack = PlayerPrefs.GetInt("Attack");
            playerStats.defense = PlayerPrefs.GetInt("Defense");
            bankSystem.Money = PlayerPrefs.GetInt("Money");
            inventorySystem.healthPotions = PlayerPrefs.GetInt("HealthPotions");
            inventorySystem.manaPotions = PlayerPrefs.GetInt("ManaPotions");
            inventorySystem.helmetLevel = PlayerPrefs.GetInt("HelmetLevel");
            inventorySystem.bootsLevel = PlayerPrefs.GetInt("BootsLevel");
            inventorySystem.bodyArmorLevel = PlayerPrefs.GetInt("BodyArmorLevel");
            timerSystem.timeElapsed = PlayerPrefs.GetFloat("TimeElapsed");
        }
    }
}
