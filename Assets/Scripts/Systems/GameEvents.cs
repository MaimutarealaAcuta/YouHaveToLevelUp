using System;

public static class GameEvents
{
    public static event Action OnGameStart;
    public static event Action OnGameEnd;

    public static void TriggerGameStart()
    {
        OnGameStart?.Invoke();
    }

    public static void TriggerGameEnd()
    {
        OnGameEnd?.Invoke();
    }
}
