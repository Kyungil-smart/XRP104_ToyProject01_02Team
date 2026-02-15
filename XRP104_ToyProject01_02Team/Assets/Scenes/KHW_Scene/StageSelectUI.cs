using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectUI : MonoBehaviour
{
    public void SelectStage(int stage)
    {
        StageManager.SelectedStage = stage;
        SceneManager.LoadScene(2);
    }

    public void BackToTitle()
    {
        SceneManager.LoadScene(0);
    }
}
