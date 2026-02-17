using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    [SerializeField] private List<StageInfo> _stages = new();
    
    private void Awake()
    {
        SingletonInit();
    }

    public void LoadStage(int stageIndex)
    {
        Instantiate(_stages[stageIndex]);
    }
}
