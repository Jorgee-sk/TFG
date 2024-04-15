using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSceneHandler : MonoBehaviour
{
    public Button goToPNGGallery;
    public Button goToDallE;
    public Button goToGameScene;
    public Button goToGallery;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        goToPNGGallery.onClick.AddListener(GoToGalleryPNGScene);
        goToDallE.onClick.AddListener(GoToDallEGeneratorScene);
        goToGameScene.onClick.AddListener(GoToGameScene);
        goToGallery.onClick.AddListener(GoToGallery);
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
        SceneManager.LoadScene(5);
    }
    
    void GoToGallery()
    {
        SceneManager.LoadScene(2);
    }
}
