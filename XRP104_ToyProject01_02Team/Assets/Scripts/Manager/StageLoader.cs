using UnityEngine;

public class StageLoader : MonoBehaviour
{
    private void Awake() => Load();

    private void Load()
    {
        DataManager.Instance.LoadStage(GameManager.Instance.StageNumber);
    }
}
