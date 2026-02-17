using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelectUI : MonoBehaviour
{
    [SerializeField] private Button _backButton;
    
    public void LoadStage(int stage)
    {
        SceneManager.LoadScene(2);
    }
    
    public void ToTitle() => SceneManager.LoadScene(0);
}
