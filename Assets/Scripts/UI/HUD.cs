using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public TMP_Text levelText;
    public TMP_Text moneyText;
    public TMP_Text HPpotionText, MPpotionText, XPpotionText;
    public RectTransform HPbar;
    public RectTransform MPbar;
    public RectTransform XPbar;

    private PlayerStats playerStats;
    private InventorySystem inventorySystem;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        inventorySystem = FindObjectOfType<InventorySystem>();

        UpdateHUD();
    }

    void Update()
    {
        UpdateHUD();
    }

    public void UpdateHUD()
    {
        levelText.text = "lvl " + playerStats.level;
        moneyText.text = playerStats.money.ToString();
        HPpotionText.text = inventorySystem.healthPotions.ToString() + " / 10";
        MPpotionText.text = inventorySystem.manaPotions.ToString() + " / 10";
        XPpotionText.text = inventorySystem.xpPotions.ToString() + " / 3";
        UpdateHPBar();
        UpdateMPBar();
        UpdateXPBar();
    }
     
    private void UpdateHPBar()
    {
        float newWidth = (float)playerStats.health / (float)playerStats.maxHealth * HPbar.parent.GetComponent<RectTransform>().rect.width;
        HPbar.sizeDelta = new Vector2(newWidth, HPbar.sizeDelta.y);
    }

    private void UpdateMPBar()
    {
        float newWidth = (float)playerStats.mana / (float)playerStats.maxMana * MPbar.parent.GetComponent<RectTransform>().rect.width;
        MPbar.sizeDelta = new Vector2(newWidth, MPbar.sizeDelta.y);
    }

    private void UpdateXPBar()
    {
        float newWidth = (float)playerStats.experience / (float)playerStats.MaxXP * XPbar.parent.GetComponent<RectTransform>().rect.width;
        XPbar.sizeDelta = new Vector2(newWidth, XPbar.sizeDelta.y);
    }

    public void ConsumeHPpotion()
    {
        if(!inventorySystem.ConsumeHPpotion())
        {
            // play error sound
        }
    }
    
    public void ConsumeMPpotion()
    {
        if (!inventorySystem.ConsumeMPpotion())
        {
            // play error sound
        }
    }

    public void ConsumeXPpotion()
    {
        if (!inventorySystem.ConsumeXPpotion())
        {
            // play error sound
        }
    }
}
