using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GallerySceneHandler : MonoBehaviour
{
    public Button goMenuButton;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        goMenuButton.onClick.AddListener(GoMenuScene);
    }

    void GoMenuScene()
    {
        SceneManager.LoadScene(6);
    }

}
