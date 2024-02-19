using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PNGallerySceneManager : MonoBehaviour
{
    public Button goToGallery;
    public Button goToDallE;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        goToGallery.onClick.AddListener(GoToGalleryScene);
        goToDallE.onClick.AddListener(GoToDallEGeneratorScene);
    }

    void GoToGalleryScene()
    {
        SceneManager.LoadScene(2);
    }

    void GoToDallEGeneratorScene()
    {
        SceneManager.LoadScene(1);
    }
}
