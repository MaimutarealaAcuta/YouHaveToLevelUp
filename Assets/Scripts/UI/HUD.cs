using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text levelText;
    public Slider experienceBar;
    public Text moneyText;
    public Text healthText;
    public Text manaText;
    public Text scoreText;

    private PlayerStats playerStats;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        UpdateHUD();
    }

    void Update()
    {
        UpdateHUD();
    }

    public void UpdateHUD()
    {
        levelText.text = "Level: " + playerStats.level;
        experienceBar.value = (float)playerStats.experience / playerStats.GetNextLevelXP();
        moneyText.text = "Money: " + playerStats.money;
        healthText.text = "Health: " + playerStats.health + "/" + playerStats.maxHealth;
        manaText.text = "Mana: " + playerStats.mana + "/" + playerStats.maxMana;
        scoreText.text = "Score: " + playerStats.score;
    }
}
