using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    public int score = 0;

    void Start()
    {
        PlayerStats.OnLevelUp += AddScoreForLevelUp;
        EnemyController.OnEnemyDefeated += AddScoreForEnemyDefeat;
    }

    void OnDestroy()
    {
        PlayerStats.OnLevelUp -= AddScoreForLevelUp;
        EnemyController.OnEnemyDefeated -= AddScoreForEnemyDefeat;
    }

    public void AddScoreForLevelUp(int level)
    {
        score += level * 100;
        Debug.Log("Score added for leveling up: " + level * 100);
    }

    public void AddScoreForEnemyDefeat(int enemyLevel)
    {
        score += enemyLevel * 50;
        Debug.Log("Score added for defeating enemy: " + enemyLevel * 50);
    }
}
