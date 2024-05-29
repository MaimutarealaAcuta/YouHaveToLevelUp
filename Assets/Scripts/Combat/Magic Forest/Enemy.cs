using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "ScriptableObjects/Enemy", order = 1)]
public class Enemy : ScriptableObject
{
    public string enemyName;
    public int level;
    public int health;
    public int maxHealth;
    public int attack;
    public int defense;
    public int experienceReward;
    public int goldReward;

    public RuntimeAnimatorController animatorController;
    public GameObject enemyPrefab; // Reference to the enemy prefab
}
