using System;

public static class GameEvents
{
    public static event Action OnGameStart;

    public delegate void GameEndDelegate(EndGameType endGameType);
    public static event GameEndDelegate OnGameEnd;

    public enum EndGameType
    {
        HPDepleted,
        MPDepleted,
        Resign,
        Win
    }

    public static void TriggerGameStart()
    {
        OnGameStart?.Invoke();
    }

    public static void TriggerGameEnd(EndGameType endGameType)
    {
        OnGameEnd?.Invoke(endGameType);
    }
}
