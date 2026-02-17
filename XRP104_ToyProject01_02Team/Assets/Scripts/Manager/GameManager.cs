using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [field: SerializeField] public int StageNumber { get; set; }

    public event Action OnStageClear;

    
    private void Awake()
    {
        SingletonInit();
    }

    public void StageClear()
    {
        Debug.Log("StageClear");
        OnStageClear?.Invoke();
    }
}
