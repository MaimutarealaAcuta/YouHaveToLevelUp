using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "ScriptableObjects/Enemy", order = 1)]
public class Enemy : ScriptableObject
{
    public string enemyName;
    public int baseHealth;
    public int baseAttack;
    public int baseDefense;
    public int baseExperienceReward;
    public int baseGoldReward;

    public RuntimeAnimatorController animatorController;
    public GameObject enemyPrefab;

    // Methods to calculate stats based on player level
    public int GetHealth(int playerLevel)
    {
        return baseHealth + (playerLevel * 10);
    }

    public int GetAttack(int playerLevel)
    {
        return baseAttack + (playerLevel * 2);
    }

    public int GetDefense(int playerLevel)
    {
        return baseDefense + (playerLevel * 2);
    }

    public int GetExperienceReward(int playerLevel)
    {
        return baseExperienceReward + (playerLevel * 5);
    }

    public int GetGoldReward(int playerLevel)
    {
        return baseGoldReward + (playerLevel * 2);
    }
}
