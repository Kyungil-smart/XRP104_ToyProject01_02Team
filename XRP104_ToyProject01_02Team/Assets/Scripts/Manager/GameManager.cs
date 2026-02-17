using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [field: SerializeField] public int StageNumber { get; set; }

    public event Action OnGameStart;
    public event Action OnStageClear;
    public event Action OnGameOver;
    public event Action<bool> OnPause;
    
    public bool IsGameRunning { get; private set; }
    public bool IsGamePaused { get; private set; }

    
    private void Awake()
    {
        SingletonInit();

        IsGamePaused = false;
        IsGameRunning = false;
    }

    public void GameStart()
    {
        IsGameRunning = true;
        OnGameStart?.Invoke();
    }

    public void GamePause(bool isPaused)
    {
        IsGamePaused = isPaused;
        OnPause?.Invoke(isPaused);
    }

    public void StageClear()
    {
        IsGameRunning = false;
        OnStageClear?.Invoke();
    }

    public void GameOver()
    {
        IsGameRunning = false;
        OnGameOver?.Invoke();
    }
}
