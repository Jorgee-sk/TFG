using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSceneHandler : MonoBehaviour
{
    public Button goToGameScene;
    public Button goToToolMenu;

    // Start is called before the first frame update
    void OnEnable()
    {
        goToGameScene.onClick.AddListener(GoToGameScene);
        goToToolMenu.onClick.AddListener(GoToToolMenu);
    }

    void GoToGameScene()
    {
        SceneManager.LoadScene(5);
    }
    
    void GoToToolMenu()
    {
        SceneManager.LoadScene(6);
    }
}
