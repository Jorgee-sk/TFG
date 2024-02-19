

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DallESceneManager : MonoBehaviour
{
    public Button goToGalleryButton;

    public Button goToPNGGalleryButton;
    // Start is called before the first frame update
    void Start()
    {
        goToGalleryButton.onClick.AddListener(GoToGalleryScene);
        goToPNGGalleryButton.onClick.AddListener(GoToPNGGallery);
    }

    void GoToGalleryScene()
    {
        SceneManager.LoadScene(2);
    }

    void GoToPNGGallery()
    {
        SceneManager.LoadScene(3);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
