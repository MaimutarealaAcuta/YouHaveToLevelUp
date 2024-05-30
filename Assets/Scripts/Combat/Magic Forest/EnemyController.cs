using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Enemy enemyData;

    public Animator animator;
    public int currentHealth { get; private set; }
    private int attack;
    private int defense;
    private int experienceReward;
    private int goldReward;

    public delegate void EnemyDefeatedAction(int enemyLevel);
    public static event EnemyDefeatedAction OnEnemyDefeated;

    //void Start()
    //{
    //    if (enemyData != null)
    //    {
    //        ConfigureEnemy(enemyData);
    //    }
    //    else
    //    {
    //        Debug.LogError("EnemyData not assigned!");
    //    }
    //}

    public void ConfigureEnemy(Enemy data, int playerLevel)
    {
        // Set up animator
        animator = GetComponent<Animator>();
        if (data.animatorController != null)
        {
            animator.runtimeAnimatorController = data.animatorController;
        }
        else
        {
            Debug.LogError("Animator or Animator Controller not found!");
        }

        // Set up enemy stats based on player level
        currentHealth = data.GetHealth(playerLevel);
        attack = data.GetAttack(playerLevel);
        defense = data.GetDefense(playerLevel);
        experienceReward = data.GetExperienceReward(playerLevel);
        goldReward = data.GetGoldReward(playerLevel);
    }

    public void TakeDamage(int damage, int playerLevel)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die(playerLevel);
        }
    }

    void Die(int playerLevel)
    {
        Debug.Log(enemyData.enemyName + " died!");

        OnEnemyDefeated?.Invoke(playerLevel);

        Destroy(gameObject);
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }

    public int GetExperienceReward()
    {
        return experienceReward;
    }

    public int GetGoldReward()
    {
        return goldReward;
    }
}
