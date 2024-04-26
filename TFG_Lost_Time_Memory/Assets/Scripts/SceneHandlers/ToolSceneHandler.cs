using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToolSceneHandler : MonoBehaviour
{
    public Button goToPNGGallery;
    public Button goToDallE;
    public Button goToGameScene;
    public Button goToGallery;
    public Button exitButton;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        goToPNGGallery.onClick.AddListener(GoToGalleryPNGScene);
        goToDallE.onClick.AddListener(GoToDallEGeneratorScene);
        goToGameScene.onClick.AddListener(GoToGameScene);
        goToGallery.onClick.AddListener(GoToGallery);
        exitButton.onClick.AddListener(ExitGame);
    }

    void GoToGalleryPNGScene()
    {
        SceneManager.LoadScene(3);
    }

    void GoToDallEGeneratorScene()
    {
        SceneManager.LoadScene(1);
    }
    
    void GoToGameScene()
    {
        SceneManager.LoadScene(4);
    }

    void GoToGallery()
    {
        SceneManager.LoadScene(2);
    }

    void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
