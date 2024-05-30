using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MarketScript : MonoBehaviour
{
    private BankSystem bankSystem;
    private InventorySystem inventorySystem;
    private PlayerStats playerStats;
    

    void Start()
    {
        bankSystem = FindObjectOfType<BankSystem>();
        inventorySystem = FindObjectOfType<InventorySystem>();

        PlayerStats.OnLevelUp += increasePotionsPrice;

    }

    // Update is called once per frame
    void Update()
    {
        updatePotionsShop();
        updateBlacksmithShop();
    }

    #region Potions Shop
    int healthPotionPrice = 10;
    int manaPotionPrice = 15;
    int experiencePotionPrice = 50;

    [Header("Potions Shop")]
    [Space(5)]
    public GameObject potionsShop;
    
    public TMP_Text hpPriceText;
    public TMP_Text mpPriceText;
    public TMP_Text xpPriceText;

    public TMP_Text hpInvText;
    public TMP_Text mpInvText;
    public TMP_Text xpInvText;
    public void TogglePotionsShop(bool open)
    {
        potionsShop.SetActive(open);
    }

    private void increasePotionsPrice(int level)
    {
        healthPotionPrice = healthPotionPrice * 110 / 100;
        manaPotionPrice = manaPotionPrice * 115 / 100;
        experiencePotionPrice = experiencePotionPrice * 120 / 100;
    }

    private void updatePotionsShop()
    {
        hpPriceText.text = healthPotionPrice.ToString();
        mpPriceText.text = manaPotionPrice.ToString();
        xpPriceText.text = experiencePotionPrice.ToString();

        hpInvText.text = inventorySystem.healthPotions.ToString() + "/ 10";
        mpInvText.text = inventorySystem.manaPotions.ToString() + "/ 10";
        xpInvText.text = inventorySystem.xpPotions.ToString() + "/ 3";
    }

    public void buyHealthPotion()
    {
        if (inventorySystem.healthPotions < 10 && bankSystem.SpendMoney(healthPotionPrice))
        {
            inventorySystem.AddHealthPotion();
        }
    }

    public void buyManaPotion()
    {
        if (inventorySystem.manaPotions < 10 && bankSystem.SpendMoney(manaPotionPrice))
        {
            inventorySystem.AddManaPotion();
        }
    }

    public void buyExperiencePotion()
    {
        if (inventorySystem.xpPotions < 3 && bankSystem.SpendMoney(experiencePotionPrice))
        {
            inventorySystem.AddXpPotion();
        }
    }

    #endregion

    #region Blacksmith Shop

    [Header("Blacksmith Shop")]
    [Space(5)]
    
    public GameObject blacksmithShop;

    public TMP_Text helmPriceText;
    public TMP_Text shieldPriceText;
    public TMP_Text swordPriceText;

    public TMP_Text helmLvlText;
    public TMP_Text shieldLvlText;
    public TMP_Text swordLvlText;

    private int helmPrice = 10;
    private int shieldPrice = 15;
    private int swordPrice = 20;

    public void ToggleBlacksmithShop(bool open)
    {
        blacksmithShop.SetActive(open);
    }

    private void updateBlacksmithShop()
    {
        helmPriceText.text = helmPrice.ToString();
        shieldPriceText.text = shieldPrice.ToString();
        swordPriceText.text = swordPrice.ToString();

        helmLvlText.text = "lvl " + inventorySystem.helmetLevel.ToString();
        shieldLvlText.text = "lvl " + inventorySystem.shieldLevel.ToString();
        swordLvlText.text = "lvl " + inventorySystem.swordLevel.ToString();
    }

    public void upgradeHelm()
    {
        if (bankSystem.SpendMoney(helmPrice))
        {
            inventorySystem.UpgradeHelmet();
            helmPrice = helmPrice * 115 / 100;
        }
    }

    public void upgradeShield()
    {
        if (bankSystem.SpendMoney(shieldPrice))
        {
            inventorySystem.UpgradeShield();
            shieldPrice = shieldPrice * 115 / 100;
        }
    }

    public void upgradeSword()
    {
        if (bankSystem.SpendMoney(swordPrice))
        {
            inventorySystem.UpgradeSword();
            swordPrice = swordPrice * 115 / 100;
        }
    }
    #endregion

}
