using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GallerySceneHandler : MonoBehaviour
{
    public Button goToPNGGallery;
    public Button goToDallE;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        goToPNGGallery.onClick.AddListener(GoToGalleryPNGScene);
        goToDallE.onClick.AddListener(GoToDallEGeneratorScene);
    }

    void GoToGalleryPNGScene()
    {
        SceneManager.LoadScene(3);
    }

    void GoToDallEGeneratorScene()
    {
        SceneManager.LoadScene(1);
    }
}
