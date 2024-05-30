using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using static GameEvents;

public class EndGameScript : MonoBehaviour
{
    public TMP_Text conclusionText;
    public TMP_Text statsText;
    public GameObject endGamePanel;

    private TimerSystem timerSystem;
    private ScoringSystem scoringSystem;
    private InventorySystem inventorySystem;
    private BankSystem bankSystem;
    
    
    void Start()
    {
        timerSystem = FindObjectOfType<TimerSystem>();
        scoringSystem = FindObjectOfType<ScoringSystem>();
        inventorySystem = FindObjectOfType<InventorySystem>();
        bankSystem = FindObjectOfType<BankSystem>();

        GameEvents.OnGameEnd += ToggleEndGame;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resign()
    {
        GameEvents.TriggerGameEnd(EndGameType.Resign);
    }

    public void ToggleEndGame(EndGameType endGameType )
    {
        GameEvents.OnGameEnd -= ToggleEndGame;
        endGamePanel.SetActive(true);
        switch (endGameType)
        {
            case EndGameType.Win:
                conclusionText.text = "You Win!";
                break;
            case EndGameType.HPDepleted:
                conclusionText.text = "HP depleted! You died!";
                break;
            case EndGameType.MPDepleted:
                conclusionText.text = "Mana depleted! You died!";
                break;
            case EndGameType.Resign:
                conclusionText.text = "You resigned!";
                break;
        }

        StringBuilder statsBuilder = new StringBuilder();
        statsBuilder.AppendLine("Time: " + timerSystem.getTime());
        statsBuilder.AppendLine("Money: " + bankSystem.GetMoney());
        statsBuilder.AppendLine();
        statsBuilder.AppendLine("Score: " + scoringSystem.score);

        statsText.text = statsBuilder.ToString();
    }

    public void returnToMainMenu()
    {
        // Load the main menu scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
