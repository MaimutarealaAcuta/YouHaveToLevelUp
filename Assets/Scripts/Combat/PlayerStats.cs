using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int level = 1;
    public int experience = 0;
    public int health = 100;
    public int maxHealth = 100;
    public int mana = 50;
    public int maxMana = 50;
    public int attack = 10;
    public int defense = 10;
    public int score = 0;

    private int[] xpTable = { 0, 100, 300, 600, 1000, 1500, 2100, 2800, 3600, 4500, 5500, 6600, 7800, 9100, 10500, 12000, 13600, 15300, 17100, 19000, 21000, 23100, 25300, 27600, 30000, 32500, 35100, 37800, 40600, 43500 };

    public delegate void LevelUpAction(int newLevel);
    public static event LevelUpAction OnLevelUp;

    void Start()
    {
        health = maxHealth;
        mana = maxMana;
    }

    public void AddExperience(int amount)
    {
        experience += amount;
        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        while (level < xpTable.Length && experience >= xpTable[level])
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        level++;
        maxHealth += 10; // Example increment
        health = maxHealth;
        maxMana += 5; // Example increment
        mana = maxMana;
        attack += 2; // Example increment
        defense += 2; // Example increment
        OnLevelUp?.Invoke(level);
        Debug.Log($"Leveled up to {level}! Health: {health}, Mana: {mana}, Attack: {attack}, Defense: {defense}");
    }

    public int GetNextLevelXP()
    {
        return xpTable[level];
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            health = 0;
            Debug.Log("Player is defeated!");
            // Add additional defeat logic here
        }
    }

    public void UseMana(int amount)
    {
        mana -= amount;
        if (mana < 0)
        {
            mana = 0;
        }
    }

    public void RestoreHealth(int amount)
    {
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public void RestoreMana(int amount)
    {
        mana += amount;
        if (mana > maxMana)
        {
            mana = maxMana;
        }
    }
}
