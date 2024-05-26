using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    public BankSystem bank;
    public InventorySystem inventory;

    public void BuyHealthPotion()
    {
        if (bank.SpendMoney(10)) // Example cost
        {
            inventory.AddHealthPotion();
        }
    }

    public void BuyManaPotion()
    {
        if (bank.SpendMoney(10)) // Example cost
        {
            inventory.AddManaPotion();
        }
    }

    public void UpgradeHelmet()
    {
        if (bank.SpendMoney(50)) // Example cost
        {
            inventory.UpgradeHelmet();
        }
    }

    public void UpgradeBoots()
    {
        if (bank.SpendMoney(50)) // Example cost
        {
            inventory.UpgradeBoots();
        }
    }

    public void UpgradeBodyArmor()
    {
        if (bank.SpendMoney(100)) // Example cost
        {
            inventory.UpgradeBodyArmor();
        }
    }
}
