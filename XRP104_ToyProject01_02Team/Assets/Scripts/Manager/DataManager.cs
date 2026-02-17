using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    [SerializeField] private List<StageInfo> _stages = new();
    [SerializeField] private List<Itembase> _items = new();
    
    private void Awake()
    {
        SingletonInit();
    }

    public void LoadStage(int stageIndex)
    {
        Instantiate(_stages[stageIndex]);
    }

    public void DropRandomItem(Transform point)
    {
        int index = Random.Range(0, _items.Count);
        
        Instantiate(_items[index], point.position, Quaternion.identity);
    }
}
