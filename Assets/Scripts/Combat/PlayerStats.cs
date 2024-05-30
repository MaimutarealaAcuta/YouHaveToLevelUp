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

    public int MaxXP { get { return 50 * level * (level + 1); } }

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

    public void AddExperiencePerc(int percentage)
    {
        AddExperience(MaxXP * percentage / 100);
    }

    private void CheckLevelUp()
    {
        while (level < 100 && experience >= MaxXP)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        experience -= MaxXP;
        level++;
        maxHealth = maxHealth * 11 / 10; // +10%
        health = health * 11 / 10; // +10%
        maxMana = maxMana * 105 / 100; // +5%
        mana = mana * 105 / 100; // +5%
        attack += 2; // Example increment
        defense += 2; // Example increment
        OnLevelUp?.Invoke(level);
        Debug.Log($"Leveled up to {level}! Health: {health}, Mana: {mana}, Attack: {attack}, Defense: {defense}");
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

    public void RestoreHealthPerc(int percentage)
    {
        RestoreHealth(maxHealth * percentage / 100);
    }

    public void RestoreMana(int amount)
    {
        mana += amount;
        if (mana > maxMana)
        {
            mana = maxMana;
        }
    }

    public void RestoreManaPerc(int percentage)
    {
        RestoreMana(maxMana * percentage / 100);
    }
}
