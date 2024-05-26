using UnityEngine;

public class BankSystem : MonoBehaviour
{
    public int money = 0;

    public delegate void MoneyChangedAction(int newBalance);
    public static event MoneyChangedAction OnMoneyChanged;

    public void AddMoney(int amount)
    {
        money += amount;
        OnMoneyChanged?.Invoke(money);
    }

    public bool SpendMoney(int amount)
    {
        if (money >= amount)
        {
            money -= amount;
            OnMoneyChanged?.Invoke(money);
            return true;
        }
        else
        {
            Debug.Log("Not enough money!");
            return false;
        }
    }

    public int GetMoney()
    {
        return money;
    }
}
