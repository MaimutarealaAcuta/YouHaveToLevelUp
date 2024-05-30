using UnityEngine;
using System.Collections;
using TMPro;

public class CombatSystem : MonoBehaviour
{
    [SerializeField]
    private PlayerStats player;
    [SerializeField]
    private TextMeshProUGUI combatLogUI;

    [SerializeField]
    private Enemy[] enemies; // Array of enemy scriptable objects
    [SerializeField]
    private Transform enemySpawnPoint; // Spawn point for the enemy
    [SerializeField]
    private Transform enemyParentNode; // Parent node for the enemy

    [SerializeField]
    private int logLimit = 8; // Limit for the log entries
    private string[] combatLog;
    private int logIndex = 0;
    private bool logIsFull = false;

    private EnemyController currentEnemy;
    private bool canHit = true;
    [SerializeField]
    private float hitCooldown = 0.25f; // 4 hits per second
    [SerializeField]
    private int baseManaCost = 10;

    public InventorySystem inventorySystem;

    public delegate void SwordSlashAction();
    public static event SwordSlashAction OnSwordSlash;

    void Start()
    {
        inventorySystem = FindObjectOfType<InventorySystem>();
        combatLog = new string[logLimit];
        SpawnEnemy();
    }

    public void PhysicalAttack()
    {
        if (canHit)
        {
            PerformPhysicalAttack();
            StartCoroutine(HitCooldown());
        }
    }

    public void MagicAttack()
    {
        if (canHit)
        {
            PerformMagicAttack();
            StartCoroutine(HitCooldown());
        }
    }

    public void PerformPhysicalAttack()
    {
        int damage = player.attack + inventorySystem.GetSwordLevel() - currentEnemy.enemyData.GetDefense(player.level);
        if (damage < 0) damage = 0;

        currentEnemy.TakeDamage(damage, player.level);
        currentEnemy.animator.SetTrigger("TakeDmg");

        OnSwordSlash?.Invoke();
        AddToCombatLog($"You dealt {damage} physical damage!");

        if (currentEnemy.currentHealth <= 0)
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
        if (player.mana >= GetManaCost())
        {
            int damage = (player.attack + +inventorySystem.GetSwordLevel()) * 2 - currentEnemy.enemyData.GetDefense(player.level);
            if (damage < 0) damage = 0;
            player.UseMana(10);

            currentEnemy.TakeDamage(damage, player.level);
            currentEnemy.animator.SetTrigger("TakeDmg");

            OnSwordSlash?.Invoke();
            AddToCombatLog($"You dealt {damage} magic damage!");

            if (currentEnemy.currentHealth <= 0)
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
            AddToCombatLog("Not enough mana!");
        }
    }

    int GetManaCost()
    {
        return Mathf.CeilToInt(baseManaCost + player.level * 0.2f);
    }

    IEnumerator HitCooldown()
    {
        canHit = false;
        yield return new WaitForSeconds(hitCooldown);
        canHit = true;
    }

    public void EnemyCounterAttack()
    {
        int damage = currentEnemy.enemyData.GetAttack(player.level) - player.defense - inventorySystem.GetShieldLevel() + inventorySystem.GetHelmetLevel();
        if (damage < 0) damage = 0;
        player.TakeDamage(damage);
        AddToCombatLog($"Enemy dealt {damage} damage to you!");

        if (player.health <= 0)
        {
            AddToCombatLog("You have been defeated!");
            // Handle player defeat logic
        }
    }

    public void DefeatEnemy()
    {
        AddToCombatLog($"{currentEnemy.enemyData.enemyName} defeated!");
        player.AddExperience(currentEnemy.enemyData.GetExperienceReward(player.level));
        FindObjectOfType<BankSystem>().AddMoney(currentEnemy.enemyData.GetGoldReward(player.level));
        Destroy(currentEnemy.gameObject);
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        if (enemies.Length == 0)
        {
            Debug.LogError("No enemies assigned in the inspector!");
            return;
        }

        int randomIndex = Random.Range(0, enemies.Length);
        Enemy randomEnemyData = enemies[randomIndex];

        // Instantiate the enemy prefab
        GameObject enemyInstance = Instantiate(randomEnemyData.enemyPrefab, enemySpawnPoint.position, Quaternion.identity, enemyParentNode);
        //enemyInstance.transform.position = randomEnemyData.enemyPrefab.transform.position;
        //enemyInstance.transform.rotation = Quaternion.Euler(0, 180, 0);

        // Get the EnemyController component and configure it
        currentEnemy = enemyInstance.GetComponent<EnemyController>();
        if (currentEnemy != null)
        {
            currentEnemy.enemyData = randomEnemyData;
            currentEnemy.ConfigureEnemy(randomEnemyData, player.level);
        }
        else
        {
            Debug.LogError("EnemyController not found on the instantiated enemy prefab!");
        }

        AddToCombatLog($"A wild {currentEnemy.enemyData.enemyName} appears!");
    }

    private void AddToCombatLog(string newEntry)
    {
        combatLog[logIndex] = newEntry;
        logIndex = (logIndex + 1) % logLimit;
        if (logIndex == 0)
        {
            logIsFull = true;
        }

        UpdateCombatLogUI();
    }

    private void UpdateCombatLogUI()
    {
        combatLogUI.text = "";
        int start = logIsFull ? logIndex : 0;
        int count = logIsFull ? logLimit : logIndex;

        for (int i = 0; i < count; i++)
        {
            int index = (start + i) % logLimit;
            combatLogUI.text += combatLog[index] + "\n";
        }
    }
}
