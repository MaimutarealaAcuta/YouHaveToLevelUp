using UnityEngine;
using UnityEngine.UI;
using static GameEvents;

public class TimerSystem : MonoBehaviour
{
    public float timeElapsed = 0;
    private bool isTimerRunning = false;

    void Start()
    {
        // Subscribe to the game start event
        GameEvents.OnGameStart += StartTimer;
        GameEvents.OnGameEnd += StopTimer;
    }

    void OnDestroy()
    {
        // Unsubscribe from the game start event
        GameEvents.OnGameStart -= StartTimer;
        GameEvents.OnGameEnd -= StopTimer;
    }

    void Update()
    {
        if(isTimerRunning)
            timeElapsed += Time.deltaTime;
    }

    public void StartTimer()
    {
        isTimerRunning = true;
        timeElapsed = 0;
    }

    public void StopTimer(EndGameType endGameType)
    {
        isTimerRunning = false;
    }

    public string getTime()
    {
        int minutes = Mathf.FloorToInt(timeElapsed / 60);
        int seconds = Mathf.FloorToInt(timeElapsed % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    #region UI
    [Header("GUI")]
    public GameObject InstructionsPanel;

    public void StartGame()
    {
        GameEvents.TriggerGameStart();
        InstructionsPanel.SetActive(false);
    }
    #endregion
}
