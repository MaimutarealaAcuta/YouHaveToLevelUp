using UnityEngine;
using UnityEngine.UI;

public class CombatSystem : MonoBehaviour
{
    public PlayerStats player;
    public Enemy currentEnemy;
    public Text combatLog;

    void Start()
    {
        SpawnEnemy();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left click for physical attack
        {
            PerformPhysicalAttack();
        }
        else if (Input.GetMouseButtonDown(1)) // Right click for magic attack
        {
            PerformMagicAttack();
        }
    }

    public void PerformPhysicalAttack()
    {
        int damage = player.attack - currentEnemy.defense;
        if (damage < 0) damage = 0;
        currentEnemy.TakeDamage(damage);
        combatLog.text += $"You dealt {damage} physical damage!\n";

        if (currentEnemy.health <= 0)
        {
            DefeatEnemy();
        }
        else
        {
            EnemyCounterAttack();
        }
    }

    public void PerformMagicAttack()
    {
        if (player.mana >= 10) // Example mana cost
        {
            int damage = player.attack * 2 - currentEnemy.defense; // Example magic damage formula
            if (damage < 0) damage = 0;
            player.UseMana(10);
            currentEnemy.TakeDamage(damage);
            combatLog.text += $"You dealt {damage} magic damage!\n";

            if (currentEnemy.health <= 0)
            {
                DefeatEnemy();
            }
            else
            {
                EnemyCounterAttack();
            }
        }
        else
        {
            combatLog.text += "Not enough mana!\n";
        }
    }

    public void EnemyCounterAttack()
    {
        int damage = currentEnemy.attack - player.defense;
        if (damage < 0) damage = 0;
        player.TakeDamage(damage);
        combatLog.text += $"Enemy dealt {damage} damage to you!\n";

        if (player.health <= 0)
        {
            combatLog.text += "You have been defeated!\n";
            // Handle player defeat logic
        }
    }

    public void DefeatEnemy()
    {
        combatLog.text += "Enemy defeated!\n";
        player.AddExperience(currentEnemy.experienceReward);
        FindObjectOfType<BankSystem>().AddMoney(currentEnemy.goldReward);
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        // Logic to spawn a new enemy from the pool based on the player's level
        currentEnemy = new Enemy(player.level);
        combatLog.text += $"A wild {currentEnemy.name} appears!\n";
    }
}
