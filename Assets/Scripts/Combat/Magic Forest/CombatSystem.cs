using UnityEngine;
using System.Collections;
using TMPro;

public class CombatSystem : MonoBehaviour
{
    [SerializeField]
    private PlayerStats player;
    [SerializeField]
    private TextMeshPro combatLog;

    [SerializeField]
    private Enemy[] enemies; // Array of enemy scriptable objects
    [SerializeField]
    private Transform enemySpawnPoint; // Spawn point for the enemy

    [SerializeField]
    private int logLimit = 8; // Limit for the log entries
    private string[] combatLogEntries;
    private int logIndex = 0;
    private bool logIsFull = false;

    [Header("Combo resources")]
    [SerializeField]
    private AudioSource sfxSource;
    [SerializeField]
    private AudioClip slashClip;

    private EnemyController currentEnemy;
    private bool canHit = true;
    [SerializeField]
    private float hitCooldown = 0.25f; // 4 hits per second
    private Camera mainCamera;

    public delegate void SwordSlashAction();
    public static event SwordSlashAction OnSwordSlash;

    void Start()
    {
        mainCamera = Camera.main;
        combatLogEntries = new string[logLimit];
        SpawnEnemy();
    }

    void Update()
    {
        if (canHit && Input.GetMouseButton(0) && IsHitRegistered()) // Left click for physical attack
        {
            PerformPhysicalAttack();
            StartCoroutine(HitCooldown());
        }
        else if (canHit && Input.GetMouseButton(1) && IsHitRegistered()) // Right click for magic attack
        {
            PerformMagicAttack();
            StartCoroutine(HitCooldown());
        }
    }

    bool IsHitRegistered()
    {
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 0);

        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }

    public void PerformPhysicalAttack()
    {
        int damage = player.attack - currentEnemy.enemyData.defense;
        if (damage < 0) damage = 0;
        currentEnemy.TakeDamage(damage);

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
        if (player.mana >= 10) // Example mana cost
        {
            int damage = player.attack * 2 - currentEnemy.enemyData.defense; // Example magic damage formula
            if (damage < 0) damage = 0;
            player.UseMana(10);
            currentEnemy.TakeDamage(damage);

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

    IEnumerator HitCooldown()
    {
        canHit = false;
        yield return new WaitForSeconds(hitCooldown);
        canHit = true;
    }

    public void EnemyCounterAttack()
    {
        int damage = currentEnemy.enemyData.attack - player.defense;
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
        player.AddExperience(currentEnemy.enemyData.experienceReward);
        FindObjectOfType<BankSystem>().AddMoney(currentEnemy.enemyData.goldReward);
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
        GameObject enemyInstance = Instantiate(randomEnemyData.enemyPrefab, enemySpawnPoint.position, Quaternion.identity);
        enemyInstance.transform.rotation = Quaternion.Euler(0, 180, 0);

        // Get the EnemyController component and configure it
        currentEnemy = enemyInstance.GetComponent<EnemyController>();
        if (currentEnemy != null)
        {
            currentEnemy.enemyData = randomEnemyData;
            currentEnemy.ConfigureEnemy(randomEnemyData);
        }
        else
        {
            Debug.LogError("EnemyController not found on the instantiated enemy prefab!");
        }

        AddToCombatLog($"A wild {currentEnemy.enemyData.enemyName} appears!");
    }

    private void AddToCombatLog(string newEntry)
    {
        combatLogEntries[logIndex] = newEntry;
        logIndex = (logIndex + 1) % logLimit;
        if (logIndex == 0)
        {
            logIsFull = true;
        }

        UpdateCombatLogUI();
    }

    private void UpdateCombatLogUI()
    {
        combatLog.text = "";
        int start = logIsFull ? logIndex : 0;
        int count = logIsFull ? logLimit : logIndex;

        for (int i = 0; i < count; i++)
        {
            int index = (start + i) % logLimit;
            combatLog.text += combatLogEntries[index] + "\n";
        }
    }
}
