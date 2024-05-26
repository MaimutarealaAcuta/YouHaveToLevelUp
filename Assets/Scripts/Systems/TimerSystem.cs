using UnityEngine;
using UnityEngine.UI;

public class TimerSystem : MonoBehaviour
{
    public Text timerText;
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
        if (isTimerRunning)
        {
            timeElapsed += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }

    public void StartTimer()
    {
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeElapsed / 60);
        int seconds = Mathf.FloorToInt(timeElapsed % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
