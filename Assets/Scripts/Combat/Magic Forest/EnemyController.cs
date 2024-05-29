using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Enemy enemyData;

    private Animator animator;
    public int currentHealth { get; private set; }

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

    public void ConfigureEnemy(Enemy data)
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

        // Set up enemy stats
        currentHealth = data.maxHealth;

        // Set other properties as needed
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(enemyData.enemyName + " died!");
        // Add death animation or other logic here
        Destroy(gameObject);
    }
}
