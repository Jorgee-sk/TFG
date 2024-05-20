using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitMenu : MonoBehaviour
{
    public Button restartGameButton;
    public Button exitToMenu;
    public TMP_Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        restartGameButton.onClick.AddListener(RestartGame);
        exitToMenu.onClick.AddListener(ExitToMenu);
        highScoreText.text = "High score: " + PlayerPrefs.GetInt("HighScore");
    }
    
    void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    void ExitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(4);
    }

    // Update is called once per frame
    void Update()
    {
        highScoreText.text = "High score: " + PlayerPrefs.GetInt("HighScore");
    }
}