using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [field: SerializeField] public int StageNumber { get; set; }

    private void Awake()
    {
        SingletonInit();
    }
    
    
}
