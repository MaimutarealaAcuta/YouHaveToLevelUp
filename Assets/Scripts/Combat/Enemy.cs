using UnityEngine;

public class Enemy
{
    public string name;
    public int level;
    public int health;
    public int maxHealth;
    public int attack;
    public int defense;
    public int experienceReward;
    public int goldReward;

    public delegate void EnemyDefeatedAction(int enemyLevel);
    public static event EnemyDefeatedAction OnEnemyDefeated;

    public Enemy(int playerLevel)
    {
        // Example logic for creating an enemy based on player level
        level = playerLevel;
        maxHealth = 50 + (level * 10);
        health = maxHealth;
        attack = 5 + (level * 2);
        defense = 5 + (level * 2);
        experienceReward = 20 * level;
        goldReward = 10 * level;
        name = "Goblin"; // Example enemy name
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
